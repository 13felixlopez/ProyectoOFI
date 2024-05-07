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
    public partial class FrmParos : Form
    {
        DCatalogo funcion = new DCatalogo();
        int IdParo;
        public FrmParos()
        {
            InitializeComponent();
            MostrarParo();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DtParos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdParo = int.Parse(DtParos.SelectedCells[1].Value.ToString());
            if (e.ColumnIndex == DtParos.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de eliminar el Paro, Desea continuar?", "Eliminando Paro", MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarParo();
                }
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            InsertarParo();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EditarParo();
        }
        #region Metodos
        private void MostrarParo()
        {
            DataTable dt = new DataTable();
            funcion.MostrarParo(ref dt);
            DtParos.DataSource = dt;
            DtParos.Columns[1].Visible = false;
        }
        private void InsertarParo()
        {
            if (TxtParos.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtParos.Focus();
            }
            else
            {
                if (funcion.AgregarParos(TxtParos.Text) == true)
                {
                    MostrarParo();
                    TxtParos.Clear();
                }
            }
        }
        private void EditarParo()
        {
            if (TxtParos.Text != "")
            {
                if (funcion.EditarParos(IdParo, TxtParos.Text) == true)
                {
                    MostrarParo();
                    TxtParos.Clear();
                    BtnEditar.Visible = false;
                    BtnGuardar.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se permiten campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtParos.Focus();
                }
            }
        }
        private void EliminarParo()
        {
            if (funcion.EliminarParo(IdParo))
            {
                MostrarParo();
            }
        }
        #endregion

        private void DtParos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string Nombre;
            Nombre = DtParos.SelectedCells[2].Value.ToString();
            TxtParos.Text = Nombre;
            IdParo = Convert.ToInt32(DtParos.SelectedCells[1].Value.ToString());
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
        }
    }
}
