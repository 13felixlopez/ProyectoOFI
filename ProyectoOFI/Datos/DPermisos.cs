using ProyectoOFI.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOFI.Datos
{
    public class DPermisos
    {
        public bool InsertarPermisos(LPermisos parametros)
        {
			try
			{
				Conexion.abrir();
				SqlCommand cmd = new SqlCommand("InsertarPermisos", Conexion.conectar);
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@IdModulo", parametros.IdModulo);
				cmd.Parameters.AddWithValue("@IdUsuario", parametros.IdUser);
				cmd.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
                Log.Writeerror("Error en InsertarPermisos ✖️✖️" + ex.Message);
                return false;
			}
			finally
			{
				Conexion.cerrar();
			}
        }
		public void MostrarPermisos(ref DataTable dt, LPermisos parametros)
		{
			try
			{
				Conexion.abrir();
				SqlDataAdapter da=new SqlDataAdapter("MostrarPermisos",Conexion.conectar);
				da.SelectCommand.CommandType=CommandType.StoredProcedure;
				da.SelectCommand.Parameters.AddWithValue("@IdUser", parametros.IdUser);
				da.Fill(dt);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
                Log.Writeerror("Error en MostrarPermisos ✖️✖️" + ex.Message);
            }
			finally
			{
				Conexion.cerrar();
			}
		}
		public bool EliminarPermisos(LPermisos parametros)
		{
			try
			{
				Conexion.abrir();
				SqlCommand cmd = new SqlCommand("EliminarPermisos", Conexion.conectar);
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@IdUser",parametros.IdUser);
				cmd.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show (ex.Message);
                Log.Writeerror("Error en EliminarPermisos ✖️✖️" + ex.Message);
                return false;
			}
			finally
			{
				Conexion.cerrar();
			}
		}
    }
}
