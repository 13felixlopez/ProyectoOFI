using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using ProyectoOFI.Otros;
using System;
using System.Data;
using System.Drawing;
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
        int dias;
        public CUControlPatio()
        {
            InitializeComponent();
        }
        private async void CUControlPatio_Load(object sender, EventArgs e)
        {
            PlCarga.Dock = DockStyle.Fill;
            await CargarDatos();
            Base.DiseñoDtvEliminar(ref dtInventariocp);
            PlCarga.Visible = false;
        }
        private async Task CargarDatos()
        {
            await Task.Delay(1500);
            dtInventariocp.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            MostrarLotes();
            ReiniciarPaginado();
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
            else if (CbBuscador.Visible == true)
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
                Buscar();
            }
            else if (CbBuscador.Visible == true)
            {
                //BuscarDatos();
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
                Buscar();
            }
            else if (CbBuscador.Visible == true)
            {
                //BuscarDatos();
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
                Buscar();
            }
            else if (CbBuscador.Visible == true)
            {
                //BuscarDatos();
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
                Buscar();
            }
            else if (CbBuscador.Visible == true)
            {
                //BuscarDatos();
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
                    VerTendidio();
                }
                else if (Proceso == "Enfarde")
                {
                    VerTendidio();
                    VerEnfarde();
                }
                else if (Proceso == "Envio")
                {
                    VerTendidio();
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
            }
            if (Proceso == "Tendido")
            {
                //Tendido
                PlTendido.Enabled = false;
                //Envio
                PlEnvio.Visible = false;
                TSLEnvio.Visible = false;
                //Enfarde
                TSLEnfarde.Visible = true;
                TSLEnfarde.Enabled = true;
                PlEnfarde.Visible = true;
                PlEnfarde.Enabled = true;
                VerTendidio();
            }
            else if (Proceso == "Enfarde")
            {
                //Tendido
                PlTendido.Enabled = false;
                //Enfarde
                PlEnfarde.Visible = true;
                TSLEnfarde.Enabled = true;
                TSLEnfarde.Visible = true;
                //Envio
                PlEnvio.Visible = true;
                PlEnfarde.Enabled = true;
                VerTendidio();
                VerEnfarde();
            }
            else if (Proceso == "Envio")
            {
                PlTendido.Enabled = false;
                PlEnvio.Visible = true;
                PlEnvio.Enabled = false;
                PlEnfarde.Enabled = false;
                PlEnfarde.Visible = true;
                TSLEnvio.Visible = true;
                TSLEnvio.Enabled = true;
                VerTendidio();
                VerEnfarde();
                VerEnvioCp();
            }
        }
        private void VerTendidio()
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
                    CbPatio.Text = row["Patio"].ToString();
                    CbUbicacionP.Text = row["Ubicación Patio"].ToString();
                    LblDigitadorCp.Text = row["Digitador"].ToString();
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
        private void AbrirFormulario()
        {
            PlControl.Location = new Point(dtInventariocp.Width / 2
                - PlControl.Width / 2, dtInventariocp.Height / 2 - PlControl.Height / 2);
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
        }
        private void BtnCerrarDetalleCp_Click(object sender, EventArgs e)
        {
            PlControl.Visible = false;
            plOpciones.Enabled = true;
            Limpiar();
        }
        private void ObtenerTK()
        {
            string nombrecolumna = "Ticket";
            int indice = dtInventariocp.Columns[nombrecolumna].Index;
            Ticket = dtInventariocp.SelectedCells[indice].Value.ToString();

            string nombrecolum = "Proceso";
            int num = dtInventariocp.Columns[nombrecolum].Index;
            Estado = dtInventariocp.SelectedCells[num].Value.ToString();
        }
        private void InsertarTendido()
        {
            if (validar())
            {
                LControlPatio parametros = new LControlPatio();
                DControlPatio funcion = new DControlPatio();
                parametros.Ticket = LblTicket.Text;
                parametros.Folio = int.Parse(TxtFolio.Text);
                parametros.FechaT = DateTime.Parse(DTPFechaTendido.Value.ToString());
                parametros.IdPatio = int.Parse(CbPatio.SelectedValue.ToString());
                parametros.IdUbicacionP = int.Parse(CbUbicacionP.SelectedValue.ToString());
                parametros.Digitador = Login.NombreA;
                if (funcion.InsertarTendido(parametros) == true)
                {
                    MessageBox.Show("Tendido realizado con éxito", "Realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MostrarLotes();
                    Limpiar();
                    PlControl.Visible = false;
                }
            }
        }
        private void EditarTendido()
        {
            if (validar())
            {
                if (edit < 3 || Login.login.Trim().StartsWith("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    LControlPatio parametros = new LControlPatio();
                    DControlPatio funcion = new DControlPatio();
                    parametros.Ticket = LblTicket.Text;
                    parametros.Folio = int.Parse(TxtFolio.Text);
                    parametros.FechaT = DateTime.Parse(DTPFechaTendido.Value.ToString());
                    parametros.IdPatio = int.Parse(CbPatio.SelectedValue.ToString());
                    parametros.IdUbicacionP = int.Parse(CbUbicacionP.SelectedValue.ToString());
                    parametros.Digitador = Login.NombreA;
                    edit = edit + 1;
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
        }
        private void BtnTendido_Click(object sender, EventArgs e)
        {
            if (BtnTendido.Text == "Tendido")
            {
                InsertarTendido();
                plOpciones.Enabled = true;
            }
            else
            {
                EditarTendido();
                PlTendido.Enabled = false;
                BtnTendido.Text = "Tendido";
            }
            Limpiar();
        }
        private void CbPatio_SelectedIndexChanged(object sender, EventArgs e)
        {
            DControlPatio funcion = new DControlPatio();
            funcion.MostrarPatioUbicacion(CbUbicacionP, (int)CbPatio.SelectedValue);
        }
        private void TSLTendido_Click(object sender, EventArgs e)
        {
            if (PlTendido.Enabled == true)
            {
                PlTendido.Enabled = false;
                BtnTendido.Text = "Tendido";
            }
            else
            {
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
                plOpciones.Enabled = true;
            }
            else
            {
                EditarEnfarde();
                PlTendido.Enabled = false;
                PlEnfarde.Enabled = false;
                BtnEnfarde.Text = "Enfarde";
            }
            Limpiar();
        }
        private void TSLEnfarde_Click(object sender, EventArgs e)
        {
            if (PlEnfarde.Enabled == true)
            {
                PlEnfarde.Enabled = false;
                BtnEnfarde.Text = "Enfarde";
            }
            else
            {
                PlEnfarde.Enabled = true;
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
        }
        private void InsertarEnfarde()
        {
            if (validarEnfarde())
            {
                LControlPatio parametros = new LControlPatio();
                DControlPatio funcion = new DControlPatio();
                parametros.IdTendido = IdTendido;
                parametros.FEnfarde = DateTime.Parse(DTPEnfarde.Value.ToString());
                parametros.DiasSecado = int.Parse(LblDiasSecado.Text.ToString());
                parametros.Sacos = int.Parse(TxtSacosEnfardados.Text.ToString());
                parametros.HumedadL = double.Parse(TxtHumedadLevante.Text.ToString());
                parametros.Digitador = Login.NombreA;
                if (funcion.InsertarEnfarde(parametros) == true)
                {
                    MessageBox.Show("Enfarde realizado con éxito", "Realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MostrarLotes();
                    Limpiar();
                    PlControl.Visible = false;
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
            if (PlEnvio.Enabled == true)
            {
                PlEnvio.Enabled = false;
                BtnEnviar.Text = "Envio";
            }
            else
            {
                PlEnvio.Enabled = true;
                BtnEnviar.Text = "Actualizar";
            }
        }
        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (BtnEnviar.Text == "Enviar")
            {
                InsertarEnvio();
                plOpciones.Enabled = true;
            }
            else
            {
                EditarEnvio();
                PlTendido.Enabled = false;
                PlEnfarde.Enabled = false;
                PlEnvio.Enabled = false;
                BtnEnviar.Text = "Enviar";
            }
            Limpiar();
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
            //BuscarTK();
            Buscar();
        }
        private void EditarEnfarde()
        {
            if (validar())
            {
                if (editenf < 3 || Login.login.Trim().StartsWith("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    LControlPatio parametros = new LControlPatio();
                    DControlPatio funcion = new DControlPatio();
                    parametros.IdEnfarde = IdEnfarde;
                    parametros.IdTendido = IdTendido;
                    parametros.DiasSecado = int.Parse(LblDiasSecado.Text);
                    parametros.FEnfarde = DateTime.Parse(DTPEnfarde.Value.ToString());
                    parametros.HumedadL = double.Parse(TxtHumedadLevante.Text.ToString());
                    parametros.Sacos = int.Parse(TxtSacosEnfardados.Text.ToString());
                    parametros.Digitador = Login.NombreA;
                    editenf = editenf + 1;
                    if (funcion.EditarEnfarde(parametros, editenf) == true)
                    {
                        MessageBox.Show("Edición de Enfarde realizado con éxito", "Realizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        }
        private void CbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbBuscar.Text == "Ticket")
            {
                CbBuscador.Visible = false;
                txtBuscador.Visible = true;
            }
            if (CbBuscar.Text == "Certificación")
            {
                CbBuscador.Visible = true;
                txtBuscador.Visible = false;
            }
        }

        private void InsertarEnvio()
        {
            if (validarEnvio())
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
                    MostrarLotes();
                    Limpiar();
                    PlControl.Visible = false;
                }
                else
                {
                    MessageBox.Show("Existen campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                    MostrarLotes();
                    Limpiar();
                    PlControl.Visible = false;
                }
                else
                {
                    MessageBox.Show("Existen campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Buscar()
        {
            DataTable dt = new DataTable();
            DControlPatio dc = new DControlPatio();
            dc.BuscarTKCP(txtBuscador.Text, ref dt, desde, hasta, ContarBusqueda);
            dtInventariocp.DataSource = dt;
            ContarBusqueda = int.Parse(dc.contador.ToString());
            Base.DiseñoDtvEliminar(ref dtInventariocp);
        }
    }
}
