using OfficeOpenXml;
using ProyectoOFI.Datos;
using ProyectoOFI.Otros;
using System;
using System.Collections.Generic;
using System.Data;
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
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
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
            DtExcel(DtLotes, fe);
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
