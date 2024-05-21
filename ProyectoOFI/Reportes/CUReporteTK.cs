using OfficeOpenXml;
using ProyectoOFI.Datos;
using System;
using System.Collections.Generic;
using System.Data;
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
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
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
            DtExcel(DtDatos, fe);
        }
        private void DtExcel(DataGridView grd, string nombreArchivo)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx|Todos los archivos (*.*)|*.*";
                saveFileDialog.FileName = nombreArchivo + ".xlsx";

                try
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        using (var package = new ExcelPackage())
                        {
                            var worksheet = package.Workbook.Worksheets.Add("Data");

                            // Encabezados de columnas
                            int ic = 1;
                            foreach (DataGridViewColumn column in grd.Columns)
                            {
                                if (column.Visible) // Check if the column is visible
                                {
                                    worksheet.Cells[1, ic].Value = column.HeaderText;
                                    worksheet.Cells[1, ic].Style.Font.Size = 16;
                                    worksheet.Cells[1, ic].Style.Font.Bold = true;
                                    ic++;
                                }
                            }

                            int IR = 2;
                            foreach (DataGridViewRow row in grd.Rows)
                            {
                                int colIndex = 0;
                                for (int col = 0; col < grd.Columns.Count; col++)
                                {
                                    DataGridViewColumn column = grd.Columns[col];
                                    if (column.Visible) // Check if the column is visible
                                    {
                                        worksheet.Cells[IR, colIndex + 1].Value = row.Cells[col].Value?.ToString();
                                        colIndex++;
                                    }
                                }
                                IR++;
                            }

                            // Guardar el archivo
                            package.SaveAs(new FileInfo(filePath));
                        }

                        MessageBox.Show("Datos exportados exitosamente a Excel", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Prompt user to open the file
                        if (MessageBox.Show("¿Desea abrir el archivo exportado?", "Abrir Archivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(filePath);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
    }
}
