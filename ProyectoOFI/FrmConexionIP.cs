using ProyectoOFI.Logica;
using System;
using System.Data.SqlClient;
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
            try
            {
                SqlConnection conexionManual = new SqlConnection(cadena_de_conexion);
                conexionManual.Open();
                SqlCommand da = new SqlCommand("Select IdUser from Usuarios", conexionManual);
                id = Convert.ToInt32(da.ExecuteScalar());
                indicador_de_conexion = "HAY CONEXION";
            }
            catch (Exception)
            {
                indicador_de_conexion = "NO HAY CONEXION";
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
    }
}
