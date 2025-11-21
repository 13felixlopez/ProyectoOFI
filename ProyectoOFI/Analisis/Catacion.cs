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
        double Casc, QQs;
        private bool isPlaceholder = true;
        double Humedad;
        Boolean Estado;
        string Proceso, Modulo, Procedencia;
        int Idcatacion;
        List<string> filtro = new List<string>();
        string Analizar = "Proceso";//Variable que define si es compra directa o no

        string Area = "Secado Natural";

        //Variables a utilizar para el envio de correo, Ticket y analisis se obtienen del metodo verdetallecata
        string NumAnalisis, Rendimiento, Quality;

        int POA1, POA2;
        string part1;
        string part2;
        string Tk2 = null;
        bool bandera = true;
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
                    //funcion.ContarTK(ref Contador);
                    Contador = ContarBusqueda;
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
                if (Area == "Secado Natural")
                {
                    BuscarTK();
                }
                else if (Area == "Robusta")
                {
                    BuscarCataRobusta();
                }
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
                if (Area == "Secado Natural")
                {
                    BuscarTK();
                }
                else if (Area == "Robusta")
                {
                    BuscarCataRobusta();
                }
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
                if (Area == "Secado Natural")
                {
                    BuscarTK();
                }
                else if (Area == "Robusta")
                {
                    BuscarCataRobusta();
                }
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
                if (Area == "Secado Natural")
                {
                    BuscarTK();
                }
                else if (Area == "Robusta")
                {
                    BuscarCataRobusta();
                }
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
            //funcion.BuscarCatacion(txtBuscador.Text, CbBuscar.Text, ref dt, desde, hasta, ContarBusqueda);
            funcion.BuscarCataSN(txtBuscador.Text, CbBuscar.Text, ref dt, desde, hasta, ContarBusqueda);
            dtInventarioCat.DataSource = dt;
            ContarBusqueda = int.Parse(funcion.Contador.ToString());
            //LblContador.Text = ContarBusqueda.ToString();
            //Base.DiseñoEnvio(ref dtInventarioCat);
        }
        private void BuscarCataRobusta()
        {
            DataTable dt = new DataTable();
            Dcatacion funcion = new Dcatacion();
            dtInventarioCat.DataSource = null;
            //funcion.BuscarTK(txtBuscador.Text, ref dt, desde, hasta, ContarBusqueda);
            //funcion.BuscarCatacion(txtBuscador.Text, CbBuscar.Text, ref dt, desde, hasta, ContarBusqueda);
            funcion.BuscarCataRobusta(txtBuscador.Text, CbBuscar.Text, ref dt, desde, hasta, ContarBusqueda);
            dtInventarioCat.DataSource = dt;
            ContarBusqueda = int.Parse(funcion.Contador.ToString());
            //LblContador.Text = ContarBusqueda.ToString();
            //Base.DiseñoEnvio(ref dtInventarioCat);
        }
        public void MostrarLotes()
        {
            BtnMostrarCompras.Text = "Compras Directas";
            Dcatacion funcion = new Dcatacion();
            DataTable dt = new DataTable();
            //funcion.MostrarCata(ref dt, desde, hasta);
            if (Area == "Secado Natural")
            {
                funcion.MostrarCataSN(ref dt, desde, hasta);
            }
            else if (Area == "Robusta")
            {
                funcion.MostrarCataRobusta(ref dt, desde, hasta);
            }
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
                        FMuestra = DateTime.Parse(dr["Fecha Muestra"].ToString());
                        DTPFechaMuestra.Value = FMuestra;
                    }
                    else
                    {
                        FMuestra = DateTime.Today;
                        DTPFechaMuestra.Value = FMuestra;
                    }

                    //DtFechaCatacion.Value = DateTime.Today.Date;
                    CalculoDias();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos en controles" + ex.Message, "ERROR en Catación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void VerDetalleCatacionRob()
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
                        LblTicketRob.Text = dr["Ticket"].ToString();
                    }
                    else
                    {
                        LblTicketRob.Text = "--";
                    }
                    if (dr["Sacos"].ToString() != null)
                    {
                        LblSacosRob.Text = dr["Sacos"].ToString();
                    }
                    else
                    {
                        LblSacosRob.Text = "--";
                    }
                    if (dr["Peso"].ToString() != null)
                    {
                        LblPesoRob.Text = dr["Peso"].ToString();
                    }
                    else
                    {
                        LblPesoRob.Text = "--";
                    }
                    if (dr["QQs"].ToString() != null)
                    {
                        LblQqsRob.Text = dr["QQs"].ToString();
                    }
                    else
                    {
                        LblQqsRob.Text = "--";
                    }
                    if (dr["Calidad"].ToString() != null)
                    {
                        LblCalidadRob.Text = dr["Calidad"].ToString();
                    }
                    else
                    {
                        LblCalidadRob.Text = "--";
                    }
                    if (dr["Certificación"].ToString() != null)
                    {
                        LblCertRob.Text = dr["Certificación"].ToString();
                    }
                    else
                    {
                        LblCertRob.Text = "--";
                    }
                    if (dr["Estado Fisico"].ToString() != null)
                    {
                        LblEstFisRob.Text = dr["Estado Fisico"].ToString();
                    }
                    else
                    {
                        LblEstFisRob.Text = "--";
                    }
                    if (dr["Daño"].ToString() != null)
                    {
                        LblDanioRob.Text = dr["Daño"].ToString();
                    }
                    else
                    {
                        LblDanioRob.Text = "--";
                    }
                    if (dr["Cliente"].ToString() != null)
                    {
                        LblClienteRob.Text = dr["Cliente"].ToString();
                    }
                    else
                    {
                        LblClienteRob.Text = "--";
                    }
                    if (dr["AreaSecado"].ToString() != null)
                    {
                        LblProcedenciaRob.Text = dr["AreaSecado"].ToString();
                    }
                    else
                    {
                        LblProcedenciaRob.Text = "--";
                    }
                    FRecibido = DateTime.Parse(dr["FechaRecibido"].ToString());
                    if (dr["Fecha Muestra"] != DBNull.Value && !string.IsNullOrWhiteSpace(dr["Fecha Muestra"].ToString()))
                    {
                        FMuestra = DateTime.Parse(dr["Fecha Muestra"].ToString());
                        DtPickerMuestraRob.Value = FMuestra;
                    }
                    else
                    {
                        FMuestra = DateTime.Today;
                        DtPickerMuestraRob.Value = FMuestra;
                    }

                    //DtFechacatacionRob.Value = DateTime.Today.Date;
                    CalculoDiasRob();
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

                //if (Procedencia == "Secado Mecánico")
                //{
                //    // Centrar panel en pantalla
                //    PlTkSM.Location = new Point(
                //        (this.ClientSize.Width - PlTkSM.Width) / 2,
                //        (this.ClientSize.Height - PlTkSM.Height) / 2);

                //    // Desactivar panel principal
                //    PLDatos.Enabled = false;
                //    PlTkSM.Visible = true;

                //    // Instanciar clase de acceso a datos
                //    var funcion = new Dcatacion();

                //    // Construir códigos de parte
                //    part1 = $"{Ticket}-Parte1";
                //    part2 = $"{Ticket}-Parte2";

                //    // Obtener datos
                //    funcion.MaquinaP1(part1, ref POA1);
                //    funcion.MaquinaP2(part2, ref POA2);

                //    // Mostrar / ocultar botón Parte 1
                //    if (POA1 > 0)
                //    {
                //        BtnPart1.Visible = true;
                //        BtnPart1.Text = $"{Ticket}-Parte1  Tolva {POA1}";
                //    }
                //    else
                //    {
                //        BtnPart1.Visible = false;
                //        BtnPart1.Text = string.Empty;
                //    }

                //    // Mostrar / ocultar botón Parte 2
                //    if (POA2 > 0)
                //    {
                //        BtnPart2.Visible = true;
                //        BtnPart2.Text = $"{Ticket}-Parte2  Tolva {POA2}";
                //    }
                //    else
                //    {
                //        BtnPart2.Visible = false;
                //        BtnPart2.Text = string.Empty;
                //    }

                //}
                //else
                //{
                // Restaurar estado normal
                PlTkSM.Visible = false;
                PLDatos.Enabled = true;
                BtnPart1.Text = string.Empty;
                BtnPart2.Text = string.Empty;
                TkDetalle = LblTicket.Text;
                CargarCombos();
                if (Area == "Secado Natural")
                {
                    DtFechaCatacion.Value = DateTime.Today.Date;
                    VerDetalleCata();
                    VerDetalleCatacion();
                }
                else if (Area == "Robusta")
                {
                    DtFechacatacionRob.Value = DateTime.Today.Date;
                    VerDetalleCataRob();
                    VerDetalleCatacionRob();
                }
                //}
            }
            else
            {
                PlDatosTk.Visible = false;
                PlDetalleCompra.Visible = true;
                //PlDetalleCompra.BringToFront();
                VerDetalleCompra();
                TkDetalle = LblTKCD.Text;
                DTPFechaMuestra.Value = DateTime.Parse(LblFecha.Text);
                VerDetalleCata();
            }

            if (Area == "Secado Natural")
            {
                AbrirFormulario(PLDatos);
            }
            else if (Area == "Robusta")
            {
                AbrirFormulario(PlDatosrob);
            }
            // Traer panel al frente
            // PlTkSM.BringToFront();
        }
        private void ObtenerTK()
        {
            string nombrecolumna = "Ticket";
            int indice = dtInventarioCat.Columns[nombrecolumna].Index;
            Ticket = dtInventarioCat.SelectedCells[indice].Value.ToString();
            LblTicket.Text = Ticket;
            if (BtnMostrarCompras.Text == "Compras Directas")
            {
                string nombrecolum = "AreaSecado";
                int num = dtInventarioCat.Columns[nombrecolum].Index;
                Procedencia = dtInventarioCat.SelectedCells[num].Value.ToString();

                string columnqqs = "QQs";
                int numqqs = dtInventarioCat.Columns[columnqqs].Index;
                QQs = double.Parse(dtInventarioCat.SelectedCells[numqqs].Value.ToString());

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
        private void CalcularDesmDRob()
        {
            // Paso 1: Obtener valores de Scr12, Scr14, Scr15
            double val12 = ObtenerValorSeguro(TxtScr12);
            double val14 = ObtenerValorSeguro(TxtScr14);
            double val15 = ObtenerValorSeguro(TxtScr15);

            // Paso 2: Calcular el porcentaje restante
            double totalUsado = val12 + val14 + val15;
            double restante = Math.Round(100 - totalUsado, 2);

            // Paso 3: Mostrar el valor restante
            LblFondo.Text = restante.ToString("F2");

            // Paso 4: Validación visual por colores
            if (restante < 0)
            {
                LblFondo.BackColor = Color.LightPink; // Se pasó de 100
            }
            else if (restante == 0)
            {
                LblFondo.BackColor = Color.LightGreen; // Perfecto
            }
            else
            {
                LblFondo.BackColor = SystemColors.Control; // Aún resta por completar
            }
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
        private void AbrirFormulario(Panel Datos)
        {
            // PLDatos.Size = new Size(1207, 622);
            //PLDatos.Location = new System.Drawing.Point(dtInventarioCat.Width / 2
            //    - PLDatos.Width / 2, dtInventarioCat.Height / 2 - PLDatos.Height / 3);
            // Obtenemos el tamaño del formulario actual
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Verificamos si el panel es más grande que el formulario y ajustamos si es necesario
            if (Datos.Width > formWidth)
            {
                Datos.Width = formWidth - 20; // Agregamos un margen
            }

            if (Datos.Height > formHeight)
            {
                Datos.Height = formHeight - 20; // Agregamos un margen
            }

            // Luego calculamos la nueva ubicación centrada
            int newX = (formWidth - Datos.Width) / 2;
            int newY = (formHeight - Datos.Height) / 2;

            Datos.Location = new System.Drawing.Point(newX, newY);

            Datos.Visible = true;
            Datos.BringToFront();
            plOpciones.Enabled = false;
            dtInventarioCat.Enabled = false;
            //Dcatacion funcion = new Dcatacion();
            //funcion.MostrarVariedad(CbVariedad);
            //string calidad = LblCalidad.Text;
            //if (calidad.EndsWith("UA"))
            //{
            //    funcion.MostrarGrupoCalidadUA(CbGrupoCalidad);
            //}
            //else
            //{
            //    funcion.MostrarGCalidad(CbGrupoCalidad);
            //}
            //funcion.MostrarTasas(CbTasa);
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
        private void CargarCombos()
        {
            Dcatacion funcion = new Dcatacion();
            if (Area == "Secado Natural")
            {
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
            }
            else if (Area == "Robusta")
            {
                funcion.MostrarGVariedadRob(CbVariedadRob);
                string calidad = LblCalidadRob.Text;
                if (calidad.EndsWith("UA"))
                {
                    funcion.MostrarGCalidadRob(CbGCalidadRob);
                }
                else
                {
                    funcion.MostrarGCalidadRob(CbGCalidadRob);
                }
                funcion.MostrarTasas(CbTazaRob);
            }
        }
        string ticketText;
        private void Analisis()
        {
            if (Area == "Secado Natural")
            {
                ticketText = LblTicket.Text;
            }
            else if (Area == "Robusta")
            {
                ticketText = LblTicketRob.Text;
            }
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
                    if (Area == "Secado Natural")
                    {
                        TxtAnalisis.Text = ticketText;
                    }
                    else if (Area == "Robusta")
                    {
                        TxtAnalisisRob.Text = ticketText;
                    }
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
            if (Area == "Secado Natural")
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
                label53.Visible = false;
                LblTolva.Visible = false;
            }
            else if (Area == "Robusta")
            {
                TxtAnalisisRob.Clear();
                LblDiasRob.Text = "--";
                TxtObtRob.Text = "";
                TxtHumdadRob.Text = "";
                TxtScr12.Text = "0";
                TxtScr15.Text = "0";
                TxtScr14.Text = "0";
                ChbAnalizadoRob.Checked = false;
                ChbRechazadoRob.Checked = false;
                TkDetalle = null;
            }
            //BtnCopiar.Visible = false;
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
                        EditarCatacionCD(TxtAnalisis.Text);
                        Task.Delay(3000);
                        BuscarTK();
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
                            InsertarCatacion(LblTicket.Text);
                            Task.Delay(3000);
                            BuscarTK();
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
                        EditarCatacionCD(TxtAnalisis.Text);
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
            if (Area == "Secado Natural")
            {
                TxtAnalisis.Enabled = true;
                //DtFechaCatacion.Enabled = true;
                DTPFechaMuestra.Enabled = true;
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
            else if (Area == "Robusta")
            {
                TxtAnalisisRob.Enabled = true;
                DtFechaCatacion.Enabled = true;
                //DTPFechaMuestra.Enabled = true;
                TxtObtRob.Enabled = true;
                CbVariedadRob.Enabled = true;
                TxtHumdadRob.Enabled = true;
                TxtScr12.Enabled = true;
                TxtScr15.Enabled = true;
                TxtScr14.Enabled = true;
                BtnAnalizadoRob.Enabled = true;
                ChbAnalizadoRob.Enabled = true;
                ChbRechazadoRob.Enabled = true;
                CbGCalidadRob.Enabled = true;
                CbTazaRob.Enabled = true;
            }
        }
        private void Desactivar()
        {
            if (Area == "Secado Natural")
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
                Tk2 = null;
            }
            else if (Area == "Robusta")
            {
                TxtAnalisisRob.Enabled = false;
                DtFechacatacionRob.Enabled = false;
                DtPickerMuestraRob.Enabled = false;
                TxtObtRob.Enabled = false;
                CbVariedadRob.Enabled = false;
                TxtHumdadRob.Enabled = false;
                TxtScr12.Enabled = false;
                TxtScr15.Enabled = false;
                TxtScr14.Enabled = false;
                BtnAnalizadoRob.Text = "Analizado";
                BtnAnalizadoRob.Enabled = false;
                ChbAnalizadoRob.Enabled = false;
                ChbRechazadoRob.Enabled = false;
                CbGCalidadRob.Enabled = false;
                CbTazaRob.Enabled = false;
            }
        }
        private async void InsertarCatacion(string Tk, bool preguntar = true)
        {
            if (!Validar())
                return;

            if (DtFechaCatacion.Value.Date > DateTime.Today.Date)
            {
                MessageBox.Show("La fecha de recibido no puede ser mayor a la fecha actual",
                                "Error en la fecha",
                                MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            LCatacion parametros = new LCatacion();
            Dcatacion funcion = new Dcatacion();

            // --- Asignar valores ---
            parametros.Ticket = Tk;
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
            parametros.Estado = ChbRechazado.Checked ? "0" : "1";

            // --- Insertar ---
            if (funcion.InsertarCatacion(parametros))
            {
                // Preguntar solo si corresponde y si existe Tk2
                if (preguntar && !string.IsNullOrEmpty(Tk2))
                {
                    var res = MessageBox.Show(
                        $"¿Deseas copiar los mismos datos a {Tk2}?",
                        "Copiar Datos",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question);

                    if (res == DialogResult.OK)
                    {
                        // Llamada recursiva SIN preguntar esta vez
                        InsertarCatacion(Tk2, false);

                        EditarCatacionCD(Ticket);
                        bandera = false;
                        await Task.Delay(3000);
                    }
                }

                PLDatos.Visible = false;
                Limpiar();
            }
            else
            {
                MessageBox.Show("❌ No se pudo insertar la catación.",
                                "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void EditarCatacionCD(string Analisis)
        {
            if (Validar())
            {
                if (DtFechaCatacion.Value.Date <= DateTime.Today.Date)
                {
                    LCatacion parametros = new LCatacion();
                    Dcatacion funcion = new Dcatacion();
                    parametros.Origen = LblProcedencia.Text;
                    parametros.Analisis = Analisis;
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
                        if (bandera == true)
                        {
                            DateTime FEdicion = DateTime.Now;
                            MSJ(Ticket, TxtAnalisis.Text, FEdicion, Rendimiento, Quality);
                        }
                        MessageBox.Show("Registro editado con Exito", "Editar Analisis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        PLDatos.Visible = false;
                        bandera = true;
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
                    if (row["IdVariedad"] != DBNull.Value && row["IdVariedad"].ToString() != null)
                    {
                        CbVariedad.SelectedValue = row["IdVariedad"].ToString();
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
        private void VerDetalleCataRob()
        {
            Dcatacion funcion = new Dcatacion();
            DataTable dt = new DataTable();

            try
            {
                funcion.VerDetalleCataRob(ref dt, TkDetalle); // 🔹 Llama al nuevo SP

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // === Campos principales ===
                    TxtAnalisisRob.Text = row["Analisis"]?.ToString() ?? "";
                    LblProcedenciaRob.Text = row["Origen"]?.ToString() ?? "";

                    // Fecha Muestra
                    if (DateTime.TryParse(row["FechaMuestra"]?.ToString(), out DateTime fechaMuestra))
                        DtPickerMuestraRob.Value = fechaMuestra;
                    else
                        DtPickerMuestraRob.Value = DateTime.Today;

                    // Fecha Catación
                    if (DateTime.TryParse(row["FechaCatacionRob"]?.ToString(), out DateTime fechaCat))
                        DtFechacatacionRob.Value = fechaCat;
                    else
                        DtFechacatacionRob.Value = DateTime.Today;

                    // Días
                    LblDiasRob.Text = row["DiasRob"]?.ToString() ?? "--";

                    // === Datos de análisis ===
                    TxtObtRob.Text = row["RmtoObtoRob"]?.ToString() ?? "";
                    LblCascarillaRob.Text = row["CascarillaRob"]?.ToString() ?? "--";
                    LblPsRob.Text = row["TotalPSRob"]?.ToString() ?? "--";
                    TxtHumdadRob.Text = row["Humedad"]?.ToString() ?? "";
                    TxtScr12.Text = row["SCR12"]?.ToString() ?? "";
                    TxtScr15.Text = row["SCR15"]?.ToString() ?? "";
                    TxtScr14.Text = row["SCR1314"]?.ToString() ?? "";
                    LblFondo.Text = row["DesmDRob"]?.ToString() ?? "--";

                    // === Porcentajes ===
                    LblRob72P.Text = row["Rob72P"]?.ToString() ?? "--";
                    LblDesmDPRob.Text = row["DesmDRobP"]?.ToString() ?? "--";
                    LblNessP.Text = row["Nessp"]?.ToString() ?? "--";

                    LblFondo.Text = row["Fondo"]?.ToString() ?? "";
                    TxtNess.Text = row["Ness"]?.ToString() ?? "";
                    Txt72.Text = row["Rob72"]?.ToString() ?? "";

                    // === Variedad ===
                    if (row["IdVariedad"] != DBNull.Value)
                        CbVariedadRob.SelectedValue = Convert.ToInt32(row["IdVariedad"]);
                    else
                        CbVariedadRob.SelectedIndex = -1;

                    // === Score / Taza / Calidad ===
                    CbTazaRob.Text = row["Tasa"]?.ToString() ?? "--";
                    CbGCalidadRob.Text = row["GradoCalidadRob"]?.ToString() ?? "--";

                    Quality = CbGCalidadRob.Text;
                    Rendimiento = TxtObtRob.Text;

                    // === Estado (es string, no bool) ===
                    string estado = row["Estado"]?.ToString()?.Trim() ?? "0";
                    if (estado == "1")
                    {
                        ChbAnalizadoRob.Checked = true;
                        BtnAnalizadoRob.Enabled = false;
                    }
                    else if (estado == "0")
                    {
                        ChbRechazadoRob.Checked = true;
                        BtnAnalizadoRob.Text = "Re-Analizar";
                    }
                    else
                    {
                        ChbAnalizadoRob.Checked = false;
                        ChbRechazadoRob.Checked = false;
                    }

                    // === ID Catación ===
                    if (int.TryParse(row["IdCatacion"]?.ToString(), out int idCata))
                        Idcatacion = idCata;

                    // === Post-procesos ===
                    CalculoDiasRob();
                    BtnActivarRod.Visible = true;
                }
                else
                {
                    BtnAnalizadoRob.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message,
                                "Error en datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (Area == "Secado Natural")
            {
                BuscarTK();
            }
            else if (Area == "Robusta")
            {
                BuscarCataRobusta();
            }
            else if (Area == "Secado Mecanico")
            {
                BuscarCataSM();
            }
            ReiniciarPaginado();
            txtBuscador.Focus();
        }

        private void BuscarCataSM()
        {
            DataTable dt = new DataTable();
            Dcatacion funcion = new Dcatacion();
            funcion.BuscarCataSM(txtBuscador.Text, CbBuscar.Text, ref dt, desde, hasta, ContarBusqueda);
            dtInventarioCat.DataSource = dt;
            ContarBusqueda = int.Parse(funcion.Contador.ToString());
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

        private void BtnPart1_Click(object sender, EventArgs e)
        {
            LblTicket.Text = Ticket + "-Parte1";
            PlTkSM.Visible = false;
            PLDatos.Enabled = true;
            TxtAnalisis.Text = Ticket + "-Parte1";
            label53.Visible = true;
            LblTolva.Visible = true;
            LblTolva.Text = POA1.ToString();
            //BtnCopiar.Visible = true;
            Tk2 = part2;
            Dcatacion funcion = new Dcatacion();
            DTPFechaMuestra.Value = funcion.ObtenerFechaMuestra(LblTicket.Text);
            TkDetalle = LblTicket.Text;
            VerDetalleCata();
            VerDetalleCata();
        }

        private void TxtScore_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, backspace y control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true; // Rechazar el carácter
            }

            // Permitir signo negativo solo al inicio
            if (e.KeyChar == '-' && ((TextBox)sender).SelectionStart != 0)
            {
                e.Handled = true;
            }

            // Evitar múltiples signos negativos
            if (e.KeyChar == '-' && ((TextBox)sender).Text.Contains("-"))
            {
                e.Handled = true;
            }
        }

        private void BtnSecadoNa_Click(object sender, EventArgs e)
        {
            Area = "Secado Natural";
            BtnSecadoM.Enabled = true;
            BtnRobusta.Enabled = true;
            BtnSecadoNa.Enabled = false;
            dtInventarioCat.DataSource = null;
            BuscarTK();
        }

        private void BtnRobusta_Click(object sender, EventArgs e)
        {
            Area = "Robusta";
            BtnSecadoM.Enabled = true;
            BtnSecadoNa.Enabled = true;
            BtnRobusta.Enabled = false;
            BuscarCataRobusta();
        }

        private void BtnAnalizadoRob_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposRob())
            {
                MessageBox.Show("Datos invalidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (BtnAnalizadoRob.Text == "Analizado")
                {
                    InsertarCatRob();
                }
                else if (BtnAnalizadoRob.Text == "Re-Analizar" || BtnAnalizadoRob.Text == "Editar Análisis")
                {
                    EditarCatacionRob();
                }
            }
        }

        private void EditarCatacionRob()
        {
            if (DtFechacatacionRob.Value.Date > DateTime.Today.Date)
            {
                MessageBox.Show("La fecha de catación no puede ser mayor a la fecha actual.",
                                "Error en la fecha",
                                MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // 2️⃣ Construir el objeto de parámetros
            LCatacionRob parametros = new LCatacionRob
            {
                Ticket = LblTicketRob.Text?.Trim(),
                Origen = LblProcedenciaRob.Text?.Trim(),
                Analisis = TxtAnalisisRob.Text?.Trim(),
                FechaMuestra = DtPickerMuestraRob.Value,
                FechaCatacion = DateTime.Today,
                Dias = int.TryParse(LblDiasRob.Text, out var dias) ? dias : 0,
                RmtoObto = TxtObtRob.Text?.Trim(),
                Cascarilla = LblCascarillaRob.Text?.Trim(),
                TotalPS = LblPsRob.Text?.Trim(),
                IdVariedad = CbVariedadRob.SelectedValue is int v ? v : 0,
                Humedad = TxtHumdadRob.Text?.Trim(),
                SCR12 = decimal.TryParse(TxtScr12.Text, out var exp) ? exp : 0,
                SCR15 = decimal.TryParse(TxtScr15.Text, out var scr15) ? scr15 : 0,
                SCR14 = decimal.TryParse(TxtScr14.Text, out var scr14) ? scr14 : 0,
                DesmDRob = decimal.TryParse(LblFondo.Text, out var desm) ? desm : 0,
                Taza = CbTazaRob.Text?.Trim(),
                GradoCalidad = CbGCalidadRob.Text?.Trim(),
                NessP = LblNessP.Text?.Trim(),
                Rob72P = LblRob72P.Text?.Trim(),
                DesmDRobP = LblDesmDPRob.Text?.Trim(),
                Digitador = Login.NombreA?.Trim(),
                PesoRecibido = decimal.TryParse(LblPesoRob.Text, out var peso) ? peso : 0,
                Fondo = decimal.TryParse(LblFondo.Text, out var fondo) ? fondo : 0,
                Ness = decimal.TryParse(TxtNess.Text, out var ness) ? ness : 0,
                Rob72 = decimal.TryParse(Txt72.Text, out var Rob72) ? Rob72 : 0,
                Estado = ChbRechazadoRob.Checked ? "0" : "1"
            };

            // 3️⃣ Validación dinámica de campos requeridos
            List<string> errores = new List<string>();

            if (string.IsNullOrWhiteSpace(parametros.Ticket)) errores.Add("Ticket");
            if (string.IsNullOrWhiteSpace(parametros.Origen)) errores.Add("Origen");
            if (string.IsNullOrWhiteSpace(parametros.Analisis)) errores.Add("Análisis");
            if (parametros.FechaMuestra == DateTime.MinValue) errores.Add("Fecha de muestra");
            if (parametros.FechaCatacion == DateTime.MinValue) errores.Add("Fecha de catación");
            if (parametros.IdVariedad <= 0) errores.Add("Variedad");
            if (parametros.SCR12 <= 0) errores.Add("Exp. Robusta");
            if (parametros.PesoRecibido <= 0) errores.Add("Peso recibido");

            // 🔴 Si hay errores, mostrarlos antes de continuar
            if (errores.Count > 0)
            {
                MessageBox.Show("Faltan los siguientes campos obligatorios:\n\n• " +
                                string.Join("\n• ", errores),
                                "Datos incompletos",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4️⃣ Confirmación visual (opcional)
            Console.WriteLine($"➡️ Insertando catación Ticket: {parametros.Ticket}");

            // 5️⃣ Llamada al método de inserción
            Dcatacion funcion = new Dcatacion();
            bool resultado = funcion.EditarCatacionRob(parametros);

            if (resultado)
            {
                MessageBox.Show("✅ Catación Editada correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                PlDatosrob.Visible = false;
                dtInventarioCat.Enabled = true;
                plOpciones.Enabled = true;
                BtnAnalizadoRob.Text = "Analizado";
                BtnActivarRod.Visible = false;
                LimpiarRob();
                BuscarCataRobusta();
            }
            else
            {
                MessageBox.Show("❌ No se pudo insertar la catación de robusta.",
                                "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ValidarCamposRob()
        {
            // Usamos una lista de campos para simplificar la validación de nulos/vacíos
            var camposTexto = new (string Nombre, string Valor, Control Control)[]
            {
            // Validaciones de Campos de Texto / Lógico (Null/Empty Check)
            ("Ticket", LblTicketRob.Text, LblTicketRob),
            ("Procedencia/Origen", LblProcedenciaRob.Text, LblProcedenciaRob),
            ("Análisis", TxtAnalisisRob.Text, TxtAnalisisRob),
            ("RmtoObto", TxtObtRob.Text, TxtObtRob),
            ("Cascarilla", LblCascarillaRob.Text, LblCascarillaRob),
            ("Total PS", LblPsRob.Text, LblPsRob),
            ("Humedad", TxtHumdadRob.Text, TxtHumdadRob),
            ("Exp Rob %", LblNessP.Text, LblNessP),
            ("SCR 15 %", LblRob72P.Text, LblRob72P),
            ("SCR 14 %", LblDesmDPRob.Text, LblDesmDPRob),
            ("Taza", CbTazaRob.Text, CbTazaRob),
            ("Grado Calidad", CbGCalidadRob.Text, CbGCalidadRob),
            
            // Validamos que se haya seleccionado un valor en el ComboBox
            ("Id Variedad", CbVariedadRob.SelectedValue?.ToString(), CbVariedadRob),
            };

            foreach (var campo in camposTexto)
            {
                // Verificación de nulos/vacíos
                if (string.IsNullOrWhiteSpace(campo.Valor))
                {
                    MessageBox.Show($"El campo '{campo.Nombre}' es obligatorio y no puede estar vacío.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    campo.Control.Focus();
                    return false;
                }
            }

            // --- 2. Validación de Campos Numéricos (Int y Decimal) ---

            // Se utiliza TryParse para validar que el texto sea convertible a número.
            // Usamos CultureInfo.InvariantCulture para asegurar que el punto sea el separador decimal (si es relevante).

            // Validación de campos INT
            var camposInt = new (string Nombre, string Valor, Control Control)[]
            {
            ("Días", LblDiasRob.Text, LblDiasRob),
            };

            foreach (var campo in camposInt)
            {
                if (!int.TryParse(campo.Valor, out _))
                {
                    MessageBox.Show($"El campo '{campo.Nombre}' debe ser un número entero válido.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    campo.Control.Focus();
                    return false;
                }
            }

            // Validación de campos DECIMAL
            var camposDecimal = new (string Nombre, string Valor, Control Control)[]
            {
            ("Exp Rob", TxtScr12.Text, TxtScr12),
            ("SCR 15", TxtScr15.Text, TxtScr15),
            ("SCR 14", TxtScr14.Text, TxtScr14),
            ("Desm D Rob", LblFondo.Text, LblFondo),
            ("Peso Recibido", LblPesoRob.Text, LblPesoRob)
            };

            foreach (var campo in camposDecimal)
            {
                // Usamos decimal.TryParse con InvariantCulture para manejo consistente de decimales.
                if (!decimal.TryParse(campo.Valor, NumberStyles.Any, CultureInfo.InvariantCulture, out _))
                {
                    MessageBox.Show($"El campo '{campo.Nombre}' debe ser un valor numérico válido.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    campo.Control.Focus();
                    return false;
                }
            }

            // Nota: Las fechas (DtPickerMuestraRob.Value, DateTime.Today) y el CheckBox (ChbRechazadoRob.Checked)
            // se manejan internamente y siempre son válidos.

            return true;
        }
        private void InsertarCatRob()
        {
            // 1️⃣ Validación de la fecha de catación
            if (DtFechacatacionRob.Value.Date > DateTime.Today.Date)
            {
                MessageBox.Show("La fecha de catación no puede ser mayor a la fecha actual.",
                                "Error en la fecha",
                                MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // 2️⃣ Construir el objeto de parámetros
            LCatacionRob parametros = new LCatacionRob
            {
                Ticket = LblTicketRob.Text?.Trim(),
                Origen = LblProcedenciaRob.Text?.Trim(),
                Analisis = TxtAnalisisRob.Text?.Trim(),
                FechaMuestra = DtPickerMuestraRob.Value,
                FechaCatacion = DateTime.Today,
                Dias = int.TryParse(LblDiasRob.Text, out var dias) ? dias : 0,
                RmtoObto = TxtObtRob.Text?.Trim(),
                Cascarilla = LblCascarillaRob.Text?.Trim(),
                TotalPS = LblPsRob.Text?.Trim(),
                IdVariedad = CbVariedadRob.SelectedValue is int v ? v : 0,
                Humedad = TxtHumdadRob.Text?.Trim(),
                SCR12 = decimal.TryParse(TxtScr12.Text, out var exp) ? exp : 0,
                SCR15 = decimal.TryParse(TxtScr15.Text, out var scr15) ? scr15 : 0,
                SCR14 = decimal.TryParse(TxtScr14.Text, out var scr14) ? scr14 : 0,
                DesmDRob = decimal.TryParse(LblDesmDRob.Text, out var desm) ? desm : 0,
                Taza = CbTazaRob.Text?.Trim(),
                GradoCalidad = CbGCalidadRob.Text?.Trim(),
                NessP = LblNessP.Text?.Trim(),
                Rob72P = LblRob72P.Text?.Trim(),
                DesmDRobP = LblDesmDPRob.Text?.Trim(),
                Digitador = Login.NombreA?.Trim(),
                PesoRecibido = decimal.TryParse(LblPesoRob.Text, out var peso) ? peso : 0,
                Fondo = decimal.TryParse(LblFondo.Text, out var fondo) ? fondo : 0,
                Ness = decimal.TryParse(TxtNess.Text, out var ness) ? ness : 0,
                Rob72 = decimal.TryParse(Txt72.Text, out var Rob72) ? Rob72 : 0,
                Estado = ChbRechazadoRob.Checked ? "0" : "1"
            };

            // 3️⃣ Validación dinámica de campos requeridos
            List<string> errores = new List<string>();

            if (string.IsNullOrWhiteSpace(parametros.Ticket)) errores.Add("Ticket");
            if (string.IsNullOrWhiteSpace(parametros.Origen)) errores.Add("Origen");
            if (string.IsNullOrWhiteSpace(parametros.Analisis)) errores.Add("Análisis");
            if (parametros.FechaMuestra == DateTime.MinValue) errores.Add("Fecha de muestra");
            if (parametros.FechaCatacion == DateTime.MinValue) errores.Add("Fecha de catación");
            if (parametros.IdVariedad <= 0) errores.Add("Variedad");
            if (parametros.SCR12 <= 0) errores.Add("Exp. Robusta");
            if (parametros.PesoRecibido <= 0) errores.Add("Peso recibido");

            // 🔴 Si hay errores, mostrarlos antes de continuar
            if (errores.Count > 0)
            {
                MessageBox.Show("Faltan los siguientes campos obligatorios:\n\n• " +
                                string.Join("\n• ", errores),
                                "Datos incompletos",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4️⃣ Confirmación visual (opcional)
            Console.WriteLine($"➡️ Insertando catación Ticket: {parametros.Ticket}");

            // 5️⃣ Llamada al método de inserción
            Dcatacion funcion = new Dcatacion();
            bool resultado = funcion.InsertarCatacionRob(parametros);

            if (resultado)
            {
                MessageBox.Show("✅ Catación insertada correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                PlDatosrob.Visible = false;
                dtInventarioCat.Enabled = true;
                plOpciones.Enabled = true;
                BtnAnalizadoRob.Text = "Analizado";
                BtnActivarRod.Visible = false;
                LimpiarRob();
                BuscarCataRobusta();
            }
            else
            {
                MessageBox.Show("❌ No se pudo insertar la catación de robusta.",
                                "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void LimpiarRob()
        {
            // 1. Limpiar TextBoxes y Labels (Restablecer a cadena vacía)

            // TextBoxes
            TxtAnalisisRob.Text = string.Empty;
            TxtObtRob.Text = string.Empty;
            TxtHumdadRob.Text = string.Empty;
            TxtScr12.Text = string.Empty;
            TxtScr15.Text = string.Empty;
            TxtScr14.Text = string.Empty;

            // Labels (donde se muestra Ticket, Origen, etc.)
            LblTicketRob.Text = string.Empty;
            LblProcedenciaRob.Text = string.Empty;
            LblDiasRob.Text = string.Empty;
            LblCascarillaRob.Text = string.Empty;
            LblPsRob.Text = string.Empty;
            LblFondo.Text = string.Empty;
            LblNessP.Text = string.Empty;
            LblRob72P.Text = string.Empty;
            LblDesmDPRob.Text = string.Empty;
            LblPesoRob.Text = string.Empty;
            TxtNess.Text = string.Empty;
            Txt72.Text = string.Empty;
            LblDesmDRob.Text = string.Empty;

            // 2. Restablecer ComboBoxes (Desmarcar selección)
            CbVariedadRob.SelectedIndex = -1; // Deseleccionar
            CbTazaRob.Text = string.Empty;    // Limpiar texto (si es editable)
            CbGCalidadRob.Text = string.Empty; // Limpiar texto (si es editable)

            // 3. Restablecer DatePickers
            DtPickerMuestraRob.Value = DateTime.Today;

            // 4. Restablecer CheckBox (Estado)
            ChbRechazadoRob.Checked = false;
        }

        private void TxtObtRob_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtObtRob.Text))
            {
                Bto = 0;
            }
            else
            {
                try
                {
                    Bto = double.Parse(TxtObtRob.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Por favor, introduce un número válido.");
                    TxtObtRob.Text = "0";
                    Bto = 0;
                }
            }

            Casc = 100 - Bto;
            LblCascarillaRob.Text = Casc.ToString();
            LblPsRob.Text = (Casc + Bto).ToString();
            CalcularPorcentajes();
        }

        private void TxtHumdadRob_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtHumdadRob.Text))
            {
                Humedad = 0;
            }
            else
            {
                CultureInfo culture = new CultureInfo("en-US");

                if (double.TryParse(TxtHumdadRob.Text, NumberStyles.Any, culture, out double result))
                {
                    Humedad = result;
                }
                else
                {
                    // Manejar el caso donde el texto no se puede convertir a número
                    MessageBox.Show("Por favor, ingrese un número válido.");
                    TxtHumdadRob.Text = string.Empty;
                    return;
                }
            }

            if (Humedad >= 12.8)
            {
                ChbRechazadoRob.Checked = true;
                ChbAnalizadoRob.Enabled = false;
                CbGCalidadRob.Text = "";
            }
            else
            {
                ChbRechazadoRob.Checked = false;
                ChbAnalizadoRob.Enabled = true;
            }
        }

        private void TxtExpRob_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TxtScr12.Text))
                {
                    Exp = 0;
                }
                else
                {
                    if (double.TryParse(TxtScr12.Text, out double result))
                    {
                        Exp = result;
                    }
                    else
                    {
                        MessageBox.Show("Por favor, ingrese un número válido.");
                        TxtScr12.Text = string.Empty;
                        return;
                    }
                }

                CalcularDesmDRob();
                //LblNessP.Text = Math.Round((Bto * Exp) / 100, 2).ToString() + "%";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló el cálculo: " + ex.Message, "Error en Exp");
            }
        }

        private void TxtScr15_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtScr15.Text))
            {
                DesmA = 0;
            }
            else
            {
                if (double.TryParse(TxtScr15.Text, out double result))
                {
                    DesmA = result;
                }
                else
                {
                    // Manejar el caso donde el texto no se puede convertir a número
                    MessageBox.Show("Por favor, ingrese un número válido.");
                    TxtScr15.Text = string.Empty; // Limpiar el TextBox en caso de error
                    return;
                }
            }

            CalcularDesmDRob();
            //LblRob72P.Text = Math.Round((Bto * DesmA) / 100, 2).ToString() + "%";
        }

        private void TxtScr14_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtScr14.Text))
            {
                DesmC = 0;
            }
            else
            {
                if (double.TryParse(TxtScr14.Text, out double result))
                {
                    DesmC = result;
                }
                else
                {
                    // Manejar el caso donde el texto no se puede convertir a número
                    MessageBox.Show("Por favor, ingrese un número válido.");
                    TxtScr14.Text = string.Empty; // Limpiar el TextBox en caso de error
                    return;
                }
            }

            CalcularDesmDRob();
            //LblDesmDPRob.Text = Math.Round((Bto * DesmC) / 100, 2).ToString() + "%";
        }

        private void ChbRechazadoRob_CheckedChanged(object sender, EventArgs e)
        {
            if (ChbRechazadoRob.Checked == true)
            {
                ChbAnalizadoRob.Enabled = false;
                BtnAnalizadoRob.Enabled = true;
                ChbAnalizadoRob.Checked = false;
                //TxtAnalisis.Text = "# Analisis";
                TxtObtRob.Text = "0";
                TxtScr12.Text = "0";
                TxtScr15.Text = "0";
                TxtScr14.Text = "0";
            }
            else
            {
                ChbAnalizadoRob.Enabled = true;
                BtnAnalizadoRob.Enabled = false;
            }
        }

        private void ChbAnalizadoRob_CheckedChanged(object sender, EventArgs e)
        {
            if (ChbAnalizadoRob.Checked == true)
            {
                ChbRechazadoRob.Enabled = false;
                BtnAnalizadoRob.Enabled = true;
                ChbRechazadoRob.Checked = false;
            }
            else
            {
                ChbRechazadoRob.Enabled = true;
                BtnAnalizadoRob.Enabled = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PlDatosrob.Visible = false;
            dtInventarioCat.Enabled = true;
            plOpciones.Enabled = true;
            BtnAnalizadoRob.Text = "Analizado";
            BtnActivarRod.Visible = false;
            Desactivar();
            Limpiar();
            LimpiarRob();
            ValidarPermisos();
        }

        private void BtnSecadoM_Click(object sender, EventArgs e)
        {
            Area = "Secado Mecanico";
            BtnSecadoNa.Enabled = true;
            BtnRobusta.Enabled = true;
            BtnSecadoM.Enabled = false;
            dtInventarioCat.DataSource = null;
            BuscarCataSM();
        }

        private void BtnActivarRod_Click(object sender, EventArgs e)
        {
            Activar();
            BtnAnalizadoRob.Visible = true;
            BtnAnalizadoRob.Text = "Editar Análisis";
        }

        private void BtnPart2_Click(object sender, EventArgs e)
        {
            LblTicket.Text = Ticket + "-Parte2";
            PlTkSM.Visible = false;
            PLDatos.Enabled = true;
            TxtAnalisis.Text = Ticket + "-Parte2";
            label53.Visible = true;
            LblTolva.Visible = true;
            LblTolva.Text = POA2.ToString();
            //BtnCopiar.Visible = true;
            Tk2 = part1;
            Dcatacion funcion = new Dcatacion();
            DTPFechaMuestra.Value = funcion.ObtenerFechaMuestra(LblTicket.Text);
            TkDetalle = LblTicket.Text;
            VerDetalleCata();
            VerDetalleCata();
        }

        private void BtnX_Click(object sender, EventArgs e)
        {
            PlTkSM.Visible = false;
            PLDatos.Enabled = true;
            PLDatos.Visible = false;
            dtInventarioCat.Enabled = true;
            plOpciones.Enabled = true;
            BtnAnalisis.Text = "Analizado";
            BtnActivar.Visible = false;
            Desactivar();
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

        private void TxtNess_TextChanged(object sender, EventArgs e)
        {
            CalcularPorcentajes();
        }

        private void Txt72_TextChanged(object sender, EventArgs e)
        {
            CalcularPorcentajes();
        }

        private void TxtNess_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite:
            // 1. Dígitos (0-9)
            // 2. Un único punto decimal (si no existe ya uno)
            // 3. Teclas de control (Backspace, Delete, etc.)
            // 4. Bloquea cualquier otro carácter (letras, signos, etc.)

            TextBox textBox = (TextBox)sender;

            // Caso 1: Si es un dígito, siempre permitido
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Caso 2: Si es un punto, verificar que no exista ya uno y que no sea la primera posición
            if (e.KeyChar == '.')
            {
                bool alreadyHasDecimal = textBox.Text.Contains('.');
                bool isFirstChar = textBox.Text.Length == 0;

                e.Handled = alreadyHasDecimal || isFirstChar;
                return;
            }

            // Caso 3: Permitir teclas de control (Backspace, Delete, etc.)
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Bloquear cualquier otro carácter
            e.Handled = true;
        }

        private void Txt72_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite:
            // 1. Dígitos (0-9)
            // 2. Un único punto decimal (si no existe ya uno)
            // 3. Teclas de control (Backspace, Delete, etc.)
            // 4. Bloquea cualquier otro carácter (letras, signos, etc.)

            TextBox textBox = (TextBox)sender;

            // Caso 1: Si es un dígito, siempre permitido
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Caso 2: Si es un punto, verificar que no exista ya uno y que no sea la primera posición
            if (e.KeyChar == '.')
            {
                bool alreadyHasDecimal = textBox.Text.Contains('.');
                bool isFirstChar = textBox.Text.Length == 0;

                e.Handled = alreadyHasDecimal || isFirstChar;
                return;
            }

            // Caso 3: Permitir teclas de control (Backspace, Delete, etc.)
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Bloquear cualquier otro carácter
            e.Handled = true;
        }

        private void TxtHumdadRob_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite:
            // 1. Dígitos (0-9)
            // 2. Un único punto decimal (si no existe ya uno)
            // 3. Teclas de control (Backspace, Delete, etc.)
            // 4. Bloquea cualquier otro carácter (letras, signos, etc.)

            TextBox textBox = (TextBox)sender;

            // Caso 1: Si es un dígito, siempre permitido
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Caso 2: Si es un punto, verificar que no exista ya uno y que no sea la primera posición
            if (e.KeyChar == '.')
            {
                bool alreadyHasDecimal = textBox.Text.Contains('.');
                bool isFirstChar = textBox.Text.Length == 0;

                e.Handled = alreadyHasDecimal || isFirstChar;
                return;
            }

            // Caso 3: Permitir teclas de control (Backspace, Delete, etc.)
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Bloquear cualquier otro carácter
            e.Handled = true;
        }

        private void TxtScr15_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite:
            // 1. Dígitos (0-9)
            // 2. Un único punto decimal (si no existe ya uno)
            // 3. Teclas de control (Backspace, Delete, etc.)
            // 4. Bloquea cualquier otro carácter (letras, signos, etc.)

            TextBox textBox = (TextBox)sender;

            // Caso 1: Si es un dígito, siempre permitido
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Caso 2: Si es un punto, verificar que no exista ya uno y que no sea la primera posición
            if (e.KeyChar == '.')
            {
                bool alreadyHasDecimal = textBox.Text.Contains('.');
                bool isFirstChar = textBox.Text.Length == 0;

                e.Handled = alreadyHasDecimal || isFirstChar;
                return;
            }

            // Caso 3: Permitir teclas de control (Backspace, Delete, etc.)
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Bloquear cualquier otro carácter
            e.Handled = true;
        }

        private void TxtScr14_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite:
            // 1. Dígitos (0-9)
            // 2. Un único punto decimal (si no existe ya uno)
            // 3. Teclas de control (Backspace, Delete, etc.)
            // 4. Bloquea cualquier otro carácter (letras, signos, etc.)

            TextBox textBox = (TextBox)sender;

            // Caso 1: Si es un dígito, siempre permitido
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Caso 2: Si es un punto, verificar que no exista ya uno y que no sea la primera posición
            if (e.KeyChar == '.')
            {
                bool alreadyHasDecimal = textBox.Text.Contains('.');
                bool isFirstChar = textBox.Text.Length == 0;

                e.Handled = alreadyHasDecimal || isFirstChar;
                return;
            }

            // Caso 3: Permitir teclas de control (Backspace, Delete, etc.)
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Bloquear cualquier otro carácter
            e.Handled = true;
        }

        private void TxtScr12_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite:
            // 1. Dígitos (0-9)
            // 2. Un único punto decimal (si no existe ya uno)
            // 3. Teclas de control (Backspace, Delete, etc.)
            // 4. Bloquea cualquier otro carácter (letras, signos, etc.)

            TextBox textBox = (TextBox)sender;

            // Caso 1: Si es un dígito, siempre permitido
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Caso 2: Si es un punto, verificar que no exista ya uno y que no sea la primera posición
            if (e.KeyChar == '.')
            {
                bool alreadyHasDecimal = textBox.Text.Contains('.');
                bool isFirstChar = textBox.Text.Length == 0;

                e.Handled = alreadyHasDecimal || isFirstChar;
                return;
            }

            // Caso 3: Permitir teclas de control (Backspace, Delete, etc.)
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Bloquear cualquier otro carácter
            e.Handled = true;
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
            //FormatCellBasedOnProceso(dtInventarioCat, e);
        }

        private void CalculoDias()
        {
            DateTime fechaActual = DtFechaCatacion.Value;
            TimeSpan diferencia = fechaActual.Subtract(DTPFechaMuestra.Value);
            int diasDiferencia = (int)diferencia.TotalDays;
            LblDias.Text = diasDiferencia.ToString();
        }
        private void CalculoDiasRob()
        {
            DateTime fechaActual = DtFechacatacionRob.Value;
            TimeSpan diferencia = fechaActual.Subtract(DtPickerMuestraRob.Value);
            int diasDiferencia = (int)diferencia.TotalDays;
            LblDiasRob.Text = diasDiferencia.ToString();
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

                    BtnAnalizadoRob.Visible = true;
                    BtnActivarRod.Enabled = true;
                }
                else if (tieneAgregarAnalisis)
                {
                    BtnAnalisis.Visible = true;
                    BtnCambiarTK.Enabled = true;
                    BtnActivar.Enabled = false;

                    BtnAnalizadoRob.Visible = true;
                    BtnActivarRod.Enabled = false;
                }
                else if (tieneEditarAnalisis)
                {
                    BtnAnalisis.Visible = false;
                    BtnCambiarTK.Enabled = false;
                    BtnActivar.Enabled = true;

                    BtnAnalizadoRob.Visible = false;
                    BtnActivarRod.Enabled = true;
                }
                else
                {
                    BtnAnalisis.Visible = false;
                    BtnCambiarTK.Enabled = false;
                    BtnActivar.Enabled = false;

                    BtnAnalizadoRob.Visible = true;
                    BtnActivarRod.Enabled = false;
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
        private void CalcularPorcentajes()
        {
            // === 1. Calcular LblFondo ===
            double scr15 = ObtenerValorSeguro(TxtScr15);
            double scr14 = ObtenerValorSeguro(TxtScr14);
            double scr12 = ObtenerValorSeguro(TxtScr12);

            double fondo = Math.Round(100 - scr15 - scr14 - scr12, 2);
            if (fondo < 0) fondo = 0;
            LblFondo.Text = fondo.ToString("F2");

            // === 2. Calcular Desmerma Robusto ===
            double obtRob = ObtenerValorSeguro(TxtObtRob);  // base 100%
            double valNess = ObtenerValorSeguro(TxtNess);   // %
            double val72 = ObtenerValorSeguro(Txt72);       // %

            double desmPorc = Math.Round(100 - valNess - val72, 2);
            if (desmPorc < 0) desmPorc = 0;
            LblDesmDRob.Text = desmPorc.ToString("F2");

            // === 3. Calcular valores reales ===
            double valNessQq = Math.Round((valNess / 100.0) * obtRob, 2);
            double val72Qq = Math.Round((val72 / 100.0) * obtRob, 2);
            double valDesmQq = Math.Round((desmPorc / 100.0) * obtRob, 2);

            LblNessP.Text = valNessQq.ToString("F2");
            LblRob72P.Text = val72Qq.ToString("F2");
            LblDesmDPRob.Text = valDesmQq.ToString("F2");

            // === 4. Validación visual ===
            if (desmPorc < 0)
                LblDesmDRob.BackColor = Color.LightPink;
            else if (desmPorc == 0)
                LblDesmDRob.BackColor = Color.LightGreen;
            else
                LblDesmDRob.BackColor = SystemColors.Control;
        }


        private double ObtenerValorSeguro(TextBox txt)
        {
            return double.TryParse(txt.Text, out double val) ? val : 0;
        }


        private void AjustarExceso(double ness, double txt72)
        {
            // Determinar cuál TextBox causó el exceso (el que tiene foco)
            if (TxtNess.Focused)
            {
                // Ajustar TxtNess para que la suma sea 100
                double nuevoNess = 100 - txt72;
                TxtNess.Text = nuevoNess.ToString("0.##");
            }
            else if (Txt72.Focused)
            {
                // Ajustar Txt72 para que la suma sea 100
                double nuevoTxt72 = 100 - ness;
                Txt72.Text = nuevoTxt72.ToString("0.##");
            }

            LblDesmDRob.Text = "0";
            LblDesmDRob.BackColor = Color.LightGreen;
        }
    }
}
