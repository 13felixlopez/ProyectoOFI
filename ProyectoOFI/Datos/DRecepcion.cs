using ProyectoOFI.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("InsertarLote", conectar))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                    cmd.Parameters.AddWithValue("@FechaRecibido", parametros.FRecibido);
                    cmd.Parameters.AddWithValue("@Patio", parametros.Patio);
                    cmd.Parameters.AddWithValue("@UbicacionRec", parametros.UbicacionRec);
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
                    cmd.Parameters.AddWithValue("@Placa", parametro.Placa);
                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("Registro realizado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en InsertarLote ✖️✖️" + ex.Message);
                return false;
            }
        }
        public void MostrarLote(ref DataTable dt, int desde, int hasta)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("MostrarLotes", conectar))
                {

                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Desde", desde);
                    da.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarLotes ✖️✖️" + ex.Message);
            }
        }
        public void MostrarDetalle(ref DataTable dt, string Tk)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("MostrarDetalle", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Ticket", Tk);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Error MostrarDetalle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarDetalle ✖️✖️ " + ex.Message);
            }
        }

        public bool EliminarTK(LRecepcion parametros)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("EliminarTK", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TK", parametros.Ticket);
                    cmd.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show($"El Ticket = {parametros.Ticket} ha sido eliminado.",
                    "Eliminado con éxito ✅", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("El elemento no ha sido eliminado: " + ex.Message,
                    "ERROR DRecepcion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en EliminarTK ✖️✖️ " + ex.Message);
                return false;
            }
        }

        public bool EditarSacosPeso(string Tk, double peso, double pesoe, int sacos, int sacose)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("EditarSacosPeso", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ticket", Tk);
                    cmd.Parameters.AddWithValue("@Sacos", sacos);
                    cmd.Parameters.AddWithValue("@Peso", peso);
                    cmd.Parameters.AddWithValue("@SacosE", sacose);
                    cmd.Parameters.AddWithValue("@PesoE", pesoe);
                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido editar el registro: " + ex.Message,
                    "ERROR al actualizar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en EditarSacosPeso ✖️✖️ " + ex.Message);
                return false;
            }
        }

        public void ContarTK(ref int Contador)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT COUNT(Rec.Ticket) 
              FROM Recepcion AS Rec
              WHERE Estado='ACTIVO'
              AND Cosecha=(SELECT Cosecha 
                           FROM Cosecha 
                           WHERE IdCosecha=(SELECT MAX(IdCosecha) FROM Cosecha))", con))
                {
                    Contador = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception)
            {
                Contador = 0;
            }
        }

        public void ContarTKCP(ref int Contador)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT COUNT(Rec.Ticket) 
              FROM Recepcion AS Rec
              LEFT JOIN AreaSecado AS ASe ON Rec.IdAreaSecado = ASe.IdAreaSecado
              LEFT JOIN Tendido AS T ON Rec.Ticket = T.Ticket
              WHERE Rec.Estado = 'ACTIVO' 
              AND (ASe.AreaSecado = 'Control Patio' OR T.ProcesoCP != '')
              AND Rec.Cosecha = (SELECT Cosecha 
                                 FROM Cosecha 
                                 WHERE IdCosecha = (SELECT MAX(IdCosecha) FROM Cosecha))", con))
                {
                    Contador = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception)
            {
                Contador = 0;
            }
        }

        internal void BuscarrangoFecha(ref DataTable dt, DateTime FInicio, DateTime FFin, int desde, int hasta, int Contar)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("BuscarrangoFecha", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Desde", desde);
                    cmd.Parameters.AddWithValue("@Hasta", hasta);
                    cmd.Parameters.AddWithValue("@FInicio", FInicio);
                    cmd.Parameters.AddWithValue("@FFin", FFin);

                    SqlParameter contarParam = new SqlParameter("@Contar", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(contarParam);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    Contar = Convert.ToInt32(contarParam.Value);
                    contador = Contar;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos en búsqueda por rango de fecha: " + ex.Message,
                    "Error BuscarrangoFecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en BuscarrangoFecha ✖️✖️ " + ex.Message);
            }
        }

        public bool EditarTK(LRecepcion parametros, LEnvio par, string TicketAnterior)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("EditarTK", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TicketAnterior", TicketAnterior);
                    cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                    cmd.Parameters.AddWithValue("@FechaRecibido", parametros.FRecibido);
                    cmd.Parameters.AddWithValue("@Patio", parametros.Patio);
                    cmd.Parameters.AddWithValue("@UbicacionRec", parametros.UbicacionRec);
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
                    // Envio
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
                    cmd.Parameters.AddWithValue("@Placa", par.Placa);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar el Ticket. Detalle: " + ex.Message,
                    "Error EditarTK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en EditarTK ✖️✖️ " + ex.Message);
                return false;
            }
        }

        public bool Consolidar(LRecepcion parametros, LEnvio par, List<string> lstcons, string folio, string proceso)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Id");
                dt.Columns.Add("TicketH");

                int i = 1;
                foreach (string ticket in lstcons)
                {
                    if (!string.IsNullOrEmpty(ticket))
                    {
                        DataRow row = dt.NewRow();
                        row["Id"] = i++;
                        row["TicketH"] = ticket;
                        dt.Rows.Add(row);
                    }
                }

                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("Consolidar", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramList = new SqlParameter("@lstCons", SqlDbType.Structured)
                    {
                        TypeName = "Con",
                        Value = dt
                    };
                    cmd.Parameters.Add(paramList);

                    cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                    cmd.Parameters.AddWithValue("@sacos", parametros.Sacos);
                    cmd.Parameters.AddWithValue("@Peso", parametros.Peso);
                    cmd.Parameters.AddWithValue("@PesoE", par.PesoE);
                    cmd.Parameters.AddWithValue("@Merma", parametros.Merma);
                    cmd.Parameters.AddWithValue("@Calidad", parametros.Calidad);
                    cmd.Parameters.AddWithValue("@IdCertificacion", par.IdCertificacionE);
                    cmd.Parameters.AddWithValue("@EstFisico", parametros.EstadoFisico);
                    cmd.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                    cmd.Parameters.AddWithValue("@FRecibido", parametros.FRecibido);
                    cmd.Parameters.AddWithValue("@Danio", parametros.Daño);
                    cmd.Parameters.AddWithValue("@Patio", parametros.Patio);
                    cmd.Parameters.AddWithValue("@UbicacionRec", parametros.UbicacionRec);
                    cmd.Parameters.AddWithValue("@AreaSecado", parametros.IdArea);
                    cmd.Parameters.AddWithValue("@Estado", "ACTIVO");
                    cmd.Parameters.AddWithValue("@Folio", folio);
                    cmd.Parameters.AddWithValue("@Proceso", proceso);
                    cmd.Parameters.AddWithValue("@Consolidado", "Si");
                    cmd.Parameters.AddWithValue("@ContadorEdit", 0);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo realizar la consolidación. Verifique los datos. " + ex.Message,
                    "Error Consolidar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en Consolidar ✖️✖️ " + ex.Message);
                return false;
            }
        }

        public bool Consolidar2(LRecepcion parametros, LEnvio par, List<string> lstcons, string folio)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Id");
                dt.Columns.Add("TicketH");

                int i = 1;
                foreach (string ticket in lstcons)
                {
                    if (!string.IsNullOrEmpty(ticket))
                    {
                        DataRow row = dt.NewRow();
                        row["Id"] = i++;
                        row["TicketH"] = ticket;
                        dt.Rows.Add(row);
                    }
                }

                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("Consolidar2", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramList = new SqlParameter("@lstCons", SqlDbType.Structured)
                    {
                        TypeName = "Con",
                        Value = dt
                    };
                    cmd.Parameters.Add(paramList);

                    cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                    cmd.Parameters.AddWithValue("@sacos", parametros.Sacos);
                    cmd.Parameters.AddWithValue("@Peso", parametros.Peso);
                    cmd.Parameters.AddWithValue("@Calidad", parametros.Calidad);
                    cmd.Parameters.AddWithValue("@IdCertificacion", par.IdCertificacionE);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo realizar la consolidación alternativa. " + ex.Message,
                    "Error Consolidar2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en Consolidar2 ✖️✖️ " + ex.Message);
                return false;
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
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand da = new SqlCommand("MostrarAcopioAgencia", con))
                {
                    da.CommandType = CommandType.StoredProcedure;
                    da.Parameters.AddWithValue("@IdAgencia", IdAgencia);
                    SqlDataAdapter cb = new SqlDataAdapter(da);
                    DataTable dt = new DataTable();
                    cb.Fill(dt);
                    combo.ValueMember = "IdAcopio";
                    combo.DisplayMember = "Acopio";
                    combo.DataSource = dt;
                    for (int i = 0; i < dt.Rows.Count; i++)
                        lista.Add(dt.Rows[i]["Acopio"].ToString());
                    combo.AutoCompleteCustomSource = lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los Acopios de la Agencia: " + ex.Message,
                    "Error MostrarAcopioAgencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarAcopioAgencia ✖️✖️ " + ex.Message);
            }
        }

        public void MostrarTKConsolidar(ref DataTable dt, LRecepcion parametros, LEnvio par)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("MostrarTKConsolidar", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Calidad", parametros.Calidad);
                    da.SelectCommand.Parameters.AddWithValue("@Cert", par.CertificacionE);
                    da.SelectCommand.Parameters.AddWithValue("@EsFi", parametros.EstadoFisico);
                    da.SelectCommand.Parameters.AddWithValue("@Danio", parametros.Daño);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar Tickets para consolidar: " + ex.Message,
                    "Error MostrarTKConsolidar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarTKConsolidar ✖️✖️ " + ex.Message);
            }
        }

        public void MostrarAgencia(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand da = new SqlCommand("MostrarAgencias", con))
                {
                    da.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter cb = new SqlDataAdapter(da);
                    DataTable dt = new DataTable();
                    cb.Fill(dt);
                    combo.ValueMember = "IdAgencia";
                    combo.DisplayMember = "Agencia";
                    combo.DataSource = dt;
                    for (int i = 0; i < dt.Rows.Count; i++)
                        lista.Add(dt.Rows[i]["Agencia"].ToString());
                    combo.AutoCompleteCustomSource = lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar las Agencias: " + ex.Message,
                    "Error MostrarAgencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarAgencias ✖️✖️ " + ex.Message);
            }
        }

        public void MostrarRecibidor(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand da = new SqlCommand("MostrarRecibidor", con))
                {
                    da.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter cb = new SqlDataAdapter(da);
                    DataTable dt = new DataTable();
                    cb.Fill(dt);
                    combo.ValueMember = "IdRecibidor";
                    combo.DisplayMember = "Nombre";
                    combo.DataSource = dt;
                    for (int i = 0; i < dt.Rows.Count; i++)
                        lista.Add(dt.Rows[i]["Nombre"].ToString());
                    combo.AutoCompleteCustomSource = lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los Recibidores: " + ex.Message,
                    "Error MostrarRecibidor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarRecibidor ✖️✖️ " + ex.Message);
            }
        }

        public void MostrarCliente(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand da = new SqlCommand("MostrarCliente", con))
                {
                    da.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter cb = new SqlDataAdapter(da);
                    DataTable dt = new DataTable();
                    cb.Fill(dt);
                    combo.ValueMember = "Idcliente";
                    combo.DisplayMember = "Nombre";
                    combo.DataSource = dt;
                    for (int i = 0; i < dt.Rows.Count; i++)
                        lista.Add(dt.Rows[i]["Nombre"].ToString());
                    combo.AutoCompleteCustomSource = lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los Clientes: " + ex.Message,
                    "Error MostrarCliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarClientes ✖️✖️ " + ex.Message);
            }
        }

        public void MostrarCompra(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand da = new SqlCommand("MostrarCompra", con))
                {
                    da.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter cb = new SqlDataAdapter(da);
                    DataTable dt = new DataTable();
                    cb.Fill(dt);
                    combo.ValueMember = "IdCompra";
                    combo.DisplayMember = "Compra";
                    combo.DataSource = dt;
                    for (int i = 0; i < dt.Rows.Count; i++)
                        lista.Add(dt.Rows[i]["Compra"].ToString());
                    combo.AutoCompleteCustomSource = lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar las Compras: " + ex.Message,
                    "Error MostrarCompra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarCompra ✖️✖️ " + ex.Message);
            }
        }

        public void MostrarCert(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand da = new SqlCommand("MostrarCertificacion", con))
                {
                    da.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter cb = new SqlDataAdapter(da);
                    DataTable dt = new DataTable();
                    cb.Fill(dt);
                    combo.ValueMember = "IdCert";
                    combo.DisplayMember = "Certificacion";
                    combo.DataSource = dt;
                    for (int i = 0; i < dt.Rows.Count; i++)
                        lista.Add(dt.Rows[i]["Certificacion"].ToString());
                    combo.AutoCompleteCustomSource = lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar las Certificaciones: " + ex.Message,
                    "Error MostrarCert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarCertificación ✖️✖️ " + ex.Message);
            }
        }

        public void MostrarEstFis(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand da = new SqlCommand("SELECT IdestFis, EstFisico FROM EstFisico", con))
                {
                    da.CommandType = CommandType.Text;
                    SqlDataAdapter cb = new SqlDataAdapter(da);
                    DataTable dt = new DataTable();
                    cb.Fill(dt);
                    combo.ValueMember = "IdestFis";
                    combo.DisplayMember = "EstFisico";
                    combo.DataSource = dt;
                    for (int i = 0; i < dt.Rows.Count; i++)
                        lista.Add(dt.Rows[i]["EstFisico"].ToString());
                    combo.AutoCompleteCustomSource = lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los Estados Físicos: " + ex.Message,
                    "Error MostrarEstFis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarEstFis ✖️✖️ " + ex.Message);
            }
        }

        public void MostrarCalidadUA(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand da = new SqlCommand("SELECT IdCalidad, Calidad FROM Calidad WHERE Calidad LIKE '%' + 'UA'", con))
                {
                    da.CommandType = CommandType.Text;
                    SqlDataAdapter cb = new SqlDataAdapter(da);
                    DataTable dt = new DataTable();
                    cb.Fill(dt);
                    combo.ValueMember = "IdCalidad";
                    combo.DisplayMember = "Calidad";
                    combo.DataSource = dt;
                    for (int i = 0; i < dt.Rows.Count; i++)
                        lista.Add(dt.Rows[i]["Calidad"].ToString());
                    combo.AutoCompleteCustomSource = lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar las Calidades UA: " + ex.Message,
                    "Error MostrarCalidadUA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarCalidadUA ✖️✖️ " + ex.Message);
            }
        }

        public void MostrarCalidad(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                using (SqlConnection con = Conexion.abrir())
                // using (SqlCommand da = new SqlCommand("SELECT * FROM Calidad WHERE Calidad NOT LIKE '%' + 'UA'", con))
                using (SqlCommand da = new SqlCommand("SELECT * FROM Calidad", con))
                {
                    da.CommandType = CommandType.Text;
                    SqlDataAdapter cb = new SqlDataAdapter(da);
                    DataTable dt = new DataTable();
                    cb.Fill(dt);
                    combo.ValueMember = "IdCalidad";
                    combo.DisplayMember = "Calidad";
                    combo.DataSource = dt;
                    for (int i = 0; i < dt.Rows.Count; i++)
                        lista.Add(dt.Rows[i]["Calidad"].ToString());
                    combo.AutoCompleteCustomSource = lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar las Calidades: " + ex.Message,
                    "Error MostrarCalidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarCalidad ✖️✖️ " + ex.Message);
            }
        }

        public void MostrarDaño(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand da = new SqlCommand("MostrarDanio", con))
                {
                    da.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter cb = new SqlDataAdapter(da);
                    DataTable dt = new DataTable();
                    cb.Fill(dt);
                    combo.ValueMember = "IdDanio";
                    combo.DisplayMember = "Daño";
                    combo.DataSource = dt;
                    for (int i = 0; i < dt.Rows.Count; i++)
                        lista.Add(dt.Rows[i]["Daño"].ToString());
                    combo.AutoCompleteCustomSource = lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los Daños: " + ex.Message,
                    "Error MostrarDaño", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarDaño ✖️✖️ " + ex.Message);
            }
        }

        public void MostrarAreaSecado(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand da = new SqlCommand("MostrarAreaSecado", con))
                {
                    da.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter cb = new SqlDataAdapter(da);
                    DataTable dt = new DataTable();
                    cb.Fill(dt);
                    combo.ValueMember = "IdAreaSecado";
                    combo.DisplayMember = "Area Secado";
                    combo.DataSource = dt;
                    for (int i = 0; i < dt.Rows.Count; i++)
                        lista.Add(dt.Rows[i]["Area Secado"].ToString());
                    combo.AutoCompleteCustomSource = lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar las Áreas de Secado: " + ex.Message,
                    "Error MostrarAreaSecado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarAreaSecado ✖️✖️ " + ex.Message);
            }
        }

        public void MostrarAreaSecado2(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand da = new SqlCommand("SELECT IdAreaSecado, AreaSecado FROM AreaSecado WHERE IdAreaSecado IN (1,2,6)", con))
                {
                    da.CommandType = CommandType.Text;
                    SqlDataAdapter cb = new SqlDataAdapter(da);
                    DataTable dt = new DataTable();
                    cb.Fill(dt);
                    combo.ValueMember = "IdAreaSecado";
                    combo.DisplayMember = "AreaSecado";
                    combo.DataSource = dt;
                    for (int i = 0; i < dt.Rows.Count; i++)
                        lista.Add(dt.Rows[i]["AreaSecado"].ToString());
                    combo.AutoCompleteCustomSource = lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar las Áreas de Secado (filtro 1,2,6): " + ex.Message,
                    "Error MostrarAreaSecado2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarAreaSecado2 ✖️✖️ " + ex.Message);
            }
        }

        public void MostrarLotesExcel(ref DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("MostrarLotesExcel", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los Lotes Excel: " + ex.Message,
                    "Error MostrarLotesExcel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarLotesExcel ✖️✖️ " + ex.Message);
            }
        }

        #endregion
        #region Buscadores
        public void BuscarTkExcel(string Buscar, ref DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("BuscarTkExcel", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Buscador", Buscar);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar en Excel: " + ex.Message,
                    "Error BuscarTkExcel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en BuscarTkExcel ✖️✖️ " + ex.Message);
            }
        }
        #endregion

        public void VerCons(ref DataTable dt, string TkPadre)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("VerCons", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Ticket", TkPadre);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los datos de consolidación: " + ex.Message,
                    "Error VerCons", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en VerCons ✖️✖️ " + ex.Message);
            }
        }

        public void BuscarTK2(string Buscar, string Dato, ref DataTable dt, int desde, int hasta, int Contar)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("BuscarTK2", con))
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

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    Contar = Convert.ToInt32(contarParam.Value);
                    contador = Contar;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar TK2: " + ex.Message,
                    "Error BuscarTK2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en BuscarTK2 ✖️✖️ " + ex.Message);
            }
        }

        public void BuscarTK3(string Buscar, ref DataTable dt, int desde, int hasta, int Contar)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("BuscarTK3", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Desde", desde);
                    cmd.Parameters.AddWithValue("@Hasta", hasta);
                    cmd.Parameters.AddWithValue("@Buscador", Buscar);

                    SqlParameter contarParam = new SqlParameter("@Contar", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(contarParam);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    Contar = Convert.ToInt32(contarParam.Value);
                    contador = Contar;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar TK3: " + ex.Message,
                    "Error BuscarTK3", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en BuscarTK3 ✖️✖️ " + ex.Message);
            }
        }

        public void Cosecha(System.Windows.Forms.Label lblCosecha)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT Cosecha FROM Cosecha WHERE IdCosecha = (SELECT MAX(IdCosecha) FROM Cosecha)", con))
                {
                    object temporada = cmd.ExecuteScalar();
                    lblCosecha.Text = (temporada != null && temporada != DBNull.Value)
                        ? temporada.ToString()
                        : "No se encontraron registros de cosecha.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la cosecha: " + ex.Message,
                    "Error Cosecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en Cosecha ✖️✖️ " + ex.Message);
            }
        }

        public bool EditarConst(string ticketConst, string ticket)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("dbo.EditarConst", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@TicketConst", SqlDbType.VarChar, 30).Value = ticketConst;
                    cmd.Parameters.Add("@Ticket", SqlDbType.VarChar, 30).Value = ticket;

                    var pMsg = cmd.Parameters.Add("@Msg", SqlDbType.NVarChar, 200);
                    pMsg.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    string mensaje = pMsg.Value?.ToString() ?? "Operación completada.";

                    MessageBox.Show(mensaje, "Resultado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error SQL ({ex.Number}): {ex.Message}",
                    "Error en EditarConst", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror($"SQL Error en EditarConst ► {ex}");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message,
                    "Error en EditarConst", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror($"Error genérico en EditarConst ► {ex}");
                return false;
            }
        }

        public DataTable BuscarMTNT()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT MT.MTNT FROM MTNTRec MT LEFT JOIN Envio En ON MT.MTNT = En.MTNT", con))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar MTNT: " + ex.Message,
                    "Error BuscarMTNT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en BuscarMTNT ✖️✖️ " + ex.Message);
            }
            return dt;
        }
        public void MostrarMTNT(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();

                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT MT.MTNT 
              FROM MTNTRec MT
              INNER JOIN Bascula B ON MT.IdBascula = B.IdBascula
              INNER JOIN Entrada Ent ON Ent.Cod = B.Cod
              WHERE NOT EXISTS (SELECT 1 FROM Envio EN WHERE EN.MTNT = MT.MTNT)
              AND Ent.TipoEntrada != 'Compra Directa'", con))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    combo.DisplayMember = "MTNT";
                    combo.ValueMember = "MTNT";
                    combo.DataSource = dt;

                    foreach (DataRow row in dt.Rows)
                        lista.Add(row["MTNT"].ToString());

                    combo.AutoCompleteCustomSource = lista;
                    combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    combo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los MTNT: " + ex.Message,
                    "Error MostrarMTNT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarMTNT ✖️✖️ " + ex.Message);
            }
        }

        public void RellenarCamposMTNT(string doc, ComboBox agencia, ComboBox acopio, NumericUpDown sacos, TextBox peso, ComboBox estFis)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT TOP (1) Agencia, Acopio, Sacos, Peso, EstadoFisico 
              FROM MTNTRec 
              WHERE MTNT = @Doc", con))
                {
                    cmd.Parameters.AddWithValue("@Doc", doc);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            agencia.Text = dt.Rows[0]["Agencia"].ToString();
                            acopio.Text = dt.Rows[0]["Acopio"].ToString();
                            sacos.Value = Convert.ToInt32(dt.Rows[0]["Sacos"]);
                            peso.Text = dt.Rows[0]["Peso"].ToString();
                            estFis.Text = dt.Rows[0]["EstadoFisico"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar datos de MTNT: " + ex.Message,
                    "Error RellenarCamposMTNT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en RellenarCamposMTNT ✖️✖️ " + ex.Message);
            }
        }

    }
}
