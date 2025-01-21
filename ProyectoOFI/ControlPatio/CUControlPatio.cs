using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using ProyectoOFI.Otros;
using ProyectoOFI.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOFI.ControlPatio
{
    public partial class CUControlPatio : UserControl
    {
        int desde = 1;
        int hasta = 100;
        private int items_por_pagina = 100;
        int totalPaginas;
        int Contador, edit, editenf, editEn;
        int ContarBusqueda;
        string Modulo;
        string Ticket, Estado;
        DateTime Frecibido;
        string Proceso;
        int IdTendido, IdEnfarde, IdEnvio;
        int dias, Rechazos;
        int diasEdit;
        List<string> filtro = new List<string>();
        public CUControlPatio()
        {
            InitializeComponent();
            ValidarPermisos();
        }
        private async void CUControlPatio_Load(object sender, EventArgs e)
        {
            PlCarga.Dock = DockStyle.Fill;
            //await CargarDatos();
            Base.DiseñoDtvEliminar(ref dtInventariocp);
            Base.DiseñoDtv(ref dtInventariocp);
            PlCarga.Visible = false;
        }
        private async Task CargarDatos()
        {
            await Task.Delay(1500);
            dtInventariocp.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //MostrarLotes();
            ReiniciarPaginado();
            LlenarCheckBoxList();
            await Task.Delay(1000);
        }
        private void MostrarLotes()
        {
            DataTable dt = new DataTable();
            DControlPatio funcion = new DControlPatio();
            funcion.MostrarLotesCP(ref dt, desde, hasta);
            dtInventariocp.DataSource = dt;
            dtInventariocp.Columns["Proceso"].Visible = false;
            Base.DiseñoDtvEliminar(ref dtInventariocp);
        }
        private void LlenarCheckBoxList()
        {
            // Limpiar el CheckListBox antes de llenarlo
            CLBFiltros.Items.Clear();

            // Llenar el CheckListBox con los encabezados del DataGridView
            foreach (DataGridViewColumn column in dtInventariocp.Columns)
            {
                CLBFiltros.Items.Add(column.HeaderText);
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
            DRecepcion funcion = new DRecepcion();
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
                funcion.ContarTKCP(ref Contador);
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
                BuscarFechaCP();
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
                BuscarTk();
            }
            else if (CbBuscador.Visible == true)
            {
                Buscar();
            }
            else if (PlFiltroFecha.Visible == true)
            {
                BuscarFechaCP();
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
                BuscarTk();
            }
            else if (CbBuscador.Visible == true)
            {
                Buscar();
            }
            else if (PlFiltroFecha.Visible == true)
            {
                BuscarFechaCP();
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
                BuscarTk();
            }
            else if (CbBuscador.Visible == true)
            {
                Buscar();
            }
            else if (PlFiltroFecha.Visible == true)
            {
                BuscarFechaCP();
            }
            else
            {
                MostrarLotes();
            }
        }
        #endregion
        private void dtInventariocp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerTK();
            ObtenerDatos();
            AbrirFormulario();
            //lblTransferencia.Text = "Editar Transferencia";
            if (Login.login.Trim().StartsWith("Admin", StringComparison.OrdinalIgnoreCase))
            {
                PlEnvio.Visible = true;
                PlEnfarde.Visible = true;
                if (Proceso == "Tendido")
                {
                    VerTendido();
                }
                else if (Proceso == "Enfarde" || Proceso == "Analizado")
                {
                    VerTendido();
                    VerEnfarde();
                }
                else if (Proceso == "Envio" || Proceso == "Envio SM")
                {
                    VerTendido();
                    VerEnfarde();
                    VerEnvioCp();
                }

            }
            else
            {
                TipoProceso();
            }
        }
        private void TipoProceso()
        {
            if (Proceso == "No Asignado" || Proceso == "")
            {
                //Enfarde
                TSLEnfarde.Visible = false;
                PlEnfarde.Visible = false;
                //Envio
                TSLEnvio.Visible = false;
                PlEnvio.Visible = false;
                //Tendido
                PlTendido.Enabled = true;
                PlTendido.Visible = true;
                DtpRetendido.Value = DTPFechaTendido.Value;
            }
            if (Proceso == "Tendido")
            {
                //Tendido
                PlTendido.Enabled = false;
                PlTendido.Visible = true;
                //Envio
                PlEnvio.Visible = false;
                TSLEnvio.Visible = false;
                //Enfarde
                TSLEnfarde.Visible = true;
                TSLEnfarde.Enabled = true;
                PlEnfarde.Visible = true;
                PlEnfarde.Enabled = true;
                VerTendido();
                if (Rechazos != 0)
                {
                    VerEnfarde();
                    DTPEnfarde.Enabled = false;
                    BtnEnvSM.Visible = true;
                    DtpReEnfarde.Enabled = true;
                    BtnEnfarde.Text = "ReEnfarde";
                }
                //Validar que las fechas de tendido no sean iguales para mostrar el ReTendido
                if (DtpRetendido.Value == DTPFechaTendido.Value)
                {
                    DtpRetendido.Visible = false;
                    LblFReTendido.Visible = false;
                    LblFechaReEnfarde.Visible = false;
                    DtpReEnfarde.Visible = false;
                    LblDtotal.Visible = false;
                    LblDTS.Visible = false;
                }
                else
                {
                    DtpRetendido.Visible = true;
                    LblFReTendido.Visible = true;
                    LblFechaReEnfarde.Visible = true;
                    DtpReEnfarde.Visible = true;
                    LblDtotal.Visible = true;
                    LblDTS.Visible = true;
                }
            }
            else if (Proceso == "Enfarde" || Proceso == "Analizado" || Estado == "Tendido/Rechazado")
            {
                LblMsj.Visible = true;
                //Tendido
                PlTendido.Enabled = false;
                PlTendido.Visible = true;
                //Enfarde
                PlEnfarde.Visible = true;
                PlEnfarde.Enabled = false;
                TSLEnfarde.Enabled = true;
                TSLEnfarde.Visible = true;
                if (Proceso == "Analizado")
                {
                    //Envio
                    PlEnvio.Enabled = true;
                    PlEnvio.Visible = true;
                    LblMsj.Visible = false;
                }
                else if (Estado == "Tendido/Rechazado")
                {
                    PlTendido.Enabled = true;
                    LblMsj.Text = "Rechazado por humedad";
                    LblMsj.Visible = true;
                    BtnTendido.Text = "ReTendido";
                    LblFReTendido.Visible = true;
                    DtpRetendido.Visible = true;
                    DTPFechaTendido.Enabled = false;
                    LblFechaReEnfarde.Visible = false;
                    DtpReEnfarde.Visible = false;
                    LblDtotal.Visible = false;
                    LblDTS.Visible = false;
                    //PlEnfarde.Enabled = true;
                }
                VerTendido();
                VerEnfarde();
                BtnEnvSM.Visible = true;
                PlEnfarde.Enabled = true;
                BtnEnfarde.Enabled = false;
                DTPEnfarde.Enabled = false;
                TxtSacosEnfardados.Enabled = false;
                TxtHumedadLevante.Enabled = false;
                //double Humedad = double.Parse(TxtHumedadLevante.Text);
                //if (Humedad >= 13)
                //{
                //}
                if (LblDiasSecado.Text == "--" || Estado == "Tendido/Rechazado" || LblFReTendido.Visible == false)
                {
                    LblFechaReEnfarde.Visible = false;
                    LblDTS.Visible = false;
                    DtpReEnfarde.Visible = false;
                    LblDtotal.Visible = false;
                }
                else
                {
                    LblFechaReEnfarde.Visible = true;
                    LblDTS.Visible = true;
                    DtpReEnfarde.Visible = true;
                    LblDtotal.Visible = true;
                }
                if (Rechazos != 0)
                {
                    if (Estado == "Enfarde" || Estado == "Analizado")
                    {
                        Rechazado();
                    }
                }
            }
            else if (Proceso == "Envio" || Proceso == "Envio SM" || Proceso == "Almacén")
            {
                PlTendido.Enabled = false;
                PlTendido.Visible = true;
                PlEnvio.Visible = true;
                PlEnvio.Enabled = false;
                PlEnfarde.Enabled = false;
                PlEnfarde.Visible = true;
                TSLEnvio.Visible = true;
                TSLEnvio.Enabled = true;
                LblMsj.Visible = false;
                VerTendido();
                VerEnfarde();
                VerEnvioCp();
                if (Rechazos != 0)
                {
                    Rechazado();
                }
            }
        }
        private void Rechazado()
        {
            LblFReTendido.Visible = true;
            DtpRetendido.Visible = true;
            LblFechaReEnfarde.Visible = true;
            DtpReEnfarde.Visible = true;
            LblDTS.Visible = true;
            LblDtotal.Visible = true;
            DtpReEnfarde.Enabled = false;
        }

        private void AbrirFormulario()
        {
            //PlControl.Location = new Point(dtInventariocp.Width / 2
            //    - PlControl.Width / 2, dtInventariocp.Height / 2 - PlControl.Height / 3);
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Verificamos si el panel es más grande que el formulario y ajustamos si es necesario
            if (PlControl.Width > formWidth)
            {
                PlControl.Width = formWidth - 20; // Agregamos un margen
            }

            if (PlControl.Height > formHeight)
            {
                PlControl.Height = formHeight - 20; // Agregamos un margen
            }

            // Luego calculamos la nueva ubicación centrada
            int newX = (formWidth - PlControl.Width) / 2;
            int newY = (formHeight - PlControl.Height) / 2;

            PlControl.Location = new System.Drawing.Point(newX, newY);


            PlControl.Visible = true;
            PlControl.BringToFront();
            plOpciones.Enabled = false;
            if (LblCert.Text == "Convencional")
            {
                PlDatos.BackColor = Color.FromArgb(192, 255, 192);
            }
            else
            {
                PlDatos.BackColor = Color.FromArgb(192, 255, 255);
            }
            dtInventariocp.Enabled = false;
            DControlPatio Ten = new DControlPatio();
            Ten.MostrarPatio(CbPatio);
            //Ten.MostrarPatioUbicacion(CbUbicacionP,(int)CbPatio.SelectedValue);
            LblDigitadorCp.Text = Login.NombreA;
            Ten.MostrarAreaSecado(CbDestino);
            Ten.MostrarEstFis(CbEstFis);
        }
        private void ObtenerDatos()
        {
            DControlPatio funcion = new DControlPatio();
            DataTable dt = new DataTable();

            try
            {
                funcion.MostrarDetalleTendido(ref dt, Ticket);

                if (dt.Rows.Count > 0)
                {
                    double kilos;
                    DataRow row = dt.Rows[0];
                    if (row["Certificacion"].ToString() != null)
                    {
                        LblCert.Text = row["Certificacion"].ToString();
                    }
                    else
                    {
                        LblCert.Text = "";
                    }
                    LblTicket.Text = Ticket.ToString();
                    Frecibido = DateTime.Parse(row["Fecha Recibido"].ToString());
                    LblEstFis.Text = row["Estado Físico"].ToString();
                    LblCalidad.Text = row["Calidad"].ToString();
                    LblDanio.Text = row["Daño"].ToString();
                    LblSacos.Text = row["Sacos"].ToString();
                    LblPeso.Text = row["Peso"].ToString();
                    kilos = double.Parse(LblPeso.Text);
                    kilos = kilos / 46;
                    LblQQs.Text = Math.Round(kilos, 2).ToString();
                    Proceso = row["Proceso SN"].ToString();
                    string nombrecolumna = "Cliente";
                    int indice = dtInventariocp.Columns[nombrecolumna].Index;
                    LblCliente.Text = dtInventariocp.SelectedCells[indice].Value.ToString();

                    string nombrecolumna2 = "Tipo Compra";
                    int indice2 = dtInventariocp.Columns[nombrecolumna2].Index;
                    LblTCompra.Text = dtInventariocp.SelectedCells[indice2].Value.ToString();
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para el ticket especificado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Limpiar()
        {
            LblTicket.Text = "--";
            LblSacos.Text = "--";
            LblPeso.Text = "--";
            LblQQs.Text = "--";
            LblEstFis.Text = "--";
            LblCalidad.Text = "--";
            LblDanio.Text = "--";
            LblCert.Text = "--";
            Proceso = null;
            Ticket = null;
            //Tendido
            TxtFolio.Clear();
            CbPatio.Text = "--";
            CbUbicacionP.Text = "--";
            LblDigitadorCp.Text = "--";
            //Enfarde
            LblDiasSecado.Text = "--";
            TxtSacosEnfardados.Clear();
            TxtHumedadLevante.Clear();
            LblDigitadorEnfar.Text = "--";
            //Envio
            CbDestino.Text = "--";
            TxtDNIN.Clear();
            CbEstFis.Text = "--";
            LblDigiEnvio.Text = "--";
            dtInventariocp.Enabled = true;
        }
        private void BtnCerrarDetalleCp_Click(object sender, EventArgs e)
        {
            PlControl.Visible = false;
            plOpciones.Enabled = true;
            PlTendido.Visible = false;
            PlEnfarde.Visible = false;
            PlEnvio.Visible = false;
            LblMsj.Text = "Falta Análisis de Catación";
            BtnEnfarde.Text = "Enfarde";
            LblMsj.Visible = false;
            BtnTendido.Text = "Tendido";
            LblFReTendido.Visible = false;
            DtpRetendido.Visible = false;
            DTPFechaTendido.Enabled = true;
            DTPEnfarde.Enabled = true;
            LblFechaReEnfarde.Visible = false;
            DtpReEnfarde.Visible = false;
            LblDtotal.Visible = false;
            LblDTS.Visible = false;
            TxtSacosEnfardados.Enabled = true;
            TxtHumedadLevante.Enabled = true;
            BtnEnfarde.Enabled = true;
            Limpiar();
        }
        private void ObtenerTK()
        {
            string nombrecolumna = "Ticket";
            int indice = dtInventariocp.Columns[nombrecolumna].Index;
            Ticket = dtInventariocp.SelectedCells[indice].Value.ToString();

            string nombrecolum = "Proceso SN";
            int num = dtInventariocp.Columns[nombrecolum].Index;
            Estado = dtInventariocp.SelectedCells[num].Value.ToString();
        }
        private void InsertarTendido()
        {
            if (validar())
            {
                if (DTPFechaTendido.Value.Date <= DateTime.Today.Date)
                {
                    LControlPatio parametros = new LControlPatio();
                    DControlPatio funcion = new DControlPatio();
                    parametros.Ticket = LblTicket.Text;
                    parametros.Folio = int.Parse(TxtFolio.Text);
                    parametros.FechaT = DateTime.Parse(DTPFechaTendido.Value.Date.ToString());
                    parametros.ReTendido = DateTime.Parse(DtpRetendido.Value.Date.ToString());
                    parametros.IdPatio = int.Parse(CbPatio.SelectedValue.ToString());
                    parametros.IdUbicacionP = int.Parse(CbUbicacionP.SelectedValue.ToString());
                    parametros.Digitador = Login.NombreA;
                    parametros.Rechazos = 0;
                    if (funcion.InsertarTendido(parametros) == true)
                    {
                        MessageBox.Show("Tendido realizado con éxito", "Realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //MostrarLotes();
                        Limpiar();
                        PlControl.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("La fecha de recibido no puede ser mayor a la fecha de dia de hoy", "Error en la fecha", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        private void InsertarReTendido()
        {
            if (validar())
            {
                if (DTPFechaTendido.Value.Date <= DateTime.Today.Date)
                {
                    LControlPatio parametros = new LControlPatio();
                    DControlPatio funcion = new DControlPatio();
                    parametros.Ticket = LblTicket.Text;
                    parametros.Folio = int.Parse(TxtFolio.Text);
                    parametros.FechaT = DateTime.Parse(DTPFechaTendido.Value.Date.ToString());
                    parametros.ReTendido = DateTime.Parse(DtpRetendido.Value.Date.ToString());
                    parametros.IdPatio = int.Parse(CbPatio.SelectedValue.ToString());
                    parametros.IdUbicacionP = int.Parse(CbUbicacionP.SelectedValue.ToString());
                    parametros.Digitador = Login.NombreA;
                    parametros.Rechazos = Rechazos + 1;
                    if (funcion.InsertarRetendido(parametros) == true)
                    {
                        MessageBox.Show("ReTendido realizado con éxito", "Realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //MostrarLotes();
                        Limpiar();
                        PlControl.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("La fecha de recibido no puede ser mayor a la fecha de dia de hoy", "Error en la fecha", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        private void EditarTendido()
        {
            if (validar())
            {
                if (DTPFechaTendido.Value.Date <= DateTime.Today.Date)
                {
                    if (edit < 3 || Login.login.Trim().StartsWith("Admin", StringComparison.OrdinalIgnoreCase))
                    {
                        LControlPatio parametros = new LControlPatio();
                        DControlPatio funcion = new DControlPatio();
                        parametros.Ticket = LblTicket.Text;
                        parametros.Folio = int.Parse(TxtFolio.Text);
                        parametros.FechaT = DateTime.Parse(DTPFechaTendido.Value.Date.ToString());
                        parametros.ReTendido = DateTime.Parse(DtpRetendido.Value.Date.ToString());
                        parametros.IdPatio = int.Parse(CbPatio.SelectedValue.ToString());
                        parametros.IdUbicacionP = int.Parse(CbUbicacionP.SelectedValue.ToString());
                        parametros.Digitador = Login.NombreA;
                        if (BtnTendido.Text == "ReTendido")
                        {
                            edit = edit + 0;
                        }
                        else
                        {
                            edit = edit + 1;
                        }
                        if (funcion.EditarTendido(parametros, edit) == true)
                        {
                            MessageBox.Show("Edición de Tendido realizado con éxito", "Realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MostrarLotes();
                            Limpiar();
                            PlControl.Visible = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ya supero los 3 intentos de edición, comuniquese con un administrador", "Superó los intentos de edición", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("La fecha de recibido no puede ser mayor a la fecha de dia de hoy", "Error en la fecha", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        private void BtnTendido_Click(object sender, EventArgs e)
        {
            if (BtnTendido.Text == "Tendido")
            {
                InsertarTendido();
                Limpiar();
            }
            else if (BtnTendido.Text == "ReTendido")
            {
                if (DTPEnfarde.Value > DtpRetendido.Value)
                {
                    MessageBox.Show("Error en la Fecha de ReTendido, por favor verificar la Fecha", "Error Fecha menor que Enfarde", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    InsertarReTendido();
                    PlTendido.Enabled = false;
                    BtnTendido.Text = "Tendido";
                    Limpiar();
                }
            }
            else
            {
                EditarTendido();
                PlTendido.Enabled = false;
                BtnTendido.Text = "Tendido";
                Limpiar();
            }
            plOpciones.Enabled = true;
            //Limpiar();
        }
        private void CbPatio_SelectedIndexChanged(object sender, EventArgs e)
        {
            DControlPatio funcion = new DControlPatio();
            funcion.MostrarPatioUbicacion(CbUbicacionP, (int)CbPatio.SelectedValue);
        }
        private void TSLTendido_Click(object sender, EventArgs e)
        {
            ValidarPermisos();
            if (PlTendido.Enabled == true)
            {
                PlTendido.Enabled = false;
                BtnTendido.Text = "Tendido";
            }
            else
            {
                BtnTendido.Visible = true;
                PlTendido.Enabled = true;
                BtnTendido.Text = "Actualizar";
            }
        }
        private bool validar()
        {
            double entero;
            if (!double.TryParse(TxtFolio.Text, out entero))
            {
                return false;
            }
            return !(TxtFolio.Text == "" || CbPatio.Text == "" || CbUbicacionP.Text == "");
        }
        private void BtnEnfarde_Click(object sender, EventArgs e)
        {
            if (BtnEnfarde.Text == "Enfarde")
            {
                InsertarEnfarde();
            }
            else if (BtnEnfarde.Text == "ReEnfarde")
            {
                if (DtpRetendido.Value > DtpReEnfarde.Value)
                {
                    MessageBox.Show("No se puede realizar el ReEnfarde porque la Fecha es menor que la Fecha de ReTendido", "Error en ReEnfarde", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    InsertarReEnfarde();
                    PlTendido.Enabled = false;
                    PlEnfarde.Enabled = false;
                    BtnEnfarde.Text = "Enfarde";
                }
            }
            else
            {
                EditarEnfarde();
                PlTendido.Enabled = false;
                PlEnfarde.Enabled = false;
                BtnEnfarde.Text = "Enfarde";
            }
            plOpciones.Enabled = true;
            Limpiar();
        }
        private void TSLEnfarde_Click(object sender, EventArgs e)
        {
            ValidarPermisos();
            if (PlEnfarde.Enabled == true)
            {
                PlEnfarde.Enabled = false;
                BtnEnfarde.Text = "Enfarde";
            }
            else
            {
                BtnEnfarde.Visible = true;
                PlEnfarde.Enabled = true;
                BtnEnfarde.Enabled = true;
                DTPEnfarde.Enabled = true;
                TxtSacosEnfardados.Enabled = true;
                TxtHumedadLevante.Enabled = true;
                BtnEnfarde.Text = "Actualizar";
            }
        }
        private void DTPEnfarde_ValueChanged(object sender, EventArgs e)
        {
            DateTime Enfarde = DTPEnfarde.Value;
            DateTime Tendido = DTPFechaTendido.Value;
            TimeSpan Diferencia = Enfarde - Tendido;
            dias = Diferencia.Days;
            LblDiasSecado.Text = dias.ToString();
            DtpReEnfarde.Value = DTPEnfarde.Value;
            LblDtotal.Text = dias.ToString();
        }
        private void InsertarEnfarde()
        {
            if (validarEnfarde())
            {
                if (DTPEnfarde.Value.Date <= DateTime.Today.Date)
                {
                    LControlPatio parametros = new LControlPatio();
                    DControlPatio funcion = new DControlPatio();
                    parametros.IdTendido = IdTendido;
                    parametros.FEnfarde = DateTime.Parse(DTPEnfarde.Value.Date.ToString());
                    parametros.FReEnfarde = DateTime.Parse(DtpReEnfarde.Value.Date.ToString());
                    parametros.DiasSecado = int.Parse(LblDiasSecado.Text.ToString());
                    parametros.DTotal = int.Parse(LblDtotal.Text.ToString());
                    parametros.Sacos = int.Parse(TxtSacosEnfardados.Text.ToString());
                    parametros.HumedadL = double.Parse(TxtHumedadLevante.Text.ToString());
                    parametros.Digitador = Login.NombreA;
                    if (funcion.InsertarEnfarde(parametros) == true)
                    {
                        MessageBox.Show("Enfarde realizado con éxito", "Realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //MostrarLotes();
                        Limpiar();
                        PlControl.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("La fecha de recibido no puede ser mayor a la fecha de dia de hoy", "Error en la fecha", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show("Existen campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InsertarReEnfarde()
        {
            if (validarEnfarde())
            {
                if (DtpReEnfarde.Value.Date <= DateTime.Today.Date)
                {
                    LControlPatio parametros = new LControlPatio();
                    DControlPatio funcion = new DControlPatio();
                    parametros.IdTendido = IdTendido;
                    parametros.IdEnfarde = IdEnfarde;
                    parametros.FEnfarde = DateTime.Parse(DTPEnfarde.Value.Date.ToString());
                    parametros.FReEnfarde = DateTime.Parse(DtpReEnfarde.Value.Date.ToString());
                    parametros.DiasSecado = int.Parse(LblDiasSecado.Text.ToString());
                    parametros.DTotal = int.Parse(LblDtotal.Text.ToString());
                    parametros.Sacos = int.Parse(TxtSacosEnfardados.Text.ToString());
                    parametros.HumedadL = double.Parse(TxtHumedadLevante.Text.ToString());
                    parametros.Digitador = Login.NombreA;
                    if (funcion.InsertarReEnfarde(parametros) == true)
                    {
                        MessageBox.Show("ReEnfarde realizado con éxito", "Realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //MostrarLotes();
                        Limpiar();
                        PlControl.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("La fecha de recibido no puede ser mayor a la fecha de dia de hoy", "Error en la fecha", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show("Existen campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool validarEnfarde()
        {
            double entero;
            if (!double.TryParse(TxtSacosEnfardados.Text, out entero) || !double.TryParse(TxtHumedadLevante.Text, out entero))
            {
                return false;
            }
            return !(TxtSacosEnfardados.Text == "" || TxtHumedadLevante.Text == "");
        }
        private void TSLEnvio_Click(object sender, EventArgs e)
        {
            ValidarPermisos();
            if (PlEnvio.Enabled == true)
            {
                PlEnvio.Enabled = false;
                BtnEnviar.Text = "Envio";
            }
            else
            {
                BtnEnviar.Visible = true;
                PlEnvio.Enabled = true;
                BtnEnviar.Text = "Actualizar";
            }
        }
        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (BtnEnviar.Text == "Enviar")
            {
                InsertarEnvio();
            }
            else
            {
                EditarEnvio();
                PlTendido.Enabled = false;
                PlEnfarde.Enabled = false;
                PlEnvio.Enabled = false;
                BtnEnviar.Text = "Enviar";
            }
            plOpciones.Enabled = true;
            Limpiar();
        }
        private void VerTendido()
        {
            DControlPatio funcion = new DControlPatio();
            DataTable dt = new DataTable();
            try
            {
                funcion.MostrarDetalleTendido(ref dt, Ticket);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    if (row["Folio"].ToString() != null)
                    {
                        TxtFolio.Text = row["Folio"].ToString();
                    }
                    else
                    {
                        TxtFolio.Text = "";
                    }
                    if (row["Edit"].ToString() != null)
                    {
                        edit = int.Parse(row["Edit"].ToString());
                    }
                    else
                    {
                        edit = 0;
                    }
                    if (row["Fecha Tendido"].ToString() != null)
                    {
                        DTPFechaTendido.Value = DateTime.Parse(row["Fecha Tendido"].ToString());
                    }
                    else
                    {
                        DTPFechaTendido.Value = DateTime.Today;
                    }
                    if (!string.IsNullOrEmpty(row["ReTendido"].ToString()))
                    {
                        // Verificar si se puede parsear a DateTime antes de asignar
                        if (DateTime.TryParse(row["ReTendido"].ToString(), out DateTime retendidoDate))
                        {
                            DtpRetendido.Value = retendidoDate;
                        }
                    }
                    else
                    {
                        DtpRetendido.Value = DTPFechaTendido.Value;
                    }
                    CbPatio.Text = row["Patio"].ToString();
                    CbUbicacionP.Text = row["Ubicación Patio"].ToString();
                    LblDigitadorCp.Text = row["Digitador"].ToString();
                    Rechazos = int.Parse(row["Rechazos"].ToString());
                    IdTendido = int.Parse(row["IdTendido"].ToString());
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para el ticket especificado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos Tendido " + ex.Message, "ERROR Tendido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void VerEnfarde()
        {
            DControlPatio funcion = new DControlPatio();
            DataTable dt = new DataTable();
            try
            {
                funcion.MostrarDetalleEnfarde(ref dt, Ticket);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    if (row["Días Secado"].ToString() != null)
                    {
                        LblDiasSecado.Text = row["Días Secado"].ToString();
                        diasEdit = int.Parse(LblDiasSecado.Text);
                    }
                    else
                    {
                        LblDiasSecado.Text = "00";
                    }
                    if (row["Edit"].ToString() != null)
                    {
                        editenf = int.Parse(row["Edit"].ToString());
                    }
                    else
                    {
                        editenf = 0;
                    }
                    if (row["Fecha Enfarde"].ToString() != null)
                    {
                        DTPEnfarde.Value = DateTime.Parse(row["Fecha Enfarde"].ToString());
                    }
                    else
                    {
                        DTPEnfarde.Value = DateTime.Today;
                    }
                    if (!string.IsNullOrEmpty(row["ReEnfarde"].ToString()))
                    {
                        // Verificar si se puede parsear a DateTime antes de asignar
                        if (DateTime.TryParse(row["ReEnfarde"].ToString(), out DateTime reenfardeDate))
                        {
                            DtpReEnfarde.Value = reenfardeDate;
                        }
                    }
                    else
                    {
                        DtpReEnfarde.Value = DTPEnfarde.Value;
                    }
                    if (row["TotalDias"].ToString() != null)
                    {
                        LblDtotal.Text = row["TotalDias"].ToString();
                        //diasEdit = int.Parse(LblDiasSecado.Text);
                    }
                    else
                    {
                        LblDtotal.Text = LblDiasSecado.Text;
                    }
                    if (row["Sacos Enfardados"].ToString() != null)
                    {
                        TxtSacosEnfardados.Text = row["Sacos Enfardados"].ToString();
                    }
                    else
                    {
                        TxtSacosEnfardados.Clear();
                    }
                    if (row["Humedad Levante"].ToString() != null)
                    {
                        TxtHumedadLevante.Text = row["Humedad Levante"].ToString();
                    }
                    else
                    {
                        TxtHumedadLevante.Clear();
                    }
                    if (row["Digitador"].ToString() != null)
                    {
                        LblDigitadorEnfar.Text = row["Digitador"].ToString();
                    }
                    else
                    {
                        LblDigitadorEnfar.Text = "--";
                    }
                    IdEnfarde = int.Parse(row["IdEnfarde"].ToString());
                    Rechazos = int.Parse(row["Rechazos"].ToString());
                    TSLEnfarde.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para el ticket especificado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos Tendido " + ex.Message, "ERROR Tendido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            //if (txtBuscador.Text == "")
            //{
            //    ReiniciarPaginado();
            //    MostrarLotes();
            //}
            //else if (CbBuscador.Text == "Peso")
            //{
            //    Buscar();
            //    ReiniciarPaginado();
            //}
            //else
            //{
            //    BuscarTk();
            //    ReiniciarPaginado();
            //}
        }
        private void EditarEnfarde()
        {
            if (validar())
            {
                if (editenf < 3 || Login.login.Trim().StartsWith("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    if (DTPEnfarde.Value.Date <= DateTime.Today.Date)
                    {
                        LControlPatio parametros = new LControlPatio();
                        DControlPatio funcion = new DControlPatio();
                        parametros.IdEnfarde = IdEnfarde;
                        parametros.IdTendido = IdTendido;
                        parametros.FEnfarde = DateTime.Parse(DTPEnfarde.Value.Date.ToString());
                        parametros.FReEnfarde = DateTime.Parse(DtpReEnfarde.Value.Date.ToString());
                        parametros.DiasSecado = int.Parse(LblDiasSecado.Text);
                        parametros.DTotal = int.Parse(LblDtotal.Text);
                        parametros.HumedadL = double.Parse(TxtHumedadLevante.Text.ToString());
                        parametros.Sacos = int.Parse(TxtSacosEnfardados.Text.ToString());
                        parametros.Digitador = Login.NombreA;
                        parametros.Rechazos = Rechazos;
                        editenf = editenf + 1;
                        if (funcion.EditarEnfarde(parametros, editenf) == true)
                        {
                            MessageBox.Show("Edición de Enfarde realizado con éxito", "Realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MostrarLotes();
                            Limpiar();
                            PlControl.Visible = false;
                        }
                        //if (BtnEnfarde.Text == "Actualizar")
                        //{
                        //    parametros.Rechazos = Rechazos;
                        //    parametros.DiasSecado = int.Parse(LblDiasSecado.Text);
                        //    editenf = editenf + 1;
                        //    if (funcion.EditarEnfarde(parametros, editenf) == true)
                        //    {
                        //        MessageBox.Show("Edición de Enfarde realizado con éxito", "Realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //        MostrarLotes();
                        //        Limpiar();
                        //        PlControl.Visible = false;
                        //    }
                        //}
                        //else if (BtnEnfarde.Text == "Re-Enfarde")
                        //{
                        //    parametros.Rechazos = Rechazos + 1;
                        //    if (diasEdit >= dias)
                        //    {
                        //        MessageBox.Show("El Re-Enfarde es erroneo por la cantidad de dias", "Error en dias Re-Enfarde", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    }
                        //    else
                        //    {
                        //        parametros.DiasSecado = int.Parse(LblDiasSecado.Text);
                        //        if (funcion.EditarEnfarde(parametros, editenf) == true)
                        //        {
                        //            MessageBox.Show("Edición de Enfarde realizado con éxito", "Realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //            MostrarLotes();
                        //            Limpiar();
                        //            PlControl.Visible = false;
                        //        }
                        //    }
                        //}
                    }
                    else
                    {
                        MessageBox.Show("La fecha de recibido no puede ser mayor a la fecha de dia de hoy", "Error en la fecha", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("Ya supero los 3 intentos de edición, comuniquese con un administrador", "Superó los intentos de edición", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
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
                BtnBuscar.Visible = true;
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
            else if (CbBuscar.Text == "Patio")
            {
                TextBuscarVisible();
                DControlPatio T = new DControlPatio();
                T.MostrarPatio(CbBuscador);
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
            BtnBuscar.Visible = false;
        }
        private void CbDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbDestino.Text == "Secado Mecánico")
            {
                CbEstFis.Text = "Pre-Seco";
            }
            else if (CbDestino.Text == "Almacén")
            {
                CbEstFis.Text = "Seco";
            }
        }
        private void PbExcel_Click(object sender, EventArgs e)
        {
            DControlPatio funcion = new DControlPatio();
            DataTable dt = new DataTable();
            funcion.LotesExcelCP(ref dt);
            string Nombre = "Control de Patio ";
            FrmLotes_Tendido LT = new FrmLotes_Tendido(dt, Nombre);
            LT.ShowDialog();
        }
        private void BtnEnvSM_Click(object sender, EventArgs e)
        {
            LblMsj.Visible = false;
            PlEnvio.Enabled = true;
            PlEnvio.Visible = true;
            CbDestino.Text = "Secado Mecánico";
            CbDestino.Enabled = false;
        }
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            PlFiltros.Visible = false;
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
                Buscar();
                ReiniciarPaginado();
            }
        }

        private void InsertarEnvio()
        {
            if (validarEnvio())
            {
                if (DTEnvio.Value.Date <= DateTime.Today.Date)
                {
                    LControlPatio parametros = new LControlPatio();
                    DControlPatio funcion = new DControlPatio();
                    parametros.IdEnfarde = IdEnfarde;
                    parametros.FEnvio = DateTime.Parse(DTEnvio.Value.ToString());
                    parametros.DNIN = int.Parse(TxtDNIN.Text.ToString());
                    parametros.IdEstFis = int.Parse(CbEstFis.SelectedValue.ToString());
                    parametros.IdAreaSecado = int.Parse(CbDestino.SelectedValue.ToString());
                    parametros.Digitador = Login.NombreA;
                    if (funcion.InsertarEnvio(parametros) == true)
                    {
                        MessageBox.Show("Envio realizado con éxito", "Realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //MostrarLotes();
                        Limpiar();
                        PlControl.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Existen campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("La fecha de recibido no puede ser mayor a la fecha de dia de hoy", "Error en la fecha", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void BtnFiltroFecha_Click(object sender, EventArgs e)
        {
            BuscarFechaCP();
            ReiniciarPaginado();
        }

        private void PbFiltro_Click(object sender, EventArgs e)
        {
            PlFiltros.Location = new Point(dtInventariocp.Width / 2
                - PlFiltros.Width / 2, dtInventariocp.Height / 2 - PlFiltros.Height / 2);
            PlFiltros.Visible = true;
            PlFiltros.BringToFront();
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarColumnas();
            PlFiltros.Visible = false;
        }
        private void FiltrarColumnas()
        {
            foreach (DataGridViewColumn column in dtInventariocp.Columns)
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

        private void DTPFechaTendido_ValueChanged(object sender, EventArgs e)
        {
            DtpRetendido.Value = DTPFechaTendido.Value;
        }

        private void DtpReEnfarde_ValueChanged(object sender, EventArgs e)
        {
            DateTime Enfarde = DtpReEnfarde.Value;
            DateTime Tendido = DtpRetendido.Value;
            TimeSpan Diferencia = Enfarde - Tendido;
            int Tdias = Diferencia.Days;
            int DiasSecado = int.Parse(LblDiasSecado.Text);
            Tdias = Tdias + DiasSecado;
            LblDtotal.Text = Tdias.ToString();
        }

        private async void BtnActualizar_Click(object sender, EventArgs e)
        {
            //await CargarDatos();
            MessageBox.Show("Datos Actualizados", "Refrescar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscador.Text == "")
            {
                ReiniciarPaginado();
                MostrarLotes();
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

        private void BtnRechazos_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DControlPatio Cp= new DControlPatio();
            Cp.LotesRechazos(ref dt);
            string Nombre = "Lotes Rechazados ";
            FrmLotes_Tendido LT = new FrmLotes_Tendido(dt, Nombre);
            LT.ShowDialog();
        }

        private bool validarEnvio()
        {
            return !(TxtDNIN.Text == "" || CbEstFis.Text == "" || CbDestino.Text == "");
        }
        private void VerEnvioCp()
        {
            DControlPatio funcion = new DControlPatio();
            DataTable dt = new DataTable();
            try
            {
                funcion.MostrarDetalleEnvioCP(ref dt, Ticket);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    if (row["Fecha Envio"].ToString() != null)
                    {
                        DTEnvio.Value = DateTime.Parse(row["Fecha Envio"].ToString());
                    }
                    else
                    {
                        DTEnvio.Value = DateTime.Today;
                    }
                    if (row["DNIN"].ToString() != null)
                    {
                        TxtDNIN.Text = row["DNIN"].ToString();
                    }
                    else
                    {
                        TxtDNIN.Clear();
                    }
                    if (row["Estado Fisico"].ToString() != null)
                    {
                        CbEstFis.Text = row["Estado Fisico"].ToString();
                    }
                    else
                    {
                        CbEstFis.Text = "";
                    }
                    if (row["AreaSecado"].ToString() != null)
                    {
                        CbDestino.Text = row["AreaSecado"].ToString();
                    }
                    else
                    {
                        CbDestino.Text = "";
                    }
                    if (row["DigitatorEnCp"].ToString() != null)
                    {
                        LblDigiEnvio.Text = row["DigitatorEnCp"].ToString();
                    }
                    else
                    {
                        LblDigiEnvio.Text = "--";
                    }
                    if (row["Edit"].ToString() != null)
                    {
                        editEn = int.Parse(row["Edit"].ToString());
                    }
                    else
                    {
                        editEn = 0;
                    }
                    IdEnvio = int.Parse(row["IdEnvio"].ToString());
                    TSLEnfarde.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para el ticket especificado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos Tendido " + ex.Message, "ERROR Tendido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EditarEnvio()
        {
            if (validarEnvio())
            {
                if (DTEnvio.Value.Date <= DateTime.Today.Date)
                {
                    LControlPatio parametros = new LControlPatio();
                    DControlPatio funcion = new DControlPatio();
                    parametros.IdEnvio = IdEnvio;
                    parametros.IdEnfarde = IdEnfarde;
                    parametros.FEnvio = DateTime.Parse(DTEnvio.Value.ToString());
                    parametros.DNIN = int.Parse(TxtDNIN.Text.ToString());
                    parametros.IdEstFis = int.Parse(CbEstFis.SelectedValue.ToString());
                    parametros.IdAreaSecado = int.Parse(CbDestino.SelectedValue.ToString());
                    parametros.Digitador = Login.NombreA;
                    editEn = editEn + 1;
                    if (funcion.EditarEnvio(parametros, editEn) == true)
                    {
                        MessageBox.Show("Envio realizado con éxito", "Realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //MostrarLotes();
                        Limpiar();
                        PlControl.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Existen campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("La fecha de recibido no puede ser mayor a la fecha de dia de hoy", "Error en la fecha", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        private void Buscar()
        {
            DataTable dt = new DataTable();
            DControlPatio funcion = new DControlPatio();
            funcion.BuscarTKCP(CbBuscador.Text, ref dt, desde, hasta, ContarBusqueda, CbBuscar.Text);
            dtInventariocp.DataSource = dt;
            ContarBusqueda = int.Parse(funcion.contador.ToString());
            Base.DiseñoDtvEliminar(ref dtInventariocp);
        }
        private void BuscarTk()
        {
            DataTable dt = new DataTable();
            DControlPatio funcion = new DControlPatio();
            funcion.BuscarTKCP(txtBuscador.Text, ref dt, desde, hasta, ContarBusqueda, CbBuscar.Text);
            dtInventariocp.DataSource = dt;
            ContarBusqueda = int.Parse(funcion.contador.ToString());
            Base.DiseñoDtvEliminar(ref dtInventariocp);
        }
        private void BuscarFechaCP()
        {
            DataTable dt = new DataTable();
            DControlPatio funcion = new DControlPatio();
            funcion.BuscarFechaCP(ref dt, DtpInicio.Value, DtpFin.Value, desde, hasta, ContarBusqueda);
            dtInventariocp.DataSource = dt;
            ContarBusqueda = int.Parse(funcion.contador.ToString());
            Base.DiseñoDtvEliminar(ref dtInventariocp);
        }
        private void ValidarPermisos()
        {
            DataTable dt = new DataTable();
            DModulos funcion = new DModulos();
            LPermisos parametros = new LPermisos();
            parametros.IdUser = Login.Iduser;
            funcion.PermisosUser(ref dt, Login.Iduser);

            bool tieneAgregarSN = false;
            bool tieneEditarSN = false;

            foreach (DataRow rowpermisos in dt.Rows)
            {
                Modulo = Convert.ToString(rowpermisos["Modulo"]);
                if (Modulo == "Agregar SN")
                {
                    tieneAgregarSN = true;
                }
                if (Modulo == "Editar SN")
                {
                    tieneEditarSN = true;
                }
            }

            if (tieneAgregarSN && tieneEditarSN)
            {
                BtnTendido.Visible = true;
                BtnEnfarde.Visible = true;
                BtnEnvSM.Visible = true;
                BtnEnviar.Visible = true;
                toolStrip1.Visible = true;
            }
            else if (tieneAgregarSN)
            {
                BtnTendido.Visible = true;
                BtnEnfarde.Visible = true;
                BtnEnvSM.Visible = true;
                BtnEnviar.Visible = true;
                toolStrip1.Visible = false;
            }
            else if (tieneEditarSN)
            {
                BtnTendido.Visible = false;
                BtnEnfarde.Visible = false;
                BtnEnviar.Visible = false;
                toolStrip1.Visible = true;
            }
            else
            {
                BtnTendido.Visible = false;
                BtnEnfarde.Visible = false;
                BtnEnviar.Visible = false;
                toolStrip1.Visible = false;
            }
        }

    }
}
