using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOFI.Analisis
{
    public partial class UCMuestras : UserControl
    {
        int ContarBusqueda;
        int desde = 1;
        int hasta = 100;
        // Variables a nivel de clase
        private List<LMuestras> muestrasTemporales = new List<LMuestras>();
        private DataTable dtMuestrasData;

        private DateTimePicker dtPicker = new DateTimePicker();
        private Rectangle _Rectangle;
        public UCMuestras()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Task.Delay(3000);
            BuscarTK();
            //ReiniciarPaginado();
            ActualizarCheckboxesEnDataGridView();
            TxtBuscar.Focus();
        }
        private void BuscarTK()
        {
            DataTable dt = new DataTable();
            DMuestras funcion = new DMuestras();
            funcion.ObtenerMuestras(TxtBuscar.Text, ref dt, ContarBusqueda);
            DtMuestras.DataSource = dt;
            DtMuestras.Columns["FechaMuestra"].ReadOnly = false;
            DtMuestras.Columns["FechaMuestra"].DefaultCellStyle.Format = "dd/MM/yyyy";
            ContarBusqueda = int.Parse(funcion.Contador.ToString());
            DtMuestras.Columns["IdMuestra"].Visible = false;
            // Inicializar la lista temporal con los datos del DataTable
            InicializarListaTemporalDesdeDataTable(dt);
            ActualizarCheckboxesEnDataGridView();
        }

        private void InicializarListaTemporalDesdeDataTable(DataTable dt)
        {
            muestrasTemporales.Clear();

            foreach (DataRow row in dt.Rows)
            {
                // Manejar valores nulos en IdMuestra y Muestriado
                int idMuestra = row["IdMuestra"] != DBNull.Value ? Convert.ToInt32(row["IdMuestra"]) : 0;
                bool muestriado = row["Muestriado"] != DBNull.Value && Convert.ToBoolean(row["Muestriado"]);
                string ticket = row["Ticket"]?.ToString() ?? "";

                // Tomar la fecha desde la tabla si existe
                DateTime fechaMuestra = DateTime.Now;
                if (dt.Columns.Contains("FechaMuestra") && row["FechaMuestra"] != DBNull.Value)
                    fechaMuestra = Convert.ToDateTime(row["FechaMuestra"]);

                // Solo agregar registros que están muestriados
                if (muestriado)
                {
                    muestrasTemporales.Add(new LMuestras
                    {
                        IdMuestra = idMuestra,
                        Ticket = ticket,
                        Muestriado = muestriado,
                        FechaMuestra = fechaMuestra
                    });
                }
            }
        }


        private void DtMuestras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DtMuestras.Columns[e.ColumnIndex].Name == "FechaMuestra")
            {
                _Rectangle = DtMuestras.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                dtPicker.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                dtPicker.Location = new Point(_Rectangle.X, _Rectangle.Y);

                // Mostrar el DateTimePicker con el valor actual
                dtPicker.Visible = true;
                if (DtMuestras.CurrentCell.Value != null && DateTime.TryParse(DtMuestras.CurrentCell.Value.ToString(), out DateTime fecha))
                    dtPicker.Value = fecha;
                else
                    dtPicker.Value = DateTime.Now;
            }
            else
            {
                dtPicker.Visible = false;
            }
        }

        private void ActualizarColorFila(int rowIndex, bool muestriado)
        {
            if (muestriado)
            {
                DtMuestras.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            }
            else
            {
                DtMuestras.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        // Método para el botón Guardar
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Sincronizar cambios desde el DataGridView hacia la lista temporal
                foreach (DataGridViewRow row in DtMuestras.Rows)
                {
                    if (row.IsNewRow) continue;

                    string ticket = row.Cells["Ticket"].Value?.ToString() ?? "";
                    if (string.IsNullOrEmpty(ticket)) continue;

                    bool muestriado = false;
                    if (row.Cells["Muestriado"].Value != null && row.Cells["Muestriado"].Value != DBNull.Value)
                        muestriado = Convert.ToBoolean(row.Cells["Muestriado"].Value);

                    DateTime fechaMuestra = DateTime.Now;
                    if (row.Cells["FechaMuestra"].Value != null && row.Cells["FechaMuestra"].Value != DBNull.Value)
                        fechaMuestra = Convert.ToDateTime(row.Cells["FechaMuestra"].Value);
                    else if (muestriado)
                    {
                        // Si el registro está muestriado pero no tiene fecha, pedimos ingresarla
                        MessageBox.Show($"Debe especificar una fecha de muestra para el ticket: {ticket}",
                                        "Fecha requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int idMuestra = 0;
                    if (row.Cells["IdMuestra"].Value != null && row.Cells["IdMuestra"].Value != DBNull.Value)
                        idMuestra = Convert.ToInt32(row.Cells["IdMuestra"].Value);

                    // Buscar si ya está en la lista temporal
                    var muestraExistente = muestrasTemporales.FirstOrDefault(m => m.Ticket == ticket);

                    if (muestriado)
                    {
                        if (muestraExistente != null)
                        {
                            // Actualizar valores
                            muestraExistente.IdMuestra = idMuestra;
                            muestraExistente.Muestriado = true;
                            muestraExistente.FechaMuestra = fechaMuestra;
                        }
                        else
                        {
                            // Agregar nuevo registro
                            muestrasTemporales.Add(new LMuestras
                            {
                                IdMuestra = idMuestra,
                                Ticket = ticket,
                                Muestriado = true,
                                FechaMuestra = fechaMuestra
                            });
                        }
                    }
                    else
                    {
                        // Si el checkbox fue desactivado, eliminarlo de la lista temporal
                        if (muestraExistente != null)
                            muestrasTemporales.Remove(muestraExistente);
                    }
                }

                // Verificar si hay algo que guardar
                if (muestrasTemporales.Count == 0)
                {
                    MessageBox.Show("No hay cambios para guardar.", "Información",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Guardar en base de datos (inserciones/actualizaciones en lote)
                DMuestras funcion = new DMuestras();
                funcion.GuardarMuestrasEnBD(muestrasTemporales);

                MessageBox.Show("Datos guardados correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar la lista temporal después de guardar
                muestrasTemporales.Clear();

                // Recargar datos para refrescar IdMuestra e información
                BuscarTK();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en BtnGuardar_Click: " + ex.Message);
            }
        }


        private void ActualizarCheckboxesEnDataGridView()
        {
            foreach (DataGridViewRow row in DtMuestras.Rows)
            {
                if (row.IsNewRow) continue;

                string ticket = row.Cells["Ticket"].Value?.ToString() ?? "";
                var muestraEnLista = muestrasTemporales.FirstOrDefault(m => m.Ticket == ticket);

                if (muestraEnLista != null)
                {
                    // Sincronizar el DataGridView con la lista temporal
                    row.Cells["Muestriado"].Value = muestraEnLista.Muestriado;
                    ActualizarColorFila(row.Index, muestraEnLista.Muestriado);
                }
                else
                {
                    // Si no está en la lista temporal, usar el valor de la base de datos manejando nulos
                    object cellValue = row.Cells["Muestriado"].Value;
                    bool muestriadoBD = (cellValue != null && cellValue != DBNull.Value) ? Convert.ToBoolean(cellValue) : false;
                    ActualizarColorFila(row.Index, muestriadoBD);
                }
            }
        }

        private void UCMuestras_Load(object sender, EventArgs e)
        {
            DtMuestras.Controls.Add(dtPicker);
            dtPicker.Visible = false;
            dtPicker.Format = DateTimePickerFormat.Short;
            dtPicker.CloseUp += new EventHandler(dtPicker_CloseUp);
            dtPicker.TextChanged += new EventHandler(dtPicker_OnTextChange);
        }
        private void dtPicker_OnTextChange(object sender, EventArgs e)
        {
            DtMuestras.CurrentCell.Value = dtPicker.Text;
        }

        private void dtPicker_CloseUp(object sender, EventArgs e)
        {
            dtPicker.Visible = false;
        }
    }
}
