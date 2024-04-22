using ProyectoOFI.Datos;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoOFI.Otros
{
    public partial class FrmUbicacionP : Form
    {
        DCatalogo fun = new DCatalogo();
        int idUbicacionP, idPatio;
        public FrmUbicacionP()
        {
            InitializeComponent();
            MostrarUbicacionP();
            DtUbicacion.Columns["IdUbicacionP"].Visible = false;
            DtUbicacion.Columns["IdPatio"].Visible = false;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmUbicacionP_Load(object sender, EventArgs e)
        {
            DTendido funcion = new DTendido();
            funcion.MostrarPatio(CbPatio);
        }
        private void InsertarUbicacion()
        {
            int idpatio = int.Parse(CbPatio.SelectedValue.ToString());
            if (fun.AgregarUbicacionP(TxtUbicacion.Text, (int)CbPatio.SelectedValue) == true)
            {
                TxtUbicacion.Clear();
                MostrarUbicacionP();
            }
        }
        private void MostrarUbicacionP()
        {
            DCatalogo funcion = new DCatalogo();
            DataTable dt = new DataTable();
            funcion.MostrarUbicacionP(ref dt);
            DtUbicacion.DataSource = dt;
        }
        private void EliminarUbicacionP()
        {
            DCatalogo funcion = new DCatalogo();
            if (funcion.EliminarUbicacionP(idUbicacionP) == true)
            {
                MostrarUbicacionP();
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            InsertarUbicacion();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EditarUbicacioP();
        }

        private void DtUbicacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LblPatio.Text = DtUbicacion.SelectedCells[4].Value.ToString();
            TxtUbicacion.Text = DtUbicacion.SelectedCells[3].Value.ToString();
            idUbicacionP = int.Parse(DtUbicacion.SelectedCells[1].Value.ToString());
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
            label3.Visible = true;
            LblPatio.Visible = true;
        }

        private void DtUbicacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idUbicacionP = int.Parse(DtUbicacion.SelectedCells[1].Value.ToString());
            if (e.ColumnIndex == DtUbicacion.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro de eliminar el Ubicación, Desea Continuar?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarUbicacionP();
                }
            }
        }

        private void EditarUbicacioP()
        {
            DCatalogo funcion = new DCatalogo();
            if (funcion.EditarUbicacionP(idUbicacionP, TxtUbicacion.Text, (int)CbPatio.SelectedValue) == true)
            {
                MostrarUbicacionP();
                TxtUbicacion.Clear();
                BtnEditar.Visible = false;
                BtnGuardar.Visible = true;
                label3.Visible = false;
                LblPatio.Visible = false;
            }
        }
    }
}
