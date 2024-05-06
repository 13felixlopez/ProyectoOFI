using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using ProyectoOFI.Otros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOFI.Recepcion
{
    public partial class Transferencia : UserControl
    {
        string Modulo;
        string Ticket;
        //string TicketAnterior;
        string Estado, areaAc;
        string Consolidado;
        int Contador;
        int ContarBusqueda;
        int desde = 1;
        int hasta = 100;
        private int items_por_pagina = 100;
        int totalPaginas;
        string Calidad, EstadoFisico, Daño;
        int IdCertificacionE;
        string CertificacionE;
        int ContadorEdit;
        string Proceso;
        DataTable Cons = new DataTable();
        // Crear un arreglo bidimensional para almacenar los datos del DataTable
        object[,] dataArray;
        List<string> filtro = new List<string>();
        private Form FrmActivo = null;
        public Transferencia()
        {
            InitializeComponent();
        }
        private async void Transferencia_Load(object sender, EventArgs e)
        {
            PlCarga.Dock = DockStyle.Fill;
            await CargarDatos();
            Base.DiseñoDtvEliminar(ref dtInventario);
            PlCarga.Visible = false;
            ValidarPermisos();
            //dtInventario.Columns["Estado"].Visible = false;
        }
        private async Task CargarDatos()
        {
            await Task.Delay(1500);
            dtInventario.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            MostrarLotes();
            ReiniciarPaginado();
            await Task.Delay(1000);
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AbrirFormulario();
            CargarCombos();
            BtnVerCons.Visible = false;
            PnGuardar.Visible = true;
            BtnEditar.Visible = false;
            LblDigitador.Text = Login.NombreA;
        }
        private void AbrirFormulario()
        {
            PlRecepcion.Location = new Point(dtInventario.Width / 2
                - PlRecepcion.Width / 2, dtInventario.Height / 2 - PlRecepcion.Height / 2);
            PlRecepcion.Visible = true;
            PlRecepcion.BringToFront();
            plOpciones.Enabled = false;
            PEnvio.Dock = DockStyle.Fill;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (nudSacos.Value > 0)
                {
                    if (nudSacosE.Value > 0)
                    {
                        if (dtFEnvio.Value <= dtpRecibido.Value)
                        {
                            carga();
                        }
                        else
                        {
                            MessageBox.Show("La fecha de envio no puede ser mayor que la fecha de recibido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    else
                    {
                        MessageBox.Show("La cantidad de sacos enviada no puede ser 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("La cantidad de sacos recibidos no puede ser 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
            }
        }
        private void bntAtras_Click(object sender, EventArgs e)
        {
            CerrarPlRec();
        }
        private void CerrarPlRec()
        {
            PlRecepcion.Visible = false;
            PRecepcion.Visible = false;
            PEnvio.Dock = DockStyle.Fill;
            PEnvio.Visible = true;
            Limpiar();
            txtTK.Enabled = true;
            CHBConsSM.Visible = true;
            nudSacos.Enabled = true;
            nudSacosE.Enabled = true;
            txtPesoE.Enabled = true;
            txtKgs.Enabled = true;
        }
        private void btnSig_Click(object sender, EventArgs e)
        {
            PRecepcion.Dock = DockStyle.Fill;
            PRecepcion.Visible = true;
            PEnvio.Visible = false;
        }
        private void btnAnt_Click(object sender, EventArgs e)
        {
            PRecepcion.Visible = false;
            PEnvio.Dock = DockStyle.Fill;
            PEnvio.Visible = true;
        }
        private void dtInventario_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Verificar si la celda que se TKá pintando es una celda de encabezado
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                // Determinar si la celda es de alguno de los encabezados especificados
                string headerText = dtInventario.Columns[e.ColumnIndex].HeaderText;
                bool isTargetHeader = headerText == "Ticket" ||
                                      headerText == "Fecha Recibido" ||
                                      headerText == "Sacos" ||
                                      headerText == "Peso" ||
                                      headerText == "MTNR" ||
                                      headerText == "Área de Secado" ||
                                      headerText == "Recibidor" ||
                                      headerText == "Calidad" ||
                                      headerText == "Estado Fisico" ||
                                      headerText == "Daño" ||
                                      headerText == "Digitador";

                // Definir los colores y la fuente según el tipo de encabezado
                Color backColor = isTargetHeader ? Color.Green : Color.Blue;
                Color textColor = Color.White;
                Font font = new Font(dtInventario.Font.FontFamily, 10, FontStyle.Bold);

                // Dibujar el fondo
                e.Graphics.FillRectangle(new SolidBrush(backColor), e.CellBounds);

                // Dibujar el texto centrado
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(headerText, font, new SolidBrush(textColor), e.CellBounds, stringFormat);

                // Indicar que ya se ha manejado el evento de pintura
                e.Handled = true;
            }
        }
        private void Limpiar()
        {
            //Enviado
            cbAgencia.Text = "";
            cbAcopio.Text = "";
            cbCliente.Text = "";
            cbCompra.Text = "";
            txtMTNT.Clear();
            cbCertificacion.Text = "";
            cbEsFisico.Text = "";
            cbCalidadE.Text = "";
            cbDanioE.Text = "";
            nudSacosE.Value = 0;
            txtPesoE.Clear();
            dtFEnvio.Value = DateTime.Today;
            LblQQsEn.Text = "--";
            //Recibido
            txtTK.Clear();
            cbArea.Text = "";
            txtMTNR.Clear();
            cbEstadoFisico.Text = "";
            cbCalidad.Text = "";
            cbDaño.Text = "";
            nudSacos.Value = nudSacosE.Value;
            txtKgs.Text = txtPesoE.Text;
            cbRecibidor.Text = "";
            LblDigitador.Text = "";
            plOpciones.Enabled = true;
            dtpRecibido.Value = DateTime.Today;
            LblQQs.Text = "--";
            lblTransferencia.Text = "Agregar Transferencia";
            TxtTally.Clear();
            CHBConsSM.Checked = false;
        }
        private void txtMTNT_TextChanged(object sender, EventArgs e)
        {
            Transferencia s = new Transferencia();
            foreach (DataRow row in s.dtInventario.Rows)
            {
                for (int i = 0; i < s.dtInventario.Rows.Count; i++)
                {
                    if (txtMTNT.Text == Convert.ToString(row["MTNT"]))
                    {
                        MessageBox.Show("MTNT ya existe", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMTNT.Clear();
                    }
                }
            }
        }
        private void txtKgs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double Kilos = double.Parse(txtKgs.Text);
                Kilos = Kilos / 46;
                LblQQs.Text = Math.Round(Kilos, 2).ToString();
                decimal PesoE, kgs, merma;
                PesoE = Convert.ToDecimal(txtPesoE.Text);
                kgs = Convert.ToDecimal(txtKgs.Text);
                merma = kgs - PesoE;
                //txtMerma.Text = Convert.ToString(fin);
                LblMerma.Text = Math.Round(merma, 2).ToString();
            }
            catch (Exception)
            {
                //txtKgs.Text = Convert.ToString(0);
            }
        }
        private void txtPesoE_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LblMerma.Text = txtPesoE.Text;
                double Kilos = double.Parse(txtPesoE.Text);
                Kilos = Kilos / 46;
                LblQQsEn.Text = Math.Round(Kilos, 2).ToString();

            }
            catch (Exception)
            {
                txtPesoE.Text = Convert.ToString(0);
            }
        }
        private bool ValidarE()
        {
            double entero;
            if (!double.TryParse(txtPesoE.Text, out entero))
            {
                return false;
            }
            return !(txtPesoE.Text == "" ||
                cbCompra.Text == "" || cbDanioE.Text == ""
            || cbCertificacion.Text == "" || cbEsFisico.Text == "" || cbCalidadE.Text == "");
        }
        private bool validar()
        {
            double entero;
            if (!double.TryParse(txtKgs.Text, out entero))
            {
                return false;
            }
            return !(txtKgs.Text == "" || txtTK.Text == "" || cbArea.Text == "" || cbCalidad.Text == "" || cbDaño.Text == ""
            || cbEstadoFisico.Text == "" || cbRecibidor.Text == "");
        }
        private bool validarEditar()
        {
            double entero;
            if (!double.TryParse(txtPesoE.Text, out entero))
            {
                return false;
            }
            return !(cbCertificacion.Text == "" || cbEstadoFisico.Text == "" || cbCalidadE.Text == "" || cbDaño.Text == "" || txtPesoE.Text == "" || cbArea.Text == "" || cbEsFisico.Text == ""
               || cbCalidad.Text == "" || cbDanioE.Text == "" || txtKgs.Text == "");
        }
        public void MostrarLotes()
        {
            DRecepcion funcion = new DRecepcion();
            DataTable dt = new DataTable();
            funcion.MostrarLote(ref dt, desde, hasta);
            dtInventario.DataSource = dt;
            Base.DiseñoDtvEliminar(ref dtInventario);
        }
        private void InsertarLote()
        {
            if (validar() && ValidarE())
            {
                if (CHBConsSM.Checked == true)
                {
                    Consolidado = "Si";
                }
                else
                {
                    Consolidado = null;
                }
                LRecepcion parametros = new LRecepcion();
                DRecepcion funcion = new DRecepcion();
                parametros.Ticket = txtTK.Text;
                parametros.FRecibido = Convert.ToDateTime(dtpRecibido.Text);
                parametros.IdArea = int.Parse(cbArea.SelectedValue.ToString());
                parametros.MTNR = txtMTNR.Text;
                parametros.IdEstFis = int.Parse(cbEstadoFisico.SelectedValue.ToString());
                parametros.IdCalidad = int.Parse(cbCalidad.SelectedValue.ToString());
                parametros.IdDaño = int.Parse(cbDaño.SelectedValue.ToString());
                parametros.Sacos = Convert.ToInt32(nudSacos.Value);
                parametros.Peso = Convert.ToDouble(txtKgs.Text);
                parametros.Merma = Convert.ToDouble(LblMerma.Text);
                parametros.IdRecibidor = int.Parse(cbRecibidor.SelectedValue.ToString());
                parametros.Digitador = Login.NombreA;
                parametros.Consolidado = Consolidado;


                LEnvio par = new LEnvio();
                par.Ticket = txtTK.Text;
                par.FEnvio = dtFEnvio.Value;
                par.IdAgencia = int.Parse(cbAgencia.SelectedValue.ToString());
                par.IdAcopio = int.Parse(cbAcopio.SelectedValue.ToString());
                par.IdCliente = int.Parse(cbCliente.SelectedValue.ToString());
                par.MTNT = txtMTNT.Text;
                par.IdTCompra = int.Parse(cbCompra.SelectedValue.ToString());
                par.IdCertificacionE = int.Parse(cbCertificacion.SelectedValue.ToString());
                par.IdEsFisico = int.Parse(cbEsFisico.SelectedValue.ToString());
                par.IdCalidadE = int.Parse(cbCalidadE.SelectedValue.ToString());
                par.IdDanioE = int.Parse(cbDanioE.SelectedValue.ToString());
                par.SacosE = Convert.ToInt32(nudSacosE.Value);
                par.PesoE = Convert.ToDouble(txtPesoE.Text);
                par.Tally = TxtTally.Text;

                if (funcion.InsertarLote2(parametros, par) == true)
                {
                    //frmInicio fr = new frmInicio();
                    DataTable dt = new DataTable();
                    funcion.MostrarLote(ref dt, desde, hasta);
                    dtInventario.DataSource = dt;
                    //PlRecepcion.Visible = false;
                    PRecepcion.Visible = false;
                    Alerta();
                    Limpiar();
                }

            }
            else
            {
                MessageBox.Show("Existen campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void Alerta()
        {
            timerAct.Enabled = true;
            PlAlerta.BringToFront();
            PlAlerta.Visible = true;
            await Task.Delay(2000);
            PlAlerta.Visible = false;
            timerAct.Enabled = false;
        }
        private async void carga()
        {
            timerAct.Enabled = true;
            PlCargaTran.Dock = DockStyle.Fill;
            PlCargaTran.Visible = true;
            PlCarga.BringToFront();
            await Task.Delay(1500);
            InsertarLote();
            ReiniciarPaginado();
            await Task.Delay(1000);
            PlCargaTran.Visible = false;
            timerAct.Enabled = false;
            PEnvio.Dock = DockStyle.Fill;
            PEnvio.Visible = true;
        }
        private void dtInventario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarCombos();
            ObtenerTK();
            ObtenerDatos();
            lblTransferencia.Text = "Editar Transferencia";
            CHBConsSM.Visible = false;
            AbrirFormulario();
            if (Login.login.Trim().StartsWith("Admin", StringComparison.OrdinalIgnoreCase) || Modulo == "EditarTK")
            {
                txtTK.Enabled = true;
            }
            else
            {
                if (txtTK.Text.Trim().StartsWith("Cons#", StringComparison.OrdinalIgnoreCase))
                {
                    // Si el texto inicia con "Cons#", habilitar el TextBox
                    txtTK.Enabled = true;
                }
                else
                {
                    // Si no inicia con "Cons#", deshabilitar el TextBox
                    txtTK.Enabled = false;
                }
            }
            if (Consolidado == "Si")
            {
                BtnVerCons.Visible = true;
                nudSacos.Enabled = false;
                nudSacosE.Enabled = false;
                txtPesoE.Enabled = false;
                txtKgs.Enabled = false;
            }
            else
            {
                BtnVerCons.Visible = false;
            }
            BtnEditar.Visible = true;
            PnGuardar.Visible = false;
        }
        private void ObtenerTK()
        {
            string nombrecolumna = "Ticket";
            int indice = dtInventario.Columns[nombrecolumna].Index;
            Ticket = dtInventario.SelectedCells[indice].Value.ToString();
            //TicketAnterior = Ticket.ToString();

            string nombrecolum = "Proceso";
            int num = dtInventario.Columns[nombrecolum].Index;
            Estado = dtInventario.SelectedCells[num].Value.ToString();

        }
        private void ObtenerDatos()
        {
            DRecepcion funcion = new DRecepcion();
            DataTable dt = new DataTable();

            try
            {
                funcion.MostrarDetalle(ref dt, Ticket);

                if (dt.Rows.Count > 0)
                {
                    double kilos, kilose;
                    DataRow row = dt.Rows[0];
                    Consolidado = row["Consolidado"].ToString();
                    if (DateTime.Parse(row["FEnvio"].ToString()) != null)
                    {
                        dtFEnvio.Value = DateTime.Parse(row["FEnvio"].ToString());
                    }
                    else
                    {
                        dtFEnvio.Value = DateTime.Today.Date;
                    }
                    if (row["Agencia"].ToString() != null)
                    {
                        cbAgencia.Text = row["Agencia"].ToString();
                    }
                    else
                    {
                        cbAgencia.ForeColor = Color.White;
                    }
                    if (row["Acopio"].ToString() != null)
                    {
                        cbAcopio.Text = row["Acopio"].ToString();
                    }
                    else
                    {
                        cbAcopio.Text = "";
                    }
                    if (row["Cliente"].ToString() != null)
                    {
                        cbCliente.Text = row["Cliente"].ToString();
                    }
                    else
                    {
                        cbCliente.Text = "";
                    }
                    if (row["Compra"].ToString() != null)
                    {
                        cbCompra.Text = row["Compra"].ToString();
                    }
                    else
                    {
                        cbCompra.Text = "";
                    }
                    if (!string.IsNullOrEmpty(row["MTNT"].ToString()))
                    {
                        txtMTNT.Text = row["MTNT"].ToString();
                    }
                    else
                    {
                        txtMTNT.Text = "";
                    }
                    if (row["Certificacion"].ToString() != null)
                    {
                        cbCertificacion.Text = row["Certificacion"].ToString();
                    }
                    else
                    {
                        cbCertificacion.Text = "";
                    }
                    if (row["EstadoFísicoE"].ToString() != null)
                    {
                        cbEsFisico.Text = row["EstadoFísicoE"].ToString();
                    }
                    else
                    {
                        cbEsFisico.Text = "";
                    }
                    if (row["CalidadE"].ToString() != null)
                    {
                        cbCalidadE.Text = row["CalidadE"].ToString();
                    }
                    else
                    {
                        cbCalidadE.Text = "";
                    }
                    if (row["DañoE"].ToString() != null)
                    {
                        cbDanioE.Text = row["DañoE"].ToString();
                    }
                    else
                    {
                        cbDanioE.Text = "";
                    }
                    if (row["SacosE"].ToString() != null)
                    {
                        nudSacosE.Value = int.Parse(row["SacosE"].ToString());
                    }
                    else
                    {
                        nudSacos.Value = 0;
                    }
                    if (row["PesoE"].ToString() != null)
                    {
                        txtPesoE.Text = row["PesoE"].ToString();
                        kilose = double.Parse(txtPesoE.Text);
                        kilose = kilose / 46;
                        LblQQsEn.Text = Math.Round(kilose, 2).ToString();
                    }
                    else
                    {
                        txtPesoE.Text = "0";
                        LblQQsEn.Text = "0";
                    }
                    txtTK.Text = Ticket.ToString();
                    dtpRecibido.Value = DateTime.Parse(row["Fecha Recibido"].ToString());
                    cbArea.Text = row["AreaSecado"].ToString();
                    areaAc = row["AreaSecado"].ToString();
                    if (row["MTNR"].ToString() != null)
                    {
                        txtMTNR.Text = row["MTNR"].ToString();
                    }
                    else
                    {
                        txtMTNR.Text = "";
                    }
                    cbEstadoFisico.Text = row["Estado Físico"].ToString();
                    cbCalidad.Text = row["Calidad"].ToString();
                    cbDaño.Text = row["Daño"].ToString();
                    nudSacos.Value = int.Parse(row["Sacos"].ToString());
                    txtKgs.Text = row["Peso"].ToString();
                    kilos = double.Parse(txtKgs.Text);
                    kilos = kilos / 46;
                    LblQQs.Text = Math.Round(kilos, 2).ToString();
                    if (row["Merma"].ToString() != null)
                    {
                        LblMerma.Text = row["Merma"].ToString();
                    }
                    else
                    {
                        LblMerma.Text = "";
                    }
                    if (row["Recibidor"].ToString() != null)
                    {
                        cbRecibidor.Text = row["Recibidor"].ToString();
                    }
                    else
                    {
                        cbRecibidor.Text = "";
                    }
                    LblDigitador.Text = row["Digitador"].ToString();
                    if (row["TallySheet"].ToString() != null)
                    {
                        TxtTally.Text = row["TallySheet"].ToString();
                    }
                    else
                    {
                        TxtTally.Text = "";
                    }
                    if (row["ContadorEdit"].ToString() != null)
                    {
                        ContadorEdit = int.Parse(row["ContadorEdit"].ToString());
                    }
                    else
                    {
                        ContadorEdit = 0;
                    }
                    Proceso = row["Proceso"].ToString();
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
        private void cbEsFisico_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbEstadoFisico.Text = (cbEsFisico.Text);
        }
        private void cbCalidadE_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCalidad.Text = cbCalidadE.Text;
        }
        private void nudSacosE_ValueChanged(object sender, EventArgs e)
        {
            nudSacos.Value = nudSacosE.Value;
        }
        private void cbDanioE_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbDaño.Text = cbDanioE.Text;
        }
        //Ordenamientos
        private void OrdenarDatos()
        {
            int index = 0;
            SortOrder order = SortOrder.Ascending;
            if (CbOrdenar.Text == "Fecha Recibido")
            {
                index = 9;
            }
            else if (CbOrdenar.Text == "Ticket")
            {
                index = 2;
            }
            else if (CbOrdenar.Text == "MTNR")
            {
                index = 13;
            }
            else if (CbOrdenar.Text == "Calidad")
            {
                index = 3;
            }
            else if (CbOrdenar.Text == "Estado Fisico")
            {
                index = 4;
            }
            else if (CbOrdenar.Text == "Digitador")
            {
                index = 15;
            }
            else if (CbOrdenar.Text == "Recibidor")
            {
                index = 14;
            }
            else if (CbOrdenar.Text == "Area de Secado")
            {
                index = 13;
            }
            else
            {
                MessageBox.Show("Valor no existente en la tabla", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dtInventario.Sort(dtInventario.Columns[index], (ListSortDirection)order);
        }
        private void CbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrdenarDatos();
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
                BuscarTK();
            }
            else if (CbBuscador.Visible == true)
            {
                BuscarDatos();
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
            else
            {
                MostrarLotes();
            }
        }
        #endregion
        private void dtInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtInventario.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro de eliminar la ticket, Desea Continuar?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarTK();
                }
            }
            if (e.ColumnIndex == dtInventario.Columns["Consolidar"].Index)
            {
                Datos();
                plfooter.Visible = false;
                plOpciones.Visible = false;
                PnConsolidar.Visible = true;
                PnConsolidar.Dock = DockStyle.Fill;
                LblTextsacos.Visible = false;
                LblSacosSM.Visible = false;
                if (CertificacionE == "Convencional")
                {
                    CbCertCons.Enabled = false;
                }
                else
                {
                    CbCertCons.Enabled = true;
                }
                //Consolidar cons = new Consolidar(Calidad, CertificacionE, EstadoFisico, Daño);
                //cons.Dock = DockStyle.Fill;
            }
        }
        private void Datos()
        {
            DRecepcion funcion = new DRecepcion();
            LEnvio par = new LEnvio();

            LRecepcion parametros = new LRecepcion();
            string nombrecolumna = "Calidad";
            int indice = dtInventario.Columns[nombrecolumna].Index;
            parametros.Calidad = dtInventario.SelectedCells[indice].Value.ToString();

            nombrecolumna = "Certificación";
            indice = dtInventario.Columns[nombrecolumna].Index;
            par.CertificacionE = (dtInventario.SelectedCells[indice].Value.ToString());

            nombrecolumna = "Estado Fisico";
            indice = dtInventario.Columns[nombrecolumna].Index;
            parametros.EstadoFisico = dtInventario.SelectedCells[indice].Value.ToString();

            nombrecolumna = "Daño";
            indice = dtInventario.Columns[nombrecolumna].Index;
            parametros.Daño = dtInventario.SelectedCells[indice].Value.ToString();

            Calidad = parametros.Calidad;
            CertificacionE = par.CertificacionE;
            EstadoFisico = parametros.EstadoFisico;
            Daño = parametros.Daño;

            funcion.MostrarCert(CbCertCons);
            funcion.MostrarAreaSecado(CbAreaCons);
            funcion.MostrarTKConsolidar(ref Cons, parametros, par);
            //DtTickets.DataSource = Cons;
            DtAADT();
        }
        private void Datos2()
        {
            DRecepcion funcion = new DRecepcion();
            LRecepcion parametros = new LRecepcion();
            LEnvio par = new LEnvio();
            parametros.Calidad = cbCalidad.Text;
            par.CertificacionE = cbCertificacion.Text;
            parametros.EstadoFisico = cbEsFisico.Text;
            parametros.Daño = cbDaño.Text;
            funcion.MostrarCert(CbCertCons);
            funcion.MostrarAreaSecado(CbAreaCons);
            funcion.MostrarTKConsolidar(ref Cons, parametros, par);
            //DtTickets.DataSource = Cons;
            DtAADT();
        }
        /// <summary>
        /// Este metodo se utliza para copiar los datos del datatable a un arreglo
        /// Esto se hace para poder agregar y eliminar los datos de ambos datagridviews
        /// Ya que DtTickets es quien recibe los datos desde la base de datos
        /// </summary>
        private void DtAADT()
        {
            // Crear un arreglo bidimensional para almacenar los datos del DataTable
            dataArray = new object[Cons.Rows.Count, Cons.Columns.Count];

            // Iterar sobre las filas y columnas del DataTable y almacenar los datos en el arreglo
            for (int i = 0; i < Cons.Rows.Count; i++)
            {
                for (int j = 0; j < Cons.Columns.Count; j++)
                {
                    dataArray[i, j] = Cons.Rows[i][j];
                }
            }

            // Limpiar el DataGridView antes de agregar datos
            DtTickets.Rows.Clear();

            // Agregar las filas al DataGridView excepto la que coincide con TxtTicketCons
            for (int i = 0; i < Cons.Rows.Count; i++)
            {
                // Verificar si la Ticket coincide con TxtTicketCons, si coincide, omitir esa fila
                if (Cons.Rows[i]["Ticket"].ToString() != TxtTicketCons.Text)
                {
                    // Agregar una nueva fila al DataGridView
                    int rowIndex = DtTickets.Rows.Add();

                    // Asignar los valores del arreglo a las celdas del DataGridView
                    for (int j = 0; j < Cons.Columns.Count; j++)
                    {
                        DtTickets.Rows[rowIndex].Cells[j].Value = dataArray[i, j];
                    }
                }
            }
        }
        private void EliminarTK()
        {
            string nombrecolumna = "Ticket";
            int indice = dtInventario.Columns[nombrecolumna].Index;
            Ticket = dtInventario.SelectedCells[indice].Value.ToString();

            LRecepcion parametros = new LRecepcion();
            DRecepcion funcion = new DRecepcion();
            parametros.Ticket = Ticket;
            parametros.Digitador = Login.NombreA;
            if (funcion.EliminarTK(parametros) == true)
            {
                MostrarLotes();
            }
            else
            {
                MessageBox.Show("Imposible eliminar la Ticket", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BuscarTK()
        {
            DataTable dt = new DataTable();
            DRecepcion funcion = new DRecepcion();
            funcion.BuscarTK(txtBuscador.Text, ref dt, desde, hasta, ContarBusqueda);
            dtInventario.DataSource = dt;
            ContarBusqueda = int.Parse(funcion.contador.ToString());
            Base.DiseñoDtvEliminar(ref dtInventario);
        }
        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscador.Text == "")
            {
                ReiniciarPaginado();
                MostrarLotes();
            }
            else if (CbBuscar.Text == "MTNT")
            {
                BuscarDatos();
                ReiniciarPaginado();
            }
            else if (CbBuscar.Text == "Peso")
            {
                BuscarDatos();
                ReiniciarPaginado();
            }
            else
            {
                BuscarTK();
                ReiniciarPaginado();
            }
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            PnConsolidar.Visible = false;
            PnConsolidar.Dock = DockStyle.None;
            plfooter.Visible = true;
            plOpciones.Visible = true;
            dtTKCons.Rows.Clear();
            Cons.Rows.Clear();
            BuscarTK();
            LimpiarCons();
        }
        private void DtTickets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si se hizo doble clic en una celda válida
            if (e.RowIndex >= 0 && e.RowIndex < DtTickets.Rows.Count)
            {
                // Obtener la fila seleccionada en DtTickets
                DataGridViewRow selectedRow = DtTickets.Rows[e.RowIndex];

                // Si dtTKCons está vacío, agregar las columnas
                if (dtTKCons.Columns.Count == 0)
                {
                    foreach (DataGridViewColumn col in DtTickets.Columns)
                    {
                        dtTKCons.Columns.Add((DataGridViewColumn)col.Clone());
                    }
                }

                // Crear una nueva fila en dtTKCons y copiar los datos de la fila seleccionada en DtTickets
                DataGridViewRow newRow = (DataGridViewRow)selectedRow.Clone();
                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    newRow.Cells[cell.ColumnIndex].Value = cell.Value;
                }

                // Agregar la nueva fila a dtTKCons
                dtTKCons.Rows.Add(newRow);

                // Eliminar la fila seleccionada de DtTickets
                DtTickets.Rows.RemoveAt(e.RowIndex);
                ActualizarTotales();
            }
        }
        private void ActualizarTotales()
        {
            // Inicializar las variables para los totales de sacos y peso
            int totalSacos = 0;
            double totalPeso = 0;
            int sacossm = int.Parse(LblSacosSM.Text);

            if (dtTKCons.Rows.Count == 0)
            {
                DtTickets.Enabled = true;
            }

            // Verificar si hay filas en dtTKCons
            if (dtTKCons.Rows.Count > 0)
            {
                // Iterar sobre todas las filas en dtTKCons para sumar los sacos y el peso
                foreach (DataGridViewRow row in dtTKCons.Rows)
                {
                    // Sumar los sacos
                    totalSacos += Convert.ToInt32(row.Cells["Sacos"].Value);

                    // Sumar el peso
                    totalPeso += Convert.ToDouble(row.Cells["Peso"].Value);
                    if (LblSacosSM.Visible == true)
                    {
                        BtnConsolidar.Enabled = false;
                        if (totalSacos > sacossm)
                        {
                            DtTickets.Enabled = false;
                            BtnConsolidar.Enabled = false;
                            MessageBox.Show("No puede superar el total de sacos del consolidado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else if (totalSacos == sacossm)
                        {
                            BtnConsolidar.Enabled = true;
                        }
                        else
                        {
                            DtTickets.Enabled = true;
                        }
                    }
                }
            }
            // Establecer los valores en los controles de etiqueta
            LblTotalSacos.Text = totalSacos.ToString();
            LblTotalPeso.Text = totalPeso.ToString();
        }
        private void EditarTK()
        {
            try
            {
                if (validarEditar())
                {
                    bool cbAreaCambio = cbArea.Text != areaAc;
                    if (cbAreaCambio && Proceso != "No Asignado")
                    {
                        MessageBox.Show("No puede cambiar el área de secado, ya que este lote tiene un proceso en curso.", "Error de cambio de área de secado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        LRecepcion parametros = new LRecepcion();
                        DRecepcion funcion = new DRecepcion();
                        parametros.Ticket = txtTK.Text;
                        parametros.FRecibido = Convert.ToDateTime(dtpRecibido.Text);
                        parametros.IdArea = int.Parse(cbArea.SelectedValue.ToString());
                        parametros.MTNR = txtMTNR.Text;
                        parametros.IdEstFis = int.Parse(cbEstadoFisico.SelectedValue.ToString());
                        parametros.IdCalidad = int.Parse(cbCalidad.SelectedValue.ToString());
                        parametros.IdDaño = int.Parse(cbDaño.SelectedValue.ToString());
                        parametros.Sacos = Convert.ToInt32(nudSacos.Value);
                        parametros.Peso = Convert.ToDouble(txtKgs.Text);
                        parametros.Merma = Convert.ToDouble(LblMerma.Text);
                        parametros.IdRecibidor = int.Parse(cbRecibidor.SelectedValue.ToString());
                        parametros.Digitador = Login.NombreA;
                        parametros.ContadorEdit = ContadorEdit + 1;
                        parametros.Proceso = Proceso;


                        LEnvio par = new LEnvio();
                        par.Ticket = txtTK.Text;
                        par.FEnvio = Convert.ToDateTime(dtFEnvio.Text);
                        par.IdAgencia = int.Parse(cbAgencia.SelectedValue.ToString());
                        par.IdAcopio = int.Parse(cbAcopio.SelectedValue.ToString());
                        par.IdCliente = int.Parse(cbCliente.SelectedValue.ToString());
                        par.MTNT = txtMTNT.Text;
                        par.IdTCompra = int.Parse(cbCompra.SelectedValue.ToString());
                        par.IdCertificacionE = int.Parse(cbCertificacion.SelectedValue.ToString());
                        par.IdEsFisico = int.Parse(cbEsFisico.SelectedValue.ToString());
                        par.IdCalidadE = int.Parse(cbCalidadE.SelectedValue.ToString());
                        par.IdDanioE = int.Parse(cbDanioE.SelectedValue.ToString());
                        par.SacosE = Convert.ToInt32(nudSacosE.Value);
                        par.PesoE = Convert.ToDouble(txtPesoE.Text);
                        par.Tally = TxtTally.Text;
                        if (ContadorEdit < 3 || Login.login.Trim().StartsWith("Admin", StringComparison.OrdinalIgnoreCase))
                        {
                            if (funcion.EditarTK(parametros, par, Ticket) == true)
                            {
                                DataTable dt = new DataTable();
                                funcion.MostrarLote(ref dt, desde, hasta);
                                dtInventario.DataSource = dt;
                                PRecepcion.Visible = false;
                                Alerta();
                                PlRecepcion.Visible = false;
                                PRecepcion.Visible = false;
                                PEnvio.Dock = DockStyle.Fill;
                                PEnvio.Visible = true;
                                Limpiar();
                                txtTK.Enabled = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ya supero los 3 intentos de edición, comuniquese con un administrador", "Superó los intentos de edición", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Existen campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarCons();
        }
        private void dtTKCons_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtTKCons.Rows.Count)
            {
                // Obtener la fila seleccionada en DtTickets
                DataGridViewRow selectedRow = dtTKCons.Rows[e.RowIndex];

                // Si dtTKCons está vacío, agregar las columnas
                if (DtTickets.Columns.Count == 0)
                {
                    foreach (DataGridViewColumn col in dtTKCons.Columns)
                    {
                        DtTickets.Columns.Add((DataGridViewColumn)col.Clone());
                    }
                }

                // Crear una nueva fila en dtTKCons y copiar los datos de la fila seleccionada en DtTickets
                DataGridViewRow newRow = (DataGridViewRow)selectedRow.Clone();
                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    newRow.Cells[cell.ColumnIndex].Value = cell.Value;
                }

                // Agregar la nueva fila a dtTKCons
                DtTickets.Rows.Add(newRow);

                // Eliminar la fila seleccionada de DtTickets
                dtTKCons.Rows.RemoveAt(e.RowIndex);
                ActualizarTotales();
            }
        }
        private async void CargaEditar()
        {
            PlCargaTran.Dock = DockStyle.Fill;
            PlCargaTran.BringToFront();
            PlCargaTran.Visible = true;
            await Task.Delay(1500);
            EditarTK();
            ReiniciarPaginado();
            await Task.Delay(1000);
            PlCargaTran.Visible = false;
            PEnvio.Dock = DockStyle.Fill;
            PEnvio.Visible = true;
        }
        private void cbAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            DRecepcion funcion = new DRecepcion();
            if (cbAgencia.SelectedValue != null)
            {
                funcion.MostrarAcopioAgencia(cbAcopio, (int)cbAgencia.SelectedValue);
            }
            else
            {
                cbAcopio.Text = null;
            }
        }
        private void BtnConsolidar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtTicketCons.Text) && !string.IsNullOrEmpty(TxtFolio.Text) && !string.IsNullOrEmpty(CbAreaCons.Text))
            {
                if (LblSacosSM.Visible == false)
                {
                    CrearConsolidado();
                }
                else
                {
                    CrearConsolidado2();
                }
            }
            else
            {
                MessageBox.Show("No puede haber espacios Vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (nudSacos.Value > 0)
                {
                    if (nudSacosE.Value > 0)
                    {
                        if (dtFEnvio.Value <= dtpRecibido.Value)
                        {
                            DialogResult res = MessageBox.Show("Esta seguro de guardar los datos editados", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (res == DialogResult.Yes)
                            {
                                CargaEditar();
                            }
                        }
                        else
                        {
                            MessageBox.Show("La fecha de envio no puede ser mayor que la fecha de recibido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    else
                    {
                        MessageBox.Show("La cantidad de sacos enviada no puede ser 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("La cantidad de sacos recibidos no puede ser 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
            }
        }
        private void TxtTicketCons_TextChanged(object sender, EventArgs e)
        {
            if (TxtTicketCons.Text != "")
            {
                DtTickets.Enabled = true;
                TxtFolio.Enabled = true;
            }
            else
            {
                DtTickets.Enabled = false;
                TxtFolio.Enabled = false;
            }
        }
        private void TxtFolio_TextChanged(object sender, EventArgs e)
        {
            if (TxtFolio.Text != "")
            {
                CbAreaCons.Enabled = true;
            }
            else
            {
                CbAreaCons.Enabled = false;
            }
            CbCertCons.Text = cbCertificacion.Text;
            if (CbCertCons.Text == "Convencional")
            {
                CbCertCons.Enabled = false;
            }
            else
            {
                CbCertCons.Enabled = true;
            }
        }
        private void CbAreaCons_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivarCons();
        }
        private void ActivarCons()
        {
            if (CbAreaCons.Text != "" || TxtTicketCons.Text != "" || TxtFolio.Text != "")
            {
                BtnConsolidar.Enabled = true;
            }
            else
            {
                BtnConsolidar.Enabled = false;
            }
        }
        private void BuscarCons()
        {
            string busqueda = TxtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(busqueda))
            {
                // Si el cuadro de búsqueda está vacío, mostrar todas las filas
                foreach (DataGridViewRow row in DtTickets.Rows)
                {
                    row.Visible = true;
                }
            }
            else
            {
                // Si hay texto en el cuadro de búsqueda, buscar y mostrar las filas que coincidan
                foreach (DataGridViewRow row in DtTickets.Rows)
                {
                    bool filaCoincide = false;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && cell.Value.ToString().IndexOf(busqueda, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            filaCoincide = true;
                            break;
                        }
                    }
                    row.Visible = filaCoincide;
                }
            }
        }
        private void PbFiltro_Click(object sender, EventArgs e)
        {
            PlFiltros.Location = new Point(dtInventario.Width / 2
                - PlFiltros.Width / 2, dtInventario.Height / 2 - PlFiltros.Height / 2);
            PlFiltros.Visible = true;
            PlFiltros.BringToFront();
        }
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            PlFiltros.Visible = false;
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
        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarColumnas();
            PlFiltros.Visible = false;
        }
        private void FiltrarColumnas()
        {
            foreach (DataGridViewColumn column in dtInventario.Columns)
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
        private void BuscarDatos()
        {
            DataTable dt = new DataTable();
            DRecepcion funcion = new DRecepcion();
            if (CbBuscar.Text == "Ticket")
            {
                funcion.BuscarTK(txtBuscador.Text, ref dt, desde, hasta, ContarBusqueda);
            }
            if (CbBuscar.Text == "Calidad")
            {
                funcion.BuscarCalidad(CbBuscador.Text, ref dt, desde, hasta, ContarBusqueda);
            }
            if (CbBuscar.Text == "Certificación")
            {
                funcion.BuscarCert(CbBuscador.Text, ref dt, desde, hasta, ContarBusqueda);
            }
            if (CbBuscar.Text == "Daño")
            {
                funcion.BuscarDanio(CbBuscador.Text, ref dt, desde, hasta, ContarBusqueda);
            }
            if (CbBuscar.Text == "Tipo Compra")
            {
                funcion.BuscarTipoCompra(CbBuscador.Text, ref dt, desde, hasta, ContarBusqueda);
            }
            if (CbBuscar.Text == "MTNT")
            {
                funcion.BuscarMTNT(txtBuscador.Text, ref dt, desde, hasta, ContarBusqueda);
            }
            if (CbBuscar.Text == "Peso")
            {
                funcion.BuscarPeso(txtBuscador.Text, ref dt, desde, hasta, ContarBusqueda);
            }
            if (CbBuscar.Text == "Área Secado")
            {
                funcion.BuscarAreaSecado(CbBuscador.Text, ref dt, desde, hasta, ContarBusqueda);
            }
            dtInventario.DataSource = dt;
            ContarBusqueda = int.Parse(funcion.contador.ToString());
            Base.DiseñoDtvEliminar(ref dtInventario);
        }
        private void CbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            DRecepcion funcion = new DRecepcion();
            if (CbBuscar.Text == "Ticket" || CbBuscar.Text == "MTNT" || CbBuscar.Text == "Peso")
            {
                CbBuscador.Text = "";
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
        private void TextBuscarVisible()
        {
            txtBuscador.Clear();
            txtBuscador.Visible = false;
            CbBuscador.Visible = true;
            CbBuscador.DataSource = null;
            CbBuscador.SelectedIndex = -1;
        }
        private void BuscarRangoFecha()
        {
            DataTable dt = new DataTable();
            DRecepcion funcion = new DRecepcion();
            DateTime Inicio = DtpBuscar.Value;
            Inicio = Convert.ToDateTime(Inicio.ToString("yyyy/MM/dd").ToString());
            DateTime Fin = DtpFin.Value;
            Fin = Convert.ToDateTime(Fin.ToString("yyyy/MM/dd").ToString());
            funcion.BuscarFecha(Inicio, Fin, ref dt);
            dtInventario.DataSource = dt;
            ContarBusqueda = int.Parse(funcion.contador.ToString());
            Base.DiseñoDtvEliminar(ref dtInventario);
        }
        private void BtnFiltroFecha_Click(object sender, EventArgs e)
        {
            BuscarRangoFecha();
        }
        private void BtnRangoFecha_Click(object sender, EventArgs e)
        {
            PlFiltroFecha.Visible = true;
        }
        private void PbExcel_Click(object sender, EventArgs e)
        {
            //AbrirFrm(new FrmExportExcel());
            FrmExportExcel excel = new FrmExportExcel();
            excel.Dock = DockStyle.Fill;
            excel.BringToFront();
            excel.ShowDialog();
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
        private void CargarCombos()
        {
            DRecepcion funcion = new DRecepcion();
            funcion.MostrarAgencia(cbAgencia);
            funcion.MostrarRecibidor(cbRecibidor);
            funcion.MostrarCliente(cbCliente);
            funcion.MostrarCompra(cbCompra);
            funcion.MostrarCert(cbCertificacion);
            funcion.MostrarCert(CbCertCons);
            funcion.MostrarEstFis(cbEsFisico);
            funcion.MostrarEstFis(cbEstadoFisico);
            funcion.MostrarCalidad(cbCalidad);
            funcion.MostrarCalidad(cbCalidadE);
            funcion.MostrarDaño(cbDanioE);
            funcion.MostrarDaño(cbDaño);
            funcion.MostrarAreaSecado(cbArea);
            funcion.MostrarAreaSecado(CbAreaCons);
        }
        private void BtnVerCons_Click(object sender, EventArgs e)
        {
            PlVerCons.Size = new Size(1512, 422);
            AbrirVerCons(PlVerCons);
            PlVerCons.Visible = true;
            PlRecepcion.Visible = false;
            LblVerCons.Text = "Detalle de Consolidación de Ticket: " + txtTK.Text;
            DRecepcion funcion = new DRecepcion();
            DataTable dt = new DataTable();
            funcion.VerCons(ref dt, txtTK.Text);
            DtVerCons.DataSource = dt;
            Base.DiseñoDtvEliminar(ref DtVerCons);
            if (dt.Rows.Count > 0)
            {
                BtnAddTK.Visible = false;
            }
            else
            {
                BtnAddTK.Visible = true;
            }
        }
        private void BtnCerrarVerCons_Click(object sender, EventArgs e)
        {
            PlVerCons.Size = new Size(129, 194);
            PlVerCons.Visible = false;
            PlRecepcion.Visible = true;
        }
        private void AbrirVerCons(Panel Pl)
        {
            Pl.Location = new Point(dtInventario.Width / 2
                - Pl.Width / 2, dtInventario.Height / 2 - Pl.Height / 2);
            Pl.Visible = true;
            Pl.BringToFront();
            plOpciones.Enabled = false;
            PEnvio.Dock = DockStyle.Fill;
        }
        private void DtVerCons_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                // Determinar si la celda es de alguno de los encabezados especificados
                string headerText = DtVerCons.Columns[e.ColumnIndex].HeaderText;
                bool isTargetHeader = headerText == "Ticket" ||
                                      headerText == "Fecha de Recibido" ||
                                      headerText == "Sacos" ||
                                      headerText == "Peso" ||
                                      headerText == "MTNR" ||
                                      headerText == "Área de Secado" ||
                                      headerText == "Recibidor" ||
                                      headerText == "Calidad" ||
                                      headerText == "Estado Físico" ||
                                      headerText == "Daño" ||
                                      headerText == "Digitador";

                // Definir los colores y la fuente según el tipo de encabezado
                Color backColor = isTargetHeader ? Color.Green : Color.Blue;
                Color textColor = Color.White;
                Font font = new Font(DtVerCons.Font.FontFamily, 10, FontStyle.Bold);

                // Dibujar el fondo
                e.Graphics.FillRectangle(new SolidBrush(backColor), e.CellBounds);

                // Dibujar el texto centrado
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(headerText, font, new SolidBrush(textColor), e.CellBounds, stringFormat);

                // Indicar que ya se ha manejado el evento de pintura
                e.Handled = true;
            }
        }
        private async void CrearConsolidado()
        {
            try
            {
                List<string> lstTickets = new List<string>();
                foreach (DataGridViewRow dr in dtTKCons.Rows)
                {
                    if (dr.Cells[0].Value != null)
                    {
                        string ticketValue = dr.Cells[0].Value.ToString();
                        lstTickets.Add(ticketValue);
                    }
                }
                LRecepcion parametros = new LRecepcion();
                LEnvio Par = new LEnvio();
                parametros.Ticket = TxtTicketCons.Text;
                parametros.Sacos = int.Parse(LblTotalSacos.Text);
                parametros.Peso = double.Parse(LblTotalPeso.Text);
                parametros.Calidad = Calidad;
                Par.IdCertificacionE = int.Parse(CbCertCons.SelectedValue.ToString());
                parametros.EstadoFisico = EstadoFisico;
                parametros.FRecibido = DateTime.Now;
                parametros.Daño = Daño;
                parametros.Digitador = Login.NombreA;
                parametros.IdArea = int.Parse(CbAreaCons.SelectedValue.ToString());
                string folio = TxtFolio.Text;
                string proceso = "No Asignado";
                DRecepcion funcion = new DRecepcion();
                if (funcion.Consolidar(parametros, Par, lstTickets, folio, proceso) == true)
                {
                    MessageBox.Show("Se ha realizado la consolidacion con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    PnConsolidar.Visible = false;
                    PnConsolidar.Dock = DockStyle.None;
                    plfooter.Visible = true;
                    plOpciones.Visible = true;
                    dtTKCons.Rows.Clear();
                    Cons.Rows.Clear();
                    await CargarDatos();
                    LimpiarCons();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lo sentimos ha ocurrido un error al consolidar", "ERROR en consolidar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void CrearConsolidado2()
        {
            try
            {
                List<string> lstTickets = new List<string>();
                foreach (DataGridViewRow dr in dtTKCons.Rows)
                {
                    if (dr.Cells[0].Value != null)
                    {
                        string ticketValue = dr.Cells[0].Value.ToString();
                        lstTickets.Add(ticketValue);
                    }
                }
                LRecepcion parametros = new LRecepcion();
                LEnvio Par = new LEnvio();
                parametros.Ticket = TxtTicketCons.Text;
                parametros.Sacos = int.Parse(LblTotalSacos.Text);
                parametros.Peso = double.Parse(LblTotalPeso.Text);
                parametros.Calidad = Calidad;
                Par.IdCertificacionE = int.Parse(CbCertCons.SelectedValue.ToString());
                parametros.EstadoFisico = EstadoFisico;
                parametros.FRecibido = DateTime.Now;
                parametros.Daño = Daño;
                parametros.Digitador = Login.NombreA;
                parametros.IdArea = int.Parse(CbAreaCons.SelectedValue.ToString());
                string folio = TxtFolio.Text;
                DRecepcion funcion = new DRecepcion();
                if (funcion.Consolidar2(parametros, Par, lstTickets, folio) == true)
                {
                    MessageBox.Show("Se ha realizado la consolidacion con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    PnConsolidar.Visible = false;
                    PnConsolidar.Dock = DockStyle.None;
                    plfooter.Visible = true;
                    plOpciones.Visible = true;
                    dtTKCons.Rows.Clear();
                    Cons.Rows.Clear();
                    await CargarDatos();
                    LimpiarCons();
                    PlVerCons.Size = new Size(129, 194);
                    PlVerCons.Visible = false;
                    CerrarPlRec();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lo sentimos ha ocurrido un error al consolidar", "ERROR en consolidar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CHBConsSM_CheckedChanged(object sender, EventArgs e)
        {
            cbArea.Text = "Secado Mecánico";
        }
        private void BtnAddTK_Click(object sender, EventArgs e)
        {
            LblSacosSM.Visible = true;
            LblTextsacos.Visible = true;
            TxtTicketCons.Text = txtTK.Text;
            LblSacosSM.Text = nudSacos.Text;
            CbAreaCons.Text = "Secado Mecánico";
            LblTextAreaCons.Visible = false;
            CbAreaCons.Visible = false;
            Datos2();
            plfooter.Visible = false;
            plOpciones.Visible = false;
            PnConsolidar.Visible = true;
            PnConsolidar.Dock = DockStyle.Fill;
            PnConsolidar.BringToFront();
            TxtTicketCons.Enabled = false;
            if (CertificacionE == "Convencional")
            {
                CbCertCons.Enabled = false;
            }
            else
            {
                CbCertCons.Enabled = true;
            }
        }
        private void LimpiarCons()
        {
            LblTotalPeso.Text = "00";
            LblTotalSacos.Text = "00";
            TxtTicketCons.Clear();
            TxtFolio.Clear();
            TxtBuscar.Clear();
        }
        private void AbrirFrm(Form hijo)
        {
            if (FrmActivo != null)
            {
                FrmActivo.Close();
            }

            FrmActivo = hijo;
            hijo.TopLevel = false;
            hijo.Dock = DockStyle.Fill;
            PlContenedor.Controls.Add(hijo);
            PlContenedor.Tag = hijo;
            hijo.BringToFront();
            hijo.Show();
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
                if (Modulo == "InsertarTranferencia")
                {
                    btnAgregar.Visible = true;
                }
                if (Modulo == "EditarTransferencia")
                {
                    BtnEditar.Visible = true;
                    PlRecepcion.Enabled = true;
                    PlEnvio.Enabled = true;
                }
                if (Modulo == "Consolidar")
                {
                    dtInventario.Columns["Consolidar"].Visible = true;
                    BtnAddTK.Visible = true;
                }
                if ((Modulo == "Eliminar"))
                {
                    dtInventario.Columns["Eliminar"].Visible = true;
                }
                if (Modulo == "EditarTK")
                {
                    txtTK.Enabled = true;
                }
            }
        }
    }
}
