using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using ProyectoOFI.Reportes;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOFI.Compras
{
    public partial class ComprasDirectas : UserControl
    {
        double kgsRem = 0, peso = 0, diferencia = 0;
        int IdBodega;
        string Ticket, Estado, Modulo;
        int desde = 1;
        int hasta = 100;
        private int items_por_pagina = 100;
        int totalPaginas;
        int Contador;
        public ComprasDirectas()
        {
            InitializeComponent();
            TxtKgsRem.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            TxtPeso.KeyPress += new KeyPressEventHandler(TextBox_KeyPress);
            TxtKgsRem.TextChanged += new EventHandler(TextBox_TextChanged);
            TxtPeso.TextChanged += new EventHandler(TextBox_TextChanged);
            ValidarPermisos();
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!double.TryParse(textBox.Text, out _))
            {
                textBox.Text = string.Empty; // Borra el contenido si no es un número válido
            }
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Obtiene el TextBox que generó el evento
            TextBox textBox = sender as TextBox;

            // Verifica si la tecla presionada es un dígito, un punto decimal o la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Rechaza la entrada de la tecla
            }

            // Permite solo un punto decimal
            if (e.KeyChar == '.' && (textBox.Text.Contains('.') || textBox.Text.Length == 0))
            {
                e.Handled = true; // Rechaza la entrada de la tecla si ya hay un punto decimal o es la primera tecla
            }
        }
        private async void ComprasDirectas_Load(object sender, System.EventArgs e)
        {
            PlCarga.Dock = DockStyle.Fill;
            await CargarDatos();
            PlCarga.Visible = false;
        }
        private async Task CargarDatos()
        {
            await Task.Delay(1500);
            dtInventarioCompras.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            MostrarComprasD();
            ReiniciarPaginado();
            await Task.Delay(1000);
        }
        private void MostrarComprasD()
        {
            DCompraD funcion = new DCompraD();
            DataTable dt = new DataTable();
            funcion.MostrarComprasD(ref dt, desde, hasta);
            dtInventarioCompras.DataSource = dt;
        }
        private void InsertarCompraDirecta()
        {
            try
            {
                if (Validar())
                {
                    if (DTPFecha.Value.Date <= DateTime.Today.Date)
                    {
                        DCompraD funcion = new DCompraD();
                        LComprasD parametros = new LComprasD();
                        parametros.Cosecha = TxtConsecha.Text;
                        parametros.Fecha = DTPFecha.Value;
                        parametros.Ticket = TxtTicket.Text;
                        parametros.Remision = TxtRem.Text;
                        parametros.Proveedor = CbProveedor.Text;
                        parametros.KgsRem = double.Parse(TxtKgsRem.Text);
                        parametros.Tally = TxtTally.Text;
                        parametros.IdEmpaque = (int)CbTipoEmpaque.SelectedValue;
                        parametros.Sacos = int.Parse(NudSacos.Text);
                        parametros.Kilos = double.Parse(TxtPeso.Text);
                        parametros.Diferencia = double.Parse(LblDiferencia.Text);
                        parametros.IdBodega = (int)CbBodega.SelectedValue;
                        parametros.IdUbicacion = (int)CbUbicacion.SelectedValue;
                        parametros.IdCompra = (int)cbCompra.SelectedValue;
                        parametros.IdMaterial = (int)CbMaterial.SelectedValue;
                        //parametros.IdCertificacion = (int)cbCertificacion.SelectedValue;
                        parametros.Estado = "S/A";
                        if (funcion.InsertarCompraDirecta(parametros) == true)
                        {
                            MostrarComprasD();
                            Limpiar();
                            PLDatos.Visible = false;
                            dtInventarioCompras.Enabled = true;
                            plOpciones.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void EditarCompraDirecta()
        {
            try
            {
                if (Validar())
                {
                    if (DTPFecha.Value.Date <= DateTime.Today.Date)
                    {
                        DCompraD funcion = new DCompraD();
                        LComprasD parametros = new LComprasD();
                        parametros.Cosecha = TxtConsecha.Text;
                        parametros.Fecha = DTPFecha.Value;
                        parametros.Ticket = TxtTicket.Text;
                        parametros.Remision = TxtRem.Text;
                        parametros.Proveedor = CbProveedor.Text;
                        parametros.KgsRem = double.Parse(TxtKgsRem.Text);
                        parametros.Tally = TxtTally.Text;
                        parametros.IdEmpaque = (int)CbTipoEmpaque.SelectedValue;
                        parametros.Sacos = int.Parse(NudSacos.Text);
                        parametros.Kilos = double.Parse(TxtPeso.Text);
                        parametros.Diferencia = double.Parse(LblDiferencia.Text);
                        parametros.IdBodega = (int)CbBodega.SelectedValue;
                        parametros.IdUbicacion = (int)CbUbicacion.SelectedValue;
                        parametros.IdCompra = (int)cbCompra.SelectedValue;
                        parametros.IdMaterial = (int)CbMaterial.SelectedValue;
                        //parametros.IdCertificacion = (int)cbCertificacion.SelectedValue;
                        parametros.Estado = Estado;
                        if (funcion.EditarCompraDirecta(parametros, Ticket) == true)
                        {
                            MostrarComprasD();
                            Limpiar();
                            PLDatos.Visible = false;
                            dtInventarioCompras.Enabled = true;
                            plOpciones.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Limpiar()
        {
            TxtTicket.Clear();
            TxtConsecha.Clear();
            TxtRem.Clear();
            TxtKgsRem.Clear();
            TxtTally.Clear();
            NudSacos.Value = 0;
            TxtPeso.Clear();
            LblDiferencia.Text = "--";
        }
        private void Activar()
        {
            TxtConsecha.Enabled = true;
            TxtRem.Enabled = true;
            TxtKgsRem.Enabled = true;
            TxtTally.Enabled = true;
            NudSacos.Enabled = true;
            TxtPeso.Enabled = true;
            DTPFecha.Enabled = true;
            CbProveedor.Enabled = true;
            CbTipoEmpaque.Enabled = true;
            CbBodega.Enabled = true;
            CbUbicacion.Enabled = true;
            cbCompra.Enabled = true;
            //cbCertificacion.Enabled = true;
            TxtTicket.Enabled = true;
            BtnActivar.Visible = false;
            plOpciones.Enabled = true;
            dtInventarioCompras.Enabled = true;
            BtnGuardar.Enabled = true;
        }
        private void Desactivar()
        {
            TxtConsecha.Enabled = false;
            TxtRem.Enabled = false;
            TxtKgsRem.Enabled = false;
            TxtTally.Enabled = false;
            NudSacos.Enabled = false;
            TxtPeso.Enabled = false;
            DTPFecha.Enabled = false;
            CbProveedor.Enabled = false;
            CbTipoEmpaque.Enabled = false;
            CbBodega.Enabled = false;
            CbUbicacion.Enabled = false;
            cbCompra.Enabled = false;
            //cbCertificacion.Enabled = false;
            TxtTicket.Enabled = false;
        }
        private bool Validar()
        {
            double entero;
            if (!double.TryParse(TxtPeso.Text, out entero) || !double.TryParse(TxtKgsRem.Text, out entero) || !double.TryParse(TxtPeso.Text, out entero))
            {
                return false;
            }
            return !(TxtPeso.Text == "" || TxtConsecha.Text == "" || TxtKgsRem.Text == "" || TxtRem.Text == "" || TxtTally.Text == "");
        }
        private void BtnCerrarPldatos_Click(object sender, EventArgs e)
        {
            PLDatos.Visible = false;
            BtnGuardar.Text = "Guardar";
            Limpiar();
            Activar();
            ValidarPermisos();
        }
        private void Calcular()
        {
            diferencia = 0;
            diferencia = kgsRem - peso;
            LblDiferencia.Text = Math.Round(diferencia, 2).ToString();
        }
        private void TxtKgsRem_TextChanged(object sender, EventArgs e)
        {
            if (TxtKgsRem.Text == "")
            {
                kgsRem = 0;
            }
            else
            {
                kgsRem = double.Parse(TxtKgsRem.Text);
            }
            Calcular();
        }
        private void TxtPeso_TextChanged(object sender, EventArgs e)
        {
            if (TxtPeso.Text == "")
            {
                peso = 0;
            }
            else
            {
                peso = double.Parse(TxtPeso.Text);
            }
            Calcular();
        }
        private void CbBodega_SelectedIndexChanged(object sender, EventArgs e)
        {
            IdBodega = (int)CbBodega.SelectedValue;
            DAlmacen DA = new DAlmacen();
            DA.MostrarUbicacionPxBodega(CbUbicacion, IdBodega);
        }
        private void dtInventarioCompras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtInventarioCompras.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("¿Esta seguro de eliminar la ticket, Desea Continuar?", "Eliminando registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarCompraD();
                }
            }
        }
        private void EliminarCompraD()
        {
            DCompraD funcion = new DCompraD();
            ObtenerTK();
            if (funcion.EliminarCompraD(Ticket, Login.NombreA) == true)
            {
                MostrarComprasD();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al intenatr eliminar el registro: " + TxtTicket.Text, "Error al eliminar Compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtInventarioCompras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarCombos();
            ObtenerTK();
            VerDetalleCompra();
            AbrirFormulario();
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (BtnGuardar.Text == "Guardar")
            {
                InsertarCompraDirecta();
            }
            else
            {
                EditarCompraDirecta();
            }
        }
        private void ObtenerTK()
        {
            string nombrecolumna = "Ticket";
            int indice = dtInventarioCompras.Columns[nombrecolumna].Index;
            Ticket = dtInventarioCompras.SelectedCells[indice].Value.ToString();

            string nombreEstado = "Estado";
            int numEstado = dtInventarioCompras.Columns[nombreEstado].Index;
            Estado = dtInventarioCompras.SelectedCells[numEstado].Value.ToString();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CargarCombos();
            AbrirFormulario();
        }
        private void CargarCombos()
        {
            DRecepcion DR = new DRecepcion();
            DR.MostrarProveedor(CbProveedor);
            DR.MostrarCompra(cbCompra);
            //DR.MostrarCert(cbCertificacion);
            DAlmacen DA = new DAlmacen();
            DA.MostrarEmpaque(CbTipoEmpaque);
            DA.MostrarBodega(CbBodega);
            DA.MostrarUbicacionPxBodega(CbUbicacion, IdBodega);
            DCompraD CD = new DCompraD();
            CD.MostrarMaterial(CbMaterial);
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
            DCompraD funcion = new DCompraD();
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
                funcion.Contar(ref Contador);
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
                MostrarComprasD();
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
                MostrarComprasD();
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
                MostrarComprasD();
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
        private void BtnActivar_Click(object sender, EventArgs e)
        {
            Activar();
        }

        private void PbExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DCompraD funcion = new DCompraD();
            funcion.ExcelCompraDirecta(ref dt);
            string Nombre = "Compras Directas ";
            FrmLotes_Tendido LT = new FrmLotes_Tendido(dt, Nombre);
            LT.ShowDialog();
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
                MostrarComprasD();
            }
        }
        #endregion
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
                        TxtConsecha.Text = row["Cosecha"].ToString();
                    }
                    else
                    {
                        TxtConsecha.Clear();
                    }
                    if (DateTime.Parse(row["Fecha"].ToString()) != null)
                    {
                        DTPFecha.Value = DateTime.Parse(row["Fecha"].ToString());
                    }
                    else
                    {
                        DTPFecha.Value = DateTime.Today;
                    }
                    if (row["Ticket"].ToString() != null)
                    {
                        TxtTicket.Text = row["Ticket"].ToString();
                    }
                    else
                    {
                        TxtTicket.Text = "";
                    }
                    if (row["Remision"].ToString() != null)
                    {
                        TxtRem.Text = row["Remision"].ToString();
                    }
                    else
                    {
                        TxtRem.Text = "";
                    }
                    if (row["Tally"].ToString() != null)
                    {
                        TxtTally.Text = row["Tally"].ToString();
                    }
                    else
                    {
                        TxtTally.Text = "";
                    }
                    if (row["kilos"].ToString() != null)
                    {
                        TxtPeso.Text = row["kilos"].ToString();
                    }
                    else
                    {
                        TxtPeso.Text = "";
                    }
                    if (row["KgsRem"].ToString() != null)
                    {
                        TxtKgsRem.Text = row["KgsRem"].ToString();
                    }
                    else
                    {
                        TxtKgsRem.Text = "";
                    }
                    if (row["Sacos"].ToString() != null)
                    {
                        NudSacos.Value = int.Parse(row["Sacos"].ToString());
                    }
                    else
                    {
                        NudSacos.Value = 0;
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
                        CbProveedor.Text = row["Proveedor"].ToString();
                    }
                    else
                    {
                        CbProveedor.Text = "--";
                    }
                    if (row["Empaque"].ToString() != null)
                    {
                        CbTipoEmpaque.Text = row["Empaque"].ToString();
                    }
                    else
                    {
                        CbTipoEmpaque.Text = "--";
                    }
                    if (row["Bodega"].ToString() != null)
                    {
                        CbBodega.Text = row["Bodega"].ToString();
                    }
                    else
                    {
                        CbBodega.Text = "--";
                    }
                    if (row["Ubicacion"].ToString() != null)
                    {
                        CbUbicacion.Text = row["Ubicacion"].ToString();
                    }
                    else
                    {
                        CbUbicacion.Text = "--";
                    }
                    if (row["Tipo de Compra"].ToString() != null)
                    {
                        cbCompra.Text = row["Tipo de Compra"].ToString();
                    }
                    else
                    {
                        cbCompra.Text = "--";
                    }
                    //if (row["Certificacion"].ToString() != null)
                    //{
                    //    cbCertificacion.Text = row["Certificacion"].ToString();
                    //}
                    //else
                    //{
                    //    cbCertificacion.Text = "--";
                    //}
                    Desactivar();
                    BtnGuardar.Enabled = false;
                    BtnActivar.Visible = true;
                    BtnGuardar.Text = "Editar";
                }
                else
                {
                    BtnGuardar.Enabled = true;
                    BtnActivar.Visible = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error en cargar datos interfaz", "Error en datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AbrirFormulario()
        {

            //PlControl.Location = new Point(dtInventariocp.Width / 2
            //    - PlControl.Width / 2, dtInventariocp.Height / 2 - PlControl.Height / 3);
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


            //PLDatos.Size = new Size(1207, 622);
            //PLDatos.Location = new System.Drawing.Point(dtInventarioCompras.Width / 2
            //    - PLDatos.Width / 2, dtInventarioCompras.Height / 2 - PLDatos.Height / 2);
            PLDatos.Visible = true;
            PLDatos.BringToFront();
            plOpciones.Enabled = false;
            dtInventarioCompras.Enabled = false;
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
                foreach (DataRow rowpermisos in dt.Rows)
                {
                    Modulo = Convert.ToString(rowpermisos["Modulo"]);
                    if (Modulo == "Agregar CompraDirecta")
                    {
                        btnAgregar.Visible = true;
                    }
                    if (Modulo == "Editar CompraDirecta")
                    {
                        BtnActivar.Enabled = true;
                    }
                    if (Modulo == "Elminar CompraDirecta")
                    {
                        dtInventarioCompras.Columns["Eliminar"].Visible = true;
                    }
                }
            }
            else
            {
                btnAgregar.Visible = true;
                BtnActivar.Enabled = true;
                dtInventarioCompras.Columns["Eliminar"].Visible = true;
            }
        }
    }
}
