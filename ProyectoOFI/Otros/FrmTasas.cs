using ProyectoOFI.Datos;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoOFI.Otros
{
    public partial class FrmTasas : Form
    {
        string tasa;
        int IdTasa;
        public FrmTasas()
        {
            InitializeComponent();
            MostrarTasas();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            InsertarTasa();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EditarTasa();
        }

        private void DtTasa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Tasa;
            Tasa = DtTasa.SelectedCells[2].Value.ToString();
            TxtTasa.Text = Tasa;
            IdTasa = Convert.ToInt32(DtTasa.SelectedCells[1].Value.ToString());
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
        }

        private void DtTasa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DtTasa.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro de eliminar la Tasa, Desea Continuar?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarTasa();
                }
            }
        }
        private void InsertarTasa()
        {
            if (TxtTasa.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtTasa.Focus();
            }
            else
            {
                DCatalogo funcion = new DCatalogo();
                if (funcion.AgregarTasa(TxtTasa.Text) == true)
                {
                    MostrarTasas();
                    TxtTasa.Clear();
                }
            }
        }
        private void MostrarTasas()
        {
            DCatalogo funcion = new DCatalogo();
            DataTable dt = new DataTable();
            funcion.MostrarTasas(ref dt);
            DtTasa.DataSource = dt;
            DtTasa.Columns[1].Visible = false;
        }
        private void EliminarTasa()
        {
            string nombrecolumna = "IdTasa";
            int indice = DtTasa.Columns[nombrecolumna].Index;
            IdTasa = int.Parse(DtTasa.SelectedCells[indice].Value.ToString());
            DCatalogo funcion = new DCatalogo();
            if (funcion.EliminarTasa(IdTasa) == true)
            {
                MostrarTasas();
            }
        }
        private void EditarTasa()
        {
            if (TxtTasa.Text != "")
            {
                DCatalogo funcion = new DCatalogo();
                if (funcion.EditarTasa(IdTasa, TxtTasa.Text) == true)
                {
                    MostrarTasas();
                    TxtTasa.Clear();
                    BtnEditar.Visible = false;
                    BtnGuardar.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtTasa.Focus();
            }
        }
    }
}
