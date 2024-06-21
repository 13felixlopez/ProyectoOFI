using DocumentFormat.OpenXml.Spreadsheet;
using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using ProyectoOFI.Otros;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace ProyectoOFI.Analisis
{
    public partial class Catacion : UserControl
    {
        int desde = 1;
        int hasta = 100;
        private int items_por_pagina = 100;
        int totalPaginas;
        int Contador;
        string Ticket, TkSM, TkDetalle;
        DateTime FRecibido, FMuestra;
        double Exp, DesmA, DesmC, DesmD;
        double Bto = 0;
        double Casc;
        private bool isPlaceholder = true;
        double Humedad;
        Boolean Estado;
        string Proceso;
        int Idcatacion;
        public Catacion()
        {
            InitializeComponent();
            SetPlaceholder(TxtAnalisis, "# Analisis");
            SetPlaceholder(TxtBto, "0");
            SetPlaceholder(TxtHumedad, "0");
            SetPlaceholder(TxtExp, "0");
            SetPlaceholder(TxtDesmA, "0");
            SetPlaceholder(TxtDesmC, "0");
            TxtBto.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            TxtHumedad.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            TxtExp.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            TxtDesmA.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            TxtDesmC.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            TxtScore.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
        }

        private async void Catacion_Load(object sender, EventArgs e)
        {
            PlCarga.Dock = DockStyle.Fill;
            await CargarDatos();
            Base.DiseñoDtvEliminar(ref dtInventarioCat);
            PlCarga.Visible = false;
            CalcularDesmD();
        }
        private async Task CargarDatos()
        {
            await Task.Delay(1500);
            dtInventarioCat.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            MostrarLotes();
            ReiniciarPaginado();
            await Task.Delay(1000);
            dtInventarioCat.Columns["Proceso"].Visible = false;
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
            if (txtBuscador.Text != "")
            {
                // Contador = ContarBusqueda;
            }
            //else if (CbBuscador.Visible == true)
            //{
            //    Contador = ContarBusqueda;
            //}
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
                //BuscarTK();
            }
            //else if (CbBuscador.Visible == true)
            //{
            //    BuscarDatos();
            //}
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
                // BuscarTK();
            }
            //else if (CbBuscador.Visible == true)
            //{
            //    BuscarDatos();
            //}
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
                //BuscarTK();
            }
            //else if (CbBuscador.Visible == true)
            //{
            //    BuscarDatos();
            //}
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
                // BuscarTK();
            }
            //else if (CbBuscador.Visible == true)
            //{
            //    BuscarDatos();
            //}
            else
            {
                MostrarLotes();
            }
        }
        #endregion
        public void MostrarLotes()
        {
            Dcatacion funcion = new Dcatacion();
            DataTable dt = new DataTable();
            funcion.MostrarCata(ref dt, desde, hasta);
            dtInventarioCat.DataSource = dt;
            Base.DiseñoDtvEliminar(ref dtInventarioCat);
            BtnMostrarCompras.Text = "Compras Directas";
        }
        private void VerDetalleCatacion()
        {
            try
            {
                Dcatacion funcion = new Dcatacion();
                DataTable dt = new DataTable();
                funcion.VerDetalleCatacion(ref dt, Ticket, TkSM);
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
                    if (dr["Fecha Muestra"].ToString() != null)
                    {
                        FMuestra = DateTime.Parse(dr["Fecha Muestra"].ToString());
                        DTPFechaMuestra.Value = DateTime.Parse(dr["Fecha Muestra"].ToString());
                    }
                    else
                    {
                        FMuestra = DateTime.Today;
                        DTPFechaMuestra.Value = DateTime.Today;
                    }
                    CalculoDias();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos en controles" + ex.Message, "ERROR en Catación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CalculoDias()
        {
            DateTime fechaActual = DateTime.Now;
            TimeSpan diferencia = fechaActual.Subtract(FMuestra);
            int diasDiferencia = (int)diferencia.TotalDays;
            LblDias.Text = diasDiferencia.ToString();
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
            VerDetalleCata();
            AbrirFormulario();
        }

        private void ObtenerTK()
        {
            string nombrecolumna = "Ticket";
            int indice = dtInventarioCat.Columns[nombrecolumna].Index;
            Ticket = dtInventarioCat.SelectedCells[indice].Value.ToString();

            if (BtnMostrarCompras.Text == "Compras Directas")
            {
                string nombrecolum = "Ticket SM";
                int num = dtInventarioCat.Columns[nombrecolum].Index;
                TkSM = dtInventarioCat.SelectedCells[num].Value.ToString();

                string nombreEstado = "Proce";
                int numEstado = dtInventarioCat.Columns[nombreEstado].Index;
                Proceso = dtInventarioCat.SelectedCells[numEstado].Value.ToString();
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
            //if (TxtBto.Text == "")
            //{
            //    SetPlaceholder(TxtBto, "0");
            //    Bto = 0;
            //}
            //Bto = double.Parse(TxtBto.Text);
            //Casc = 100 - Bto;
            //LblCascarilla.Text = Casc.ToString();
            //LblTotal.Text = (Casc + Bto).ToString();

            if (isPlaceholder)
            {
                return; // Salir si es el marcador de posición
            }

            if (string.IsNullOrWhiteSpace(TxtBto.Text))
            {
                SetPlaceholder(TxtBto, "0");
                Bto = 0;
            }
            else
            {
                if (double.TryParse(TxtBto.Text, out double result))
                {
                    Bto = result;
                }
                else
                {
                    // Manejar el caso donde el texto no se puede convertir a número
                    MessageBox.Show("Por favor, ingrese un número válido.");
                    return;
                }
            }

            Casc = 100 - Bto;
            LblCascarilla.Text = Casc.ToString();
            LblTotal.Text = (Casc + Bto).ToString();
        }
        private void TxtDesmA_TextChanged(object sender, EventArgs e)
        {
            if (isPlaceholder)
            {
                return; // Salir si es el marcador de posición
            }

            if (string.IsNullOrWhiteSpace(TxtDesmA.Text))
            {
                SetPlaceholder(TxtDesmA, "0");
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
                    return;
                }
            }
            CalcularDesmD();
            LblDesmAP.Text = Math.Round((Bto * DesmA) / 100, 2).ToString() + "%";
        }
        private void TxtScore_TextChanged(object sender, EventArgs e)
        {
            if (TxtScore.Text == "")
            {
                LblTasa.Text = "";
                LblGCalidad.Text = "";
            }
            else
            {
                SeleccionarScore();
            }
        }
        private void SeleccionarScore()
        {
            Dcatacion funcion = new Dcatacion();
            int score = int.Parse(TxtScore.Text);
            funcion.SeleccionarScore(score, LblTasa, LblGCalidad);
        }
        private void TxtHumedad_TextChanged(object sender, EventArgs e)
        {
            //if (TxtHumedad.Text == "")
            //{
            //    TxtHumedad.Text = "0";
            //}
            //double Humedad = double.Parse(TxtHumedad.Text);
            if (isPlaceholder)
            {
                return; // Salir si es el marcador de posición
            }

            if (string.IsNullOrWhiteSpace(TxtHumedad.Text))
            {
                SetPlaceholder(TxtHumedad, "0");
                Humedad = 0;
            }
            else
            {
                if (double.TryParse(TxtHumedad.Text, out double result))
                {
                    Humedad = result;
                }
                else
                {
                    // Manejar el caso donde el texto no se puede convertir a número
                    MessageBox.Show("Por favor, ingrese un número válido.");
                    return;
                }
            }
            if (Humedad >= 12.8)
            {
                ChbRechazado.Checked = true;
                ChbAnalizado.Enabled = false;
            }
            else
            {
                ChbRechazado.Checked = false;
                ChbAnalizado.Enabled = true;
            }
        }
        private void TxtDesmC_TextChanged(object sender, EventArgs e)
        {
            if (isPlaceholder)
            {
                return; // Salir si es el marcador de posición
            }

            if (string.IsNullOrWhiteSpace(TxtDesmC.Text))
            {
                SetPlaceholder(TxtDesmC, "0");
                DesmC = 0;
            }
            else
            {
                if (double.TryParse(TxtDesmC.Text, out double result))
                {
                    DesmC = result;
                }
                else
                {
                    // Manejar el caso donde el texto no se puede convertir a número
                    MessageBox.Show("Por favor, ingrese un número válido.");
                    return;
                }
            }
            CalcularDesmD();
            LblDesmCP.Text = Math.Round((Bto * DesmC) / 100, 2).ToString() + "%";
        }
        private void TxtExp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (isPlaceholder)
                {
                    return; // Salir si es el marcador de posición
                }

                if (string.IsNullOrWhiteSpace(TxtExp.Text))
                {
                    SetPlaceholder(TxtExp, "0");
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
                        // Manejar el caso donde el texto no se puede convertir a número
                        MessageBox.Show("Por favor, ingrese un número válido.");
                        return;
                    }
                }
                CalcularDesmD();
                LblExpP.Text = Math.Round((Bto * Exp) / 100, 2).ToString() + "%";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló el calculo " + ex.Message, "Error en Exp");
            }
        }
        private void CalcularDesmD()
        {
            Exp = double.Parse(TxtExp.Text);
            DesmA = double.Parse(TxtDesmA.Text);
            DesmC = double.Parse(TxtDesmC.Text);
            DesmD = Math.Round(100 - Exp - DesmA - DesmC, 2);
            LblDesmD.Text = DesmD.ToString();
            LblDesmDP.Text = Math.Round((Bto * DesmD) / 100, 2).ToString() + "%";
        }
        private void BtnCerrarPldatos_Click(object sender, EventArgs e)
        {
            PLDatos.Visible = false;
            dtInventarioCat.Enabled = true;
            plOpciones.Enabled = true;
            BtnAnalisis.Text = "Analizado";
            Desactivar();
            Limpiar();
        }
        private void AbrirFormulario()
        {
            PLDatos.Size = new Size(1207, 622);
            PLDatos.Location = new System.Drawing.Point(dtInventarioCat.Width / 2
                - PLDatos.Width / 2, dtInventarioCat.Height / 2 - PLDatos.Height / 2);
            PLDatos.Visible = true;
            PLDatos.BringToFront();
            plOpciones.Enabled = false;
            dtInventarioCat.Enabled = false;
            Dcatacion funcion = new Dcatacion();
            funcion.MostrarVariedad(CbVariedad);
            if (Proceso == "S/A")
            {
                Activar();
            }
            else
            {
                Desactivar();
            }
            //if (Proceso != "Analizado")
            //{
            //    BtnAnalisis.Text = "Analizado";
            //}
            //else
            //{
            //    BtnAnalisis.Text = "Re-Análisis";
            //}
            //if (Proceso != "Analizado")
            //{
            //    //BtnAnalisis.Enabled = false;
            //    ChbAnalizado.Enabled = false;
            //    ChbRechazado.Enabled = false;
            //}
            //else
            //{
            //    ChbAnalizado.Enabled = true;
            //    ChbRechazado.Enabled = true;
            //}
            MostrarCambiarTK();
        }
        private void ChbRechazado_CheckedChanged(object sender, EventArgs e)
        {
            if (ChbRechazado.Checked == true)
            {
                ChbAnalizado.Enabled = false;
                BtnAnalisis.Enabled = true;
                ChbAnalizado.Checked = false;
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
            TxtDesmC.Text = "0";
            TxtScore.Clear();
            ChbAnalizado.Checked = false;
            ChbRechazado.Checked = false;
            TkDetalle = null;
        }
        private void BtnAnalisis_Click(object sender, EventArgs e)
        {
            if (BtnAnalisis.Text == "Analizado")
            {
                if (Validar())
                {
                    if (BtnMostrarCompras.Text == "Análisis")
                    {
                        InsertarCatacionCD();
                    }
                    else
                    {
                        InsertarCatacion();
                    }
                }
                else
                {
                    MessageBox.Show("Existen campos vacios", "ERROR campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (Validar())
                {
                    EditarCatacion();
                }
            }
            MostrarLotes();
            dtInventarioCat.Enabled = true;
            plOpciones.Enabled = true;
        }

        private void InsertarCatacionCD()
        {
            if (Validar())
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
                parametros.DesmC = double.Parse(TxtDesmC.Text);
                parametros.DesmD = double.Parse(LblDesmD.Text);
                parametros.Score = int.Parse(TxtScore.Text);
                parametros.Tasa = LblTasa.Text;
                parametros.GradoCalidad = LblGCalidad.Text;
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

        //Prueba Placeholders
        private void SetPlaceholder(TextBox textBox, string placeholderText)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                isPlaceholder = true;
                textBox.Text = placeholderText;
                textBox.ForeColor = System.Drawing.Color.Gray;
            }
            else
            {
                isPlaceholder = false;
                textBox.ForeColor = System.Drawing.Color.Black;
            }

            textBox.GotFocus += (sender, e) => RemovePlaceholder(sender, e, placeholderText);
            textBox.LostFocus += (sender, e) => ShowPlaceholder(sender, e, placeholderText);
        }
        private void RemovePlaceholder(object sender, EventArgs e, string placeholderText)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == placeholderText)
            {
                textBox.Text = "";
                textBox.ForeColor = System.Drawing.Color.Black;
                isPlaceholder = false;
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
        private void BtnCerrarCambioTK_Click(object sender, EventArgs e)
        {
            PlCambioTK.Visible = false;
            PLDatos.Enabled = true;
            TxtTkNueva.Clear();
        }
        private void ShowPlaceholder(object sender, EventArgs e, string placeholderText)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholderText;
                textBox.ForeColor = System.Drawing.Color.Gray;
                isPlaceholder = true;
            }
        }
        private void BtnCambioTK_Click(object sender, EventArgs e)
        {
            EditarTKAnalisis();
            MostrarLotes();
        }
        private void BtnActivar_Click(object sender, EventArgs e)
        {
            Activar();
            BtnAnalisis.Text = "Re-Analizar";
        }
        private void Activar()
        {
            TxtAnalisis.Enabled = true;
            DtFechaCatacion.Enabled = true;
            DTPFechaMuestra.Enabled = true;
            TxtBto.Enabled = true;
            CbVariedad.Enabled = true;
            TxtHumedad.Enabled = true;
            TxtExp.Enabled = true;
            TxtDesmA.Enabled = true;
            TxtDesmC.Enabled = true;
            TxtScore.Enabled = true;
            BtnAnalisis.Enabled = true;
            ChbAnalizado.Enabled = true;
            ChbRechazado.Enabled = true;
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
            TxtDesmC.Enabled = false;
            TxtScore.Enabled = false;
            BtnAnalisis.Text = "Analizado";
            BtnAnalisis.Enabled = false;
            ChbAnalizado.Enabled = false;
            ChbRechazado.Enabled = false;
        }
        private void InsertarCatacion()
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
                parametros.DesmC = double.Parse(TxtDesmC.Text);
                parametros.DesmD = double.Parse(LblDesmD.Text);
                parametros.Score = int.Parse(TxtScore.Text);
                parametros.Tasa = LblTasa.Text;
                parametros.GradoCalidad = LblGCalidad.Text;
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
        }
        private async void BtnMostrarCompras_Click(object sender, EventArgs e)
        {
            PlCarga.Dock = DockStyle.Fill;
            PlCarga.Visible = true;
            await Task.Delay(1500);
            if (BtnMostrarCompras.Text == "Compras Directas")
            {
                MostrarComprasD();
            }
            else
            {
                MostrarLotes();
            }
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
                parametros.DesmC = double.Parse(TxtDesmC.Text);
                parametros.DesmD = double.Parse(LblDesmD.Text);
                parametros.Score = int.Parse(TxtScore.Text);
                parametros.Tasa = LblTasa.Text;
                parametros.GradoCalidad = LblGCalidad.Text;
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
        private bool Validar()
        {
            double entero;
            if (!double.TryParse(TxtBto.Text, out entero) || (!double.TryParse(TxtHumedad.Text, out entero)))
            {
                return false;
            }
            return !(TxtAnalisis.Text == "" ||
                TxtBto.Text == "" || TxtDesmA.Text == ""
            || TxtDesmC.Text == "" || TxtScore.Text == "" || TxtExp.Text == "" || TxtHumedad.Text == "");
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
                        TxtDesmC.Text = row["DesmC"].ToString();
                    }
                    else
                    {
                        TxtDesmC.Clear();
                    }

                    // Asignar el valor de Cat.DesmD
                    if (row["DesmD"] != DBNull.Value && row["DesmD"].ToString() != null)
                    {
                        LblDesmD.Text = row["DesmD"].ToString();
                    }
                    else
                    {
                        LblDesmD.Text = "--";
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

                    // Asignar el valor de Cat.Taza 'Tasa'
                    if (row["Tasa"] != DBNull.Value && row["Tasa"].ToString() != null)
                    {
                        LblTasa.Text = row["Tasa"].ToString();
                    }
                    else
                    {
                        LblTasa.Text = "--";
                    }

                    // Asignar el valor de Cat.GradoCalidad
                    if (row["GradoCalidad"] != DBNull.Value && row["GradoCalidad"].ToString() != null)
                    {
                        LblGCalidad.Text = row["GradoCalidad"].ToString();
                    }
                    else
                    {
                        LblGCalidad.Text = "--";
                    }
                    if (row["Estado"] != DBNull.Value && row["Estado"].ToString() != null)
                    {
                        Estado = Boolean.Parse(row["Estado"].ToString());
                        if (Estado == true)
                        {
                            ChbAnalizado.Checked = true;
                        }
                        else if (Estado == false)
                        {
                            ChbRechazado.Checked = true;
                        }
                        else
                        {
                            ChbRechazado.Checked = false;
                            ChbAnalizado.Checked = false;
                        }
                    }

                    Idcatacion = int.Parse(row["IdCatacion"].ToString());
                    BtnActivar.Visible = true;
                    Desactivar();
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
            DCompraD funcion = new DCompraD();
            DataTable dt = new DataTable();
            funcion.MostrarComprasD(ref dt, desde, hasta);
            dtInventarioCat.DataSource = dt;
            BtnMostrarCompras.Text = "Análisis";
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
    }
}
