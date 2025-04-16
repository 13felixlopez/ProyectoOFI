using ProyectoOFI.Datos;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoOFI.Otros
{
    public partial class Recibidor : Form
    {
        int Idrecibidor;
        public Recibidor()
        {
            InitializeComponent();
            MostrarRecibidor();
        }
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            InsertarRecibidor();
        }
        private void MostrarRecibidor()
        {
            DCatalogo funcion = new DCatalogo();
            DataTable dt = new DataTable();
            funcion.MostrarRecibidor(ref dt);
            DtRecibidor.DataSource = dt;
            DtRecibidor.Columns[1].Visible = false;
        }
        private void InsertarRecibidor()
        {
            if (TxtRecibidor.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtRecibidor.Focus();
            }
            else
            {
                DCatalogo funcion = new DCatalogo();
                if (funcion.AgregarRecibidor(TxtRecibidor.Text) == true)
                {
                    MostrarRecibidor();
                    TxtRecibidor.Clear();
                }
            }
        }
        private void EditarRecibidor()
        {
            if (TxtRecibidor.Text != "")
            {
                DCatalogo funcion = new DCatalogo();
                if (funcion.EditarRecibidor(Idrecibidor, TxtRecibidor.Text) == true)
                {
                    MostrarRecibidor();
                    TxtRecibidor.Clear();
                    BtnEditar.Visible = false;
                    BtnGuardar.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtRecibidor.Focus();
                }
            }
        }
        private void EliminarRecibidor()
        {
            DCatalogo funcion = new DCatalogo();
            if (funcion.EliminarRecibidor(Idrecibidor) == true)
            {
                MostrarRecibidor();
            }
        }
        private void DtRecibidor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Nombre;
            Nombre = DtRecibidor.SelectedCells[2].Value.ToString();
            TxtRecibidor.Text = Nombre;
            Idrecibidor = Convert.ToInt32(DtRecibidor.SelectedCells[1].Value.ToString());
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
        }
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EditarRecibidor();
        }
        private void DtRecibidor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Idrecibidor = int.Parse(DtRecibidor.SelectedCells[1].Value.ToString());
            if (e.ColumnIndex == DtRecibidor.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro de eliminar el Recibidor, Desea Continuar?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarRecibidor();
                }
            }
        }
    }
}
