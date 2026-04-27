using ProyectoOFI.Logica;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoOFI.Datos
{
    public class DPOA
    {
        public DataTable MostrarPOA()
        {
            DataTable tablaTickets = new DataTable();
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("MostrarPOA", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    tablaTickets.Load(cmd.ExecuteReader());
                    return tablaTickets;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
                Log.Writeerror("No se ha podido cargar los datos en MostrarPOA ✖️✖️ " + ex.Message);
                return tablaTickets;
            }
        }

        public void CargarPOA(string TK, DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("CargarPOA", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TK", TK);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool CargaDirectaSF(LVertical parametros)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("CargaDirectaSF", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                    cmd.Parameters.AddWithValue("@HoradesIn", parametros.HoradesIn);
                    cmd.Parameters.AddWithValue("@HoraFin", parametros.HoraFin);
                    cmd.Parameters.AddWithValue("@Humedad", parametros.Humedad);
                    cmd.Parameters.AddWithValue("@ProcesoSF", parametros.ProcesoSF);
                    cmd.Parameters.AddWithValue("@IdTurno", parametros.TurnoV);
                    cmd.Parameters.AddWithValue("@POA1", parametros.POA1);
                    cmd.Parameters.AddWithValue("@DigitadorSF", parametros.DigitadorV);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Insertar los datos " + ex.Message, "ERROR CargaDirectaSF", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al Insertar los datos en CargaDirectaSF ✖️✖️ " + ex.Message);
                return false;
            }
        }

        public bool InsertarGuardiola(LPOA parametros)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("InsertarGuardiola", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                    cmd.Parameters.AddWithValue("@Guardiola", parametros.Guardiola);
                    cmd.Parameters.AddWithValue("@IdTurno", parametros.IdTurno);
                    cmd.Parameters.AddWithValue("@HoraIniG", parametros.HoraIniG);
                    cmd.Parameters.AddWithValue("@HoraFinG", parametros.HoraFinG);
                    cmd.Parameters.AddWithValue("@DuracionG", parametros.Duracion);
                    cmd.Parameters.AddWithValue("@IdPOA", parametros.IdPOA);
                    cmd.Parameters.AddWithValue("@DigitadorG", parametros.DigitadorG);
                    cmd.Parameters.AddWithValue("@HumedadG", parametros.Humedad);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Cargar Guardiola " + ex.Message, "Error Guardiola", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en InsertarGuardiola ✖️✖️ " + ex.Message);
                return false;
            }
        }

    }
}
