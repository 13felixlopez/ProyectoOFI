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
            Lotes_Almacen();
            CantLotes_POAV();
            CantLotes_Vertical();
            CantLotes_POA();
            CantLotes_Guardiola();
            CantLotes_PS();
            CantLotes_EnviadosSM();
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
            LblTotal.Text = Total.ToString("N2") + " QQs";
        }
        private void TotalSN()
        {
            DReporte funcion = new DReporte();
            funcion.QQsSN(ref SN);
            LblSN.Text = SN.ToString("N2") + " QQs";
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
            FrmLotes_Tendido LT = new FrmLotes_Tendido(dt, Nombre);
            LT.ShowDialog();
        }
        private void TotalSM()
        {
            DReporte funcion = new DReporte();
            funcion.QQsSM(ref SM);
            LblSM.Text = SM.ToString("N2") + " QQs";
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
            LblAnalisis.Text = Cata.ToString("N2") + " QQs";
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

        private void BtnAlmacen_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DReporte funcion = new DReporte();
            funcion.Lotes_Almacen(ref dt);
            string Nombre = "Lotes Almacén ";
            FrmLotes_Tendido LT = new FrmLotes_Tendido(dt, Nombre);
            LT.ShowDialog();
        }

        private void BtnPV_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DReporte funcion = new DReporte();
            funcion.Lotes_POAV(ref dt);
            string Nombre = "Inventario POAV";
            FrmLotes_Tendido LT = new FrmLotes_Tendido(dt, Nombre);
            LT.ShowDialog();
        }

        private void Lotes_Analizados()
        {
            DReporte funcion = new DReporte();
            double Analizados = 0;
            funcion.Lotes_Analizados(ref Analizados);
            BtnAnalizados.Text = "Analizados " + Analizados.ToString() + " Lotes";
        }

        private void BtnVertical_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DReporte funcion = new DReporte();
            funcion.Lotes_Vertical(ref dt);
            string Nombre = "Inventario Vertical";
            FrmLotes_Tendido LT = new FrmLotes_Tendido(dt, Nombre);
            LT.ShowDialog();
        }

        private void Lotes_Enviados()
        {
            DReporte funcion = new DReporte();
            double Analizados = 0;
            funcion.Lotes_Enviados(ref Analizados);
            BtnEnvio.Text = "Enviados " + Analizados.ToString() + " Lotes";
        }
        private void Lotes_Almacen()
        {
            DReporte funcion = new DReporte();
            double almacen = 0;
            funcion.Lotes_Almacen(ref almacen);
            BtnAlmacen.Text = "Almacén " + almacen.ToString() + " Lotes";
        }

        private void BtnPOA_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DReporte funcion = new DReporte();
            funcion.Lotes_POA(ref dt);
            string Nombre = "Inventario POA";
            FrmLotes_Tendido LT = new FrmLotes_Tendido(dt, Nombre);
            LT.ShowDialog();
        }

        private void CantLotes_POAV()
        {
            DReporte funcion = new DReporte();
            double POAV = 0;
            funcion.CantLotes_POAV(ref POAV);
            BtnPV.Text = "POAV " + POAV.ToString() + " Lotes";
        }

        private void BtnGuardiola_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DReporte funcion = new DReporte();
            funcion.Lotes_Guardiola(ref dt);
            string Nombre = "Inventario Guardiola";
            FrmLotes_Tendido LT = new FrmLotes_Tendido(dt, Nombre);
            LT.ShowDialog();
        }

        private void CantLotes_Vertical()
        {
            DReporte funcion = new DReporte();
            double Vertical = 0;
            funcion.CantLotes_Vertical(ref Vertical);
            BtnVertical.Text = "Vertical " + Vertical.ToString() + " Lotes";
        }

        private void BtnPS_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DReporte funcion = new DReporte();
            funcion.Lotes_PS(ref dt);
            string Nombre = "Inventario PS";
            FrmLotes_Tendido LT = new FrmLotes_Tendido(dt, Nombre);
            LT.ShowDialog();
        }

        private void CantLotes_POA()
        {
            DReporte funcion = new DReporte();
            double POA = 0;
            funcion.CantLotes_POA(ref POA);
            BtnPOA.Text = "POA " + POA.ToString() + " Lotes";
        }

        private void BtnEnviados_Click(object sender, EventArgs e)
        {
            DataTable dt=new DataTable();
            DReporte funcion = new DReporte();
            funcion.Lotes_EnviadosSM(ref dt);
            string Nombre = "Inventario de Envios";
            FrmLotes_Tendido LT = new FrmLotes_Tendido(dt, Nombre);
            LT.ShowDialog();
        }

        private void CantLotes_Guardiola()
        {
            DReporte funcion = new DReporte();
            double Guardiola = 0;
            funcion.CantLotes_Guardiola(ref Guardiola);
            BtnGuardiola.Text = "Guardiola " + Guardiola.ToString() + " Lotes";
        }
        private void CantLotes_PS()
        {
            DReporte funcion = new DReporte();
            double PS = 0;
            funcion.CantLotes_PS(ref PS);
            BtnPS.Text = "PS " + PS.ToString() + " Lotes";
        }
        private void CantLotes_EnviadosSM()
        {
            DReporte funcion = new DReporte();
            double EnviadosSM = 0;
            funcion.CantLotes_EnviadosSM(ref  EnviadosSM);
            BtnEnviados.Text = "Enviados " + EnviadosSM.ToString() + " Lotes";
        }
    }
}
