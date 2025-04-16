using ProyectoOFI.Datos;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoOFI.Reportes
{
    public partial class Digitacion : Form
    {
        DHistorial funcion = new DHistorial();
        DataTable dt = new DataTable();
        public Digitacion()
        {
            InitializeComponent();
        }

        private void Digitacion_Load(object sender, EventArgs e)
        {
            MostrarDigitacion();
        }
        private void MostrarDigitacion()
        {
            dt.Rows.Clear();
            funcion.MostrarDigitacion(ref dt, DateTime.Now.Date);
            DtDigitacion.DataSource = dt;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();
            funcion.MostrarDigitacion(ref dt, DPFecha.Value);
            DtDigitacion.DataSource = dt;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
