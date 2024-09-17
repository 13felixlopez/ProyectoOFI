using DocumentFormat.OpenXml.Presentation;
using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoOFI.SM
{
    public partial class TolvasVerticales : UserControl
    {
        string Sacos, Kilos, Calidad, Daño, EsFisico, Modulo;
        public TolvasVerticales()
        {
            InitializeComponent();
            ValidarPermisos();
        }
        private void TolvasVerticales_Load(object sender, EventArgs e)
        {
            MostrarTicketsEnLabels();
            Estilo();
        }

        protected void MostrarTicketsEnLabels()
        {
            DSM datos = new DSM();
            DataTable tablaTickets = datos.MostrarTV();
            foreach (DataRow fila in tablaTickets.Rows)
            {
                int poav = Convert.ToInt32(fila["POAV"]);
                string ticket = fila["Ticket"].ToString();
                MostrarTicketEnLabel(poav, ticket);
            }
        }

        protected void MostrarTicketEnLabel(int poav, string ticket)
        {
            // Encuentra el Label correspondiente a la POAV
            string lblName = "lblTV" + poav;
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
            #region TV1
            if (lblTV1.Text == "--")
            {
                btnTV1.BackColor = Color.FromArgb(r1, g1, b1);
                lblTV1.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnTV1.BackColor = Color.FromArgb(r, p, f);
                lblTV1.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion

            #region Vertical2
            if (lblTV2.Text == "--")
            {
                btnTV2.BackColor = Color.FromArgb(r1, g1, b1);
                lblTV2.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnTV2.BackColor = Color.FromArgb(r, p, f);
                lblTV2.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion

            #region Vertical3
            if (lblTV3.Text == "--")
            {
                btnTV3.BackColor = Color.FromArgb(r1, g1, b1);
                lblTV3.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnTV3.BackColor = Color.FromArgb(r, p, f);
                lblTV3.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion

            #region Verical4
            if (lblTV4.Text == "--")
            {
                btnTV4.BackColor = Color.FromArgb(r1, g1, b1);
                lblTV4.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnTV4.BackColor = Color.FromArgb(r, p, f);
                lblTV4.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion

            #region Vertical5
            if (lblTV5.Text == "--")
            {
                btnTV5.BackColor = Color.FromArgb(r1, g1, b1);
                lblTV5.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnTV5.BackColor = Color.FromArgb(r, p, f);
                lblTV5.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion

            #region Vertical6
            if (lblTV6.Text == "--")
            {
                btnTV6.BackColor = Color.FromArgb(r1, g1, b1);
                lblTV6.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnTV6.BackColor = Color.FromArgb(r, p, f);
                lblTV6.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion

            #region Vertical7
            if (lblTV7.Text == "--")
            {
                btnTV7.BackColor = Color.FromArgb(r1, g1, b1);
                lblTV7.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnTV7.BackColor = Color.FromArgb(r, p, f);
                lblTV7.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion

            #region Vertical8
            if (lblTV8.Text == "--")
            {
                btnTV8.BackColor = Color.FromArgb(r1, g1, b1);
                lblTV8.BackColor = Color.FromArgb(r1, g1, b1);
            }
            else
            {
                btnTV8.BackColor = Color.FromArgb(r, p, f);
                lblTV8.BackColor = Color.FromArgb(r, p, f);
            }
            #endregion
        }

        private void btnTV2_Click(object sender, EventArgs e)
        {

            //PLDatos.Dock = DockStyle.Fill;
            txtTolvaV.Text = "2";
            if (lblTV2.Text != "--")
            {
                CargaTV(lblTV2);
            }
            else
            {
                Limpiar();
                DSM DV = new DSM();
                DV.CargarTk(cbTicketV);
                CargarDatos();
            }
        }

        private void btnTV1_Click(object sender, EventArgs e)
        {

            //PLDatos.Dock = DockStyle.Fill;
            txtTolvaV.Text = "1";
            if (lblTV1.Text != "--")
            {
                CargaTV(lblTV1);
            }
            else
            {
                Limpiar();
                DSM DV = new DSM();
                DV.CargarTk(cbTicketV);
                CargarDatos();
            }
        }
        private void AbrirFormulario()
        {
            PLDatos.Size = new Size(1233, 542);
            PLDatos.Visible = true;
            PLDatos.Location = new Point(TLPPlTolvas.Width / 2
                - PLDatos.Width / 2, TLPPlTolvas.Height / 2 - PLDatos.Height / 2);
            PLDatos.BringToFront();
            DPOAV funcion = new DPOAV();
            funcion.MostrarTurno(cbTurnoPV);
            TLPPlTolvas.Enabled = false;
        }
        private void btnTV3_Click(object sender, EventArgs e)
        {

            //PLDatos.Dock = DockStyle.Fill;
            txtTolvaV.Text = "3";
            if (lblTV3.Text != "--")
            {
                CargaTV(lblTV3);
            }
            else
            {
                Limpiar();
                DSM DV = new DSM();
                DV.CargarTk(cbTicketV);
                CargarDatos();
            }
        }

        private void btnTV4_Click(object sender, EventArgs e)
        {

            //PLDatos.Dock = DockStyle.Fill;
            txtTolvaV.Text = "4";
            if (lblTV4.Text != "--")
            {
                CargaTV(lblTV4);
            }
            else
            {
                Limpiar();
                DSM DV = new DSM();
                DV.CargarTk(cbTicketV);
                CargarDatos();
            }
        }

        private void btnTV5_Click(object sender, EventArgs e)
        {

            //PLDatos.Dock = DockStyle.Fill;
            txtTolvaV.Text = "5";
            if (lblTV5.Text != "--")
            {
                CargaTV(lblTV5);
            }
            else
            {
                Limpiar();
                DSM DV = new DSM();
                DV.CargarTk(cbTicketV);
                CargarDatos();
            }
        }

        private void btnTV6_Click(object sender, EventArgs e)
        {

            //PLDatos.Dock = DockStyle.Fill;
            txtTolvaV.Text = "6";
            if (lblTV6.Text != "--")
            {
                CargaTV(lblTV6);
            }
            else
            {
                Limpiar();
                DSM DV = new DSM();
                DV.CargarTk(cbTicketV);
                CargarDatos();
            }
        }

        private void btnTV7_Click(object sender, EventArgs e)
        {

            //PLDatos.Dock = DockStyle.Fill;
            txtTolvaV.Text = "7";
            if (lblTV7.Text != "--")
            {
                CargaTV(lblTV7);
            }
            else
            {
                Limpiar();
                DSM DV = new DSM();
                DV.CargarTk(cbTicketV);
                CargarDatos();
            }
        }

        private void btnTV8_Click(object sender, EventArgs e)
        {

            //PLDatos.Dock = DockStyle.Fill;
            txtTolvaV.Text = "8";
            if (lblTV8.Text != "--")
            {
                CargaTV(lblTV8);
            }
            else
            {
                Limpiar();
                DSM DV = new DSM();
                DV.CargarTk(cbTicketV);
                CargarDatos();
            }
        }

        private void btnGuardarPV_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                if (dtFechaPV.Value >= Convert.ToDateTime(LblFRecibido.Text))
                {
                    InsertarPOAV();
                    PLDatos.Visible = false;
                    Limpiar();
                    MostrarTicketsEnLabels();
                    Estilo();
                }
                else
                {
                    MessageBox.Show("La fecha de Ingreso a Tolvas Verticales no puede ser menor a la fecha de recibido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Existen campos vacios o con datos erroneos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private bool Validar()
        {
            double entero;
            if (!double.TryParse(txtHumedadPV.Text, out entero))
            {
                return false;
            }
            return !(cbOperadorPV.Text == "" || cbTurnoPV.Text == "" || txtHumedadPV.Text == "");
        }

        private void InsertarPOAV()
        {
            LPOAV parametros = new LPOAV();
            DPOAV funcion = new DPOAV();
            parametros.Ticket = cbTicketV.Text;
            parametros.POAV = Convert.ToInt32(txtTolvaV.Text);
            parametros.OperadorPV = cbOperadorPV.SelectedValue.ToString();
            parametros.TurnoPV = Convert.ToInt32(cbTurnoPV.SelectedValue);
            parametros.FRecibidoPV = Convert.ToDateTime(dtFechaPV.Value);
            parametros.HumedadPV = Convert.ToDouble(txtHumedadPV.Text);
            parametros.DigitadorPOA = Login.NombreA;
            if (funcion.InsertarPOAV(parametros) == true)
            {
                MessageBox.Show("Carga realizada con exito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnGuardarPV.Visible = false;
                cbOperadorPV.Enabled = false;
                cbTurnoPV.Enabled = false;
                dtFechaPV.Enabled = false;
                txtHumedadPV.Enabled = false;
                btnDescargarPV.Visible = true;
                cbTicketV.Enabled = false;
                TLPPlTolvas.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error al realizar esta acción", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDescargarPV_Click(object sender, EventArgs e)
        {
            gbVertical.Visible = true;
            gbPOAV.Enabled = false;
            txtVertical.Text = txtTolvaV.Text;
            cbOperadorV.Focus();
            DPOAV funcion = new DPOAV();
            DSM sm = new DSM();
            funcion.MostrarTurno(cbTurnoV);
            sm.MostrarOperador(cbOperadorV);
        }

        private void btnGuardarV_Click(object sender, EventArgs e)
        {
            if (ValidarDes())
            {
                if (dtFProcV.Value >= dtFechaPV.Value)
                {
                    DescargarTV();
                    MostrarTicketsEnLabels();
                    Estilo();
                }
                else
                {
                    MessageBox.Show("La fecha de ingreso a Vertical no puede menor al ingreso a Tolva Verical", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Existen campos vacios o con datos no validos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void DescargarTV()
        {
            //Verificar que la Vertical este vacia
            LVertical parametros = new LVertical();
            DVerticales funcion = new DVerticales();
            parametros.Ticket = cbTicketV.Text;
            parametros.Ver = int.Parse(txtVertical.Text);
            parametros.OperadorV = int.Parse(cbOperadorV.SelectedValue.ToString());
            parametros.TurnoV = int.Parse(cbTurnoPV.SelectedValue.ToString());
            parametros.FRecibidoV = Convert.ToDateTime(dtFechaPV.Text);
            parametros.HrInicoV = Convert.ToDateTime(dtHorainicioV.Text);
            parametros.HrFin = Convert.ToDateTime(dtHoraFinV.Text);
            parametros.Duracion = Convert.ToDateTime(txtDuracionV.Text);
            parametros.DigitadorV = Login.NombreA;
            if (funcion.InsertarVertical(parametros) == true)
            {
                //string TK = cbTicketV.Text;
                //LPOAV parametro = new LPOAV();
                //DPOAV fun = new DPOAV();
                //parametro.Ticket = TK;
                MessageBox.Show("Se ha Guardado el registro", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CambiarLblTK(parametros.Ver);
                PLDatos.Visible = false;
                //Limpiar();
                //MostrarTicketsEnLabels();
                //Estilo();
                gbVertical.Visible = false;
                TLPPlTolvas.Enabled = true;
            }
            else
            {
                MessageBox.Show("No se ha podido realizar la descarga", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CambiarLblTK(int poav)
        {
            string lblName = "lblTV" + poav;
            System.Windows.Forms.Control[] controls = Controls.Find(lblName, true);
            if (controls.Length > 0 && controls[0] is Label)
            {
                // Muestra el ticket en el Label
                Label lblTicket = (Label)controls[0];
                lblTicket.Text = "--";
            }
        }
        private bool ValidarDes() => !(cbOperadorV.Text == "" || cbTurnoV.Text == "");

        private void dtHoraFinV_ValueChanged(object sender, EventArgs e)
        {
            DateTime hasta = dtHoraFinV.Value;
            DateTime desde = dtHorainicioV.Value;
            TimeSpan Duracion = hasta - desde;
            txtDuracionV.Text = Convert.ToString(Duracion);
        }

        private void BtnCerrarVerCons_Click(object sender, EventArgs e)
        {
            PLDatos.Visible = false;
            gbVertical.Visible = false;
            gbPOAV.Enabled = true;
            TLPPlTolvas.Enabled = true;
            gbDatos.BackColor = Color.White;
            Limpiar();
        }

        private void CargaTV(Label TV)
        {
            DSM Sm = new DSM();
            DataTable dt = new DataTable();
            Sm.CargarTV(TV.Text, dt);
            cbTicketV.Enabled = false;
            cbTicketV.Text = TV.Text;
            LblSacos.Text = dt.Rows[0]["Sacos"].ToString();
            LblKilos.Text = dt.Rows[0]["Peso"].ToString();
            double kilos = Convert.ToDouble(LblKilos.Text);
            kilos = kilos / 46;
            LblQQsV.Text = Math.Round(kilos, 2).ToString();
            LblCalidadV.Text = dt.Rows[0]["Calidad"].ToString();
            LblDanioV.Text = dt.Rows[0]["Danio"].ToString();
            LblEFisicoV.Text = dt.Rows[0]["EstFisico"].ToString();
            cbOperadorPV.Text = dt.Rows[0]["Nombre"].ToString();
            cbTurnoPV.Text = dt.Rows[0]["TurnoPV"].ToString();
            dtFechaPV.Text = dt.Rows[0]["FRecibidoPV"].ToString();
            txtHumedadPV.Text = dt.Rows[0]["HumedadPV"].ToString();
            LblFRecibido.Text = dt.Rows[0]["FRecibido"].ToString();
            LblCert.Text = dt.Rows[0]["Certificacion"].ToString();
            btnGuardarPV.Visible = false;
            btnDescargarPV.Visible = true;
            cbOperadorPV.Enabled = false;
            cbTurnoPV.Enabled = false;
            dtFechaPV.Enabled = false;
            txtHumedadPV.Enabled = false;
            Capacidad();
            AbrirFormulario();
        }
        private void Capacidad()
        {
            double capacidad;
            double QQs = double.Parse(LblQQsV.Text);
            capacidad = (QQs / 600) * 100;
            capacidad = Math.Round(capacidad, 2);
            LblCapacidad.Text = capacidad.ToString() + " %";
            if (capacidad >= 100)
            {
                gbDatos.BackColor = Color.FromArgb(255, 150, 136);
            }
            else if (capacidad <= 50)
            {
                gbDatos.BackColor = Color.FromArgb(244, 250, 180);
            }
            else
            {
                gbDatos.BackColor = Color.White;
            }
        }
        private void Limpiar()
        {
            LblSacos.Text = "--";
            LblKilos.Text = "--";
            LblQQsV.Text = "--";
            LblCalidadV.Text = "--";
            LblDanioV.Text = "--";
            LblEFisicoV.Text = "--";
            cbOperadorPV.Text = "";
            txtHumedadPV.Clear();
        }
        private void cbTicketV_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }
        private void CargarDatos()
        {
            if (cbTicketV.SelectedValue != null)
            {
                AbrirFormulario();
                DSM sm = new DSM();
                sm.MostrarDatosTKSM(LblSacos, LblKilos, LblQQsV, LblCalidadV, LblDanioV, LblEFisicoV, LblFRecibido, LblCert, cbTicketV.Text);
                cbTicketV.Enabled = true;
                btnGuardarPV.Visible = true;
                btnDescargarPV.Visible = false;
                cbOperadorPV.Enabled = true;
                cbTurnoPV.Enabled = true;
                dtFechaPV.Enabled = true;
                txtHumedadPV.Enabled = true;
                CargarCombos();
                Capacidad();
            }
            else
            {
                Limpiar();
            }

        }
        private void CargarCombos()
        {
            DSM sm = new DSM();
            sm.MostrarOperador(cbOperadorPV);
            sm.MostrarOperador(cbOperadorV);
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
                    TLPPlTolvas.Enabled = true;
                }
            }
        }
    }
}
