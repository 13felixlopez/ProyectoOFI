using ProyectoOFI.Logica;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoOFI.Datos
{
    public class DControlPatio
    {
        public int contador;

        public void MostrarLotesCP(ref DataTable dt, int Desde, int Hasta)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("MostrarLotesCP", conectar))
                {

                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Desde", Desde);
                    da.SelectCommand.Parameters.AddWithValue("@Hasta", Hasta);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos " + ex.Message, "ERROR Control Patio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarLotesCP ✖️✖️" + ex.Message);
            }
        }
        public void BuscarAreaSecado(ref DataTable dt, string Ticket)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("BuscarAreaSecado", conectar))
                {

                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Ticket", Ticket);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos " + ex.Message, "ERROR Buscar Área Secado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en BuscarAreaSecado ✖️✖️" + ex.Message);
            }
        }
        public void ContarTKCP(ref int Contador)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("select COUNT (ticket) from Recepcion where Estado='ACTIVO' AND IdAreaSecado=1", conectar))
                {

                    Contador = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception)
            {
                Contador = 0;
            }
        }
        #region Tendido
        public bool InsertarTendido(LControlPatio parametros)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("InsertarTendido", conectar))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                    cmd.Parameters.AddWithValue("@FechaT", parametros.FechaT);
                    cmd.Parameters.AddWithValue("@Folio", parametros.Folio);
                    cmd.Parameters.AddWithValue("@IdPatio", parametros.IdPatio);
                    cmd.Parameters.AddWithValue("@IdUbicacionP", parametros.IdUbicacionP);
                    cmd.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                    cmd.Parameters.AddWithValue("@Rechazo", parametros.Rechazos);
                    cmd.Parameters.AddWithValue("@ReTendido", parametros.ReTendido);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Tender el lote " + ex.Message, "ERROR Tendido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en InsertarTendido ✖️✖️ " + ex.Message);
                return false;
            }
        }
        public bool EditarTendido(LControlPatio parametros, int edit)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("EditarTendido", conectar))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                    cmd.Parameters.AddWithValue("@FechaT", parametros.FechaT);
                    cmd.Parameters.AddWithValue("@ReTendido", parametros.ReTendido);
                    cmd.Parameters.AddWithValue("@Folio", parametros.Folio);
                    cmd.Parameters.AddWithValue("@IdPatio", parametros.IdPatio);
                    cmd.Parameters.AddWithValue("@IdUbicacionP", parametros.IdUbicacionP);
                    cmd.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                    cmd.Parameters.AddWithValue("@Edit", edit);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido editar el registro " + ex.Message, "ERROR al actualizar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en EditarTendido ✖️✖️" + ex.Message);
                return false;
            }
        }
        public bool CambioArea(string Ticket, string Area)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("CambioArea", conectar))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ticket", Ticket);
                    cmd.Parameters.AddWithValue("@Area", Area);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido cambiar el área de secado" + ex.Message, "ERROR al cambiar área de secado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en CambioArea ✖️✖️" + ex.Message);
                return false;
            }
        }
        public bool CambioProc(string Ticket, string Proceso)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("CambioProc", conectar))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ticket", Ticket);
                    cmd.Parameters.AddWithValue("@Proceso", Proceso);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido cambiar el proceso" + ex.Message, "ERROR al cambiar el proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en CambioProc ✖️✖️" + ex.Message);
                return false;
            }
        }
        public bool InsertarRetendido(LControlPatio parametros)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("InsertarRetendido", conectar))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                    cmd.Parameters.AddWithValue("@FechaT", parametros.FechaT);
                    cmd.Parameters.AddWithValue("@Folio", parametros.Folio);
                    cmd.Parameters.AddWithValue("@IdPatio", parametros.IdPatio);
                    cmd.Parameters.AddWithValue("@IdUbicacionP", parametros.IdUbicacionP);
                    cmd.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                    cmd.Parameters.AddWithValue("@Rechazos", parametros.Rechazos);
                    cmd.Parameters.AddWithValue("@ReTendido", parametros.ReTendido);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ReTender el lote " + ex.Message, "ERROR ReTendido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en InsertarRetendido ✖️✖️ " + ex.Message);
                return false;
            }
        }
        public void MostrarDetalleTendido(ref DataTable dt, string Tk)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("MostrarDetalleTendido", conectar))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Ticket", Tk);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarDetalleTendido ✖️✖️" + ex.Message);
            }
        }
        public bool EliminarTendido(LControlPatio parametros)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("EliminarTendido", conectar))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdTendido", parametros.IdTendido);
                    cmd.Parameters.AddWithValue("@Usuario", parametros.Digitador);
                    cmd.Parameters.AddWithValue("@ProcesoCP", parametros.ProcesoCP);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("El registro ha sido eliminado.", "Eliminado con éxito ✅", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Eliminar Tendido " + ex.Message, "Error aļ Eliminar Tendido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en EliminarTendido ✖️✖️ " + ex.Message);
                return true;
            }
        }
        #endregion
        #region MostrarCombos
        public void MostrarPatio(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand da = new SqlCommand("MostrarPatio", conectar))
                {

                    da.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter cb = new SqlDataAdapter(da);
                    DataTable dt = new DataTable();
                    cb.Fill(dt);
                    combo.ValueMember = "IdPatio";
                    combo.DisplayMember = "Patio";
                    combo.DataSource = dt;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        lista.Add(dt.Rows[i]["Patio"].ToString());
                    }
                    combo.AutoCompleteCustomSource = lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarPatio ✖️✖️" + ex.Message);
            }
        }
        public void MostrarPatioUbicacion(ComboBox combo, int IdPatio)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand da = new SqlCommand("MostrarPatioUbicacion", conectar))
                {
                    da.CommandType = CommandType.StoredProcedure;
                    da.Parameters.AddWithValue("@Idpatio", IdPatio);
                    SqlDataAdapter cb = new SqlDataAdapter(da);
                    DataTable dt = new DataTable();
                    cb.Fill(dt);
                    combo.ValueMember = "IdUbicacionP";
                    combo.DisplayMember = "UbicacionP";
                    combo.DataSource = dt;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        lista.Add(dt.Rows[i]["UbicacionP"].ToString());
                    }
                    combo.AutoCompleteCustomSource = lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarPatioUbicacion ✖️✖️" + ex.Message);
            }
        }
        public void MostrarAreaSecado(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                string consulta = "Select * from AreaSecado where AreaSecado in ('Almacén','Secado Mecánico')";
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand da = new SqlCommand(consulta, conectar))
                {
                    SqlDataAdapter cb = new SqlDataAdapter(da);
                    DataTable dt = new DataTable();
                    cb.Fill(dt);
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
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarAreaSecado ✖️✖️" + ex.Message);
            }
        }
        public void MostrarEstFis(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                string consulta = "select * from EstFisico where EstFisico in ('Pre-Seco','Seco')";
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand da = new SqlCommand(consulta, conectar))
                {
                    SqlDataAdapter cb = new SqlDataAdapter(da);
                    DataTable dt = new DataTable();
                    cb.Fill(dt);
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
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarEstFis ✖️✖️" + ex.Message);
            }
        }
        #endregion
        #region Enfarde
        public bool InsertarEnfarde(LControlPatio parametros)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("InsertarEnfarde", conectar))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdTendido", parametros.IdTendido);
                    cmd.Parameters.AddWithValue("@FEnfarde", parametros.FEnfarde);
                    cmd.Parameters.AddWithValue("@ReEnfarde", parametros.FReEnfarde);
                    cmd.Parameters.AddWithValue("@DiasSecado", parametros.DiasSecado);
                    cmd.Parameters.AddWithValue("DTotal", parametros.DTotal);
                    cmd.Parameters.AddWithValue("@HumedadL", parametros.HumedadL);
                    cmd.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                    cmd.Parameters.AddWithValue("@SacosEnf", parametros.Sacos);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Enfandar el lote " + ex.Message, "ERROR Enfarde", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en InsertarEnfarde ✖️✖️ " + ex.Message);
                return false;
            }
        }
        public void MostrarDetalleEnfarde(ref DataTable dt, string Tk)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("MostrarDetalleEnfarde", conectar))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Ticket", Tk);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarDetalleEnfarde ✖️✖️" + ex.Message);
            }
        }
        public bool EditarEnfarde(LControlPatio parametros, int edit)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("EditarEnfarde", conectar))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdEnfarde", parametros.IdEnfarde);
                    cmd.Parameters.AddWithValue("@IdTendido", parametros.IdTendido);
                    cmd.Parameters.AddWithValue("@FEnfarde", parametros.FEnfarde);
                    cmd.Parameters.AddWithValue("@ReEnfarde", parametros.FReEnfarde);
                    cmd.Parameters.AddWithValue("@DiasSecado", parametros.DiasSecado);
                    cmd.Parameters.AddWithValue("@DTotal", parametros.DTotal);
                    cmd.Parameters.AddWithValue("@HumedadL", parametros.HumedadL);
                    cmd.Parameters.AddWithValue("@SacosEnf", parametros.Sacos);
                    cmd.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                    cmd.Parameters.AddWithValue("@Edit", edit);
                    cmd.Parameters.AddWithValue("@Rechazos", parametros.Rechazos);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido editar el registro " + ex.Message, "ERROR al actualizar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en EditarEnfarde ✖️✖️" + ex.Message);
                return false;
            }
        }
        public bool InsertarReEnfarde(LControlPatio parametros)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("InsertarReEnfarde", conectar))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdTendido", parametros.IdTendido);
                    cmd.Parameters.AddWithValue("@IdEnfarde", parametros.IdEnfarde);
                    cmd.Parameters.AddWithValue("@ReEnfarde", parametros.FReEnfarde);
                    cmd.Parameters.AddWithValue("@DTotal", parametros.DTotal);
                    cmd.Parameters.AddWithValue("@HumedadL", parametros.HumedadL);
                    cmd.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                    cmd.Parameters.AddWithValue("@SacosEnf", parametros.Sacos);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ReEnfandar el lote " + ex.Message, "ERROR ReEnfarde", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en InsertarReEnfarde ✖️✖️ " + ex.Message);
                return false;
            }
        }
        public bool EliminarEnfarde(LControlPatio parametros)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("EliminarEnfarde", conectar))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdTendido", parametros.IdTendido);
                    cmd.Parameters.AddWithValue("@IdEnfarde", parametros.IdEnfarde);
                    cmd.Parameters.AddWithValue("@Usuario", parametros.Digitador);
                    cmd.Parameters.AddWithValue("@ProcesoCP", parametros.ProcesoCP);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("El registro ha sido eliminado.", "Eliminado con éxito ✅", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Eliminar Enfarde " + ex.Message, "Error aļ Eliminar Enfarde", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en EliminarEnfarde ✖️✖️ " + ex.Message);
                return true;
            }
        }
        #endregion
        #region Envio
        public bool InsertarEnvio(LControlPatio parametros)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("InsertarEnvio", conectar))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdEnfarde", parametros.IdEnfarde);
                    cmd.Parameters.AddWithValue("@FEnvio", parametros.FEnvio);
                    cmd.Parameters.AddWithValue("@DNIN", parametros.DNIN);
                    cmd.Parameters.AddWithValue("@IdEstFis", parametros.IdEstFis);
                    cmd.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                    cmd.Parameters.AddWithValue("@IdAreaSecado", parametros.IdAreaSecado);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Envio el lote " + ex.Message, "ERROR Envio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en InsertarEnvio ✖️✖️ " + ex.Message);
                return false;
            }
        }
        public void MostrarDetalleEnvioCP(ref DataTable dt, string Tk)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("MostrarDetalleEnvioCP", conectar))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Ticket", Tk);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarDetalleEnvio ✖️✖️" + ex.Message);
            }
        }
        public bool EditarEnvio(LControlPatio parametros, int edit)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("EditarEnvio", conectar))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdEnvio", parametros.IdEnvio);
                    cmd.Parameters.AddWithValue("@IdEnfarde", parametros.IdEnfarde);
                    cmd.Parameters.AddWithValue("@FEnvio", parametros.FEnvio);
                    cmd.Parameters.AddWithValue("@DNIN", parametros.DNIN);
                    cmd.Parameters.AddWithValue("@IdEstFis", parametros.IdEstFis);
                    cmd.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                    cmd.Parameters.AddWithValue("@IdAreaSecado", parametros.IdAreaSecado);
                    cmd.Parameters.AddWithValue("@Edit", edit);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido editar el registro " + ex.Message, "ERROR al actualizar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en EditarEnvio ✖️✖️" + ex.Message);
                return false;
            }
        }
        public bool EliminarEnvio(LControlPatio parametros)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("EliminarEnvioCP", conectar))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdTendido", parametros.IdTendido);
                    cmd.Parameters.AddWithValue("@IdEnvio", parametros.IdEnvio);
                    cmd.Parameters.AddWithValue("@Usuario", parametros.Digitador);
                    cmd.Parameters.AddWithValue("@ProcesoCP", parametros.ProcesoCP);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("El registro ha sido eliminado.", "Eliminado con éxito ✅", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Eliminar Envio " + ex.Message, "Error aļ Eliminar Envio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en EliminarEnvio ✖️✖️ " + ex.Message);
                return true;
            }
        }
        #endregion
        #region Buscar
        public void BuscarTKCP(string Buscar, ref DataTable dt, int desde, int hasta, int Contar, string Dato)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("BuscarTKCP", conectar))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Desde", desde);
                    cmd.Parameters.AddWithValue("@Hasta", hasta);
                    cmd.Parameters.AddWithValue("@Buscador", Buscar);
                    cmd.Parameters.AddWithValue("@Dato", Dato);

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en BuscarTKCP ✖️✖️" + ex.Message);
            }
        }
        internal void BuscarFechaCP(ref DataTable dt, DateTime FInicio, DateTime FFin, int desde, int hasta, int Contar)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("BuscarFechaCP", conectar))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Desde", desde);
                    cmd.Parameters.AddWithValue("@Hasta", hasta);
                    cmd.Parameters.AddWithValue("@FInicio", FInicio);
                    cmd.Parameters.AddWithValue("@FFin", FFin);
                    SqlParameter contarparam = new SqlParameter("@Contar", SqlDbType.Int);
                    contarparam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(contarparam);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    Contar = Convert.ToInt32(contarparam.Value);
                    contador = Contar;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en BuscarFechaCP ✖️✖️" + ex.Message);
            }
        }
        #endregion
        public void LotesExcelCP(ref DataTable dt)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("LotesExcelCP", conectar))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos", "Error LotesExcelCP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al cargar los datos en LotesExcelCP ✖️✖️ " + ex.Message);
            }
        }

        internal void BuscarTkExcel(string Buscar, ref DataTable dt)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("BuscarTkExcelCP", conectar))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Buscador", Buscar);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en BuscarExcel ✖️✖️" + ex.Message);
            }
        }
        public void LotesRechazos(ref DataTable dt)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("LotesRechazados", conectar))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos", "Error en Lotes Rechazados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al cargar los datos en lotesRechazados ✖️✖️" + ex.Message);
            }
        }

        public void BuscarTKCP2(string Buscar, ref DataTable dt, int desde, int hasta, int Contar)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("BuscarTKCP2", conectar))
                {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en BuscarTKCP2 ✖️✖️" + ex.Message);
            }
        }
        public (string Proceso, string ProcesoCP) MostrarProceso(string Ticket)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("MostrarProceso", conectar))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ticket", Ticket);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string proceso = reader["Proceso"].ToString();
                            string procesoCP = reader["ProcesoCP"].ToString();
                            return (proceso, procesoCP);
                        }
                        else
                        {
                            throw new Exception("No se encontraron datos para el ticket proporcionado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los resultados", "Error en MostrarProceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al cargar datos en MostrarProceso ✖️✖️ " + ex.Message);
                // Puedes retornar valores predeterminados en caso de error si lo deseas
                return (string.Empty, string.Empty);
            }
        }
        public bool InsertarSNPreSeco(LSNPreSeco parametros)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("InsertarSNPreSeco", conectar))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdTendido", parametros.IdTendido);
                    cmd.Parameters.AddWithValue("@InicioPreseco", parametros.InicioPreseco);
                    cmd.Parameters.AddWithValue("@HumedadPreseco", parametros.HumedadPreseco);
                    cmd.Parameters.AddWithValue("@CantSacos", parametros.CantSacos);
                    cmd.Parameters.AddWithValue("@Usuario", parametros.Usuario);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Writeerror("Error en InsertarSNPreSeco ✖️✖️ " + ex.Message);
                MessageBox.Show("Ne se logó insertar el registro Preseco " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        internal void MostrarDetallePreseco(ref DataTable dt, int idTendido)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("MostrarDetallePreseco", conectar))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@IdTendido", idTendido);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarDetallePreseco ✖️✖️" + ex.Message);
            }
        }
    }
}
