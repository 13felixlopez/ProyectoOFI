using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoOFI.Datos
{
    public class DReporteTK
    {
        public void ReporteTicket(ref DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("ReporteTicket", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Log.Writeerror("Error al cargar los datos en ReporteTicket " + ex.Message);
            }
        }
        public void BuscarReporteTK(string Buscar, string Dato, ref DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("BuscarReporteTK", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Buscador", Buscar);
                    cmd.Parameters.AddWithValue("@Dato", Dato);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos de BuscarReporteTK " + ex.Message, "Error en Buscar Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("No se pudieron cargar los datos en BuscarReporteTK ✖️✖️ " + ex.Message);
            }
        }
    }
}
