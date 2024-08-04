using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using OfficeOpenXml;
using ProyectoOFI.Datos;
using ProyectoOFI.Otros;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProyectoOFI.ControlPatio
{
    public partial class FrmExcelCP : Form
    {
        List<string> filtro = new List<string>();
        public FrmExcelCP()
        {
            InitializeComponent();
            AdjustFormSize();
            //ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }
        private void AdjustFormSize()
        {
            // Tamaño deseado del formulario 1834; 788
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
        private void FrmExcelCP_Load(object sender, EventArgs e)
        {
            LotesExcelCP();
        }
        private void LotesExcelCP()
        {
            DControlPatio funcion = new DControlPatio();
            DataTable dt = new DataTable();
            funcion.LotesExcelCP(ref dt);
            DtLotes.DataSource = dt;
            Base.DiseñoDtvEliminar(ref DtLotes);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PbExcel_Click(object sender, EventArgs e)
        {
            string fe = "Control de Patio " + DateTime.Now.Day + "_" + DateTime.Today.Month + "_" + DateTime.Today.Year + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;
            SaveExcelFile(DtLotes, fe);
        }
        private void ExportToExcel(DataGridView dataGridView, string fileName)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("No_Asignados");

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
                        cell.SetCellValue(gridViewRow.Cells[column.Index].Value?.ToString() ?? string.Empty);
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
        private void PbFiltro_Click(object sender, EventArgs e)
        {
            PlFiltros.Location = new Point(this.Width / 2
                - PlFiltros.Width / 2, this.Height / 2 - PlFiltros.Height / 2);
            PlFiltros.Visible = true;
            PlFiltros.BringToFront();
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarColumnas();
            PlFiltros.Visible = false;
        }
        private void FiltrarColumnas()
        {
            foreach (DataGridViewColumn column in DtLotes.Columns)
            {
                if (filtro.Any(f => column.Name.Contains(f)))
                {
                    column.Visible = false;
                }
                else
                {
                    column.Visible = true;
                }
            }
        }
        private void DtLotes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Verificar si la celda que se TKá pintando es una celda de encabezado
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                // Determinar si la celda es de alguno de los encabezados especificados
                string headerText = DtLotes.Columns[e.ColumnIndex].HeaderText;
                bool isTargetHeader = headerText == "Ticket" ||
                                      headerText == "Fecha Recibido" ||
                                      headerText == "Sacos" ||
                                      headerText == "Peso" ||
                                      headerText == "MTNR" ||
                                      headerText == "Área de Secado" ||
                                      headerText == "Recibidor" ||
                                      headerText == "Calidad" ||
                                      headerText == "Estado Fisico" ||
                                      headerText == "Daño" ||
                                      headerText == "Estado" ||
                                      headerText == "Proceso" ||
                                      headerText == "Consolidado" ||
                                      headerText == "Digitador";

                // Definir los colores y la fuente según el tipo de encabezado
                Color backColor = isTargetHeader ? Color.Green : Color.Blue;
                Color textColor = Color.White;
                Font font = new Font(DtLotes.Font.FontFamily, 10, FontStyle.Bold);

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
        private void CLBFiltros_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string seleccion = CLBFiltros.Items[e.Index].ToString();
            if (e.NewValue == CheckState.Checked)
            {
                filtro.Add(seleccion);
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                filtro.Remove(seleccion);
            }
        }
        private void BtnCerrarFiltro_Click(object sender, EventArgs e)
        {
            PlFiltros.Visible = false;
        }
        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DControlPatio funcion = new DControlPatio();
            funcion.BuscarTkExcel(txtBuscador.Text, ref dt);
            DtLotes.DataSource = dt;
            Base.DiseñoDtvEliminar(ref DtLotes);
        }
    }
}
