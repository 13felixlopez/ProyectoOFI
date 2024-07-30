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
            Lotes_Analizados();
            Lotes_Enviados();
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
        private void BtnAnalizados_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DReporte funcion = new DReporte();
            funcion.Lotes_Analizados(ref dt);
            string Nombre = "Lotes Analizados ";
            FrmLotes_Tendido LT = new FrmLotes_Tendido(dt, Nombre);
            LT.ShowDialog();
        }
        private void BtnEnvio_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DReporte funcion = new DReporte();
            funcion.Lotes_Enviados(ref dt);
            string Nombre = "Lotes Enviados ";
            FrmLotes_Tendido LT = new FrmLotes_Tendido(dt, Nombre);
            LT.ShowDialog();
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
            double Enfarde = 0;
            funcion.Lotes_Enfarde(ref Enfarde);
            BtnEnfarde.Text = "Enfardados " + Enfarde.ToString() + " Lotes";
        }
        private void Lotes_Analizados()
        {
            DReporte funcion = new DReporte();
            double Analizados = 0;
            funcion.Lotes_Analizados(ref Analizados);
            BtnAnalizados.Text = "Analizados " + Analizados.ToString() + " Lotes";
        }
        private void Lotes_Enviados()
        {
            DReporte funcion = new DReporte();
            double Analizados = 0;
            funcion.Lotes_Enviados(ref Analizados);
            BtnEnvio.Text = "Enviados " + Analizados.ToString() + " Lotes";
        }
    }
}
