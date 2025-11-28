using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoOFI.Datos
{
    public class DHistorial
    {
        public int Contador;
        public void MostrarHistorial(ref DataTable dt, int desde, int hasta)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("MostrarHistorial", conectar))
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
                Log.Writeerror("Error al MostrarHistorial ✖️✖️" + ex.Message);
            }
        }
        public void ExcelHistorial(ref DataTable dt)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("ExcelHistorial", conectar))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al ExcelHistorial ✖️✖️" + ex.Message);
            }
        }
        public void ContarHistorial(ref int Contador)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(IdHistorial) FROM Historial", conectar))
                {
                    Contador = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception)
            {
                Contador = 0;
            }
        }

        public void BuscarHistorial(string Buscar, string Dato, ref DataTable dt, int desde, int hasta, int Contar)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("BuscarHistorial", conectar))
                {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en BuscarHistorial ✖️✖️" + ex.Message);
            }
        }
        public void BuscarHistorialFecha(ref DataTable dt, DateTime FInicio, DateTime FFin, int desde, int hasta, int Contar)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("BuscarHistorialFecha", conectar))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Desde", desde);
                    cmd.Parameters.AddWithValue("@Hasta", hasta);
                    cmd.Parameters.AddWithValue("@FInicio", FInicio);
                    cmd.Parameters.AddWithValue("@FFin", FFin);
                    SqlParameter contarparam = new SqlParameter("@Contar", SqlDbType.Int);
                    contarparam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(contarparam);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    Contar = Convert.ToInt32(contarparam.Value);
                    Contador = Contar;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en BuscarHistorialFecha ✖️✖️" + ex.Message);
            }
        }
        public void MostrarUsuarios(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                string consulta = "select distinct Usuario from Historial";
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand da = new SqlCommand(consulta, conectar))
                {
                    SqlDataAdapter cb = new SqlDataAdapter(da);
                    DataTable dt = new DataTable();
                    cb.Fill(dt);
                    combo.ValueMember = "Usuario";
                    combo.DisplayMember = "Usuario";
                    combo.DataSource = dt;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        lista.Add(dt.Rows[i]["Usuario"].ToString());
                    }
                    combo.AutoCompleteCustomSource = lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarUsuarios ✖️✖️" + ex.Message);
            }
        }
        public void MostrarDigitacion(ref DataTable dt, DateTime Fecha)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("Digitacion", conectar))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Fecha", Fecha);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al mostrar Digitacion ✖️✖️" + ex.Message);
            }
        }
        public void CambioUbi(ref DataTable dt)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlDataAdapter cmd = new SqlDataAdapter("Select Fecha,Observacion from Historial where Observacion like 'Cambio%' order by Fecha DESC", conectar))
                {
                    cmd.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al mostrar CambioUbi ✖️✖️" + ex.Message);
            }
        }
    }
}
