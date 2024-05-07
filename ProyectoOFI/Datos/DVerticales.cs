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
    }
}
