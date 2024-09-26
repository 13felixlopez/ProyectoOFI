using ProyectoOFI.Datos;
using ProyectoOFI.Otros;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
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
        int ContarBusqueda;
        public FrmHistorial()
        {
            InitializeComponent();
            AdjustFormSize();
        }
        private void AdjustFormSize()
        {
            // Tamaño deseado del formulario
            int desiredWidth = 1834;
            int desiredHeight = 788;

            // Obtener tamaño de la pantalla
            Rectangle screenRectangle = Screen.PrimaryScreen.WorkingArea;

            // Ajustar tamaño del formulario
            int newWidth = Math.Min(desiredWidth, screenRectangle.Width);
            int newHeight = Math.Min(desiredHeight, screenRectangle.Height);

            this.Size = new Size(newWidth, newHeight);

            // Centrar el formulario en la pantalla
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private async void FrmHistorial_Load(object sender, EventArgs e)
        {
            PlCarga.Dock = DockStyle.Fill;
            await CargarDatos();
            DtHistorial.Columns["IdHistorial"].Visible = false;
            PlCarga.Visible = false;
            CargarEncabezadosEnComboBox();
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
            else if (PlFiltroFecha.Visible == true)
            {
                BuscarRangoFecha();
            }
            else
            {
                MostrarHistorial();
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

        private void BuscarDatos()
        {
            DataTable dt = new DataTable();
            DHistorial funcion = new DHistorial();
            //funcion.BuscarTK(txtBuscador.Text, ref dt, desde, hasta, ContarBusqueda);
            funcion.BuscarHistorial(CbBuscador.Text, CbBuscar.Text, ref dt, desde, hasta, Contador);
            DtHistorial.DataSource = dt;
            ContarBusqueda = int.Parse(funcion.Contador.ToString());
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
            else if (PlFiltroFecha.Visible == true)
            {
                BuscarRangoFecha();
            }
            else
            {
                MostrarHistorial();
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
            else if (PlFiltroFecha.Visible == true)
            {
                BuscarRangoFecha();
            }
            else
            {
                MostrarHistorial();
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
            else if (PlFiltroFecha.Visible == true)
            {
                BuscarRangoFecha();
            }
            else
            {
                MostrarHistorial();
            }
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
                funcion.ContarHistorial(ref Contador);
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

        #endregion
        private void CargarEncabezadosEnComboBox()
        {
            // Limpiar el ComboBox antes de cargar los encabezados
            CbBuscar.Items.Clear();

            // Definir el encabezado que no se debe cargar (en todas sus variaciones)
            string[] encabezadosIgnorar = { "Observación", "Observacion", "observación", "observacion" };

            // Iterar sobre las columnas visibles del DataGridView y agregar sus encabezados al ComboBox
            foreach (DataGridViewColumn col in DtHistorial.Columns)
            {
                if (col.Visible)  // Solo añadir las columnas visibles
                {
                    // Si el encabezado no es "Observación" (en todas sus variaciones), lo agregamos
                    if (!encabezadosIgnorar.Contains(col.HeaderText))
                    {
                        CbBuscar.Items.Add(col.HeaderText);
                    }
                }
            }

            // Opcional: Seleccionar el primer elemento por defecto si hay elementos en el ComboBox
            if (CbBuscar.Items.Count > 0)
            {
                CbBuscar.SelectedIndex = 0;
            }
        }
        private void BuscarTK()
        {
            DataTable dt = new DataTable();
            DHistorial funcion = new DHistorial();
            //funcion.BuscarTK(txtBuscador.Text, ref dt, desde, hasta, ContarBusqueda);
            funcion.BuscarHistorial(txtBuscador.Text, CbBuscar.Text, ref dt, desde, hasta, Contador);
            DtHistorial.DataSource = dt;
            ContarBusqueda = int.Parse(funcion.Contador.ToString());
        }
        private void BuscarRangoFecha()
        {
            DataTable dt = new DataTable();
            DHistorial funcion = new DHistorial();
            funcion.BuscarHistorialFecha(ref dt, DtpInicio.Value, DtpFin.Value, desde, hasta, Contador);
            DtHistorial.DataSource = dt;
            ContarBusqueda = int.Parse(funcion.Contador.ToString());
        }

        private void CbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbBuscar.Text == "Fecha")
            {
                CbBuscador.Visible = false;
                txtBuscador.Visible = false;
                PlFiltroFecha.Visible = true;
            }
            else if (CbBuscar.Text == "Ticket")
            {
                CbBuscador.Visible = false;
                txtBuscador.Visible = true;
                PlFiltroFecha.Visible = false;
            }
            else if (CbBuscar.Text == "Usuario")
            {
                CbBuscador.Visible = true;
                txtBuscador.Visible = false;
                PlFiltroFecha.Visible = false;
                DHistorial funcion = new DHistorial();
                funcion.MostrarUsuarios(CbBuscador);
            }
        }

        private void BtnFiltroFecha_Click(object sender, EventArgs e)
        {
            BuscarRangoFecha();
            ReiniciarPaginado();
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            BuscarTK();
            ReiniciarPaginado();
        }

        private void CbBuscador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbBuscador.Text == "")
            {
                ReiniciarPaginado();
                MostrarHistorial();
            }
            else
            {
                BuscarDatos();
                ReiniciarPaginado();
            }
        }
    }
}
