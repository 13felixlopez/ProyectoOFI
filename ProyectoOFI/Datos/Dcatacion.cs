using ProyectoOFI.Logica;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoOFI.Datos
{
    public class Dcatacion
    {
        public int Contador;
        public void MostrarCata(ref DataTable dt, int desde, int hasta)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarCata", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Desde", desde);
                da.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar Lotes para catación " + ex.Message, "ERROR Catación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarCata ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        internal void ContarTK(ref int contador)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("select COUNT (Rec.Ticket) from Recepcion Rec " +
                    "LEFT JOIN PreSecado Pre ON Rec.Ticket=Pre.Ticket LEFT JOIN POA P ON Pre.IDPreSecado=P.IDPreSecado " +
                    "where Estado = 'ACTIVO' AND (Proceso = 'Enfarde' OR Proceso = 'PS' OR Proceso = 'Envio' OR Proceso = 'Compra Directa') " +
                    "AND Cosecha=(select Cosecha from Cosecha where IdCosecha=(select max(IdCosecha) from Cosecha))",
                    Conexion.conectar);
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
        public void VerDetalleCatacion(ref DataTable dt, string Ticket, string TkSM)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("VerDetalleCatacion", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Ticket", Ticket);
                da.SelectCommand.Parameters.AddWithValue("@TkSM", TkSM);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar el detalle de la Ticket " + ex.Message, "Error Detalle Catación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en mostrar datos en VerDetalleCatacion ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarVariedad(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarVariedades", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                combo.ValueMember = "IdVariedad";
                combo.DisplayMember = "Variedad";
                combo.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lista.Add(dt.Rows[i]["Variedad"].ToString());
                }
                combo.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarVariedades ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void SeleccionarScore(int score, Label Tasa, Label Calidad)
        {
            try
            {
                Conexion.abrir();
                SqlCommand da = new SqlCommand("SeleccionarScore", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@score", score);
                SqlDataReader dr = da.ExecuteReader();
                if (dr.Read())
                {
                    Tasa.Text = dr["Tasa"].ToString();
                    Calidad.Text = dr["GrupoCalidad"].ToString();
                }
                else
                {
                    MessageBox.Show("No se encontraron resultados para el score especificado.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Score fuera del rango " + ex.Message, "Error SeleccionarScore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en cargar datos SeleccionarScore✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool InsertarCatacion(LCatacion parametros)
        {
            try
            {
                Conexion.abrir();
                SqlCommand da = new SqlCommand("InsertarCatacion", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                da.Parameters.AddWithValue("@Origen", parametros.Origen);
                da.Parameters.AddWithValue("@FechaMuestra", parametros.FechaMuestra);
                da.Parameters.AddWithValue("@FechaCatacion", parametros.FechaCatacion);
                da.Parameters.AddWithValue("@Dias", parametros.Dias);
                da.Parameters.AddWithValue("@RmtoObto", parametros.RmtoObto);
                da.Parameters.AddWithValue("@Cascarilla", parametros.Cascarilla);
                da.Parameters.AddWithValue("@TotalPS", parametros.TotalPS);
                da.Parameters.AddWithValue("@IdVariedad", parametros.IdVariedad);
                da.Parameters.AddWithValue("@Humedad", parametros.Humedad);
                da.Parameters.AddWithValue("@Exp", parametros.Exp);
                da.Parameters.AddWithValue("@DesmA", parametros.DesmA);
                da.Parameters.AddWithValue("@DesmC", parametros.DesmC);
                da.Parameters.AddWithValue("@DesmD", parametros.DesmD);
                da.Parameters.AddWithValue("@ExpP", parametros.ExpP);
                da.Parameters.AddWithValue("@DesmAP", parametros.DesmAP);
                da.Parameters.AddWithValue("@DesmCP", parametros.DesmCP);
                da.Parameters.AddWithValue("@DesmDP", parametros.DesmDP);
                da.Parameters.AddWithValue("@Score", parametros.Score);
                da.Parameters.AddWithValue("@Taza", parametros.Tasa);
                da.Parameters.AddWithValue("@GradoCalidad", parametros.GradoCalidad);
                da.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                da.Parameters.AddWithValue("@Estado", parametros.Estado);
                da.Parameters.AddWithValue("@Analisis", parametros.Analisis);
                da.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Insertar los datos " + ex.Message, "Error al Insertar Análisis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en InsertarCatacion ✖️✖️ " + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void VerDetalleCata(ref DataTable dt,string Ticket)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("VerDetalleCata", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Ticket",Ticket);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar el detalle de la Ticket " + ex.Message, "Error en Ver Detalle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en VerDetalleCata ✖️✖️ " + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarCatacion(LCatacion parametros,int IdCatacion)
        {
            try
            {
                Conexion.abrir();
                SqlCommand da = new SqlCommand("EditarCatacion", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@IdCatacion", IdCatacion);
                da.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                da.Parameters.AddWithValue("@Origen", parametros.Origen);
                da.Parameters.AddWithValue("@FechaMuestra", parametros.FechaMuestra);
                da.Parameters.AddWithValue("@FechaCatacion", parametros.FechaCatacion);
                da.Parameters.AddWithValue("@Dias", parametros.Dias);
                da.Parameters.AddWithValue("@RmtoObto", parametros.RmtoObto);
                da.Parameters.AddWithValue("@Cascarilla", parametros.Cascarilla);
                da.Parameters.AddWithValue("@TotalPS", parametros.TotalPS);
                da.Parameters.AddWithValue("@IdVariedad", parametros.IdVariedad);
                da.Parameters.AddWithValue("@Humedad", parametros.Humedad);
                da.Parameters.AddWithValue("@Exp", parametros.Exp);
                da.Parameters.AddWithValue("@DesmA", parametros.DesmA);
                da.Parameters.AddWithValue("@DesmC", parametros.DesmC);
                da.Parameters.AddWithValue("@DesmD", parametros.DesmD);
                da.Parameters.AddWithValue("@DesmAP", parametros.DesmAP);
                da.Parameters.AddWithValue("@DesmCP", parametros.DesmCP);
                da.Parameters.AddWithValue("@DesmDP", parametros.DesmDP);
                da.Parameters.AddWithValue("@Score", parametros.Score);
                da.Parameters.AddWithValue("@Taza", parametros.Tasa);
                da.Parameters.AddWithValue("@GradoCalidad", parametros.GradoCalidad);
                da.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                da.Parameters.AddWithValue("@Estado", parametros.Estado);
                da.Parameters.AddWithValue("@Analisis", parametros.Analisis);
                da.Parameters.AddWithValue("@ExpP", parametros.ExpP);
                da.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar los datos " + ex.Message, "Error al editar Análisis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en EditarCatacion ✖️✖️ " + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarTKAnalisis(string Ticket,string TicketNueva)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarTKAnalisis", Conexion.conectar);
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ticket", Ticket);
                cmd.Parameters.AddWithValue("@TicketNueva",TicketNueva);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar la Ticket" + ex.Message, "Error en editar ticket", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en EditarTKAnalisis ✖️✖️ "+ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool InsertarCatacionCD(LCatacion parametros)
        {
            try
            {
                Conexion.abrir();
                SqlCommand da = new SqlCommand("InsertarCatacionCD", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                da.Parameters.AddWithValue("@Origen", parametros.Origen);
                da.Parameters.AddWithValue("@FechaMuestra", parametros.FechaMuestra);
                da.Parameters.AddWithValue("@FechaCatacion", parametros.FechaCatacion);
                da.Parameters.AddWithValue("@Dias", parametros.Dias);
                da.Parameters.AddWithValue("@RmtoObto", parametros.RmtoObto);
                da.Parameters.AddWithValue("@Cascarilla", parametros.Cascarilla);
                da.Parameters.AddWithValue("@TotalPS", parametros.TotalPS);
                da.Parameters.AddWithValue("@IdVariedad", parametros.IdVariedad);
                da.Parameters.AddWithValue("@Humedad", parametros.Humedad);
                da.Parameters.AddWithValue("@Exp", parametros.Exp);
                da.Parameters.AddWithValue("@DesmA", parametros.DesmA);
                da.Parameters.AddWithValue("@DesmC", parametros.DesmC);
                da.Parameters.AddWithValue("@DesmD", parametros.DesmD);
                da.Parameters.AddWithValue("@ExpP", parametros.ExpP);
                da.Parameters.AddWithValue("@DesmAP", parametros.DesmAP);
                da.Parameters.AddWithValue("@DesmCP", parametros.DesmCP);
                da.Parameters.AddWithValue("@DesmDP", parametros.DesmDP);
                da.Parameters.AddWithValue("@Score", parametros.Score);
                da.Parameters.AddWithValue("@Taza", parametros.Tasa);
                da.Parameters.AddWithValue("@GradoCalidad", parametros.GradoCalidad);
                da.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                da.Parameters.AddWithValue("@Estado", parametros.Estado);
                da.Parameters.AddWithValue("@Analisis", parametros.Analisis);
                da.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Insertar los datos " + ex.Message, "Error al Insertar Análisis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en InsertarCatacion ✖️✖️ " + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarCatacionCD(LCatacion parametros, string TK)
        {
            try
            {
                Conexion.abrir();
                SqlCommand da = new SqlCommand("EditarCatacionCD", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@Ticket", TK);
                da.Parameters.AddWithValue("@Origen", parametros.Origen);
                da.Parameters.AddWithValue("@FechaMuestra", parametros.FechaMuestra);
                da.Parameters.AddWithValue("@FechaCatacion", parametros.FechaCatacion);
                da.Parameters.AddWithValue("@Dias", parametros.Dias);
                da.Parameters.AddWithValue("@RmtoObto", parametros.RmtoObto);
                da.Parameters.AddWithValue("@Cascarilla", parametros.Cascarilla);
                da.Parameters.AddWithValue("@TotalPS", parametros.TotalPS);
                da.Parameters.AddWithValue("@IdVariedad", parametros.IdVariedad);
                da.Parameters.AddWithValue("@Humedad", parametros.Humedad);
                da.Parameters.AddWithValue("@Exp", parametros.Exp);
                da.Parameters.AddWithValue("@DesmA", parametros.DesmA);
                da.Parameters.AddWithValue("@DesmC", parametros.DesmC);
                da.Parameters.AddWithValue("@DesmD", parametros.DesmD);
                da.Parameters.AddWithValue("@DesmAP", parametros.DesmAP);
                da.Parameters.AddWithValue("@DesmCP", parametros.DesmCP);
                da.Parameters.AddWithValue("@DesmDP", parametros.DesmDP);
                da.Parameters.AddWithValue("@Score", parametros.Score);
                da.Parameters.AddWithValue("@Taza", parametros.Tasa);
                da.Parameters.AddWithValue("@GradoCalidad", parametros.GradoCalidad);
                da.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                da.Parameters.AddWithValue("@Estado", parametros.Estado);
                da.Parameters.AddWithValue("@Analisis", parametros.Analisis);
                da.Parameters.AddWithValue("@ExpP", parametros.ExpP);
                da.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar los datos " + ex.Message, "Error al editar Análisis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en EditarCatacion ✖️✖️ " + ex.Message);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarGrupoCalidad(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarGrupoCalidad", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                combo.ValueMember = "IdScore";
                combo.DisplayMember = "GrupoCalidad";
                combo.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lista.Add(dt.Rows[i]["GrupoCalidad"].ToString());
                }
                combo.AutoCompleteCustomSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarGrupoCalidad ✖️✖️" + ex.Message);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
    }
}
