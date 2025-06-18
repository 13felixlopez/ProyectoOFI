using ProyectoOFI.Logica;
using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace ProyectoOFI
{
    public partial class FrmConexionIP : Form
    {
        string cadena_de_conexion;
        string indicador_de_conexion;
        int id;
        private AES aes = new AES();
        public FrmConexionIP()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void comprobar_conexion()
        {
            // Obtener el nombre de la base de datos desde el TextBox
            string nombreBaseDatos = TXTbasededatos.Text.Trim();

            // Validar el nombre de la base de datos
            if (string.IsNullOrWhiteSpace(nombreBaseDatos) || !Regex.IsMatch(nombreBaseDatos, @"^[\w]+$"))
            {
                indicador_de_conexion = "Nombre de base de datos inválido";
                return;
            }

            try
            {
                // Crear una nueva conexión usando la cadena de conexión base
                using (SqlConnection conexionManual = new SqlConnection(cadena_de_conexion))
                {
                    conexionManual.Open();

                    // Cambiar a la base de datos especificada
                    conexionManual.ChangeDatabase(nombreBaseDatos);

                    // Consulta segura sin concatenación
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT TOP 1 TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'",
                        conexionManual))
                    {
                        var resultado = cmd.ExecuteScalar();

                        if (resultado != null)
                        {
                            indicador_de_conexion = "HAY CONEXION";
                        }
                        else
                        {
                            indicador_de_conexion = "NO HAY CONEXION";
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Manejar errores específicos de SQL
                switch (sqlEx.Number)
                {
                    case 4060: // No se puede abrir la base de datos
                        indicador_de_conexion = $"Error: Base de datos '{nombreBaseDatos}' no encontrada";
                        break;
                    case 18456: // Error de inicio de sesión
                        indicador_de_conexion = "Error: Credenciales inválidas";
                        break;
                    default:
                        indicador_de_conexion = $"Error SQL ({sqlEx.Number}): {sqlEx.Message}";
                        break;
                }
            }
            catch (Exception ex)
            {
                indicador_de_conexion = $"Error: {ex.Message}";
            }
        }
        public void SaveXML(object dbcnString)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("ConnectionString.xml");
                XmlElement root = doc.DocumentElement;
                root.Attributes[0].Value = Convert.ToString(dbcnString);
                XmlTextWriter write = new XmlTextWriter("ConnectionString.xml", null);
                write.Formatting = Formatting.Indented;
                doc.Save(write);
                write.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("No existe el archivo ConnectionString.xml");
            }
        }
        private void conectar_manualmente()
        {
            cadena_de_conexion = ("Data Source=" + txtIp.Text + ";Initial Catalog=" + TXTbasededatos.Text + ";Integrated Security=False;User Id=" + txtUsuario.Text + ";Password=" + txtPassword.Text + "");
            comprobar_conexion();
            if (indicador_de_conexion == "HAY CONEXION")
            {
                SaveXML(aes.Encrypt(cadena_de_conexion, Desencryptacion.appPwdUnique, int.Parse("256")));
                MessageBox.Show("Conexion Correcta. Vuelve a Abrir el Sistema", "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
            if (indicador_de_conexion == "NO HAY CONEXION")
            {
                MessageBox.Show("Verifique que los datos sean correctos", "Ocurrio un error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIp.Text) && !string.IsNullOrEmpty(txtUsuario.Text) &&
                !string.IsNullOrEmpty(txtPassword.Text) && !string.IsNullOrEmpty(TXTbasededatos.Text))
            {
                conectar_manualmente();
            }
            else
            {
                MessageBox.Show("Completa todos los campos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnProbar_Click(object sender, EventArgs e)
        {
            string cadena = GenerarCadenaConexion();
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Conexión exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private string GenerarCadenaConexion()
        {
            string servidor = txtIp.Text.Trim();
            string bd = TXTbasededatos.Text.Trim();
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtPassword.Text.Trim();
            return $"Data Source={servidor};Initial Catalog={bd};User ID={usuario};Password={contrasena}";
        }

        private void FrmConexionIP_Load(object sender, EventArgs e)
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
                txtIp.Text = builder.DataSource;
                TXTbasededatos.Text = builder.InitialCatalog;

                txtUsuario.Text = builder.UserID;
                txtPassword.Text = builder.Password;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la configuración: " + ex.Message,
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
