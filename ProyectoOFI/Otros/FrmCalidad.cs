using ProyectoOFI.Datos;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoOFI.Otros
{
    public partial class FrmCalidad : Form
    {
        DCatalogo funcion=new DCatalogo();
        int IdCalidad;
        public FrmCalidad()
        {
            InitializeComponent();
            MostrarCalidad();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DtCalidad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Nombre;
            Nombre = DtCalidad.SelectedCells[2].Value.ToString();
            TxtCalidad.Text = Nombre;
            IdCalidad = Convert.ToInt32(DtCalidad.SelectedCells[1].Value.ToString());
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
        }

        private void DtCalidad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdCalidad = int.Parse(DtCalidad.SelectedCells[1].Value.ToString());
            if (e.ColumnIndex == DtCalidad.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro de eliminar el Recibidor, Desea Continuar?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarCalidad();
                }
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            InsertarCalidad();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EditarCalidad();
        }
        #region Metodos
        private void MostrarCalidad()
        {
            DataTable dt = new DataTable();
            funcion.MostrarCalidad(ref dt);
            DtCalidad.DataSource = dt;
            DtCalidad.Columns[1].Visible = false;
        }
        private void InsertarCalidad()
        {
            if (TxtCalidad.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtCalidad.Focus();
            }
            else
            {
                if (funcion.AgregarCalidad(TxtCalidad.Text) == true)
                {
                    MostrarCalidad();
                    TxtCalidad.Clear();
                }
            }
        }
        private void EditarCalidad()
        {
            if (TxtCalidad.Text != "")
            {
                if (funcion.EditarCalidad(IdCalidad, TxtCalidad.Text) == true)
                {
                    MostrarCalidad();
                    TxtCalidad.Clear();
                    BtnEditar.Visible = false;
                    BtnGuardar.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se permiten campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtCalidad.Focus();
                }
            }
        }
        private void EliminarCalidad()
        {
            if (funcion.EliminarCalidad(IdCalidad))
            {
                MostrarCalidad();
            }
        }
        #endregion
    }
}
