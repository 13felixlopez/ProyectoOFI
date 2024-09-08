using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using ProyectoOFI.Otros;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOFI.SM
{
    public partial class SecadoMecanico : UserControl
    {
        string Ticket, Proceso, Estado;
        DateTime Frecibido;
        int desde = 1;
        int hasta = 100;
        int Contador, totalPaginas;
        int ContarBusqueda;
        private int items_por_pagina = 100;
        int IdVer;
        string origen;
        string Modulo;
        Label labelPreSeco = new Label();
        DataTable SM = new DataTable();
        public SecadoMecanico()
        {
            InitializeComponent();
            ValidarPermisos();
        }
        private async void SecadoMecanico_Load(object sender, EventArgs e)
        {
            PlCarga.Dock = DockStyle.Fill;
            await CargarDatos();
            Base.DiseñoDtvEliminar(ref dtInventarioSM);
            PlCarga.Visible = false;
        }
        private async Task CargarDatos()
        {
            await Task.Delay(1500);
            dtInventarioSM.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            MostrarSM();
            ReiniciarPaginado();
            await Task.Delay(1000);
        }
        private void MostrarSM()
        {
            DSM SM = new DSM();
            DataTable dt = new DataTable();
            SM.MostrarSM(ref dt, desde, hasta);
            dtInventarioSM.DataSource = dt;
            // dtInventarioSM.Columns["ProcesoSM"].Visible = false;
        }
        private void ObtenerTK()
        {
            string nombrecolumna = "Ticket";
            int indice = dtInventarioSM.Columns[nombrecolumna].Index;
            Ticket = dtInventarioSM.SelectedCells[indice].Value.ToString();

            string nombrecolum = "ProcesoSM";
            int num = dtInventarioSM.Columns[nombrecolum].Index;
            Proceso = dtInventarioSM.SelectedCells[num].Value.ToString();

            string Status = "Proceso";
            int num1 = dtInventarioSM.Columns[Status].Index;
            Estado = dtInventarioSM.SelectedCells[num1].Value.ToString();
        }
        private void dtInventarioSM_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerTK();
            VerDetalleTK();
            AbrirFormulario();
            if (Login.login.Trim().StartsWith("Admin", StringComparison.OrdinalIgnoreCase))
            {
                if (Proceso == "POAV")
                {
                    VerPOAV();
                }
                else if (Proceso == "Vertical")
                {
                    VerPOAV();
                    VerVertical();
                }
            }
            else
            {
                TipoProceso();
            }
            if (LblCert.Text != "Convencional")
            {
                PLDatos.BackColor = Color.FromArgb(192, 255, 255);
            }
            else
            {
                PLDatos.BackColor = Color.FromArgb(192, 255, 192);
            }
        }
        private void TipoProceso()
        {
            try
            {

                if (Proceso == "No Asignado" || Proceso == "")
                {
                    gbPOAV.Visible = false;
                    gbVertical.Visible = false;
                    double qqs = double.Parse(LblQQsV.Text);
                    if (qqs >= 331 && Estado == "No Asignado" || Proceso == "")
                    {
                        BtnParticionar.Visible = true;
                    }
                    else
                    {
                        BtnParticionar.Visible = false;
                    }
                }
                if (Proceso == "POAV")
                {
                    gbPOAV.Visible = true;
                    gbVertical.Visible = false;
                    VerPOAV();
                }
                if (Proceso == "Vertical")
                {
                    gbPOAV.Visible = true;
                    gbVertical.Visible = true;
                    VerPOAV();
                    VerVertical();
                }
                if (Proceso == "POA")
                {
                    GbPreSecado.Visible = true;
                    gbPOAV.Visible = true;
                    gbVertical.Visible = true;
                    VerPOAV();
                    VerVertical();
                    VerPreSecado();
                    EnvioSM();
                }
                if (Proceso == "Carga Directa SF")
                {
                    gbPOAV.Visible = false;
                    GbPreSecado.Visible = true;
                    VerPreSecado();
                }
                if (Proceso == "Carga Directa SF" && Estado == "Guardiola")
                {
                    GbPreSecado.Visible = true;
                    gbPOAV.Visible = true;
                    gbVertical.Visible = true;
                    GbGuardiola.Visible = true;
                    //VerPOAV();
                    //VerVertical();
                    VerPreSecado();
                    VerGuardiola();
                    EnvioSM();
                }
                if (Proceso == "Guardiola" && Estado == "Guardiola")
                {
                    GbPreSecado.Visible = true;
                    gbPOAV.Visible = true;
                    gbVertical.Visible = true;
                    GbGuardiola.Visible = true;
                    VerPreSecado();
                    VerGuardiola();
                    EnvioSM();
                }
                if (Proceso == "PS" && Estado == "PS")
                {
                    GbPreSecado.Visible = true;
                    gbPOAV.Visible = true;
                    gbVertical.Visible = true;
                    GbGuardiola.Visible = true;
                    GbPS.Visible = true;
                    VerPOAV();
                    VerVertical();
                    VerPreSecado();
                    VerGuardiola();
                    VerPS();
                    EnvioSM();
                }
                if (Proceso == "PS" || Estado == "PS" || Estado == "TF/Rechazado")
                {
                    GbPreSecado.Visible = true;
                    gbPOAV.Visible = true;
                    gbVertical.Visible = true;
                    GbGuardiola.Visible = true;
                    GbPS.Visible = true;
                    VerPOAV();
                    VerVertical();
                    VerPreSecado();
                    VerGuardiola();
                    VerPS();
                    EnvioSM();
                }
                if (Proceso == "Envio" && Estado == "Envio")
                {
                    GbPreSecado.Visible = true;
                    gbPOAV.Visible = true;
                    gbVertical.Visible = true;
                    GbGuardiola.Visible = true;
                    GbPS.Visible = true;
                    VerPOAV();
                    VerVertical();
                    VerPreSecado();
                    VerGuardiola();
                    VerPS();
                    EnvioSM();
                }
                if (Proceso == "Envio" || Estado == "Envio" || Proceso == "Almacén" || Estado == "Almacén")
                {
                    GbPreSecado.Visible = true;
                    gbPOAV.Visible = true;
                    gbVertical.Visible = true;
                    GbGuardiola.Visible = true;
                    GbPS.Visible = true;
                    GbDatosSm.Visible = true;
                    VerPOAV();
                    VerVertical();
                    EnvioSM();
                    VerPreSecado();
                    VerGuardiola();
                    VerPS();
                }
                if (Proceso == "Analizado" && Estado == "Analizado")
                {
                    GbPreSecado.Visible = true;
                    gbPOAV.Visible = true;
                    gbVertical.Visible = true;
                    GbGuardiola.Visible = true;
                    GbPS.Visible = true;
                    VerPOAV();
                    VerVertical();
                    VerPreSecado();
                    VerGuardiola();
                    VerPS();
                    EnvioSM();
                }
                if (Proceso == "Carga Directa SF" && Estado == "Analizado")
                {
                    GbPreSecado.Visible = true;
                    gbPOAV.Visible = true;
                    gbVertical.Visible = true;
                    GbGuardiola.Visible = true;
                    GbPS.Visible = true;
                    //VerPOAV();
                    //VerVertical();
                    VerPreSecado();
                    VerGuardiola();
                    VerPS();
                    EnvioSM();
                }
            }
            catch (Exception)
            {
                GbPreSecado.Visible = false;
                //PLDatos.Visible = false;
                //MessageBox.Show("No hay datos para mostrar", "Datos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void VerGuardiola()
        {
            try
            {
                DSM funcion = new DSM();
                DataTable dt = new DataTable();
                funcion.VerGuardiola(ref dt, Ticket);
                DtGuardiola.DataSource = dt;
            }
            catch { }
        }
        private void VerPS()
        {
            try
            {
                DSM funcion = new DSM();
                DataTable dt = new DataTable();
                funcion.VerPS(ref dt, Ticket);
                dtPS.DataSource = dt;
            }
            catch { }
        }
        private void VerPreSecado()
        {
            try
            {
                DataTable dt = new DataTable();
                DSM SM = new DSM();
                SM.VerPreSecado(ref dt, Ticket, LblG1, LblG2);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    if (dr["FechaDes"].ToString() != null)
                    {
                        LblFDescargue.Text = Convert.ToDateTime(dr["FechaDes"]).ToShortDateString();
                    }
                    else
                    {
                        LblFDescargue.Text = "--";
                    }
                    if (dr["HoradesIn"].ToString() != null)
                    {
                        TimeSpan horaMinutos = (TimeSpan)dr["HoradesIn"];
                        LblHrDescIn.Text = horaMinutos.ToString(@"hh\:mm");
                    }
                    else
                    {
                        LblHrDescIn.Text = "--";
                    }
                    if (dr["HoraFin"].ToString() != null)
                    {
                        TimeSpan horaMaxutos = (TimeSpan)dr["HoraFin"];
                        LblHrDesfin.Text = horaMaxutos.ToString(@"hh\:mm");
                    }
                    else
                    {
                        LblHrDesfin.Text = "--";
                    }
                    if (dr["Paros"].ToString() != null)
                    {
                        LblParos.Text = dr["Paros"].ToString();
                    }
                    else
                    {
                        LblParos.Text = "--";
                    }
                    if (dr["Total"] != DBNull.Value)
                    {
                        string totalTiempo = dr["Total"].ToString();

                        // Regex para extraer días, horas y minutos
                        Regex regex = new Regex(@"(?:(\d+) días?)?\s*(?:(\d+) horas?)?\s*(?:(\d+) minutos?)?");
                        Match match = regex.Match(totalTiempo);

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
                            LblTotalPre.Text = resultado;
                        }
                        else
                        {
                            LblTotalPre.Text = "--";
                        }
                    }
                    else
                    {
                        LblTotalPre.Text = "--";
                    }


                    if (dr["Humedad"].ToString() != null)
                    {
                        LblHumedadSF.Text = dr["Humedad"].ToString();
                    }
                    else
                    {
                        LblHumedadSF.Text = "--";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void VerVertical()
        {
            try
            {
                DataTable dt = new DataTable();
                DSM SM = new DSM();
                SM.VerVertical(ref dt, Ticket);
                if (dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0]["Ticket"].ToString()))
                {
                    DataRow dr = dt.Rows[0];
                    if (dr["IDV"].ToString() != null)
                    {
                        IdVer = int.Parse(dr["IDV"].ToString());
                    }
                    if (dr["Ver"].ToString() != null)
                    {
                        LblVer.Text = dr["Ver"].ToString();
                    }
                    else
                    {
                        LblVer.Text = "";
                    }
                    if (dr["Turno"].ToString() != null)
                    {
                        LblTurnoV.Text = dr["Turno"].ToString();
                    }
                    else
                    {
                        LblTurnoV.Text = "";
                    }
                    if (dr["FRecibidoV"].ToString() != null)
                    {
                        dtFProcV.Value = DateTime.Parse(dr["FRecibidoV"].ToString());
                    }
                    else
                    {
                        dtFProcV.Value = DateTime.Today;
                    }
                    if (dr["HrInicioV"].ToString() != null)
                    {
                        dtHorainicioV.Value = DateTime.Parse(dr["HrInicioV"].ToString());
                    }
                    else
                    {
                        dtHorainicioV.Format = DateTimePickerFormat.Time;
                    }
                    if (dr["HrFin"].ToString() != null)
                    {
                        dtHoraFinV.Value = DateTime.Parse(dr["HrFin"].ToString());
                    }
                    else
                    {
                        dtHoraFinV.Format = DateTimePickerFormat.Time;
                    }
                    if (dr["Duracion"].ToString() != null)
                    {
                        TimeSpan tiempo = (TimeSpan)dr["Duracion"];
                        string duracionFormateada = $"{tiempo.Hours:D2}:{tiempo.Minutes:D2}";
                        LblDuracion.Text = duracionFormateada;
                    }
                    else
                    {
                        LblDuracion.Text = "";
                    }
                    if (dr["Nombre"].ToString() != null)
                    {
                        LblOperadorV.Text = dr["Nombre"].ToString();
                    }
                    else
                    {
                        LblOperadorV.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos en controles" + ex.Message, "ERROR en Secado Mecanico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AbrirFormulario()
        {
            PLDatos.Size = new Size(1905, 743);
            PLDatos.Location = new System.Drawing.Point(dtInventarioSM.Width / 2
                - PLDatos.Width / 2, dtInventarioSM.Height / 2 - PLDatos.Height / 2);
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Verificamos si el panel es más grande que el formulario y ajustamos si es necesario
            if (PLDatos.Width > formWidth)
            {
                PLDatos.Width = formWidth - 20; // Agregamos un margen
            }

            if (PLDatos.Height > formHeight)
            {
                PLDatos.Height = formHeight - 20; // Agregamos un margen
            }

            // Luego calculamos la nueva ubicación centrada
            int newX = (formWidth - PLDatos.Width) / 2;
            int newY = (formHeight - PLDatos.Height) / 2;

            PLDatos.Location = new Point(newX, newY);
            PLDatos.Visible = true;
            PLDatos.BringToFront();
            plOpciones.Enabled = false;
            dtInventarioSM.Enabled = false;
        }
        private void BtnCerrarVerCons_Click(object sender, EventArgs e)
        {
            PLDatos.Visible = false;
            plOpciones.Enabled = true;
            GbPreSecado.Visible = false;
            gbPOAV.Visible = true;
            GbGuardiola.Visible = false;
            gbVertical.Visible = false;
            GbPS.Visible = false;
            GbDatosSm.Visible = false;
            SM.Clear();
            labelPreSeco.Text = "";
            labelPreSeco.BackColor = Color.Transparent;
            dtInventarioSM.Enabled = true;
            BtnParticionar.Visible = false;
            Limpiar();
        }
        private void Limpiar()
        {
            LblPOAV.Text = "--";
            LblOperadorPV.Text = "--";
            LblTurnoPV.Text = "--";
            LblHumedadPV.Text = "--";
            LblVer.Text = "--";
            LblOperadorV.Text = "--";
            LblTurnoV.Text = "--";
            LblDuracion.Text = "--";
            LblFDescargue.Text = "--";
            LblHrDescIn.Text = "--";
            LblHrDesfin.Text = "--";
            LblParos.Text = "--";
            LblHumedadSF.Text = "--";
            LblTotalPre.Text = "--";
            LblG1.Text = "--";
            LblG2.Text = "--";
        }
        private void VerDetalleTK()
        {
            try
            {
                DataTable dt = new DataTable();
                DSM SM = new DSM();
                SM.VerPOAV(ref dt, Ticket);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    double kilos;
                    if (row["Certificacion"].ToString() != null)
                    {
                        LblCert.Text = row["Certificacion"].ToString();
                    }
                    else
                    {
                        LblCert.Text = "";
                    }
                    LblTk.Text = Ticket.ToString();
                    Frecibido = DateTime.Parse(row["FechaRecibido"].ToString());
                    LblFRecibido.Text = Frecibido.ToString();
                    LblEFisicoV.Text = row["EstFisico"].ToString();
                    LblCalidadV.Text = row["Calidad"].ToString();
                    LblDanioV.Text = row["Danio"].ToString();
                    LblSacos.Text = row["Sacos"].ToString();
                    LblKilos.Text = row["Peso"].ToString();
                    kilos = double.Parse(LblKilos.Text);
                    kilos = kilos / 46;
                    LblQQsV.Text = Math.Round(kilos, 2).ToString();
                    //Proceso = row["ProcesoSM"].ToString();
                    origen = row["ProcesoCP"].ToString();
                    if (origen == "Envio SM")
                    {
                        labelPreSeco.Text = "Pre-Seco";
                        gbDatos.Controls.Add(labelPreSeco);
                        labelPreSeco.Location = new System.Drawing.Point(1081, 62);
                        labelPreSeco.BackColor = Color.OrangeRed;
                    }
                    else
                    {
                        labelPreSeco.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos en controles" + ex.Message, "ERROR en Secado Mecanico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void VerPOAV()
        {
            try
            {
                DataTable dt = new DataTable();
                DSM SM = new DSM();
                SM.VerPOAV(ref dt, Ticket);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    double kilos;
                    if (row["Certificacion"].ToString() != null)
                    {
                        LblCert.Text = row["Certificacion"].ToString();
                    }
                    else
                    {
                        LblCert.Text = "";
                    }
                    LblTk.Text = Ticket.ToString();
                    Frecibido = DateTime.Parse(row["FechaRecibido"].ToString());
                    LblFRecibido.Text = Frecibido.ToString();
                    LblEFisicoV.Text = row["EstFisico"].ToString();
                    LblCalidadV.Text = row["Calidad"].ToString();
                    LblDanioV.Text = row["Danio"].ToString();
                    LblSacos.Text = row["Sacos"].ToString();
                    LblKilos.Text = row["Peso"].ToString();
                    kilos = double.Parse(LblKilos.Text);
                    kilos = kilos / 46;
                    LblQQsV.Text = Math.Round(kilos, 2).ToString();
                    Proceso = row["ProcesoSM"].ToString();
                    if (row["POAV"].ToString() != null)
                    {
                        LblPOAV.Text = row["POAV"].ToString();
                    }
                    else
                    {
                        LblPOAV.Text = "";
                    }
                    if (row["Turno"].ToString() != null)
                    {
                        LblTurnoPV.Text = row["Turno"].ToString();
                    }
                    else
                    {
                        LblTurnoPV.Text = "";
                    }
                    if (row["Nombre"].ToString() != null)
                    {
                        LblOperadorPV.Text = row["Nombre"].ToString();
                    }
                    else
                    {
                        LblOperadorPV.Text = "";
                    }
                    if (row["FRecibidoPV"].ToString() != null)
                    {
                        dtFechaPV.Text = row["FRecibidoPV"].ToString();
                    }
                    else
                    {
                        dtFechaPV.Text = DateTime.Today.ToString();
                    }
                    if (row["HumedadPV"].ToString() != null)
                    {
                        LblHumedadPV.Text = row["HumedadPV"].ToString() + "%";
                    }
                    else
                    {
                        LblHumedadPV.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos en controles" + ex.Message, "ERROR en Secado Mecanico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BuscarTk()
        {
            DataTable dt = new DataTable();
            DSM funcion = new DSM();
            funcion.BuscarTKSM(txtBuscador.Text, ref dt, desde, hasta, ContarBusqueda, CbBuscar.Text);
            dtInventarioSM.DataSource = dt;
            ContarBusqueda = int.Parse(funcion.contador.ToString());
            Base.DiseñoDtvEliminar(ref dtInventarioSM);
        }
        #region Paginado
        private void ReiniciarPaginado()
        {
            desde = 1;
            hasta = 100;
            Contar();

            if (Contador > hasta)
            {

                btn_Sig.Visible = true;
                btn_atras.Visible = false;
                btn_Ultima.Visible = true;
                btn_Primera.Visible = true;
            }
            else
            {

                btn_Sig.Visible = false;
                btn_atras.Visible = false;
                btn_Ultima.Visible = false;
                btn_Primera.Visible = false;
            }
            Paginar();
        }
        private void Contar()
        {
            DSM funcion = new DSM();
            if (txtBuscador.Text != "")
            {
                Contador = ContarBusqueda;
            }
            else if (CbBuscador.Visible == true || PlFiltroFecha.Visible == true)
            {
                Contador = ContarBusqueda;
            }
            else
            {
                funcion.ContarTK(ref Contador);
            }
        }
        private void Paginar()
        {
            try
            {
                lbl_Pagina.Text = (hasta / items_por_pagina).ToString();
                lbl_totalPaginas.Text = Math.Ceiling(Convert.ToSingle(Contador) / items_por_pagina).ToString();
                totalPaginas = Convert.ToInt32(lbl_totalPaginas.Text);
            }
            catch (Exception)
            {

            }
        }
        private void btn_atras_Click(object sender, EventArgs e)
        {
            desde -= 100;
            hasta -= 100;
            if (txtBuscador.Text != "")
            {
                BuscarTk();
            }
            else if (CbBuscador.Visible == true)
            {
                Buscar();
            }
            else if (PlFiltroFecha.Visible == true)
            {
                BuscarFechaSM();
            }
            else
            {
                MostrarSM();
            }
            Contar();
            if (Contador > hasta)
            {
                btn_Sig.Visible = true;
                btn_atras.Visible = true;
            }
            else
            {
                btn_Sig.Visible = false;
                btn_atras.Visible = true;
            }
            if (desde == 1)
            {
                ReiniciarPaginado();
            }
            Paginar();
        }
        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscador.Text == "")
            {
                ReiniciarPaginado();
                MostrarSM();
            }
            else if (CbBuscador.Text == "Peso")
            {
                Buscar();
                ReiniciarPaginado();
            }
            else
            {
                BuscarTk();
                ReiniciarPaginado();
            }
        }
        private void btn_Sig_Click(object sender, EventArgs e)
        {
            desde += 100;
            hasta += 100;
            if (txtBuscador.Text != "")
            {
                BuscarTk();
            }
            else if (CbBuscador.Visible == true)
            {
                Buscar();
            }
            else if (PlFiltroFecha.Visible == true)
            {
                BuscarFechaSM();
            }
            else
            {
                MostrarSM();
            }
            Contar();
            if (Contador > hasta)
            {
                btn_Sig.Visible = true;
                btn_atras.Visible = true;
            }
            else
            {
                btn_Sig.Visible = false;
                btn_atras.Visible = true;
            }
            Paginar();
        }
        private void btn_Ultima_Click(object sender, EventArgs e)
        {
            hasta = totalPaginas * items_por_pagina;
            desde = hasta - 99;
            if (txtBuscador.Text != "")
            {
                BuscarTk();
            }
            else if (CbBuscador.Visible == true)
            {
                Buscar();
            }
            else if (PlFiltroFecha.Visible == true)
            {
                BuscarFechaSM();
            }
            else
            {
                MostrarSM();
            }
            Contar();
            if (Contador > hasta)
            {
                btn_Sig.Visible = true;
                btn_atras.Visible = true;
            }
            else
            {
                btn_Sig.Visible = false;
                btn_atras.Visible = true;
            }
            Paginar(); ;
        }
        private void btn_Primera_Click(object sender, EventArgs e)
        {
            ReiniciarPaginado();
            if (txtBuscador.Text != "")
            {
                BuscarTk();
            }
            else if (CbBuscador.Visible == true)
            {
                Buscar();
            }
            else if (PlFiltroFecha.Visible == true)
            {
                BuscarFechaSM();
            }
            else
            {
                MostrarSM();
            }
        }
        #endregion
        private void Buscar()
        {
            DataTable dt = new DataTable();
            DSM funcion = new DSM();
            funcion.BuscarTKSM(CbBuscador.Text, ref dt, desde, hasta, ContarBusqueda, CbBuscar.Text);
            dtInventarioSM.DataSource = dt;
            ContarBusqueda = int.Parse(funcion.contador.ToString());
            Base.DiseñoDtvEliminar(ref dtInventarioSM);
        }
        private void BtnParticionar_Click(object sender, EventArgs e)
        {
            PlParticion.Size = new System.Drawing.Size(1254, 352);
            PlParticion.Location = new System.Drawing.Point(dtInventarioSM.Width / 2
                - PlParticion.Width / 2, dtInventarioSM.Height / 2 - PlParticion.Height / 2);
            PlParticion.Visible = true;
            PlParticion.BringToFront();
            plOpciones.Enabled = false;
            dtInventarioSM.Enabled = false;
            PLDatos.Enabled = false;
            DSM funcion = new DSM();
            funcion.MostrarOperador(CbOperadores);
            funcion.MostrarTurno(CbTurno);
            ObtenerDatos();
        }
        private void ObtenerDatos()
        {
            LblTkParticion.Text = LblTk.Text;
            LblSacosPar.Text = LblSacos.Text;
            LblKilosPar.Text = LblKilos.Text;
            LblSacosPar.Text = LblSacos.Text;
            LblQQsPar.Text = LblQQsV.Text;
            LblCertPar.Text = LblCert.Text;
            LblDaPar.Text = LblDanioV.Text;
            LblCalPar.Text = LblCalidadV.Text;
            LblEstPar.Text = LblEFisicoV.Text;
        }
        private void BtnCerrarParticion_Click(object sender, EventArgs e)
        {
            PlParticion.Visible = false;
            plOpciones.Enabled = true;
            LblTkParticion.Text = "--";
            LblSacosPar.Text = "--";
            LblKilosPar.Text = "--";
            LblSacosPar.Text = "--";
            LblQQsPar.Text = "--";
            LblCertPar.Text = "--";
            LblDaPar.Text = "--";
            LblCalPar.Text = "--";
            LblEstPar.Text = "--";
            PLDatos.Enabled = true;
        }
        private void BtnSF_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtHumedad.Text))
            {
                ParticionSM();
                PLDatos.Enabled = true;
            }
            else
            {
                MessageBox.Show("Existen datos vacios", "Error en validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PbExcel_Click(object sender, EventArgs e)
        {
            FrmExcelSM excel = new FrmExcelSM();
            excel.Dock = DockStyle.Fill;
            excel.BringToFront();
            excel.ShowDialog();
        }
        private void ParticionSM()
        {
            try
            {
                LVertical parametros = new LVertical();
                DSM funcion = new DSM();
                parametros.Ticket = LblTkParticion.Text;
                parametros.FechaDes = DtPFDes1.Value;
                parametros.HoradesIn = DtHInicio1.Value;
                parametros.HoraFin = DtHInicio2.Value;
                parametros.Humedad = double.Parse(TxtHumedad.Text);
                parametros.ProcesoSF = "POA";
                parametros.OperadorV = int.Parse(CbOperadores.SelectedValue.ToString());
                parametros.TurnoV = int.Parse(CbTurno.SelectedValue.ToString());
                parametros.POA1 = int.Parse(CbPOA1.Text.Trim());
                parametros.POA2 = int.Parse(CbPOA2.Text.Trim());
                parametros.DigitadorV = Login.NombreA;
                if (funcion.ParticionSM(parametros) == true)
                {
                    MessageBox.Show("Operación realizada con éxito", "Secado final", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    PlParticion.Visible = false;
                    plOpciones.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Error en los datos de la partición", "Error Partición", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al crear las particiones", "Error ParticionSM interfaz", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            DRecepcion funcion = new DRecepcion();
            if (CbBuscar.Text == "Ticket" || CbBuscar.Text == "MTNT" || CbBuscar.Text == "Peso")
            {
                CbBuscador.Text = "";
                PlFiltroFecha.Visible = false;
                txtBuscador.Visible = true;
                CbBuscador.Visible = false;
                ReiniciarPaginado();
            }
            else if (CbBuscar.Text == "Calidad")
            {
                TextBuscarVisible();
                funcion.MostrarCalidad(CbBuscador);
            }
            else if (CbBuscar.Text == "Certificación")
            {
                TextBuscarVisible();
                funcion.MostrarCert(CbBuscador);
            }
            else if (CbBuscar.Text == "Daño")
            {
                TextBuscarVisible();
                funcion.MostrarDaño(CbBuscador);
            }
            else if (CbBuscar.Text == "Proceso")
            {
                TextBuscarVisible();
                DSM T = new DSM();
                T.ProcesoSM(CbBuscador);
            }
            else if (CbBuscar.Text == "Fecha")
            {
                TextBuscarVisible();
                CbBuscador.Visible = false;
                PlFiltroFecha.Visible = true;
            }
        }
        private void TextBuscarVisible()
        {
            txtBuscador.Clear();
            txtBuscador.Visible = false;
            CbBuscador.Visible = true;
            CbBuscador.DataSource = null;
            CbBuscador.SelectedIndex = -1;
            PlFiltroFecha.Visible = false;
        }
        private void CbBuscador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbBuscador.Text == "")
            {
                ReiniciarPaginado();
                MostrarSM();
            }
            else
            {
                Buscar();
                ReiniciarPaginado();
            }
        }
        private void BtnFiltroFecha_Click(object sender, EventArgs e)
        {
            BuscarFechaSM();
            ReiniciarPaginado();
        }
        private void BuscarFechaSM()
        {
            DataTable dt = new DataTable();
            DSM funcion = new DSM();
            funcion.BuscarFechaSM(ref dt, DtpInicio.Value, DtpFin.Value, desde, hasta, ContarBusqueda);
            dtInventarioSM.DataSource = dt;
            ContarBusqueda = int.Parse(funcion.contador.ToString());
            Base.DiseñoDtvEliminar(ref dtInventarioSM);
        }

        private async void BtnActualizar_Click(object sender, EventArgs e)
        {
            await CargarDatos();
            MessageBox.Show("Datos Actualizados", "Refrescar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void EnvioSM()
        {
            SM.Clear();
            DSM sM = new DSM();
            sM.VerEnvioSM(ref SM, Ticket);
            VerEnvioSM(SM, GbDatosSm);
            GbDatosSm.Visible = true;
        }
        private void VerEnvioSM(DataTable dt, GroupBox groupBox)
        {
            // Limpiar cualquier control existente en el GroupBox
            groupBox.Controls.Clear();

            // Variables para posicionamiento
            int posY = 55;

            foreach (DataRow row in dt.Rows)
            {
                int posX = 10; // Reiniciar la posición X para cada nueva fila

                foreach (DataColumn column in dt.Columns)
                {
                    if (row[column] != DBNull.Value) // Solo crear Labels para valores no nulos
                    {
                        Label label = new Label();
                        label.Text = $"{column.ColumnName}: {row[column].ToString()}";
                        label.AutoSize = true;
                        label.Location = new Point(posX, posY);

                        groupBox.Controls.Add(label);

                        // Ajustar posX para la próxima etiqueta en la misma fila
                        posX += label.Width + 10;
                    }
                }

                // Ajustar posY para la próxima fila de etiquetas
                posY += 50;
            }
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
                    BtnParticionar.Enabled = true;
                }
            }
        }
    }
}
