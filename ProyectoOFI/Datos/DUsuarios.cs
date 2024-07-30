using ProyectoOFI.Logica;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoOFI.Datos
{
    public class DUsuarios
    {
        public bool InsertarUsuario(LUsuarios parametros)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("InsertarUsuario", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreA", parametros.NombreA);
                cmd.Parameters.AddWithValue("@Pass", parametros.Pass);
                cmd.Parameters.AddWithValue("@Estado", "ACTIVO");
                cmd.Parameters.AddWithValue("@Correo", parametros.Correo);
                cmd.Parameters.AddWithValue("@Login", parametros.Login);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Log.Writeerror("Se produjo un error en InsertarUsuario DUsuario ❌❌");
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarUsuarios(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarUsuarios", Conexion.conectar);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Log.Writeerror("Error al cargar MostrarUsuarios DUsuarios ✖️✖️");
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void ObtenerIdUser(ref int IdUser, string login)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("ObtenerIdUser", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Login", login);
                IdUser = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Log.Writeerror("Error Al ObtenerIdUser DUsarios ✖️✖️");
            }
            finally { Conexion.cerrar(); }
        }
        public void VerificarUsuario(ref string Indicador)
        {
            try
            {
                int IdUser;
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("Select IdUser from Usuarios", Conexion.conectar);
                IdUser = Convert.ToInt32(cmd.ExecuteScalar());
                Conexion.cerrar();
                Indicador = "Correcto";
            }
            catch (Exception)
            {
                Indicador = "Incorrecto";
            }
        }
        public DataTable D_Usuarios(LUsuarios parametros)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("Login", Conexion.conectar)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Login", parametros.Login);
                cmd.Parameters.AddWithValue("@Pass", parametros.Pass);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw new Exception("Datos incorrectos");
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EliminarUser(int IdUser)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarUser", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUser", IdUser);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un erro al eliminar el Ususario, " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en EliminarUser DUsuario ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarUser(LUsuarios parametros)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarUser", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUser", parametros.IdUser);
                cmd.Parameters.AddWithValue("@NombreApellidos", parametros.NombreA);
                cmd.Parameters.AddWithValue("@Correo", parametros.Correo);
                cmd.Parameters.AddWithValue("@Login", parametros.Login);
                cmd.Parameters.AddWithValue("@Pass", parametros.Pass);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Log.Writeerror("Error EditarUser Dusuario ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarUsuarioLogueado(DataTable dt, int Iduser)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarUsuarioLogueado", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@IdUser", Iduser);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos del usuario " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al MostrarUsuarioLogueado DUsuario ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
    }
}
