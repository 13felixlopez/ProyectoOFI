using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOFI.Recepcion
{
    public partial class Transferencia : UserControl
    {
        string Ticket;
        string Estado;
        int Contador;
        int ContarBusqueda;
        int desde = 1;
        int hasta = 100;
        private int items_por_pagina = 100;
        int totalPaginas;
        
        public Transferencia()
        {
            InitializeComponent();
        }
        private async void Transferencia_Load(object sender, EventArgs e)
        {
            PlCarga.Dock = DockStyle.Fill;
            await CargarDatos();
            PlCarga.Visible = false;
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
            PnGuardar.Visible = true;
            BtnEditar.Visible = false;
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
                        MessageBox.Show("La cantidad de sacos enviada no puede ser 0", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
            PlRecepcion.Visible = false;
            PRecepcion.Visible = false;
            PEnvio.Dock = DockStyle.Fill;
            PEnvio.Visible = true;
            Limpiar();
            txtTK.Enabled = true;
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
            // Verificar si la celda que se está pintando es una celda de encabezado
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
            cbDigitador.Text = "";
            plOpciones.Enabled = true;
            dtpRecibido.Value = DateTime.Today;
            LblQQs.Text = "--";
            lblTransferencia.Text = "Agregar Transferencia";
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
                txtMerma.Text = Math.Round(merma, 2).ToString();
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
                txtMerma.Text = txtPesoE.Text;
                double Kilos = int.Parse(txtPesoE.Text);
                Kilos  = Kilos / 46;
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
            return !(txtPesoE.Text == "" || cbAgencia.Text == "" || cbAcopio.Text == "" || cbCliente.Text == "" ||
                cbCompra.Text == "" || txtMTNT.Text == "" || cbDanioE.Text == ""
            || cbCertificacion.Text == "" || cbEsFisico.Text == "" || cbCalidadE.Text == "");
        }
        private bool validar()
        {
            double entero;
            if (!double.TryParse(txtKgs.Text, out entero) || !double.TryParse(txtMerma.Text, out entero))
            {
                return false;
            }
            return !(txtKgs.Text == "" || txtMerma.Text == "" || txtTK.Text == "" || cbArea.Text == "" || cbCalidad.Text == "" || cbDaño.Text == ""
            || cbDigitador.Text == "" || cbEstadoFisico.Text == "" || cbRecibidor.Text == "");
        }

        public void MostrarLotes()
        {
            DRecepcion funcion = new DRecepcion();
            DataTable dt = new DataTable();
            funcion.MostrarLote(ref dt, desde, hasta);
            dtInventario.DataSource = dt;
        }
        private void InsertarLote()
        {
            if (validar() && ValidarE())
            {
                LRecepcion parametros = new LRecepcion();
                DRecepcion funcion = new DRecepcion();
                parametros.Ticket = txtTK.Text;
                parametros.FRecibido = Convert.ToDateTime(dtpRecibido.Text);
                parametros.Area = cbArea.Text;
                parametros.MTNR = txtMTNR.Text;
                parametros.EstadoFisico = cbEstadoFisico.Text;
                parametros.Calidad = cbCalidad.Text;
                parametros.Daño = cbDaño.Text;
                parametros.Sacos = Convert.ToInt32(nudSacos.Value);
                parametros.Peso = Convert.ToDouble(txtKgs.Text);
                parametros.Merma = Convert.ToDouble(txtMerma.Text);
                parametros.Recibidor = cbRecibidor.Text;
                parametros.Digitador = cbDigitador.Text;


                LEnvio par = new LEnvio();
                par.Ticket = txtTK.Text;
                par.FEnvio = dtFEnvio.Value;
                par.Agencia = cbAgencia.Text;
                par.Acopio = cbAcopio.Text;
                par.Cliente = cbCliente.Text;
                par.MTNT = txtMTNT.Text;
                par.TCompra = cbCompra.Text;
                par.CertificacionE = cbCertificacion.Text;
                par.EsFisico = cbEsFisico.Text;
                par.CalidadE = cbCalidadE.Text;
                par.DanioE = cbDanioE.Text;
                par.SacosE = Convert.ToInt32(nudSacosE.Value);
                par.PesoE = Convert.ToDouble(txtPesoE.Text);

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
            ObtenerEstado();
            ObtenerDatos();
            lblTransferencia.Text = "Editar Transferencia";
            AbrirFormulario();
            txtTK.Enabled = false;
            BtnEditar.Visible = true;
            PnGuardar.Visible = false;
        }
        private void ObtenerEstado()
        {
            string nombrecolumna = "Ticket";
            int indice = dtInventario.Columns[nombrecolumna].Index;
            Ticket = dtInventario.SelectedCells[indice].Value.ToString();

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
                    dtFEnvio.Value = DateTime.Parse(row["FEnvio"].ToString());
                    cbAgencia.Text = row["Agencia"].ToString();
                    cbAcopio.Text = row["Acopio"].ToString();
                    cbCliente.Text = row["Cliente"].ToString();
                    cbCompra.Text = row["Tipo_Compra"].ToString();
                    txtMTNT.Text = row["MTNT"].ToString();
                    cbCertificacion.Text = row["Certificacion"].ToString();
                    cbEsFisico.Text = row["EsFisico"].ToString();
                    cbCalidadE.Text = row["CalidadE"].ToString();
                    cbDanioE.Text = row["DanioE"].ToString();
                    nudSacosE.Value = int.Parse(row["SacosE"].ToString());
                    txtPesoE.Text = row["PesoE"].ToString();
                    kilose = double.Parse(txtPesoE.Text);
                    kilose = kilose / 46;
                    LblQQsEn.Text = Math.Round(kilose, 2).ToString();
                    txtTK.Text = Ticket.ToString();
                    dtpRecibido.Value = DateTime.Parse(row["FechaRecibido"].ToString());
                    cbArea.Text = row["AreaSecado"].ToString();
                    txtMTNR.Text = row["MTNR"].ToString();
                    cbEstadoFisico.Text = row["EstadoFisico"].ToString();
                    cbCalidad.Text = row["Calidad"].ToString();
                    cbDaño.Text = row["Danio"].ToString();
                    nudSacos.Value = int.Parse(row["Sacos"].ToString());
                    txtKgs.Text = row["Peso"].ToString();
                    kilos = double.Parse(txtKgs.Text);
                    kilos = kilos / 46;
                    LblQQs.Text = Math.Round(kilos, 2).ToString();
                    txtMerma.Text = row["Merma"].ToString();
                    cbRecibidor.Text = row["Recibidor"].ToString();
                    cbDigitador.Text = row["Digitador"].ToString();
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
                index = 8;
            }
            else if (CbOrdenar.Text == "Ticket")
            {
                index = 1;
            }
            else if (CbOrdenar.Text== "MTNR")
            {
                index = 11;
            }
            else if (CbOrdenar.Text== "Calidad")
            {
                index = 2;
            }
            else if (CbOrdenar.Text== "Estado Fisico")
            {
                index = 3;
            }
            else if (CbOrdenar.Text== "Digitador")
            {
                index = 14;
            }
            else if (CbOrdenar.Text== "Recibidor")
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
            if (txtBuscador.Text!="")
            {
                BuscarTK();
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
            if (txtBuscador.Text!="")
            {
                BuscarTK();
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
                DialogResult result = MessageBox.Show("¿Esta seguro de eliminar esta ticket, Desea Continuar?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarTK();
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
            if (funcion.EliminarTK(parametros) == true)
            {
                MostrarLotes();
            }
            else
            {
                MessageBox.Show("Imposible eliminar esta Ticket", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BuscarTK()
        {
            DataTable dt = new DataTable();
            DRecepcion funcion = new DRecepcion();
            funcion.BuscarTK(txtBuscador.Text, ref dt, desde, hasta, ContarBusqueda);
            dtInventario.DataSource = dt;
            ContarBusqueda = int.Parse(funcion.contador.ToString());
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscador.Text == "")
            {
                ReiniciarPaginado();
                MostrarLotes();
            }
            else
            {
                BuscarTK();
                ReiniciarPaginado();
            }
        }
        private void EditarTK()
        {
            try
            {
                if (validar() && ValidarE())
                {
                    LRecepcion parametros = new LRecepcion();
                    DRecepcion funcion = new DRecepcion();
                    parametros.Ticket = txtTK.Text;
                    parametros.FRecibido = Convert.ToDateTime(dtpRecibido.Text);
                    parametros.Area = cbArea.Text;
                    parametros.MTNR = txtMTNR.Text;
                    parametros.EstadoFisico = cbEstadoFisico.Text;
                    parametros.Calidad = cbCalidad.Text;
                    parametros.Daño = cbDaño.Text;
                    parametros.Sacos = Convert.ToInt32(nudSacos.Value);
                    parametros.Peso = Convert.ToDouble(txtKgs.Text);
                    parametros.Merma = Convert.ToDouble(txtMerma.Text);
                    parametros.Recibidor = cbRecibidor.Text;
                    parametros.Digitador = cbDigitador.Text;


                    LEnvio par = new LEnvio();
                    par.Ticket = txtTK.Text;
                    par.FEnvio = dtFEnvio.Value;
                    par.Agencia = cbAgencia.Text;
                    par.Acopio = cbAcopio.Text;
                    par.Cliente = cbCliente.Text;
                    par.MTNT = txtMTNT.Text;
                    par.TCompra = cbCompra.Text;
                    par.CertificacionE = cbCertificacion.Text;
                    par.EsFisico = cbEsFisico.Text;
                    par.CalidadE = cbCalidadE.Text;
                    par.DanioE = cbDanioE.Text;
                    par.SacosE = Convert.ToInt32(nudSacosE.Value);
                    par.PesoE = Convert.ToDouble(txtPesoE.Text);

                    if (funcion.EditarTK(parametros, par) == true)
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
                    MessageBox.Show("Existen campos vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void CargaEditar()
        {
            PlCargaTran.Dock = DockStyle.Fill;
            PlCargaTran.Visible = true;
            await Task.Delay(1500);
            EditarTK();
            ReiniciarPaginado();
            await Task.Delay(1000);
            PlCargaTran.Visible = false;
            PEnvio.Dock = DockStyle.Fill;
            PEnvio.Visible = true;
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
                            DialogResult res=MessageBox.Show("Esta seguro de guardar los datos editados","Advertencia",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                            if (res==DialogResult.Yes)
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
    }
}
