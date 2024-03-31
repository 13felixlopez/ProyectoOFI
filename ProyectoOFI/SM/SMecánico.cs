using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOFI.SM
{
    public partial class SMecánico : Form
    {
        public SMecánico()
        {
            InitializeComponent();
        }

        private void SMecánico_Load(object sender, EventArgs e)
        {
            SecadoMecanico ir = new SecadoMecanico();
            PlSM.Controls.Clear();
            ir.Dock = DockStyle.Fill;
            ir.BringToFront();
            PlSM.Controls.Add(ir);
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
    }
}
