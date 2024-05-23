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
    public class DPS
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
        public void CargarPS(string TK, DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlCommand da = new SqlCommand("CargarPS", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@TK", TK);
                SqlDataAdapter cb = new SqlDataAdapter(da);
                cb.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("No se pudieron cargar los datos en CargarPS ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool InsertarEnvioSM(LPS parametros, int IDPS)
        {
            try
            {
                Conexion.abrir();
                SqlCommand da = new SqlCommand("InsertarEnvioSM", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@IdPS", parametros.IdPS);
                da.Parameters.AddWithValue("@IdOperador", parametros.IdOperador);
                da.Parameters.AddWithValue("@IdTurno", parametros.IdTurno);
                da.Parameters.AddWithValue("@FechaEn", parametros.FechaPS);
                da.Parameters.AddWithValue("@DigitadorPS", parametros.DigitadorPS);
                da.Parameters.AddWithValue("@DNIN", parametros.DNIN);
                da.Parameters.AddWithValue("@IdArea", parametros.IdArea);
                da.Parameters.AddWithValue("@IdEstFis", parametros.IdEstFis);
                da.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar el Envio hacia Almacén " + ex.Message, "Error Envio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en InsertarEnvioSM ✖️✖️ " + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarAreaSecado(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("select IdAreaSecado,AreaSecado from AreaSecado where IdAreaSecado IN (1,5)", Conexion.conectar);
                da.CommandType = CommandType.Text;
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                combo.ValueMember = "IdAreaSecado";
                combo.DisplayMember = "AreaSecado";
                combo.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lista.Add(dt.Rows[i]["AreaSecado"].ToString());
                }
                combo.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarAreaSecado ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarEstFis(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("SELECT IdestFis, EstFisico FROM EstFisico WHERE IdestFis IN (4, 6)", Conexion.conectar);
                da.CommandType = CommandType.Text;
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                combo.ValueMember = "IdestFis";
                combo.DisplayMember = "EstFisico";
                combo.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lista.Add(dt.Rows[i]["EstFisico"].ToString());
                }
                combo.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarEstFis ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
    }
}
