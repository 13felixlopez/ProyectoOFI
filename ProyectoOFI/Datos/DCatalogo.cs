using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoOFI.Datos
{
    public class DCatalogo
    {
        public void MostrarCosechas(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter cmd = new SqlDataAdapter("Select * from Cosecha", Conexion.conectar);
                cmd.SelectCommand.CommandType = CommandType.Text;
                cmd.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos" + ex.Message, "Error en MostrarCosechas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarCosechas ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool InsertarCosecha(string cosecha)
        {
            try
            {
                Conexion.abrir();
                SqlCommand sqlCommand = new SqlCommand("InsertarCosecha", Conexion.conectar);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Cosecha", cosecha);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se logro insertar la cosecha " + ex.Message, "Error al insertar cosecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en InsertarCosecha ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarCosecha(int idCosecha, string Cosecha)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarCosecha", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCosecha", idCosecha);
                cmd.Parameters.AddWithValue("@Cosecha", Cosecha);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EditarCosecha ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool AgregarAgencia(string Agencia)
        {
            try
            {
                Conexion.abrir();
                SqlCommand sqlCommand = new SqlCommand("AgregarAgencia", Conexion.conectar);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Agencia", Agencia);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al AgregarAgencia DAgencia ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarAgencias(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarAgencias", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al MostrarAgencias DAgencias" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EliminarAgencia(string Agencia)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarAgencia", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Agencia", Agencia);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EliminarAgencia ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarAgencia(int idagencia, string Agencia)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarAgencia", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAgencia", idagencia);
                cmd.Parameters.AddWithValue("@Agencia", Agencia);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EditarAgencia ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool InsertarAcopio(string Acopio, int idagencia)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("InsertarAcopio", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAgencia", idagencia);
                cmd.Parameters.AddWithValue("@Acopio", Acopio);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al InsertarAcopio ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarAcopios(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarAcopios", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al MostrarAcopios ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarAcopio(int idacopio, string acopio, int idagencia)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarAcopio", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAcopio", idacopio);
                cmd.Parameters.AddWithValue("@Acopio", acopio);
                cmd.Parameters.AddWithValue("@IdAgencia", idagencia);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EditarAcopios ✖️✖️" + ex.Message);
                return false;
            }
            finally { Conexion.cerrar(); }
        }
        public bool EliminarAcopio(int IdAcopio)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarAcopio", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAcopio", IdAcopio);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EliminarAcopios ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarRecibidor(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter cmd = new SqlDataAdapter("MostrarRecibidor", Conexion.conectar);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al MostrarRecibidor ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool AgregarRecibidor(string Nombre)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("InsertarRecibidor", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar Recibidor " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al InsertarRecibidor ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarRecibidor(int Idrecibidor, string Nombre)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarRecibidor", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdRecibidor", Idrecibidor);
                cmd.Parameters.AddWithValue("@Nombre", Nombre.Trim());
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ah podido editar el Nombre del Recibidor" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EditarRecibidor ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EliminarRecibidor(int Idrecibidor)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarRecibidor", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Idrecibidor", Idrecibidor);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EliminarRecibidor ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #region Clientes
        public void MostrarClientes(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter cmd = new SqlDataAdapter("MostrarCliente", Conexion.conectar);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al MostrarCliente ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool AgregarCliente(string Identificacion, string Nombre)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("AgregarClientes", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Identificacion", Identificacion);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar Cliente " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al AgregarClientes ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarCliente(int idcliente, string Identificacion, string Nombre)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarCliente", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Idcliente", idcliente);
                cmd.Parameters.AddWithValue("@Identificacion", Identificacion);
                cmd.Parameters.AddWithValue("@Nombre", Nombre.Trim());
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ah podido editar los datos del cliente" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EditarCliente ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EliminarCliente(int idcliente)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarCliente", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Idcliente", idcliente);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EliminarCliente ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
        #region Compra
        public bool AgregarCompra(string Compra)
        {
            try
            {
                Conexion.abrir();
                SqlCommand sqlCommand = new SqlCommand("AgregarCompra", Conexion.conectar);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Compra", Compra);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al AgregarCompra ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarCompra(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarCompra", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al MostrarCompra ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EliminarCompra(int IdCompra)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarCompra", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCompra", IdCompra);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EliminarCompra ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarCompra(int IdCompra, string Compra)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarCompra", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCompra", IdCompra);
                cmd.Parameters.AddWithValue("@Compra", Compra);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EditarCompra ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
        #region Cert
        public bool AgregarCert(string Cert)
        {
            try
            {
                Conexion.abrir();
                SqlCommand sqlCommand = new SqlCommand("AgregarCertificacion", Conexion.conectar);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Cert", Cert);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al AgregarCertificación ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarCertificacion(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarCertificacion", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al MostrarCertificación ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EliminarCert(int idcert)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarCertificacion", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCertificacion", idcert);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EliminarCertificación ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarCertificacion(int Idcert, string Cert)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarCertificacion", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCertificacion", Idcert);
                cmd.Parameters.AddWithValue("@Cert", Cert);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EditarCertificación ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
        #region EstFis
        public bool AgregarEstFist(string EstFis)
        {
            try
            {
                Conexion.abrir();
                SqlCommand sqlCommand = new SqlCommand("InsertarEstFis", Conexion.conectar);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EstFisico", EstFis);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al InsertarEstFis ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarEstFis(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarEstFis", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al MostrarEstFis ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EliminarEstFis(int EstFis)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarEstFis", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdEstFis", EstFis);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EliminarEstFis ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarEstFis(int IdEstFis, string EstFis)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarEstFis", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdEstFis", IdEstFis);
                cmd.Parameters.AddWithValue("@EstFisico", EstFis);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EditarEstFis ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
        #region Calidad
        public bool AgregarCalidad(string Calidad)
        {
            try
            {
                Conexion.abrir();
                SqlCommand sqlCommand = new SqlCommand("AgregarCalidad", Conexion.conectar);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Calidad", Calidad);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al AgregarCalidad ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarCalidad(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarCalidad", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al MostrarCalidad ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EliminarCalidad(int Calidad)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarCalidad", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCalidad", Calidad);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EliminarCalidad ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarCalidad(int IdCalidad, string Calidad)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarCalidad", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCalidad", IdCalidad);
                cmd.Parameters.AddWithValue("@Calidad", Calidad);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EditarCalidad ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
        #region Daño
        public bool AgregarDanio(string Danio)
        {
            try
            {
                Conexion.abrir();
                SqlCommand sqlCommand = new SqlCommand("AgregarDanio", Conexion.conectar);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Danio", Danio);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al AgregarDanio ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarDanio(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarDanio", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al MostrarDanio ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EliminarDanio(int IdDanio)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarDanio", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdDanio", IdDanio);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EliminarDanio ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarDanio(int IdDanio, string Danio)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarDanio", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdDanio", IdDanio);
                cmd.Parameters.AddWithValue("@Danio", Danio);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EditarDanio ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
        #region AreaSecado
        public bool AgregarAreaSecado(string AreaSecado)
        {
            try
            {
                Conexion.abrir();
                SqlCommand sqlCommand = new SqlCommand("AgregarAreaSecado", Conexion.conectar);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@AreaSecado", AreaSecado);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al AgregarAreaSecado ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarAreaSecado(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarAreaSecado", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al MostrarAreaSecado ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EliminarAreaSecado(int IdAreaSecado)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarAreaSecado", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAreaSecado", IdAreaSecado);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EliminarAreaSecado ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarAreaSecado(int IdAreaSecado, string AreaSecado)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarAreaSecado", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAreaSecado", IdAreaSecado);
                cmd.Parameters.AddWithValue("@AreaSecado", AreaSecado);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EditarAreaSecado ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
        #region Patio
        public bool AgregarPatio(string Patio)
        {
            try
            {
                Conexion.abrir();
                SqlCommand sqlCommand = new SqlCommand("AgregarPatio", Conexion.conectar);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Patio", Patio);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al AgregarPatio ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarPatio(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarPatio", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al MostrarPatio ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EliminarPatio(int IdPatio)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarPatio", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPatio", IdPatio);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EliminarPatio ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarPatio(int IdPatio, string Patio)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarPatio", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPatio", IdPatio);
                cmd.Parameters.AddWithValue("@Patio", Patio);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EditarPatio ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
        #region UbicacionP
        public bool AgregarUbicacionP(string UbicacionP, int IdPatio)
        {
            try
            {
                Conexion.abrir();
                SqlCommand sqlCommand = new SqlCommand("AgregarUbicacionP", Conexion.conectar);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Ubicacion", UbicacionP);
                sqlCommand.Parameters.AddWithValue("@IdPatio", IdPatio);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al AgregarUbicacionP ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarUbicacionP(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarUbicacionP", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al MostrarUbicacionP ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EliminarUbicacionP(int IdUbicacionP)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarUbicacionP", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUbicacionP", IdUbicacionP);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EliminarUbicacionP ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarUbicacionP(int IdUbicacionP, string UbicacionP, int idPatio)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarUbicacionP", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUbicacion", IdUbicacionP);
                cmd.Parameters.AddWithValue("@Ubicacion", UbicacionP);
                cmd.Parameters.AddWithValue("@IdPatio", idPatio);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EditarUbicacionP ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
        #region OperadorSM
        public bool AgregarOperadorSM(string OperadorSM)
        {
            try
            {
                Conexion.abrir();
                SqlCommand sqlCommand = new SqlCommand("AgregarOperadorSM", Conexion.conectar);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Nombre", OperadorSM);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al AgregarOperadorSM ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarOperadorSM(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarOperadores", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al MostrarOperadorSM ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EliminarOperadorSM(int IdOperadorSM)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarOperadorSM", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdOperadorSM", IdOperadorSM);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EliminarOperadorSM ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarOperadorSM(int IdOperadorSM, string OperadorSM)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarOperadorSM", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdOperadorSM", IdOperadorSM);
                cmd.Parameters.AddWithValue("@OperadorSM", OperadorSM);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EditarOperadorSM ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
        #region Turnos
        public bool AgregarTurnos(string Turnos)
        {
            try
            {
                Conexion.abrir();
                SqlCommand sqlCommand = new SqlCommand("AgregarTurnos", Conexion.conectar);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Turnos", Turnos);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al AgregarTurnos ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarTurno(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarTurno", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al MostrarTurno ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EliminarTurno(int IdTurno)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarTurno", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTurno", IdTurno);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EliminarTurnos ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarTurnos(int IdTurnos, string Turnos)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarTurnos", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTurnos", IdTurnos);
                cmd.Parameters.AddWithValue("@Turnos", Turnos);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EditarTurnos ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
        #region Paros
        public bool AgregarParos(string Paros)
        {
            try
            {
                Conexion.abrir();
                SqlCommand sqlCommand = new SqlCommand("AgregarParos", Conexion.conectar);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Paros", Paros);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al AgregarParos ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarParo(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarParo", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al MostrarParo ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EliminarParo(int IdParo)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarParo", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdParo", IdParo);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EliminarParos ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarParos(int IdParos, string Paros)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarParos", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdParos", IdParos);
                cmd.Parameters.AddWithValue("@Paros", Paros);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EditarParos ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
        #region Variedad
        public bool AgregarVariedad(string Variedad)
        {
            try
            {
                Conexion.abrir();
                SqlCommand sqlCommand = new SqlCommand("AgregarVariedad", Conexion.conectar);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Variedad", Variedad);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al AgregarVariedad ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarVariedad(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarVariedades", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al MostrarVariedades ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EliminarVariedad(int IdVariedad)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarVariedad", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdVariedad", IdVariedad);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EliminarVariedad ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarVariedad(int IdVariedad, string Variedad)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarVariedad", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdVariedad", IdVariedad);
                cmd.Parameters.AddWithValue("@Variedad", Variedad);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EditarVariedad ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
        #region Descargador
        public bool AgregarDescargador(string Descargador)
        {
            try
            {
                Conexion.abrir();
                SqlCommand sqlCommand = new SqlCommand("AgregarDescargador", Conexion.conectar);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Descargador", Descargador);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al AgregarDescargador ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarDescargador(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarDescargador", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al MostrarDescargador ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EliminarDescargador(int IdDescargador)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarDescargador", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdDescargador", IdDescargador);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EliminarDescargador ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarDescargador(int IdDescargador, string Descargador)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarDescargador", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdDescargador", IdDescargador);
                cmd.Parameters.AddWithValue("@Descargador", Descargador);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EditarDescargador ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
        #region Bodega
        public bool AgregarBodega(string Bodega)
        {
            try
            {
                Conexion.abrir();
                SqlCommand sqlCommand = new SqlCommand("AgregarBodega", Conexion.conectar);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Bodega", Bodega);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al AgregarBodega ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarBodega(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarBodega", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al MostrarBodega ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EliminarBodega(int IdBodega)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarBodega", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdBodega", IdBodega);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EliminarBodega ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarBodega(int IdBodega, string Bodega)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarBodega", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdBodega", IdBodega);
                cmd.Parameters.AddWithValue("@Bodega", Bodega);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EditarBodega ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
        #region UbicacionB
        public bool AgregarUbicacionB(string UbicacionB, int IdBodega)
        {
            try
            {
                Conexion.abrir();
                SqlCommand sqlCommand = new SqlCommand("AgregarUbicacionB", Conexion.conectar);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UbicacionB", UbicacionB);
                sqlCommand.Parameters.AddWithValue("@IdBodega", IdBodega);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al AgregarUbicacionB ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarUbicacionB(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarUbicacionB", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al MostrarUbicacionB ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EliminarUbicacionB(int IdUbicacionB)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarUbicacionB", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUbicacion", IdUbicacionB);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EliminarUbicacionB ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarUbicacionB(int IdUbicacionB, string UbicacionB, int idBodega)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarUbicacionB", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUbicacion", IdUbicacionB);
                cmd.Parameters.AddWithValue("@UbicacionB", UbicacionB);
                cmd.Parameters.AddWithValue("@IdBodega", idBodega);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EditarUbicacionB ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
        #region Empaque
        public bool AgregarEmpaque(string Empaque, string Capacidad, double TaraSaco)
        {
            try
            {
                Conexion.abrir();
                SqlCommand sqlCommand = new SqlCommand("AgregarEmpaque", Conexion.conectar);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Empaque", Empaque);
                sqlCommand.Parameters.AddWithValue("@Capacidad", Capacidad);
                sqlCommand.Parameters.AddWithValue("@TaraSaco", TaraSaco);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al AgregarEmpaque ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarEmpaque(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarEmpaque", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al MostrarEmpaque ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EliminarEmpaque(int IdEmpaque)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarEmpaque", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdEmpaque", IdEmpaque);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EliminarEmpaque ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarEmpaque(int IdEmpaque, string Empaque, string Capacidad, double TaraSaco)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarEmpaque", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdEmpaque", IdEmpaque);
                cmd.Parameters.AddWithValue("@Empaque", Empaque);
                cmd.Parameters.AddWithValue("@Capacidad", Capacidad);
                cmd.Parameters.AddWithValue("@TaraSaco", TaraSaco);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EditarEmpaque ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
        #region TurnoAl
        public bool AgregarTurnoAl(string TurnoAl)
        {
            try
            {
                Conexion.abrir();
                SqlCommand sqlCommand = new SqlCommand("AgregarTurnoAl", Conexion.conectar);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Turnos", TurnoAl);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al AgregarTurnoAl ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarTurnoAl(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarTurnoAl", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al MostrarTurnoAl ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EliminarTurnoAl(int IdTurno)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarTurnoAl", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTurno", IdTurno);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EliminarTurnoAl ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarTurnoAl(int IdTurnoAl, string TurnoAl)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarTurnosAl", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTurnos", IdTurnoAl);
                cmd.Parameters.AddWithValue("@Turnos", TurnoAl);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EditarTurnoAl ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
        #region GCalidades
        public bool AgregarGCalidades(string GCalidades)
        {
            try
            {
                Conexion.abrir();
                SqlCommand sqlCommand = new SqlCommand("InsertarGrupoCalidad", Conexion.conectar);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@GrupoCalidad", GCalidades);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al AgregarGCalidades ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarGCalidades(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Select * from GrupoCalidad", Conexion.conectar);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al MostrarGCalidadeses ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EliminarGCalidades(int IdGCalidades)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarGrupoCalidad", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdGrupoCalidad", IdGCalidades);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EliminarGCalidades ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarGCalidades(int IdGCalidades, string GCalidades)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarGrupoCalidad", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdGrupoCalidad", IdGCalidades);
                cmd.Parameters.AddWithValue("@GrupoCalidad", GCalidades);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EditarGCalidades ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
        #region Material
        public bool AgregarMaterial(string Material)
        {
            try
            {
                Conexion.abrir();
                SqlCommand sqlCommand = new SqlCommand("AgregarMaterial", Conexion.conectar);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Material", Material);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al AgregarMaterial ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarMaterial(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarMaterial", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al MostrarMaterial ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EliminarMaterial(int IdMaterial)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarMaterial", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdMaterial", IdMaterial);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EliminarMaterial ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarMaterial(int IdMaterial, string Material)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarMaterial", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdMaterial", IdMaterial);
                cmd.Parameters.AddWithValue("@Material", Material);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EditarMaterial ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
        #region Tasa
        public bool AgregarTasa(string Tasa)
        {
            try
            {
                Conexion.abrir();
                SqlCommand sqlCommand = new SqlCommand("InsertarTasa", Conexion.conectar);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Tasa", Tasa);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al InsertarTasa ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarTasas(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarTasas", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al MostrarTasa ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EliminarTasa(int IdTasa)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarTasa", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTasa", IdTasa);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EliminarTasa ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarTasa(int IdTasa, string Tasa)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarTasa", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTasa", IdTasa);
                cmd.Parameters.AddWithValue("@Tasa", Tasa);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al EditarTasa ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
    }
}
