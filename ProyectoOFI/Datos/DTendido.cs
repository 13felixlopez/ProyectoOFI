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
    public class DTendido
    {
        public void MostrarLotesCP(ref DataTable dt,int Desde, int Hasta)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarLotesCP", Conexion.conectar);
                da.SelectCommand.CommandType=CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Desde", Desde);
                da.SelectCommand.Parameters.AddWithValue("@Hasta",Hasta);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos "+ex.Message,"ERROR Control Patio",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarLotesCP ✖️✖️" + ex.Message);
            } 
            finally
            {
                Conexion.cerrar();
            }
        }
        public void ContarTKCP(ref int Contador)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("select COUNT (ticket) from Recepcion where Estado='ACTIVO' AND IdAreaSecado=1", Conexion.conectar);
                Contador = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                Contador = 0;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
    }
}
