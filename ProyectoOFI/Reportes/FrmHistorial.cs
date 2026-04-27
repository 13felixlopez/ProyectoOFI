using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using ProyectoOFI.Datos;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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
            await MostrarHistorialAsync();        // página inicial
            ReiniciarPaginado();
            CargarEncabezadosEnComboBox();        // lo que tenías
        }
        private bool _cargando;                       // evita clics repetidos
        private DataGridViewAutoSizeColumnsMode _modoOriginal;

        private async Task MostrarHistorialAsync()
        {
            if (_cargando) return;                    // ya hay una carga en curso
            _cargando = true;

            // --- Feedback al usuario ---
            PlCarga.Dock = DockStyle.Fill;
            PlCarga.Visible = true;

            // --- Acelera la actualización ---
            DtHistorial.SuspendLayout();
            _modoOriginal = DtHistorial.AutoSizeColumnsMode;
            DtHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // --- Carga real en hilo de trabajo ---
            var dt = await Task.Run(() =>
            {
                var tabla = new DataTable();
                tabla.BeginLoadData();
                new DHistorial().MostrarHistorial(ref tabla, desde, hasta);  // usa paginación
                tabla.EndLoadData();
                return tabla;
            });

            // --- Enlace y formato ---
            DtHistorial.DataSource = dt;
            DtHistorial.Columns["IdHistorial"].Visible = false;
            DtHistorial.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            DtHistorial.AutoSizeColumnsMode = _modoOriginal;
            DtHistorial.ResumeLayout();

            // --- Fin ---
            PlCarga.Visible = false;
            _cargando = false;
        }

        //private async Task CargarDatos()
        //{
        //    await Task.Delay(1500);
        //    DtHistorial.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        //    MostrarHistorial();
        //    ReiniciarPaginado();
        //    await Task.Delay(1000);
        //}
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region Paginado Btn
        private async void btn_atras_Click(object sender, EventArgs e)
        {
            desde -= 100;
            hasta -= 100;

            if (!string.IsNullOrEmpty(txtBuscador.Text))
                await BuscarTKAsync();
            else if (CbBuscador.Visible)
                await BuscarDatosAsync();
            else if (PlFiltroFecha.Visible)
                await BuscarRangoFechaAsync();
            else
                await MostrarHistorialAsync();

            ActualizarPaginadoYBotones();
        }
        private async Task BuscarDatosAsync()
        {
            DataTable dt = new DataTable();
            DHistorial funcion = new DHistorial();
            //funcion.BuscarTK(txtBuscador.Text, ref dt, desde, hasta, ContarBusqueda);
            funcion.BuscarHistorial(CbBuscador.Text, CbBuscar.Text, ref dt, desde, hasta, Contador);
            DtHistorial.DataSource = dt;
            ContarBusqueda = int.Parse(funcion.Contador.ToString());
        }

        private async void btn_Sig_Click(object sender, EventArgs e)
        {
            desde += 100;
            hasta += 100;

            if (!string.IsNullOrEmpty(txtBuscador.Text))
                await BuscarTKAsync();
            else if (CbBuscador.Visible)
                await BuscarDatosAsync();
            else if (PlFiltroFecha.Visible)
                await BuscarRangoFechaAsync();
            else
                await MostrarHistorialAsync();

            ActualizarPaginadoYBotones();
        }
        private async void btn_Ultima_Click(object sender, EventArgs e)
        {
            hasta = totalPaginas * items_por_pagina;
            desde = hasta - 99;
            if (txtBuscador.Text != "")
            {
                await BuscarTKAsync();
            }
            else if (CbBuscador.Visible == true)
            {
                await BuscarDatosAsync();
            }
            else if (PlFiltroFecha.Visible == true)
            {
                await BuscarRangoFechaAsync();
            }
            else
            {
                await MostrarHistorialAsync();
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
        private async void btn_Primera_Click(object sender, EventArgs e)
        {
            ReiniciarPaginado();
            if (txtBuscador.Text != "")
            {
                await BuscarTKAsync();
            }
            else if (CbBuscador.Visible == true)
            {
                await BuscarDatosAsync();
            }
            else if (PlFiltroFecha.Visible == true)
            {
                await BuscarRangoFechaAsync();
            }
            else
            {
                await MostrarHistorialAsync();
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
        private async Task BuscarTKAsync()
        {
            DataTable dt = new DataTable();
            DHistorial funcion = new DHistorial();
            //funcion.BuscarTK(txtBuscador.Text, ref dt, desde, hasta, ContarBusqueda);
            funcion.BuscarHistorial(txtBuscador.Text, CbBuscar.Text, ref dt, desde, hasta, Contador);
            DtHistorial.DataSource = dt;
            ContarBusqueda = int.Parse(funcion.Contador.ToString());
        }
        private async Task BuscarRangoFechaAsync()
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

        private async void BtnFiltroFecha_Click(object sender, EventArgs e)
        {
            await BuscarRangoFechaAsync();
            ReiniciarPaginado();
        }

        private async void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            await BuscarTKAsync();
            ReiniciarPaginado();
        }

        private async void CbBuscador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbBuscador.Text == "")
            {
                ReiniciarPaginado();
                await MostrarHistorialAsync();
            }
            else
            {
                await BuscarDatosAsync();
                ReiniciarPaginado();
            }
        }

        private void PbExcel_Click(object sender, EventArgs e)
        {
            DHistorial funcion = new DHistorial();
            DataTable dt = new DataTable();
            funcion.ExcelHistorial(ref dt);
            string Nombre = "Historial ";
            FrmLotes_Tendido LT = new FrmLotes_Tendido(dt, Nombre);
            LT.ShowDialog();
        }
        private void ActualizarPaginadoYBotones()
        {
            Contar();                               // tu método actual
            btn_atras.Visible = desde > 1;
            btn_Sig.Visible = Contador > hasta;
            Paginar();                              // pinta "Página X de N"
        }

        private void ExportToExcel(DataGridView dataGridView, string fileName)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Datos");

            // Crear el formato de fecha
            ICellStyle dateCellStyle = workbook.CreateCellStyle();
            short dateFormat = workbook.CreateDataFormat().GetFormat("yyyy-MM-dd"); // Formato de fecha
            dateCellStyle.DataFormat = dateFormat;

            // Crear la fila de encabezado con columnas visibles
            IRow headerRow = sheet.CreateRow(0);
            int visibleColumnIndex = 0;
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column.Visible)
                {
                    ICell cell = headerRow.CreateCell(visibleColumnIndex++);
                    cell.SetCellValue(column.HeaderText);
                }
            }

            // Llenar las filas con datos del DataGridView solo de columnas visibles
            int rowIndex = 1;
            foreach (DataGridViewRow gridViewRow in dataGridView.Rows)
            {
                IRow row = sheet.CreateRow(rowIndex++);
                visibleColumnIndex = 0;

                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    if (column.Visible)
                    {
                        ICell cell = row.CreateCell(visibleColumnIndex++);
                        var cellValue = gridViewRow.Cells[column.Index].Value;

                        if (cellValue is DateTime dateValue)
                        {
                            // Formatear como fecha
                            cell.SetCellValue(dateValue);
                            cell.CellStyle = dateCellStyle;
                        }
                        else if (decimal.TryParse(cellValue?.ToString(), out decimal numericValue))
                        {
                            // Formatear como número
                            cell.SetCellValue((double)numericValue);
                        }
                        else
                        {
                            cell.SetCellValue(cellValue?.ToString() ?? string.Empty);
                        }
                    }
                }
            }

            // Guardar el archivo Excel
            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(stream);
            }
        }


        private void SaveExcelFile(DataGridView dataGridView, string defaultFileName)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Guardar archivo Excel";
                saveFileDialog.FileName = defaultFileName;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;
                    ExportToExcel(dataGridView, fileName);

                    DialogResult result = MessageBox.Show("Archivo Excel creado y guardado exitosamente. ¿Deseas abrir el archivo?", "Exportación Completada", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo(fileName) { UseShellExecute = true });
                    }
                }
            }
        }

        private void BtnCambioUbi_Click(object sender, EventArgs e)
        {
            DtHistorial.DataSource = null;
            if (BtnDescargar.Visible == false)
            {
                BtnDescargar.Visible = true;
            }
            else
            {
                BtnDescargar.Visible = false;
            }
            DHistorial funcion = new DHistorial();
            DataTable dt =new DataTable();
            funcion.CambioUbi(ref dt);
            DtHistorial.DataSource = dt;
        }

        private void BtnDescargar_Click(object sender, EventArgs e)
        {
            string fe = "Cambio Ubicacion " + DateTime.Now.Day + "_" + DateTime.Today.Month + "_" + DateTime.Today.Year + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;
            SaveExcelFile(DtHistorial, fe);
        }
    }
}
