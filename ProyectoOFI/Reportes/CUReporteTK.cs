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

        private void CUReporteTK_Load(object sender, EventArgs e)
        {
            ReporteTicket();
            //Base.DiseñoDtv(ref DtDatos);
            Base.DiseñoDtvEliminar(ref DtDatos);
        }

        private void ReporteTicket()
        {
            DReporteTK funcion = new DReporteTK();
            DataTable dt = new DataTable();
            funcion.ReporteTicket(ref dt);
            DtDatos.DataSource = dt;
        }
    }
}
