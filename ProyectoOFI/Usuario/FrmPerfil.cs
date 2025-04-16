using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoOFI.Usuario
{
    public partial class FrmPerfil : Form
    {
        private bool labelsVerdes = false;
        int id;
        private int conteo;
        string correo = Login.Correo;
        public FrmPerfil()
        {
            InitializeComponent();
        }

        private void FrmPerfil_Load(object sender, EventArgs e)
        {
            FrmPerfil Fp = new FrmPerfil();
            Fp.Text = "Perfil de " + Login.NombreA;
            MostrarDatos();
        }

        private void FrmPerfil_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
            frmInicio frm = new frmInicio();
            frm.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                EditarUsuarios();
            }
            else
            {
                MessageBox.Show("Existen campos vacios o datos incorrectos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MostrarDatos()
        {
            int user = Login.Iduser;
            DUsuarios funcion = new DUsuarios();
            DataTable dt = new DataTable();
            funcion.MostrarUsuarioLogueado(dt, user);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtNombreApellidos.Text = row["NombreApellidos"].ToString();
                txtCorreo.Text = row["Correo"].ToString();
                TxtUser.Text = row["Login"].ToString();
                txtContraseña.Text = Encrip.DesEncriptar(Encrip.DesEncriptar(row["Pass"].ToString()));
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            PlDatos.Enabled = true;
            btnActualizar.Visible = true;
            btnGuardar.Visible = false;
        }
        private bool validar()
        {
            return !(txtNombreApellidos.Text == "" || txtCorreo.Text == "" || TxtUser.Text == "" ||
             txtContraseña.Text == "");

        }
        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            string contra = txtContraseña.Text;
            Validaciones.ActualizarVisibilidadEtiquetas(contra, lblMayu, lblMin, lblNum);

            //// Verificar si la contraseña cumple con los criterios
            bool cumpleCriterios = Validaciones.ContraseñaCumpleCriterios(contra) && contra.Length >= 6;

            // Cambiar el color del Label según si cumple los criterios
            LblPass.ForeColor = cumpleCriterios ? Color.Green : Color.Red;
            // Actualizar los colores de los labels y validar si todos están en verde
            labelsVerdes = Validaciones.ValidarLabelsVerdes(lblNombreApellidos, LblUser, LblPass, lblCorreo);

            // Habilitar o deshabilitar el botón btnGuardar
            //btnGuardar.Enabled = cumpleCriterios && labelsVerdes;
            btnActualizar.Enabled = cumpleCriterios && labelsVerdes;
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;

            if (textBox == TxtUser)
            {
                LblUser.ForeColor = string.IsNullOrEmpty(TxtUser.Text) ? Color.Red : Color.Green;

                // Actualizar los colores de los labels y validar si todos están en verde
                labelsVerdes = Validaciones.ValidarLabelsVerdes(lblNombreApellidos, LblUser, LblPass, lblCorreo);

                // Habilitar o deshabilitar el botón guardar según el estado de los labels
                //btnGuardar.Enabled = labelsVerdes;
                btnActualizar.Enabled = labelsVerdes;
            }

            if (textBox == txtNombreApellidos)
            {
                lblNombreApellidos.ForeColor = string.IsNullOrEmpty(txtNombreApellidos.Text) ? Color.Red : Color.Green;

                // Actualizar los colores de los labels y validar si todos están en verde
                labelsVerdes = Validaciones.ValidarLabelsVerdes(lblNombreApellidos, LblUser, LblPass, lblCorreo);

                // Habilitar o deshabilitar el botón guardar según el estado de los labels
                //btnGuardar.Enabled = labelsVerdes;
                btnActualizar.Enabled = labelsVerdes;
            }

            if (textBox == txtContraseña)
            {
                if (int.TryParse(txtContraseña.Text, out int celular) && celular.ToString().Length >= 8)
                {
                    LblPass.ForeColor = Color.Green;
                }
                else
                {
                    LblPass.ForeColor = Color.Red;
                }
                // Actualizar los colores de los labels y validar si todos están en verde
                labelsVerdes = Validaciones.ValidarLabelsVerdes(lblNombreApellidos, LblUser, LblPass, lblCorreo);

                // Habilitar o deshabilitar el botón guardar según el estado de los labels
                // btnGuardar.Enabled = labelsVerdes;
                btnActualizar.Enabled = labelsVerdes;
            }

            if (textBox == txtCorreo)
            {
                lblCorreo.ForeColor = Validaciones.EsCorreoValido(txtCorreo.Text) ? Color.Green : Color.Red;
                // Actualizar los colores de los labels y validar si todos están en verde
                labelsVerdes = Validaciones.ValidarLabelsVerdes(lblNombreApellidos, LblUser, LblPass, lblCorreo);

                // Habilitar o deshabilitar el botón guardar según el estado de los labels
                //btnGuardar.Enabled = labelsVerdes;
                btnActualizar.Enabled = labelsVerdes;
            }
        }
        private void EditarUsuarios()
        {
            LUsuarios parametros = new LUsuarios();
            DUsuarios funcion = new DUsuarios();
            parametros.IdUser = Login.Iduser;
            parametros.NombreA = txtNombreApellidos.Text;
            parametros.Login = TxtUser.Text;
            parametros.Pass = Encrip.Encriptar(Encrip.Encriptar(txtContraseña.Text));
            parametros.Correo = txtCorreo.Text;
            if (funcion.EditarUser(parametros) == true)
            {
                MessageBox.Show("Se editó correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnGuardar.Visible = true;
                btnActualizar.Visible = false;
                PlDatos.Enabled = false;
            }
        }
    }
}
