using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoOFI.Datos
{
    public class DReporte
    {
        public double contador;
        public void kilosArea(DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("kilosArea", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos al gráfico", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al cargar los datos en kilosArea ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void QQsTotal(ref double Contador)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("Select FORMAT(SUM(Peso)/46, 'N2') from Recepcion where IdAreaSecado=1 OR IdAreaSecado=2", Conexion.conectar);
                Contador = Convert.ToDouble(cmd.ExecuteScalar());
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
        public void QQsSN(ref double SN)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("SELECT FORMAT(SUM(Peso)/46, 'N2') FROM Recepcion Rec WHERE IdAreaSecado = 1",Conexion.conectar);
                SN=Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                SN = 0;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void QQsSM(ref double SM)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("SELECT FORMAT(SUM(Peso)/46, 'N2') FROM Recepcion Rec WHERE IdAreaSecado = 2", Conexion.conectar);
                SM = Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                SM = 0;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void TotalAnalisis(ref double Cata)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("TotalAnalisis", Conexion.conectar);
                Cata= Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                Cata = 0;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
    }
}
