using ProyectoOFI.Logica;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoOFI.Datos
{
    public class DPS
    {
        public DataTable MostrarPS()
        {
            DataTable tablaTickets = new DataTable();
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("MostrarPS", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    tablaTickets.Load(cmd.ExecuteReader());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
                Log.Writeerror("No se ha podido cargar los datos en MostrarPS ✖️✖️ " + ex.Message);
            }
            return tablaTickets;
        }

        public void BuscarLotesPS(string Ticket, ref DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("BuscarLotesPS", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ticket", Ticket);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en BuscarLotesPS ✖️✖️ " + ex.Message);
            }
        }

        public void MostrarLotesPS2(ref DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("MostrarLotesPS2", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarLotesPS2 ✖️✖️ " + ex.Message);
            }
        }

        public bool InsertarPS(LPS parametros)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("InsertarPS", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdGuardiola", parametros.IdGuardiola);
                    cmd.Parameters.AddWithValue("@PS", parametros.PS);
                    cmd.Parameters.AddWithValue("@HoraIniPS", parametros.HoraIniPS);
                    cmd.Parameters.AddWithValue("@HoraFinPS", parametros.HoraFinPS);
                    cmd.Parameters.AddWithValue("@HumedadPS", parametros.HumedadPS);
                    cmd.Parameters.AddWithValue("@ParosPS", parametros.ParosPS);
                    cmd.Parameters.AddWithValue("@ObservacionSF", parametros.Observacion);
                    cmd.Parameters.AddWithValue("@TiempoSF", parametros.TiempoSF);
                    cmd.Parameters.AddWithValue("@TiempoTotal", parametros.TiempoTotal);
                    // cmd.Parameters.AddWithValue("@IdOperador", parametros.IdOperador);
                    cmd.Parameters.AddWithValue("@IdTurno", parametros.IdTurno);
                    cmd.Parameters.AddWithValue("@DigitadorPS", parametros.DigitadorPS);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Insertar los datos: " + ex.Message, "ERROR InsertarPS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al Insertar los datos en InsertarPS ✖️✖️ " + ex.Message);
                return false;
            }
        }

        public void CargarPS(string TK, DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("CargarPS", con))
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
                MessageBox.Show("No se pudieron cargar los datos: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("No se pudieron cargar los datos en CargarPS ✖️✖️ " + ex.Message);
            }
        }

        public bool InsertarEnvioSM(LPS parametros, int IDPS)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("InsertarEnvioSM", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPS", parametros.IdPS);
                    //cmd.Parameters.AddWithValue("@IdOperador", parametros.IdOperador);
                    cmd.Parameters.AddWithValue("@IdTurno", parametros.IdTurno);
                    cmd.Parameters.AddWithValue("@FechaEn", parametros.FechaPS);
                    cmd.Parameters.AddWithValue("@DigitadorPS", parametros.DigitadorPS);
                    cmd.Parameters.AddWithValue("@DNIN", parametros.DNIN);
                    cmd.Parameters.AddWithValue("@IdArea", parametros.IdArea);
                    cmd.Parameters.AddWithValue("@IdEstFis", parametros.IdEstFis);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar el Envio hacia Almacén: " + ex.Message, "Error Envio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en InsertarEnvioSM ✖️✖️ " + ex.Message);
                return false;
            }
        }

        public void MostrarAreaSecado(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();

                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("SELECT IdAreaSecado, AreaSecado FROM AreaSecado WHERE IdAreaSecado IN (3)", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        combo.ValueMember = "IdAreaSecado";
                        combo.DisplayMember = "AreaSecado";
                        combo.DataSource = dt;

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            lista.Add(dt.Rows[i]["AreaSecado"].ToString());
                        }

                        combo.AutoCompleteCustomSource = lista;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarAreaSecado ✖️✖️ " + ex.Message);
            }
        }

        public void MostrarEstFis(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();

                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("SELECT IdestFis, EstFisico FROM EstFisico WHERE IdestFis IN (3,5)", con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        combo.ValueMember = "IdestFis";
                        combo.DisplayMember = "EstFisico";
                        combo.DataSource = dt;

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            lista.Add(dt.Rows[i]["EstFisico"].ToString());
                        }

                        combo.AutoCompleteCustomSource = lista;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarEstFis ✖️✖️ " + ex.Message);
            }
        }

        public bool InsertarTF(string TK)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("InsertarTF", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ticket", TK);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo Enviar a Tolvas Finales: " + ex.Message, "ERROR TF", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en InsertarTF ✖️✖️ " + ex.Message);
                return false;
            }
        }

        public void MostrarTF(ref DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("MostrarTF", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos en MostrarTF: " + ex.Message, "Error MostrarTF", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en cargar datos en MostrarTF ✖️✖️ " + ex.Message);
            }
        }

        public void DetalleTF(string TK, ref DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("DetalleTF", con))
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
                MessageBox.Show("Error en cargar los datos de Ticket: " + ex.Message, "Error Detalle TF", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en mostrar los datos en DetalleTF ✖️✖️ " + ex.Message);
            }
        }

        public bool ReProceso(string TK, double Humedad, int POA)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("ReProceso", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ticket", TK);
                    cmd.Parameters.AddWithValue("@POA1", POA);
                    cmd.Parameters.AddWithValue("@HumedadG", Humedad);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron insertar los datos ReProceso: " + ex.Message, "Error ReProceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("No se insertaron los datos de ReProceso ✖️✖️ " + ex.Message);
                return false;
            }
        }

        public bool CambioAEnvio(string Ticket, string TK)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("CambioAEnvio", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ticket", TK);
                    cmd.Parameters.AddWithValue("@TKSM", Ticket);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar el cambio de proceso: " + ex.Message, "Error CambioAEnvio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en CambioAEnvio ✖️✖️ " + ex.Message);
                return false;
            }
        }

    }
}
