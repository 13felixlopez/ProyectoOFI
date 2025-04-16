using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using ProyectoOFI.Reportes;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOFI.Almacen
{
    public partial class Almacen : UserControl
    {
        int desde = 1;
        int hasta = 100;
        private int items_por_pagina = 100;
        int totalPaginas;
        int Contador;
        string Ticket, Modulo;
        int IdBodega, IdEmpaque, Edit;
        double PesoNeto, Tara;
        double rendimiento;
        int ContarBusqueda;
        string TicketO;
        public Almacen()
        {
            InitializeComponent();
            ValidarPermisos();
        }

        private async void Almacen_Load(object sender, EventArgs e)
        {
            PlCarga.Dock = DockStyle.Fill;
            //await CargarDatos();
            PlCarga.Visible = false;
            DAlmacen funcion = new DAlmacen();
            funcion.MostrarBodega(CbBodega);
            funcion.MostrarUbicacionPxBodega(CbUbicacion, IdBodega);
            funcion.MostrarEmpaque(CbTipoEmpaque);
            funcion.MostrarTaraSaco(IdEmpaque);
            funcion.MostrarTurnoAl(CbTurno);
            funcion.MostrarDescargador(CbDescargador);
            Tara = funcion.taraSaco;
        }
        private async Task CargarDatos()
        {
            await Task.Delay(1500);
            dtInventarioAlm.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            MostrarAlmacen();
            ReiniciarPaginado();
            await Task.Delay(1000);
            //dtInventarioAlm.Columns["Proceso"].Visible = false;
        }
        private void MostrarAlmacen()
        {
            DataTable dt = new DataTable();
            DAlmacen funcion = new DAlmacen();
            funcion.MostrarAlmacen(ref dt, desde, hasta);
            dtInventarioAlm.DataSource = dt;
            dtInventarioAlm.Columns["TicketO"].Visible = false;
            //Base.DiseñoDtvEliminar(ref dtInventarioAlm);
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
            DAlmacen funcion = new DAlmacen();
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
                MostrarAlmacen();
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
                MostrarAlmacen();
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
                MostrarAlmacen();
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
                MostrarAlmacen();
            }
        }
        #endregion
        private void dtInventarioAlm_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerTK();
            VerdetalleTkAlmacen();
            DetalleAlmacen();
            AbrirFormulario();
        }
        private void ObtenerTK()
        {
            string nombrecolumna = "Ticket";
            int indice = dtInventarioAlm.Columns[nombrecolumna].Index;
            Ticket = dtInventarioAlm.SelectedCells[indice].Value.ToString();

            string nombrecolumna2 = "Quality Grade";
            int indice2 = dtInventarioAlm.Columns[nombrecolumna2].Index;
            LblQuality.Text = dtInventarioAlm.SelectedCells[indice2].Value.ToString();
        }
        private void VerdetalleTkAlmacen()
        {
            DAlmacen funcion = new DAlmacen();
            DataTable dt = new DataTable();
            funcion.VerdetalleTkAlmacen(ref dt, Ticket);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                if (dr["Ticket"].ToString() != null)
                {
                    LblTicket.Text = Ticket;
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
            }
        }
        private void AbrirFormulario()
        {
            PLDatos.Size = new Size(1207, 622);
            //PLDatos.Location = new System.Drawing.Point(dtInventarioAlm.Width / 2
            //    - PLDatos.Width / 2, dtInventarioAlm.Height / 2 - PLDatos.Height / 2);

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
            dtInventarioAlm.Enabled = false;
            if (LblRedimiento.Text == "--" || LblRedimiento.Text == "0%")
            {
                BtnGuardar.Text = "Guardar";
                BtnActivar.Visible = false;
            }
            else
            {
                BtnGuardar.Text = "Editar";
                BtnActivar.Visible = true;
            }
        }
        private void BtnCerrarPldatos_Click(object sender, EventArgs e)
        {
            Limpiar();
            Activar();
            ValidarPermisos();
        }
        private void InsertarAlmacen()
        {
            if (validar())
            {
                // DateTime fechaAlmacen = DtpFAlmacen.Value.Date.AddDays(-1);
                if (DtpFAlmacen.Value.Date <= DateTime.Today.Date)
                {
                    DAlmacen funcion = new DAlmacen();
                    LAlmacen parametros = new LAlmacen();
                    parametros.Ticket = LblTicket.Text;
                    parametros.Origen = LblProcedencia.Text;
                    parametros.FechaAlmacen = DateTime.Parse(DtpFAlmacen.Text);
                    parametros.IdBodega = (int)CbBodega.SelectedValue;
                    parametros.IdUbicacion = (int)CbUbicacion.SelectedValue;
                    parametros.IdEmpaque = (int)CbTipoEmpaque.SelectedValue;
                    parametros.Sacos = int.Parse(NudSacos.Text);
                    parametros.Peso = decimal.Parse(TxtPeso.Text);
                    parametros.Tara = decimal.Parse(TxtTara.Text);
                    parametros.PesoNeto = decimal.Parse(TxtPesoNeto.Text);
                    parametros.Rendimiento = rendimiento;
                    parametros.IdTurno = (int)CbTurno.SelectedValue;
                    parametros.IdDescargador = (int)CbDescargador.SelectedValue;
                    if (funcion.InsertarAlmacen(parametros) == true)
                    {
                        MessageBox.Show("Se ha guardado con éxito", "Almacén", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        MostrarAlmacen();
                        Limpiar();
                    }
                }
                else
                {
                    MessageBox.Show("La fecha de recibido no puede ser mayor a la fecha de dia de hoy", "Error en la fecha", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show("Existen campos vacios", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool validar()
        {
            double entero;
            if (!double.TryParse(TxtPeso.Text, out entero) || !double.TryParse(TxtPesoNeto.Text, out entero) || !double.TryParse(TxtTara.Text, out entero))
            {
                return false;
            }
            return !(TxtPeso.Text == "" || TxtPesoNeto.Text == "" || TxtTara.Text == "");
        }
        private void CbBodega_SelectedIndexChanged(object sender, EventArgs e)
        {
            IdBodega = (int)CbBodega.SelectedValue;
            DAlmacen funcion = new DAlmacen();
            funcion.MostrarUbicacionPxBodega(CbUbicacion, IdBodega);
        }
        private void Calculate()
        {
            int Sacos = (int)NudSacos.Value;
            double Peso = 0;
            double PesoNeto = 0;
            double PesoRec = 0;
            rendimiento = 0;

            // Validar Sacos
            if (Sacos > 0)
            {
                TxtTara.Text = (Sacos * Tara).ToString();
                TxtPeso.Enabled = true;
            }
            else
            {
                TxtTara.Text = Tara.ToString();
                TxtPeso.Enabled = false;
                TxtPeso.Text = "0";
            }

            // Validar Peso
            if (double.TryParse(TxtPeso.Text, out Peso) && double.TryParse(TxtTara.Text, out double tara))
            {
                PesoNeto = Peso - tara;
                TxtPesoNeto.Text = PesoNeto.ToString();

                // Validar PesoRec
                if (double.TryParse(LblPeso.Text, out PesoRec) && PesoRec > 0)
                {
                    rendimiento = (PesoNeto / PesoRec) * 100;
                    LblRedimiento.Text = Math.Round(rendimiento, 2).ToString() + "%";
                }
                else
                {
                    LblRedimiento.Text = "0%";
                }
            }
            else
            {
                TxtPesoNeto.Text = "0";
                LblRedimiento.Text = "0%";
            }
        }
        private void NudSacos_ValueChanged(object sender, EventArgs e)
        {
            Calculate();
        }
        private void TxtPeso_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (BtnGuardar.Text == "Guardar")
            {
                InsertarAlmacen();
            }
            else
            {
                if (Edit > 3)
                {
                    MessageBox.Show("No puede editar esta Ticket porque ya superó la cantidad de ediciones permitida", "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    EditarAlmacen();
                }
            }
        }
        private void EditarAlmacen()
        {
            if (validar())
            {
                // Restar un día al valor de DtpFAlmacen DateTime fechaAlmacen = DtpFAlmacen.Value.Date.AddDays(-1)
                //DateTime fechaAlmacen = DtpFAlmacen.Value.Date.AddDays(-1);
                if (DtpFAlmacen.Value.Date <= DateTime.Today.Date)
                {
                    DAlmacen funcion = new DAlmacen();
                    LAlmacen parametros = new LAlmacen();
                    parametros.Ticket = LblTicket.Text;
                    parametros.Origen = LblProcedencia.Text;
                    parametros.FechaAlmacen = DateTime.Parse(DtpFAlmacen.Text);
                    parametros.IdBodega = (int)CbBodega.SelectedValue;
                    parametros.IdUbicacion = (int)CbUbicacion.SelectedValue;
                    parametros.IdEmpaque = (int)CbTipoEmpaque.SelectedValue;
                    parametros.Sacos = int.Parse(NudSacos.Text);
                    parametros.Peso = decimal.Parse(TxtPeso.Text);
                    parametros.Tara = decimal.Parse(TxtTara.Text);
                    parametros.PesoNeto = decimal.Parse(TxtPesoNeto.Text);
                    parametros.Rendimiento = rendimiento;
                    parametros.IdTurno = (int)CbTurno.SelectedValue;
                    parametros.IdDescargador = (int)CbDescargador.SelectedValue;
                    if (funcion.EditarAlmacen(parametros) == true)
                    {
                        MessageBox.Show("Se ha guardado con éxito", "Almacén", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        MostrarAlmacen();
                        Limpiar();
                    }
                }
                else
                {
                    MessageBox.Show("La fecha de recibido no puede ser mayor a la fecha de dia de hoy", "Error en la fecha", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show("Existen campos vacios", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CbTipoEmpaque_SelectedIndexChanged(object sender, EventArgs e)
        {
            DAlmacen funcion = new DAlmacen();
            IdEmpaque = (int)CbTipoEmpaque.SelectedValue;
            funcion.MostrarTaraSaco(IdEmpaque);
            Tara = funcion.taraSaco;

            Calculate();
        }
        private void Limpiar()
        {
            NudSacos.Value = 0;
            TxtPeso.Clear();
            TxtPesoNeto.Clear();
            LblRedimiento.Text = "--";
            PLDatos.Visible = false;
            dtInventarioAlm.Enabled = true;
            plOpciones.Enabled = true;
        }
        private void DetalleAlmacen()
        {
            DAlmacen funcion = new DAlmacen();
            DataTable dt = new DataTable();
            try
            {
                funcion.DetalleAlmacen(ref dt, Ticket);
                if (dt.Rows.Count > 0 && !string.IsNullOrEmpty(dt.Rows[0]["Ticket"].ToString()))
                {
                    DataRow row = dt.Rows[0];
                    if (DateTime.Parse(row["FechaAlmacen"].ToString()) != null)
                    {
                        DtpFAlmacen.Value = DateTime.Parse(row["FechaAlmacen"].ToString());
                    }
                    else
                    {
                        DtpFAlmacen.Value = DateTime.Today.Date;
                    }
                    if (row["Bodega"].ToString() != null)
                    {
                        CbBodega.Text = row["Bodega"].ToString();
                    }
                    else
                    {
                        CbBodega.ForeColor = Color.Red;
                    }
                    if (row["Ubicacion"].ToString() != null)
                    {
                        CbUbicacion.Text = row["Ubicacion"].ToString();
                    }
                    else
                    {
                        CbUbicacion.ForeColor = Color.Red;
                    }
                    if (row["Empaque"].ToString() != null)
                    {
                        CbTipoEmpaque.Text = row["Empaque"].ToString();
                    }
                    else
                    {
                        CbTipoEmpaque.ForeColor = Color.Red;
                    }
                    if (row["Sacos"].ToString() != null)
                    {
                        NudSacos.Text = row["Sacos"].ToString();
                    }
                    else
                    {
                        NudSacos.Value = 0;
                        NudSacos.ForeColor = Color.Red;
                    }
                    if (row["Peso"].ToString() != null)
                    {
                        TxtPeso.Text = row["Peso"].ToString();
                    }
                    else
                    {
                        TxtPeso.Text = "";
                    }
                    if (row["Tara"].ToString() != null)
                    {
                        TxtTara.Text = row["Tara"].ToString();
                    }
                    else
                    {
                        TxtTara.Text = "";
                    }
                    if (row["PesoNeto"].ToString() != null)
                    {
                        TxtPesoNeto.Text = row["PesoNeto"].ToString();
                    }
                    else
                    {
                        TxtPesoNeto.Text = "";
                    }
                    if (row["Rendimiento"].ToString() != null)
                    {
                        LblRedimiento.Text = row["Rendimiento"].ToString();
                    }
                    else
                    {
                        LblRedimiento.Text = "";
                    }
                    if (row["Turno"].ToString() != null)
                    {
                        CbTurno.Text = row["Turno"].ToString();
                    }
                    else
                    {
                        CbTurno.ForeColor = Color.Red;
                    }
                    if (row["Descargador"].ToString() != null)
                    {
                        CbDescargador.Text = row["Descargador"].ToString();
                    }
                    else
                    {
                        CbDescargador.ForeColor = Color.Red;
                    }
                    Edit = int.Parse(row["Edit"].ToString());
                    Desactivar();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void BtnActivar_Click(object sender, EventArgs e)
        {
            Activar();
            BtnGuardar.Visible = true;
        }

        private void PbExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DAlmacen funcion = new DAlmacen();
            funcion.ExcelAlmacen(ref dt);
            string Nombre = "Inventario Almacén";
            FrmLotes_Tendido LT = new FrmLotes_Tendido(dt, Nombre);
            LT.ShowDialog();
        }

        private async void BtnActualizar_Click(object sender, EventArgs e)
        {
            await CargarDatos();
            MessageBox.Show("Datos Actualizados", "Refrescar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void dtInventarioAlm_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verificar si la columna actual es la columna "Proceso"
            if (dtInventarioAlm.Columns[e.ColumnIndex].Name == "Proceso")
            {
                // Obtener el valor de la celda actual
                string cellValue = e.Value as string;

                // Verificar si el valor de la celda es "Almacén"
                if (!string.IsNullOrEmpty(cellValue) && cellValue == "Almacén")
                {
                    // Cambiar el color de fondo y el color de fuente de la fila
                    dtInventarioAlm.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow; // Color de fondo
                    dtInventarioAlm.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;    // Color de fuente
                }
                else
                {
                    // Restablecer los estilos de las filas que no cumplen la condición
                    dtInventarioAlm.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    dtInventarioAlm.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }
        private void Desactivar()
        {
            DtpFAlmacen.Enabled = false;
            CbBodega.Enabled = false;
            CbUbicacion.Enabled = false;
            CbTipoEmpaque.Enabled = false;
            NudSacos.Enabled = false;
            TxtPeso.Enabled = false;
            CbTurno.Enabled = false;
            CbDescargador.Enabled = false;
            BtnGuardar.Enabled = false;
        }

        private void CbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            DRecepcion funcion = new DRecepcion();
            if (CbBuscar.Text == "Ticket" || CbBuscar.Text == "Analisis" || CbBuscar.Text == "Peso")
            {
                CbBuscador.Text = "";
                //PlFiltroFecha.Visible = false;
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
            //PlFiltroFecha.Visible = false;
        }

        private void CbBuscador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbBuscador.Text == "")
            {
                ReiniciarPaginado();
                MostrarAlmacen();
            }
            else
            {
                BuscarDatos();
                ReiniciarPaginado();
            }
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            //BuscarTK();
            //ReiniciarPaginado();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            LblTKSplit.Text = "--";
            LblPesoO.Text = "--";
            PlSplit.Visible = false;
        }

        private void BtnSplit_Click(object sender, EventArgs e)
        {
            PlSplit.Location = new Point(this.Width / 2
               - PlSplit.Width / 2, this.Height / 2 - PlSplit.Height / 2);
            PlSplit.Visible = true;
            PlSplit.BringToFront();
            LblTKSplit.Text = LblTicket.Text;
            LblPesoO.Text = LblPeso.Text;
        }

        private void BtnCrearSplit_Click(object sender, EventArgs e)
        {
            DAlmacen funcion = new DAlmacen();
            double pesoNuevo = double.Parse(TxtPesoNuevo.Text);
            funcion.Split(pesoNuevo, TicketO, Ticket);
            LblPeso.Text = pesoNuevo.ToString();
            MessageBox.Show("Split realizado con éxito", "Correcto!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            PlSplit.Visible = false;
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DAlmacen funcion = new DAlmacen();
            funcion.ReporteAlmacen(ref dt);
            string Nombre = "Reporte Almacén";
            FrmLotes_Tendido LT = new FrmLotes_Tendido(dt, Nombre);
            LT.ShowDialog();
        }

        private void BtnBusqueda_Click(object sender, EventArgs e)
        {
            BuscarTK();
            ReiniciarPaginado();
        }

        private void Activar()
        {
            DtpFAlmacen.Enabled = true;
            CbBodega.Enabled = true;
            CbUbicacion.Enabled = true;
            CbTipoEmpaque.Enabled = true;
            NudSacos.Enabled = true;
            CbTurno.Enabled = true;
            CbDescargador.Enabled = true;
            BtnGuardar.Enabled = true;
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

                bool tieneAgregarAlmacen = false;
                bool tieneEditarAnalisis = false;

                foreach (DataRow rowpermisos in dt.Rows)
                {
                    Modulo = Convert.ToString(rowpermisos["Modulo"]);
                    if (Modulo == "Agregar Almacén")
                    {
                        tieneAgregarAlmacen = true;
                    }
                    if (Modulo == "Editar Almacén")
                    {
                        tieneEditarAnalisis = true;
                    }
                }

                if (tieneAgregarAlmacen && tieneEditarAnalisis)
                {
                    BtnGuardar.Visible = true;
                    BtnActivar.Enabled = true;
                }
                else if (tieneAgregarAlmacen)
                {
                    BtnGuardar.Visible = true;
                    BtnActivar.Enabled = false;
                }
                else if (tieneEditarAnalisis)
                {
                    BtnGuardar.Visible = false;
                    BtnActivar.Enabled = true;
                }
                else
                {
                    BtnGuardar.Visible = false;
                    BtnActivar.Enabled = false;
                }
            }
            else
            {
                BtnGuardar.Visible = true;
                BtnActivar.Enabled = true;
            }
        }
        private void BuscarDatos()
        {
            DataTable dt = new DataTable();
            DAlmacen funcion = new DAlmacen();
            //funcion.BuscarTK(txtBuscador.Text, ref dt, desde, hasta, ContarBusqueda);
            funcion.BuscarAlmacen(CbBuscador.Text, CbBuscar.Text, ref dt, desde, hasta, ContarBusqueda);
            dtInventarioAlm.DataSource = dt;
            ContarBusqueda = int.Parse(funcion.Contador.ToString());
        }
        private void BuscarTK()
        {
            DataTable dt = new DataTable();
            DAlmacen funcion = new DAlmacen();
            //funcion.BuscarTK(txtBuscador.Text, ref dt, desde, hasta, ContarBusqueda);
            funcion.BuscarAlmacen(txtBuscador.Text, CbBuscar.Text, ref dt, desde, hasta, ContarBusqueda);
            dtInventarioAlm.DataSource = dt;
            ContarBusqueda = int.Parse(funcion.Contador.ToString());
        }

    }
}
