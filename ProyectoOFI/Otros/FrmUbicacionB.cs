using ProyectoOFI.Datos;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoOFI.Otros
{
    public partial class FrmUbicacionB : Form
    {
        DCatalogo fun = new DCatalogo();
        int IdUbicacionB;
        public FrmUbicacionB()
        {
            InitializeComponent();
            MostrarUbicacionB();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            InsertarUbicacionB();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EditarUbicacionB();
        }

        private void DtUbicacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LblBodega.Text = DtUbicacion.SelectedCells[3].Value.ToString();
            TxtUbicacion.Text = DtUbicacion.SelectedCells[2].Value.ToString();
            IdUbicacionB = int.Parse(DtUbicacion.SelectedCells[1].Value.ToString());
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
            label3.Visible = true;
            LblBodega.Visible = true;
        }

        private void DtUbicacionB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdUbicacionB = int.Parse(DtUbicacion.SelectedCells[1].Value.ToString());
            if (e.ColumnIndex == DtUbicacion.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro de eliminar el Ubicación, Desea Continuar?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarUbicacionB();
                }
            }
        }

        #region Metodos
        private void InsertarUbicacionB()
        {
            int idBodega = int.Parse(CbBodega.SelectedValue.ToString());
            if (fun.AgregarUbicacionB(TxtUbicacion.Text, (int)CbBodega.SelectedValue) == true)
            {
                TxtUbicacion.Clear();
                MostrarUbicacionB();
            }
        }
        private void MostrarUbicacionB()
        {
            DCatalogo funcion = new DCatalogo();
            DataTable dt = new DataTable();
            funcion.MostrarUbicacionB(ref dt);
            DtUbicacion.DataSource = dt;
            DtUbicacion.Columns["IdUbicacion"].Visible = false;
        }
        private void EliminarUbicacionB()
        {
            DCatalogo funcion = new DCatalogo();
            if (funcion.EliminarUbicacionB(IdUbicacionB) == true)
            {
                MostrarUbicacionB();
            }
        }
        private void EditarUbicacionB()
        {
            DCatalogo funcion = new DCatalogo();
            if (funcion.EditarUbicacionB(IdUbicacionB, TxtUbicacion.Text, (int)CbBodega.SelectedValue) == true)
            {
                MostrarUbicacionB();
                TxtUbicacion.Clear();
                BtnEditar.Visible = false;
                BtnGuardar.Visible = true;
                label3.Visible = false;
                LblBodega.Visible = false;
            }
        }
        #endregion

        private void FrmUbicacionB_Load(object sender, EventArgs e)
        {
            DAlmacen funcion = new DAlmacen();
            funcion.MostrarBodega(CbBodega);
        }
    }
}
