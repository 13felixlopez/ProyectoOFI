using ProyectoOFI.Datos;
using ProyectoOFI.Otros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOFI.Reportes
{
    public partial class CUReporteTK : UserControl
    {
        public CUReporteTK()
        {
            InitializeComponent();
        }

        private async void CUReporteTK_Load(object sender, EventArgs e)
        {
            await CargarDatos();
            //Base.DiseñoDtv(ref DtDatos);
            //Base.DiseñoDtvEliminar(ref DtDatos);
        }

        private void ReporteTicket()
        {
            DReporteTK funcion = new DReporteTK();
            DataTable dt = new DataTable();
            funcion.ReporteTicket(ref dt);
            DtDatos.DataSource = dt;
        }

        private async void PBrefrescar_Click(object sender, EventArgs e)
        {
            await CargarDatos();
            this.Refresh();
        }
        private async Task CargarDatos()
        {
            PlCarga.Visible = true;
            PlCarga.Dock = DockStyle.Fill;
            await Task.Delay(1500);
            ReporteTicket();
            //ReiniciarPaginado();
            await Task.Delay(1000);
            PlCarga.Visible = false;
        }
    }
}
