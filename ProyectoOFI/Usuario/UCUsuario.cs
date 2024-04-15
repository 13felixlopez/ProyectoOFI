using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using ProyectoOFI.Otros;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace ProyectoOFI.Usuario
{
    public partial class UCUsuario : UserControl
    {
        int IdUser;
        string Estado;
        string login;
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
            parametros.Pass = Encrip.Encriptar(Encrip.Encriptar(txtContraseña.Text));
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

        private void DtUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DtUser.Columns["Editar"].Index)
            {
                ObtenerEstado();
                ObtenerDatos();
            }
            if (e.ColumnIndex == DtUser.Columns["Eliminar"].Index)
            {
                string admin = DtUser.SelectedCells[6].Value.ToString();
                DialogResult resultado = MessageBox.Show("¿Realmente desea eliminar este Registro?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.OK)
                {
                    if (admin != "Admin")
                    {
                        capturarIdUsuario();
                        EliminarUser();
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar el usuario Admin","ERROR",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
        }

        private void capturarIdUsuario()
        {
            IdUser = Convert.ToInt32(DtUser.SelectedCells[2].Value);
            login = DtUser.SelectedCells[6].Value.ToString();
        }

        private void ObtenerDatos()
        {
            capturarIdUsuario();
            txtNombreApellidos.Text = DtUser.SelectedCells[3].Value.ToString();
            TxtUser.Text = DtUser.SelectedCells[6].Value.ToString();
            txtCorreo.Text = DtUser.SelectedCells[4].Value.ToString();
            TxtCedula.Text = DtUser.SelectedCells[5].Value.ToString();
            if (TxtUser.Text == "Admin")
            {
                TxtUser.Enabled = false;
                DtPermisos.Enabled = false;
            }
            else
            {
                TxtUser.Enabled = true;
                DtPermisos.Enabled = true;
            }
            txtContraseña.Text = Encrip.DesEncriptar(Encrip.DesEncriptar(DtUser.SelectedCells[7].Value.ToString()));

            PlRegistro.Visible = true;
            PlRegistro.Dock = DockStyle.Fill;
            btnActualizar.Visible = true;
            btnGuardar.Visible = false;
            MostrarModulos();
            MostrarPermisos();
        }

        private void MostrarPermisos()
        {
            DataTable dt = new DataTable();
            DPermisos funcion = new DPermisos();
            LPermisos parametros = new LPermisos();
            parametros.IdUser = IdUser;
            funcion.MostrarPermisos(ref dt, parametros);
            foreach (DataRow rowPermisos in dt.Rows)
            {
                int idmoduloPermisos = Convert.ToInt32(rowPermisos["IdModulo"]);
                foreach (DataGridViewRow rowModulos in DtPermisos.Rows)
                {
                    int Idmodulo = Convert.ToInt32(rowModulos.Cells["IdModulo"].Value);
                    if (idmoduloPermisos == Idmodulo)
                    {
                        rowModulos.Cells[0].Value = true;
                    }
                }
            }
        }

        private void EliminarUser()
        {
            string nombrecolumna = "IdUser";
            int indice = DtUser.Columns[nombrecolumna].Index;
            IdUser = int.Parse(DtUser.SelectedCells[indice].Value.ToString());
            DUsuarios funcion = new DUsuarios();
            if (funcion.EliminarUser(IdUser) == true)
            {
                MostrarUsuarios();
            }
        }

        private void ObtenerEstado()
        {
            Estado = DtUser.SelectedCells[8].Value.ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombreApellidos.Text))
            {
                if (!string.IsNullOrEmpty(TxtUser.Text))
                {
                    if (!string.IsNullOrEmpty(txtContraseña.Text))
                    {
                        if (!string.IsNullOrEmpty(txtCorreo.Text))
                        {
                            if (!string.IsNullOrEmpty(TxtCedula.Text))
                            {
                                EditarUsuarios();
                            }
                            else
                            {
                                MessageBox.Show("Ingrese una Cedula");

                            }
                        }
                        else
                        {
                            MessageBox.Show("Ingrese un Correo");

                        }

                    }
                    else
                    {
                        MessageBox.Show("Ingrese la contraseña");


                    }
                }
                else
                {
                    MessageBox.Show("Ingrese el Usuario");


                }
            }
            else
            {

                MessageBox.Show("Ingrese el Nombre");
            }
        }

        private void EditarUsuarios()
        {
            LUsuarios parametros = new LUsuarios();
            DUsuarios funcion = new DUsuarios();
            parametros.IdUser = IdUser;
            parametros.NombreA = txtNombreApellidos.Text;
            parametros.Login = TxtUser.Text;
            parametros.Pass = Encrip.Encriptar(Encrip.Encriptar(txtContraseña.Text));
            parametros.Correo = txtCorreo.Text;
            parametros.Cedula = TxtCedula.Text;
            if (funcion.EditarUser(parametros) == true)
            {
                EliminarPermisos();
                InsertarPermisos();
            }
        }

        private void EliminarPermisos()
        {
            LPermisos parametros = new LPermisos();
            DPermisos funcion = new DPermisos();
            parametros.IdUser = IdUser;
            funcion.EliminarPermisos(parametros);
        }
    }
}
