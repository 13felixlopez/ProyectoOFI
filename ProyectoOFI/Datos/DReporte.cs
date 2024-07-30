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
                SqlCommand cmd = new SqlCommand("SELECT ROUND(SUM(Peso)/46, 2) AS Resultado FROM Recepcion WHERE Estado='ACTIVO'", Conexion.conectar);
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
                SqlCommand cmd = new SqlCommand("SELECT ROUND(SUM(Peso)/46, 2) FROM Recepcion Rec WHERE IdAreaSecado = 1 AND Estado='ACTIVO'", Conexion.conectar);
                SN = Convert.ToDouble(cmd.ExecuteScalar());
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
                SqlCommand cmd = new SqlCommand("SELECT ROUND(SUM(Peso)/46, 2) FROM Recepcion Rec WHERE IdAreaSecado = 2 AND Estado='ACTIVO'", Conexion.conectar);
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
                Cata = Convert.ToDouble(cmd.ExecuteScalar());
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
        public void DatosSM(DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("DatosSM", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de SM " + ex.Message, "Error en reporte SM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al cargar datos de DatosSM ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void DatosSN(DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("DatosSN", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos al gráfico", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al cargar los datos en DatosSN ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void No_Asignado(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("No_Asignado", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos de lotes No asignados " + ex.Message, "Error en No Asignado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("No se pudieron cargar datos en No_Asignado ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void CantNoAsignado(ref double NoAsignado)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("Select COUNT(Ticket) from Recepcion Rec where IdAreaSecado=1 AND Proceso='No asignado' and Estado='ACTIVO' And Rec.Cosecha=(select Cosecha from Cosecha where IdCosecha=(select max(IdCosecha) from Cosecha))", Conexion.conectar);
                NoAsignado = Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en mostrar cantidad de lotes No asignados " + ex.Message, "Error En Cantidad de No asignados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en mostrar CantNoAsignado ✖️✖️" + ex.Message);
            }
            finally
            {

                Conexion.cerrar();
            }
        }
    }
}
