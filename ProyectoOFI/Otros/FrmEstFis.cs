using ProyectoOFI.Datos;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoOFI.Otros
{
    public partial class FrmEstFis : Form
    {
        DCatalogo funcion = new DCatalogo();
        int IdEstFis;
        public FrmEstFis()
        {
            InitializeComponent();
            MostrarEstFis();
        }
        private void MostrarEstFis()
        {
            DataTable dt = new DataTable();
            funcion.MostrarEstFis(ref dt);
            DtEstFis.DataSource = dt;
            DtEstFis.Columns[1].Visible = false;
        }
        private void InsertarEstFis()
        {
            if (TxtEstFis.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtEstFis.Focus();
            }
            else
            {
                if (funcion.AgregarEstFist(TxtEstFis.Text) == true)
                {
                    MostrarEstFis();
                    TxtEstFis.Clear();
                }
            }
        }
        private void EditarEstFis()
        {
            if (TxtEstFis.Text != "")
            {
                if (funcion.EditarEstFis(IdEstFis, TxtEstFis.Text) == true)
                {
                    MostrarEstFis();
                    TxtEstFis.Clear();
                    BtnEditar.Visible = false;
                    BtnGuardar.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se permiten campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtEstFis.Focus();
                }
            }
        }
        private void EliminarEstFis()
        {
            if (funcion.EliminarEstFis(IdEstFis))
            {
                MostrarEstFis();
            }
        }
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DtEstFis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Nombre;
            Nombre = DtEstFis.SelectedCells[2].Value.ToString();
            TxtEstFis.Text = Nombre;
            IdEstFis = Convert.ToInt32(DtEstFis.SelectedCells[1].Value.ToString());
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
        }
        private void DtEstFis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdEstFis = int.Parse(DtEstFis.SelectedCells[1].Value.ToString());
            if (e.ColumnIndex == DtEstFis.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro de eliminar el Recibidor, Desea Continuar?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarEstFis();
                }
            }
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            InsertarEstFis();
        }
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EditarEstFis();
        }
    }
}
