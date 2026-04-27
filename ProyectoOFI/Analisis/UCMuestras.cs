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

        string Area = "control patio";
        public UCMuestras()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Task.Delay(3000);
            BuscarTK();
            //ReiniciarPaginado();
            //ActualizarCheckboxesEnDataGridView();
            TxtBuscar.Focus();
        }
        private void BuscarTK()
        {
            DataTable dt = new DataTable();
            DMuestras funcion = new DMuestras();
            funcion.ObtenerMuestras(TxtBuscar.Text, ref dt, ContarBusqueda, Area);
            DtMuestras.DataSource = dt;

            DtMuestras.Columns["FechaMuestra"].ReadOnly = false;
            DtMuestras.Columns["FechaMuestra"].DefaultCellStyle.Format = "dd/MM/yyyy";
            DtMuestras.Columns["IdMuestra"].Visible = false;

            ContarBusqueda = int.Parse(funcion.Contador.ToString());

            // ❌ Quita esta línea (ya no se precarga la lista temporal)
            // InicializarListaTemporalDesdeDataTable(dt);

            //ActualizarCheckboxesEnDataGridView();
        }

        private void DtMuestras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // ✅ Cuando el usuario cambia el checkbox de Muestriado
            if (DtMuestras.Columns[e.ColumnIndex].Name == "Muestriado")
            {
                try
                {
                    var row = DtMuestras.Rows[e.RowIndex];

                    // Estado actual
                    bool currentValue = row.Cells["Muestriado"].Value != DBNull.Value &&
                                        Convert.ToBoolean(row.Cells["Muestriado"].Value);

                    // Cambiar valor
                    bool newValue = !currentValue;
                    row.Cells["Muestriado"].Value = newValue;

                    // Datos base
                    string ticket = row.Cells["Ticket"].Value?.ToString() ?? "";
                    int idMuestra = row.Cells["IdMuestra"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["IdMuestra"].Value) : 0;

                    DateTime fechaMuestra = DateTime.Now;
                    if (row.Cells["FechaMuestra"].Value != DBNull.Value && row.Cells["FechaMuestra"].Value != null)
                        fechaMuestra = Convert.ToDateTime(row.Cells["FechaMuestra"].Value);

                    // Buscar si ya está en la lista temporal
                    var muestra = muestrasTemporales.FirstOrDefault(m => m.Ticket == ticket);

                    if (muestra == null)
                    {
                        // Nuevo cambio (activado o desactivado)
                        muestrasTemporales.Add(new LMuestras
                        {
                            IdMuestra = idMuestra,
                            Ticket = ticket,
                            Muestriado = newValue,
                            FechaMuestra = fechaMuestra
                        });
                    }
                    else
                    {
                        // Ya existía → actualizar su estado
                        muestra.Muestriado = newValue;
                        muestra.FechaMuestra = fechaMuestra;
                    }

                    // Colorear fila según el nuevo estado
                    //ActualizarColorFila(e.RowIndex, newValue);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al procesar el checkbox: {ex.Message}", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // ✅ Control de fecha (sin cambios)
            else if (DtMuestras.Columns[e.ColumnIndex].Name == "FechaMuestra")
            {
                _Rectangle = DtMuestras.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                dtPicker.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                dtPicker.Location = new Point(_Rectangle.X, _Rectangle.Y);
                dtPicker.Visible = true;

                if (DtMuestras.CurrentCell.Value != null &&
                    DateTime.TryParse(DtMuestras.CurrentCell.Value.ToString(), out DateTime fecha))
                    dtPicker.Value = fecha;
                else
                    dtPicker.Value = DateTime.Now;
            }
            else
            {
                dtPicker.Visible = false;
            }
        }


        // Método para el botón Guardar
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (muestrasTemporales.Count == 0)
                {
                    MessageBox.Show("No hay cambios para guardar.", "Información",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DMuestras funcion = new DMuestras();
                funcion.GuardarMuestrasEnBD(muestrasTemporales);

                MessageBox.Show("Cambios guardados correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                muestrasTemporales.Clear();
                BuscarTK();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en BtnGuardar_Click: " + ex.Message);
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

        private void BtnSN_Click(object sender, EventArgs e)
        {
            Area = "control patio";
            BtnSN.Enabled = false;
            BtnSM.Enabled = true;
        }

        private void BtnSM_Click(object sender, EventArgs e)
        {
            Area = "Secado Mecánico";
            BtnSM.Enabled = false;
            BtnSN.Enabled = true;
        }
    }
}
