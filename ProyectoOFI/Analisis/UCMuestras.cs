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
                object idMuestraValue = row["IdMuestra"];
                int idMuestra = (idMuestraValue != null && idMuestraValue != DBNull.Value) ? Convert.ToInt32(idMuestraValue) : 0;

                object muestriadoValue = row["Muestriado"];
                bool muestriado = (muestriadoValue != null && muestriadoValue != DBNull.Value) ? Convert.ToBoolean(muestriadoValue) : false;

                string ticket = row["Ticket"].ToString() ?? "";

                // Solo agregar a la lista temporal los registros que tienen Muestriado = true
                if (muestriado)
                {
                    muestrasTemporales.Add(new LMuestras
                    {
                        IdMuestra = idMuestra,
                        Ticket = ticket,
                        Muestriado = muestriado,
                        FechaMuestra = DateTime.Now
                    });
                }
            }
        }

        private void DtMuestras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (e.ColumnIndex == DtMuestras.Columns["Muestriado"].Index)
            {
                try
                {
                    // Obtener la fila actual
                    DataGridViewRow row = DtMuestras.Rows[e.RowIndex];

                    // Manejar valores nulos de forma segura
                    bool currentValue = false;
                    if (row.Cells["Muestriado"].Value != null && row.Cells["Muestriado"].Value != DBNull.Value)
                    {
                        currentValue = Convert.ToBoolean(row.Cells["Muestriado"].Value);
                    }

                    // Cambiar el valor
                    bool newValue = !currentValue;
                    row.Cells["Muestriado"].Value = newValue;

                    // Obtener ticket e IdMuestra
                    string ticket = row.Cells["Ticket"].Value?.ToString() ?? "";

                    int idMuestra = 0;
                    if (row.Cells["IdMuestra"].Value != null && row.Cells["IdMuestra"].Value != DBNull.Value)
                    {
                        idMuestra = Convert.ToInt32(row.Cells["IdMuestra"].Value);
                    }

                    // Buscar o agregar a la lista temporal
                    var muestraExistente = muestrasTemporales.FirstOrDefault(m => m.Ticket == ticket);
                    if (muestraExistente != null)
                    {
                        muestraExistente.Muestriado = newValue;
                        muestraExistente.FechaMuestra = DateTime.Now;
                    }
                    else
                    {
                        muestrasTemporales.Add(new LMuestras
                        {
                            IdMuestra = idMuestra,
                            Ticket = ticket,
                            Muestriado = newValue,
                            FechaMuestra = DateTime.Now
                        });
                    }

                    ActualizarColorFila(e.RowIndex, newValue);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al procesar el checkbox: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                if (muestrasTemporales.Count == 0)
                {
                    MessageBox.Show("No hay cambios para guardar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DMuestras funcion = new DMuestras();
                funcion.GuardarMuestrasEnBD(muestrasTemporales);
                MessageBox.Show("Datos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar la lista temporal después de guardar
                muestrasTemporales.Clear();

                // Recargar los datos para actualizar los IdMuestra si hubo INSERTs
                BuscarTK();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en btnGuardar_Click: " + ex.Message);
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
    }
}
