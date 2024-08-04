using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
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
    public partial class FrmLotes_Tendido : Form
    {
        DataTable dt2 = new DataTable();
        List<string> filtro = new List<string>();
        string Name;
        public FrmLotes_Tendido(DataTable dt,string Nombre)
        {
            InitializeComponent();
            AdjustFormSize();
            dt2 = dt;
            Name = Nombre;
        }
        private void AdjustFormSize()
        {
            // Tamaño deseado del formulario 1678; 679
            int desiredWidth = 1678;
            int desiredHeight = 679;

            // Obtener tamaño de la pantalla
            Rectangle screenRectangle = Screen.PrimaryScreen.WorkingArea;

            // Ajustar tamaño del formulario
            int newWidth = Math.Min(desiredWidth, screenRectangle.Width);
            int newHeight = Math.Min(desiredHeight, screenRectangle.Height);

            this.Size = new Size(newWidth, newHeight);

            // Centrar el formulario en la pantalla
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void LlenarCheckBoxList()
        {
            // Limpiar el CheckListBox antes de llenarlo
            CLBFiltros.Items.Clear();

            // Llenar el CheckListBox con los encabezados del DataGridView
            foreach (DataGridViewColumn column in DtLotes_Tendido.Columns)
            {
                CLBFiltros.Items.Add(column.HeaderText);
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private async void FrmLotes_Tendido_Load(object sender, EventArgs e)
        {
            PlCarga.Dock = DockStyle.Fill;
            await CargarDatos();
            PlCarga.Visible = false;
        }
        private async Task CargarDatos()
        {
            await Task.Delay(1500);
            MostrarLotes();
            LlenarCheckBoxList();
            await Task.Delay(1000);
        }

        private void MostrarLotes()
        {
            DtLotes_Tendido.DataSource = dt2;
        }

        private void PbExcel_Click(object sender, EventArgs e)
        {
            string fe = Name + DateTime.Now.Day + "_" + DateTime.Today.Month + "_" + DateTime.Today.Year + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;
            SaveExcelFile(DtLotes_Tendido, fe);
        }
        private void ExportToExcel(DataGridView dataGridView, string fileName)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Lotes");

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

        private void BtnCerrarFiltro_Click(object sender, EventArgs e)
        {
            PlFiltros.Visible = false;
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarColumnas();
            PlFiltros.Visible = false;
        }
        private void FiltrarColumnas()
        {
            foreach (DataGridViewColumn column in DtLotes_Tendido.Columns)
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
    }
}
