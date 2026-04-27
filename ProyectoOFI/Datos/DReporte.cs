using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoOFI.Datos
{
    public class DReporte
    {
        public double contador;
        public void KilosArea(DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("kilosArea", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos en kilosArea: " + ex.Message,
                    "Error KilosArea", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en kilosArea ✖️✖️ " + ex.Message);
            }
        }

        public void QQsTotal(ref double contador)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT ROUND(SUM(Peso)/46, 2) FROM Recepcion WHERE Estado='ACTIVO'", con))
                {
                    var result = cmd.ExecuteScalar();
                    contador = result != DBNull.Value ? Convert.ToDouble(result) : 0;
                }
            }
            catch
            {
                contador = 0;
            }
        }

        public void QQsSN(ref double sn)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT ROUND(SUM(peso) / 46, 2) 
              FROM Recepcion Rec
              LEFT JOIN Tendido T ON Rec.Ticket = T.Ticket
              WHERE ((Proceso = 'No Asignado' AND IdAreaSecado = 1) 
                  OR ProcesoCP IN ('Tendido','Rechazado','Tendido/Rechazado',
                                   'Enfarde','Analizado','Envio','Envio SM',
                                   'Almacén','Almacen'))
              AND Estado = 'ACTIVO'
              AND Rec.Cosecha = (
                  SELECT Cosecha FROM Cosecha 
                  WHERE IdCosecha = (SELECT MAX(IdCosecha) FROM Cosecha))", con))
                {
                    var result = cmd.ExecuteScalar();
                    sn = result != DBNull.Value ? Convert.ToDouble(result) : 0;
                }
            }
            catch
            {
                sn = 0;
            }
        }

        public void QQsSM(ref double sm)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT ROUND(SUM(Peso)/46, 2) FROM Recepcion Rec WHERE IdAreaSecado = 2 AND Estado='ACTIVO'", con))
                {
                    var result = cmd.ExecuteScalar();
                    sm = result != DBNull.Value ? Convert.ToDouble(result) : 0;
                }
            }
            catch
            {
                sm = 0;
            }
        }

        public void TotalAnalisis(ref double cata)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("TotalAnalisis", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var result = cmd.ExecuteScalar();
                    cata = result != DBNull.Value ? Convert.ToDouble(result) : 0;
                }
            }
            catch
            {
                cata = 0;
            }
        }

        public void DatosSM(DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("DatosSM", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de SM: " + ex.Message,
                    "Error DatosSM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en DatosSM ✖️✖️ " + ex.Message);
            }
        }

        public void DatosSN(DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("DatosSN", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de SN: " + ex.Message,
                    "Error DatosSN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en DatosSN ✖️✖️ " + ex.Message);
            }
        }

        public void No_Asignado(ref DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("No_Asignado", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar lotes No Asignados: " + ex.Message,
                    "Error No_Asignado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en No_Asignado ✖️✖️ " + ex.Message);
            }
        }

        public void Lotes_Tendido(ref DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("Lotes_Tendido", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar lotes Tendido: " + ex.Message,
                    "Error Lotes_Tendido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en Lotes_Tendido ✖️✖️ " + ex.Message);
            }
        }

        public void Lotes_Enfarde(ref DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("Lotes_Enfarde", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar lotes Enfarde: " + ex.Message,
                    "Error Lotes_Enfarde", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en Lotes_Enfarde ✖️✖️ " + ex.Message);
            }
        }

        public void Lotes_Analizados(ref DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("Lotes_Analizados", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar lotes Analizados: " + ex.Message,
                    "Error Lotes_Analizados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en Lotes_Analizados ✖️✖️ " + ex.Message);
            }
        }

        public void Lotes_Enviados(ref DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("Lotes_Enviados", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar lotes Enviados: " + ex.Message,
                    "Error Lotes_Enviados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en Lotes_Enviados ✖️✖️ " + ex.Message);
            }
        }

        public void Lotes_Almacen(ref DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("Lotes_Almacen", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Lotes Almacén: " + ex.Message,
                    "Error Lotes_Almacen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en Lotes_Almacen ✖️✖️ " + ex.Message);
            }
        }

        public void CantNoAsignado(ref double noAsignado)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(Ticket) FROM Recepcion Rec " +
                    "WHERE IdAreaSecado=1 AND Proceso='No asignado' AND Estado='ACTIVO' " +
                    "AND Rec.Cosecha=(SELECT Cosecha FROM Cosecha WHERE IdCosecha=(SELECT MAX(IdCosecha) FROM Cosecha))", con))
                {
                    var result = cmd.ExecuteScalar();
                    noAsignado = result != DBNull.Value ? Convert.ToDouble(result) : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al contar lotes No Asignados: " + ex.Message,
                    "Error CantNoAsignado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en CantNoAsignado ✖️✖️ " + ex.Message);
            }
        }

        public void Lotes_Tendido(ref double tendido)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(Ticket) FROM Recepcion Rec " +
                    "WHERE IdAreaSecado=1 AND Proceso='Tendido' AND Estado='ACTIVO' " +
                    "AND Rec.Cosecha=(SELECT Cosecha FROM Cosecha WHERE IdCosecha=(SELECT MAX(IdCosecha) FROM Cosecha))", con))
                {
                    var result = cmd.ExecuteScalar();
                    tendido = result != DBNull.Value ? Convert.ToDouble(result) : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al contar lotes Tendidos: " + ex.Message,
                    "Error Lotes_Tendido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en Lotes_Tendido ✖️✖️ " + ex.Message);
            }
        }

        public void Lotes_Enfarde(ref double enfarde)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(Ticket) FROM Recepcion Rec " +
                    "WHERE IdAreaSecado=1 AND Proceso='Enfarde' AND Estado='ACTIVO' " +
                    "AND Rec.Cosecha=(SELECT Cosecha FROM Cosecha WHERE IdCosecha=(SELECT MAX(IdCosecha) FROM Cosecha))", con))
                {
                    var result = cmd.ExecuteScalar();
                    enfarde = result != DBNull.Value ? Convert.ToDouble(result) : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al contar lotes Enfardados: " + ex.Message,
                    "Error Lotes_Enfarde", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en Lotes_Enfarde ✖️✖️ " + ex.Message);
            }
        }

        public void Lotes_Analizados(ref double analisis)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(Ticket) FROM Recepcion Rec " +
                    "WHERE IdAreaSecado=1 AND Proceso='Analizado' AND Estado='ACTIVO' " +
                    "AND Rec.Cosecha=(SELECT Cosecha FROM Cosecha WHERE IdCosecha=(SELECT MAX(IdCosecha) FROM Cosecha))", con))
                {
                    var result = cmd.ExecuteScalar();
                    analisis = result != DBNull.Value ? Convert.ToDouble(result) : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al contar lotes Analizados: " + ex.Message,
                    "Error Lotes_Analizados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en Lotes_Analizados ✖️✖️ " + ex.Message);
            }
        }

        public void Lotes_Enviados(ref double envio)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(Ticket) FROM Recepcion Rec " +
                    "WHERE IdAreaSecado=1 AND Proceso IN ('Envio','Envío') AND Estado='ACTIVO' " +
                    "AND Rec.Cosecha=(SELECT Cosecha FROM Cosecha WHERE IdCosecha=(SELECT MAX(IdCosecha) FROM Cosecha))", con))
                {
                    var result = cmd.ExecuteScalar();
                    envio = result != DBNull.Value ? Convert.ToDouble(result) : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al contar lotes Enviados: " + ex.Message,
                    "Error Lotes_Enviados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en Lotes_Enviados ✖️✖️ " + ex.Message);
            }
        }

        public void Lotes_Almacen(ref double almacen)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(Ticket) FROM Recepcion Rec " +
                    "WHERE IdAreaSecado=1 AND Proceso IN ('Almacén','Almacen') AND Estado='ACTIVO' " +
                    "AND Rec.Cosecha=(SELECT Cosecha FROM Cosecha WHERE IdCosecha=(SELECT MAX(IdCosecha) FROM Cosecha))", con))
                {
                    var result = cmd.ExecuteScalar();
                    almacen = result != DBNull.Value ? Convert.ToDouble(result) : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al contar lotes en Almacén: " + ex.Message,
                    "Error Lotes_Almacen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en Lotes_Almacen ✖️✖️ " + ex.Message);
            }
        }

        public void ReporteConsolidados(ref DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("ReporteConsolidados", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Lotes Consolidados: " + ex.Message,
                    "Error ReporteConsolidados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en ReporteConsolidados ✖️✖️ " + ex.Message);
            }
        }

        public void Lotes_POAV(ref DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("Lotes_POAV", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Lotes POAV: " + ex.Message,
                    "Error Lotes_POAV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en Lotes_POAV ✖️✖️ " + ex.Message);
            }
        }

        public void CantLotes_POAV(ref double total)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(Ticket) FROM Recepcion " +
                    "WHERE Estado='ACTIVO' AND Proceso='POAV' " +
                    "AND Cosecha=(SELECT Cosecha FROM Cosecha WHERE IdCosecha=(SELECT MAX(IdCosecha) FROM Cosecha))", con))
                {
                    var result = cmd.ExecuteScalar();
                    total = result != DBNull.Value ? Convert.ToDouble(result) : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al contar lotes POAV: " + ex.Message,
                    "Error CantLotes_POAV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en CantLotes_POAV ✖️✖️ " + ex.Message);
            }
        }

        public void Lotes_Vertical(ref DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("Lotes_Vertical", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Lotes Vertical: " + ex.Message,
                    "Error Lotes_Vertical", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en Lotes_Vertical ✖️✖️ " + ex.Message);
            }
        }

        public void CantLotes_Vertical(ref double total)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(Ticket) FROM Recepcion " +
                    "WHERE Estado='ACTIVO' AND Proceso='Vertical' " +
                    "AND Cosecha=(SELECT Cosecha FROM Cosecha WHERE IdCosecha=(SELECT MAX(IdCosecha) FROM Cosecha))", con))
                {
                    var result = cmd.ExecuteScalar();
                    total = result != DBNull.Value ? Convert.ToDouble(result) : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al contar lotes Vertical: " + ex.Message,
                    "Error CantLotes_Vertical", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en CantLotes_Vertical ✖️✖️ " + ex.Message);
            }
        }

        public void Lotes_POA(ref DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("Lotes_POA", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Lotes POA: " + ex.Message,
                    "Error Lotes_POA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en Lotes_POA ✖️✖️ " + ex.Message);
            }
        }

        public void CantLotes_POA(ref double total)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(P.Ticket) " +
                    "FROM Recepcion Rec " +
                    "INNER JOIN PreSecado Pre ON Rec.Ticket=Pre.Ticket " +
                    "INNER JOIN POA P ON Pre.IDPreSecado=P.IDPreSecado " +
                    "WHERE Estado='ACTIVO' AND ProcesoSF='POA' " +
                    "AND Cosecha=(SELECT Cosecha FROM Cosecha WHERE IdCosecha=(SELECT MAX(IdCosecha) FROM Cosecha))", con))
                {
                    var result = cmd.ExecuteScalar();
                    total = result != DBNull.Value ? Convert.ToDouble(result) : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al contar lotes POA: " + ex.Message,
                    "Error CantLotes_POA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en CantLotes_POA ✖️✖️ " + ex.Message);
            }
        }

        public void Lotes_Guardiola(ref DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("Lotes_Guardiola", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Lotes Guardiola: " + ex.Message,
                    "Error Lotes_Guardiola", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en Lotes_Guardiola ✖️✖️ " + ex.Message);
            }
        }

        public void CantLotes_Guardiola(ref double total)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(P.Ticket) " +
                    "FROM Recepcion Rec " +
                    "INNER JOIN PreSecado Pre ON Rec.Ticket = Pre.Ticket " +
                    "INNER JOIN POA P ON Pre.IDPreSecado = P.IDPreSecado " +
                    "WHERE Estado='ACTIVO' AND ProcesoSF='Guardiola' " +
                    "AND Cosecha = (SELECT Cosecha FROM Cosecha WHERE IdCosecha=(SELECT MAX(IdCosecha) FROM Cosecha))", con))
                {
                    var result = cmd.ExecuteScalar();
                    total = result != DBNull.Value ? Convert.ToDouble(result) : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al contar lotes Guardiola: " + ex.Message,
                    "Error CantLotes_Guardiola", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en CantLotes_Guardiola ✖️✖️ " + ex.Message);
            }
        }

        public void Lotes_PS(ref DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("Lotes_PS", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Lotes PS: " + ex.Message,
                    "Error Lotes_PS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en Lotes_PS ✖️✖️ " + ex.Message);
            }
        }

        public void CantLotes_PS(ref double total)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(P.Ticket) " +
                    "FROM Recepcion Rec " +
                    "INNER JOIN PreSecado Pre ON Rec.Ticket = Pre.Ticket " +
                    "INNER JOIN POA P ON Pre.IDPreSecado = P.IDPreSecado " +
                    "WHERE Estado='ACTIVO' AND ProcesoSF IN ('PS','Analizado') " +
                    "AND Cosecha = (SELECT Cosecha FROM Cosecha WHERE IdCosecha=(SELECT MAX(IdCosecha) FROM Cosecha))", con))
                {
                    var result = cmd.ExecuteScalar();
                    total = result != DBNull.Value ? Convert.ToDouble(result) : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al contar lotes PS: " + ex.Message,
                    "Error CantLotes_PS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en CantLotes_PS ✖️✖️ " + ex.Message);
            }
        }

        public void Lotes_EnviadosSM(ref DataTable dt)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("Lotes_EnviadosSM", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Lotes Enviados SM: " + ex.Message,
                    "Error Lotes_EnviadosSM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en Lotes_EnviadosSM ✖️✖️ " + ex.Message);
            }
        }

        public void CantLotes_EnviadosSM(ref double total)
        {
            try
            {
                using (SqlConnection con = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(P.Ticket) " +
                    "FROM Recepcion Rec " +
                    "INNER JOIN PreSecado Pre ON Rec.Ticket = Pre.Ticket " +
                    "INNER JOIN POA P ON Pre.IDPreSecado = P.IDPreSecado " +
                    "WHERE Estado='ACTIVO' " +
                    "AND ProcesoSF IN ('Envio','Envío','Almacén','Almacen') " +
                    "AND Cosecha = (SELECT Cosecha FROM Cosecha WHERE IdCosecha=(SELECT MAX(IdCosecha) FROM Cosecha))", con))
                {
                    var result = cmd.ExecuteScalar();
                    total = result != DBNull.Value ? Convert.ToDouble(result) : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al contar Lotes Enviados SM: " + ex.Message,
                    "Error CantLotes_EnviadosSM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en CantLotes_EnviadosSM ✖️✖️ " + ex.Message);
            }
        }

    }
}
