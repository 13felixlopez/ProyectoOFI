using ProyectoOFI.Datos;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoOFI.Otros
{
    public partial class FrmCliente : Form
    {
        int idcliente;
        public FrmCliente()
        {
            InitializeComponent();
            MostrarClientes();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            AgregarCliente();
        }
        private void AgregarCliente()
        {
            if (TxtCliente.Text == "")
            {
                if (!string.IsNullOrEmpty(TxtIdentificacion.Text))
                {
                    MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtIdentificacion.Focus();
                }
                MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtCliente.Focus();
            }
            else
            {
                DCatalogo funcion = new DCatalogo();
                if (funcion.AgregarCliente(TxtIdentificacion.Text,TxtCliente.Text) == true)
                {
                    MostrarClientes();
                    TxtCliente.Clear();
                    TxtIdentificacion.Clear();
                }
            }
        }

        private void MostrarClientes()
        {
            DCatalogo funcion = new DCatalogo();
            DataTable dt = new DataTable();
            funcion.MostrarClientes(ref dt);
            DtCliente.DataSource = dt;
            DtCliente.Columns[1].Visible = false;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EditarCliente();
        }
        private void EditarCliente()
        {
            if (TxtCliente.Text != "" && TxtIdentificacion.Text != "")
            {
                DCatalogo funcion = new DCatalogo();
                if (funcion.EditarCliente(idcliente, TxtIdentificacion.Text,TxtCliente.Text) == true)
                {
                    MostrarClientes();
                    TxtCliente.Clear();
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

        private void DtCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Nombre;
            string Identificacion;
            Identificacion = DtCliente.SelectedCells[3].Value.ToString();
            Nombre = DtCliente.SelectedCells[2].Value.ToString();
            TxtCliente.Text = Nombre;
            TxtIdentificacion.Text = Identificacion;
            idcliente = Convert.ToInt32(DtCliente.SelectedCells[1].Value.ToString());
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
        }

        private void DtCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idcliente = int.Parse(DtCliente.SelectedCells[1].Value.ToString());
            if (e.ColumnIndex == DtCliente.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro de eliminar el Cliente, Desea Continuar?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarCliente();
                }
            }
        }

        private void EliminarCliente()
        {
            DCatalogo funcion = new DCatalogo();
            if (funcion.EliminarCliente(idcliente) == true)
            {
                MostrarClientes();
            }
        }
    }
}
