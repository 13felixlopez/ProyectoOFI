using ProyectoOFI.Datos;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoOFI.Otros
{
    public partial class FrmDescargador : Form
    {
        int IdDescargador;
        public FrmDescargador()
        {
            InitializeComponent();
            MostrarDescargador();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            InsertarDescargador();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EditarDescargador();
        }

        private void DtDescargador_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Nombre;
            Nombre = DtDescargador.SelectedCells[2].Value.ToString();
            TxtDescargador.Text = Nombre;
            IdDescargador = Convert.ToInt32(DtDescargador.SelectedCells[1].Value.ToString());
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
        }

        private void DtDescargador_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdDescargador = int.Parse(DtDescargador.SelectedCells[1].Value.ToString());
            if (e.ColumnIndex == DtDescargador.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro de eliminar el Descargador, Desea Continuar?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarDescargador();
                }
            }
        }
        #region Metodos
        private void MostrarDescargador()
        {
            DCatalogo funcion = new DCatalogo();
            DataTable dt = new DataTable();
            funcion.MostrarDescargador(ref dt);
            DtDescargador.DataSource = dt;
            DtDescargador.Columns[1].Visible = false;
        }
        private void InsertarDescargador()
        {
            if (TxtDescargador.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtDescargador.Focus();
            }
            else
            {
                DCatalogo funcion = new DCatalogo();
                if (funcion.AgregarDescargador(TxtDescargador.Text) == true)
                {
                    MostrarDescargador();
                    TxtDescargador.Clear();
                }
            }
        }
        private void EditarDescargador()
        {
            if (TxtDescargador.Text != "")
            {
                DCatalogo funcion = new DCatalogo();
                if (funcion.EditarDescargador(IdDescargador, TxtDescargador.Text) == true)
                {
                    MostrarDescargador();
                    TxtDescargador.Clear();
                    BtnEditar.Visible = false;
                    BtnGuardar.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtDescargador.Focus();
                }
            }
        }
        private void EliminarDescargador()
        {
            DCatalogo funcion = new DCatalogo();
            if (funcion.EliminarDescargador(IdDescargador) == true)
            {
                MostrarDescargador();
            }
        }
        #endregion
    }
}
