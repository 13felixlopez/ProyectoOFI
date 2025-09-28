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
                MsjCorreo.IsBodyHtml = true;
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
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("Correo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Dato", usuarioSolicitado);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            string estadoUsuario = reader["Estado"].ToString();

                            if (estadoUsuario == "ACTIVO")
                            {
                                string nombreUsuario = reader["Nombre"].ToString();
                                string correoUsuario = reader["Correo"].ToString();
                                string passUsuario = reader["Pass"].ToString(); // ojo: validá bien el índice/columna real

                                var mailservice = new DCorreoSoporte();
                                mailservice.enviarCorreo(
                                    subject: "ofi Sistema de seguimiento de lotes: Notificación de seguridad",
                                    body:
                                        $"Hola, estimado/a {nombreUsuario}\n\n" +
                                        "Los datos de su cuenta en ofi Sistema de seguimiento de lotes han cambiado recientemente.\n" +
                                        "\nLe informamos que se ha hecho un cambio en su cuenta, si usted realizó dicho cambio ignore este correo," +
                                        "\nPero si usted no ha realizado ningún cambio en su cuenta," +
                                        "\nle pedimos que cambie su contraseña inmediatamente una vez ingrese al sistema..." +
                                        "\n\nSi no está seguro de si usted o su administrador ha realizado este cambio," +
                                        " debe ponerse en contacto con su administrador inmediatamente",
                                    destinatarioCorreo: new List<string> { correoUsuario }
                                );

                                return $"Hola, {nombreUsuario}\n" +
                                       "Usted solicitó recuperar su contraseña.\n" +
                                       $"Por favor revise su correo: {correoUsuario}\n" +
                                       "Sin embargo, le pedimos que cambie su contraseña inmediatamente una vez ingrese al sistema...";
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
                }
            }
            catch (Exception ex)
            {
                Log.Writeerror("Error en NotificacionCambio ✖️✖️ " + ex.Message);
                return "ERROR, Algo anda mal: " + ex.Message;
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
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("CambiarContraseñaYEnviarCorreo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Dato", usuarioSolicitado);
                    cmd.Parameters.AddWithValue("@Password", Encrip.Encriptar(Encrip.Encriptar(nuevaContraseña)));

                    var nuevoPasswordParam = new SqlParameter("@NuevoPassword", SqlDbType.VarChar, 255)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(nuevoPasswordParam);

                    var correoParam = new SqlParameter("@Correo", SqlDbType.VarChar, 100)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(correoParam);

                    var nombreUsuarioParam = new SqlParameter("@Login", SqlDbType.VarChar, 100)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(nombreUsuarioParam);

                    cmd.ExecuteNonQuery();

                    string nombreUsuario = nombreUsuarioParam.Value?.ToString() ?? "Usuario";
                    string correoUsuario = correoParam.Value?.ToString() ?? "";
                    //string nuevoPassword = nuevoPasswordParam.Value?.ToString() ?? ""; // ⚠️ no enviar nunca por correo

                    if (string.IsNullOrEmpty(correoUsuario))
                        return "No se encontró un correo válido para el usuario solicitado.";

                    var mailservice = new DCorreoSoporte();
                    mailservice.enviarCorreo(
                        subject: "ofi Sistema de seguimiento de lotes: Recuperación de contraseña",
                        body:
                            $"Hola {nombreUsuario},\n\n" +
                            "Usted solicitó recuperar su contraseña.\n" +
                            "Se le ha generado una nueva contraseña temporal:\n\n" +
                            $"🔑 {nuevaContraseña}\n\n" +
                            "Por su seguridad, le pedimos que cambie esta contraseña inmediatamente después de ingresar al sistema.\n\n" +
                            "Si usted no solicitó este restablecimiento, contacte a su administrador de inmediato.",
                        destinatarioCorreo: new List<string> { correoUsuario }
                    );

                    return $"Hola {nombreUsuario}, revise su correo: {correoUsuario}\n" +
                           "Recuerde cambiar la contraseña inmediatamente después de ingresar al sistema.";
                }
            }
            catch (Exception ex)
            {
                Log.Writeerror("Error en RecoverPassword2 ✖️✖️ " + ex.Message);
                return "ERROR, Algo anda mal: " + ex.Message;
            }
        }


        private void NotificacionCambio()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
