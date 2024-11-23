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
        public void Lotes_POAV(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Lotes_POAV", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos de Lotes POAV " + ex.Message, "Error en Lotes POAV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("No se pudieron cargar datos en Lotes_POAV ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void CantLotes_POAV(ref double Tendido)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("Select COUNT(Ticket) from Recepcion where Estado='ACTIVO' AND Proceso='POAV' AND Cosecha = ( SELECT Cosecha FROM Cosecha WHERE IdCosecha = ( SELECT MAX ( IdCosecha ) FROM Cosecha ))", Conexion.conectar);
                Tendido = Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en mostrar cantidad de lotes poav " + ex.Message, "Error En Cantidad de poav", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en mostrar CantLotes_POAV ✖️✖️" + ex.Message);
            }
            finally
            {

                Conexion.cerrar();
            }
        }
        public void Lotes_Vertical(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Lotes_Vertical", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos de Lotes Vertical " + ex.Message, "Error en Lotes Vertical", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("No se pudieron cargar datos en Lotes_Vertical ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void CantLotes_Vertical(ref double Tendido)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("Select COUNT(Ticket) from Recepcion where Estado='ACTIVO' AND Proceso='Vertical' AND Cosecha = ( SELECT Cosecha FROM Cosecha WHERE IdCosecha = ( SELECT MAX ( IdCosecha ) FROM Cosecha ))", Conexion.conectar);
                Tendido = Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en mostrar cantidad de lotes Vertical " + ex.Message, "Error En Cantidad de Vertical", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en mostrar CantLotes_Vertical ✖️✖️" + ex.Message);
            }
            finally
            {

                Conexion.cerrar();
            }
        }
        public void Lotes_POA(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Lotes_POA", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos de Lotes POA " + ex.Message, "Error en Lotes POA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("No se pudieron cargar datos en Lotes_POA ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void CantLotes_POA(ref double Lote)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("Select COUNT(P.Ticket) from Recepcion Rec INNER JOIN PreSecado Pre ON Rec.Ticket=Pre.Ticket INNER JOIN POA P ON Pre.IDPreSecado=p.IDPreSecado where Estado='ACTIVO' AND ProcesoSF='POA' AND Cosecha = ( SELECT Cosecha FROM Cosecha WHERE IdCosecha = ( SELECT MAX ( IdCosecha ) FROM Cosecha ))", Conexion.conectar);
                Lote = Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en mostrar cantidad de lotes POA " + ex.Message, "Error En Cantidad de POA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en mostrar CantLotes_POA ✖️✖️" + ex.Message);
            }
            finally
            {

                Conexion.cerrar();
            }
        }
        public void Lotes_Guardiola(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Lotes_Guardiola", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos de Lotes Guardiola " + ex.Message, "Error en Lotes Guardiola", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("No se pudieron cargar datos en Lotes_Guardiola ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void CantLotes_Guardiola(ref double Lote)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("Select COUNT(P.Ticket) from Recepcion Rec INNER JOIN PreSecado Pre ON Rec.Ticket=Pre.Ticket INNER JOIN POA P ON Pre.IDPreSecado=p.IDPreSecado where Estado='ACTIVO' AND ProcesoSF='Guardiola' AND Cosecha = ( SELECT Cosecha FROM Cosecha WHERE IdCosecha = ( SELECT MAX ( IdCosecha ) FROM Cosecha ))", Conexion.conectar);
                Lote = Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en mostrar cantidad de lotes Guardiola " + ex.Message, "Error En Cantidad de Guardiola", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en mostrar CantLotes_Guardiola ✖️✖️" + ex.Message);
            }
            finally
            {

                Conexion.cerrar();
            }
        }
        public void Lotes_PS(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Lotes_PS", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos de Lotes PS " + ex.Message, "Error en Lotes PS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("No se pudieron cargar datos en Lotes_PS ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void CantLotes_PS(ref double Lote)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("Select COUNT(P.Ticket) from Recepcion Rec INNER JOIN PreSecado Pre ON Rec.Ticket=Pre.Ticket INNER JOIN POA P ON Pre.IDPreSecado=p.IDPreSecado where Estado='ACTIVO' AND ProcesoSF in ('PS','Analizado') AND Cosecha = ( SELECT Cosecha FROM Cosecha WHERE IdCosecha = ( SELECT MAX ( IdCosecha ) FROM Cosecha ))", Conexion.conectar);
                Lote = Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en mostrar cantidad de lotes PS " + ex.Message, "Error En Cantidad de PS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en mostrar CantLotes_PS ✖️✖️" + ex.Message);
            }
            finally
            {

                Conexion.cerrar();
            }
        }
        public void Lotes_EnviadosSM(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Lotes_EnviadosSM", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos de Lotes Enviados SM " + ex.Message, "Error en Lotes Enviados SM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("No se pudieron cargar datos en Lotes_EnviadosSM ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void CantLotes_EnviadosSM(ref double Lote)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("Select COUNT(P.Ticket) from Recepcion Rec INNER JOIN PreSecado Pre ON Rec.Ticket=Pre.Ticket INNER JOIN POA P ON Pre.IDPreSecado=p.IDPreSecado where Estado='ACTIVO' AND ProcesoSF in ('Envio','Envío','Almacén','Almacen') AND Cosecha = ( SELECT Cosecha FROM Cosecha WHERE IdCosecha = ( SELECT MAX ( IdCosecha ) FROM Cosecha ))", Conexion.conectar);
                Lote = Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en mostrar cantidad de Lotes Enviados SM " + ex.Message, "Error En Cantidad de Lotes Enviados SM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en mostrar CantLotes_EnviadosSM ✖️✖️" + ex.Message);
            }
            finally
            {

                Conexion.cerrar();
            }
        }
    }
}
