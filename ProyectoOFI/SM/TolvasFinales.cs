using ProyectoOFI.Datos;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoOFI.SM
{
    public partial class TolvasFinales : UserControl
    {
        string Ticket;
        public TolvasFinales()
        {
            InitializeComponent();
            MostrarTF();
        }
        private void MostrarTF()
        {
            DPS funcion = new DPS();
            DataTable dt = new DataTable();
            funcion.MostrarTF(ref dt);
            DtTolvasFinales.DataSource = dt;
        }

        private void BtnCerrarPlDatos_Click(object sender, System.EventArgs e)
        {
            PlTolvasFin.Visible = false;
            DtTolvasFinales.Enabled = true;
        }

        private void DtTolvasFinales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerTK();
            DetalleTF();
            AbrirFormulario();
        }
        private void AbrirFormulario()
        {
            PlTolvasFin.Size = new Size(1001, 149);
            PlTolvasFin.Visible = true;
            PlTolvasFin.Location = new Point(DtTolvasFinales.Width / 2
                - PlTolvasFin.Width / 2, DtTolvasFinales.Height / 2 - PlTolvasFin.Height / 2);
            PlTolvasFin.BringToFront();
            DtTolvasFinales.Enabled = false;
        }
        private void ObtenerTK()
        {
            string nombrecolumna = "Ticket";
            int indice = DtTolvasFinales.Columns[nombrecolumna].Index;
            Ticket = DtTolvasFinales.SelectedCells[indice].Value.ToString();

            //string nombrecolum = "ProcesoSM";
            //int num = DtTolvasFinales.Columns[nombrecolum].Index;
            //Proceso = DtTolvasFinales.SelectedCells[num].Value.ToString();

            //string Status = "Proceso";
            //int num1 = DtTolvasFinales.Columns[Status].Index;
            //Estado = DtTolvasFinales.SelectedCells[num1].Value.ToString();
        }
        private void DetalleTF()
        {
            try
            {
                DataTable dt = new DataTable();
                DPS funcion = new DPS();
                funcion.DetalleTF(Ticket, ref dt);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    if (row["Ticket"].ToString() != null)
                    {
                        LblTicket.Text = row["Ticket"].ToString();
                    }
                    else
                    {
                        LblTicket.Text = "--";
                    }
                    if (row["Humedad"].ToString()!=null)
                    {
                        LblHumedad.Text = row["Humedad"].ToString();
                    }
                    else
                    {
                        LblHumedad.Text= "--";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error en cargar datos en interfaz Tolvas Finales","Error TF",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCargar_Click(object sender, System.EventArgs e)
        {
            ReProceso();
        }

        private void ReProceso()
        {
            DPS funcion = new DPS();
            double Humedad=double.Parse(LblHumedad.Text);
            int POA=int.Parse(CbPOA.Text);
            if(funcion.ReProceso(LblTicket.Text,Humedad,POA)==true)
            {
                PlTolvasFin.Visible = false;
                LblHumedad.Text = "--";
                LblTicket.Text= "--";
                DtTolvasFinales.Enabled = true;
                MostrarTF();
            }
        }
    }
}
