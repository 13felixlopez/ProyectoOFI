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
    public class DPOA
    {
        public DataTable MostrarPOA()
        {
            DataTable tablaTickets = new DataTable();
            try
            {
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarPOA", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                tablaTickets.Load(da.ExecuteReader());
                return tablaTickets;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
                Log.Writeerror("No se ha podido cargar los datos en MostrarPOA" + ex.Message);
                return tablaTickets;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void CargarPOA(string TK, DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlCommand da = new SqlCommand("CargarPOA", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@TK", TK);
                SqlDataAdapter cb = new SqlDataAdapter(da);
                cb.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
    }
}
