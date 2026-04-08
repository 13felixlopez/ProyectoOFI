using ProyectoOFI.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProyectoOFI.Datos
{
    public class DUsuarios
    {
        public bool InsertarUsuario(LUsuarios parametros)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("InsertarUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreA", parametros.NombreA);
                    cmd.Parameters.AddWithValue("@Pass", parametros.Pass);
                    cmd.Parameters.AddWithValue("@Estado", parametros.Estado);
                    cmd.Parameters.AddWithValue("@Correo", parametros.Correo);
                    cmd.Parameters.AddWithValue("@Login", parametros.Login);
                    cmd.Parameters.AddWithValue("@Patio", parametros.Patio);
                    cmd.Parameters.AddWithValue("@Cargo", parametros.Cargo);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar usuario: " + ex.Message,
                    "Error InsertarUsuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en InsertarUsuario ✖️✖️ " + ex.Message);
                return false;
            }
        }

        public void MostrarUsuarios(ref DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("MostrarUsuarios", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar usuarios: " + ex.Message,
                    "Error MostrarUsuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarUsuarios ✖️✖️ " + ex.Message);
            }
        }

        public void ObtenerIdUser(ref int IdUser, string login)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("ObtenerIdUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Login", login);
                    IdUser = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener IdUser: " + ex.Message,
                    "Error ObtenerIdUser", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en ObtenerIdUser ✖️✖️ " + ex.Message);
            }
        }

        public void VerificarUsuario(ref string Indicador, string db)
        {
            try
            {
                if (!Regex.IsMatch(db, @"^[\w]+$"))
                {
                    Indicador = "Nombre de base de datos inválido";
                    return;
                }

                string query = $@"
            SELECT TOP 1 TABLE_NAME 
            FROM {EscapeDatabaseName(db)}.INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_TYPE = 'BASE TABLE'";

                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    var resultado = cmd.ExecuteScalar();
                    Indicador = (resultado != null)
                        ? "Correcto. Primera tabla: " + resultado
                        : "No se encontraron tablas.";
                }
            }
            catch (Exception ex)
            {
                Indicador = "Error de conexión: " + ex.Message;
                Log.Writeerror("Error en VerificarUsuario ✖️✖️ " + ex.Message);
            }
        }



        // Función para escapar nombres de bases de datos de forma segura
        private string EscapeDatabaseName(string dbName)
        {
            // Usamos QUOTENAME para prevenir inyección SQL y manejar nombres especiales
            return $"[{dbName.Replace("]", "]]")}]";
        }
        public DataTable D_Usuarios(LUsuarios parametros)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("Login", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Login", parametros.Login);
                    cmd.Parameters.AddWithValue("@Pass", parametros.Pass);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool EliminarUser(int IdUser)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("EliminarUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUser", IdUser);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al eliminar el Usuario: " + ex.Message,
                                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en EliminarUser ✖️✖️ " + ex.Message);
                return false;
            }
        }

        public bool EditarUser(LUsuarios parametros)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("EditarUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUser", parametros.IdUser);
                    cmd.Parameters.AddWithValue("@NombreApellidos", parametros.NombreA);
                    cmd.Parameters.AddWithValue("@Correo", parametros.Correo);
                    cmd.Parameters.AddWithValue("@Login", parametros.Login);
                    cmd.Parameters.AddWithValue("@Pass", parametros.Pass);
                    cmd.Parameters.AddWithValue("@Patio", parametros.Patio);
                    cmd.Parameters.AddWithValue("@Cargo", parametros.Cargo);
                    cmd.Parameters.AddWithValue("@Estado", parametros.Estado);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar usuario: " + ex.Message,
                                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en EditarUser ✖️✖️ " + ex.Message);
                return false;
            }
        }

        public void MostrarUsuarioLogueado(DataTable dt, int Iduser)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("MostrarUsuarioLogueado", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@IdUser", Iduser);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos del usuario: " + ex.Message,
                                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarUsuarioLogueado ✖️✖️ " + ex.Message);
            }
        }

        public List<string> BuscarCargos(string filtro)
        {
            var cargos = new List<string>();

            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT DISTINCT Cargo FROM Usuarios WHERE Cargo LIKE @q + '%'", con))
                {
                    cmd.Parameters.AddWithValue("@q", filtro);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                                cargos.Add(reader.GetString(0));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar cargos: " + ex.Message,
                                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en BuscarCargos ✖️✖️ " + ex.Message);
            }

            return cargos;
        }


    }
}
