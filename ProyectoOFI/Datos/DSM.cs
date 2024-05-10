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
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarSM", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Desde", Desde);
                da.SelectCommand.Parameters.AddWithValue("@Hasta", Hasta);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    // Verificar si Proceso es "No Asignado" y asignar un valor vacío a ProcesoSM
                    if (dr["Proceso"].ToString() == "No Asignado")
                    {
                        dr["ProcesoSM"] = "";
                    }
                    // Verificar si ProcesoSM es null y cambiarlo por "Carga Directa SF"
                    else if (dr["ProcesoSM"] == DBNull.Value)
                    {
                        dr["ProcesoSM"] = "Carga Directa SF";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarSM ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public DataTable MostrarTV()
        {
            DataTable tablaTickets = new DataTable();
            try
            {
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarTV", Conexion.conectar);
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
        public void CargarTV(string TK, DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlCommand da = new SqlCommand("CargarTV", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@Ticket", TK);
                SqlDataAdapter cb = new SqlDataAdapter(da);
                cb.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void CargarTk(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("MostrarTkV", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter cb = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                combo.ValueMember = "Ticket";
                combo.DisplayMember = "Ticket";
                combo.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lista.Add(dt.Rows[i]["Ticket"].ToString());
                }
                combo.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarDatosTKSM(Label sacos, Label kilos, Label QQS, Label calidad, Label daño, Label esfisico, Label FRecibido, string TK)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarDatosTKSM", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@TK", TK);
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                sacos.Text = dt.Rows[0]["Sacos"].ToString();
                kilos.Text = dt.Rows[0]["Peso"].ToString();
                double QQs = double.Parse(kilos.Text);
                QQs = QQs / 46;
                QQS.Text = Math.Round(QQs, 2).ToString();
                calidad.Text = dt.Rows[0]["Calidad"].ToString();
                daño.Text = dt.Rows[0]["Danio"].ToString();
                esfisico.Text = dt.Rows[0]["Estado Fisico"].ToString();
                FRecibido.Text = dt.Rows[0]["FRecibido"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error " + ex.Message, "Error mostrar datos DSM", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarOperador(ComboBox combo)
        {
            try
            {
                Conexion.abrir();
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarOperadores", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                combo.ValueMember = "IdOperador";
                combo.DisplayMember = "Nombre";
                combo.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lista.Add(dt.Rows[i]["Nombre"].ToString());
                }
                combo.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los operadores " + ex.Message, "ERROR Operadores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al cargar los operadores, MostrarOperador ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void VerDetalleTkSM(ref DataTable dt, string Tk)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("VerDetalleTkSM", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Ticket", Tk);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en VerDetalleTkSM ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void VerPOAV(ref DataTable dt, string TK)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("VerPOAV", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Ticket", TK);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en VerPOAV ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void ContarTK(ref int Contador)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("select COUNT (Ticket) from Recepcion INNER JOIN AreaSecado AS ASe ON Recepcion.IdAreaSecado = ASe.IdAreaSecado where " +
                    "Estado='ACTIVO' AND AreaSecado='Secado Mecánico'", Conexion.conectar);
                Contador = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                Contador = 0;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void VerVertical(ref DataTable dt, string ticket)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("VerVertical", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Ticket", ticket);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en VerVertical ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        internal void VerPreSecado(ref DataTable dt, string ticket,Label LblG1,Label LblG2)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("VerPreSecado", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Ticket", ticket);
                da.Fill(dt);

                if (dt.Rows.Count == 2)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        string resultado = dr["POA"].ToString();
                        if (resultado.EndsWith("-Parte1"))
                        {
                            LblG1.Text = resultado;
                        }
                        else if (resultado.EndsWith("-Parte2"))
                        {
                            LblG2.Text = resultado;
                        }
                    }
                }
                else if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];
                    string resultado = dr["POA"].ToString();
                    if (resultado.EndsWith("-Parte1"))
                    {
                        LblG1.Text = resultado;
                    }
                    else if (resultado.EndsWith("-Parte2"))
                    {
                        LblG2.Text = resultado;
                    }
                    LblG1.Text = resultado;
                    // Si solo hay un resultado, el otro Label quedará sin cambio
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en VerPreSecado ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void BuscarTKSM(string Buscar, ref DataTable dt, int desde, int hasta, int Contar)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("BuscarTKSM", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Desde", desde);
                cmd.Parameters.AddWithValue("@Hasta", hasta);
                cmd.Parameters.AddWithValue("@Buscador", Buscar);

                // Parámetro de salida para el contador
                SqlParameter contarParam = new SqlParameter("@Contar", SqlDbType.Int);
                contarParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(contarParam);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                // Obtener el valor del contador
                Contar = Convert.ToInt32(contarParam.Value);
                contador = Contar;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en BuscarTKSM ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
    }
}
