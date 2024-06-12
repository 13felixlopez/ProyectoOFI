using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
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
        string Ticket;
        int IdBodega, IdEmpaque;
        double PesoNeto, Tara;
        public Almacen()
        {
            InitializeComponent();
        }

        private async void Almacen_Load(object sender, EventArgs e)
        {
            PlCarga.Dock = DockStyle.Fill;
            await CargarDatos();
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
                // BuscarTK();
            }
            //else if (CbBuscador.Visible == true)
            //{
            //    BuscarDatos();
            //}
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
                //BuscarTK();
            }
            //else if (CbBuscador.Visible == true)
            //{
            //    BuscarDatos();
            //}
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
                // BuscarTK();
            }
            //else if (CbBuscador.Visible == true)
            //{
            //    BuscarDatos();
            //}
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
            AbrirFormulario();
        }

        private void ObtenerTK()
        {
            string nombrecolumna = "Ticket";
            int indice = dtInventarioAlm.Columns[nombrecolumna].Index;
            Ticket = dtInventarioAlm.SelectedCells[indice].Value.ToString();
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
            }
        }
        private void AbrirFormulario()
        {
            PLDatos.Size = new Size(1207, 622);
            PLDatos.Location = new System.Drawing.Point(dtInventarioAlm.Width / 2
                - PLDatos.Width / 2, dtInventarioAlm.Height / 2 - PLDatos.Height / 2);
            PLDatos.Visible = true;
            PLDatos.BringToFront();
            plOpciones.Enabled = false;
            dtInventarioAlm.Enabled = false;
        }
        private void BtnCerrarPldatos_Click(object sender, EventArgs e)
        {
            PLDatos.Visible = false;
            dtInventarioAlm.Enabled = true;
            plOpciones.Enabled = true;
        }
        private void InsertarAlmacen()
        {
            if (validar())
            {
                DAlmacen funcion = new DAlmacen();
                LAlmacen parametros = new LAlmacen();
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

        private void NudSacos_ValueChanged(object sender, EventArgs e)
        {
            int Sacos = (int)NudSacos.Value;
            if (Sacos > 0)
            {
                TxtTara.Text = (Sacos * Tara).ToString();
            }
            else
            {
                TxtTara.Text = Tara.ToString();
            }
        }

        private void TxtPeso_TextChanged(object sender, EventArgs e)
        {
            double Peso;
            Double PesoNeto, PesoRec;
            Peso = double.Parse(TxtPeso.Text);
            Tara = double.Parse(TxtTara.Text);
            PesoNeto = Peso - Tara;
            TxtPesoNeto.Text = PesoNeto.ToString();
            PesoNeto = double.Parse(TxtPesoNeto.Text);
            PesoRec = double.Parse(LblPeso.Text);
            LblRedimiento.Text = (PesoNeto / PesoRec).ToString();
        }

        private void CbTipoEmpaque_SelectedIndexChanged(object sender, EventArgs e)
        {
            DAlmacen funcion = new DAlmacen();
            IdEmpaque = (int)CbTipoEmpaque.SelectedValue;
            funcion.MostrarTaraSaco(IdEmpaque);
        }
    }
}
