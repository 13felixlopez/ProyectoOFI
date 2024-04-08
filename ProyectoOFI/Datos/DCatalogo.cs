using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Schema;

namespace ProyectoOFI.Datos
{
    public class DCatalogo
    {
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
				SqlCommand cmd= new SqlCommand("EliminarAgencia",Conexion.conectar);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@Agencia", Agencia);
				cmd.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
			finally
			{
				Conexion.cerrar();
			}
		}
		public bool EditarAgencia(int idagencia,string Agencia)
		{
			try
			{
				Conexion.abrir();
				SqlCommand cmd = new SqlCommand("EditarAgencia", Conexion.conectar);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@IdAgencia", idagencia);
				cmd.Parameters.AddWithValue("@Agencia",Agencia);
				cmd.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
			finally
			{
				Conexion.cerrar();
			}
		}
		public bool InsertarAcopio(string Acopio,int idagencia)
		{
			try
			{
				Conexion.abrir();
				SqlCommand cmd = new SqlCommand("InsertarAcopio", Conexion.conectar);
				cmd.CommandType= CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@IdAgencia", idagencia);
				cmd.Parameters.AddWithValue("@Acopio", Acopio);
				cmd.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
            finally
            {
                Conexion.cerrar();
            }
        }
		public bool EditarAcopio(int idacopio,string acopio,int idagencia)
		{
			try
			{
				Conexion.abrir();
				SqlCommand cmd = new SqlCommand("EditarAcopio",Conexion.conectar);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@IdAcopio",idacopio);
				cmd.Parameters.AddWithValue("@Acopio",acopio);
				cmd.Parameters.AddWithValue("@IdAgencia",idagencia);
				cmd.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
				cmd.CommandType= CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@IdAcopio",IdAcopio);
				cmd.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
				MessageBox.Show("Error al cargar los datos "+ex.Message,"ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
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
				cmd.Parameters.AddWithValue("@Nombre",Nombre);
				cmd.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al insertar Recibidor " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			finally 
			{
				Conexion.cerrar();
			}
		}
		public bool EditarRecibidor(int Idrecibidor,string Nombre)
		{
			try
			{
				Conexion.abrir();
				SqlCommand cmd = new SqlCommand("EditarRecibidor", Conexion.conectar);
				cmd.CommandType= CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@IdRecibidor",Idrecibidor);
				cmd.Parameters.AddWithValue("@Nombre",Nombre.Trim());
				cmd.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("No se ah podido editar el Nombre del Recibidor" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool AgregarCliente(string Identificacion,string Nombre)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("AgregarClientes", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@Identificacion",Identificacion);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar Cliente " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarCliente(int idcliente,string Identificacion, string Nombre)
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
