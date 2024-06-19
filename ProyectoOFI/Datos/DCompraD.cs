using ProyectoOFI.Logica;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoOFI.Datos
{
    public class DCompraD
    {
        public bool InsertarCompraDirecta(LComprasD parametros)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("InsertarCompraDirecta", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cosecha", parametros.Cosecha);
                cmd.Parameters.AddWithValue("@Remision", parametros.Remision);
                cmd.Parameters.AddWithValue("@Proveedor", parametros.Proveedor);
                cmd.Parameters.AddWithValue("@KgsRem", parametros.KgsRem);
                cmd.Parameters.AddWithValue("@Tally", parametros.Tally);
                cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                cmd.Parameters.AddWithValue("@IdEmpaque", parametros.IdEmpaque);
                cmd.Parameters.AddWithValue("@Sacos", parametros.Sacos);
                cmd.Parameters.AddWithValue("@Kilos", parametros.Kilos);
                cmd.Parameters.AddWithValue("@Diferencia", parametros.Diferencia);
                cmd.Parameters.AddWithValue("@IdBodega", parametros.IdBodega);
                cmd.Parameters.AddWithValue("@IdUbicacion", parametros.IdUbicacion);
                cmd.Parameters.AddWithValue("@IdCompra", parametros.IdCompra);
                cmd.Parameters.AddWithValue("@IdCertificacion", parametros.IdCertificacion);
                cmd.Parameters.AddWithValue("@Estado", parametros.Estado);
                cmd.Parameters.AddWithValue("@Usuario", Login.NombreA);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar los datos en CompraDirecta: " + ex.Message, "Error en CompraDirecta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en InsertarCompraDirecta ✖️✖️ " + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarComprasD(ref DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarComprasD", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de compras directas " + ex.Message, "Error Compras Directas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al cargar datos en MostrarComprasD ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
    }
}
