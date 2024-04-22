using DocumentFormat.OpenXml.Office2016.Drawing.Charts;
using ProyectoOFI.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOFI.Datos
{
    public class DTendido
    {
        public void MostrarLotesCP(ref DataTable dt, int Desde, int Hasta)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarLotesCP", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Desde", Desde);
                da.SelectCommand.Parameters.AddWithValue("@Hasta", Hasta);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos " + ex.Message, "ERROR Control Patio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarLotesCP ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void ContarTKCP(ref int Contador)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("select COUNT (ticket) from Recepcion where Estado='ACTIVO' AND IdAreaSecado=1", Conexion.conectar);
                Contador = Convert.ToInt32(cmd.ExecuteScalar());
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
        public bool InsertarTendido(LTendido parametros)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("InsertarTendido", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                cmd.Parameters.AddWithValue("@FechaT", parametros.FechaT);
                cmd.Parameters.AddWithValue("@Folio", parametros.Folio);
                cmd.Parameters.AddWithValue("@IdPatio", parametros.IdPatio);
                cmd.Parameters.AddWithValue("@IdUbicacionP", parametros.IdUbicacionP);
                cmd.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Tender el lote " + ex.Message, "ERROR Tendido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en InsertarTendido ✖️✖️ " + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarTendido(LTendido parametros,int edit)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarTendido", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                cmd.Parameters.AddWithValue("@FechaT", parametros.FechaT);
                cmd.Parameters.AddWithValue("@Folio", parametros.Folio);
                cmd.Parameters.AddWithValue("@IdPatio", parametros.IdPatio);
                cmd.Parameters.AddWithValue("@IdUbicacionP", parametros.IdUbicacionP);
                cmd.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                cmd.Parameters.AddWithValue("@Edit", edit);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido editar el registro " + ex.Message, "ERROR al actualizar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en EditarTendido ✖️✖️" + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarDetalleTendido(ref DataTable dt, string Tk)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarDetalleTendido", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Ticket", Tk);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarDetalleTendido ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #region MostrarCombos
        public void MostrarPatio(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarPatio", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                combo.ValueMember = "IdPatio";
                combo.DisplayMember = "Patio";
                combo.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lista.Add(dt.Rows[i]["Patio"].ToString());
                }
                combo.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarPatio ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarPatioUbicacion(ComboBox combo, int IdPatio)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarPatioUbicacion", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@Idpatio", IdPatio);
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                combo.ValueMember = "IdUbicacionP";
                combo.DisplayMember = "UbicacionP";
                combo.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lista.Add(dt.Rows[i]["UbicacionP"].ToString());
                }
                combo.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarPatioUbicacion ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        #endregion
    }
}
