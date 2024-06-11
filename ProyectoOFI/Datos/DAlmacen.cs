using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoOFI.Datos
{
    public class DAlmacen
    {
        public int Contador;
        public void MostrarAlmacen(ref DataTable dt, int desde, int hasta)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarAlmacen", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Desde", desde);
                da.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de Almacén " + ex.Message, "Error en Almacén", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al cargar los datos en MostrarAlmacen ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void ContarTK(ref int contador)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("ConteoAlmacen", Conexion.conectar);
                contador = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                contador = 0;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void VerdetalleTkAlmacen(ref DataTable dt,string Tk)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da=new SqlDataAdapter("VerdetalleTkAlmacen",Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Dato", Tk);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el detalle de ticket Almacén " + ex.Message, "Error Almacén", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al cargar los datos en VerdetalleTkAlmacen ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
    }
}
