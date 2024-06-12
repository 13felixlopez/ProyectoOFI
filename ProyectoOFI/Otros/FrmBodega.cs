using ProyectoOFI.Datos;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoOFI.Otros
{
    public partial class FrmBodega : Form
    {
        int IdBodega;
        public FrmBodega()
        {
            InitializeComponent();
            MostrarBodega();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            InsertarBodega();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EditarBodega();
        }

        private void DtBodega_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Nombre;
            Nombre = DtBodega.SelectedCells[2].Value.ToString();
            TxtBodega.Text = Nombre;
            IdBodega = Convert.ToInt32(DtBodega.SelectedCells[1].Value.ToString());
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
        }

        private void DtBodega_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdBodega = int.Parse(DtBodega.SelectedCells[1].Value.ToString());
            if (e.ColumnIndex == DtBodega.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro de eliminar el Bodega, Desea Continuar?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarBodega();
                }
            }
        }
        #region Metodos
        private void MostrarBodega()
        {
            DCatalogo funcion = new DCatalogo();
            DataTable dt = new DataTable();
            funcion.MostrarBodega(ref dt);
            DtBodega.DataSource = dt;
            DtBodega.Columns[1].Visible = false;
        }
        private void InsertarBodega()
        {
            if (TxtBodega.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtBodega.Focus();
            }
            else
            {
                DCatalogo funcion = new DCatalogo();
                if (funcion.AgregarBodega(TxtBodega.Text) == true)
                {
                    MostrarBodega();
                    TxtBodega.Clear();
                }
            }
        }
        private void EditarBodega()
        {
            if (TxtBodega.Text != "")
            {
                DCatalogo funcion = new DCatalogo();
                if (funcion.EditarBodega(IdBodega, TxtBodega.Text) == true)
                {
                    MostrarBodega();
                    TxtBodega.Clear();
                    BtnEditar.Visible = false;
                    BtnGuardar.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtBodega.Focus();
                }
            }
        }
        private void EliminarBodega()
        {
            DCatalogo funcion = new DCatalogo();
            if (funcion.EliminarBodega(IdBodega) == true)
            {
                MostrarBodega();
            }
        }
        #endregion
    }
}
