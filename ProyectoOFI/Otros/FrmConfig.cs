using ProyectoOFI.Recepcion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOFI.Otros
{
    public partial class FrmConfig : Form
    {
        public FrmConfig()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            frmInicio fr=new frmInicio();
            fr.Show();
            this.Close();
        }

        private void BtnAgencia_Click(object sender, EventArgs e)
        {
            FrmAgencia AA = new FrmAgencia();
            AA.ShowDialog();
        }

        private void BtnAcopio_Click(object sender, EventArgs e)
        {
            FrmAcopios AA = new FrmAcopios();
            AA.ShowDialog();
        }

        private void BtnRecibidor_Click(object sender, EventArgs e)
        {
            Recibidor AA = new Recibidor();
            AA.ShowDialog();
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            FrmCliente AA = new FrmCliente();
            AA.ShowDialog();
        }

        private void BtnCompra_Click(object sender, EventArgs e)
        {
            FrmCompra AA = new FrmCompra();
            AA.ShowDialog();
        }
    }
}
