using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoOFI.Logica;

namespace ProyectoOFI.Datos
{
    public  class DPS
    {
        public DataTable MostrarPS()
        {
            DataTable tablaTickets = new DataTable();
            try
            {
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarPS", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                tablaTickets.Load(da.ExecuteReader());
                return tablaTickets;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
                Log.Writeerror("No se ha podido cargar los datos en MostrarPS" + ex.Message);
                return tablaTickets;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool InsertarPS(LPS parametros)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("InsertarPS", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdGuardiola", parametros.IdGuardiola);
                cmd.Parameters.AddWithValue("@PS", parametros.PS);
                cmd.Parameters.AddWithValue("@FechaPS", parametros.FechaPS);
                cmd.Parameters.AddWithValue("@HoraIniPS", parametros.HoraIniPS);
                cmd.Parameters.AddWithValue("@HoraFinPS ", parametros.HoraFinPS);
                cmd.Parameters.AddWithValue("@HumedadPS ", parametros.HumedadPS);
                cmd.Parameters.AddWithValue("@ParosPS", parametros.ParosPS);
                cmd.Parameters.AddWithValue("@ObservacionSF", parametros.Observacion);
                cmd.Parameters.AddWithValue("@TiempoSF", parametros.TiempoSF);
                cmd.Parameters.AddWithValue("@TiempoTotal", parametros.TiempoTotal);
                cmd.Parameters.AddWithValue("@IdOperador ", parametros.IdOperador);
                cmd.Parameters.AddWithValue("@IdTurno", parametros.IdTurno);
                cmd.Parameters.AddWithValue("@DigitadorPS ", parametros.DigitadorPS);
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Insertar los datos " + ex.Message, "ERROR InsertarPS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al Insertar los datos en InsertarPS ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
    }
}
