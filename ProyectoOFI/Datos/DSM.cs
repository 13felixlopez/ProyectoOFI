using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace ProyectoOFI.Datos
{
    public class DSM
    {
        //Variables
        public string TV1, TV2, TV3, TV4, TV5, TV6, TV7, TV8;
        public void MostrarSM(ref DataTable dt)
        {
			try
			{
                Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarSM", Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
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

        public DataTable MostrarTV()
        {
                DataTable tablaTickets = new DataTable();
            try
            {
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarTV", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                tablaTickets.Load(da.ExecuteReader());
                return tablaTickets;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+ex.StackTrace);
                return tablaTickets;
                //MessageBox.Show("No se ha podido cargar los datos " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Conexion.cerrar();
            }
        }

        public void CargarTV(string TK, DataTable dt)
        {
            try
            {
                Conexion.abrir();
                SqlCommand da = new SqlCommand("CargarTV", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@Ticket", TK);
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
        public void CargarTk(ComboBox combo)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand cmd = new SqlCommand("MostrarTkV", Conexion.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter cb = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                combo.ValueMember = "Ticket";
                combo.DisplayMember = "Ticket";
                combo.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lista.Add(dt.Rows[i]["Ticket"].ToString());
                }
                combo.AutoCompleteCustomSource = lista;
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

        public void MostrarDatosTKSM(Label sacos, Label kilos, Label QQS, Label calidad, Label daño, Label esfisico, Label FRecibido, string TK)
        {
            try
            {
                AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
                Conexion.abrir();
                SqlCommand da = new SqlCommand("MostrarDatosTKSM", Conexion.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@TK", TK);
                SqlDataAdapter cb = new SqlDataAdapter(da);
                DataTable dt = new DataTable();
                cb.Fill(dt);
                sacos.Text = dt.Rows[0]["Sacos"].ToString();
                kilos.Text = dt.Rows[0]["Peso"].ToString();
                double QQs = double.Parse(kilos.Text);
                QQs= QQs / 46;
                QQS.Text = Math.Round(QQs, 2).ToString();
                calidad.Text = dt.Rows[0]["Calidad"].ToString();
                daño.Text = dt.Rows[0]["Danio"].ToString();
                esfisico.Text = dt.Rows[0]["EstadoFisico"].ToString();
                FRecibido.Text= dt.Rows[0]["FRecibido"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error "+ex.Message, "Error mostrar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Conexion.cerrar();
            }
        }
    }
}
