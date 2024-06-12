using ProyectoOFI.Datos;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoOFI.Otros
{
    public partial class FrmEmpaque : Form
    {
        int IdEmpaque;
        double tara;
        public FrmEmpaque()
        {
            InitializeComponent();
            MostrarEmpaque();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            InsertarEmpaque();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EditarEmpaque();
        }

        private void DtEmpaque_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Nombre, capacidad, Tara;
            Tara = DtEmpaque.SelectedCells[4].Value.ToString();
            capacidad = DtEmpaque.SelectedCells[3].Value.ToString();
            Nombre = DtEmpaque.SelectedCells[2].Value.ToString();
            TxtEmpaque.Text = Nombre;
            TxtCapacidad.Text = capacidad;
            TxtTara.Text = Tara;
            IdEmpaque = Convert.ToInt32(DtEmpaque.SelectedCells[1].Value.ToString());
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
        }

        private void DtEmpaque_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdEmpaque = int.Parse(DtEmpaque.SelectedCells[1].Value.ToString());
            if (e.ColumnIndex == DtEmpaque.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro de eliminar el Empaque, Desea Continuar?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarEmpaque();
                }
            }
        }
        #region Metodos
        private void MostrarEmpaque()
        {
            DCatalogo funcion = new DCatalogo();
            DataTable dt = new DataTable();
            funcion.MostrarEmpaque(ref dt);
            DtEmpaque.DataSource = dt;
            DtEmpaque.Columns[1].Visible = false;
        }
        private void InsertarEmpaque()
        {
            if (TxtEmpaque.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtEmpaque.Focus();
            }
            else
            {
                DCatalogo funcion = new DCatalogo();
                tara=double.Parse(TxtTara.Text);
                if (funcion.AgregarEmpaque(TxtEmpaque.Text,TxtCapacidad.Text,tara) == true)
                {
                    MostrarEmpaque();
                    Limpiar();
                }
            }
        }
        private void EditarEmpaque()
        {
            if (TxtEmpaque.Text != "")
            {
                DCatalogo funcion = new DCatalogo();
                tara = double.Parse(TxtTara.Text);
                if (funcion.EditarEmpaque(IdEmpaque, TxtEmpaque.Text,TxtCapacidad.Text,tara) == true)
                {
                    MostrarEmpaque();
                    Limpiar();
                    BtnEditar.Visible = false;
                    BtnGuardar.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtEmpaque.Focus();
                }
            }
        }
        private void EliminarEmpaque()
        {
            DCatalogo funcion = new DCatalogo();
            if (funcion.EliminarEmpaque(IdEmpaque) == true)
            {
                MostrarEmpaque();
            }
        }
        #endregion
        private void Limpiar()
        {
            TxtTara.Clear();
            TxtEmpaque.Clear();
            TxtCapacidad.Clear();
        }
    }
}
