using ProyectoOFI.Recepcion;
using ProyectoOFI.SM;
using System;
using System.Windows.Forms;

namespace ProyectoOFI
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
            timerAct.Start();
        
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
           
        }

        

        private void timerAct_Tick(object sender, EventArgs e)
        {
            //MostrarLotes();
        }

        private void BtnTransferencia_Click(object sender, EventArgs e)
        {
            PlPrincipal.Controls.Clear();
            Transferencia tr = new Transferencia
            {
                Dock = DockStyle.Fill
            };
            PlPrincipal.Controls.Add(tr);
        }

        private void BtnSM_Click(object sender, EventArgs e)
        {
            SMecánico sm = new SMecánico();
            sm.ShowDialog();
        }
    }
}
