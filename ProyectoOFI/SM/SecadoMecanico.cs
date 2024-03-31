using ProyectoOFI.Datos;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoOFI.SM
{
    public partial class SecadoMecanico : UserControl
    {
        public SecadoMecanico()
        {
            InitializeComponent();
        }

        private void SecadoMecanico_Load(object sender, EventArgs e)
        {
            MostrarSM();
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
