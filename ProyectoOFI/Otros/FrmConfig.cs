using DocumentFormat.OpenXml.Vml.Spreadsheet;
using ProyectoOFI.Datos;
using ProyectoOFI.Recepcion;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoOFI.Otros
{
    public partial class FrmConfig : Form
    {
        int IdCosecha;
        public FrmConfig()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
            //frmInicio fr=new frmInicio();
            //fr.ShowDialog();
        }

        private void BtnAgencia_Click(object sender, EventArgs e)
        {
            FrmAgencia AA = new FrmAgencia();
            AA.ShowDialog();
        }

        private void BtnAcopio_Click(object sender, EventArgs e)
        {
            FrmAcopios AA = new FrmAcopios();
            AA.ShowDialog();
        }

        private void BtnRecibidor_Click(object sender, EventArgs e)
        {
            Recibidor AA = new Recibidor();
            AA.ShowDialog();
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            FrmCliente AA = new FrmCliente();
            AA.ShowDialog();
        }

        private void BtnCompra_Click(object sender, EventArgs e)
        {
            FrmCompra AA = new FrmCompra();
            AA.ShowDialog();
        }

        private void BtnCert_Click(object sender, EventArgs e)
        {
            FrmCert AA = new FrmCert();
            AA.ShowDialog();
        }

        private void BtnEstf_Click(object sender, EventArgs e)
        {
            FrmEstFis AA = new FrmEstFis();
            AA.ShowDialog();
        }

        private void BtnCalidad_Click(object sender, EventArgs e)
        {
            FrmCalidad AA = new FrmCalidad();
            AA.ShowDialog();
        }

        private void BtnDaño_Click(object sender, EventArgs e)
        {
            FrmDanio AA = new FrmDanio();
            AA.ShowDialog();
        }

        private void BtnAreaS_Click(object sender, EventArgs e)
        {
            FrmAreaSecado AA = new FrmAreaSecado();
            AA.ShowDialog();
        }

        private void BtnPatio_Click(object sender, EventArgs e)
        {
            FrmPatio AA = new FrmPatio();
            AA.ShowDialog();
        }

        private void BtnUbicacionesPatio_Click(object sender, EventArgs e)
        {
            FrmUbicacionP AA = new FrmUbicacionP();
            AA.ShowDialog();
        }

        private void BtnOperadores_Click(object sender, EventArgs e)
        {
            FrmOperadorSM AA = new FrmOperadorSM();
            AA.ShowDialog();
        }

        private void BtnTurnos_Click(object sender, EventArgs e)
        {
            FrmTurnos AA = new FrmTurnos();
            AA.ShowDialog();
        }

        private void BtnParos_Click(object sender, EventArgs e)
        {
            FrmParos AA = new FrmParos();
            AA.ShowDialog();
        }

        private void BtnVariedad_Click(object sender, EventArgs e)
        {
            FrmVariedad AA = new FrmVariedad();
            AA.ShowDialog();
        }

        private void BtnDescargador_Click(object sender, EventArgs e)
        {
            FrmDescargador AA = new FrmDescargador();
            AA.ShowDialog();
        }

        private void BtnBodegas_Click(object sender, EventArgs e)
        {
            FrmBodega AA = new FrmBodega();
            AA.ShowDialog();
        }

        private void BtnUbicacion_Click(object sender, EventArgs e)
        {
            FrmUbicacionB AA = new FrmUbicacionB();
            AA.ShowDialog();
        }

        private void BtnEmpaques_Click(object sender, EventArgs e)
        {
            FrmEmpaque AA = new FrmEmpaque();
            AA.ShowDialog();
        }

        private void BtnTurnosAl_Click(object sender, EventArgs e)
        {
            FrmTurnoAl AA = new FrmTurnoAl();
            AA.ShowDialog();
        }

        private void BtnCosechas_Click(object sender, EventArgs e)
        {
            Gbcatacion.Enabled = false;
            GbControlPatio.Enabled = false;
            GbTransfer.Enabled = false;
            GbSM.Enabled = false;
            GbAlmacen.Enabled = false;
            BtnCerrar.Enabled = false;
            PlCosecha.Visible = true;
            PlCosecha.Location = new System.Drawing.Point(220, 161);
            PlCosecha.Size = new System.Drawing.Size(493, 395);
            MostrarCosecha();
        }

        private void BtnCerrarCosecha_Click(object sender, EventArgs e)
        {
            PlCosecha.Visible = false;
            Gbcatacion.Enabled = true;
            GbControlPatio.Enabled = true;
            GbTransfer.Enabled = true;
            GbSM.Enabled = true;
            GbAlmacen.Enabled = true;
            BtnCerrar.Enabled = true;
        }
        private void InsertarCosecha()
        {
            DCatalogo funcion = new DCatalogo();
            if (TxtCosecha.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtCosecha.Focus();
            }
            else
            {
                if (funcion.InsertarCosecha(TxtCosecha.Text) == true)
                {
                    MostrarCosecha();
                    TxtCosecha.Clear();
                }
            }
        }
        DCatalogo funcion = new DCatalogo();
        private void MostrarCosecha()
        {
            DataTable dt = new DataTable();
            funcion.MostrarCosechas(ref dt);
            DtCosechas.DataSource = dt;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            InsertarCosecha();
        }
        private void EditarCosecha()
        {
            if (TxtCosecha.Text != "")
            {
                if (funcion.EditarDanio(IdCosecha, TxtCosecha.Text) == true)
                {
                    MostrarCosecha();
                    TxtCosecha.Clear();
                    BtnEditar.Visible = false;
                    BtnGuardar.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se permiten campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtCosecha.Focus();
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EditarCosecha();
        }
        private void ObtenerDatos()
        {
            string Nombre;
            Nombre = DtCosechas.SelectedCells[2].Value.ToString();
            TxtCosecha.Text = Nombre;
            IdCosecha = Convert.ToInt32(DtCosechas.SelectedCells[1].Value.ToString());
            BtnEditar.Visible = true;
            BtnGuardar.Visible = false;
        }

        private void DtCosechas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerDatos();
        }
    }
}
