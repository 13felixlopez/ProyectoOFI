using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoOFI.SM
{
    public partial class POASF : UserControl
    {
        int IdPOA;
        string Modulo;
        public POASF()
        {
            InitializeComponent();
            ValidarPermisos();
        }
        private void POASF_Load(object sender, EventArgs e)
        {
            MostrarPOALabels();
            Estilo();
        }
        private void MostrarPOALabels()
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
            GbDescarga.Visible = false;
        }
        private void MostrarDatos(Label POA)
        {
            try
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
                IdPOA = int.Parse(dt.Rows[0]["IdPOA"].ToString());
                btnGuardarPOA.Visible = false;
                btnDescargarPOA.Visible = true;
                DtHoraInPOA.Enabled = false;
                DtHoraFinPOA.Enabled = false;
                txtHumedadPOA.Enabled = false;
                cbOperadorPOA.Enabled = false;
                cbTurnoPOA.Enabled = false;
                dtFechaPOA.Enabled = false;
                Capacidad();
                AbrirFormulario();
            }
            catch (Exception)
            {

                throw;
            }
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
            TiempoDp();
        }

        private void TiempoDp()
        {
            DtPFDes1.Value = dtFechaPOA.Value;
            DtHInicio1.Value = DtHoraFinPOA.Value;
            DtHoraFin1.Value = DtHInicio1.Value.AddMinutes(5);
        }

        private void btnP1_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "1";
            if (lblP1.Text != "--")
            {
                MostrarDatos(lblP1);
            }
            else
            {
                Limpiar();
                DSM DV = new DSM();
                DV.CargarTk(cbTicketP);
                CargarDatos();
            }
        }
        private void CargarDatos()
        {
            if (cbTicketP.SelectedValue != null)
            {
                AbrirFormulario();
                DSM sm = new DSM();
                sm.MostrarDatosTKSM(LblSacos, LblKilos, LblQQsV, LblCalidadV, LblDanioV, LblEFisicoV, LblFRecibido, LblCert, cbTicketP.Text);
                cbTicketP.Enabled = true;
                btnGuardarPOA.Visible = true;
                btnDescargarPOA.Visible = false;
                cbOperadorPOA.Enabled = true;
                cbTurnoPOA.Enabled = true;
                dtFechaPOA.Enabled = true;
                txtHumedadPOA.Enabled = true;
                DtHoraInPOA.Enabled = true;
                DtHoraFinPOA.Enabled = true;
                CargarCombos();
                Capacidad();
                double QQs = double.Parse(LblQQsV.Text);
                if (QQs > 331)
                {
                    DialogResult result = MessageBox.Show("El peso de este lote supera la capacidad de la maquina, ¿Quieres seguir con el proceso?", "Capacidad POA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        gbPOA.Enabled = true;
                    }
                    else
                    {
                        gbPOA.Enabled = false;
                    }
                }
                else
                {
                    gbPOA.Enabled = true;
                }
            }
            else
            {
                Limpiar();
            }

        }
        private void CargarCombos()
        {
            DSM sm = new DSM();
            sm.MostrarOperador(cbOperadorPOA);
            sm.MostrarOperador(CbOperadores);
        }
        private void Limpiar()
        {
            LblSacos.Text = "--";
            LblKilos.Text = "--";
            LblQQsV.Text = "--";
            LblCalidadV.Text = "--";
            LblDanioV.Text = "--";
            LblEFisicoV.Text = "--";
            cbOperadorPOA.Text = "";
            txtHumedadPOA.Clear();
            TxtGuariola.Clear();
            DtPFDes1.Value = DateTime.Today;
            DtHInicio1.Value = DateTime.Today;
            DtHoraFin1.Value = DateTime.Today;
            LblDuracionG.Text = "--";
            TxtHumedad.Clear();
        }

        private void btnP2_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "2";
            if (lblP2.Text != "--")
            {
                MostrarDatos(lblP2);
            }
            else
            {
                Limpiar();
                DSM DV = new DSM();
                DV.CargarTk(cbTicketP);
                CargarDatos();
            }
        }

        private void btnP3_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "3";
            if (lblP3.Text != "--")
            {
                MostrarDatos(lblP3);
            }
            else
            {
                Limpiar();
                DSM DV = new DSM();
                DV.CargarTk(cbTicketP);
                CargarDatos();
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
            else
            {
                Limpiar();
                DSM DV = new DSM();
                DV.CargarTk(cbTicketP);
                CargarDatos();
            }
        }

        private void btnP6_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "6";
            if (lblP6.Text != "--")
            {
                MostrarDatos(lblP6);
            }
            else
            {
                Limpiar();
                DSM DV = new DSM();
                DV.CargarTk(cbTicketP);
                CargarDatos();
            }
        }

        private void btnP7_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "7";
            if (lblP7.Text != "--")
            {
                MostrarDatos(lblP7);
            }
            else
            {
                Limpiar();
                DSM DV = new DSM();
                DV.CargarTk(cbTicketP);
                CargarDatos();
            }
        }

        private void btnP8_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "8";
            if (lblP8.Text != "--")
            {
                MostrarDatos(lblP8);
            }
            else
            {
                Limpiar();
                DSM DV = new DSM();
                DV.CargarTk(cbTicketP);
                CargarDatos();
            }
        }

        private void btnP9_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "9";
            if (lblP9.Text != "--")
            {
                MostrarDatos(lblP9);
            }
            else
            {
                Limpiar();
                DSM DV = new DSM();
                DV.CargarTk(cbTicketP);
                CargarDatos();
            }
        }

        private void btnP10_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "10";
            if (lblP10.Text != "--")
            {
                MostrarDatos(lblP10);
            }
            else
            {
                Limpiar();
                DSM DV = new DSM();
                DV.CargarTk(cbTicketP);
                CargarDatos();
            }
        }

        private void btnP11_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "11";
            if (lblP11.Text != "--")
            {
                MostrarDatos(lblP11);
            }
            else
            {
                Limpiar();
                DSM DV = new DSM();
                DV.CargarTk(cbTicketP);
                CargarDatos();
            }
        }

        private void btnP12_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "12";
            if (lblP12.Text != "--")
            {
                MostrarDatos(lblP12);
            }
            else
            {
                Limpiar();
                DSM DV = new DSM();
                DV.CargarTk(cbTicketP);
                CargarDatos();
            }
        }

        private void btnP13_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "13";
            if (lblP13.Text != "--")
            {
                MostrarDatos(lblP13);
            }
            else
            {
                Limpiar();
                DSM DV = new DSM();
                DV.CargarTk(cbTicketP);
                CargarDatos();
            }
        }

        private void btnP14_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "14";
            if (lblP14.Text != "--")
            {
                MostrarDatos(lblP14);
            }
            else
            {
                Limpiar();
                DSM DV = new DSM();
                DV.CargarTk(cbTicketP);
                CargarDatos();
            }
        }

        private void btnP15_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "15";
            if (lblP15.Text != "--")
            {
                MostrarDatos(lblP15);
            }
            else
            {
                Limpiar();
                DSM DV = new DSM();
                DV.CargarTk(cbTicketP);
                CargarDatos();
            }
        }

        private void btnP16_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "16";
            if (lblP16.Text != "--")
            {
                MostrarDatos(lblP16);
            }
            else
            {
                Limpiar();
                DSM DV = new DSM();
                DV.CargarTk(cbTicketP);
                CargarDatos();
            }
        }

        private void btnP17_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "17";
            if (lblP17.Text != "--")
            {
                MostrarDatos(lblP17);
            }
            else
            {
                Limpiar();
                DSM DV = new DSM();
                DV.CargarTk(cbTicketP);
                CargarDatos();
            }
        }

        private void btnP18_Click(object sender, EventArgs e)
        {
            txtTolvaPOA.Text = "18";
            if (lblP18.Text != "--")
            {
                MostrarDatos(lblP18);
            }
            else
            {
                Limpiar();
                DSM DV = new DSM();
                DV.CargarTk(cbTicketP);
                CargarDatos();
            }
        }

        private void cbTicketP_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnGuardarPOA_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                CargaDirectaSF();
            }
            else
            {
                MessageBox.Show("Existen campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Validar()
        {
            double entero;
            if (!double.TryParse(txtHumedadPOA.Text, out entero))
            {
                return false;
            }
            return !(txtTolvaPOA.Text == "" || txtHumedadPOA.Text == "" || cbOperadorPOA.Text == ""
                || cbTurnoPOA.Text == "");
        }

        private void CargaDirectaSF()
        {
            try
            {
                LVertical parametros = new LVertical();
                DPOA funcion = new DPOA();
                parametros.Ticket = cbTicketP.Text;
                parametros.FechaDes = dtFechaPOA.Value;
                parametros.HoradesIn = DtHoraInPOA.Value;
                parametros.HoraFin = DtHoraFinPOA.Value;
                parametros.Humedad = double.Parse(txtHumedadPOA.Text);
                //Paros();
                parametros.ProcesoSF = "POA";
                //parametros.OperadorV = int.Parse(cbOperadorPOA.SelectedValue.ToString());
                parametros.TurnoV = int.Parse(cbTurnoPOA.SelectedValue.ToString());
                parametros.POA1 = int.Parse(txtTolvaPOA.Text.Trim());
                //parametros.POA2 = int.Parse(CbPOA2.Text.Trim());
                parametros.DigitadorV = Login.NombreA;
                //parametros.IDV = "";
                if (funcion.CargaDirectaSF(parametros) == true)
                {
                    MessageBox.Show("Operación realizada con éxito", "Secado final", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    PlDatos.Visible = false;
                    TLPPOA.Enabled = true;
                    Limpiar();
                    MostrarPOALabels();
                    Estilo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar datos CargaDirectaSF " + ex.Message, "ERROR Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDescargarPOA_Click(object sender, EventArgs e)
        {
            GbDescarga.Visible = true;
            TxtGuariola.Text = txtTolvaPOA.Text;
            DPOAV funcion = new DPOAV();
            DSM sm = new DSM();
            funcion.MostrarTurno(CbTurno);
            sm.MostrarOperador(CbOperadores);
        }
        private void BtnSF_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtHumedad.Text))
            {
                MessageBox.Show("Existen campos vacíos", "Error al enviar datos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (ValidarTiempo())
            {
                InsertarGuardiola();
                MostrarPOALabels();
                Estilo();
                PlDatos.Visible = false;
                TLPPOA.Enabled = true;
                GbDescarga.Visible = false;
            }
        }

        private bool ValidarTiempo()
        {
            // Validar que LblDuracionG contenga un tiempo válido
            if (!TimeSpan.TryParse(LblDuracionG.Text, out TimeSpan Duracion))
            {
                MessageBox.Show("La duración no es un tiempo válido.", "Error en duración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar que la duración no sea negativa
            if (Duracion < TimeSpan.Zero)
            {
                MessageBox.Show("La duración no puede ser negativa.", "Error en duración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar que DtPFDes1 no sea menor que dtFechaPOA
            if (DtPFDes1.Value < dtFechaPOA.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser menor que la fecha de carga.", "Error en fecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar que DtHInicio1 no sea menor que DtHoraFinPOA
            if (DtHInicio1.Value < DtHoraFinPOA.Value)
            {
                MessageBox.Show("La hora de inicio no puede ser menor que la hora de fin de la carga.", "Error en hora", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Si todas las validaciones pasan, retornar true
            return true;
        }

        private void InsertarGuardiola()
        {
            try
            {
                LPOA parametros = new LPOA();
                DPOA funcion = new DPOA();
                parametros.Ticket = cbTicketP.Text;
                parametros.Guardiola = int.Parse(TxtGuariola.Text);
                parametros.IdTurno = int.Parse(CbTurno.SelectedValue.ToString());
                //parametros.IdOperador = int.Parse(CbOperadores.SelectedValue.ToString());
                parametros.FechaG = DateTime.Parse(DtPFDes1.Value.ToString());
                parametros.HoraIniG = DateTime.Parse(DtHInicio1.Value.ToString());
                parametros.HoraFinG = DateTime.Parse(DtHoraFin1.Value.ToString());
                parametros.Duracion = DateTime.Parse(LblDuracionG.Text);
                parametros.Humedad = double.Parse(TxtHumedad.Text);
                parametros.DigitadorG = Login.NombreA;
                parametros.IdPOA = IdPOA;
                if (funcion.InsertarGuardiola(parametros) == true)
                {
                    MessageBox.Show("Carga Guardiola realiza con éxito", "Guardiola Cargada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    int Poa = int.Parse(txtTolvaPOA.Text);
                    CambiarLblTK(Poa);
                    PlDatos.Visible = false;
                    TLPPOA.Enabled = true;
                    Limpiar();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al ejecutar CargaGuariola", "Error Interfaz", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CambiarLblTK(int poa)
        {
            string lblName = "lblP" + poa;
            System.Windows.Forms.Control[] controls = Controls.Find(lblName, true);
            if (controls.Length > 0 && controls[0] is Label)
            {
                // Muestra el ticket en el Label
                Label lblTicket = (Label)controls[0];
                lblTicket.Text = "--";
            }
        }
        private void DtHoraFin1_ValueChanged(object sender, EventArgs e)
        {
            DateTime inicio = DtHInicio1.Value;
            DateTime fin = DtHoraFin1.Value;

            // Calcular la duración restando los DateTime
            TimeSpan duracion = fin - inicio;
            string resultado = duracion.ToString(@"hh\:mm");
            // Mostrar la duración en el Label
            LblDuracionG.Text = resultado.ToString();
        }
        private void ValidarPermisos()
        {
            DataTable dt = new DataTable();
            DModulos funcion = new DModulos();
            LPermisos parametros = new LPermisos();
            parametros.IdUser = Login.Iduser;
            funcion.PermisosUser(ref dt, Login.Iduser);
            foreach (DataRow rowpermisos in dt.Rows)
            {
                Modulo = Convert.ToString(rowpermisos["Modulo"]);
                if (Modulo == "Particionar SM")
                {
                    TLPPOA.Enabled = true;
                }
            }
        }
    }
}
