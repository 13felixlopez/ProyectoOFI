using ProyectoOFI.Logica;
using System;
using ProyectoOFI.Datos;
using ExcelDataReader;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOFI.Recepcion
{
    public partial class FrmDatos : Form
    {
        public DataSet dtsTablas = new DataSet();
        private int pageIndex = 0;
        private int pageSize = 20000;
        public FrmDatos()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //configuracion de ventana para seleccionar un archivo
                OpenFileDialog oOpenFileDialog = new OpenFileDialog();
                oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

                if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    cboHojas.Items.Clear();
                    DtLotes.DataSource = null;

                    txtRuta.Text = oOpenFileDialog.FileName;

                    //FileStream nos permite leer, escribir, abrir y cerrar archivos en un sistema de archivos, como matrices de bytes
                    FileStream fsSource = new FileStream(oOpenFileDialog.FileName, FileMode.Open, FileAccess.Read);


                    //ExcelReaderFactory.CreateBinaryReader = formato XLS
                    //ExcelReaderFactory.CreateOpenXmlReader = formato XLSX
                    //ExcelReaderFactory.CreateReader = XLS o XLSX
                    IExcelDataReader reader = ExcelReaderFactory.CreateReader(fsSource);

                    //convierte todas las hojas a un DataSet
                    dtsTablas = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    //obtenemos las tablas y añadimos sus nombres en el desplegable de hojas
                    foreach (DataTable tabla in dtsTablas.Tables)
                    {
                        cboHojas.Items.Add(tabla.TableName);
                    }
                    cboHojas.SelectedIndex = 0;

                    reader.Close();
                    if (txtRuta.Text != "")
                    {
                        btnCargar.Enabled = true;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor cierre el archivo de Excel que quiere cargar al sistema ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            DtLotes.Columns.Clear();
            //await CargarDatosPaginados(pageIndex);
            PCargar.Visible = false;
            PCargar.Size = new Size(77, 48);
            PCargar.Location = new Point(960, 238);
            btnGuardar.Enabled = true;
        }
        private async Task CargarDatosPaginados(int index)
        {
            // Obtener la tabla seleccionada desde el DataSet.
            DataTable tabla = dtsTablas.Tables[cboHojas.SelectedIndex];

            // Limpiar las columnas del DataGridView.
            DtLotes.Columns.Clear();

            int totalRows = tabla.Rows.Count;

            // Calcular el índice de inicio y final para la página actual.
            int startIndex = index * pageSize;
            int endIndex = Math.Min(startIndex + pageSize, totalRows);

            if (startIndex >= 0 && startIndex < totalRows)
            {
                // Crear una vista que contiene la página actual de datos.
                DataTable pagina = tabla.Clone();
                for (int i = startIndex; i < endIndex; i++)
                {
                    DataRow row = tabla.Rows[i];
                    pagina.ImportRow(row);
                }

                // Asignar la vista actual como origen de datos del DataGridView.
                DtLotes.DataSource = pagina;
            }
        }

        private void btnCerrarP_Click(object sender, EventArgs e)
        {
            PCargar.Visible = false;
            PCargar.Size = new Size(77, 48);
            PCargar.Location = new Point(960, 238);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
            PCargar.BringToFront();
            PCargar.Visible = true;
            PCargar.Size = new Size(511, 178);
            PCargar.Location = new Point(this.Width / 2 - PCargar.Width / 2, this.Height / 2 - PCargar.Height / 2);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Insertar();
            //InsertarAsignaturas();
            //ConfigurarDataGridView();
        }
        //private void Insertar()
        //{
        //    try
        //    {
        //        List<LRecepcion> lst = new List<LRecepcion>();
        //        foreach (DataGridViewRow dr in DtLotes.Rows)
        //        {
        //            // Verifica si la fila está en la página actual.
        //            if (!dr.IsNewRow)
        //            {
        //                LRecepcion oConcepto = new LRecepcion();
        //                oConcepto.Ticket = dr.Cells[0].Value.ToString();
        //                oConcepto.FRecibido = DateTime.Parse(dr.Cells[1].Value.ToString());
        //                oConcepto.Area = dr.Cells[2].Value.ToString();
        //                oConcepto.MTNR = dr.Cells[3].Value.ToString();
        //                oConcepto.EstadoFisico= dr.Cells[4].Value.ToString();
        //                oConcepto.Calidad= dr.Cells[5].Value.ToString();
        //                oConcepto.Daño= dr.Cells[6].Value.ToString();
        //                oConcepto.Sacos = int.Parse(dr.Cells[7].Value.ToString());
        //                oConcepto.Peso = double.Parse(dr.Cells[8].Value.ToString());
        //                oConcepto.Merma = double.Parse(dr.Cells[9].Value.ToString());
        //                oConcepto.Recibidor= dr.Cells[10].Value.ToString();
        //                oConcepto.Digitador = "Admin";
        //                oConcepto.Estado = (dr.Cells[11].Value.ToString());

        //                lst.Add(oConcepto);
        //            }
        //        }
        //        LRecepcion parametros = new LRecepcion();
        //        DRecepcion funcion = new DRecepcion();
        //        funcion.Insertar(parametros, lst);
        //        UCProfesores uc = new UCProfesores();
        //        uc.MostrarProfesores();
        //        this.Close();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
