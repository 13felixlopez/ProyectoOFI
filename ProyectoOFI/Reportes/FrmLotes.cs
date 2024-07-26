using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using OfficeOpenXml;
using ProyectoOFI.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOFI.Reportes
{
    public partial class FrmLotes : Form
    {
        List<string> filtro = new List<string>();
        public FrmLotes()
        {
            InitializeComponent();
        }
        private async Task No_Asignado()
        {
            DataTable dt = new DataTable();
            DReporte funcion = new DReporte();
            await Task.Run(() => funcion.No_Asignado(ref dt));

            // Actualizar el DataGridView en el hilo principal
            Invoke(new Action(() =>
            {
                DtLotes.SuspendLayout();
                DtLotes.DataSource = dt;
                DtLotes.ResumeLayout();
            }));
        }

        private void BtnCerrar_Click(object sender, System.EventArgs e)
        {
            Dispose();
        }

        private async void FrmLotes_Load(object sender, System.EventArgs e)
        {
            PlCarga.Dock = DockStyle.Fill;
            await No_Asignado();
            PlCarga.Visible = false;
        }

        private void PbExcel_Click(object sender, EventArgs e)
        {
            string fe = "Lotes No Asignados " + DateTime.Now.Day + "_" + DateTime.Today.Month + "_" + DateTime.Today.Year + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;
            //DtExcel(DtLotes, fe);
            SaveExcelFile(DtLotes, fe);
        }
        //private void DtExcel(DataGridView grd, string nombreArchivo)
        //{
        //    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        //    {
        //        saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx|Todos los archivos (*.*)|*.*";
        //        saveFileDialog.FileName = nombreArchivo + ".xlsx";

        //        try
        //        {
        //            if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //            {
        //                string filePath = saveFileDialog.FileName;

        //                using (var package = new ExcelPackage())
        //                {
        //                    var worksheet = package.Workbook.Worksheets.Add("Data");

        //                    // Encabezados de columnas
        //                    int ic = 1;
        //                    foreach (DataGridViewColumn column in grd.Columns)
        //                    {
        //                        if (column.Visible) // Check if the column is visible
        //                        {
        //                            worksheet.Cells[1, ic].Value = column.HeaderText;
        //                            worksheet.Cells[1, ic].Style.Font.Size = 16;
        //                            worksheet.Cells[1, ic].Style.Font.Bold = true;
        //                            ic++;
        //                        }
        //                    }

        //                    int IR = 2;
        //                    foreach (DataGridViewRow row in grd.Rows)
        //                    {
        //                        int colIndex = 0;
        //                        for (int col = 0; col < grd.Columns.Count; col++)
        //                        {
        //                            DataGridViewColumn column = grd.Columns[col];
        //                            if (column.Visible) // Check if the column is visible
        //                            {
        //                                worksheet.Cells[IR, colIndex + 1].Value = row.Cells[col].Value?.ToString();
        //                                colIndex++;
        //                            }
        //                        }
        //                        IR++;
        //                    }

        //                    // Guardar el archivo
        //                    package.SaveAs(new FileInfo(filePath));
        //                }

        //                MessageBox.Show("Datos exportados exitosamente a Excel", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //                // Prompt user to open the file
        //                if (MessageBox.Show("¿Desea abrir el archivo exportado?", "Abrir Archivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //                {
        //                    System.Diagnostics.Process.Start(filePath);
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //}
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
    }
}
