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
                SqlCommand cmd = new SqlCommand("  SELECT ROUND(SUM(peso) / 46, 2) AS Resultado FROM Recepcion Rec " +
                    "LEFT JOIN Tendido T ON Rec.Ticket = T.Ticket WHERE ((Proceso = 'No Asignado' AND IdAreaSecado = 1) " +
                    "OR ProcesoCP IN ('Tendido', 'Rechazado', 'Tendido/Rechazado', 'Enfarde', 'Analizado', 'Envio', 'Envio SM', 'Almacén', 'Almacen')) " +
                    "AND Estado = 'ACTIVO' AND Rec.Cosecha = (SELECT Cosecha FROM Cosecha WHERE IdCosecha = (SELECT MAX(IdCosecha) FROM Cosecha));", Conexion.conectar);
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
        public void Lotes_Tendido(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Lotes_Tendido", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos de Lotes Tendido " + ex.Message, "Error en Lotes Tendido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("No se pudieron cargar datos en Lotes_Tendido ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void Lotes_Enfarde(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Lotes_Enfarde", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos de Lotes Enfarde " + ex.Message, "Error en Lotes Enfarde", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("No se pudieron cargar datos en Lotes_Enfarde ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void Lotes_Analizados(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Lotes_Analizados", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos de Lotes Analizados " + ex.Message, "Error en Lotes Analizados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("No se pudieron cargar datos en Lotes_Analizados ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void Lotes_Enviados(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Lotes_Enviados", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos de Lotes Enviados " + ex.Message, "Error en Lotes Enviados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("No se pudieron cargar datos en Lotes_Enviados ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void Lotes_Almacen(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Lotes_Almacen", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos de Lotes Almacén " + ex.Message, "Error en Lotes Almacén", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("No se pudieron cargar datos en Lotes_Almacen ✖️✖️ " + ex.Message);
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
        public void Lotes_Tendido(ref double Tendido)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("Select COUNT(Ticket) from Recepcion Rec where IdAreaSecado=1 AND Proceso='Tendido' and Estado='ACTIVO' And Rec.Cosecha=(select Cosecha from Cosecha where IdCosecha=(select max(IdCosecha) from Cosecha))", Conexion.conectar);
                Tendido = Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en mostrar cantidad de lotes Tendidos " + ex.Message, "Error En Cantidad de Tendidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en mostrar Lotes_Enfarde ✖️✖️" + ex.Message);
            }
            finally
            {

                Conexion.cerrar();
            }
        }
        public void Lotes_Enfarde(ref double Enfarde)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("Select COUNT(Ticket) from Recepcion Rec where IdAreaSecado=1 AND Proceso='Enfarde' and Estado='ACTIVO' And Rec.Cosecha=(select Cosecha from Cosecha where IdCosecha=(select max(IdCosecha) from Cosecha))", Conexion.conectar);
                Enfarde = Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en mostrar cantidad de lotes Enfardados " + ex.Message, "Error En Cantidad de Lotes Enfardados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en mostrar Lotes_Enfarde ✖️✖️" + ex.Message);
            }
            finally
            {

                Conexion.cerrar();
            }
        }
        public void Lotes_Analizados(ref double Analisis)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("Select COUNT(Ticket) from Recepcion Rec where IdAreaSecado=1 AND Proceso='Analizado' and Estado='ACTIVO' And Rec.Cosecha=(select Cosecha from Cosecha where IdCosecha=(select max(IdCosecha) from Cosecha))", Conexion.conectar);
                Analisis = Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en mostrar cantidad de lotes Analizado " + ex.Message, "Error En Cantidad de Lotes Analizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en mostrar Lotes_Analizados ✖️✖️" + ex.Message);
            }
            finally
            {

                Conexion.cerrar();
            }
        }
        public void Lotes_Enviados(ref double Envio)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("Select COUNT(Ticket) from Recepcion Rec where IdAreaSecado=1 AND Proceso in ('Envio','Envío') and Estado='ACTIVO' And Rec.Cosecha=(select Cosecha from Cosecha where IdCosecha=(select max(IdCosecha) from Cosecha))", Conexion.conectar);
                Envio = Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en mostrar cantidad de lotes Enviados " + ex.Message, "Error En Cantidad de Lotes Enviados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en mostrar Lotes_Enviados ✖️✖️" + ex.Message);
            }
            finally
            {

                Conexion.cerrar();
            }
        }
        public void Lotes_Almacen(ref double Almacen)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("Select COUNT(Ticket) from Recepcion Rec where IdAreaSecado=1 AND Proceso in ('Almacén','Almacen') and Estado='ACTIVO' And Rec.Cosecha=(select Cosecha from Cosecha where IdCosecha=(select max(IdCosecha) from Cosecha))", Conexion.conectar);
                Almacen = Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en mostrar cantidad de lotes Almacén " + ex.Message, "Error En Cantidad de Lotes Almacén", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en mostrar Lotes_Almacen ✖️✖️" + ex.Message);
            }
            finally
            {

                Conexion.cerrar();
            }
        }
        public void ReporteConsolidados(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("ReporteConsolidados", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos de Lotes Consolidados " + ex.Message, "Error en Lotes Consolidados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("No se pudieron cargar datos en ReporteConsolidados ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
    }
}
