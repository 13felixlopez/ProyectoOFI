using ProyectoOFI.Datos;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoOFI.SM
{
    public partial class Guardiolas : UserControl
    {
        int IdPOA, IdGuardiola;
        public Guardiolas()
        {
            InitializeComponent();
        }

        private void Guardiolas_Load(object sender, EventArgs e)
        {
            MostrarGuardiolaLabels();
            Estilo();
        }

        private void MostrarGuardiolaLabels()
        {
            DGuardiola datos = new DGuardiola();
            DataTable tablaTickets = datos.MostrarGuardiola();
            foreach (DataRow fila in tablaTickets.Rows)
            {
                int POA = Convert.ToInt32(fila["Guardiola"]);
                string ticket = fila["Ticket"].ToString();
                MostrarTicketEnLabel(POA, ticket);
            }
        }
        protected void MostrarTicketEnLabel(int Guardiola, string ticket)
        {
            // Encuentra el Label correspondiente a la POAV
            string lblName = "LblG" + Guardiola;
            Control[] controls = Controls.Find(lblName, true);
            if (controls.Length > 0 && controls[0] is Label)
            {
                // Muestra el ticket en el Label
                Label lblTicket = (Label)controls[0];
                lblTicket.Text = ticket;
            }
        }
        public void Estilo()
        {
            //Rojo
            int r1 = 240, g1 = 110, b1 = 67;
            //Verde
            int r = 0; int p = 221;
            int f = 117;
            #region Guardiola1
            if (LblG1.Text == "--")
            {
                BtnG1.BackColor = Color.FromArgb(r1, g1, b1);
                LblG1.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnG1.BackColor = Color.FromArgb(r, p, f);
                LblG1.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola2
            if (LblG2.Text == "--")
            {
                BtnG2.BackColor = Color.FromArgb(r1, g1, b1);
                LblG2.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnG2.BackColor = Color.FromArgb(r, p, f);
                LblG2.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola3
            if (LblG3.Text == "--")
            {
                BtnG3.BackColor = Color.FromArgb(r1, g1, b1);
                LblG3.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnG3.BackColor = Color.FromArgb(r, p, f);
                LblG3.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola4
            if (LblG4.Text == "--")
            {
                BtnG4.BackColor = Color.FromArgb(r1, g1, b1);
                LblG4.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnG4.BackColor = Color.FromArgb(r, p, f);
                LblG4.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola5
            if (LblG5.Text == "--")
            {
                BtnG5.BackColor = Color.FromArgb(r1, g1, b1);
                LblG5.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnG5.BackColor = Color.FromArgb(r, p, f);
                LblG5.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola6
            if (LblG6.Text == "--")
            {
                BtnG6.BackColor = Color.FromArgb(r1, g1, b1);
                LblG6.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnG6.BackColor = Color.FromArgb(r, p, f);
                LblG6.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola7
            if (LblG7.Text == "--")
            {
                BtnG7.BackColor = Color.FromArgb(r1, g1, b1);
                LblG7.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnG7.BackColor = Color.FromArgb(r, p, f);
                LblG7.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola8
            if (LblG8.Text == "--")
            {
                BtnG8.BackColor = Color.FromArgb(r1, g1, b1);
                LblG8.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnG8.BackColor = Color.FromArgb(r, p, f);
                LblG8.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola9
            if (LblG9.Text == "--")
            {
                BtnG9.BackColor = Color.FromArgb(r1, g1, b1);
                LblG9.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnG9.BackColor = Color.FromArgb(r, p, f);
                LblG9.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola10
            if (LblG10.Text == "--")
            {
                BtnG10.BackColor = Color.FromArgb(r1, g1, b1);
                LblG10.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnG10.BackColor = Color.FromArgb(r, p, f);
                LblG10.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola11
            if (LblG11.Text == "--")
            {
                BtnG11.BackColor = Color.FromArgb(r1, g1, b1);
                LblG11.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnG11.BackColor = Color.FromArgb(r, p, f);
                LblG11.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola12
            if (LblG12.Text == "--")
            {
                BtnG12.BackColor = Color.FromArgb(r1, g1, b1);
                LblG12.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnG12.BackColor = Color.FromArgb(r, p, f);
                LblG12.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola13
            if (LblG13.Text == "--")
            {
                BtnG13.BackColor = Color.FromArgb(r1, g1, b1);
                LblG13.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnG13.BackColor = Color.FromArgb(r, p, f);
                LblG13.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola14
            if (LblG14.Text == "--")
            {
                BtnG14.BackColor = Color.FromArgb(r1, g1, b1);
                LblG14.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnG14.BackColor = Color.FromArgb(r, p, f);
                LblG14.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola15
            if (LblG15.Text == "--")
            {
                BtnG15.BackColor = Color.FromArgb(r1, g1, b1);
                LblG15.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnG15.BackColor = Color.FromArgb(r, p, f);
                LblG15.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola16
            if (LblG16.Text == "--")
            {
                BtnG16.BackColor = Color.FromArgb(r1, g1, b1);
                LblG16.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnG16.BackColor = Color.FromArgb(r, p, f);
                LblG16.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola17
            if (LblG17.Text == "--")
            {
                BtnG17.BackColor = Color.FromArgb(r1, g1, b1);
                LblG17.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnG17.BackColor = Color.FromArgb(r, p, f);
                LblG17.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region Guardiola18
            if (LblG18.Text == "--")
            {
                BtnG18.BackColor = Color.FromArgb(r1, g1, b1);
                LblG18.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnG18.BackColor = Color.FromArgb(r, p, f);
                LblG18.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
        }
        private void CargaGuardiola(Label lblG)
        {
            try
            {

                DGuardiola funcion = new DGuardiola();
                DataTable dt = new DataTable();
                funcion.CargarGuardiola(lblG.Text, dt);
                LblTicket.Text = lblG.Text;
                LblSacos.Text = dt.Rows[0]["Sacos"].ToString();
                LblKilos.Text = dt.Rows[0]["Peso"].ToString();
                double kilos = Convert.ToDouble(LblKilos.Text);
                kilos = kilos / 46;
                LblQQsV.Text = Math.Round(kilos, 2).ToString();
                LblCalidadV.Text = dt.Rows[0]["Calidad"].ToString();
                LblDanioV.Text = dt.Rows[0]["Danio"].ToString();
                LblEFisicoV.Text = dt.Rows[0]["EstFisico"].ToString();
                LblCert.Text = dt.Rows[0]["Certificacion"].ToString();
                LblGuardiola.Text = dt.Rows[0]["Guardiola"].ToString();
                LblOperador.Text = dt.Rows[0]["Nombre"].ToString();
                LblTurno.Text = dt.Rows[0]["TurnoG"].ToString();
                dtFechaG.Text = dt.Rows[0]["FechaG"].ToString();
                dtHoraIniG.Text = dt.Rows[0]["HoraIniG"].ToString();
                dtHoraFinG.Text = dt.Rows[0]["HoraFinG"].ToString();
                LblHumedadG.Text = dt.Rows[0]["Humedad"].ToString();
                IdPOA = int.Parse(dt.Rows[0]["IdPOA"].ToString());
                IdGuardiola = int.Parse(dt.Rows[0]["IdGuardiola"].ToString());
                LblDigitadorG.Text = dt.Rows[0]["DigitadorG"].ToString();
                TimeSpan tiempo = (TimeSpan)dt.Rows[0]["DuracionG"];
                string duracionFormateada = $"{tiempo.Hours:D2}:{tiempo.Minutes:D2}";
                LblDuracionG.Text = duracionFormateada;
                AbrirFormulario();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void AbrirFormulario()
        {
            PlDatos.Size = new Size(1354, 517);
            PlDatos.Visible = true;
            PlDatos.Location = new Point(TLPGuardiola.Width / 2
                - PlDatos.Width / 2, TLPGuardiola.Height / 2 - PlDatos.Height / 2);
            PlDatos.BringToFront();
            DPOAV funcion = new DPOAV();
            funcion.MostrarTurno(CbTurno);
            TLPGuardiola.Enabled = false;
        }
        private void BtnG1_Click(object sender, EventArgs e)
        {
            try
            {
                if (LblG1.Text != "--")
                {
                    CargaGuardiola(LblG1);
                }
                else
                {
                    MessageBox.Show("Guardiola Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //PlDatos.Visible = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void BtnG2_Click(object sender, EventArgs e)
        {
            if (LblG2.Text != "--")
            {
                CargaGuardiola(LblG2);
            }
            else
            {
                MessageBox.Show("Guardiola Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //PlDatos.Visible = false;
            }
        }

        private void BtnG3_Click(object sender, EventArgs e)
        {
            if (LblG3.Text != "--")
            {
                CargaGuardiola(LblG3);
            }
            else
            {
                MessageBox.Show("Guardiola Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //PlDatos.Visible = false;
            }
        }

        private void BtnG4_Click(object sender, EventArgs e)
        {
            if (LblG4.Text != "--")
            {
                CargaGuardiola(LblG4);
            }
            else
            {
                MessageBox.Show("Guardiola Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //PlDatos.Visible = false;
            }
        }

        private void BtnG5_Click(object sender, EventArgs e)
        {
            if (LblG5.Text != "--")
            {
                CargaGuardiola(LblG5);
            }
            else
            {
                MessageBox.Show("Guardiola Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //PlDatos.Visible = false;
            }
        }

        private void BtnG6_Click(object sender, EventArgs e)
        {
            if (LblG6.Text != "--")
            {
                CargaGuardiola(LblG6);
            }
            else
            {
                MessageBox.Show("Guardiola Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //PlDatos.Visible = false;
            }
        }

        private void BtnG7_Click(object sender, EventArgs e)
        {
            if (LblG7.Text != "--")
            {
                CargaGuardiola(LblG7);
            }
            else
            {
                MessageBox.Show("Guardiola Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //PlDatos.Visible = false;
            }
        }

        private void BtnG8_Click(object sender, EventArgs e)
        {
            if (LblG8.Text != "--")
            {
                CargaGuardiola(LblG8);
            }
            else
            {
                MessageBox.Show("Guardiola Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //PlDatos.Visible = false;
            }
        }

        private void BtnG9_Click(object sender, EventArgs e)
        {
            if (LblG9.Text != "--")
            {
                CargaGuardiola(LblG9);
            }
            else
            {
                MessageBox.Show("Guardiola Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //PlDatos.Visible = false;
            }
        }

        private void BtnG10_Click(object sender, EventArgs e)
        {
            if (LblG10.Text != "--")
            {
                CargaGuardiola(LblG10);
            }
            else
            {
                MessageBox.Show("Guardiola Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //PlDatos.Visible = false;
            }
        }

        private void BtnG11_Click(object sender, EventArgs e)
        {
            if (LblG11.Text != "--")
            {
                CargaGuardiola(LblG11);
            }
            else
            {
                MessageBox.Show("Guardiola Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //PlDatos.Visible = false;
            }
        }

        private void BtnG12_Click(object sender, EventArgs e)
        {
            if (LblG12.Text != "--")
            {
                CargaGuardiola(LblG12);
            }
            else
            {
                MessageBox.Show("Guardiola Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //PlDatos.Visible = false;
            }
        }

        private void BtnG13_Click(object sender, EventArgs e)
        {
            if (LblG13.Text != "--")
            {
                CargaGuardiola(LblG13);
            }
            else
            {
                MessageBox.Show("Guardiola Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //PlDatos.Visible = false;
            }
        }

        private void BtnG14_Click(object sender, EventArgs e)
        {
            if (LblG14.Text != "--")
            {
                CargaGuardiola(LblG14);
            }
            else
            {
                MessageBox.Show("Guardiola Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //PlDatos.Visible = false;
            }
        }

        private void BtnG15_Click(object sender, EventArgs e)
        {
            if (LblG15.Text != "--")
            {
                CargaGuardiola(LblG15);
            }
            else
            {
                MessageBox.Show("Guardiola Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //PlDatos.Visible = false;
            }
        }

        private void BtnG16_Click(object sender, EventArgs e)
        {
            if (LblG16.Text != "--")
            {
                CargaGuardiola(LblG16);
            }
            else
            {
                MessageBox.Show("Guardiola Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //PlDatos.Visible = false;
            }
        }

        private void BtnG17_Click(object sender, EventArgs e)
        {
            if (LblG17.Text != "--")
            {
                CargaGuardiola(LblG17);
            }
            else
            {
                MessageBox.Show("Guardiola Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //PlDatos.Visible = false;
            }
        }

        private void BtnCerrarVerCons_Click(object sender, EventArgs e)
        {
            PlDatos.Visible = false;
            TLPGuardiola.Enabled = true;
        }

        private void BtnG18_Click(object sender, EventArgs e)
        {
            if (LblG18.Text != "--")
            {
                CargaGuardiola(LblG18);
            }
            else
            {
                MessageBox.Show("Guardiola Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //PlDatos.Visible = false;
            }
        }
    }
}
