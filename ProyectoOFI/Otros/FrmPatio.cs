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
    public partial class FrmPatio : Form
    {
        string Patio;
        int IdPatio;
        public FrmPatio()
        {
            InitializeComponent();
        }
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            InsertarPatio();
        }
        private void InsertarPatio()
        {
            if (TxtPatio.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtPatio.Focus();
            }
            else
            {
                DCatalogo funcion = new DCatalogo();
                if (funcion.AgregarPatio(TxtPatio.Text) == true)
                {
                    MostrarPatio();
                    TxtPatio.Clear();
                }
            }
        }
        private void MostrarPatio()
        {
            DCatalogo funcion = new DCatalogo();
            DataTable dt = new DataTable();
            funcion.MostrarPatio(ref dt);
            DtPatio.DataSource = dt;
            DtPatio.Columns[1].Visible = false;
        }
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EditarPatio();
        }
        private void EditarPatio()
        {
            if (TxtPatio.Text != "")
            {
                DCatalogo funcion = new DCatalogo();
                if (funcion.EditarPatio(IdPatio, TxtPatio.Text) == true)
                {
                    MostrarPatio();
                    TxtPatio.Clear();
                    BtnEditar.Visible = false;
                    BtnGuardar.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtPatio.Focus();
            }
        }
        private void DtPatio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Patio;
            Patio = DtPatio.SelectedCells[2].Value.ToString();
            TxtPatio.Text = Patio;
            IdPatio = Convert.ToInt32(DtPatio.SelectedCells[1].Value.ToString());
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
        }
        private void DtPatio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdPatio = int.Parse(DtPatio.SelectedCells[1].Value.ToString());
            if (e.ColumnIndex == DtPatio.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro de eliminar el Recibidor, Desea Continuar?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarPatio();
                }
            }
        }
        private void EliminarPatio()
        {
            DCatalogo funcion = new DCatalogo();
            if (funcion.EliminarPatio(IdPatio) == true)
            {
                MostrarPatio();
            }
        }
    }
}
