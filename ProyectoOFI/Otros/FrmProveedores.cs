using ProyectoOFI.Datos;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoOFI.Otros
{
    public partial class FrmProveedores : Form
    {
        int idproveedor;
        public FrmProveedores()
        {
            InitializeComponent();
            MostrarProveedor();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            AgregarProveedor();
        }

        private void AgregarProveedor()
        {
            if (TxtProveedor.Text == "")
            {
                if (!string.IsNullOrEmpty(TxtIdentificacion.Text))
                {
                    MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtIdentificacion.Focus();
                }
                MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtProveedor.Focus();
            }
            else
            {
                DCatalogo funcion = new DCatalogo();
                if (funcion.AgregarProveedor(TxtIdentificacion.Text, TxtProveedor.Text) == true)
                {
                    MostrarProveedor();
                    TxtProveedor.Clear();
                    TxtIdentificacion.Clear();
                }
            }
        }
        private void MostrarProveedor()
        {
            DCatalogo funcion = new DCatalogo();
            DataTable dt = new DataTable();
            funcion.MostrarProveedores(ref dt);
            DtProveedor.DataSource = dt;
            DtProveedor.Columns[1].Visible = false;
        }
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EditarProveedor();
        }
        private void EditarProveedor()
        {
            if (TxtProveedor.Text != "" && TxtIdentificacion.Text != "")
            {
                DCatalogo funcion = new DCatalogo();
                if (funcion.EditarCliente(idproveedor, TxtIdentificacion.Text, TxtProveedor.Text) == true)
                {
                    MostrarProveedor();
                    TxtProveedor.Clear();
                    TxtIdentificacion.Clear();
                    BtnEditar.Visible = false;
                    BtnGuardar.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtIdentificacion.Focus();
                }
            }
        }

        private void DtProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idproveedor = int.Parse(DtProveedor.SelectedCells[1].Value.ToString());
            if (e.ColumnIndex == DtProveedor.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro de eliminar el Proveedor, Desea Continuar?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarProveedor();
                }
            }
        }
        private void EliminarProveedor()
        {
            DCatalogo funcion = new DCatalogo();
            if (funcion.EliminarProveedor(idproveedor) == true)
            {
                MostrarProveedor();
            }
        }
        private void DtProveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Nombre;
            string Identificacion;
            Identificacion = DtProveedor.SelectedCells[3].Value.ToString();
            Nombre = DtProveedor.SelectedCells[2].Value.ToString();
            TxtProveedor.Text = Nombre;
            TxtIdentificacion.Text = Identificacion;
            idproveedor = Convert.ToInt32(DtProveedor.SelectedCells[1].Value.ToString());
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
        }
    }
}
