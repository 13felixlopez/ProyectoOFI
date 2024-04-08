using ProyectoOFI.Otros;
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
            btnTransferencia.Enabled = false;
            PlOpciones.Visible = false;
        }

        private void BtnSM_Click(object sender, EventArgs e)
        {
            SMecánico sm = new SMecánico();
            sm.ShowDialog();
            btnTransferencia.Enabled = true;
            PlOpciones.Visible = false;
        }

        private void BtnCatalogo_Click(object sender, EventArgs e)
        {
            if (PlOpciones.Visible==true)
            {
                PlOpciones.Visible = false;
            }
            else
            {
                PlOpciones.Visible = true;

            }
        }

        private void BtnAgencia_Click(object sender, EventArgs e)
        {
            FrmAgencia AA = new FrmAgencia();
            AA.ShowDialog();
            PlOpciones.Visible = false;
        }

        private void BtnAcopio_Click(object sender, EventArgs e)
        {
            FrmAcopios Ac= new FrmAcopios();
            Ac.ShowDialog();
            PlOpciones.Visible = false;
        }

        private void BtnRecibidor_Click(object sender, EventArgs e)
        {
            Recibidor REC= new Recibidor();
            REC.ShowDialog();
            PlOpciones.Visible = false;
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            FrmCliente CL= new FrmCliente();
            PlOpciones.Visible = false;
            CL.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCompra cp= new FrmCompra();
            cp.ShowDialog();
            PlOpciones.Visible=false;
        }
    }
}
