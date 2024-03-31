using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoOFI.Logica;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Security.Policy;

namespace ProyectoOFI.Datos
{
    public class DRecepcion
    {
        public int contador;
        public bool InsertarLote2(LRecepcion parametros, LEnvio parametro)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("InsertarLote", Conexion.conectar)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                cmd.Parameters.AddWithValue("@FechaRecibido", parametros.FRecibido);
                cmd.Parameters.AddWithValue("@AreaSecado", parametros.Area);
                cmd.Parameters.AddWithValue("@MTNR", parametros.MTNR);
                cmd.Parameters.AddWithValue("@EstadoFisico", parametros.EstadoFisico);
                cmd.Parameters.AddWithValue("@CalidadE", parametros.Calidad);
                cmd.Parameters.AddWithValue("@DanioE", parametros.Daño);
                cmd.Parameters.AddWithValue("@SacosE", parametros.Sacos);
                cmd.Parameters.AddWithValue("@Peso", parametros.Peso);
                cmd.Parameters.AddWithValue("@Merma", parametros.Merma);
                cmd.Parameters.AddWithValue("@Recibidor", parametros.Recibidor);
                cmd.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                //Envio
                cmd.Parameters.AddWithValue("@IDEnvio", parametro.IDEnvio);
                cmd.Parameters.AddWithValue("@TicketE", parametros.Ticket);
                cmd.Parameters.AddWithValue("@FEnvio", parametro.FEnvio);
                cmd.Parameters.AddWithValue("@Agencia", parametro.Agencia);
                cmd.Parameters.AddWithValue("@Acopio", parametro.Acopio);
                cmd.Parameters.AddWithValue("@Cliente", parametro.Cliente);
                cmd.Parameters.AddWithValue("@MTNT", parametro.MTNT);
                cmd.Parameters.AddWithValue("@Tipo_Compra", parametro.TCompra);
                cmd.Parameters.AddWithValue("@Certificacion", parametro.CertificacionE);
                cmd.Parameters.AddWithValue("@EsFisico", parametro.EsFisico);
                cmd.Parameters.AddWithValue("@Calidad", parametro.CalidadE);
                cmd.Parameters.AddWithValue("@Danio", parametro.DanioE);
                cmd.Parameters.AddWithValue("@Sacos", parametro.SacosE);
                cmd.Parameters.AddWithValue("@PesoE", parametro.PesoE);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Registro realizado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarLote(ref DataTable dt, int desde, int hasta)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarLotes", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Desde", desde);
                da.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "No se pudieron mostrar los datos " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void MostrarDetalle(ref DataTable dt, string Tk)
        {
            try
            {
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarDetalle", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Ticket", Tk);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Conexion.cerrar();
            }
        }

        public bool EliminarTK(LRecepcion parametros)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EliminarTK", Conexion.conectar)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@TK", parametros.Ticket);
                cmd.ExecuteNonQuery();
                MessageBox.Show("La Ticket= " + parametros.Ticket + " Ha sido eliminada.", "Eliminado con éxito ✅", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR DRecepcion", "El elemento no ha sido eliminado " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public void ContarTK(ref int Contador)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("select Count(Ticket) from Recepcion", Conexion.conectar);
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
        public void BuscarTK(string Buscar, ref DataTable dt, int desde, int hasta,int Contar)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("BuscarTK", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Desde", desde);
                cmd.Parameters.AddWithValue("@Hasta", hasta);
                cmd.Parameters.AddWithValue("@Buscador", Buscar);

                // Parámetro de salida para el contador
                SqlParameter contarParam = new SqlParameter("@Contar", SqlDbType.Int);
                contarParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(contarParam);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                // Obtener el valor del contador
                Contar = Convert.ToInt32(contarParam.Value);
                contador = Contar;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
        public bool EditarTK(LRecepcion parametros, LEnvio par)
        {
            try
            {
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("EditarTK", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                cmd.Parameters.AddWithValue("@FechaRecibido", parametros.FRecibido);
                cmd.Parameters.AddWithValue("@AreaSecado", parametros.Area);
                cmd.Parameters.AddWithValue("@MTNR", parametros.MTNR);
                cmd.Parameters.AddWithValue("@EstadoFisico", parametros.EstadoFisico);
                cmd.Parameters.AddWithValue("@CalidadE", parametros.Calidad);
                cmd.Parameters.AddWithValue("@DanioE", parametros.Daño);
                cmd.Parameters.AddWithValue("@SacosE", parametros.Sacos);
                cmd.Parameters.AddWithValue("@Peso", parametros.Peso);
                cmd.Parameters.AddWithValue("@Merma", parametros.Merma);
                cmd.Parameters.AddWithValue("@Recibidor", parametros.Recibidor);
                cmd.Parameters.AddWithValue("@Digitador", parametros.Digitador);
                //Envio
                cmd.Parameters.AddWithValue("@FEnvio", par.FEnvio);
                cmd.Parameters.AddWithValue("@Agencia",par.Agencia);
                cmd.Parameters.AddWithValue("@Acopio", par.Acopio);
                cmd.Parameters.AddWithValue("@Cliente",par.Cliente);
                cmd.Parameters.AddWithValue("@MTNT", par.MTNT);
                cmd.Parameters.AddWithValue("@Tipo_Compra", par.TCompra);
                cmd.Parameters.AddWithValue("@Certificacion", par.CertificacionE);
                cmd.Parameters.AddWithValue("@EsFisico", par.EsFisico);
                cmd.Parameters.AddWithValue("@Calidad", par.CalidadE);
                cmd.Parameters.AddWithValue("@Danio", par.DanioE);
                cmd.Parameters.AddWithValue("@Sacos", par.SacosE);
                cmd.Parameters.AddWithValue("@PesoE", par.PesoE);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido editar el registro " + ex.Message, "ERROR al actualizar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Conexion.cerrar();
            }
        }
    }
}
