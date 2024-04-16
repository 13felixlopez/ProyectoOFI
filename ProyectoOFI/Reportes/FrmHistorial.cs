using ProyectoOFI.Datos;
using ProyectoOFI.Otros;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOFI.Reportes
{
    public partial class FrmHistorial : Form
    {
        int desde = 1;
        int hasta = 100;
        private int items_por_pagina = 100;
        int totalPaginas;
        int Contador;
        public FrmHistorial()
        {
            InitializeComponent();
        }
        private async void FrmHistorial_Load(object sender, EventArgs e)
        {
            PlCarga.Dock = DockStyle.Fill;
            await CargarDatos();
            DtHistorial.Columns["IdHistorial"].Visible = false;
            PlCarga.Visible = false;
        }
        private void MostrarHistorial()
        {
            DHistorial funcion = new DHistorial();
            DataTable dt = new DataTable();
            funcion.MostrarHistorial(ref dt, desde, hasta);
            DtHistorial.DataSource = dt;
        }
        private async Task CargarDatos()
        {
            await Task.Delay(1500);
            DtHistorial.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            MostrarHistorial();
            ReiniciarPaginado();
            await Task.Delay(1000);
        }
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region Paginado Btn
        private void btn_atras_Click(object sender, EventArgs e)
        {
            desde -= 10;
            hasta -= 10;
            MostrarHistorial();
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
            desde += 10;
            hasta += 10;
            MostrarHistorial();
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
            desde = hasta - 9;
            MostrarHistorial();
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
            MostrarHistorial();
        }
        #endregion
        #region Paginado Metodos
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
            DHistorial funcion = new DHistorial();
            funcion.ContarHistorial(ref Contador);
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

        #endregion
    }
}
