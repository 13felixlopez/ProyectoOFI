using ProyectoOFI.Datos;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoOFI.Recepcion
{
    public partial class FrmAgencia : Form
    {
        string agen;
        int IdAgencia;

        public FrmAgencia()
        {
            InitializeComponent();
            MostrarAgencias();
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            InsertarAgencia();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EditarAgencia();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DtAgencia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Agencia;
            Agencia = DtAgencia.SelectedCells[2].Value.ToString();
            TxtAgencia.Text = Agencia;
            IdAgencia = Convert.ToInt32(DtAgencia.SelectedCells[1].Value.ToString());
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
        }

        private void DtAgencia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DtAgencia.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro de eliminar la Agencia, Desea Continuar?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarAgencia();
                }
            }
        }
        private void InsertarAgencia()
        {
            if (TxtAgencia.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtAgencia.Focus();
            }
            else
            {
                DCatalogo funcion = new DCatalogo();
                if (funcion.AgregarAgencia(TxtAgencia.Text) == true)
                {
                    MostrarAgencias();
                    TxtAgencia.Clear();
                }
            }
        }
        private void MostrarAgencias()
        {
            DCatalogo funcion = new DCatalogo();
            DataTable dt = new DataTable();
            funcion.MostrarAgencias(ref dt);
            DtAgencia.DataSource = dt;
            DtAgencia.Columns[1].Visible = false;
        }
        private void EliminarAgencia()
        {
            string nombrecolumna = "Agencia";
            int indice = DtAgencia.Columns[nombrecolumna].Index;
            agen = DtAgencia.SelectedCells[indice].Value.ToString();
            DCatalogo funcion = new DCatalogo();
            if (funcion.EliminarAgencia(agen) == true)
            {
                MostrarAgencias();
            }
        }
        private void EditarAgencia()
        {
            if (TxtAgencia.Text != "")
            {
                DCatalogo funcion = new DCatalogo();
                if (funcion.EditarAgencia(IdAgencia, TxtAgencia.Text) == true)
                {
                    MostrarAgencias();
                    TxtAgencia.Clear();
                    BtnEditar.Visible = false;
                    BtnGuardar.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtAgencia.Focus();
            }
        }
    }
}
