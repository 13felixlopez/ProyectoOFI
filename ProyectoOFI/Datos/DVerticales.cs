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
    internal class DVerticales
    {
        public void CargarTk(ComboBox cb)
        {
            Conexion.abrir();
            SqlCommand cmd = new SqlCommand("MostrarTkV", Conexion.conectar);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb.Items.Add(dr["Ticket"].ToString());
            }
            cb.SelectedItem = 0;
            Conexion.cerrar();
        }
        public bool InsertarVertical(LVertical parametros)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_Vertical", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDV", parametros.IDV);
                cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                cmd.Parameters.AddWithValue("@Ver", parametros.Ver);
                cmd.Parameters.AddWithValue("@OperadorV", parametros.OperadorV);
                cmd.Parameters.AddWithValue("@TurnoV", parametros.TurnoV);
                cmd.Parameters.AddWithValue("@FRecibidoV", parametros.FRecibidoV);
                cmd.Parameters.AddWithValue("@HrInicioV", parametros.HrInicoV);
                cmd.Parameters.AddWithValue("@HrFin", parametros.HrFin);
                cmd.Parameters.AddWithValue("@Duracion", parametros.Duracion);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
    }
}
