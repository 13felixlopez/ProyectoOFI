using ProyectoOFI.Datos;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoOFI.Otros
{
    public partial class FrmGrupoCalidades : Form
    {
        string GCalidad;
        int IdGCalidad;
        public FrmGrupoCalidades()
        {
            InitializeComponent();
            MostrarGCalidades();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            InsertarGCalidad();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EditarGCalidad();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DtGCalidad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string GCalidad;
            GCalidad = DtGCalidad.SelectedCells[1].Value.ToString();
            TxtGCalidad.Text = GCalidad;
            IdGCalidad = Convert.ToInt32(DtGCalidad.SelectedCells[1].Value.ToString());
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
        }

        private void DtGCalidad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdGCalidad = int.Parse(DtGCalidad.SelectedCells[0].Value.ToString());
            if (e.ColumnIndex == DtGCalidad.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro de eliminar la GCalidad, Desea Continuar?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarGCalidad();
                }
            }
        }
        private void InsertarGCalidad()
        {
            if (TxtGCalidad.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtGCalidad.Focus();
            }
            else
            {
                DCatalogo funcion = new DCatalogo();
                if (funcion.AgregarGCalidades(TxtGCalidad.Text) == true)
                {
                    MostrarGCalidades();
                    TxtGCalidad.Clear();
                }
            }
        }
        private void MostrarGCalidades()
        {
            DCatalogo funcion = new DCatalogo();
            DataTable dt = new DataTable();
            funcion.MostrarGCalidades(ref dt);
            DtGCalidad.DataSource = dt;
            DtGCalidad.Columns[1].Visible = false;
        }
        private void EliminarGCalidad()
        {
            DCatalogo funcion = new DCatalogo();
            if (funcion.EliminarGCalidades(IdGCalidad) == true)
            {
                MostrarGCalidades();
            }
        }
        private void EditarGCalidad()
        {
            if (TxtGCalidad.Text != "")
            {
                DCatalogo funcion = new DCatalogo();
                if (funcion.EditarGCalidades(IdGCalidad, TxtGCalidad.Text) == true)
                {
                    MostrarGCalidades();
                    TxtGCalidad.Clear();
                    BtnEditar.Visible = false;
                    BtnGuardar.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtGCalidad.Focus();
            }
        }
    }
}
