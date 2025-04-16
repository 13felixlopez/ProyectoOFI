using ProyectoOFI.Datos;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoOFI.Otros
{
    public partial class FrmTurnoAl : Form
    {
        DCatalogo funcion = new DCatalogo();
        int IdTurnoAl;
        public FrmTurnoAl()
        {
            InitializeComponent();
            MostrarTurnoAl();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            InsertarTurnoAl();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EditarTurnoAl();
        }

        private void DtTurnoAl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTurnoAl = int.Parse(DtTurnoAl.SelectedCells[1].Value.ToString());
            if (e.ColumnIndex == DtTurnoAl.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de eliminar el TurnoAl, Desea continuar?", "Eliminando TurnoAl", MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarTurnoAl();
                }
            }
        }

        private void DtTurnoAl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string Nombre;
            Nombre = DtTurnoAl.SelectedCells[2].Value.ToString();
            TxtTurnoAl.Text = Nombre;
            IdTurnoAl = Convert.ToInt32(DtTurnoAl.SelectedCells[1].Value.ToString());
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
        }
        #region Metodos
        private void MostrarTurnoAl()
        {
            DataTable dt = new DataTable();
            funcion.MostrarTurnoAl(ref dt);
            DtTurnoAl.DataSource = dt;
            DtTurnoAl.Columns[1].Visible = false;
        }
        private void InsertarTurnoAl()
        {
            if (TxtTurnoAl.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtTurnoAl.Focus();
            }
            else
            {
                if (funcion.AgregarTurnoAl(TxtTurnoAl.Text) == true)
                {
                    MostrarTurnoAl();
                    TxtTurnoAl.Clear();
                }
            }
        }
        private void EditarTurnoAl()
        {
            if (TxtTurnoAl.Text != "")
            {
                if (funcion.EditarTurnoAl(IdTurnoAl, TxtTurnoAl.Text) == true)
                {
                    MostrarTurnoAl();
                    TxtTurnoAl.Clear();
                    BtnEditar.Visible = false;
                    BtnGuardar.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se permiten campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtTurnoAl.Focus();
                }
            }
        }
        private void EliminarTurnoAl()
        {
            if (funcion.EliminarTurnoAl(IdTurnoAl))
            {
                MostrarTurnoAl();
            }
        }
        #endregion
    }
}
