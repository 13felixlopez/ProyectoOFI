using ProyectoOFI.Logica;
using System;
using System.Data;
using System.Data.SqlClient;
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
                cmd.Parameters.AddWithValue("@TurnoPV", parametros.TurnoPV);
                cmd.Parameters.AddWithValue("@FRecibidoPV", parametros.FRecibidoPV);
                cmd.Parameters.AddWithValue("@HumedadPV", parametros.HumedadPV);
                cmd.Parameters.AddWithValue("@DigitadorPOA", parametros.DigitadorPOA);
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
        public void MostrarTurno(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarTurno", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                combo.ValueMember = "IdTurnos";
                combo.DisplayMember = "Turno";
                combo.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lista.Add(dt.Rows[i]["Turno"].ToString());
                }
                combo.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarTurnos ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
    }
}
