using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProyectoOFI.SM
{
    public partial class PS : UserControl
    {
        int IdPS;
        public PS()
        {
            InitializeComponent();
        }

        private void PS_Load(object sender, EventArgs e)
        {
            MostrarTicketsEnLabels();
            Estilo();
        }
        protected void MostrarTicketsEnLabels()
        {
            DPS datos = new DPS();
            DataTable tablaTickets = datos.MostrarPS();
            foreach (DataRow fila in tablaTickets.Rows)
            {
                int ps = Convert.ToInt32(fila["PS"]);
                string ticket = fila["Ticket"].ToString();
                MostrarTicketEnLabel(ps, ticket);
            }
        }
        protected void MostrarTicketEnLabel(int ps, string ticket)
        {
            // Encuentra el Label correspondiente a la PS
            string lblName = "LblPS" + ps;
            System.Windows.Forms.Control[] controls = Controls.Find(lblName, true);
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
            #region PS1
            if (LblPS1.Text == "--")
            {
                BtnPS1.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS1.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS1.BackColor = Color.FromArgb(r, p, f);
                LblPS1.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region PS2
            if (LblPS2.Text == "--")
            {
                BtnPS2.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS2.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS2.BackColor = Color.FromArgb(r, p, f);
                LblPS2.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region PS3
            if (LblPS3.Text == "--")
            {
                BtnPS3.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS3.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS3.BackColor = Color.FromArgb(r, p, f);
                LblPS3.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region PS4
            if (LblPS4.Text == "--")
            {
                BtnPS4.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS4.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS4.BackColor = Color.FromArgb(r, p, f);
                LblPS4.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region PS5
            if (LblPS5.Text == "--")
            {
                BtnPS5.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS5.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS5.BackColor = Color.FromArgb(r, p, f);
                LblPS5.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region PS6
            if (LblPS6.Text == "--")
            {
                BtnPS6.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS6.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS6.BackColor = Color.FromArgb(r, p, f);
                LblPS6.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region PS7
            if (LblPS7.Text == "--")
            {
                BtnPS7.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS7.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS7.BackColor = Color.FromArgb(r, p, f);
                LblPS7.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region PS8
            if (LblPS8.Text == "--")
            {
                BtnPS8.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS8.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS8.BackColor = Color.FromArgb(r, p, f);
                LblPS8.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region PS9
            if (LblPS9.Text == "--")
            {
                BtnPS9.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS9.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS9.BackColor = Color.FromArgb(r, p, f);
                LblPS9.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region PS10
            if (LblPS10.Text == "--")
            {
                BtnPS10.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS10.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS10.BackColor = Color.FromArgb(r, p, f);
                LblPS10.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region PS11
            if (LblPS11.Text == "--")
            {
                BtnPS11.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS11.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS11.BackColor = Color.FromArgb(r, p, f);
                LblPS11.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region PS12
            if (LblPS12.Text == "--")
            {
                BtnPS12.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS12.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS12.BackColor = Color.FromArgb(r, p, f);
                LblPS12.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region PS13
            if (LblPS13.Text == "--")
            {
                BtnPS13.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS13.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS13.BackColor = Color.FromArgb(r, p, f);
                LblPS13.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region PS14
            if (LblPS14.Text == "--")
            {
                BtnPS14.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS14.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS14.BackColor = Color.FromArgb(r, p, f);
                LblPS14.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region PS15
            if (LblPS15.Text == "--")
            {
                BtnPS15.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS15.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS15.BackColor = Color.FromArgb(r, p, f);
                LblPS15.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region PS16
            if (LblPS16.Text == "--")
            {
                BtnPS16.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS16.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS16.BackColor = Color.FromArgb(r, p, f);
                LblPS16.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region PS17
            if (LblPS17.Text == "--")
            {
                BtnPS17.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS17.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS17.BackColor = Color.FromArgb(r, p, f);
                LblPS17.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
            #region PS18
            if (LblPS18.Text == "--")
            {
                BtnPS18.BackColor = Color.FromArgb(r1, g1, b1);
                LblPS18.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                BtnPS18.BackColor = Color.FromArgb(r, p, f);
                LblPS18.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
        }
        private void BtnCerrarPlDatos_Click(object sender, EventArgs e)
        {
            PlDatos.Visible = false;
            GbEnvio.Visible = false;
            TLPPS.Enabled = true;
        }
        private void BtnPS_Click(object sender, EventArgs e)
        {
            GbEnvio.Visible = true;
            DSM funcion = new DSM();
            funcion.MostrarOperador(CbOperadoresEn);
            funcion.MostrarTurno(CbTurnoEn);
            DPS dPS = new DPS();
            dPS.MostrarAreaSecado(CbDestino);
            dPS.MostrarEstFis(CbEstFis);
        }
        private void CargarPS(Label lblG)
        {
            try
            {

                DPS funcion = new DPS();
                DataTable dt = new DataTable();
                funcion.CargarPS(lblG.Text, dt);
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
                //Datos de PS
                LblPS.Text = dt.Rows[0]["PS"].ToString();
                LblOperador.Text = dt.Rows[0]["Nombre"].ToString();
                LblTurno.Text = dt.Rows[0]["Turno"].ToString();
                DateTime Fecha = DateTime.Parse(dt.Rows[0]["FechaDes"].ToString());
                LblFDesPS.Text = Fecha.ToShortDateString();
                LblParos.Text = dt.Rows[0]["ParosSF"].ToString();
                LblHumedad.Text = dt.Rows[0]["Humedad"].ToString() + " %";
                IdPS = int.Parse(dt.Rows[0]["IdPS"].ToString());
                TimeSpan Horai = (TimeSpan)dt.Rows[0]["HoraFinDes"];
                string duracionFormateada = $"{Horai.Hours:D2}:{Horai.Minutes:D2}";
                LblHrFinPS.Text = duracionFormateada;
                TimeSpan HoraF = (TimeSpan)dt.Rows[0]["HoraInDes"];
                string HoraFormateada = $"{HoraF.Hours:D2}:{HoraF.Minutes:D2}";
                LblHrInPS.Text = HoraFormateada;
                //Conversion de Tiempo Secado Final a Horas
                if (dt.Rows[0]["TiempoSF"] != DBNull.Value)
                {
                    string TiempoSF = dt.Rows[0]["TiempoSF"].ToString();

                    // Regex para extraer días, horas y minutos
                    Regex regex = new Regex(@"(?:(\d+)\s*días?)?\s*(?:(\d+)\s*horas?)?\s*(?:(\d+)\s*minutos?)?");
                    Match match = regex.Match(TiempoSF);

                    if (match.Success)
                    {
                        int dias = match.Groups[1].Value != "" ? int.Parse(match.Groups[1].Value) : 0;
                        int horas = match.Groups[2].Value != "" ? int.Parse(match.Groups[2].Value) : 0;
                        int minutos = match.Groups[3].Value != "" ? int.Parse(match.Groups[3].Value) : 0;

                        // Calcular el total de horas
                        int totalHoras = (dias * 24) + horas;

                        // Formatear el resultado en "HH:mm"
                        string resultado = $"{totalHoras:D2}:{minutos:D2}";

                        // Mostrar el resultado en una etiqueta
                        LblTiempoSF.Text = resultado;
                    }
                    else
                    {
                        LblTiempoSF.Text = "--";
                    }
                }
                else
                {
                    LblTiempoSF.Text = "--";
                }

                // LblTiempoSF.Text = dt.Rows[0]["TiempoSF"].ToString();

                //Conversion de Tiempo total a Horas
                if (dt.Rows[0]["TiempoTotal"] != DBNull.Value)
                {
                    string TiempoTotal = dt.Rows[0]["TiempoTotal"].ToString();

                    // Regex para extraer días, horas y minutos
                    Regex regex = new Regex(@"(?:(\d+)\s*días?)?\s*(?:(\d+)\s*horas?)?\s*(?:(\d+)\s*minutos?)?");
                    Match match = regex.Match(TiempoTotal);

                    if (match.Success)
                    {
                        int dias = match.Groups[1].Value != "" ? int.Parse(match.Groups[1].Value) : 0;
                        int horas = match.Groups[2].Value != "" ? int.Parse(match.Groups[2].Value) : 0;
                        int minutos = match.Groups[3].Value != "" ? int.Parse(match.Groups[3].Value) : 0;

                        // Calcular el total de horas
                        int totalHoras = (dias * 24) + horas;

                        // Formatear el resultado en "HH:mm"
                        string resultado = $"{totalHoras:D2}:{minutos:D2}";

                        // Mostrar el resultado en una etiqueta
                        LblTotalTime.Text = resultado;
                    }
                    else
                    {
                        LblTotalTime.Text = "--";
                    }
                }
                else
                {
                    LblTotalTime.Text = "--";
                }

                //LblTotalTime.Text = dt.Rows[0]["TiempoTotal"].ToString();
                txtObservacion.Text = dt.Rows[0]["Observacion"].ToString();
                AbrirFormulario();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void AbrirFormulario()
        {
            PlDatos.Size = new Size(1398, 619);
            PlDatos.Visible = true;
            PlDatos.Location = new Point(TLPPS.Width / 2
                - PlDatos.Width / 2, TLPPS.Height / 2 - PlDatos.Height / 2);
            PlDatos.BringToFront();
            TLPPS.Enabled = false;
        }
        #region Botones
        private void BtnPS1_Click(object sender, EventArgs e)
        {
            if (LblPS1.Text != "--")
            {
                CargarPS(LblPS1);
            }
            else
            {
                MessageBox.Show("PS Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnPS2_Click(object sender, EventArgs e)
        {
            if (LblPS2.Text != "--")
            {
                CargarPS(LblPS2);
            }
            else
            {
                MessageBox.Show("PS Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnPS3_Click(object sender, EventArgs e)
        {
            if (LblPS3.Text != "--")
            {
                CargarPS(LblPS3);
            }
            else
            {
                MessageBox.Show("PS Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnPS4_Click(object sender, EventArgs e)
        {
            if (LblPS4.Text != "--")
            {
                CargarPS(LblPS4);
            }
            else
            {
                MessageBox.Show("PS Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnPS5_Click(object sender, EventArgs e)
        {
            if (LblPS5.Text != "--")
            {
                CargarPS(LblPS5);
            }
            else
            {
                MessageBox.Show("PS Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnPS6_Click(object sender, EventArgs e)
        {
            if (LblPS6.Text != "--")
            {
                CargarPS(LblPS6);
            }
            else
            {
                MessageBox.Show("PS Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnPS7_Click(object sender, EventArgs e)
        {
            if (LblPS7.Text != "--")
            {
                CargarPS(LblPS7);
            }
            else
            {
                MessageBox.Show("PS Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnPS8_Click(object sender, EventArgs e)
        {
            if (LblPS8.Text != "--")
            {
                CargarPS(LblPS8);
            }
            else
            {
                MessageBox.Show("PS Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnPS9_Click(object sender, EventArgs e)
        {
            if (LblPS9.Text != "--")
            {
                CargarPS(LblPS9);
            }
            else
            {
                MessageBox.Show("PS Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnPS10_Click(object sender, EventArgs e)
        {
            if (LblPS10.Text != "--")
            {
                CargarPS(LblPS10);
            }
            else
            {
                MessageBox.Show("PS Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnPS11_Click(object sender, EventArgs e)
        {
            if (LblPS11.Text != "--")
            {
                CargarPS(LblPS11);
            }
            else
            {
                MessageBox.Show("PS Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnPS12_Click(object sender, EventArgs e)
        {
            if (LblPS12.Text != "--")
            {
                CargarPS(LblPS12);
            }
            else
            {
                MessageBox.Show("PS Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnPS13_Click(object sender, EventArgs e)
        {
            if (LblPS13.Text != "--")
            {
                CargarPS(LblPS13);
            }
            else
            {
                MessageBox.Show("PS Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnPS14_Click(object sender, EventArgs e)
        {
            if (LblPS14.Text != "--")
            {
                CargarPS(LblPS14);
            }
            else
            {
                MessageBox.Show("PS Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnPS15_Click(object sender, EventArgs e)
        {
            if (LblPS15.Text != "--")
            {
                CargarPS(LblPS15);
            }
            else
            {
                MessageBox.Show("PS Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnPS16_Click(object sender, EventArgs e)
        {
            if (LblPS16.Text != "--")
            {
                CargarPS(LblPS16);
            }
            else
            {
                MessageBox.Show("PS Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnPS17_Click(object sender, EventArgs e)
        {
            if (LblPS17.Text != "--")
            {
                CargarPS(LblPS17);
            }
            else
            {
                MessageBox.Show("PS Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnPS18_Click(object sender, EventArgs e)
        {
            if (LblPS18.Text != "--")
            {
                CargarPS(LblPS18);
            }
            else
            {
                MessageBox.Show("PS Vacia", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        private void InsertarEnvioSM()
        {
            try
            {
                LPS parametros = new LPS();
                DPS funcion = new DPS();
                parametros.IdPS = IdPS;
                parametros.FechaPS = DtPFEnvio.Value;
                parametros.IdOperador = (int)CbOperadoresEn.SelectedValue;
                parametros.IdTurno = (int)CbTurnoEn.SelectedValue;
                parametros.DNIN = TxtDNIN.Text;
                parametros.IdArea = (int)CbDestino.SelectedValue;
                parametros.IdEstFis = (int)CbEstFis.SelectedValue;
                parametros.DigitadorPS = Login.NombreA;
                if (funcion.InsertarEnvioSM(parametros, IdPS) == true)
                {
                    GbEnvio.Visible = false;
                    PlDatos.Visible = false;
                    TxtDNIN.Clear();
                    MessageBox.Show("Envio realizado con éxito", "Envio a almacén", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarTicketsEnLabels();
                    Estilo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar datos Pre-Secado " + ex.Message, "ERROR Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtDNIN.Text))
            {
                InsertarEnvioSM();
            }
            else
            {
                MessageBox.Show("Existen campos vacios", "Error en datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
