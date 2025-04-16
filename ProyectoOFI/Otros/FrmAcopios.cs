using ProyectoOFI.Datos;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoOFI.Otros
{
    public partial class FrmAcopios : Form
    {
        int Idagencia, idacopio;
        public FrmAcopios()
        {
            InitializeComponent();
            MostrarAcopios();
            DtAcopio.Columns["IdAcopio"].Visible = false;
            DtAcopio.Columns["IdAgencia"].Visible = false;
        }

        private void FrmAcopios_Load(object sender, EventArgs e)
        {
            DRecepcion funcion = new DRecepcion();
            funcion.MostrarAgencia(CbAgencia);
        }
        private void InsertarAcopio()
        {
            DCatalogo funcion = new DCatalogo();
            int idagencia = int.Parse(CbAgencia.SelectedValue.ToString());
            if (funcion.InsertarAcopio(TxtAcopio.Text, (int)CbAgencia.SelectedValue) == true)
            {
                TxtAcopio.Clear();
                MostrarAcopios();
            }
        }
        private void MostrarAcopios()
        {
            DCatalogo funcion = new DCatalogo();
            DataTable dt = new DataTable();
            funcion.MostrarAcopios(ref dt);
            DtAcopio.DataSource = dt;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            InsertarAcopio();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DtAcopio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LblAgencia.Text = DtAcopio.SelectedCells[4].Value.ToString();
            TxtAcopio.Text = DtAcopio.SelectedCells[3].Value.ToString();
            idacopio = int.Parse(DtAcopio.SelectedCells[1].Value.ToString());
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
            label3.Visible = true;
            LblAgencia.Visible = true;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Editarcopio();
        }

        private void CbAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Idagencia = (int)CbAgencia.SelectedIndex;
        }

        private void DtAcopio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idacopio = int.Parse(DtAcopio.SelectedCells[1].Value.ToString());
            if (e.ColumnIndex == DtAcopio.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro de eliminar el Acopio, Desea Continuar?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarAcopio();
                }
            }
        }

        private void EliminarAcopio()
        {
            DCatalogo funcion = new DCatalogo();
            if (funcion.EliminarAcopio(idacopio) == true)
            {
                MostrarAcopios();
            }
        }

        private void Editarcopio()
        {
            DCatalogo funcion = new DCatalogo();
            if (funcion.EditarAcopio(idacopio, TxtAcopio.Text, (int)CbAgencia.SelectedValue) == true)
            {
                MostrarAcopios();
                TxtAcopio.Clear();
                BtnEditar.Visible = false;
                BtnGuardar.Visible = true;
                label3.Visible = false;
                LblAgencia.Visible = false;
            }
        }
    }
}
