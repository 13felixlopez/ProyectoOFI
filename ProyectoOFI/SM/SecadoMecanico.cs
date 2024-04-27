using ProyectoOFI.Datos;
using ProyectoOFI.Otros;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOFI.SM
{
    public partial class SecadoMecanico : UserControl
    {
        public SecadoMecanico()
        {
            InitializeComponent();
        }

        private async void SecadoMecanico_Load(object sender, EventArgs e)
        {
            PlCarga.Dock = DockStyle.Fill;
            await CargarDatos();
            //Base.DiseñoDtvEliminar(ref dtInventarioSM);
            PlCarga.Visible = false;
        }
        private async Task CargarDatos()
        {
            await Task.Delay(1500);
            dtInventarioSM.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            MostrarSM();
            //ReiniciarPaginado();
            await Task.Delay(1000);
        }
        private void MostrarSM()
        {
            DSM SM = new DSM();
            DataTable dt = new DataTable();
            SM.MostrarSM(ref dt);
            dtInventarioSM.DataSource = dt;
        }
    }
}
