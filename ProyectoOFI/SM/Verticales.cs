using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoOFI.SM
{
    public partial class Verticales : UserControl
    {
        string Observacion = "";
        int IDV;
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
            GbSF.Visible = false;
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
            IDV = int.Parse(dt.Rows[0]["IDV"].ToString());
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
            PlDatos.Size = new Size(1398, 619);
            PlDatos.Visible = true;
            PlDatos.Location = new Point(TLPPlTolvas.Width / 2
                - PlDatos.Width / 2, TLPPlTolvas.Height / 2 - PlDatos.Height / 2);
            PlDatos.BringToFront();
            TLPPlTolvas.Enabled = false;
            DPOAV funcion = new DPOAV();
            funcion.MostrarTurno(CbTurno);
            DSM fun = new DSM();
            fun.MostrarOperador(CbOperadores);
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
                PlDatos.Visible = false;
            }
        }

        private void Limpiar()
        {
            CbPOA1.Text = "1";
            CbPOA2.Text = "2";
            DtPFDes1.Value = DateTime.Now;
            DtPFDes2.Value = DateTime.Now;
            DtHInicio1.Value = DateTime.Now;
            DtHInicio2.Value = DateTime.Now;
            DtHoraFin1.Value = DateTime.Now;
            DtHoraFin2.Value = DateTime.Now;
            TxtHumedad.Clear();
            TxtParos.Text = "0";
            LblTiempoPre.Text = "--";
            for (int i = 0; i < CHParos.Items.Count; i++)
            {
                CHParos.SetItemChecked(i, false);
            }
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

        private void BtnEnviarSF_Click(object sender, EventArgs e)
        {
            GbSF.Visible = true;
            DVerticales funcion = new DVerticales();
            funcion.MostrarParos(CHParos);
        }

        private void BtnSF_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                InsertarPreSecado();
            }
            else
            {
                MessageBox.Show("Existen campos vacios","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InsertarPreSecado()
        {
            try
            {
                LVertical parametros = new LVertical();
                DVerticales funcion = new DVerticales();
                parametros.Ticket = LblTicket.Text;
                parametros.FechaDes = DtPFDes1.Value;
                parametros.HoradesIn = DtHInicio1.Value;
                parametros.HoraFin = DtHInicio2.Value;
                parametros.Humedad = double.Parse(TxtHumedad.Text);
                parametros.Paros = double.Parse(TxtParos.Text);
                Paros();
                parametros.Observacion = Observacion;
                parametros.Total = DateTime.Parse(LblTiempoPre.Text);
                parametros.ProcesoSF = "POA";
                parametros.OperadorV = int.Parse(CbOperadores.SelectedValue.ToString());
                parametros.TurnoV = int.Parse(CbTurno.SelectedValue.ToString());
                parametros.POA1 = int.Parse(CbPOA1.Text.Trim());
                parametros.POA2 = int.Parse(CbPOA2.Text.Trim());
                parametros.DigitadorV = Login.NombreA;
                parametros.IDV = IDV;
                if (funcion.InsertarPreSecado(parametros) == true)
                {
                    MessageBox.Show("Operación realizada con éxito", "Secado final", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    PlDatos.Visible = false;
                    TLPPlTolvas.Enabled = true;
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar datos Pre-Secado " + ex.Message, "ERROR Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Paros()
        {
            foreach (var item in CHParos.CheckedItems)
            {
                Observacion += item.ToString() + ", ";
            }

            //// Quitar la coma adicional al final si hay elementos seleccionados
            //if (!string.IsNullOrEmpty(Observacion))
            //{
            //    Observacion = Observacion.TrimEnd(',', ' ');
            //}
        }
        private bool Validar()
        {
            double entero;
            if (!double.TryParse(TxtParos.Text, out entero) || !double.TryParse(TxtHumedad.Text, out entero))
            {
                return false;
            }
            return !(CbPOA1.Text == "" || CbPOA2.Text == "" || TxtHumedad.Text == "" || TxtParos.Text == "" || CbOperadores.Text == ""
                || CbTurno.Text == "");
        }

        private void TxtParos_TextChanged(object sender, EventArgs e)
        {
            // Obtener el valor de Txtparos y convertirlo a un TimeSpan
            TimeSpan paros;
            if (!TimeSpan.TryParse(TxtParos.Text, out paros))
            {
                // Manejar el caso en que el valor ingresado en Txtparos no sea válido
                MessageBox.Show("El valor ingresado en Txtparos no es válido.");
                return;
            }

            // Calcular el tiempo total y restarle el tiempo de paros
            DateTime FInicio, FechaFin, HoraInicio, HoraFin;
            FInicio = dtFProcV.Value;
            FechaFin = DtPFDes1.Value;
            HoraInicio = dtHorainicioV.Value;
            HoraFin = DtHoraFin2.Value;

            TimeSpan tiempoTotal = (FechaFin.Date + HoraFin.TimeOfDay) - (FInicio.Date + HoraInicio.TimeOfDay);
            tiempoTotal -= paros;

            // Convertir el resultado a formato HH:MM y mostrarlo
            string resultado = tiempoTotal.ToString(@"hh\:mm");
            LblTiempoPre.Text = resultado;

        }
    }
}
