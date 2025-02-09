using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProyectoOFI.SM
{
    public partial class PSData : UserControl
    {
        string Proceso, Ticket, Tolva, Modulo;
        int IdPS;
        public PSData()
        {
            InitializeComponent();
        }

        private void PSData_Load(object sender, EventArgs e)
        {
            MostrarLotesPS2();
            ValidarPermisos();
        }
        private void MostrarLotesPS2()
        {
            DPS pS = new DPS();
            DataTable dt = new DataTable();
            pS.MostrarLotesPS2(ref dt);
            DtPS.DataSource = dt;
        }
        private void DtPS_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerTK();
            //VerDetalleTK();
            CargarPS(Ticket);
            //AbrirFormulario();
        }

        private void CargarPS(string Tk)
        {
            try
            {

                DPS funcion = new DPS();
                DataTable dt = new DataTable();
                funcion.CargarPS(Tk, dt);
                LblTicket.Text = Ticket;
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
                LblParos.Text = dt.Rows[0]["ParosSF"].ToString();
                LblHumedad.Text = dt.Rows[0]["Humedad"].ToString() + " %";
                IdPS = int.Parse(dt.Rows[0]["IdPS"].ToString());
                //TimeSpan Horai = (TimeSpan)dt.Rows[0]["HoraFinDes"];
                //string duracionFormateada = $"{Horai.Hours:D2}:{Horai.Minutes:D2}";
                LblHrFinPS.Text = dt.Rows[0]["HoraFinDes"].ToString();
                //TimeSpan HoraF = (TimeSpan)dt.Rows[0]["HoraInDes"];
                //string HoraFormateada = $"{HoraF.Hours:D2}:{HoraF.Minutes:D2}";
                LblHrInPS.Text = dt.Rows[0]["HoraInDes"].ToString();
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
                Proceso = dt.Rows[0]["ProcesoSF"].ToString();
                AbrirFormulario();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void AbrirFormulario()
        {
            //PlDatos.Size = new Size(1398, 619);

            PlDatos.Visible = true;
            PlDatos.Location = new Point(DtPS.Width / 2
                - PlDatos.Width / 2, DtPS.Height / 2 - PlDatos.Height / 2);
            PlDatos.BringToFront();
            DtPS.Enabled = false;
            if (Proceso == "Analizado")
            {
                BtnPS.Enabled = true;
                LblMsj.Visible = false;
                BtnPS.Text = "Realizar Envio";
            }
            else if (Proceso == "TF/Rechazado")
            {
                BtnPS.Text = "Enviar a Tolvas Finales";
                BtnPS.Enabled = true;
                LblMsj.Text = "Rechazado por humedad";
                LblMsj.Visible = true;
            }
            else
            {
                double humedad;
                if (double.TryParse(LblHumedad.Text.TrimEnd('%'), out humedad))
                {
                    if (humedad >= 13)
                    {
                        BtnPS.Enabled = true;
                        LblMsj.Visible = false;
                        BtnPS.Text = "Realizar Envio";
                    }
                    else
                    {
                        BtnPS.Enabled = false;
                        LblMsj.Visible = true;
                        BtnPS.Text = "Realizar Envio";
                    }
                }
                else
                {
                    MessageBox.Show("No se puede convertir el numero", "Error en la Humedad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnCerrarPlDatos_Click(object sender, EventArgs e)
        {
            PlDatos.Visible = false;
            GbEnvio.Visible = false;
            DtPS.Enabled = true;
            BtnPS.Text = "Realizar Envio";
        }

        private void BtnPS_Click(object sender, EventArgs e)
        {
            if (BtnPS.Text == "Enviar a Tolvas Finales")
            {
                InsertarTF();
            }
            else
            {
                GbEnvio.Visible = true;
                DSM funcion = new DSM();
                funcion.MostrarOperador(CbOperadoresEn);
                funcion.MostrarTurno(CbTurnoEn);
                DPS dPS = new DPS();
                dPS.MostrarAreaSecado(CbDestino);
                dPS.MostrarEstFis(CbEstFis);
            }
        }

        private void InsertarTF()
        {
            DPS funcion = new DPS();
            if (funcion.InsertarTF(LblTicket.Text) == true)
            {
                MessageBox.Show("Envio realizado con éxito", "Envio a Tolvas Finales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarLotesPS2();
                PlDatos.Visible = false;
                DtPS.Enabled = true;
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error", "Error en Interfaz TF", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void InsertarEnvioSM()
        {
            try
            {
                LPS parametros = new LPS();
                DPS funcion = new DPS();
                parametros.IdPS = IdPS;
                parametros.FechaPS = DtPFEnvio.Value;
                //parametros.IdOperador = (int)CbOperadoresEn.SelectedValue;
                parametros.IdTurno = (int)CbTurnoEn.SelectedValue;
                parametros.DNIN = TxtDNIN.Text;
                parametros.IdArea = (int)CbDestino.SelectedValue;
                parametros.IdEstFis = (int)CbEstFis.SelectedValue;
                parametros.DigitadorPS = CbOperadoresEn.Text;
                if (funcion.InsertarEnvioSM(parametros, IdPS) == true)
                {
                    GbEnvio.Visible = false;
                    PlDatos.Visible = false;
                    TxtDNIN.Clear();
                    MessageBox.Show("Envio realizado con éxito", "Envio a almacén", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    int PS = int.Parse(LblPS.Text);
                    MostrarLotesPS2();
                    DtPS.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar datos Pre-Secado " + ex.Message, "ERROR Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBusqueda_Click(object sender, EventArgs e)
        {
            if (txtTicket.Text == "")
            {
                MostrarLotesPS2();
            }
            else
            {
                DPS funcion = new DPS();
                DataTable dt = new DataTable();
                funcion.BuscarLotesPS(txtTicket.Text, ref dt);
                DtPS.DataSource = dt;
            }
        }

        private void ObtenerTK()
        {
            string nombrecolumna = "Ticket Hijo";
            int indice = DtPS.Columns[nombrecolumna].Index;
            Ticket = DtPS.SelectedCells[indice].Value.ToString();

            string nombrecolum = "Proceso";
            int num = DtPS.Columns[nombrecolum].Index;
            Proceso = DtPS.SelectedCells[num].Value.ToString();

            string Status = "PS";
            int num1 = DtPS.Columns[Status].Index;
            Tolva = DtPS.SelectedCells[num1].Value.ToString();
        }
        private void ValidarPermisos()
        {
            if (!Login.login.Trim().StartsWith("Admin", StringComparison.OrdinalIgnoreCase))
            {
                DataTable dt = new DataTable();
                DModulos funcion = new DModulos();
                LPermisos parametros = new LPermisos();
                parametros.IdUser = Login.Iduser;
                funcion.PermisosUser(ref dt, Login.Iduser);
                foreach (DataRow rowpermisos in dt.Rows)
                {
                    Modulo = Convert.ToString(rowpermisos["Modulo"]);
                    if (Modulo == "Agregar SM")
                    {
                        DtPS.Enabled = true;

                    }
                }
            }
            else
            {
                DtPS.Enabled = true;
            }
        }
    }
}
