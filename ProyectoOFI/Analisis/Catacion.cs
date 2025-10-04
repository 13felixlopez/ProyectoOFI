using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using ProyectoOFI.Reportes;
using ProyectoOFI.Usuario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOFI.Analisis
{
    public partial class Catacion : UserControl
    {
        int desde = 1;
        int hasta = 100;
        private int items_por_pagina = 100;
        int totalPaginas;
        int Contador;
        int ContarBusqueda;
        string Ticket, TkSM, TkDetalle, EstadoEnv;
        DateTime FRecibido, FMuestra;
        double Exp, DesmA, DesmC, DesmD;
        double Bto = 0;
        double Casc;
        private bool isPlaceholder = true;
        double Humedad;
        Boolean Estado;
        string Proceso, Modulo;
        int Idcatacion;
        List<string> filtro = new List<string>();
        string Analizar = "Proceso";//Variable que define si es compra directa o no

        //Variables a utilizar para el envio de correo, Ticket y analisis se obtienen del metodo verdetallecata
        string NumAnalisis, Rendimiento, Quality;
        public Catacion()
        {
            InitializeComponent();
            //SetPlaceholder(TxtAnalisis, "# Analisis");
            //SetPlaceholder(TxtBto, "0");
            //SetPlaceholder(TxtHumedad, "0");
            //SetPlaceholder(TxtExp, "0");
            //SetPlaceholder(TxtDesmA, "0");
            //SetPlaceholder(TxtDesmC, "0");
            TxtBto.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            TxtHumedad.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            TxtExp.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            TxtDesmA.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            TxtDesmD.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            TxtScore.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            ValidarPermisos();
        }
        private async void Catacion_Load(object sender, EventArgs e)
        {
            PlCarga.Dock = DockStyle.Fill;
            //await CargarDatos();
            //Base.DiseñoDtvEliminar(ref dtInventarioCat);
            //Base.DiseñoEnvio(ref dtInventarioCat);
            PlCarga.Visible = false;
            CalcularDesmD();
        }
        private async Task CargarDatos()
        {
            try
            {
                await Task.Delay(1500);
                dtInventarioCat.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                MostrarLotes();
                ReiniciarPaginado();
                LlenarCheckBoxList();
                LblContador.Text = Contador.ToString();
                await Task.Delay(1000);
                dtInventarioCat.Columns["Proceso"].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error con el servidor", "Cerrando programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Dispose();
                Login lg = new Login();
                lg.ShowDialog();
            }
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
            Dcatacion funcion = new Dcatacion();
            if (Analizar != "Proceso")
            {
                DCompraD DC = new DCompraD();
                DC.Contar(ref Contador);
            }
            else
            {
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
        }
        private void Paginar()
        {
            try
            {
                lbl_Pagina.Text = (hasta / items_por_pagina).ToString();
                lbl_totalPaginas.Text = Math.Ceiling(Convert.ToSingle(Contador) / items_por_pagina).ToString();
                totalPaginas = Convert.ToInt32(lbl_totalPaginas.Text);
                LblContador.Text = Contador.ToString();
                //Base.DiseñoEnvio(ref dtInventarioCat);
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
                BuscarTK();
            }
            else if (CbBuscador.Visible == true)
            {
                BuscarDatos();
            }
            else if (PlFiltroFecha.Visible == true)
            {
                // BuscarRangoFecha();
            }
            else
            {
                MostrarLotes();
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
        private void btn_Sig_Click(object sender, EventArgs e)
        {
            desde += 100;
            hasta += 100;
            if (txtBuscador.Text != "")
            {
                BuscarTK();
            }
            else if (CbBuscador.Visible == true)
            {
                BuscarDatos();
            }
            else if (PlFiltroFecha.Visible == true)
            {
                // BuscarRangoFecha();
            }
            else
            {
                MostrarLotes();
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
                BuscarTK();
            }
            else if (CbBuscador.Visible == true)
            {
                BuscarDatos();
            }
            else if (PlFiltroFecha.Visible == true)
            {
                //BuscarRangoFecha();
            }
            else
            {
                MostrarLotes();
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
        private void btn_Primera_Click(object sender, EventArgs e)
        {
            ReiniciarPaginado();
            if (txtBuscador.Text != "")
            {
                BuscarTK();
            }
            else if (CbBuscador.Visible == true)
            {
                BuscarDatos();
            }
            else if (PlFiltroFecha.Visible == true)
            {
                //BuscarRangoFecha();
            }
            else
            {
                MostrarLotes();
            }
        }

        #endregion
        private void BuscarDatos()
        {
            DataTable dt = new DataTable();
            Dcatacion funcion = new Dcatacion();
            //funcion.BuscarTK(txtBuscador.Text, ref dt, desde, hasta, ContarBusqueda);
            funcion.BuscarCatacion(CbBuscador.Text, CbBuscar.Text, ref dt, desde, hasta, ContarBusqueda);
            dtInventarioCat.DataSource = dt;
            ContarBusqueda = int.Parse(funcion.Contador.ToString());
            //Base.DiseñoEnvio(ref dtInventarioCat);
        }
        private void BuscarTK()
        {
            DataTable dt = new DataTable();
            Dcatacion funcion = new Dcatacion();
            //funcion.BuscarTK(txtBuscador.Text, ref dt, desde, hasta, ContarBusqueda);
            funcion.BuscarCatacion(txtBuscador.Text, CbBuscar.Text, ref dt, desde, hasta, ContarBusqueda);
            dtInventarioCat.DataSource = dt;
            ContarBusqueda = int.Parse(funcion.Contador.ToString());
            //Base.DiseñoEnvio(ref dtInventarioCat);
        }
        public void MostrarLotes()
        {
            BtnMostrarCompras.Text = "Compras Directas";
            Dcatacion funcion = new Dcatacion();
            DataTable dt = new DataTable();
            funcion.MostrarCata(ref dt, desde, hasta);
            //ReiniciarPaginado();
            dtInventarioCat.DataSource = dt;
            //Base.DiseñoDtvEliminar(ref dtInventarioCat);
        }
        private void VerDetalleCatacion()
        {
            try
            {
                Dcatacion funcion = new Dcatacion();
                DataTable dt = new DataTable();
                funcion.VerDetalleCatacion(ref dt, Ticket);
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    if (dr["Ticket"].ToString() != null)
                    {
                        LblTicket.Text = dr["Ticket"].ToString();
                    }
                    else
                    {
                        LblTicket.Text = "--";
                    }
                    if (dr["Sacos"].ToString() != null)
                    {
                        LblSacos.Text = dr["Sacos"].ToString();
                    }
                    else
                    {
                        LblSacos.Text = "--";
                    }
                    if (dr["Peso"].ToString() != null)
                    {
                        LblPeso.Text = dr["Peso"].ToString();
                    }
                    else
                    {
                        LblPeso.Text = "--";
                    }
                    if (dr["QQs"].ToString() != null)
                    {
                        LblQQs.Text = dr["QQs"].ToString();
                    }
                    else
                    {
                        LblQQs.Text = "--";
                    }
                    if (dr["Calidad"].ToString() != null)
                    {
                        LblCalidad.Text = dr["Calidad"].ToString();
                    }
                    else
                    {
                        LblCalidad.Text = "--";
                    }
                    if (dr["Certificación"].ToString() != null)
                    {
                        LblCert.Text = dr["Certificación"].ToString();
                    }
                    else
                    {
                        LblCert.Text = "--";
                    }
                    if (dr["Estado Fisico"].ToString() != null)
                    {
                        LblEstFis.Text = dr["Estado Fisico"].ToString();
                    }
                    else
                    {
                        LblEstFis.Text = "--";
                    }
                    if (dr["Daño"].ToString() != null)
                    {
                        LblDanio.Text = dr["Daño"].ToString();
                    }
                    else
                    {
                        LblDanio.Text = "--";
                    }
                    if (dr["Cliente"].ToString() != null)
                    {
                        LblCliente.Text = dr["Cliente"].ToString();
                    }
                    else
                    {
                        LblCliente.Text = "--";
                    }
                    if (dr["AreaSecado"].ToString() != null)
                    {
                        LblProcedencia.Text = dr["AreaSecado"].ToString();
                    }
                    else
                    {
                        LblProcedencia.Text = "--";
                    }
                    FRecibido = DateTime.Parse(dr["FechaRecibido"].ToString());
                    if (dr["Fecha Muestra"] != DBNull.Value && !string.IsNullOrWhiteSpace(dr["Fecha Muestra"].ToString()))
                    {
                        FMuestra = DateTime.Parse(dr["Fecha Muestra"].ToString()).AddDays(1);
                        DTPFechaMuestra.Value = FMuestra;
                    }
                    else
                    {
                        FMuestra = DateTime.Today.AddDays(1);
                        DTPFechaMuestra.Value = FMuestra;
                    }

                    DtFechaCatacion.Value = DateTime.Today.Date;
                    CalculoDias();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos en controles" + ex.Message, "ERROR en Catación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtInventarioCat_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerTK();
            if (BtnMostrarCompras.Text == "Compras Directas")
            {
                PlDetalleCompra.Visible = false;
                PlDatosTk.Visible = true;
                //PlDatosTk.BringToFront();
                VerDetalleCatacion();
                TkDetalle = LblTicket.Text;
            }
            else
            {
                PlDatosTk.Visible = false;
                PlDetalleCompra.Visible = true;
                //PlDetalleCompra.BringToFront();
                VerDetalleCompra();
                TkDetalle = LblTKCD.Text;
                DTPFechaMuestra.Value = DateTime.Parse(LblFecha.Text);
            }
            AbrirFormulario();
            VerDetalleCata();
        }
        private void ObtenerTK()
        {
            string nombrecolumna = "Ticket";
            int indice = dtInventarioCat.Columns[nombrecolumna].Index;
            Ticket = dtInventarioCat.SelectedCells[indice].Value.ToString();

            if (BtnMostrarCompras.Text == "Compras Directas")
            {
                //string nombrecolum = "Ticket SM";
                //int num = dtInventarioCat.Columns[nombrecolum].Index;
                //TkSM = dtInventarioCat.SelectedCells[num].Value.ToString();

                string nombreEstado = "Proceso";
                int numEstado = dtInventarioCat.Columns[nombreEstado].Index;
                Proceso = dtInventarioCat.SelectedCells[numEstado].Value.ToString();

                string Est_Env = "EstadoFisico";
                int numEst = dtInventarioCat.Columns[Est_Env].Index;
                EstadoEnv = dtInventarioCat.SelectedCells[numEst].Value.ToString();
            }
            else
            {
                string nombreEstado = "Estado";
                int numEstado = dtInventarioCat.Columns[nombreEstado].Index;
                Proceso = dtInventarioCat.SelectedCells[numEstado].Value.ToString();
            }
        }
        private void TxtBto_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtBto.Text))
            {
                Bto = 0;
            }
            else
            {
                try
                {
                    Bto = double.Parse(TxtBto.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Por favor, introduce un número válido.");
                    TxtBto.Text = "0";
                    Bto = 0;
                }
            }

            Casc = 100 - Bto;
            LblCascarilla.Text = Casc.ToString();
            LblTotal.Text = (Casc + Bto).ToString();
            CalcularDesmD();
        }

        private void TxtDesmA_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtDesmA.Text))
            {
                DesmA = 0;
            }
            else
            {
                if (double.TryParse(TxtDesmA.Text, out double result))
                {
                    DesmA = result;
                }
                else
                {
                    // Manejar el caso donde el texto no se puede convertir a número
                    MessageBox.Show("Por favor, ingrese un número válido.");
                    TxtDesmA.Text = string.Empty; // Limpiar el TextBox en caso de error
                    return;
                }
            }

            CalcularDesmD();
            LblDesmAP.Text = Math.Round((Bto * DesmA) / 100, 2).ToString() + "%";
        }

        //private void TxtScore_TextChanged(object sender, EventArgs e)
        //{
        //    //if (TxtScore.Text == "")
        //    //{
        //    //    LblTasa.Text = "";
        //    //    LblGCalidad.Text = "";
        //    //}
        //    //else
        //    //{
        //    //    SeleccionarScore();
        //    //}
        //}
        //private void SeleccionarScore()
        //{
        //    Dcatacion funcion = new Dcatacion();
        //    int score = int.Parse(TxtScore.Text);
        //    funcion.SeleccionarScore(score, LblTasa, LblGCalidad);
        //}
        private void TxtHumedad_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtHumedad.Text))
            {
                Humedad = 0;
            }
            else
            {
                CultureInfo culture = new CultureInfo("en-US");

                if (double.TryParse(TxtHumedad.Text, NumberStyles.Any, culture, out double result))
                {
                    Humedad = result;
                }
                else
                {
                    // Manejar el caso donde el texto no se puede convertir a número
                    MessageBox.Show("Por favor, ingrese un número válido.");
                    TxtHumedad.Text = string.Empty;
                    return;
                }
            }

            if (Humedad >= 12.8)
            {
                ChbRechazado.Checked = true;
                ChbAnalizado.Enabled = false;
                CbGrupoCalidad.Text = "";
            }
            else
            {
                ChbRechazado.Checked = false;
                ChbAnalizado.Enabled = true;
            }
        }

        private void TxtDesmC_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtDesmD.Text))
            {
                DesmC = 0;
            }
            else
            {
                if (double.TryParse(TxtDesmD.Text, out double result))
                {
                    DesmC = result;
                }
                else
                {
                    // Manejar el caso donde el texto no se puede convertir a número
                    MessageBox.Show("Por favor, ingrese un número válido.");
                    TxtDesmD.Text = string.Empty; // Limpiar el TextBox en caso de error
                    return;
                }
            }

            CalcularDesmD();
            LblDesmDP.Text = Math.Round((Bto * DesmC) / 100, 2).ToString() + "%";
        }

        private void TxtExp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TxtExp.Text))
                {
                    Exp = 0;
                }
                else
                {
                    if (double.TryParse(TxtExp.Text, out double result))
                    {
                        Exp = result;
                    }
                    else
                    {
                        MessageBox.Show("Por favor, ingrese un número válido.");
                        TxtExp.Text = string.Empty;
                        return;
                    }
                }

                CalcularDesmD();
                LblExpP.Text = Math.Round((Bto * Exp) / 100, 2).ToString() + "%";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló el cálculo: " + ex.Message, "Error en Exp");
            }
        }

        private void CalcularDesmD()
        {
            double Exp = string.IsNullOrEmpty(TxtExp.Text) ? 0 : double.Parse(TxtExp.Text);
            double DesmA = string.IsNullOrEmpty(TxtDesmA.Text) ? 0 : double.Parse(TxtDesmA.Text);
            double DesmC = string.IsNullOrEmpty(TxtDesmD.Text) ? 0 : double.Parse(TxtDesmD.Text);

            double DesmD = Math.Round(100 - Exp - DesmA - DesmC, 2);
            LblDesmC.Text = DesmD.ToString();
            LblDesmCP.Text = Math.Round((Bto * DesmD) / 100, 2).ToString() + "%";
        }

        private void BtnCerrarPldatos_Click(object sender, EventArgs e)
        {
            PLDatos.Visible = false;
            dtInventarioCat.Enabled = true;
            plOpciones.Enabled = true;
            BtnAnalisis.Text = "Analizado";
            BtnActivar.Visible = false;
            Desactivar();
            Limpiar();
            ValidarPermisos();
        }
        private void AbrirFormulario()
        {
            // PLDatos.Size = new Size(1207, 622);
            //PLDatos.Location = new System.Drawing.Point(dtInventarioCat.Width / 2
            //    - PLDatos.Width / 2, dtInventarioCat.Height / 2 - PLDatos.Height / 3);
            // Obtenemos el tamaño del formulario actual
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

            PLDatos.Location = new System.Drawing.Point(newX, newY);

            PLDatos.Visible = true;
            PLDatos.BringToFront();
            plOpciones.Enabled = false;
            dtInventarioCat.Enabled = false;
            Dcatacion funcion = new Dcatacion();
            funcion.MostrarVariedad(CbVariedad);
            string calidad = LblCalidad.Text;
            if (calidad.EndsWith("UA"))
            {
                funcion.MostrarGrupoCalidadUA(CbGrupoCalidad);
            }
            else
            {
                funcion.MostrarGCalidad(CbGrupoCalidad);
            }
            funcion.MostrarTasas(CbTasa);
            Analisis();
            if (Proceso != "Almacén" && Proceso != "Analizado" && Proceso != "Envio")
            {
                Activar();
            }
            else
            {
                if (EstadoEnv == "Pre-Seco")
                {
                    Activar();
                }
                else
                {
                    Desactivar();
                }
            }

            MostrarCambiarTK();
            TxtBto.Focus();
        }
        private void Analisis()
        {
            string ticketText = LblTicket.Text;
            if (Analizar == "Proceso")
            {
                // Verifica si el ticket contiene "-Parte1" o "-Parte2"
                if (ticketText.Contains("-Parte1") || ticketText.Contains("-Parte2"))
                {
                    // Utiliza Regex para extraer la parte después de "24/25-"
                    string pattern = @"24\/25-(\w+)-";
                    Match match = Regex.Match(ticketText, pattern);

                    if (match.Success)
                    {
                        // Si se encuentra una coincidencia, establece el texto extraído
                        TxtAnalisis.Text = match.Groups[1].Value;
                    }
                    else
                    {
                        // Si no se encuentra una coincidencia, muestra un mensaje de error
                        TxtAnalisis.Text = "No se encontró una coincidencia válida.";
                    }
                }
                else
                {
                    // Si no lo contiene, muestra el ticket completo
                    TxtAnalisis.Text = ticketText;
                }

            }
            else
            {
                TxtAnalisis.Text = LblTKCD.Text;
            }
        }
        private void ChbRechazado_CheckedChanged(object sender, EventArgs e)
        {
            if (ChbRechazado.Checked == true)
            {
                ChbAnalizado.Enabled = false;
                BtnAnalisis.Enabled = true;
                ChbAnalizado.Checked = false;
                //TxtAnalisis.Text = "# Analisis";
                TxtBto.Text = "0";
                TxtExp.Text = "0";
                TxtDesmA.Text = "0";
                TxtDesmD.Text = "0";
                TxtScore.Text = "0";
            }
            else
            {
                ChbAnalizado.Enabled = true;
                BtnAnalisis.Enabled = false;
            }
        }
        private void ChbAnalizado_CheckedChanged(object sender, EventArgs e)
        {
            if (ChbAnalizado.Checked == true)
            {
                ChbRechazado.Enabled = false;
                BtnAnalisis.Enabled = true;
                ChbRechazado.Checked = false;
            }
            else
            {
                ChbRechazado.Enabled = true;
                BtnAnalisis.Enabled = false;
            }
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Obtener el TextBox que disparó el evento
            TextBox textBox = sender as TextBox;

            // Comprobar si la tecla presionada es un número, un punto o un carácter de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true; // Si no es ninguno de los permitidos, cancela el evento
            }

            // Permitir solo un punto decimal
            if ((e.KeyChar == '.') && (textBox.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void Limpiar()
        {
            TxtAnalisis.Clear();
            LblDias.Text = "--";
            TxtBto.Text = "";
            TxtHumedad.Text = "";
            TxtExp.Text = "0";
            TxtDesmA.Text = "0";
            TxtDesmD.Text = "0";
            TxtScore.Clear();
            ChbAnalizado.Checked = false;
            ChbRechazado.Checked = false;
            TkDetalle = null;
        }
        private void BtnAnalisis_Click(object sender, EventArgs e)
        {
            DialogResult res;
            if (Validar())
            {
                if (Analizar == "Proceso")
                {
                    if (BtnAnalisis.Text == "Re-Analizar" || BtnAnalisis.Text == "Editar Análisis")
                    {
                        EditarCatacionCD();
                        Task.Delay(3000);
                        MostrarLotes();
                        Desactivar();
                    }
                    else
                    {
                        // Crear el mensaje con los datos
                        string mensaje = $"Verifique los datos antes de proceder:\n" +
                                         $"- Ticket: {LblTicket.Text}\n" +
                                         $"- Analisis: {TxtAnalisis.Text}\n" +
                                         $"- Rendimineto Oro Bruto: {TxtBto.Text}\n" +
                                         $"- Cascarilla: {LblCascarilla.Text}\n" +
                                         $"- Total PS: {LblTotal.Text}\n" +
                                         $"- Variedad: {CbVariedad.Text}\n" +
                                         $"- Humedad: {TxtHumedad.Text}\n" +
                                         $"- Exp: {TxtExp.Text}\n" +
                                         $"- DesmA: {TxtDesmA.Text}\n" +
                                         $"- DesmD: {TxtDesmD.Text}\n" +
                                         $"- DesmC: {LblDesmC.Text}\n" +
                                         $"- Score: {TxtScore.Text}\n" +
                                         $"- Quality Grade: {CbGrupoCalidad.Text}\n" +
                                         $"- Taza: {CbTasa.Text}\n";

                        // Mostrar el mensaje y esperar la confirmación del usuario
                        res = MessageBox.Show(mensaje, "Confirmar Edición", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (res == DialogResult.Yes)
                        {
                            InsertarCatacion();
                            Task.Delay(3000);
                            MostrarLotes();
                            Desactivar();
                        }
                        else
                        {
                            Activar();
                        }
                    }
                }
                else
                {
                    if (BtnAnalisis.Text == "Re-Analizar" || BtnAnalisis.Text == "Editar Análisis")
                    {
                        EditarCatacionCD();
                        Task.Delay(3000);
                        MostrarComprasD();
                        Desactivar();
                    }
                    else
                    {
                        InsertarCatacionCD();
                        Task.Delay(3000);
                        MostrarComprasD();
                        Desactivar();
                    }
                }
            }
            else
            {
                MessageBox.Show("Existen campos vacíos", "ERROR campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dtInventarioCat.Enabled = true;
            plOpciones.Enabled = true;
        }
        private void InsertarCatacionCD()
        {
            if (Validar())
            {
                if (DtFechaCatacion.Value.Date <= DateTime.Today.Date)
                {

                    LCatacion parametros = new LCatacion();
                    Dcatacion funcion = new Dcatacion();
                    parametros.Ticket = LblTKCD.Text;
                    parametros.Origen = "Compra Directa";
                    parametros.Analisis = TxtAnalisis.Text;
                    parametros.FechaMuestra = DTPFechaMuestra.Value;
                    parametros.FechaCatacion = DateTime.Today;
                    parametros.Dias = int.Parse(LblDias.Text);
                    parametros.RmtoObto = TxtBto.Text;
                    parametros.Cascarilla = LblCascarilla.Text;
                    parametros.TotalPS = LblTotal.Text;
                    parametros.IdVariedad = (int)CbVariedad.SelectedValue;
                    parametros.Humedad = TxtHumedad.Text;
                    parametros.Exp = double.Parse(TxtExp.Text);
                    parametros.DesmA = double.Parse(TxtDesmA.Text);
                    parametros.DesmD = double.Parse(TxtDesmD.Text);
                    parametros.DesmC = double.Parse(LblDesmC.Text);
                    parametros.Score = int.Parse(TxtScore.Text);
                    //parametros.Tasa = LblTasa.Text;
                    parametros.GradoCalidad = CbGrupoCalidad.Text;
                    parametros.ExpP = LblExpP.Text;
                    parametros.DesmAP = LblDesmAP.Text;
                    parametros.DesmCP = LblDesmCP.Text;
                    parametros.DesmDP = LblDesmDP.Text;
                    parametros.Digitador = Login.NombreA;
                    parametros.PesoRecibido = double.Parse(LblPeso.Text);
                    if (ChbRechazado.Checked == true)
                    {
                        parametros.Estado = "0";
                    }
                    else if (ChbAnalizado.Checked == true)
                    {
                        parametros.Estado = "1";
                    }
                    else
                    {
                        parametros.Estado = "1";
                    }
                    if (funcion.InsertarCatacionCD(parametros) == true)
                    {
                        PLDatos.Visible = false;
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Error en los datos", "Error en interfaz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void BtnCerrarCambioTK_Click(object sender, EventArgs e)
        {
            PlCambioTK.Visible = false;
            PLDatos.Enabled = true;
            TxtTkNueva.Clear();
        }
        private void BtnCambioTK_Click(object sender, EventArgs e)
        {
            EditarTKAnalisis();
            MostrarLotes();
        }
        private void BtnActivar_Click(object sender, EventArgs e)
        {
            Activar();
            BtnAnalisis.Visible = true;
            BtnAnalisis.Text = "Editar Análisis";
        }
        private void Activar()
        {
            TxtAnalisis.Enabled = true;
            //DtFechaCatacion.Enabled = true;
            //DTPFechaMuestra.Enabled = true;
            TxtBto.Enabled = true;
            CbVariedad.Enabled = true;
            TxtHumedad.Enabled = true;
            TxtExp.Enabled = true;
            TxtDesmA.Enabled = true;
            TxtDesmD.Enabled = true;
            TxtScore.Enabled = true;
            BtnAnalisis.Enabled = true;
            ChbAnalizado.Enabled = true;
            ChbRechazado.Enabled = true;
            CbGrupoCalidad.Enabled = true;
            CbTasa.Enabled = true;
        }
        private void Desactivar()
        {
            TxtAnalisis.Enabled = false;
            DtFechaCatacion.Enabled = false;
            DTPFechaMuestra.Enabled = false;
            TxtBto.Enabled = false;
            CbVariedad.Enabled = false;
            TxtHumedad.Enabled = false;
            TxtExp.Enabled = false;
            TxtDesmA.Enabled = false;
            TxtDesmD.Enabled = false;
            TxtScore.Enabled = false;
            BtnAnalisis.Text = "Analizado";
            BtnAnalisis.Enabled = false;
            ChbAnalizado.Enabled = false;
            ChbRechazado.Enabled = false;
            CbGrupoCalidad.Enabled = false;
            CbTasa.Enabled = false;
        }
        private void InsertarCatacion()
        {
            if (Validar())
            {
                if (DtFechaCatacion.Value.Date <= DateTime.Today.Date)
                {
                    LCatacion parametros = new LCatacion();
                    Dcatacion funcion = new Dcatacion();
                    parametros.Ticket = LblTicket.Text;
                    parametros.Origen = LblProcedencia.Text;
                    parametros.Analisis = TxtAnalisis.Text;
                    parametros.FechaMuestra = DTPFechaMuestra.Value;
                    parametros.FechaCatacion = DateTime.Today;
                    parametros.Dias = int.Parse(LblDias.Text);
                    parametros.RmtoObto = TxtBto.Text;
                    parametros.Cascarilla = LblCascarilla.Text;
                    parametros.TotalPS = LblTotal.Text;
                    parametros.IdVariedad = (int)CbVariedad.SelectedValue;
                    parametros.Humedad = TxtHumedad.Text;
                    parametros.Exp = double.Parse(TxtExp.Text);
                    parametros.DesmA = double.Parse(TxtDesmA.Text);
                    parametros.DesmC = double.Parse(LblDesmC.Text);
                    parametros.DesmD = double.Parse(TxtDesmD.Text);
                    parametros.Score = int.Parse(TxtScore.Text);
                    parametros.Tasa = CbTasa.Text;
                    parametros.GradoCalidad = CbGrupoCalidad.Text;
                    parametros.ExpP = LblExpP.Text;
                    parametros.DesmAP = LblDesmAP.Text;
                    parametros.DesmCP = LblDesmCP.Text;
                    parametros.DesmDP = LblDesmDP.Text;
                    parametros.Digitador = Login.NombreA;
                    parametros.PesoRecibido = double.Parse(LblPeso.Text);
                    if (ChbRechazado.Checked == true)
                    {
                        parametros.Estado = "0";
                    }
                    else if (ChbAnalizado.Checked == true)
                    {
                        parametros.Estado = "1";
                    }
                    else
                    {
                        parametros.Estado = "1";
                    }
                    if (funcion.InsertarCatacion(parametros) == true)
                    {
                        PLDatos.Visible = false;
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Error en los datos", "Error en interfaz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("La fecha de recibido no puede ser mayor a la fecha de dia de hoy", "Error en la fecha", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private async void BtnMostrarCompras_Click(object sender, EventArgs e)
        {
            PlCarga.Dock = DockStyle.Fill;
            PlCarga.Visible = true;
            await Task.Delay(1500);
            ReiniciarPaginado();
            if (BtnMostrarCompras.Text == "Compras Directas")
            {
                Analizar = "Compras";
                MostrarComprasD();
            }
            else
            {
                Analizar = "Proceso";
                MostrarLotes();
            }
            ReiniciarPaginado();
            PlCarga.Visible = false;
            await Task.Delay(1000);
        }
        private void EditarCatacion()
        {
            if (Validar())
            {
                LCatacion parametros = new LCatacion();
                Dcatacion funcion = new Dcatacion();
                parametros.Ticket = LblTicket.Text;
                parametros.Origen = LblProcedencia.Text;
                parametros.Analisis = TxtAnalisis.Text;
                parametros.FechaMuestra = DTPFechaMuestra.Value;
                parametros.FechaCatacion = DateTime.Today;
                parametros.Dias = int.Parse(LblDias.Text);
                parametros.RmtoObto = TxtBto.Text;
                parametros.Cascarilla = LblCascarilla.Text;
                parametros.TotalPS = LblTotal.Text;
                parametros.IdVariedad = (int)CbVariedad.SelectedValue;
                parametros.Humedad = TxtHumedad.Text;
                parametros.Exp = double.Parse(TxtExp.Text);
                parametros.DesmA = double.Parse(TxtDesmA.Text);
                parametros.DesmC = double.Parse(TxtDesmD.Text);
                parametros.DesmD = double.Parse(LblDesmC.Text);
                parametros.Score = int.Parse(TxtScore.Text);
                parametros.Tasa = CbTasa.Text;
                //parametros.GradoCalidad = LblGCalidad.Text;
                parametros.ExpP = LblExpP.Text;
                parametros.DesmAP = LblDesmAP.Text;
                parametros.DesmCP = LblDesmCP.Text;
                parametros.DesmDP = LblDesmDP.Text;
                parametros.Digitador = Login.NombreA;

                if (ChbRechazado.Checked == true)
                {
                    parametros.Estado = "0";
                }
                else if (ChbAnalizado.Checked == true)
                {
                    parametros.Estado = "1";
                }
                else
                {
                    parametros.Estado = "1";
                }

                if (funcion.EditarCatacion(parametros, Idcatacion) == true)
                {
                    PLDatos.Visible = false;
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Error en los datos", "Error en interfaz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void EditarCatacionCD()
        {
            if (Validar())
            {
                if (DtFechaCatacion.Value.Date <= DateTime.Today.Date)
                {
                    LCatacion parametros = new LCatacion();
                    Dcatacion funcion = new Dcatacion();
                    parametros.Origen = LblProcedencia.Text;
                    parametros.Analisis = TxtAnalisis.Text;
                    parametros.FechaMuestra = DTPFechaMuestra.Value;
                    parametros.FechaCatacion = DateTime.Today;
                    parametros.Dias = int.Parse(LblDias.Text);
                    parametros.RmtoObto = TxtBto.Text;
                    parametros.Cascarilla = LblCascarilla.Text;
                    parametros.TotalPS = LblTotal.Text;
                    parametros.IdVariedad = (int)CbVariedad.SelectedValue;
                    parametros.Humedad = TxtHumedad.Text;
                    parametros.Exp = double.Parse(TxtExp.Text);
                    parametros.DesmA = double.Parse(TxtDesmA.Text);
                    parametros.DesmC = double.Parse(LblDesmC.Text);
                    parametros.DesmD = double.Parse(TxtDesmD.Text);
                    parametros.Score = int.Parse(TxtScore.Text);
                    parametros.Tasa = CbTasa.Text;
                    parametros.GradoCalidad = CbGrupoCalidad.Text;
                    parametros.ExpP = LblExpP.Text;
                    parametros.DesmAP = LblDesmAP.Text;
                    parametros.DesmCP = LblDesmCP.Text;
                    parametros.DesmDP = LblDesmDP.Text;
                    parametros.Digitador = Login.NombreA;
                    parametros.PesoRecibido = double.Parse(LblPeso.Text);
                    if (ChbRechazado.Checked == true)
                    {
                        parametros.Estado = "0";
                    }
                    else if (ChbAnalizado.Checked == true)
                    {
                        parametros.Estado = "1";
                    }
                    else
                    {
                        parametros.Estado = "1";
                    }

                    if (funcion.EditarCatacionCD(parametros, LblTicket.Text) == true)
                    {
                        DateTime FEdicion = DateTime.Now;
                        MSJ(Ticket, TxtAnalisis.Text, FEdicion, Rendimiento, Quality);
                        MessageBox.Show("Registro editado con Exito", "Editar Analisis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        PLDatos.Visible = false;
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Error en los datos", "Error en interfaz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("La fecha de recibido no puede ser mayor a la fecha de dia de hoy", "Error en la fecha", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        private async void MSJ(string TK, string Analisis, DateTime Fecha, string Rendimiento, string Quality)
        {
            try
            {
                string texto = "<html>" +
              "<body style='font-family: Arial, sans-serif; line-height: 1.6; color: #333;'>" +
              "<h2 style='color: #0056b3;'>Notificación de Cambios en la Ticket " + TK + "</h2>" +
              "<p>Modificaciones hechas por: <b>" + Login.NombreA + "</b>,</p>";

                if (Rendimiento != TxtBto.Text && Quality != CbGrupoCalidad.Text)
                {
                    texto += "<p>Se han realizado los siguientes cambios en la Ticket <b>" + TK + "</b>:</p>" +
                            "<p><b>Rendimiento:</b> de <span style='color: #d9534f;'>" + Rendimiento + "</span> a <span style='color: #5cb85c;'>" + TxtBto.Text + "</span></p>" +
                            "<p><b>Quality Grade:</b> de <span style='color: #d9534f;'>" + Quality + "</span> a <span style='color: #5cb85c;'>" + CbGrupoCalidad.Text + "</span></p>";
                }
                else if (Rendimiento != TxtBto.Text)
                {
                    texto += "<p>Se ha realizado el siguiente cambio en la Ticket <b>" + TK + "</b>:</p>" +
                            "<p><b>Rendimiento:</b> de <span style='color: #d9534f;'>" + Rendimiento + "</span> a <span style='color: #5cb85c;'>" + TxtBto.Text + "</span></p>";
                }
                else if (Quality != CbGrupoCalidad.Text)
                {
                    texto += "<p>Se ha realizado el siguiente cambio en la Ticket <b>" + TK + "</b>:</p>" +
                            "<p><b>Quality Grade:</b> de <span style='color: #d9534f;'>" + Quality + "</span> a <span style='color: #5cb85c;'>" + CbGrupoCalidad.Text + "</span></p>";
                }

                texto += "<p>Este cambio fue realizado el día <b>" + Fecha + "</b>.</p>" +
    "<hr style='border: 0; border-top: 1px solid #ccc;' />" +
    "<p>Saludos cordiales,<br>Equipo de Soporte<br>" +
    "<b>" +
    "<span style='font-size: 20px; font-weight: bold; color: rgb(135, 0, 100);'>Dry</span> " +
    "<span style='font-size: 20px; font-weight: bold; color: rgb(248, 141, 0);'>System</span> " +
    "ofi Sistema de seguimiento de lotes" +
    "</b></p>" +
    "</body>" +
    "</html>";


                // Si hay un mensaje, realizar acción
                if (!string.IsNullOrEmpty(texto))
                {
                    // Mostrar el mensaje en pantalla
                    // MessageBox.Show(texto, "Envio de Correo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Enviar el mensaje por correo
                    await EnviarCorreoNotificacion(texto);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Ha ocurrido un error al enviar el correo de edición. " + ex.Message, "Error en el correo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Ha ocurrido un error al enviar el correo de edición. " + ex.Message);
            }
        }

        private async Task EnviarCorreoNotificacion(string mensaje)
        {
            try
            {
                // Crear una lista con el destinatario (puedes agregar más correos si lo necesitas)
                //List<string> destinatarios = new List<string> { "lfelixlopez732@gmail.com" };

                // Definir asunto y cuerpo del correo
                string asunto = "Dry System ofi Sistema de seguimiento de lotes: Notificación de Cambios";
                string cuerpo = mensaje;

                // Llamar al método enviarCorreo de la clase Recuperacion
                //Recuperacion rec = new Recuperacion();
                //rec.enviarCorreo(asunto, cuerpo, destinatarios);

                var mailservice = new DCorreoSoporte();
                mailservice.enviarCorreo(
                    subject: asunto,
                    body: cuerpo,
                    destinatarioCorreo: new List<string> { "lfelixlopez732@gmail.com" });
                // MessageBox.Show("Correo enviado exitosamente.", "Envio de Correo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el correo: " + ex.Message, "Error en el correo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DTPFechaMuestra_ValueChanged(object sender, EventArgs e)
        {
            CalculoDias();
        }

        private void DtFechaCatacion_ValueChanged(object sender, EventArgs e)
        {
            CalculoDias();
        }

        private bool Validar()
        {
            double entero;
            if (!double.TryParse(TxtBto.Text, out entero) || (!double.TryParse(TxtHumedad.Text, out entero)))
            {
                return false;
            }
            return !(TxtAnalisis.Text == "" ||
                TxtBto.Text == "" || TxtDesmA.Text == ""
            || TxtDesmD.Text == "" || TxtScore.Text == "" || TxtExp.Text == "" || TxtHumedad.Text == "");
        }

        private async void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (Analizar == "Proceso")
            {
                await CargarDatos();
            }
            else
            {
                MostrarComprasD();
                ReiniciarPaginado();
            }
            MessageBox.Show("Datos Actualizados", "Refrescar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void PbExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Dcatacion funcion = new Dcatacion();
            funcion.ExcelCatacion(ref dt);
            string Nombre = "Inventario Catación";
            FrmLotes_Tendido LT = new FrmLotes_Tendido(dt, Nombre);
            LT.ShowDialog();
        }

        private void VerDetalleCata()
        {
            Dcatacion funcion = new Dcatacion();
            DataTable dt = new DataTable();
            try
            {
                funcion.VerDetalleCata(ref dt, TkDetalle);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    if (row["Analisis"].ToString() != null)
                    {
                        TxtAnalisis.Text = row["Analisis"].ToString();
                    }
                    else
                    {
                        TxtAnalisis.Clear();
                    }
                    if (DateTime.Parse(row["FechaMuestra"].ToString()) != null)
                    {
                        DTPFechaMuestra.Value = DateTime.Parse(row["FechaMuestra"].ToString());
                    }
                    else
                    {
                        DTPFechaMuestra.Value = DateTime.Today;
                    }
                    if (DateTime.Parse(row["FechaCatacion"].ToString()) != null)
                    {
                        DtFechaCatacion.Value = DateTime.Parse(row["FechaCatacion"].ToString());
                    }
                    else
                    {
                        DtFechaCatacion.Value = DateTime.Today;
                    }
                    if (row["Dias"].ToString() != null)
                    {
                        LblDias.Text = row["Dias"].ToString();
                    }
                    else
                    {
                        LblDias.Text = "--";
                    }
                    // Asignar el valor de Cat.RmtoObto
                    if (row["RmtoObto"] != DBNull.Value && row["RmtoObto"].ToString() != null)
                    {
                        TxtBto.Text = row["RmtoObto"].ToString();
                        Rendimiento = TxtBto.Text;
                    }
                    else
                    {
                        TxtBto.Clear();
                    }

                    // Asignar el valor de Cat.Cascarilla
                    if (row["Cascarilla"] != DBNull.Value && row["Cascarilla"].ToString() != null)
                    {
                        LblCascarilla.Text = row["Cascarilla"].ToString();
                    }
                    else
                    {
                        LblCascarilla.Text = "--";
                    }

                    // Asignar el valor de Cat.TotalPS
                    if (row["TotalPS"] != DBNull.Value && row["TotalPS"].ToString() != null)
                    {
                        LblTotal.Text = row["TotalPS"].ToString();
                    }
                    else
                    {
                        LblTotal.Text = "--";
                    }

                    // Asignar el valor de Var.Variedad
                    if (row["Variedad"] != DBNull.Value && row["Variedad"].ToString() != null)
                    {
                        CbVariedad.Text = row["Variedad"].ToString();
                    }
                    else
                    {
                        CbVariedad.Text = "--";
                    }

                    // Asignar el valor de Cat.Humedad
                    if (row["Humedad"] != DBNull.Value && row["Humedad"].ToString() != null)
                    {
                        TxtHumedad.Text = row["Humedad"].ToString();
                    }
                    else
                    {
                        TxtHumedad.Clear();
                    }

                    // Asignar el valor de Cat.Exp
                    if (row["Exp"] != DBNull.Value && row["Exp"].ToString() != null)
                    {
                        TxtExp.Text = row["Exp"].ToString();
                    }
                    else
                    {
                        TxtExp.Clear();
                    }

                    // Asignar el valor de Cat.DesmA
                    if (row["DesmA"] != DBNull.Value && row["DesmA"].ToString() != null)
                    {
                        TxtDesmA.Text = row["DesmA"].ToString();
                    }
                    else
                    {
                        TxtDesmA.Clear();
                    }

                    // Asignar el valor de Cat.DesmC
                    if (row["DesmC"] != DBNull.Value && row["DesmC"].ToString() != null)
                    {
                        LblDesmC.Text = row["DesmC"].ToString();
                    }
                    else
                    {
                        LblDesmC.Text = "--";
                    }

                    // Asignar el valor de Cat.DesmD
                    if (row["DesmD"] != DBNull.Value && row["DesmD"].ToString() != null)
                    {
                        TxtDesmD.Text = row["DesmD"].ToString();
                    }
                    else
                    {
                        TxtDesmD.Clear();
                    }

                    // Asignar el valor de Cat.DesmAP
                    if (row["DesmAP"] != DBNull.Value && row["DesmAP"].ToString() != null)
                    {
                        LblDesmAP.Text = row["DesmAP"].ToString();
                    }
                    else
                    {
                        LblDesmAP.Text = "--";
                    }

                    // Asignar el valor de Cat.DesmCP
                    if (row["DesmCP"] != DBNull.Value && row["DesmCP"].ToString() != null)
                    {
                        LblDesmCP.Text = row["DesmCP"].ToString();
                    }
                    else
                    {
                        LblDesmCP.Text = "--";
                    }

                    // Asignar el valor de Cat.DesmDP
                    if (row["DesmDP"] != DBNull.Value && row["DesmDP"].ToString() != null)
                    {
                        LblDesmDP.Text = row["DesmDP"].ToString();
                    }
                    else
                    {
                        LblDesmDP.Text = "--";
                    }

                    // Asignar el valor de Cat.ExpP
                    if (row["ExpP"] != DBNull.Value && row["ExpP"].ToString() != null)
                    {
                        LblExpP.Text = row["ExpP"].ToString();
                    }
                    else
                    {
                        LblExpP.Text = "--";
                    }

                    // Asignar el valor de Cat.Score
                    if (row["Score"] != DBNull.Value && row["Score"].ToString() != null)
                    {
                        TxtScore.Text = row["Score"].ToString();
                    }
                    else
                    {
                        TxtScore.Clear();
                    }

                    //Asignar el valor de Cat.Taza 'Tasa'
                    if (row["Tasa"] != DBNull.Value && row["Tasa"].ToString() != null)
                    {
                        CbTasa.Text = row["Tasa"].ToString();
                    }
                    else
                    {
                        CbTasa.Text = "--";
                    }

                    // Asignar el valor de Cat.GradoCalidad
                    if (row["GradoCalidad"] != DBNull.Value && row["GradoCalidad"].ToString() != null)
                    {
                        CbGrupoCalidad.Text = row["GradoCalidad"].ToString();
                        Quality = CbGrupoCalidad.Text;
                    }
                    else
                    {
                        //LblGCalidad.Text = "--";
                        CbGrupoCalidad.Text = "--";
                    }
                    if (row["Estado"] != DBNull.Value && row["Estado"].ToString() != null)
                    {
                        Estado = Boolean.Parse(row["Estado"].ToString());
                        if (Estado == true)
                        {
                            ChbAnalizado.Checked = true;
                            BtnAnalisis.Enabled = false;
                            if (BtnAnalisis.Text == "Re-Analizar")
                            {
                                BtnAnalisis.Enabled = true;
                            }
                        }
                        else if (Estado == false)
                        {
                            ChbRechazado.Checked = true;
                            BtnAnalisis.Text = "Re-Analizar";
                        }
                        else
                        {
                            ChbRechazado.Checked = false;
                            ChbAnalizado.Checked = false;
                        }
                    }
                    CalculoDias();
                    Idcatacion = int.Parse(row["IdCatacion"].ToString());
                    BtnActivar.Visible = true;
                    //Desactivar();
                    //else
                    //{
                    //    Estado = false;
                    //}
                }
                else
                {
                    BtnAnalisis.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error en cargar datos interfaz", "Error en datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarColumnas();
            PlFiltros.Visible = false;
        }
        private void FiltrarColumnas()
        {
            foreach (DataGridViewColumn column in dtInventarioCat.Columns)
            {
                if (filtro.Any(f => column.Name.Contains(f)))
                {
                    column.Visible = false;
                }
                else
                {
                    column.Visible = true;
                }
            }
        }
        private void CLBFiltros_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string seleccion = CLBFiltros.Items[e.Index].ToString();
            if (e.NewValue == CheckState.Checked)
            {
                filtro.Add(seleccion);
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                filtro.Remove(seleccion);
            }
        }

        private void PbFiltro_Click(object sender, EventArgs e)
        {
            LlenarCheckBoxList();
            PlFiltros.Location = new Point(this.Width / 2
               - PlFiltros.Width / 2, this.Height / 2 - PlFiltros.Height / 2);
            PlFiltros.Visible = true;
            PlFiltros.BringToFront();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            PlFiltros.Visible = false;
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            //Task.Delay(3000);
            //BuscarTK();
            //ReiniciarPaginado();
        }

        private void CbBuscador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbBuscador.Text == "")
            {
                ReiniciarPaginado();
                MostrarLotes();
            }
            else
            {
                BuscarDatos();
                ReiniciarPaginado();
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
            else if (CbBuscar.Text == "Tipo Compra")
            {
                TextBuscarVisible();
                funcion.MostrarCompra(CbBuscador);
            }
            else if (CbBuscar.Text == "Área Secado")
            {
                TextBuscarVisible();
                funcion.MostrarAreaSecado(CbBuscador);
            }
        }

        private void BtnCambiarTK_Click(object sender, EventArgs e)
        {
            PlCambioTK.Size = new Size(457, 229);
            PlCambioTK.Location = new System.Drawing.Point(dtInventarioCat.Width / 2
                - PlCambioTK.Width / 2, dtInventarioCat.Height / 2 - PlCambioTK.Height / 2);
            PlCambioTK.Visible = true;
            PlCambioTK.BringToFront();
            PLDatos.Enabled = false;
            LblTK.Text = LblTicket.Text;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Task.Delay(3000);
            BuscarTK();
            ReiniciarPaginado();
            txtBuscador.Focus();
        }

        private void BtnSplit_Click(object sender, EventArgs e)
        {
            if (TxtBto.Text == "")
            {
                Dcatacion funcion = new Dcatacion();
                if (funcion.CambioCatacion(LblProcedencia.Text, LblTicket.Text))
                {
                    MessageBox.Show("Registro editado con Exito", "Cambio de proceso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    PLDatos.Visible = false;
                    dtInventarioCat.Enabled = true;
                    plOpciones.Enabled = true;
                    BtnAnalisis.Text = "Analizado";
                    BtnActivar.Visible = false;
                    Desactivar();
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Error en los datos", "Error en interfaz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("No se puede cambiar el proceso", "Error con cambioCatacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void FormatCellBasedOnProceso(DataGridView dataGridView, DataGridViewCellFormattingEventArgs e)
        {
            // Obtener los valores de las columnas relevantes
            string columnName = dataGridView.Columns[e.ColumnIndex].Name;

            // Verificar si la columna es "Proce"
            if (columnName == "Proce")
            {
                // Obtener el valor de la celda actual
                string cellValue = e.Value as string;

                // Verificar si el valor de la celda cumple las condiciones para formatear la fila
                if (!string.IsNullOrEmpty(cellValue) &&
                    (cellValue.Equals("Almacén", StringComparison.OrdinalIgnoreCase) ||
                     cellValue.Equals("Analizado", StringComparison.OrdinalIgnoreCase) ||
                     cellValue.Equals("Envio", StringComparison.OrdinalIgnoreCase) ||
                     cellValue.Equals("Envío", StringComparison.OrdinalIgnoreCase) ||
                     cellValue.Equals("Enviado", StringComparison.OrdinalIgnoreCase)))
                {
                    // Formatear toda la fila con fondo amarillo y letras rojas
                    dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                    dataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    // Restablecer el estilo de las filas que no cumplen la condición
                    dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    dataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            }

            // Verificar si la columna es "Est_Envio"
            if (columnName == "Est_Envio")
            {
                // Obtener el valor de la celda actual
                string cellValue = e.Value as string;

                if (!string.IsNullOrEmpty(cellValue) && cellValue.Equals("Pre-Seco", StringComparison.OrdinalIgnoreCase))
                {
                    // Cambiar el color de fondo y el color de fuente de la celda actual
                    e.CellStyle.BackColor = Color.Green;
                    e.CellStyle.ForeColor = Color.White;
                }
                else
                {
                    // Restablecer el estilo predeterminado de la celda
                    e.CellStyle.BackColor = dataGridView.DefaultCellStyle.BackColor;
                    e.CellStyle.ForeColor = dataGridView.DefaultCellStyle.ForeColor;
                }
            }
        }


        // Llama al método desde el evento CellFormatting
        private void dtInventarioCat_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            FormatCellBasedOnProceso(dtInventarioCat, e);
        }

        private void CalculoDias()
        {
            DateTime fechaActual = DtFechaCatacion.Value;
            TimeSpan diferencia = fechaActual.Subtract(DTPFechaMuestra.Value);
            int diasDiferencia = (int)diferencia.TotalDays;
            LblDias.Text = diasDiferencia.ToString();
        }
        private void MostrarCambiarTK()
        {
            // Obtener el texto del Label
            string labelText = LblTicket.Text;

            // Verificar si el texto finaliza con "-Parte" seguido de un número
            if (System.Text.RegularExpressions.Regex.IsMatch(labelText, @"-Parte\d+$"))
            {
                // Mostrar el botón BtnCambiarTK
                BtnCambiarTK.Visible = true;
            }
            else
            {
                // Ocultar el botón BtnCambiarTK
                BtnCambiarTK.Visible = false;
            }
        }
        private void EditarTKAnalisis()
        {
            if (!string.IsNullOrEmpty(TxtTkNueva.Text))
            {
                Dcatacion funcion = new Dcatacion();
                if (funcion.EditarTKAnalisis(LblTK.Text, TxtTkNueva.Text) == true)
                {
                    MessageBox.Show("Se editó con éxito", "Editar Ticket", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PlCambioTK.Visible = false;
                    PLDatos.Enabled = true;
                    LblTicket.Text = TxtTkNueva.Text;
                    TxtTkNueva.Clear();
                }
            }
        }
        private void MostrarComprasD()
        {
            BtnMostrarCompras.Text = "Análisis";
            DCompraD funcion = new DCompraD();
            DataTable dt = new DataTable();
            funcion.MostrarComprasD(ref dt, desde, hasta);
            //ReiniciarPaginado();
            dtInventarioCat.DataSource = dt;
        }
        private void VerDetalleCompra()
        {
            DCompraD funcion = new DCompraD();
            DataTable dt = new DataTable();
            try
            {
                funcion.VerdetalleCompraD(ref dt, Ticket);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    if (row["Cosecha"].ToString() != null)
                    {
                        LblCosecha.Text = row["Cosecha"].ToString();
                    }
                    else
                    {
                        LblCosecha.Text = "--";
                    }
                    if (DateTime.TryParse(row["Fecha"].ToString(), out DateTime fecha))
                    {
                        LblFecha.Text = fecha.ToString("dd MMMM yyyy"); // Esto mostrará la fecha en formato "día mes año", por ejemplo, "28 mayo 2024"
                        FMuestra = DateTime.Parse(fecha.ToString("dd MMMM yyyy"));
                    }
                    else
                    {
                        LblFecha.Text = DateTime.Today.ToString();
                    }
                    if (row["Ticket"].ToString() != null)
                    {
                        LblTKCD.Text = row["Ticket"].ToString();
                    }
                    else
                    {
                        LblTKCD.Text = "--";
                    }
                    if (row["Remision"].ToString() != null)
                    {
                        LblResmision.Text = row["Remision"].ToString();
                    }
                    else
                    {
                        LblResmision.Text = "--";
                    }
                    if (row["Tally"].ToString() != null)
                    {
                        LblTally.Text = row["Tally"].ToString();
                    }
                    else
                    {
                        LblTally.Text = "--";
                    }
                    if (row["kilos"].ToString() != null)
                    {
                        LblPesoCD.Text = row["kilos"].ToString();
                    }
                    else
                    {
                        LblPesoCD.Text = "--";
                    }
                    if (row["KgsRem"].ToString() != null)
                    {
                        LblKgsRem.Text = row["KgsRem"].ToString();
                    }
                    else
                    {
                        LblKgsRem.Text = "--";
                    }
                    if (row["Sacos"].ToString() != null)
                    {
                        LblSacosCD.Text = row["Sacos"].ToString();
                    }
                    else
                    {
                        LblSacosCD.Text = "--";
                    }
                    if (row["Diferencia"].ToString() != null)
                    {
                        LblDiferencia.Text = row["Diferencia"].ToString();
                    }
                    else
                    {
                        LblDiferencia.Text = "--";
                    }
                    if (row["Proveedor"].ToString() != null)
                    {
                        LblProveedor.Text = row["Proveedor"].ToString();
                    }
                    else
                    {
                        LblProveedor.Text = "--";
                    }
                    if (row["Empaque"].ToString() != null)
                    {
                        LblEmpaque.Text = row["Empaque"].ToString();
                    }
                    else
                    {
                        LblEmpaque.Text = "--";
                    }
                    if (row["Bodega"].ToString() != null)
                    {
                        LblBodega.Text = row["Bodega"].ToString();
                    }
                    else
                    {
                        LblBodega.Text = "--";
                    }
                    if (row["Ubicacion"].ToString() != null)
                    {
                        LblUbicacion.Text = row["Ubicacion"].ToString();
                    }
                    else
                    {
                        LblUbicacion.Text = "--";
                    }
                    if (row["Tipo de Compra"].ToString() != null)
                    {
                        LblTCompra.Text = row["Tipo de Compra"].ToString();
                    }
                    else
                    {
                        LblTCompra.Text = "--";
                    }
                    if (row["Certificacion"].ToString() != null)
                    {
                        LblCertificacion.Text = row["Certificacion"].ToString();
                    }
                    else
                    {
                        LblCertificacion.Text = "--";
                    }
                    CalculoDias();
                }
                else
                {

                    BtnActivar.Visible = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error en cargar datos interfaz", "Error en datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                bool tieneAgregarAnalisis = false;
                bool tieneEditarAnalisis = false;

                foreach (DataRow rowpermisos in dt.Rows)
                {
                    Modulo = Convert.ToString(rowpermisos["Modulo"]);
                    if (Modulo == "Agregar Análisis")
                    {
                        tieneAgregarAnalisis = true;
                    }
                    if (Modulo == "Editar Análisis")
                    {
                        tieneEditarAnalisis = true;
                    }
                }

                if (tieneAgregarAnalisis && tieneEditarAnalisis)
                {
                    BtnAnalisis.Visible = true;
                    BtnCambiarTK.Enabled = true;
                    BtnActivar.Enabled = true;
                }
                else if (tieneAgregarAnalisis)
                {
                    BtnAnalisis.Visible = true;
                    BtnCambiarTK.Enabled = true;
                    BtnActivar.Enabled = false;
                }
                else if (tieneEditarAnalisis)
                {
                    BtnAnalisis.Visible = false;
                    BtnCambiarTK.Enabled = false;
                    BtnActivar.Enabled = true;
                }
                else
                {
                    BtnAnalisis.Visible = false;
                    BtnCambiarTK.Enabled = false;
                    BtnActivar.Enabled = false;
                }
            }
            else
            {
                // Hacer todos los controles visibles y habilitados
                BtnAnalisis.Visible = true;
                BtnCambiarTK.Enabled = true;
                BtnActivar.Enabled = true;
            }
        }
        private void LlenarCheckBoxList()
        {
            // Limpiar el CheckListBox antes de llenarlo
            CLBFiltros.Items.Clear();

            // Llenar el CheckListBox con los encabezados del DataGridView
            foreach (DataGridViewColumn column in dtInventarioCat.Columns)
            {
                CLBFiltros.Items.Add(column.HeaderText);
            }
        }
    }
}
