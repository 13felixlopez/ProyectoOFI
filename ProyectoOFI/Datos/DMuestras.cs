using ProyectoOFI.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoOFI.Datos
{
    public class DMuestras
    {
        public int Contador;
        public void ObtenerMuestras(string TK, ref DataTable dt, int Contar)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("ObtenerMuestras", conectar))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ticket", TK);

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
                Log.Writeerror("Error en ObtenerMuestras ✖️✖️" + ex.Message);
            }
        }
        public void GuardarMuestrasEnBD(List<LMuestras> muestras)
        {
            using (SqlConnection conexion = Conexion.abrir())
            using (SqlCommand cmd = new SqlCommand("UpsertMuestras", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Crear DataTable para el parámetro table-valued
                DataTable dtMuestras = new DataTable();
                dtMuestras.Columns.Add("IdMuestra", typeof(int));
                dtMuestras.Columns.Add("Ticket", typeof(string));
                dtMuestras.Columns.Add("FechaMuestra", typeof(DateTime));
                dtMuestras.Columns.Add("Muestriado", typeof(bool));

                // Llenar el DataTable con los datos temporales
                foreach (var muestra in muestras)
                {
                    dtMuestras.Rows.Add(muestra.IdMuestra, muestra.Ticket, muestra.FechaMuestra, muestra.Muestriado);
                }

                // Agregar parámetro
                SqlParameter param = new SqlParameter("@Muestras", SqlDbType.Structured)
                {
                    TypeName = "dbo.MuestraTableType",
                    Value = dtMuestras
                };
                cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@Usuario", Login.NombreA);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
