using ProyectoOFI.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOFI.Otros
{
    public partial class FrmCompra : Form
    {
        int idcompra;
        public FrmCompra()
        {
            InitializeComponent();
            MostrarCompra();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            AgregarCompra();
        }

        private void AgregarCompra()
        {
            if (TxtCompra.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtCompra.Focus();
            }
            else
            {
                DCatalogo funcion = new DCatalogo();
                if (funcion.AgregarCompra(TxtCompra.Text) == true)
                {
                    MostrarCompra();
                    TxtCompra.Clear();
                }
            }
        }

        private void MostrarCompra()
        {
            DCatalogo funcion = new DCatalogo();
            DataTable dt = new DataTable();
            funcion.MostrarCompra(ref dt);
            DtCompra.DataSource = dt;
            DtCompra.Columns[1].Visible = false;
        }
        private void EliminarCompra()
        {
            DCatalogo funcion = new DCatalogo();
            if (funcion.EliminarCompra(idcompra) == true)
            {
                MostrarCompra();
            }
        }

        private void DtCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idcompra = int.Parse(DtCompra.SelectedCells[1].Value.ToString());
            if (e.ColumnIndex == DtCompra.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro de eliminar la Compra, Desea Continuar?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarCompra();
                }
            }
        }

        private void DtCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Compra;
            Compra = DtCompra.SelectedCells[2].Value.ToString();
            TxtCompra.Text = Compra;
            idcompra = Convert.ToInt32(DtCompra.SelectedCells[1].Value.ToString());
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EditarCompra();
        }

        private void EditarCompra()
        {
            if (TxtCompra.Text != "")
            {
                DCatalogo funcion = new DCatalogo();
                if (funcion.EditarCompra(idcompra, TxtCompra.Text) == true)
                {
                    MostrarCompra();
                    TxtCompra.Clear();
                    BtnEditar.Visible = false;
                    BtnGuardar.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtCompra.Focus();
            }
        }
    }
}
