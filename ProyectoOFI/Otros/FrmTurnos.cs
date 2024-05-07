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
    public partial class FrmTurnos : Form
    {
        DCatalogo funcion = new DCatalogo();
        int IdTurno;
        public FrmTurnos()
        {
            InitializeComponent();
            MostrarTurno();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DtTurnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTurno = int.Parse(DtTurnos.SelectedCells[1].Value.ToString());
            if (e.ColumnIndex == DtTurnos.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de eliminar el Turno, Desea continuar?", "Eliminando turno", MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarTurno();
                }
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            InsertarTurno();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EditarTurno();
        }
        #region Metodos
        private void MostrarTurno()
        {
            DataTable dt = new DataTable();
            funcion.MostrarTurno(ref dt);
            DtTurnos.DataSource = dt;
            DtTurnos.Columns[1].Visible = false;
        }
        private void InsertarTurno()
        {
            if (TxtTurnos.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtTurnos.Focus();
            }
            else
            {
                if (funcion.AgregarTurnos(TxtTurnos.Text) == true)
                {
                    MostrarTurno();
                    TxtTurnos.Clear();
                }
            }
        }
        private void EditarTurno()
        {
            if (TxtTurnos.Text != "")
            {
                if (funcion.EditarTurnos(IdTurno, TxtTurnos.Text) == true)
                {
                    MostrarTurno();
                    TxtTurnos.Clear();
                    BtnEditar.Visible = false;
                    BtnGuardar.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se permiten campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtTurnos.Focus();
                }
            }
        }
        private void EliminarTurno()
        {
            if (funcion.EliminarTurno(IdTurno))
            {
                MostrarTurno();
            }
        }
        #endregion

        private void DtTurnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string Nombre;
            Nombre = DtTurnos.SelectedCells[2].Value.ToString();
            TxtTurnos.Text = Nombre;
            IdTurno = Convert.ToInt32(DtTurnos.SelectedCells[1].Value.ToString());
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
        }
    }
}
