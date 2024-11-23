using ProyectoOFI.Logica;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoOFI.Datos
{
    public class DAlmacen
    {
        public int Contador;
        public double taraSaco;
        public void MostrarAlmacen(ref DataTable dt, int desde, int hasta)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarAlmacen", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Desde", desde);
                da.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de Almacén " + ex.Message, "Error en Almacén", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al cargar los datos en MostrarAlmacen ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void ExcelAlmacen(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("ExcelAlmacen", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar datos de Excel de Almacén" + ex.Message, "Error en datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al cargar datos en ExcelAlmacen ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void ReporteAlmacen(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("ReporteAlmacen", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar datos de Reporte de Almacén" + ex.Message, "Error en datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al cargar datos en ReporteAlmacen ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void ContarTK(ref int contador)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("ConteoAlmacen", Conexion.conectar);
                contador = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                contador = 0;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void VerdetalleTkAlmacen(ref DataTable dt, string Tk)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("VerdetalleTkAlmacen", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Dato", Tk);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el detalle de ticket Almacén " + ex.Message, "Error Almacén", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al cargar los datos en VerdetalleTkAlmacen ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarBodega(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarBodega", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                combo.ValueMember = "IdBodega";
                combo.DisplayMember = "Bodega";
                combo.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lista.Add(dt.Rows[i]["Bodega"].ToString());
                }
                combo.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarBodega ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarUbicacionPxBodega(ComboBox combo, int IdBodega)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarUbicacionPxBodega", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@IdBodega", IdBodega);
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                combo.ValueMember = "IdUbicacion";
                combo.DisplayMember = "Ubicacion";
                combo.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lista.Add(dt.Rows[i]["Ubicacion"].ToString());
                }
                combo.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarBodega ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool InsertarAlmacen(LAlmacen parametros)
        {
            try
            {
                Conexion.abrir();
                SqlCommand da = new SqlCommand("InsertarAlmacen", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                da.Parameters.AddWithValue("@Origen", parametros.Origen);
                da.Parameters.AddWithValue("@FechaAlmacen", parametros.FechaAlmacen);
                da.Parameters.AddWithValue("@IdBodega", parametros.IdBodega);
                da.Parameters.AddWithValue("@IdUbicacion", parametros.IdUbicacion);
                da.Parameters.AddWithValue("@IdEmpaque", parametros.IdEmpaque);
                da.Parameters.AddWithValue("@Sacos", parametros.Sacos);
                da.Parameters.AddWithValue("@Peso", parametros.Peso);
                da.Parameters.AddWithValue("@Tara", parametros.Tara);
                da.Parameters.AddWithValue("@PesoNeto", parametros.PesoNeto);
                da.Parameters.AddWithValue("@Rendimiento", parametros.Rendimiento);
                da.Parameters.AddWithValue("@IdTurno", parametros.IdTurno);
                da.Parameters.AddWithValue("@IdDescargador", parametros.IdDescargador);
                da.Parameters.AddWithValue("@Usuario", Login.NombreA);
                da.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Insertar los datos en Almacén " + ex.Message, "Error en Almacén", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en InsertarAlmacen ✖️✖️ " + ex.Message);
                return false;
            }
            finally { Conexion.cerrar(); }
        }
        public bool EditarAlmacen(LAlmacen parametros)
        {
            try
            {
                Conexion.abrir();
                SqlCommand da = new SqlCommand("EditarAlmacen", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                da.Parameters.AddWithValue("@Origen", parametros.Origen);
                da.Parameters.AddWithValue("@FechaAlmacen", parametros.FechaAlmacen);
                da.Parameters.AddWithValue("@IdBodega", parametros.IdBodega);
                da.Parameters.AddWithValue("@IdUbicacion", parametros.IdUbicacion);
                da.Parameters.AddWithValue("@IdEmpaque", parametros.IdEmpaque);
                da.Parameters.AddWithValue("@Sacos", parametros.Sacos);
                da.Parameters.AddWithValue("@Peso", parametros.Peso);
                da.Parameters.AddWithValue("@Tara", parametros.Tara);
                da.Parameters.AddWithValue("@PesoNeto", parametros.PesoNeto);
                da.Parameters.AddWithValue("@Rendimiento", parametros.Rendimiento);
                da.Parameters.AddWithValue("@IdTurno", parametros.IdTurno);
                da.Parameters.AddWithValue("@IdDescargador", parametros.IdDescargador);
                da.Parameters.AddWithValue("@Usuario", Login.NombreA);
                da.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Editar los datos en Almacén " + ex.Message, "Error en Almacén", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en EditarAlmacen ✖️✖️ " + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarEmpaque(ComboBox Empaque)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarEmpaque", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                Empaque.ValueMember = "IdEmpaque";
                Empaque.DisplayMember = "Empaque";
                Empaque.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lista.Add(dt.Rows[i]["Empaque"].ToString());
                }
                Empaque.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Empaques " + ex.Message, "Error en Empaques", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Log.Writeerror("Error en MostrarEmpaques ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarTurnoAl(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarTurnoAl", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                combo.ValueMember = "IdTurno";
                combo.DisplayMember = "Turno";
                combo.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lista.Add(dt.Rows[i]["Turno"].ToString());
                }
                combo.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Turnos " + ex.Message, "Error en Empaques", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Log.Writeerror("Error en MostrarTurnoAl ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarDescargador(ComboBox Descargador)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarDescargador", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                Descargador.ValueMember = "IdDescargador";
                Descargador.DisplayMember = "Descargador";
                Descargador.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lista.Add(dt.Rows[i]["Descargador"].ToString());
                }
                Descargador.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Descargador " + ex.Message, "Error en Descargadores", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Log.Writeerror("Error en MostrarDescargador ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarTaraSaco(int IdEmpaque)
        {
            try
            {
                // Abrir la conexión
                Conexion.abrir();

                using (SqlCommand cmd = new SqlCommand("MostrarTaraSaco", Conexion.conectar))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdEmpaque", IdEmpaque);

                    // Ejecutar el comando y obtener el resultado
                    object result = cmd.ExecuteScalar();

                    // Verificar que el resultado no sea null y asignarlo a la variable
                    if (result != null && result != DBNull.Value)
                    {
                        taraSaco = Convert.ToDouble(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en cargar TaraSacos " + ex.Message, "Error en TaraSacos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en cargar datos de TaraSacos ✖️✖️ " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión
                Conexion.cerrar();
            }
        }
        public void DetalleAlmacen(ref DataTable dt, string TK)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("DetalleAlmacen", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Ticket", TK);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar los datos de Ticket " + ex.Message, "Error en detalle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("No se pudo cargar los datos en DetalleAlmacen ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void BuscarAlmacen(string Buscar, string Dato, ref DataTable dt, int desde, int hasta, int Contar)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("BuscarAlmacen", Conexion.conectar);
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
                Contador = Contar;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en BuscarAlmacen ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool Split(double Peso,string TicketO, string Ticket)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("Split", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PesoNuevo",Peso);
                cmd.Parameters.AddWithValue("@TicketPrincipal", TicketO);
                cmd.Parameters.AddWithValue("@TicketSeleccionado",Ticket);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el Split " + ex.Message, "Split no creado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en Split ✖️✖️ " + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
    }
}
