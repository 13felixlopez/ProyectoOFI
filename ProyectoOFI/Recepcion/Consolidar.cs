using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using System.Data;
using System.Security.Principal;
using System.Windows.Forms;

namespace ProyectoOFI.Recepcion
{
    public partial class Consolidar : UserControl
    {
        LRecepcion parametros = new LRecepcion();
        LEnvio par = new LEnvio();
        public Consolidar(string Calidad, string CertificacionE, string EstadoFisico, string Daño)
        {
            InitializeComponent();
            DRecepcion funcion = new DRecepcion();
            DataTable dt = new DataTable();
            parametros.Calidad=Calidad;
            par.CertificacionE = CertificacionE;
            parametros.EstadoFisico = EstadoFisico;
            parametros.Daño = Daño;
            funcion.MostrarTKConsolidar(ref dt, parametros, par);
            DtTickets.DataSource = dt;
        }

        private void BtnCancelar_Click(object sender, System.EventArgs e)
        {
            frmInicio fr = new frmInicio();
            fr.PlPrincipal.Controls.Clear();
            Transferencia tr = new Transferencia
            {
                Dock = DockStyle.Fill
            };
            fr.PlPrincipal.Controls.Add(tr);
        }
    }
}
