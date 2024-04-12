using System;
using System.Windows.Forms;

namespace ProyectoOFI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnInicio_Click(object sender, EventArgs e)
        {
            Logue();
        }
        private void Logue()
        {
            Dispose();
            frmInicio fr = new frmInicio();
            fr.ShowDialog();
        }
    }
}
