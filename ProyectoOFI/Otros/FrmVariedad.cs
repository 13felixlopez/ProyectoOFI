using ProyectoOFI.Datos;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoOFI.Otros
{
    public partial class FrmVariedad : Form
    {
        string Variedad;
        int IdVariedad;
        public FrmVariedad()
        {
            InitializeComponent();
            MostrarVariedades();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            InsertarVariedad();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EditarVariedad();
        }

        private void DtVariedad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdVariedad = int.Parse(DtVariedad.SelectedCells[1].Value.ToString());
            if (e.ColumnIndex == DtVariedad.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro de eliminar la Variedad, Desea Continuar?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarVariedad();
                }
            }
        }

        private void DtVariedad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Variedad;
            Variedad = DtVariedad.SelectedCells[2].Value.ToString();
            TxtVariedad.Text = Variedad;
            IdVariedad = Convert.ToInt32(DtVariedad.SelectedCells[1].Value.ToString());
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
        }
        private void InsertarVariedad()
        {
            if (TxtVariedad.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtVariedad.Focus();
            }
            else
            {
                DCatalogo funcion = new DCatalogo();
                if (funcion.AgregarVariedad(TxtVariedad.Text) == true)
                {
                    MostrarVariedades();
                    TxtVariedad.Clear();
                }
            }
        }
        private void MostrarVariedades()
        {
            DCatalogo funcion = new DCatalogo();
            DataTable dt = new DataTable();
            funcion.MostrarVariedad(ref dt);
            DtVariedad.DataSource = dt;
            DtVariedad.Columns[1].Visible = false;
        }
        private void EliminarVariedad()
        {
            DCatalogo funcion = new DCatalogo();
            if (funcion.EliminarVariedad(IdVariedad) == true)
            {
                MostrarVariedades();
            }
        }
        private void EditarVariedad()
        {
            if (TxtVariedad.Text != "")
            {
                DCatalogo funcion = new DCatalogo();
                if (funcion.EditarVariedad(IdVariedad, TxtVariedad.Text) == true)
                {
                    MostrarVariedades();
                    TxtVariedad.Clear();
                    BtnEditar.Visible = false;
                    BtnGuardar.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtVariedad.Focus();
            }
        }
    }
}
