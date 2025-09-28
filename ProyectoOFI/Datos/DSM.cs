using ProyectoOFI.Logica;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoOFI.Datos
{
    public class DSM
    {
        public int contador;
        //Variables
        public string TV1, TV2, TV3, TV4, TV5, TV6, TV7, TV8;

        public void MostrarSM(ref DataTable dt, int Desde, int Hasta)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("MostrarSM", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Desde", Desde);
                    da.SelectCommand.Parameters.AddWithValue("@Hasta", Hasta);
                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["Proceso"].ToString() == "No Asignado")
                            dr["ProcesoSM"] = "";
                        else if (dr["ProcesoSM"] == DBNull.Value)
                            dr["ProcesoSM"] = "Carga Directa SF";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar datos de SM: " + ex.Message,
                    "Error MostrarSM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarSM ✖️✖️ " + ex.Message);
            }
        }

        public DataTable MostrarTV()
        {
            var tablaTickets = new DataTable();
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("MostrarTV", con))
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
                MessageBox.Show("Error al mostrar Tickets TV: " + ex.Message,
                    "Error MostrarTV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarTV ✖️✖️ " + ex.Message);
            }
            return tablaTickets;
        }

        public void CargarTV(string TK, DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("CargarTV", con))
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
                MessageBox.Show("Error al cargar TV: " + ex.Message,
                    "Error CargarTV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en CargarTV ✖️✖️ " + ex.Message);
            }
        }

        public void CargarTk(ComboBox combo)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("MostrarTkV", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        combo.DataSource = dt;
                        combo.ValueMember = "Ticket";
                        combo.DisplayMember = "Ticket";
                        combo.SelectedIndex = -1;

                        AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                        foreach (DataRow row in dt.Rows)
                            lista.Add(row["Ticket"].ToString());

                        combo.AutoCompleteCustomSource = lista;
                        combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        combo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Tickets: " + ex.Message,
                    "Error CargarTk", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en CargarTk ✖️✖️ " + ex.Message);
            }
        }

        public void MostrarDatosTKSM(Label sacos, Label kilos, Label QQS, Label calidad, Label daño,
                                     Label esfisico, Label FRecibido, Label Cert, string TK)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("MostrarDatosTKSM", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TK", TK);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            var row = dt.Rows[0];
                            sacos.Text = row["Sacos"].ToString();
                            kilos.Text = row["Peso"].ToString();

                            if (double.TryParse(kilos.Text, out double peso))
                                QQS.Text = Math.Round(peso / 46, 2).ToString();

                            calidad.Text = row["Calidad"].ToString();
                            daño.Text = row["Danio"].ToString();
                            esfisico.Text = row["Estado Fisico"].ToString();
                            FRecibido.Text = row["FRecibido"].ToString();
                            Cert.Text = row["Certificacion"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron datos para el Ticket especificado.",
                                "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar datos de TKSM: " + ex.Message,
                    "Error MostrarDatosTKSM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarDatosTKSM ✖️✖️ " + ex.Message);
            }
        }
        public void MostrarOperador(ComboBox combo)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("MostrarOperadores", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        combo.DataSource = dt;
                        combo.ValueMember = "IdOperador";
                        combo.DisplayMember = "Nombre";
                        combo.SelectedIndex = -1;

                        AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                        foreach (DataRow row in dt.Rows)
                            lista.Add(row["Nombre"].ToString());

                        combo.AutoCompleteCustomSource = lista;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar operadores: " + ex.Message,
                    "Error Operadores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarOperador ✖️✖️ " + ex.Message);
            }
        }

        public void MostrarTurno(ComboBox combo)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("MostrarTurno", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        combo.DataSource = dt;
                        combo.ValueMember = "IdTurnos";
                        combo.DisplayMember = "Turno";
                        combo.SelectedIndex = -1;

                        AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                        foreach (DataRow row in dt.Rows)
                            lista.Add(row["Turno"].ToString());

                        combo.AutoCompleteCustomSource = lista;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar turnos: " + ex.Message,
                    "Error Turnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarTurno ✖️✖️ " + ex.Message);
            }
        }

        public void VerDetalleTkSM(ref DataTable dt, string Tk)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("VerDetalleTkSM", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Ticket", Tk);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar detalle TKSM: " + ex.Message,
                    "Error VerDetalleTkSM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en VerDetalleTkSM ✖️✖️ " + ex.Message);
            }
        }

        public void VerPOAV(ref DataTable dt, string TK)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("VerPOAV", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Ticket", TK);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar POAV: " + ex.Message,
                    "Error VerPOAV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en VerPOAV ✖️✖️ " + ex.Message);
            }
        }

        public void VerEnvioSM(ref DataTable dt, string TK)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("VerEnvioSM", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Ticket", TK);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar datos de EnvioSM: " + ex.Message,
                    "Error VerEnvioSM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en VerEnvioSM ✖️✖️ " + ex.Message);
            }
        }

        public void VerGuardiola(ref DataTable dt, string TK)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("VerGuardiola", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Ticket", TK);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar datos de Guardiola: " + ex.Message,
                    "Error VerGuardiola", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en VerGuardiola ✖️✖️ " + ex.Message);
            }
        }
        public void VerPS(ref DataTable dt, string TK)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("VerPS", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Ticket", TK);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar datos de PS: " + ex.Message,
                    "Error PS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en VerPS ✖️✖️ " + ex.Message);
            }
        }

        public void ContarTK(ref int Contador)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(Ticket) " +
                    "FROM Recepcion " +
                    "INNER JOIN AreaSecado AS ASe ON Recepcion.IdAreaSecado = ASe.IdAreaSecado " +
                    "WHERE Estado='ACTIVO' AND AreaSecado='Secado Mecánico' " +
                    "AND Cosecha=(SELECT Cosecha FROM Cosecha WHERE IdCosecha=(SELECT MAX(IdCosecha) FROM Cosecha))",
                    con))
                {
                    Contador = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch
            {
                Contador = 0;
            }
        }

        public void VerVertical(ref DataTable dt, string ticket)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("VerVertical", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Ticket", ticket);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar datos de Vertical: " + ex.Message,
                    "Error VerVertical", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en VerVertical ✖️✖️ " + ex.Message);
            }
        }

        internal void VerPreSecado(ref DataTable dt, string ticket, Label LblG1, Label LblG2)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("VerPreSecado", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Ticket", ticket);
                    da.Fill(dt);

                    if (dt.Rows.Count == 2)
                    {
                        LblG1.Text = dt.Rows[0]["POA"].ToString();
                        LblG2.Text = dt.Rows[1]["POA"].ToString();
                    }
                    else if (dt.Rows.Count == 1)
                    {
                        LblG1.Text = dt.Rows[0]["POA"].ToString();
                        LblG2.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar datos de PreSecado: " + ex.Message,
                    "Error VerPreSecado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en VerPreSecado ✖️✖️ " + ex.Message);
            }
        }

        public void BuscarTKSM(string Buscar, ref DataTable dt, int desde, int hasta, int Contar, string Dato)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("BuscarTKSM", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Desde", desde);
                    cmd.Parameters.AddWithValue("@Hasta", hasta);
                    cmd.Parameters.AddWithValue("@Buscador", Buscar);
                    cmd.Parameters.AddWithValue("@Dato", Dato);

                    SqlParameter contarParam = new SqlParameter("@Contar", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(contarParam);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);

                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["Proceso"].ToString() == "No Asignado")
                                dr["ProcesoSM"] = "";
                            else if (dr["ProcesoSM"] == DBNull.Value)
                                dr["ProcesoSM"] = "Carga Directa SF";
                        }
                    }

                    Contar = Convert.ToInt32(contarParam.Value);
                    contador = Contar;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar TKSM: " + ex.Message,
                    "Error BuscarTKSM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en BuscarTKSM ✖️✖️ " + ex.Message);
            }
        }
        public bool ParticionSM(LVertical parametros)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("ParticionSM", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                    cmd.Parameters.AddWithValue("@FechaCar", parametros.FechaDes);
                    cmd.Parameters.AddWithValue("@HoradesIn", parametros.HoradesIn);
                    cmd.Parameters.AddWithValue("@HoraFin", parametros.HoraFin);
                    cmd.Parameters.AddWithValue("@Humedad", parametros.Humedad);
                    cmd.Parameters.AddWithValue("@ProcesoSF", parametros.ProcesoSF);
                    cmd.Parameters.AddWithValue("@IdTurno", parametros.TurnoV);
                    cmd.Parameters.AddWithValue("@POA1", parametros.POA1);
                    cmd.Parameters.AddWithValue("@POA2", parametros.POA2);
                    cmd.Parameters.AddWithValue("@DigitadorSF", parametros.DigitadorV);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar datos en ParticionSM: " + ex.Message,
                    "ERROR ParticionSM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en ParticionSM ✖️✖️ " + ex.Message);
                return false;
            }
        }

        public void ExcelSM(ref DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("ExcelSM", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de ExcelSM: " + ex.Message,
                    "Error ExcelSM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en ExcelSM ✖️✖️ " + ex.Message);
            }
        }

        public void ProcesoSM(ComboBox combo)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT ProcesoSM FROM POAV", con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    combo.DataSource = dt;
                    combo.ValueMember = "ProcesoSM";
                    combo.DisplayMember = "ProcesoSM";
                    combo.SelectedIndex = -1;

                    AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                    foreach (DataRow row in dt.Rows)
                        lista.Add(row["ProcesoSM"].ToString());

                    combo.AutoCompleteCustomSource = lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar datos de ProcesoSM: " + ex.Message,
                    "ERROR ProcesoSM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en ProcesoSM ✖️✖️ " + ex.Message);
            }
        }

        internal void BuscarFechaSM(ref DataTable dt, DateTime FInicio, DateTime FFin, int desde, int hasta, int Contar)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("BuscarFechaSM", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Desde", desde);
                    cmd.Parameters.AddWithValue("@Hasta", hasta);
                    cmd.Parameters.AddWithValue("@FInicio", FInicio);
                    cmd.Parameters.AddWithValue("@FFin", FFin);

                    SqlParameter contarparam = new SqlParameter("@Contar", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(contarparam);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }

                    Contar = Convert.ToInt32(contarparam.Value);
                    contador = Contar;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar datos en SM: " + ex.Message,
                    "Error BuscarFechaSM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en BuscarFechaSM ✖️✖️ " + ex.Message);
            }
        }

    }
}
