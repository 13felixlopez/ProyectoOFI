using ExcelDataReader.Log;
using ProyectoOFI.Logica;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoOFI.Datos
{
    internal class DVerticales
    {
        public void CargarTk(ComboBox cb)
        {
            Conexion.abrir();
            SqlCommand cmd = new SqlCommand("MostrarTkV", Conexion.conectar);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb.Items.Add(dr["Ticket"].ToString());
            }
            cb.SelectedItem = 0;
            Conexion.cerrar();
        }
        public bool InsertarVertical(LVertical parametros)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_Vertical", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDV", parametros.IDV);
                cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                cmd.Parameters.AddWithValue("@Ver", parametros.Ver);
                cmd.Parameters.AddWithValue("@OperadorV", parametros.OperadorV);
                cmd.Parameters.AddWithValue("@TurnoV", parametros.TurnoV);
                cmd.Parameters.AddWithValue("@FRecibidoV", parametros.FRecibidoV);
                cmd.Parameters.AddWithValue("@HrInicioV", parametros.HrInicoV);
                cmd.Parameters.AddWithValue("@HrFin", parametros.HrFin);
                cmd.Parameters.AddWithValue("@Duracion", parametros.Duracion);
                cmd.Parameters.AddWithValue("@DigitadorV", parametros.DigitadorV);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
                Log.Writeerror("Error al Insertar los datos en InsertarVertical ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public DataTable MostrarV()
        {
            DataTable tablaTickets = new DataTable();
            try
            {
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarV", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                tablaTickets.Load(da.ExecuteReader());
                return tablaTickets;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
                return tablaTickets;
                //MessageBox.Show("No se ha podido cargar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        internal void CargarVer(string TK, DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlCommand da = new SqlCommand("CargaVer", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@Ticket", TK);
                SqlDataAdapter cb = new SqlDataAdapter(da);
                cb.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("No se pudieron cargar los datos en CargarVer ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarParos(CheckedListBox checkListBox)
        {
            try
            {
                Conexion.abrir(); // Suponiendo que esto abre la conexión a la base de datos

                // Crear un DataTable para almacenar los datos
                DataTable dt = new DataTable();

                // Crear el SqlDataAdapter con el nombre del procedimiento almacenado
                SqlDataAdapter da = new SqlDataAdapter("MostrarParo", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Llenar el DataTable con los datos del SqlDataAdapter
                da.Fill(dt);

                // Limpiar el CheckListBox antes de cargar nuevos datos
                checkListBox.Items.Clear();

                // Recorrer el DataTable y agregar los elementos al CheckListBox
                foreach (DataRow row in dt.Rows)
                {
                    checkListBox.Items.Add(row["Paros"].ToString()); // Reemplaza "Nombre" por el nombre de la columna que deseas mostrar
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al MostrarParo ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar(); // Suponiendo que esto cierra la conexión a la base de datos
            }

        }
        public bool InsertarPreSecado(LVertical parametros)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("InsertarPreSecado", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDV", parametros.IDV);
                cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                cmd.Parameters.AddWithValue("@FechaDes", parametros.FechaDes);
                cmd.Parameters.AddWithValue("@HoradesIn", parametros.HoradesIn);
                cmd.Parameters.AddWithValue("@HoraFin", parametros.HoraFin);
                cmd.Parameters.AddWithValue("@Humedad", parametros.Humedad);
                cmd.Parameters.AddWithValue("@Paros", parametros.Paros);
                cmd.Parameters.AddWithValue("@Observacion", parametros.Observacion);
                cmd.Parameters.AddWithValue("@Total", parametros.Total);
                cmd.Parameters.AddWithValue("@ProcesoSF", parametros.ProcesoSF);
                cmd.Parameters.AddWithValue("@IdOperador", parametros.OperadorV);
                cmd.Parameters.AddWithValue("@IdTurno", parametros.TurnoV);
                cmd.Parameters.AddWithValue("@POA1", parametros.POA1);
                cmd.Parameters.AddWithValue("POA2", parametros.POA2);
                cmd.Parameters.AddWithValue("@DigitadorSF", parametros.DigitadorV);
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Insertar los datos " + ex.Message, "ERROR Pre-Secado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al Insertar los datos en InsertarPreSecado ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
    }
}
