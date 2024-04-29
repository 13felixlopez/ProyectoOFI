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
    public partial class FrmOperadorSM : Form
    {
        int IdOperadorSM;
        public FrmOperadorSM()
        {
            InitializeComponent();
            MostrarOperadorSM();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region Metodos
        private void MostrarOperadorSM()
        {
            DCatalogo funcion = new DCatalogo();
            DataTable dt = new DataTable();
            funcion.MostrarOperadorSM(ref dt);
            DtOperadorSM.DataSource = dt;
            DtOperadorSM.Columns[1].Visible = false;
        }
        private void InsertarOperadorSM()
        {
            if (TxtOperadorSM.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtOperadorSM.Focus();
            }
            else
            {
                DCatalogo funcion = new DCatalogo();
                if (funcion.AgregarOperadorSM(TxtOperadorSM.Text) == true)
                {
                    MostrarOperadorSM();
                    TxtOperadorSM.Clear();
                }
            }
        }
        private void EditarOperadorSM()
        {
            if (TxtOperadorSM.Text != "")
            {
                DCatalogo funcion = new DCatalogo();
                if (funcion.EditarOperadorSM(IdOperadorSM, TxtOperadorSM.Text) == true)
                {
                    MostrarOperadorSM();
                    TxtOperadorSM.Clear();
                    BtnEditar.Visible = false;
                    BtnGuardar.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se permiten campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtOperadorSM.Focus();
                }
            }
        }
        private void EliminarOperadorSM()
        {
            DCatalogo funcion = new DCatalogo();
            if (funcion.EliminarOperadorSM(IdOperadorSM) == true)
            {
                MostrarOperadorSM();
            }
        }
        #endregion
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            InsertarOperadorSM();
        }
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EditarOperadorSM();
        }
        private void DtOperadorSM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Nombre;
            Nombre = DtOperadorSM.SelectedCells[2].Value.ToString();
            TxtOperadorSM.Text = Nombre;
            IdOperadorSM = Convert.ToInt32(DtOperadorSM.SelectedCells[1].Value.ToString());
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
        }
        private void DtOperadorSM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdOperadorSM = int.Parse(DtOperadorSM.SelectedCells[1].Value.ToString());
            if (e.ColumnIndex == DtOperadorSM.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro de eliminar el OperadorSM, Desea Continuar?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarOperadorSM();
                }
            }
        }
    }
}
