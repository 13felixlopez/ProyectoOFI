using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
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
    public partial class CUReporteTK : UserControl
    {
        List<string> filtro = new List<string>();
        public CUReporteTK()
        {
            InitializeComponent();
           // ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }

        private async void CUReporteTK_Load(object sender, EventArgs e)
        {
            await CargarDatos();
            //Base.DiseñoDtv(ref DtDatos);
            //Base.DiseñoDtvEliminar(ref DtDatos);
        }

        private void ReporteTicket()
        {
            DReporteTK funcion = new DReporteTK();
            DataTable dt = new DataTable();
            funcion.ReporteTicket(ref dt);
            DtDatos.DataSource = dt;
        }

        private async void PBrefrescar_Click(object sender, EventArgs e)
        {
            await CargarDatos();
            ReiniciarFiltros();
            this.Refresh();
        }
        private void ReiniciarFiltros()
        {
            for (int i = 0; i < CLBFiltros.Items.Count; i++)
            {
                // Deselecciona el elemento en la posición i
                CLBFiltros.SetItemChecked(i, false);
            }
            FiltrarColumnas();
        }
        private async Task CargarDatos()
        {
            PlCarga.Visible = true;
            PlCarga.Dock = DockStyle.Fill;
            await Task.Delay(1500);
            ReporteTicket();
            //ReiniciarPaginado();
            await Task.Delay(1000);
            PlCarga.Visible = false;
        }

        private void PbExcel_Click(object sender, EventArgs e)
        {
            string fe = "Reporte Ticket " + DateTime.Now.Day + "_" + DateTime.Today.Month + "_" + DateTime.Today.Year + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;
            SaveExcelFile(DtDatos, fe);
        }
        private void ExportToExcel(DataGridView dataGridView, string fileName)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Reporte_TK");

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
            foreach (DataGridViewColumn column in DtDatos.Columns)
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

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            PlFiltros.Visible = false;
        }

        private void CbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            DRecepcion funcion = new DRecepcion();
            if (CbBuscar.Text == "Ticket" || CbBuscar.Text == "MTNR" || CbBuscar.Text == "Peso" || CbBuscar.Text == "Ticket Hijo")
            {
                CbBuscador.Text = "";
                PlFiltroFecha.Visible = false;
                txtBuscador.Visible = true;
                CbBuscador.Visible = false;
            }
            else if (CbBuscar.Text == "Calidad")
            {
                TextBuscarVisible();
                funcion.MostrarCalidad(CbBuscador);
            }
            else if (CbBuscar.Text == "Certificación")
            {
                TextBuscarVisible();
                funcion.MostrarCert(CbBuscador);
            }
            else if (CbBuscar.Text == "Daño")
            {
                TextBuscarVisible();
                funcion.MostrarDaño(CbBuscador);
            }
            else if (CbBuscar.Text == "Tipo Compra")
            {
                TextBuscarVisible();
                funcion.MostrarCompra(CbBuscador);
            }
            else if (CbBuscar.Text == "Área Secado")
            {
                TextBuscarVisible();
                funcion.MostrarAreaSecado(CbBuscador);
            }
        }
        private void TextBuscarVisible()
        {
            txtBuscador.Clear();
            txtBuscador.Visible = false;
            CbBuscador.Visible = true;
            CbBuscador.DataSource = null;
            CbBuscador.SelectedIndex = -1;
            PlFiltroFecha.Visible = false;
        }
        private void BuscarDato()
        {
            DReporteTK funcion = new DReporteTK();
            DataTable dt = new DataTable();
            funcion.BuscarReporteTK(CbBuscador.Text, CbBuscar.Text, ref dt);
            DtDatos.DataSource = dt;
        }
        private void BuscarTK()
        {
            DReporteTK funcion = new DReporteTK();
            DataTable dt = new DataTable();
            funcion.BuscarReporteTK(txtBuscador.Text, CbBuscar.Text, ref dt);
            DtDatos.DataSource = dt;
        }
        private void CbBuscador_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscarDato();
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            BuscarTK();
        }
    }
}
