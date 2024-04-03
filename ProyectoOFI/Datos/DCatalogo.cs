using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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
    }
}
