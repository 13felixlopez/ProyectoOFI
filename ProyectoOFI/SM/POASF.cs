using ProyectoOFI.Datos;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoOFI.SM
{
    public partial class POASF : UserControl
    {
        public POASF()
        {
            InitializeComponent();
        }
        private void POASF_Load(object sender, EventArgs e)
        {
            MostrarVerticalLabels();
            Estilo();
        }
        private void MostrarVerticalLabels()
        {
            DPOA datos = new DPOA();
            DataTable tablaTickets = datos.MostrarPOA();
            foreach (DataRow fila in tablaTickets.Rows)
            {
                int POA = Convert.ToInt32(fila["POA"]);
                string ticket = fila["Ticket"].ToString();
                MostrarTicketEnLabel(POA, ticket);
            }
        }
        protected void MostrarTicketEnLabel(int POA, string ticket)
        {
            // Encuentra el Label correspondiente a la POAV
            string lblName = "lblP" + POA;
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
            #region POA1
            if (lblP1.Text == "--")
            {
                btnP1.BackColor = Color.FromArgb(r1, g1, b1);
                lblP1.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnP1.BackColor = Color.FromArgb(r, p, f);
                lblP1.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region POA2
            if (lblP2.Text == "--")
            {
                btnP2.BackColor = Color.FromArgb(r1, g1, b1);
                lblP2.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnP2.BackColor = Color.FromArgb(r, p, f);
                lblP2.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region POA3
            if (lblP3.Text == "--")
            {
                btnP3.BackColor = Color.FromArgb(r1, g1, b1);
                lblP3.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnP3.BackColor = Color.FromArgb(r, p, f);
                lblP3.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region POA4
            if (lblP4.Text == "--")
            {
                btnP4.BackColor = Color.FromArgb(r1, g1, b1);
                lblP4.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnP4.BackColor = Color.FromArgb(r, p, f);
                lblP4.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region POA5
            if (lblP5.Text == "--")
            {
                btnP5.BackColor = Color.FromArgb(r1, g1, b1);
                lblP5.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnP5.BackColor = Color.FromArgb(r, p, f);
                lblP5.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region POA6
            if (lblP6.Text == "--")
            {
                btnP6.BackColor = Color.FromArgb(r1, g1, b1);
                lblP6.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnP6.BackColor = Color.FromArgb(r, p, f);
                lblP6.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region POA7
            if (lblP7.Text == "--")
            {
                btnP7.BackColor = Color.FromArgb(r1, g1, b1);
                lblP7.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnP7.BackColor = Color.FromArgb(r, p, f);
                lblP7.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region POA8
            if (lblP8.Text == "--")
            {
                btnP8.BackColor = Color.FromArgb(r1, g1, b1);
                lblP8.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnP8.BackColor = Color.FromArgb(r, p, f);
                lblP8.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region POA9
            if (lblP9.Text == "--")
            {
                btnP9.BackColor = Color.FromArgb(r1, g1, b1);
                lblP9.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnP9.BackColor = Color.FromArgb(r, p, f);
                lblP9.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region POA10
            if (lblP10.Text == "--")
            {
                btnP10.BackColor = Color.FromArgb(r1, g1, b1);
                lblP10.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnP10.BackColor = Color.FromArgb(r, p, f);
                lblP10.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region POA11
            if (lblP11.Text == "--")
            {
                btnP11.BackColor = Color.FromArgb(r1, g1, b1);
                lblP11.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnP11.BackColor = Color.FromArgb(r, p, f);
                lblP11.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region POA12
            if (lblP12.Text == "--")
            {
                btnP12.BackColor = Color.FromArgb(r1, g1, b1);
                lblP12.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnP12.BackColor = Color.FromArgb(r, p, f);
                lblP12.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region POA13
            if (lblP13.Text == "--")
            {
                btnP13.BackColor = Color.FromArgb(r1, g1, b1);
                lblP13.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnP13.BackColor = Color.FromArgb(r, p, f);
                lblP13.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region POA14
            if (lblP14.Text == "--")
            {
                btnP14.BackColor = Color.FromArgb(r1, g1, b1);
                lblP14.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnP14.BackColor = Color.FromArgb(r, p, f);
                lblP14.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region POA15
            if (lblP15.Text == "--")
            {
                btnP15.BackColor = Color.FromArgb(r1, g1, b1);
                lblP15.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnP15.BackColor = Color.FromArgb(r, p, f);
                lblP15.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region POA16
            if (lblP16.Text == "--")
            {
                btnP16.BackColor = Color.FromArgb(r1, g1, b1);
                lblP16.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnP16.BackColor = Color.FromArgb(r, p, f);
                lblP16.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region POA17
            if (lblP17.Text == "--")
            {
                btnP17.BackColor = Color.FromArgb(r1, g1, b1);
                lblP17.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnP17.BackColor = Color.FromArgb(r, p, f);
                lblP17.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region POA18
            if (lblP18.Text == "--")
            {
                btnP18.BackColor = Color.FromArgb(r1, g1, b1);
                lblP18.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnP18.BackColor = Color.FromArgb(r, p, f);
                lblP18.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
        }

        private void BtnCerrarVerCons_Click(object sender, EventArgs e)
        {
            PlDatos.Visible = false;
            TLPPOA.Enabled = true;
        }
        private void MostrarDatos(Label POA)
        {
            DPOA DPOA = new DPOA();
            DataTable dt = new DataTable();
            DPOA.CargarPOA(POA.Text, dt);
            cbTicketP.Enabled = false;
            cbTicketP.Text = POA.Text;
            LblSacos.Text = dt.Rows[0]["Sacos"].ToString();
            LblKilos.Text = dt.Rows[0]["Peso"].ToString();
            double kilos = Convert.ToDouble(LblKilos.Text);
            kilos = kilos / 46;
            LblQQsV.Text = Math.Round(kilos, 2).ToString();
            LblCalidadV.Text = dt.Rows[0]["Calidad"].ToString();
            LblDanioV.Text = dt.Rows[0]["Danio"].ToString();
            LblEFisicoV.Text = dt.Rows[0]["EstFisico"].ToString();
            LblCert.Text = dt.Rows[0]["Certificacion"].ToString();
            txtTolvaPOA.Text = dt.Rows[0]["POA"].ToString();
            cbOperadorPOA.Text = dt.Rows[0]["Nombre"].ToString();
            cbTurnoPOA.Text = dt.Rows[0]["TurnoPOA"].ToString();
            dtFechaPOA.Text = dt.Rows[0]["FechaDes"].ToString();
            DtHoraInPOA.Text = dt.Rows[0]["HoradesIn"].ToString();
            DtHoraFinPOA.Text = dt.Rows[0]["HoraFin"].ToString();
            txtHumedadPOA.Text = dt.Rows[0]["Humedad"].ToString();
            btnGuardarPOA.Visible = false;
            btnDescargarPOA.Visible = true;
            Capacidad();
            AbrirFormulario();
        }
        private void Capacidad()
        {
            double capacidad;
            double QQs = double.Parse(LblQQsV.Text);
            if (QQs > 331)
            {
                capacidad = (QQs / 600) * 100;
                capacidad = Math.Round(capacidad, 2);
                LblCapacidad.Text = capacidad.ToString() + " %";
            }
            else
            {
                capacidad = (QQs / 300) * 100;
                capacidad = Math.Round(capacidad, 2);
                LblCapacidad.Text = capacidad.ToString() + " %";
            }
            //if (capacidad >= 100)
            //{
            //    gbDatos.BackColor = Color.FromArgb(255, 150, 136);
            //}
            //else if (capacidad <= 50)
            //{
            //    gbDatos.BackColor = Color.FromArgb(244, 250, 180);
            //}
            //else
            //{
            //    gbDatos.BackColor = Color.White;
            //}
        }

        private void AbrirFormulario()
        {
            PlDatos.Size = new Size(1354, 517);
            PlDatos.Visible = true;
            PlDatos.Location = new Point(TLPPOA.Width / 2
                - PlDatos.Width / 2, TLPPOA.Height / 2 - PlDatos.Height / 2);
            PlDatos.BringToFront();
            DPOAV funcion = new DPOAV();
            funcion.MostrarTurno(cbTurnoPOA);
            TLPPOA.Enabled = false;
        }

        private void btnP1_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "1";
            if (lblP1.Text != "--")
            {
                MostrarDatos(lblP1);
            }
            //else
            //{
            //    Limpiar();
            //    DSM DV = new DSM();
            //    DV.CargarTk(cbTicketV);
            //    CargarDatos();
            //}
        }

        private void btnP2_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "2";
            if (lblP2.Text != "--")
            {
                MostrarDatos(lblP2);
            }
        }

        private void btnP3_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "3";
            if (lblP3.Text != "--")
            {
                MostrarDatos(lblP3);
            }
        }

        private void btnP4_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "4";
            if (lblP4.Text != "--")
            {
                MostrarDatos(lblP4);
            }
        }

        private void btnP5_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "5";
            if (lblP5.Text != "--")
            {
                MostrarDatos(lblP5);
            }
        }

        private void btnP6_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "6";
            if (lblP6.Text != "--")
            {
                MostrarDatos(lblP6);
            }
        }

        private void btnP7_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "7";
            if (lblP7.Text != "--")
            {
                MostrarDatos(lblP7);
            }
        }

        private void btnP8_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "8";
            if (lblP8.Text != "--")
            {
                MostrarDatos(lblP8);
            }
        }

        private void btnP9_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "9";
            if (lblP9.Text != "--")
            {
                MostrarDatos(lblP9);
            }
        }

        private void btnP10_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "10";
            if (lblP10.Text != "--")
            {
                MostrarDatos(lblP10);
            }
        }

        private void btnP11_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "11";
            if (lblP11.Text != "--")
            {
                MostrarDatos(lblP11);
            }
        }

        private void btnP12_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "12";
            if (lblP12.Text != "--")
            {
                MostrarDatos(lblP12);
            }
        }

        private void btnP13_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "13";
            if (lblP13.Text != "--")
            {
                MostrarDatos(lblP13);
            }
        }

        private void btnP14_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "14";
            if (lblP14.Text != "--")
            {
                MostrarDatos(lblP14);
            }
        }

        private void btnP15_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "15";
            if (lblP15.Text != "--")
            {
                MostrarDatos(lblP15);
            }
        }

        private void btnP16_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "16";
            if (lblP16.Text != "--")
            {
                MostrarDatos(lblP16);
            }
        }

        private void btnP17_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "17";
            if (lblP17.Text != "--")
            {
                MostrarDatos(lblP17);
            }
        }

        private void btnP18_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "18";
            if (lblP18.Text != "--")
            {
                MostrarDatos(lblP18);
            }
        }
    }
}
