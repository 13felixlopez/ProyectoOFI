using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOFI.SM
{
    public partial class SMecánico : Form
    {
        public SMecánico()
        {
            InitializeComponent();
            this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            this.WindowState = FormWindowState.Maximized;
        }

        private void SMecánico_Load(object sender, EventArgs e)
        {
            plfooterSm.Enabled = false;
            SecadoMecanico ir = new SecadoMecanico();
            PlSM.Controls.Clear();
            ir.Dock = DockStyle.Fill;
            ir.BringToFront();
            PlSM.Controls.Add(ir);
            Task.Delay(3500);
            plfooterSm.Enabled = true;
        }

        private void btnTransferencia_Click(object sender, EventArgs e)
        {
            SecadoMecanico ir = new SecadoMecanico();
            PlSM.Controls.Clear();
            ir.Dock = DockStyle.Fill;
            ir.BringToFront();
            PlSM.Controls.Add(ir);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnTverticales_Click(object sender, EventArgs e)
        {
            TolvasVerticales TV = new TolvasVerticales();
            PlSM.Controls.Clear();
            TV.Dock = DockStyle.Fill;
            TV.BringToFront();
            PlSM.Controls.Add(TV);
        }

        private void BtnVerticales_Click(object sender, EventArgs e)
        {
            Verticales ver = new Verticales();
            PlSM.Controls.Clear();
            ver.Dock = DockStyle.Fill;
            ver.BringToFront();
            PlSM.Controls.Add(ver);
        }

        private void BtnPOA_Click(object sender, EventArgs e)
        {
            POASF p = new POASF();
            PlSM.Controls.Clear();
            p.Dock = DockStyle.Fill;
            p.BringToFront();
            PlSM.Controls.Add(p);
        }

        private void BtnGuardiola_Click(object sender, EventArgs e)
        {
            Guardiolas g = new Guardiolas();
            PlSM.Controls.Clear();
            g.Dock = DockStyle.Fill;
            g.BringToFront();
            PlSM.Controls.Add(g);
        }

        private void BtnPS_Click(object sender, EventArgs e)
        {
            PS pS = new PS();
            PlSM.Controls.Clear();
            pS.Dock = DockStyle.Fill;
            pS.BringToFront();
            PlSM.Controls.Add(pS);
        }

        private void BtnTF_Click(object sender, EventArgs e)
        {
            TolvasFinales TF = new TolvasFinales();
            PlSM.Controls.Clear();
            TF.Dock = DockStyle.Fill;
            TF.BringToFront();
            PlSM.Controls.Add(TF);
        }

        private void BtnPS_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PSData pS = new PSData();
                PlSM.Controls.Clear();
                pS.Dock = DockStyle.Fill;
                pS.BringToFront();
                PlSM.Controls.Add(pS);
            }
        }
    }
}
