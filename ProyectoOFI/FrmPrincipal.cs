using ProyectoOFI.Otros;
using ProyectoOFI.Recepcion;
using ProyectoOFI.SM;
using ProyectoOFI.Usuario;
using System;
using System.Windows.Forms;

namespace ProyectoOFI
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();    
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnTransferencia_Click(object sender, EventArgs e)
        {
            PlPrincipal.Controls.Clear();
            Transferencia tr = new Transferencia
            {
                Dock = DockStyle.Fill
            };
            PlPrincipal.Controls.Add(tr);
            btnTransferencia.Enabled = false;
        }

        private void BtnSM_Click(object sender, EventArgs e)
        {
            SMecánico sm = new SMecánico();
            sm.ShowDialog();
            btnTransferencia.Enabled = true;
        }

        private void BtnCatalogo_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmConfig Cg = new FrmConfig();
            Cg.ShowDialog();
        }

        private void BtnUser_Click(object sender, EventArgs e)
        {
            PlPrincipal.Controls.Clear();
            UCUsuario tr = new UCUsuario
            {
                Dock = DockStyle.Fill
            };
            PlPrincipal.Controls.Add(tr);
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            LblPrincipal.Text = Login.NombreA + "\r\nBienvenido al \r\nSistema 👋";
        }
    }
}
