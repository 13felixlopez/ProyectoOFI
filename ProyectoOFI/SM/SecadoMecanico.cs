using ProyectoOFI.Datos;
using ProyectoOFI.Otros;
using System;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOFI.SM
{
    public partial class SecadoMecanico : UserControl
    {
        string Ticket, Proceso;
        DateTime Frecibido;
        int desde = 1;
        int hasta = 100;
        int Contador, totalPaginas;
        int ContarBusqueda;
        private int items_por_pagina = 100;

        public SecadoMecanico()
        {
            InitializeComponent();
        }

        private async void SecadoMecanico_Load(object sender, EventArgs e)
        {
            PlCarga.Dock = DockStyle.Fill;
            await CargarDatos();
            Base.DiseñoDtvEliminar(ref dtInventarioSM);
            PlCarga.Visible = false;
        }
        private async Task CargarDatos()
        {
            await Task.Delay(1500);
            dtInventarioSM.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            MostrarSM();
            ReiniciarPaginado();
            await Task.Delay(1000);
        }
        private void MostrarSM()
        {
            DSM SM = new DSM();
            DataTable dt = new DataTable();
            SM.MostrarSM(ref dt, desde, hasta);
            dtInventarioSM.DataSource = dt;
            dtInventarioSM.Columns["Proceso"].Visible = false;
        }
        private void ObtenerTK()
        {
            string nombrecolumna = "Ticket";
            int indice = dtInventarioSM.Columns[nombrecolumna].Index;
            Ticket = dtInventarioSM.SelectedCells[indice].Value.ToString();

        }
        private void dtInventarioSM_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerTK();
            VerDetalleTkSM();
            AbrirFormulario();
            if (LblCert.Text != "Convencional")
            {
                PLDatos.BackColor = Color.FromArgb(192, 255, 255);
            }
            else
            {
                PLDatos.BackColor = Color.FromArgb(192, 255, 192);
            }
        }
        private void AbrirFormulario()
        {
            PLDatos.Location = new Point(dtInventarioSM.Width / 2
                - PLDatos.Width / 2, dtInventarioSM.Height / 2 - PLDatos.Height / 2);
            PLDatos.Visible = true;
            PLDatos.BringToFront();
            plOpciones.Enabled = false;
        }
        private void BtnCerrarVerCons_Click(object sender, EventArgs e)
        {
            PLDatos.Visible = false;
            plOpciones.Enabled = true;
        }
        private void VerDetalleTkSM()
        {
            try
            {
                DataTable dt = new DataTable();
                DSM SM = new DSM();
                SM.VerDetalleTkSM(ref dt, Ticket);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    double kilos;
                    if (row["Certificacion"].ToString() != null)
                    {
                        LblCert.Text = row["Certificacion"].ToString();
                    }
                    else
                    {
                        LblCert.Text = "";
                    }
                    LblTk.Text = Ticket.ToString();
                    Frecibido = DateTime.Parse(row["FechaRecibido"].ToString());
                    LblFRecibido.Text = Frecibido.ToString();
                    LblEFisicoV.Text = row["EstFisico"].ToString();
                    LblCalidadV.Text = row["Calidad"].ToString();
                    LblDanioV.Text = row["Danio"].ToString();
                    LblSacos.Text = row["Sacos"].ToString();
                    LblKilos.Text = row["Peso"].ToString();
                    kilos = double.Parse(LblKilos.Text);
                    kilos = kilos / 46;
                    LblQQsV.Text = Math.Round(kilos, 2).ToString();
                    Proceso = row["ProcesoSM"].ToString();
                    if (row["POAV"].ToString() != null)
                    {
                        LblPOAV.Text = row["POAV"].ToString();
                    }
                    else
                    {
                        LblPOAV.Text = "";
                    }
                    if (row["TurnoPV"].ToString() != null)
                    {
                        LblTurnoPV.Text = row["TurnoPV"].ToString();
                    }
                    else
                    {
                        LblTurnoPV.Text = "";
                    }
                    if (row["Nombre"].ToString() != null)
                    {
                        LblOperadorPV.Text = row["Nombre"].ToString();
                    }
                    else
                    {
                        LblOperadorPV.Text = "";
                    }
                    if (row["FRecibidoPV"].ToString() != null)
                    {
                        dtFechaPV.Text = row["FRecibidoPV"].ToString();
                    }
                    else
                    {
                        dtFechaPV.Text = DateTime.Today.ToString();
                    }
                    if (row["HumedadPV"].ToString() != null)
                    {
                        LblHumedadPV.Text = row["HumedadPV"].ToString() + "%";
                    }
                    else
                    {
                        LblHumedadPV.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos en controles" + ex.Message, "ERROR en Secado Mecanico", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            DSM funcion = new DSM();
            if (txtBuscador.Text != "")
            {
                Contador = ContarBusqueda;
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
                //Buscar();
            }
            //else if (CbBuscador.Visible == true)
            //{
            //    //BuscarDatos();
            //}
            else
            {
                MostrarSM();
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
                //Buscar();
            }
            //else if (CbBuscador.Visible == true)
            //{
            //    //BuscarDatos();
            //}
            else
            {
                MostrarSM();
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
                //Buscar();
            }
            //else if (CbBuscador.Visible == true)
            //{
            //    //BuscarDatos();
            //}
            else
            {
                MostrarSM();
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
                //Buscar();
            }
            //else if (CbBuscador.Visible == true)
            //{
            //    //BuscarDatos();
            //}
            else
            {
                MostrarSM();
            }
        }
        #endregion
    }
}
