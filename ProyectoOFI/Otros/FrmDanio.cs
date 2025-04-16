using ProyectoOFI.Datos;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoOFI.Otros
{
    public partial class FrmDanio : Form
    {
        DCatalogo funcion = new DCatalogo();
        int IdDanio;
        public FrmDanio()
        {
            InitializeComponent();
            MostrarDanio();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region Metodos
        private void MostrarDanio()
        {
            DataTable dt = new DataTable();
            funcion.MostrarDanio(ref dt);
            DtDaño.DataSource = dt;
            DtDaño.Columns[1].Visible = false;
        }
        private void InsertarDaño()
        {
            if (TxtDaño.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtDaño.Focus();
            }
            else
            {
                if (funcion.AgregarDanio(TxtDaño.Text) == true)
                {
                    MostrarDanio();
                    TxtDaño.Clear();
                }
            }
        }
        private void EditarDaño()
        {
            if (TxtDaño.Text != "")
            {
                if (funcion.EditarDanio(IdDanio, TxtDaño.Text) == true)
                {
                    MostrarDanio();
                    TxtDaño.Clear();
                    BtnEditar.Visible = false;
                    BtnGuardar.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se permiten campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtDaño.Focus();
                }
            }
        }
        private void EliminarDaño()
        {
            if (funcion.EliminarDanio(IdDanio))
            {
                MostrarDanio();
            }
        }
        private void ObtenerDatos()
        {
            string Nombre;
            Nombre = DtDaño.SelectedCells[2].Value.ToString();
            TxtDaño.Text = Nombre;
            IdDanio = Convert.ToInt32(DtDaño.SelectedCells[1].Value.ToString());
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
        }
        #endregion

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            InsertarDaño();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EditarDaño();
        }

        private void DtDaño_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerDatos();
        }

        private void DtDaño_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdDanio = int.Parse(DtDaño.SelectedCells[1].Value.ToString());
            if (e.ColumnIndex == DtDaño.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro de eliminar el Recibidor, Desea Continuar?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarDaño();
                }
            }
        }
    }
}
