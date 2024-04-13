using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using System;
using System.Data;
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
        public Login()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnInicio_Click(object sender, EventArgs e)
        {
            Logueo();
        }
        
        frmInicio fr = new frmInicio();
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
                //parametros.Pass = Encrip.Encriptar(Encrip.Encriptar(TxtPass.Text));
                parametros.Pass = TxtPass.Text;

                try
                {
                    dt = nuser.Nusers(parametros);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Iduser = Convert.ToInt32(dt.Rows[0][0]);
                        NombreA = dt.Rows[0][1].ToString();
                        login = dt.Rows[0][6].ToString();

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
                finally
                {
                    Conexion.cerrar();
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
        private void VerificarConexion()
        {
            DUsuarios funcion = new DUsuarios();
            funcion.VerificarUsuario(ref Indicador);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Validar_Conexion();
        }
    }
}
