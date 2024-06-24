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
        }
        private void kilosArea()
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
        private void TotalSM()
        {
            DReporte funcion = new DReporte();
            funcion.QQsSM(ref SM);
            LblSM.Text = SM.ToString() + " QQs";
        }
        private void TotalAnalisis()
        {
            DReporte funcion = new DReporte();
            funcion.TotalAnalisis(ref Cata);
            LblAnalisis.Text = Cata.ToString() + " QQs";
        }
    }
}
