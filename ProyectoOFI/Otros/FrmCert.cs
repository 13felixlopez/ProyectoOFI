using ProyectoOFI.Datos;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoOFI.Otros
{
    public partial class FrmCert : Form
    {
        int Idcert;
        DCatalogo funcion = new DCatalogo();
        public FrmCert()
        {
            InitializeComponent();
            MostrarCert();
        }

        private void MostrarCert()
        {
            DataTable dt = new DataTable();
            funcion.MostrarCertificacion(ref dt);
            DtCert.DataSource = dt;
            DtCert.Columns[1].Visible = false;
        }
        private void InsertarCert()
        {
            if (TxtCert.Text=="")
            {
                MessageBox.Show("No se permiten campos vacíos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtCert.Focus();
            }
            else
            {
                if (funcion.AgregarCert(TxtCert.Text) == true)
                {
                    MostrarCert();
                    TxtCert.Clear();
                }
            }
        }
        private void EditarCert()
        {
            if (TxtCert.Text != "")
            {
                if (funcion.EditarCertificacion(Idcert,TxtCert.Text)==true)
                {
                    MostrarCert();
                    TxtCert.Clear();
                    BtnEditar.Visible = false;
                    BtnGuardar.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se permiten campos vacíos","ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtCert.Focus();
                }
            }
        }
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DtCert_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string nombre;
            nombre = DtCert.SelectedCells[2].Value.ToString();
            TxtCert.Text = nombre;
            Idcert = int.Parse(DtCert.SelectedCells[1].Value.ToString());
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
        }
        private void DtCert_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Idcert = int.Parse(DtCert.SelectedCells[1].Value.ToString());
            if (e.ColumnIndex == DtCert.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro de eliminar esta certificación, Desea Continuar?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result==DialogResult.OK)
                {
                    EliminarCert();
                }
            }
        }
        private void EliminarCert()
        {
            if (funcion.EliminarCert(Idcert) == true)
            {
                MostrarCert();
            }
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            InsertarCert();
        }
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EditarCert();
        }
    }
}
