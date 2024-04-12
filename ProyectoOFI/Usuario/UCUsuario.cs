using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using ProyectoOFI.Otros;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoOFI.Usuario
{
    public partial class UCUsuario : UserControl
    {
        int IdUser;
        public UCUsuario()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Limpiar();
            HabilitarPaneles();
            MostrarUsuarios();
            MostrarModulos();
        }
        private void MostrarModulos()
        {
            DModulos funcion = new DModulos();
            DataTable dt = new DataTable();
            funcion.MostrarModulos(ref dt);
            DtPermisos.DataSource = dt;
            DtPermisos.Columns["IdModulo"].Visible = false;
        }
        private void Limpiar()
        {
            txtNombreApellidos.Clear();
            txtCorreo.Clear();
            txtContraseña.Clear();
            TxtCedula.Clear();
            Plheader.Visible = false;
        }
        private void HabilitarPaneles()
        {
            PlRegistro.Visible = true;
            PlRegistro.Dock = DockStyle.Fill;
            PlRegistro.BringToFront();
            btnGuardar.Visible = true;
            btnActualizar.Visible = false;
        }

        private void btnVolverPersonal_Click(object sender, EventArgs e)
        {
            PlRegistro.Visible = false;
            Plheader.Visible = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombreApellidos.Text))
            {
                if (!string.IsNullOrEmpty(txtCorreo.Text))
                {
                    if (!string.IsNullOrEmpty(TxtCedula.Text))
                    {
                        if (!string.IsNullOrEmpty(txtContraseña.Text))
                        {
                            InsertarUser();
                        }
                        else
                        {
                            MessageBox.Show("La contraseña ingresada no cumple con los requerimientos necesarios", "ERROR Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese la cudula", "Error Cedula", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese el correo", "Error Correo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese el nombre", "Error Nombre", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InsertarUser()
        {
            LUsuarios parametros = new LUsuarios();
            DUsuarios funcion = new DUsuarios();
            parametros.NombreA = txtNombreApellidos.Text;
            parametros.Pass = txtContraseña.Text;
            parametros.Correo = txtCorreo.Text;
            parametros.Cedula = TxtCedula.Text;
            parametros.Login = TxtUser.Text;
            if (funcion.InsertarUsuario(parametros) == true)
            {
                ObtenerIdUser();
                InsertarPermisos();
            }
        }
        private void ObtenerIdUser()
        {
            DUsuarios funcion = new DUsuarios();
            funcion.ObtenerIdUser(ref IdUser, TxtUser.Text);
        }
        private void InsertarPermisos()
        {
            foreach (DataGridViewRow row in DtPermisos.Rows)
            {
                int IdModulo = Convert.ToInt32(row.Cells["IdModulo"].Value);
                bool marcado = Convert.ToBoolean(row.Cells["Marcar"].Value);
                if (marcado == true)
                {
                    LPermisos parametros = new LPermisos();
                    DPermisos funcion = new DPermisos();
                    parametros.IdModulo = IdModulo;
                    parametros.IdUser = IdUser;
                    funcion.InsertarPermisos(parametros);
                }
            }
            MostrarUsuarios();
            PlRegistro.Visible = false;
        }

        private void MostrarUsuarios()
        {
            DataTable dt = new DataTable();
            DUsuarios funcion = new DUsuarios();
            funcion.MostrarUsuarios(ref dt);
            DtUser.DataSource = dt;
            DiseñarDtvUsuarios();
        }

        private void UCUsuario_Load(object sender, EventArgs e)
        {
            MostrarUsuarios();
        }
        private void DiseñarDtvUsuarios()
        {
            Base.DiseñoDtv(ref DtUser);
            DtUser.Columns["IdUser"].Visible = false;
            DtUser.Columns["Pass"].Visible = false;
        }
    }
}
