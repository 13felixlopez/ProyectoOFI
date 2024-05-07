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

namespace ProyectoOFI.SM
{
    public partial class Verticales : UserControl
    {
        public Verticales()
        {
            InitializeComponent();
        }

        private void Verticales_Load(object sender, EventArgs e)
        {
            MostrarVerticalLabels();
            Estilo();
        }
        private void MostrarVerticalLabels()
        {
            DVerticales datos = new DVerticales();
            DataTable tablaTickets = datos.MostrarV();
            foreach (DataRow fila in tablaTickets.Rows)
            {
                int Ver = Convert.ToInt32(fila["Ver"]);
                string ticket = fila["Ticket"].ToString();
                MostrarTicketEnLabel(Ver, ticket);
            }
        }
        protected void MostrarTicketEnLabel(int Ver, string ticket)
        {
            // Encuentra el Label correspondiente a la POAV
            string lblName = "lblV" + Ver;
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
            #region V1
            if (lblV1.Text == "--")
            {
                btnV1.BackColor = Color.FromArgb(r1, g1, b1);
                lblV1.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnV1.BackColor = Color.FromArgb(r, p, f);
                lblV1.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion

            #region Vertical2
            if (lblV2.Text == "--")
            {
                btnV2.BackColor = Color.FromArgb(r1, g1, b1);
                lblV2.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnV2.BackColor = Color.FromArgb(r, p, f);
                lblV2.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion

            #region Vertical3
            if (lblV3.Text == "--")
            {
                btnV3.BackColor = Color.FromArgb(r1, g1, b1);
                lblV3.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnV3.BackColor = Color.FromArgb(r, p, f);
                lblV3.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion

            #region Verical4
            if (lblV4.Text == "--")
            {
                btnV4.BackColor = Color.FromArgb(r1, g1, b1);
                lblV4.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnV4.BackColor = Color.FromArgb(r, p, f);
                lblV4.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion

            #region Vertical5
            if (lblV5.Text == "--")
            {
                btnV5.BackColor = Color.FromArgb(r1, g1, b1);
                lblV5.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnV5.BackColor = Color.FromArgb(r, p, f);
                lblV5.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion

            #region Vertical6
            if (lblV6.Text == "--")
            {
                btnV6.BackColor = Color.FromArgb(r1, g1, b1);
                lblV6.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnV6.BackColor = Color.FromArgb(r, p, f);
                lblV6.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion

            #region Vertical7
            if (lblV7.Text == "--")
            {
                btnV7.BackColor = Color.FromArgb(r1, g1, b1);
                lblV7.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnV7.BackColor = Color.FromArgb(r, p, f);
                lblV7.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion

            #region Vertical8
            if (lblV8.Text == "--")
            {
                btnV8.BackColor = Color.FromArgb(r1, g1, b1);
                lblV8.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnV8.BackColor = Color.FromArgb(r, p, f);
                lblV8.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
        }

        private void BtnCerrarVerCons_Click(object sender, EventArgs e)
        {
            PlDatos.Visible = false;
            TLPPlTolvas.Enabled = true;
        }
        private void CargaVer(Label V)
        {
            DVerticales verticales = new DVerticales();
            DataTable dt = new DataTable();
            verticales.CargarVer(V.Text, dt);
            LblTicket.Text = V.Text;
            LblSacos.Text = dt.Rows[0]["Sacos"].ToString();
            LblKilos.Text = dt.Rows[0]["Peso"].ToString();
            double kilos = Convert.ToDouble(LblKilos.Text);
            kilos = kilos / 46;
            LblQQsV.Text = Math.Round(kilos, 2).ToString();
            LblCalidadV.Text = dt.Rows[0]["Calidad"].ToString();
            LblDanioV.Text = dt.Rows[0]["Danio"].ToString();
            LblEFisicoV.Text = dt.Rows[0]["EstFisico"].ToString();
            LblOperador.Text = dt.Rows[0]["Nombre"].ToString();
            LblTurno.Text = dt.Rows[0]["TurnoV"].ToString();
            dtFProcV.Text = dt.Rows[0]["FRecibidoV"].ToString();
            dtHorainicioV.Text = dt.Rows[0]["HrInicioV"].ToString();
            dtHoraFinV.Text = dt.Rows[0]["HrFin"].ToString();
            TimeSpan tiempo = (TimeSpan)dt.Rows[0]["Duracion"];
            string duracionFormateada = $"{tiempo.Hours:D2}:{tiempo.Minutes:D2}";
            LblDuracion.Text = duracionFormateada;
            LblFRecibido.Text = dt.Rows[0]["FRecibido"].ToString();
            LblCert.Text = dt.Rows[0]["Certificacion"].ToString();
            Lblver.Text = dt.Rows[0]["Ver"].ToString();
            if (LblCert.Text != "Convencional")
            {
                PlDatos.BackColor = Color.FromArgb(192, 255, 255);
            }
            else
            {
                PlDatos.BackColor = Color.FromArgb(192, 255, 192);
            }
            AbrirFormulario();
        }
        private void AbrirFormulario()
        {
            PlDatos.Size = new Size(1233, 542);
            PlDatos.Visible = true;
            PlDatos.Location = new Point(TLPPlTolvas.Width / 2
                - PlDatos.Width / 2, TLPPlTolvas.Height / 2 - PlDatos.Height / 2);
            PlDatos.BringToFront();
            TLPPlTolvas.Enabled = false;
        }

        private void btnV1_Click(object sender, EventArgs e)
        {
            if (lblV1.Text != "--")
            {
                CargaVer(lblV1);
            }
            else
            {
                MessageBox.Show("Vertical Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PlDatos.Visible=false;
            }
        }

        private void Limpiar()
        {
            throw new NotImplementedException();
        }

        private void btnV2_Click(object sender, EventArgs e)
        {
            if (lblV2.Text != "--")
            {
                CargaVer(lblV2);
            }
            else
            {
                MessageBox.Show("Vertical Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PlDatos.Visible = false;
            }
        }

        private void btnV3_Click(object sender, EventArgs e)
        {
            if (lblV3.Text != "--")
            {
                CargaVer(lblV3);
            }
            else
            {
                MessageBox.Show("Vertical Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PlDatos.Visible = false;
            }
        }

        private void btnV4_Click(object sender, EventArgs e)
        {
            if (lblV4.Text != "--")
            {
                CargaVer(lblV4);
            }
            else
            {
                MessageBox.Show("Vertical Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PlDatos.Visible = false;
            }
        }

        private void btnV5_Click(object sender, EventArgs e)
        {
            if (lblV5.Text != "--")
            {
                CargaVer(lblV5);
            }
            else
            {
                MessageBox.Show("Vertical Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PlDatos.Visible = false;
            }
        }

        private void btnV6_Click(object sender, EventArgs e)
        {
            if (lblV6.Text != "--")
            {
                CargaVer(lblV6);
            }
            else
            {
                MessageBox.Show("Vertical Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PlDatos.Visible = false;
            }
        }

        private void btnV7_Click(object sender, EventArgs e)
        {
            if (lblV7.Text != "--")
            {
                CargaVer(lblV7);
            }
            else
            {
                MessageBox.Show("Vertical Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PlDatos.Visible = false;
            }
        }

        private void btnV8_Click(object sender, EventArgs e)
        {
            if (lblV8.Text != "--")
            {
                CargaVer(lblV8);
            }
            else
            {
                MessageBox.Show("Vertical Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PlDatos.Visible = false;
            }
        }
    }
}
