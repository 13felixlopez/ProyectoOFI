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
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("MostrarTkV", con))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    cb.Items.Clear();
                    while (dr.Read())
                    {
                        cb.Items.Add(dr["Ticket"].ToString());
                    }

                    if (cb.Items.Count > 0)
                        cb.SelectedIndex = 0; // ✅ corrige SelectedItem = 0
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los Tickets: " + ex.Message,
                                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en CargarTk ✖️✖️ " + ex.Message);
            }
        }

        public bool InsertarVertical(LVertical parametros)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("Insertar_Vertical", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDV", parametros.IDV);
                    cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                    cmd.Parameters.AddWithValue("@Ver", parametros.Ver);
                    cmd.Parameters.AddWithValue("@TurnoV", parametros.TurnoV);
                    cmd.Parameters.AddWithValue("@HrInicioV", parametros.HrInicoV);
                    cmd.Parameters.AddWithValue("@HrFin", parametros.HrFin);
                    cmd.Parameters.AddWithValue("@Duracion", parametros.Duracion);
                    cmd.Parameters.AddWithValue("@DigitadorV", parametros.DigitadorV);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar Vertical: " + ex.Message,
                                "ERROR InsertarVertical", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en InsertarVertical ✖️✖️ " + ex.Message);
                return false;
            }
        }

        public DataTable MostrarV()
        {
            DataTable tablaTickets = new DataTable();
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("MostrarV", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        tablaTickets.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar V: " + ex.Message,
                                "ERROR MostrarV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarV ✖️✖️ " + ex.Message);
            }
            return tablaTickets;
        }

        internal void CargarVer(string TK, DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("CargaVer", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ticket", TK);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos: " + ex.Message,
                                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en CargarVer ✖️✖️ " + ex.Message);
            }
        }

        public void MostrarParos(CheckedListBox checkListBox)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("MostrarParo", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    checkListBox.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        checkListBox.Items.Add(row["Paros"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos: " + ex.Message,
                                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarParos ✖️✖️ " + ex.Message);
            }
        }

        public bool InsertarPreSecado(LVertical parametros)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("InsertarPreSecado", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDV", parametros.IDV);
                    cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                    cmd.Parameters.AddWithValue("@HoradesIn", parametros.HoradesIn);
                    cmd.Parameters.AddWithValue("@HoraFin", parametros.HoraFin);
                    cmd.Parameters.AddWithValue("@Humedad", parametros.Humedad);
                    cmd.Parameters.AddWithValue("@Paros", parametros.Paros);
                    cmd.Parameters.AddWithValue("@Observacion", parametros.Observacion);
                    cmd.Parameters.AddWithValue("@Total", parametros.Total);
                    cmd.Parameters.AddWithValue("@ProcesoSF", parametros.ProcesoSF);
                    cmd.Parameters.AddWithValue("@IdTurno", parametros.TurnoV);
                    cmd.Parameters.AddWithValue("@POA1", parametros.POA1);
                    cmd.Parameters.AddWithValue("POA2", parametros.POA2);
                    cmd.Parameters.AddWithValue("@DigitadorSF", parametros.DigitadorV);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar los datos: " + ex.Message,
                                "ERROR Pre-Secado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en InsertarPreSecado ✖️✖️ " + ex.Message);
                return false;
            }
        }

    }
}
