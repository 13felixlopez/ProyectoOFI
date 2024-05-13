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
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarLotesCP", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Desde", Desde);
                da.SelectCommand.Parameters.AddWithValue("@Hasta", Hasta);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos " + ex.Message, "ERROR Control Patio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarLotesCP ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void ContarTKCP(ref int Contador)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("select COUNT (ticket) from Recepcion where Estado='ACTIVO' AND IdAreaSecado=1", Conexion.conectar);
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
        #region Tendido
        public bool InsertarTendido(LControlPatio parametros)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("InsertarTendido", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                cmd.Parameters.AddWithValue("@FechaT", parametros.FechaT);
                cmd.Parameters.AddWithValue("@Folio", parametros.Folio);
                cmd.Parameters.AddWithValue("@IdPatio", parametros.IdPatio);
                cmd.Parameters.AddWithValue("@IdUbicacionP", parametros.IdUbicacionP);
                cmd.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Tender el lote " + ex.Message, "ERROR Tendido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en InsertarTendido ✖️✖️ " + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarTendido(LControlPatio parametros, int edit)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarTendido", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                cmd.Parameters.AddWithValue("@FechaT", parametros.FechaT);
                cmd.Parameters.AddWithValue("@Folio", parametros.Folio);
                cmd.Parameters.AddWithValue("@IdPatio", parametros.IdPatio);
                cmd.Parameters.AddWithValue("@IdUbicacionP", parametros.IdUbicacionP);
                cmd.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                cmd.Parameters.AddWithValue("@Edit", edit);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido editar el registro " + ex.Message, "ERROR al actualizar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en EditarTendido ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarDetalleTendido(ref DataTable dt, string Tk)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarDetalleTendido", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Ticket", Tk);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarDetalleTendido ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
        #region MostrarCombos
        public void MostrarPatio(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarPatio", Conexion.conectar);
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
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarPatio ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarPatioUbicacion(ComboBox combo, int IdPatio)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarPatioUbicacion", Conexion.conectar);
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
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarPatioUbicacion ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarAreaSecado(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarAreaSecado", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                combo.ValueMember = "IdAreaSecado";
                combo.DisplayMember = "Area Secado";
                combo.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lista.Add(dt.Rows[i]["Area Secado"].ToString());
                }
                combo.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarAreaSecado ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarEstFis(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarEstFis", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
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
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarEstFis ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
        #region Enfarde
        public bool InsertarEnfarde(LControlPatio parametros)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("InsertarEnfarde", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTendido", parametros.IdTendido);
                cmd.Parameters.AddWithValue("@FEnfarde", parametros.FEnfarde);
                cmd.Parameters.AddWithValue("@DiasSecado", parametros.DiasSecado);
                cmd.Parameters.AddWithValue("@HumedadL", parametros.HumedadL);
                cmd.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                cmd.Parameters.AddWithValue("@SacosEnf", parametros.Sacos);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Enfandar el lote " + ex.Message, "ERROR Enfarde", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en InsertarEnfarde ✖️✖️ " + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarDetalleEnfarde(ref DataTable dt, string Tk)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarDetalleEnfarde", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Ticket", Tk);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarDetalleEnfarde ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarEnfarde(LControlPatio parametros, int edit)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarEnfarde", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdEnfarde", parametros.IdEnfarde);
                cmd.Parameters.AddWithValue("@IdTendido", parametros.IdTendido);
                cmd.Parameters.AddWithValue("@FEnfarde", parametros.FEnfarde);
                cmd.Parameters.AddWithValue("@DiasSecado", parametros.DiasSecado);
                cmd.Parameters.AddWithValue("@HumedadL", parametros.HumedadL);
                cmd.Parameters.AddWithValue("@SacosEnf", parametros.Sacos);
                cmd.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                cmd.Parameters.AddWithValue("@Edit", edit);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido editar el registro " + ex.Message, "ERROR al actualizar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en EditarEnfarde ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
        #region Envio
        public bool InsertarEnvio(LControlPatio parametros)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("InsertarEnvio", Conexion.conectar);
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al Enfandar el lote " + ex.Message, "ERROR Envio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en InsertarEnvio ✖️✖️ " + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarDetalleEnvioCP(ref DataTable dt, string Tk)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarDetalleEnvioCP", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Ticket", Tk);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarDetalleEnvio ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarEnvio(LControlPatio parametros, int edit)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarEnvio", Conexion.conectar);
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
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido editar el registro " + ex.Message, "ERROR al actualizar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en EditarEnvio ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
        #region Buscar
        public void BuscarTKCP(string Buscar, ref DataTable dt, int desde, int hasta, int Contar)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("BuscarTKCP", Conexion.conectar);
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
                Log.Writeerror("Error en BuscarTKCP ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }

        internal void BuscarCalidad(string text, ref DataTable dt, int desde, int hasta, int contarBusqueda)
        {
            throw new NotImplementedException();
        }

        internal void BuscarCert(string text, ref DataTable dt, int desde, int hasta, int contarBusqueda)
        {
            throw new NotImplementedException();
        }

        internal void BuscarDanio(string text, ref DataTable dt, int desde, int hasta, int contarBusqueda)
        {
            throw new NotImplementedException();
        }

        internal void BuscarTipoCompra(string text, ref DataTable dt, int desde, int hasta, int contarBusqueda)
        {
            throw new NotImplementedException();
        }

        internal void BuscarMTNT(string text, ref DataTable dt, int desde, int hasta, int contarBusqueda)
        {
            throw new NotImplementedException();
        }

        internal void BuscarPeso(string text, ref DataTable dt, int desde, int hasta, int contarBusqueda)
        {
            throw new NotImplementedException();
        }

        internal void BuscarAreaSecado(string text, ref DataTable dt, int desde, int hasta, int contarBusqueda)
        {
            throw new NotImplementedException();
        }
        #endregion
        public void LotesExcelCP(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("LotesExcelCP", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos", "Error LotesExcelCP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al cargar los datos en LotesExcelCP ✖️✖️ "+ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }

        internal void BuscarTkExcel(string Buscar, ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("BuscarTkExcelCP", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Buscador", Buscar);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en BuscarExcel ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
    }
}
