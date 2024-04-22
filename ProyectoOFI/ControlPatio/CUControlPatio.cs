using OfficeOpenXml.FormulaParsing.Excel.Functions;
using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using ProyectoOFI.Otros;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ProyectoOFI.ControlPatio
{
    public partial class CUControlPatio : UserControl
    {
        int desde = 1;
        int hasta = 100;
        private int items_por_pagina = 100;
        int totalPaginas;
        int Contador, edit;
        int ContarBusqueda;
        string Modulo;
        string Ticket, Estado;
        DateTime Frecibido;
        string Proceso;
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
            DTendido funcion = new DTendido();
            funcion.MostrarLotesCP(ref dt, desde, hasta);
            dtInventariocp.DataSource = dt;
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
            DTendido funcion = new DTendido();
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
                // BuscarTK();
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
                //BuscarTK();
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
                //BuscarTK();
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
                //BuscarTK();
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
            //lblTransferencia.Text = "Editar Transferencia";
            AbrirFormulario();
            if (Login.login.Trim().StartsWith("Admin", StringComparison.OrdinalIgnoreCase) || Modulo == "EditarTK")
            {
                PlEnfarde.Visible = true;
                PlEnvio.Visible = true;
            }
            else
            {
                if (Proceso == "No Asignado")
                {
                    PlTendido.Enabled = true;
                }
                if (Proceso == "Tendido")
                {
                    PlTendido.Enabled = false;
                    PlEnfarde.Visible = true;
                    VerTendidio();
                }
                else if (Proceso == "Enfardado")
                {
                    PlTendido.Enabled = false;
                    PlEnfarde.Enabled = false;
                    PlEnfarde.Visible = true;
                    PlEnvio.Visible = true;
                    TSLEnfarde.Visible = true;
                }
                else if (Proceso == "Enviado")
                {
                    PlTendido.Enabled = false;
                    PlEnfarde.Enabled = false;
                    PlEnfarde.Visible = true;
                    PlEnvio.Visible = true;
                    PlEnvio.Enabled = false;
                    TSLEnvio.Visible = true;
                }
            }
        }
        private void VerTendidio()
        {
            DTendido funcion = new DTendido();
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
                    DTPFechaTendido.Value = DateTime.Parse(row["Fecha Tendido"].ToString());
                    CbPatio.Text = row["Patio"].ToString();
                    CbUbicacionP.Text = row["Ubicación Patio"].ToString();

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
            DTendido Ten = new DTendido();
            Ten.MostrarPatio(CbPatio);
            LblDigitadorCp.Text = Login.NombreA;
        }
        private void ObtenerDatos()
        {
            DTendido funcion = new DTendido();
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
                LTendido parametros = new LTendido();
                DTendido funcion = new DTendido();
                parametros.Ticket = LblTicket.Text;
                parametros.Folio = int.Parse(TxtFolio.Text);
                parametros.FechaT = DateTime.Parse(DTPFechaTendido.Value.ToString());
                parametros.IdPatio = int.Parse(CbPatio.SelectedValue.ToString());
                parametros.IdUbicacionP = int.Parse(CbUbicacionP.SelectedValue.ToString());
                parametros.Digitador = LblDigitadorCp.Text;
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
                    LTendido parametros = new LTendido();
                    DTendido funcion = new DTendido();
                    parametros.Ticket = LblTicket.Text;
                    parametros.Folio = int.Parse(TxtFolio.Text);
                    parametros.FechaT = DateTime.Parse(DTPFechaTendido.Value.ToString());
                    parametros.IdPatio = int.Parse(CbPatio.SelectedValue.ToString());
                    parametros.IdUbicacionP = int.Parse(CbUbicacionP.SelectedValue.ToString());
                    parametros.Digitador = LblDigitadorCp.Text;
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
        }
        private void CbPatio_SelectedIndexChanged(object sender, EventArgs e)
        {
            DTendido funcion = new DTendido();
            funcion.MostrarPatioUbicacion(CbUbicacionP, (int)CbPatio.SelectedValue);
        }
        private void TSLTendido_Click(object sender, EventArgs e)
        {
            PlTendido.Enabled = true;
            BtnTendido.Text = "Actualizar";
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
    }
}
