using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace ProyectoOFI.Usuario
{
    public class Recuperacion
    {
        /* El fragmento de código declara propiedades privadas y protegidas y un campo en la clase
        `DRecuperacion`. */
        private SmtpClient smtpClient;
        protected string remitenteCorreo { get; set; }
        protected string password { get; set; }
        protected string host { get; set; }
        protected int port { get; set; }
        protected bool ssl { get; set; }

        /// <summary>
        /// La función inicializa un objeto SmtpClient con las credenciales, el host, el puerto y la
        /// configuración de SSL especificados.
        /// </summary>
        protected void initialzeSmtpClient()
        {
            smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(remitenteCorreo, password);
            smtpClient.Host = host;
            smtpClient.Port = port;
            smtpClient.EnableSsl = ssl;
        }

        /// <summary>
        /// La función `enviarCorreo` envía un correo electrónico con un asunto, cuerpo y lista de
        /// destinatarios especificados.
        /// </summary>
        /// <param name="subject">El asunto del correo electrónico que se enviará.</param>
        /// <param name="body">El parámetro del cuerpo es una cadena que representa el contenido del
        /// mensaje de correo electrónico. Puede contener texto, HTML o una combinación de
        /// ambos.</param>
        /// <param name="destinatarioCorreo">El parámetro "destinatarioCorreo" es una lista de cadenas
        /// que representa las direcciones de correo electrónico de los destinatarios del correo
        /// electrónico.</param>
        public void enviarCorreo(string subject, string body, List<string> destinatarioCorreo)
        {
            var MsjCorreo = new MailMessage();
            try
            {
                MsjCorreo.From = new MailAddress(remitenteCorreo);
                foreach (string mail in destinatarioCorreo)
                {
                    MsjCorreo.To.Add(mail);
                }
                MsjCorreo.Subject = subject;
                MsjCorreo.Body = body;
                MsjCorreo.Priority = MailPriority.Normal;
                smtpClient.Send(MsjCorreo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MsjCorreo.Dispose();
                smtpClient.Dispose();
            }
        }
        /// <summary>
        /// La función "NotificaciónCambio" envía un correo electrónico de notificación a un usuario si
        /// su cuenta ha cambiado y devuelve un mensaje que indica el estado de la notificación.
        /// </summary>
        /// <param name="usuarioSolicitado">El parámetro "usuarioSolicitado" es una cadena que
        /// representa el nombre de usuario o correo electrónico del usuario para quien se está
        /// generando la notificación.</param>
        /// <returns>
        /// El método está devolviendo una cadena.
        /// </returns>
        public string NotificacionCambio(string usuarioSolicitado)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("Correo", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dato", usuarioSolicitado);
                SqlDataReader reader = cmd.ExecuteReader();
                cmd.CommandType = CommandType.Text;

                if (reader.HasRows)
                {
                    reader.Read();
                    string estadoUsuario = reader.GetString(reader.GetOrdinal("Estado"));
                    if (estadoUsuario == "ACTIVO")
                    {
                        string nombreUsuario = reader.GetString(1);
                        string correoUsuario = reader.GetString(2);
                        string passUsuario = reader.GetString(6);

                        var mailservice = new DCorreoSoporte();
                        mailservice.enviarCorreo(
                            subject: "ofi Sistema de seguimiento de lotes: Notificación de seguridad",
                            body: "Hola, estimado/a " + nombreUsuario + "\nLos datos de su cuenta en ofi Sistema de seguimiento de lotes ha cambiado recientemente.\n" +
                            "\nLe informamos que se ha hecho un cambio en su cuenta, si usted realizó dicho cambio ignore este correo," +
                            "\nPero si usted no ha realizado ningún cambio en su cuenta," +
                            "\nle pedimos que cambie su contraseña inmediatamente una vez ingrese al sistema..." +
                            "\n" +
                            "\nSi no está seguro de si usted o su administrador ha realizado este cambio," +
                            " debe ponerse en contacto con su administrador inmediatamente",
                            destinatarioCorreo: new List<string> { correoUsuario });

                        return "Hola, " + nombreUsuario + "\nUsted solicitó recuperar su contraseña.\n" +
                            "Por favor revise su correo: " + correoUsuario +
                            "\nSin embargo, le pedimos que cambie su contraseña inmediatamente una vez ingrese al sistema...";
                    }
                    else
                    {
                        return "Este usuario no cuenta con una cuenta activa";
                    }
                }
                else
                {
                    return "Lo sentimos, no tiene una cuenta con ese correo o nombre de usuario";
                }
            }
            catch (Exception ex)
            {
                return "ERROR, Algo anda mal: " + ex.Message;
            }
            finally
            {
                Conexion.cerrar();
            }
        }

        /// <summary>
        /// La función "RecoverPassword2" toma un nombre de usuario solicitado y una nueva contraseña, y
        /// devuelve una cadena.
        /// </summary>
        /// <param name="usuarioSolicitado">El nombre de usuario del usuario que solicitó la
        /// recuperación de la contraseña.</param>
        /// <param name="nuevaContraseña">El parámetro "nuevaContraseña" es una cadena que representa la
        /// nueva contraseña que el usuario quiere establecer.</param>
        public string RecoverPassword2(string usuarioSolicitado, string nuevaContraseña)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("CambiarContraseñaYEnviarCorreo", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Dato", usuarioSolicitado);
                cmd.Parameters.AddWithValue("@Password", Encrip.Encriptar(Encrip.Encriptar(nuevaContraseña)));

                SqlParameter nuevoPasswordParam = new SqlParameter("@NuevoPassword", SqlDbType.VarChar, 255);
                nuevoPasswordParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(nuevoPasswordParam);

                SqlParameter correoParam = new SqlParameter("@Correo", SqlDbType.VarChar, 100);
                correoParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(correoParam);

                SqlParameter nombreUsuarioParam = new SqlParameter("@Login", SqlDbType.VarChar, 100);
                nombreUsuarioParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(nombreUsuarioParam);

                cmd.ExecuteNonQuery();

                string nombreUsuario = nombreUsuarioParam.Value.ToString();
                string nuevoPassword = nuevoPasswordParam.Value.ToString();
                string correoUsuario = correoParam.Value.ToString();

                var mailservice = new DCorreoSoporte();
                mailservice.enviarCorreo(
                    subject: "ofi Sistema de seguimiento de lotes: Solicitud de recuperación de Contraseña",
                    body: "Hola, " + nombreUsuario + "\nUsted solicitó recuperar su contraseña.\n" +
                    "\nSe le proporcionará una nueva contraseña por seguridad" +
                    "\nSu nueva contraseña es: " + nuevaContraseña +
                    "\n" +
                    "\nSin embargo, le pedimos que cambie su contraseña una vez que ingrese al sistema..." +
                    "\n" +
                    "\nSi no está seguro de si usted o su administrador ha realizado este restablecimiento," +
                    " debe ponerse en contacto con su administrador inmediatamente",
                    destinatarioCorreo: new List<string> { correoUsuario });

                return "Hola, " + nombreUsuario + "\nUsted solicitó recuperar su contraseña.\n" +
                    "Por favor revise su correo: " + correoUsuario +
                    "\nSin embargo, le pedimos que cambie su contraseña una vez que ingrese al sistema...";
            }
            catch (Exception ex)
            {
                return "ERROR, Algo anda mal: " + ex.Message;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
    }
}
