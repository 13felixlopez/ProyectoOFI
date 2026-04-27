using ProyectoOFI.Logica;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoOFI.Datos
{
    public class DPermisos
    {
        public bool InsertarPermisos(LPermisos parametros)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("InsertarPermisos", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdModulo", parametros.IdModulo);
                    cmd.Parameters.AddWithValue("@IdUsuario", parametros.IdUser);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Log.Writeerror("Error en InsertarPermisos ✖️✖️ " + ex.Message);
                return false;
            }
        }

        public void MostrarPermisos(ref DataTable dt, LPermisos parametros)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("MostrarPermisos", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@IdUser", parametros.IdUser);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Log.Writeerror("Error en MostrarPermisos ✖️✖️ " + ex.Message);
            }
        }

        public bool EliminarPermisos(LPermisos parametros)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("EliminarPermisos", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUser", parametros.IdUser);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Log.Writeerror("Error en EliminarPermisos ✖️✖️ " + ex.Message);
                return false;
            }
        }

    }
}
