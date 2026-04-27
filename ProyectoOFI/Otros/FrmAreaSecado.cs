using ProyectoOFI.Datos;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoOFI.Otros
{
    public partial class FrmAreaSecado : Form
    {
        DCatalogo funcion = new DCatalogo();
        int IdAreaSecado;
        public FrmAreaSecado()
        {
            InitializeComponent();
            MostrarAreaSecado();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            InsertarAreaSecado();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EditarAreaSecado();
        }

        private void DtAreaSecado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerDatos();
        }

        private void DtAreaSecado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdAreaSecado = int.Parse(DtAreaSecado.SelectedCells[1].Value.ToString());
            if (e.ColumnIndex == DtAreaSecado.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro de eliminar el Recibidor, Desea Continuar?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarAreaSecado();
                }
            }
        }
        #region Metodos
        private void MostrarAreaSecado()
        {
            DataTable dt = new DataTable();
            funcion.MostrarAreaSecado(ref dt);
            DtAreaSecado.DataSource = dt;
            DtAreaSecado.Columns[1].Visible = false;
        }
        private void InsertarAreaSecado()
        {
            if (TxtAreaSecado.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtAreaSecado.Focus();
            }
            else
            {
                if (funcion.AgregarAreaSecado(TxtAreaSecado.Text) == true)
                {
                    MostrarAreaSecado();
                    TxtAreaSecado.Clear();
                }
            }
        }
        private void EditarAreaSecado()
        {
            if (TxtAreaSecado.Text != "")
            {
                if (funcion.EditarAreaSecado(IdAreaSecado, TxtAreaSecado.Text) == true)
                {
                    MostrarAreaSecado();
                    TxtAreaSecado.Clear();
                    BtnEditar.Visible = false;
                    BtnGuardar.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se permiten campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtAreaSecado.Focus();
                }
            }
        }
        private void EliminarAreaSecado()
        {
            if (funcion.EliminarAreaSecado(IdAreaSecado))
            {
                MostrarAreaSecado();
            }
        }
        private void ObtenerDatos()
        {
            string Nombre;
            Nombre = DtAreaSecado.SelectedCells[2].Value.ToString();
            TxtAreaSecado.Text = Nombre;
            IdAreaSecado = Convert.ToInt32(DtAreaSecado.SelectedCells[1].Value.ToString());
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
        }
        #endregion
    }
}
