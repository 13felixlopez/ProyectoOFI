using ProyectoOFI.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace ProyectoOFI.Datos
{
    public class DRecepcion
    {
        public int contador;
        public bool InsertarLote2(LRecepcion parametros, LEnvio parametro)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("InsertarLote", Conexion.conectar)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                cmd.Parameters.AddWithValue("@FechaRecibido", parametros.FRecibido);
                cmd.Parameters.AddWithValue("@Patio", parametros.Patio);
                cmd.Parameters.AddWithValue("@AreaSecado", parametros.IdArea);
                cmd.Parameters.AddWithValue("@MTNR", parametros.MTNR);
                cmd.Parameters.AddWithValue("@EstadoFisico", parametros.IdEstFis);
                cmd.Parameters.AddWithValue("@Calidad", parametros.IdCalidad);
                cmd.Parameters.AddWithValue("@Danio", parametros.IdDaño);
                cmd.Parameters.AddWithValue("@Sacos", parametros.Sacos);
                cmd.Parameters.AddWithValue("@Peso", parametros.Peso);
                cmd.Parameters.AddWithValue("@Merma", parametros.Merma);
                cmd.Parameters.AddWithValue("@Recibidor", parametros.IdRecibidor);
                cmd.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                cmd.Parameters.AddWithValue("@Consolidado", parametros.Consolidado);
                cmd.Parameters.AddWithValue("@Cosecha", parametros.Cosecha);
                //Envio
                cmd.Parameters.AddWithValue("@IDEnvio", parametro.IDEnvio);
                cmd.Parameters.AddWithValue("@TicketE", parametros.Ticket);
                cmd.Parameters.AddWithValue("@FEnvio", parametro.FEnvio);
                cmd.Parameters.AddWithValue("@IdAgencia", parametro.IdAgencia);
                cmd.Parameters.AddWithValue("@IdAcopio", parametro.IdAcopio);
                cmd.Parameters.AddWithValue("@IdCliente", parametro.IdCliente);
                cmd.Parameters.AddWithValue("@MTNT", parametro.MTNT);
                cmd.Parameters.AddWithValue("@Tipo_Compra", parametro.IdTCompra);
                cmd.Parameters.AddWithValue("@IdCertificacion", parametro.IdCertificacionE);
                cmd.Parameters.AddWithValue("@EsFisico", parametro.IdEsFisico);
                cmd.Parameters.AddWithValue("@CalidadE", parametro.IdCalidadE);
                cmd.Parameters.AddWithValue("@DanioE", parametro.IdDanioE);
                cmd.Parameters.AddWithValue("@SacosE", parametro.SacosE);
                cmd.Parameters.AddWithValue("@PesoE", parametro.PesoE);
                cmd.Parameters.AddWithValue("@Tally", parametro.Tally);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Registro realizado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en InsertarLote ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarLote(ref DataTable dt, int desde, int hasta)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarLotes", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Desde", desde);
                da.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarLotes ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarDetalle(ref DataTable dt, string Tk)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarDetalle", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Ticket", Tk);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarDetalle ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EliminarTK(LRecepcion parametros)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarTK", Conexion.conectar)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TK", parametros.Ticket);
                cmd.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                cmd.ExecuteNonQuery();
                MessageBox.Show("La Ticket= " + parametros.Ticket + " Ha sido eliminada.", "Eliminado con éxito ✅", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR DRecepcion", "El elemento no ha sido eliminado " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en EliminarTK ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarSacosPeso(string Tk,double peso,double pesoe,int sacos,int sacose)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarSacosPeso", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ticket", Tk);
                cmd.Parameters.AddWithValue("@Sacos", sacos);
                cmd.Parameters.AddWithValue("@Peso", peso);
                //Envio
                cmd.Parameters.AddWithValue("@SacosE", sacose);
                cmd.Parameters.AddWithValue("@PesoE", pesoe);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido editar el registro " + ex.Message, "ERROR al actualizar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en EditarSacosPeso ✖️✖️" + ex.Message);
                return false;
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
                SqlCommand cmd = new SqlCommand("select COUNT (Rec.Ticket) from Recepcion as Rec " +
                    "where Estado='ACTIVO' " +
                    "AND Cosecha=(select Cosecha from Cosecha where IdCosecha=(select max(IdCosecha) from Cosecha))", Conexion.conectar);
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
        public void ContarTKCP(ref int Contador)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(Rec.Ticket) FROM Recepcion AS Rec" +
                    " LEFT JOIN AreaSecado AS ASe ON Rec.IdAreaSecado = ASe.IdAreaSecado " +
                    "LEFT JOIN Tendido AS T ON Rec.Ticket = T.Ticket " +
                    "WHERE Rec.Estado = 'ACTIVO' AND (ASe.AreaSecado = 'Control Patio' OR T.ProcesoCP != '')" +
                    "AND Rec.Cosecha = (SELECT Cosecha FROM Cosecha " +
                    "WHERE IdCosecha = (SELECT MAX(IdCosecha) FROM Cosecha))\r\n", Conexion.conectar);
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
        public void BuscarTK(string Buscar, ref DataTable dt, int desde, int hasta, int Contar)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("BuscarTK", Conexion.conectar);
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
                Log.Writeerror("Error en BuscarTK ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        internal void BuscarrangoFecha(ref DataTable dt, DateTime FInicio, DateTime FFin, int desde, int hasta, int Contar)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("BuscarrangoFecha", Conexion.conectar);
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
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en BuscarrangoFecha ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarTK(LRecepcion parametros, LEnvio par, string TicketAnteriror)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarTK", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TicketAnterior", TicketAnteriror);
                cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                cmd.Parameters.AddWithValue("@FechaRecibido", parametros.FRecibido);
                cmd.Parameters.AddWithValue("@Patio", parametros.Patio);
                cmd.Parameters.AddWithValue("@AreaSecado", parametros.IdArea);
                cmd.Parameters.AddWithValue("@MTNR", parametros.MTNR);
                cmd.Parameters.AddWithValue("@EstadoFisico", parametros.IdEstFis);
                cmd.Parameters.AddWithValue("@Calidad", parametros.IdCalidad);
                cmd.Parameters.AddWithValue("@Danio", parametros.IdDaño);
                cmd.Parameters.AddWithValue("@Sacos", parametros.Sacos);
                cmd.Parameters.AddWithValue("@Peso", parametros.Peso);
                cmd.Parameters.AddWithValue("@Merma", parametros.Merma);
                cmd.Parameters.AddWithValue("@Recibidor", parametros.IdRecibidor);
                cmd.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                cmd.Parameters.AddWithValue("@ContadorEdit", parametros.ContadorEdit);
                cmd.Parameters.AddWithValue("@Proceso", parametros.Proceso);
                //Envio
                cmd.Parameters.AddWithValue("@FEnvio", par.FEnvio);
                cmd.Parameters.AddWithValue("@IdAgencia", par.IdAgencia);
                cmd.Parameters.AddWithValue("@IdAcopio", par.IdAcopio);
                cmd.Parameters.AddWithValue("@IdCliente", par.IdCliente);
                cmd.Parameters.AddWithValue("@MTNT", par.MTNT);
                cmd.Parameters.AddWithValue("@Tipo_Compra", par.IdTCompra);
                cmd.Parameters.AddWithValue("@IdCertificacion", par.IdCertificacionE);
                cmd.Parameters.AddWithValue("@EsFisico", par.IdEsFisico);
                cmd.Parameters.AddWithValue("@CalidadE", par.IdCalidadE);
                cmd.Parameters.AddWithValue("@DanioE", par.IdDanioE);
                cmd.Parameters.AddWithValue("@SacosE", par.SacosE);
                cmd.Parameters.AddWithValue("@PesoE", par.PesoE);
                cmd.Parameters.AddWithValue("@Tally", par.Tally);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido editar el registro " + ex.Message, "ERROR al actualizar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en EditarTK ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool Consolidar(LRecepcion parametros, LEnvio Par, List<string> lstcons, string folio, string proceso)
        {
            try
            {
                var dt = new DataTable();
                dt.Columns.Add("Id");
                dt.Columns.Add("TicketH");
                int i = 1;
                foreach (string ticket in lstcons)
                {
                    if (ticket != null)
                    {
                        DataRow row = dt.NewRow();  // Crear una nueva fila
                        row["Id"] = i;  // Establecer el valor del Id en la fila actual
                        row["TicketH"] = ticket;  // Establecer el valor del TicketH en la fila actual
                        dt.Rows.Add(row);  // Agregar la fila al DataTable
                        i++; // Incrementar el contador de Id
                    }
                }

                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("Consolidar", Conexion.conectar);
                var paramertlist = new SqlParameter("@lstCons", SqlDbType.Structured);
                paramertlist.TypeName = "Con";
                paramertlist.Value = dt;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(paramertlist);
                cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                cmd.Parameters.AddWithValue("@sacos", parametros.Sacos);
                cmd.Parameters.AddWithValue("@Peso", parametros.Peso);
                cmd.Parameters.AddWithValue("@PesoE", Par.PesoE);
                cmd.Parameters.AddWithValue("@Merma", parametros.Merma);
                cmd.Parameters.AddWithValue("@Calidad", parametros.Calidad);
                cmd.Parameters.AddWithValue("@IdCertificacion", Par.IdCertificacionE);
                cmd.Parameters.AddWithValue("@EstFisico", parametros.EstadoFisico);
                cmd.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                cmd.Parameters.AddWithValue("@FRecibido", parametros.FRecibido);
                cmd.Parameters.AddWithValue("@Danio", parametros.Daño);
                cmd.Parameters.AddWithValue("@Patio", parametros.Patio);
                cmd.Parameters.AddWithValue("@AreaSecado", parametros.IdArea);
                cmd.Parameters.AddWithValue("@Estado", "ACTIVO");
                cmd.Parameters.AddWithValue("@Folio", folio);
                cmd.Parameters.AddWithValue("@Proceso", proceso);
                cmd.Parameters.AddWithValue("@Consolidado", "Si");
                cmd.Parameters.AddWithValue("@ContadorEdit", 0);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ups! Ha ocurrido un error al agregar el Consolidado por favor revise los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Log.Writeerror("Error en Consolidar ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool Consolidar2(LRecepcion parametros, LEnvio Par, List<string> lstcons, string folio)
        {
            try
            {
                var dt = new DataTable();
                dt.Columns.Add("Id");
                dt.Columns.Add("TicketH");
                int i = 1;
                foreach (string ticket in lstcons)
                {
                    if (ticket != null)
                    {
                        DataRow row = dt.NewRow();  // Crear una nueva fila
                        row["Id"] = i;  // Establecer el valor del Id en la fila actual
                        row["TicketH"] = ticket;  // Establecer el valor del TicketH en la fila actual
                        dt.Rows.Add(row);  // Agregar la fila al DataTable
                        i++; // Incrementar el contador de Id
                    }
                }

                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("Consolidar2", Conexion.conectar);
                var paramertlist = new SqlParameter("@lstCons", SqlDbType.Structured);
                paramertlist.TypeName = "Con";
                paramertlist.Value = dt;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(paramertlist);
                cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                cmd.Parameters.AddWithValue("@sacos", parametros.Sacos);
                cmd.Parameters.AddWithValue("@Peso", parametros.Peso);
                cmd.Parameters.AddWithValue("@Calidad", parametros.Calidad);
                cmd.Parameters.AddWithValue("@IdCertificacion", Par.IdCertificacionE);
                cmd.Parameters.AddWithValue("@EstFisico", parametros.EstadoFisico);
                cmd.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                cmd.Parameters.AddWithValue("@FRecibido", parametros.FRecibido);
                cmd.Parameters.AddWithValue("@Danio", parametros.Daño);
                cmd.Parameters.AddWithValue("@AreaSecado", parametros.IdArea);
                cmd.Parameters.AddWithValue("@Estado", "ACTIVO");
                cmd.Parameters.AddWithValue("@Folio", folio);
                cmd.Parameters.AddWithValue("@Consolidado", "Si");
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ups! Ha ocurrido un error al agregar el Consolidado por favor revise los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Log.Writeerror("Error en Consolidar ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        //public void BuscarFecha(DateTime Inicio, DateTime Fin, ref DataTable dt)
        //{
        //    try
        //    {
        //        Conexion.abrir();
        //        SqlDataAdapter da = new SqlDataAdapter("BuscarrangoFecha", Conexion.conectar);
        //        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        da.SelectCommand.Parameters.AddWithValue("@Inicio", Inicio);
        //        da.SelectCommand.Parameters.AddWithValue("@Fin", Fin);
        //        da.Fill(dt);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Ocurrió un error al cargar los datos " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        Log.Writeerror("Error en BuscarrangoFecha ✖️✖️" + ex.Message);
        //    }
        //    finally
        //    {
        //        Conexion.cerrar();
        //    }
        //}
        #region Mostrar
        public void MostrarAcopioAgencia(ComboBox combo, int IdAgencia)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarAcopioAgencia", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@IdAgencia", IdAgencia);
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                combo.ValueMember = "IdAcopio";
                combo.DisplayMember = "Acopio";
                combo.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lista.Add(dt.Rows[i]["Acopio"].ToString());
                }
                combo.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarAcopioAgencia ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarTKConsolidar(ref DataTable dt, LRecepcion parametros, LEnvio par)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarTKConsolidar", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Calidad", parametros.Calidad);
                da.SelectCommand.Parameters.AddWithValue("@Cert", par.CertificacionE);
                da.SelectCommand.Parameters.AddWithValue("@EsFi", parametros.EstadoFisico);
                da.SelectCommand.Parameters.AddWithValue("@Danio", parametros.Daño);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarTKConsolidar ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarAgencia(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarAgencias", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                combo.ValueMember = "IdAgencia";
                combo.DisplayMember = "Agencia";
                combo.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lista.Add(dt.Rows[i]["Agencia"].ToString());
                }
                combo.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarAgencias ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarRecibidor(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarRecibidor", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                combo.ValueMember = "IdRecibidor";
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
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarRecibidor ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarCliente(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarCliente", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                combo.ValueMember = "Idcliente";
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
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarClientes ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarCompra(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarCompra", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                combo.ValueMember = "IdCompra";
                combo.DisplayMember = "Compra";
                combo.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lista.Add(dt.Rows[i]["Compra"].ToString());
                }
                combo.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarCompra ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarCert(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarCertificacion", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                combo.ValueMember = "IdCert";
                combo.DisplayMember = "Certificacion";
                combo.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lista.Add(dt.Rows[i]["Certificacion"].ToString());
                }
                combo.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarCertificación ✖️✖️" + ex.Message);
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
                //SqlCommand da = new SqlCommand("SELECT IdestFis, EstFisico FROM EstFisico WHERE IdestFis IN (3,4,5)", Conexion.conectar);
                SqlCommand da = new SqlCommand("SELECT IdestFis, EstFisico FROM EstFisico", Conexion.conectar);
                da.CommandType = CommandType.Text;
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
        public void MostrarCalidadUA(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("Select * from Calidad where Calidad Like '%' + 'UA'", Conexion.conectar);
                da.CommandType = CommandType.Text;
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                combo.ValueMember = "IdCalidad";
                combo.DisplayMember = "Calidad";
                combo.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lista.Add(dt.Rows[i]["Calidad"].ToString());
                }
                combo.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarCalidad ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarCalidad(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("Select * from Calidad where Calidad NOT Like '%' + 'UA'", Conexion.conectar);
                da.CommandType = CommandType.Text;
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                combo.ValueMember = "IdCalidad";
                combo.DisplayMember = "Calidad";
                combo.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lista.Add(dt.Rows[i]["Calidad"].ToString());
                }
                combo.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarCalidad ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarDaño(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarDanio", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                combo.ValueMember = "IdDanio";
                combo.DisplayMember = "Daño";
                combo.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lista.Add(dt.Rows[i]["Daño"].ToString());
                }
                combo.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarDanio ✖️✖️" + ex.Message);
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
        public void MostrarAreaSecado2(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("select IdAreaSecado,AreaSecado from AreaSecado where IdAreaSecado IN (1,2,6)", Conexion.conectar);
                da.CommandType = CommandType.Text;
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
        public void MostrarLotesExcel(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarLotesExcel", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarLotesExcel ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
        #region Buscadores
        public void BuscarTkExcel(string Buscar, ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("BuscarTkExcel", Conexion.conectar);
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
        #region metodos no usados
        //public void BuscarCalidad(string Buscar, ref DataTable dt, int desde, int hasta, int Contar)
        //{
        //    try
        //    {
        //        Conexion.abrir();
        //        SqlCommand cmd = new SqlCommand("BuscarCalidad", Conexion.conectar);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Desde", desde);
        //        cmd.Parameters.AddWithValue("@Hasta", hasta);
        //        cmd.Parameters.AddWithValue("@Buscador", Buscar);

        //        // Parámetro de salida para el contador
        //        SqlParameter contarParam = new SqlParameter("@Contar", SqlDbType.Int);
        //        contarParam.Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add(contarParam);

        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(dt);

        //        // Obtener el valor del contador
        //        Contar = Convert.ToInt32(contarParam.Value);
        //        contador = Contar;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Ocurrió un error al cargar los datos " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        Log.Writeerror("Error en BuscarCalidad ✖️✖️" + ex.Message);
        //    }
        //    finally
        //    {
        //        Conexion.cerrar();
        //    }
        //}
        //public void BuscarCert(string Buscar, ref DataTable dt, int desde, int hasta, int Contar)
        //{
        //    try
        //    {
        //        Conexion.abrir();
        //        SqlCommand cmd = new SqlCommand("BuscarCert", Conexion.conectar);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Desde", desde);
        //        cmd.Parameters.AddWithValue("@Hasta", hasta);
        //        cmd.Parameters.AddWithValue("@Buscador", Buscar);

        //        // Parámetro de salida para el contador
        //        SqlParameter contarParam = new SqlParameter("@Contar", SqlDbType.Int);
        //        contarParam.Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add(contarParam);

        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(dt);

        //        // Obtener el valor del contador
        //        Contar = Convert.ToInt32(contarParam.Value);
        //        contador = Contar;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Ocurrió un error al cargar los datos " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        Log.Writeerror("Error en BuscarCert ✖️✖️" + ex.Message);
        //    }
        //    finally
        //    {
        //        Conexion.cerrar();
        //    }
        //}
        //public void BuscarDanio(string Buscar, ref DataTable dt, int desde, int hasta, int Contar)
        //{
        //    try
        //    {
        //        Conexion.abrir();
        //        SqlCommand cmd = new SqlCommand("BuscarDanio", Conexion.conectar);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Desde", desde);
        //        cmd.Parameters.AddWithValue("@Hasta", hasta);
        //        cmd.Parameters.AddWithValue("@Buscador", Buscar);

        //        // Parámetro de salida para el contador
        //        SqlParameter contarParam = new SqlParameter("@Contar", SqlDbType.Int);
        //        contarParam.Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add(contarParam);

        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(dt);

        //        // Obtener el valor del contador
        //        Contar = Convert.ToInt32(contarParam.Value);
        //        contador = Contar;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Ocurrió un error al cargar los datos " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        Log.Writeerror("Error en BuscarDanio ✖️✖️" + ex.Message);
        //    }
        //    finally
        //    {
        //        Conexion.cerrar();
        //    }
        //}
        //public void BuscarTipoCompra(string Buscar, ref DataTable dt, int desde, int hasta, int Contar)
        //{
        //    try
        //    {
        //        Conexion.abrir();
        //        SqlCommand cmd = new SqlCommand("BuscarTipoCompra", Conexion.conectar);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Desde", desde);
        //        cmd.Parameters.AddWithValue("@Hasta", hasta);
        //        cmd.Parameters.AddWithValue("@Buscador", Buscar);

        //        // Parámetro de salida para el contador
        //        SqlParameter contarParam = new SqlParameter("@Contar", SqlDbType.Int);
        //        contarParam.Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add(contarParam);

        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(dt);

        //        // Obtener el valor del contador
        //        Contar = Convert.ToInt32(contarParam.Value);
        //        contador = Contar;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Ocurrió un error al cargar los datos " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        Log.Writeerror("Error en BuscarTipoCompra ✖️✖️" + ex.Message);
        //    }
        //    finally
        //    {
        //        Conexion.cerrar();
        //    }
        //}
        //public void BuscarMTNT(string Buscar, ref DataTable dt, int desde, int hasta, int Contar)
        //{
        //    try
        //    {
        //        Conexion.abrir();
        //        SqlCommand cmd = new SqlCommand("BuscarMTNT", Conexion.conectar);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Desde", desde);
        //        cmd.Parameters.AddWithValue("@Hasta", hasta);
        //        cmd.Parameters.AddWithValue("@Buscador", Buscar);

        //        // Parámetro de salida para el contador
        //        SqlParameter contarParam = new SqlParameter("@Contar", SqlDbType.Int);
        //        contarParam.Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add(contarParam);

        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(dt);

        //        // Obtener el valor del contador
        //        Contar = Convert.ToInt32(contarParam.Value);
        //        contador = Contar;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Ocurrió un error al cargar los datos " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        Log.Writeerror("Error en BuscarMTNT ✖️✖️" + ex.Message);
        //    }
        //    finally
        //    {
        //        Conexion.cerrar();
        //    }
        //}
        //public void BuscarPeso(string Buscar, ref DataTable dt, int desde, int hasta, int Contar)
        //{
        //    try
        //    {
        //        Conexion.abrir();
        //        SqlCommand cmd = new SqlCommand("BuscarPeso", Conexion.conectar);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Desde", desde);
        //        cmd.Parameters.AddWithValue("@Hasta", hasta);
        //        cmd.Parameters.AddWithValue("@Buscador", Buscar);

        //        // Parámetro de salida para el contador
        //        SqlParameter contarParam = new SqlParameter("@Contar", SqlDbType.Int);
        //        contarParam.Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add(contarParam);

        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(dt);

        //        // Obtener el valor del contador
        //        Contar = Convert.ToInt32(contarParam.Value);
        //        contador = Contar;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Ocurrió un error al cargar los datos " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        Log.Writeerror("Error en BuscarPeso ✖️✖️" + ex.Message);
        //    }
        //    finally
        //    {
        //        Conexion.cerrar();
        //    }
        //}
        //public void BuscarAreaSecado(string Buscar, ref DataTable dt, int desde, int hasta, int Contar)
        //{
        //    try
        //    {
        //        Conexion.abrir();
        //        SqlCommand cmd = new SqlCommand("BuscarAreaSecado", Conexion.conectar);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Desde", desde);
        //        cmd.Parameters.AddWithValue("@Hasta", hasta);
        //        cmd.Parameters.AddWithValue("@Buscador", Buscar);

        //        // Parámetro de salida para el contador
        //        SqlParameter contarParam = new SqlParameter("@Contar", SqlDbType.Int);
        //        contarParam.Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add(contarParam);

        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(dt);

        //        // Obtener el valor del contador
        //        Contar = Convert.ToInt32(contarParam.Value);
        //        contador = Contar;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Ocurrió un error al cargar los datos " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        Log.Writeerror("Error en BuscarAreaSecado ✖️✖️" + ex.Message);
        //    }
        //    finally
        //    {
        //        Conexion.cerrar();
        //    }
        //}
        #endregion
        #endregion
        public void VerCons(ref DataTable dt, string TkPadre)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("VerCons", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Ticket", TkPadre);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en VerCons ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void BuscarTK2(string Buscar, string Dato, ref DataTable dt, int desde, int hasta, int Contar)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("BuscarTK2", Conexion.conectar);
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
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en BuscarTK ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void BuscarTK3(string Buscar, ref DataTable dt, int desde, int hasta, int Contar)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("BuscarTK3", Conexion.conectar);
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
                Log.Writeerror("Error en BuscarTK ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void Cosecha(System.Windows.Forms.Label Cosecha)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("select Cosecha from Cosecha where IdCosecha=(select max(IdCosecha) from Cosecha)", Conexion.conectar);
                object Temporada =cmd.ExecuteScalar();
                if (Temporada != null && Temporada != DBNull.Value)
                {
                    Cosecha.Text = Temporada.ToString();
                }
                else
                {
                    Cosecha.Text = "No se encontraron registros de cosecha.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puso cargar la cosecha" + ex.Message, "Error en Cosecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("No se pudo cargar la cosecha ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
    }
}
