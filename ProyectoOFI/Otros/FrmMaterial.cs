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
    public partial class FrmMaterial : Form
    {
        int IdMaterial;
        public FrmMaterial()
        {
            InitializeComponent();
            MostrarMaterial();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            InsertarMaterial();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EditarMaterial();
        }

        private void DtMaterial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Nombre;
            Nombre = DtMaterial.SelectedCells[2].Value.ToString();
            TxtMaterial.Text = Nombre;
            IdMaterial = Convert.ToInt32(DtMaterial.SelectedCells[1].Value.ToString());
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
        }

        private void DtMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdMaterial = int.Parse(DtMaterial.SelectedCells[1].Value.ToString());
            if (e.ColumnIndex == DtMaterial.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro de eliminar el Material, Desea Continuar?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarMaterial();
                }
            }
        }
        #region Metodos
        private void MostrarMaterial()
        {
            DCatalogo funcion = new DCatalogo();
            DataTable dt = new DataTable();
            funcion.MostrarMaterial(ref dt);
            DtMaterial.DataSource = dt;
            DtMaterial.Columns[1].Visible = false;
        }
        private void InsertarMaterial()
        {
            if (TxtMaterial.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtMaterial.Focus();
            }
            else
            {
                DCatalogo funcion = new DCatalogo();
                if (funcion.AgregarMaterial(TxtMaterial.Text) == true)
                {
                    MostrarMaterial();
                    TxtMaterial.Clear();
                }
            }
        }
        private void EditarMaterial()
        {
            if (TxtMaterial.Text != "")
            {
                DCatalogo funcion = new DCatalogo();
                if (funcion.EditarMaterial(IdMaterial, TxtMaterial.Text) == true)
                {
                    MostrarMaterial();
                    TxtMaterial.Clear();
                    BtnEditar.Visible = false;
                    BtnGuardar.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtMaterial.Focus();
                }
            }
        }
        private void EliminarMaterial()
        {
            DCatalogo funcion = new DCatalogo();
            if (funcion.EliminarMaterial(IdMaterial) == true)
            {
                MostrarMaterial();
            }
        }
        #endregion
    }
}
