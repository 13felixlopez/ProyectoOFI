using ProyectoOFI.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ProyectoOFI.Reportes
{
    public partial class Dashboard : UserControl
    {
        double Total, SN, SM, Cata;
        public Dashboard()
        {
            InitializeComponent();
            kilosArea();
            TotalQQs();
            TotalSN();
            TotalSM();
            TotalAnalisis();
            DatosSM();
            DatosSN();
            CantNoAsignado();
            Lotes_Tendido();
            Lotes_Enfarde();
        }
        private void kilosArea()
        {
            try
            {
                List<string> Concepto = new List<string>();
                List<double> Porcentaje = new List<double>();
                DataTable dt = new DataTable();
                DReporte funcion = new DReporte();
                funcion.kilosArea(dt);
                foreach (DataRow row in dt.Rows)
                {
                    Concepto.Add(Convert.ToString(row[0]));
                    Porcentaje.Add(Convert.ToDouble(row[1]));
                }
                chartKilos.Series[0].Points.DataBindXY(Concepto, Porcentaje);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Kilos Area" + ex.Message, "Error KiloArea", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DatosSN()
        {
            List<string> Concepto = new List<string>();
            List<double> Porcentaje = new List<double>();
            DataTable dt = new DataTable();
            DReporte funcion = new DReporte();
            funcion.DatosSN(dt);
            foreach (DataRow row in dt.Rows)
            {
                Concepto.Add(Convert.ToString(row[0]));
                Porcentaje.Add(Convert.ToDouble(row[1]));
            }
            chartSN.Series[0].Points.DataBindXY(Concepto, Porcentaje);
        }
        private void DatosSM()
        {
            List<string> Concepto = new List<string>();
            List<double> Porcentaje = new List<double>();
            DataTable dt = new DataTable();
            DReporte funcion = new DReporte();
            funcion.DatosSM(dt);
            foreach (DataRow row in dt.Rows)
            {
                Concepto.Add(Convert.ToString(row[0]));
                Porcentaje.Add(Convert.ToDouble(row[1]));
            }
            chartSM.Series[0].Points.DataBindXY(Concepto, Porcentaje);
        }
        private void TotalQQs()
        {
            DReporte funcion = new DReporte();
            funcion.QQsTotal(ref Total);
            LblTotal.Text = Total.ToString() + " QQs";
        }
        private void TotalSN()
        {
            DReporte funcion = new DReporte();
            funcion.QQsSN(ref SN);
            LblSN.Text = SN.ToString() + " QQs";
        }
        private void BtnNoAsignado_Click(object sender, EventArgs e)
        {
            FrmLotes lt = new FrmLotes();
            lt.ShowDialog();
        }
        private void BtnTendido_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DReporte funcion = new DReporte();
            funcion.Lotes_Tendido(ref dt);
            string Nombre = "Lotes Tendidos ";
            FrmLotes_Tendido LT = new FrmLotes_Tendido(dt,Nombre);
            LT.ShowDialog();
        }
        private void TotalSM()
        {
            DReporte funcion = new DReporte();
            funcion.QQsSM(ref SM);
            LblSM.Text = SM.ToString() + " QQs";
        }
        private void BtnEnfarde_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DReporte funcion = new DReporte();
            funcion.Lotes_Enfarde(ref dt);
            string Nombre = "Lotes Enfarde ";
            FrmLotes_Tendido LT = new FrmLotes_Tendido(dt, Nombre);
            LT.ShowDialog();
        }
        private void TotalAnalisis()
        {
            DReporte funcion = new DReporte();
            funcion.TotalAnalisis(ref Cata);
            LblAnalisis.Text = Cata.ToString() + " QQs";
        }
        private void CantNoAsignado()
        {
            DReporte funcion = new DReporte();
            double CantNA = 0;
            funcion.CantNoAsignado(ref CantNA);
            BtnNoAsignado.Text = "No Asignados " + CantNA.ToString() + " Lotes";
        }
        private void Lotes_Tendido()
        {
            DReporte funcion = new DReporte();
            double Tendido = 0;
            funcion.Lotes_Tendido(ref Tendido);
            BtnTendido.Text = "Tendidos " + Tendido.ToString() + " Lotes";
        }
        private void Lotes_Enfarde()
        {
            DReporte funcion = new DReporte();
            double Tendido = 0;
            funcion.Lotes_Enfarde(ref Tendido);
            BtnEnfarde.Text = "Enfardados " + Tendido.ToString() + " Lotes";
        }
    }
}
