using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using ProyectoOFI.Usuario;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace ProyectoOFI
{
    public partial class Login : Form
    {

        int Contador;
        string Indicador;
        readonly NUser nuser = new NUser();
        readonly LUsuarios luser = new LUsuarios();
        LUsuarios parametros = new LUsuarios();
        public static string NombreA;
        public static int Iduser;
        public static string login;
        public static string Correo;
        public static string IP;
        public static string Pass;

        private int clickCount = 0;
        private DateTime lastClickTime = DateTime.MinValue;
        private const int DoubleClickThreshold = 500;
        string DB;
        public Login()
        {
            InitializeComponent();
            CrearArchivo();
            NombreDB();
        }
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnInicio_Click(object sender, EventArgs e)
        {
            Logueo();
        }
        //frmInicio fr = new frmInicio();
        FrmMenu fr = new FrmMenu();
        private void Logueo()
        {
            if (string.IsNullOrEmpty(TxtUser.Text) || string.IsNullOrEmpty(TxtPass.Text))
            {
                MessageBox.Show("Los campos estan vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtUser.Focus();
            }
            else
            {
                DataTable dt = new DataTable();
                parametros.Login = TxtUser.Text;
                parametros.Pass = Encrip.Encriptar(Encrip.Encriptar(TxtPass.Text));

                try
                {
                    dt = nuser.Nusers(parametros);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Iduser = Convert.ToInt32(dt.Rows[0][0]);
                        NombreA = dt.Rows[0][1].ToString();
                        login = dt.Rows[0][5].ToString();

                        Pass = dt.Rows[0][2].ToString();
                        Correo = dt.Rows[0][4].ToString();
                        //Tusuario = dt.Rows[0][6].ToString();
                        Dispose();
                        fr.ShowDialog();
                        TxtPass.Clear();
                        TxtUser.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o Contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Validar_Conexion()
        {
            VerificarConexion();
            if (Indicador == "Incorrecto")
            {
                Dispose();
                FrmConexionIP cc = new FrmConexionIP();
                cc.ShowDialog();
            }
            else
            {
                login = null;
            }
        }
        private void NombreDB()
        {
            try
            {
                // Obtener la cadena de conexión desencriptada
                string connectionString = Desencryptacion.checkServer().ToString();

                // Mostrar la cadena completa (opcional, para debug)
                //txtCadenaCompleta.Text = connectionString;

                // Parsear la cadena de conexión
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);

                // Mostrar datos en los controles del formulario
                DB = builder.InitialCatalog;
                LblDB.Text = DB;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la configuración: " + ex.Message,
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void VerificarConexion()
        {
            DUsuarios funcion = new DUsuarios();
            funcion.VerificarUsuario(ref Indicador, DB);
        }
        private void Login_Load(object sender, EventArgs e)
        {
            Validar_Conexion();
            TxtUser.Focus();
            // Suscribir el evento MouseDown al label
            label5.MouseDown += new MouseEventHandler(label4_MouseDown);
        }
        private void CrearArchivo()
        {
            // Ruta donde se creará la carpeta y el archivo
            string rutaCarpeta = @"C:\Log";
            string rutaArchivo = Path.Combine(rutaCarpeta, "logerror.txt");

            try
            {
                // Verificar si la carpeta ya existe
                if (!Directory.Exists(rutaCarpeta))
                {
                    // Crear la carpeta si no existe
                    Directory.CreateDirectory(rutaCarpeta);

                    // Crear el archivo dentro de la carpeta
                    File.Create(rutaArchivo);
                    Console.WriteLine("Se creó la carpeta y el archivo correctamente.");
                }
                else
                {
                    Console.WriteLine("La carpeta y el archivo ya existen.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear la carpeta y el archivo: " + ex.Message);
            }
        }

        private void CambiarServidor_Click(object sender, EventArgs e)
        {
            Dispose();
            FrmConexionIP IP = new FrmConexionIP();
            IP.ShowDialog();
        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) // Verifica si es un clic derecho
            {
                // Calcula el tiempo transcurrido desde el último clic
                TimeSpan timeSinceLastClick = DateTime.Now - lastClickTime;

                if (timeSinceLastClick.TotalMilliseconds <= DoubleClickThreshold)
                {
                    clickCount++;

                    if (clickCount == 10) // Si es el segundo clic derecho
                    {
                        //Task.Delay(10000);
                        CambiarServidor.Visible = true;
                        LblDB.Visible = true;
                        // Reinicia el contador
                        clickCount = 0;
                    }
                }
                else
                {
                    // Reinicia el contador si el tiempo entre clics es mayor que el umbral
                    clickCount = 1;
                }

                lastClickTime = DateTime.Now; // Actualiza el tiempo del último clic
            }
        }

        private void Lblrestablecer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Restablecer res = new Restablecer();
            res.Show();
            this.Hide();
        }
    }
}
