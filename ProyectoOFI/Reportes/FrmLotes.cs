using ProyectoOFI.Datos;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOFI.Reportes
{
    public partial class FrmLotes : Form
    {
        public FrmLotes()
        {
            InitializeComponent();
        }
        private async Task No_Asignado()
        {
            DataTable dt = new DataTable();
            DReporte funcion = new DReporte();
            await Task.Run(() => funcion.No_Asignado(ref dt));

            // Actualizar el DataGridView en el hilo principal
            Invoke(new Action(() =>
            {
                DtLotes.SuspendLayout();
                DtLotes.DataSource = dt;
                DtLotes.ResumeLayout();
            }));
        }

        private void BtnCerrar_Click(object sender, System.EventArgs e)
        {
            Dispose();
        }

        private async void FrmLotes_Load(object sender, System.EventArgs e)
        {
            PlCarga.Dock = DockStyle.Fill;
            await No_Asignado();
            PlCarga.Visible = false;
        }

    }
}
