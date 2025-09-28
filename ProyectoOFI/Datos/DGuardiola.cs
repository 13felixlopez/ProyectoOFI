using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoOFI.Datos
{
    public class DGuardiola
    {
        public DataTable MostrarGuardiola()
        {
            DataTable tablaTickets = new DataTable();
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand da = new SqlCommand("MostrarGuardiola", conectar))
                {
                    da.CommandType = CommandType.StoredProcedure;
                    conectar.Open();
                    tablaTickets.Load(da.ExecuteReader());
                    return tablaTickets;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
                Log.Writeerror("No se ha podido cargar los datos en MostrarGuardiola" + ex.Message);
                return tablaTickets;
            }
        }
        public void CargarGuardiola(string TK, DataTable dt)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand da = new SqlCommand("CargarGuardiola", conectar))
                {
                    da.CommandType = CommandType.StoredProcedure;
                    da.Parameters.AddWithValue("@TK", TK);
                    SqlDataAdapter cb = new SqlDataAdapter(da);
                    cb.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("No se pudieron cargar los datos en CargarGuardiola ✖️✖️ " + ex.Message);
            }
        }
    }
}
