using ProyectoOFI.Logica;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoOFI.Datos
{
    public class DCompraD
    {
        public int Contador;
        public bool InsertarCompraDirecta(LComprasD parametros)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("InsertarCompraDirecta", conectar))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                    cmd.Parameters.AddWithValue("@Cosecha", parametros.Cosecha);
                    cmd.Parameters.AddWithValue("@Fecha", parametros.Fecha);
                    cmd.Parameters.AddWithValue("@Remision", parametros.Remision);
                    cmd.Parameters.AddWithValue("@Proveedor", parametros.Proveedor);
                    cmd.Parameters.AddWithValue("@KgsRem", parametros.KgsRem);
                    cmd.Parameters.AddWithValue("@Tally", parametros.Tally);
                    cmd.Parameters.AddWithValue("@IdEmpaque", parametros.IdEmpaque);
                    cmd.Parameters.AddWithValue("@Sacos", parametros.Sacos);
                    cmd.Parameters.AddWithValue("@Kilos", parametros.Kilos);
                    cmd.Parameters.AddWithValue("@Diferencia", parametros.Diferencia);
                    cmd.Parameters.AddWithValue("@IdBodega", parametros.IdBodega);
                    cmd.Parameters.AddWithValue("@IdUbicacion", parametros.IdUbicacion);
                    cmd.Parameters.AddWithValue("@IdCompra", parametros.IdCompra);
                    cmd.Parameters.AddWithValue("@IdMaterial", parametros.IdMaterial);
                    //cmd.Parameters.AddWithValue("@IdCertificacion", parametros.IdCertificacion);
                    cmd.Parameters.AddWithValue("@Estado", parametros.Estado);
                    cmd.Parameters.AddWithValue("@Usuario", Login.NombreA);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar los datos en CompraDirecta: " + ex.Message, "Error en CompraDirecta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en InsertarCompraDirecta ✖️✖️ " + ex.Message);
                return false;
            }
        }
        public void MostrarComprasD(ref DataTable dt, int Desde, int Hasta)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("MostrarComprasD", conectar))
                {

                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Desde", Desde);
                    da.SelectCommand.Parameters.AddWithValue("@Hasta", Hasta);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de compras directas " + ex.Message, "Error Compras Directas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al cargar datos en MostrarComprasD ✖️✖️ " + ex.Message);
            }
        }
        public void Contar(ref int contador)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("select count (Ticket) from CompraDirecta", conectar))
                {
                    conectar.Open();
                    contador = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception)
            {
                contador = 0;
            }
        }
        public bool EliminarCompraD(string TK, string Usuario)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("EliminarCompraD", conectar))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ticket", TK);
                    cmd.Parameters.AddWithValue("@Usuario", Usuario);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el registro " + ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en EliminarCompraD ✖️✖️ " + ex.Message);
                return false;
            }
        }
        public void VerdetalleCompraD(ref DataTable dt, string TK)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("VerdetalleCompraD", conectar))
                {

                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Ticket", TK);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos " + ex.Message, "Error en Detalle Compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al cargar datos de VerdetalleCompraD ✖️✖️ " + ex.Message);
            }
        }
        public bool EditarCompraDirecta(LComprasD parametros, string TK)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand cmd = new SqlCommand("EditarCompraDirecta", conectar))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TK", TK);
                    cmd.Parameters.AddWithValue("@Ticket", parametros.Ticket);
                    cmd.Parameters.AddWithValue("@Cosecha", parametros.Cosecha);
                    cmd.Parameters.AddWithValue("@Fecha", parametros.Fecha);
                    cmd.Parameters.AddWithValue("@Remision", parametros.Remision);
                    cmd.Parameters.AddWithValue("@Proveedor", parametros.Proveedor);
                    cmd.Parameters.AddWithValue("@KgsRem", parametros.KgsRem);
                    cmd.Parameters.AddWithValue("@Tally", parametros.Tally);
                    cmd.Parameters.AddWithValue("@IdEmpaque", parametros.IdEmpaque);
                    cmd.Parameters.AddWithValue("@Sacos", parametros.Sacos);
                    cmd.Parameters.AddWithValue("@Kilos", parametros.Kilos);
                    cmd.Parameters.AddWithValue("@Diferencia", parametros.Diferencia);
                    cmd.Parameters.AddWithValue("@IdBodega", parametros.IdBodega);
                    cmd.Parameters.AddWithValue("@IdUbicacion", parametros.IdUbicacion);
                    cmd.Parameters.AddWithValue("@IdCompra", parametros.IdCompra);
                    cmd.Parameters.AddWithValue("@IdMaterial", parametros.IdMaterial);
                    //cmd.Parameters.AddWithValue("@IdCertificacion", parametros.IdCertificacion);
                    cmd.Parameters.AddWithValue("@Estado", parametros.Estado);
                    cmd.Parameters.AddWithValue("@Usuario", Login.NombreA);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar los datos en CompraDirecta: " + ex.Message, "Error en CompraDirecta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en EditarCompraDirecta ✖️✖️ " + ex.Message);
                return false;
            }
        }
        public void ExcelCompraDirecta(ref DataTable dt)
        {
            try
            {
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlDataAdapter da = new SqlDataAdapter("ExcelCompraDirecta", conectar))
                {

                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de compras directas " + ex.Message, "Error Compras Directas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error al cargar datos en MostrarComprasD ✖️✖️ " + ex.Message);
            }
        }
        public void MostrarMaterial(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                using (SqlConnection conectar = Conexion.abrir())
                using (SqlCommand da = new SqlCommand("MostrarMaterial", conectar))
                {

                    da.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter cb = new SqlDataAdapter(da);
                    DataTable dt = new DataTable();
                    cb.Fill(dt);
                    combo.ValueMember = "IdMaterial";
                    combo.DisplayMember = "Material";
                    combo.DataSource = dt;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        lista.Add(dt.Rows[i]["Material"].ToString());
                    }
                    combo.AutoCompleteCustomSource = lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron mostrar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Writeerror("Error en MostrarMaterial ✖️✖️" + ex.Message);
            }
        }
    }
}
