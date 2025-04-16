using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoOFI.Datos
{
    public class DModulos
    {
        public void MostrarModulos(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Select * from Modulos", Conexion.conectar);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Log.Writeerror("Error al MostrarModulos ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void PermisosUser(ref DataTable dt, int IdUser)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("PermisosUser", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@IdUser", IdUser);

                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en PermisosUser ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
    }
}
