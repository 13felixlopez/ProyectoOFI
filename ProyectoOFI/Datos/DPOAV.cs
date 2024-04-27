using ProyectoOFI.Logica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOFI.Datos
{
    public class DPOAV
    {
        public bool InsertarPOAV(LPOAV parametros)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("InsertarPOAV", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", parametros.ID);
                cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                cmd.Parameters.AddWithValue("@POAV", parametros.POAV);
                cmd.Parameters.AddWithValue("@IdOperador", parametros.OperadorPV);
                cmd.Parameters.AddWithValue("@TurnoPV", parametros.TurnoPV);
                cmd.Parameters.AddWithValue("@FRecibidoPV", parametros.FRecibidoPV);
                cmd.Parameters.AddWithValue("@HumedadPV", parametros.HumedadPV);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
                Log.Writeerror("Error en InsertarPOAV ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
    }
}
