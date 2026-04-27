using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoOFI.Usuario
{
    public partial class Restablecer : Form
    {
        private int conteo;
        string contraseñaGenerada;
        public Restablecer()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            Dispose();
        }
        private void GenerarPass()
        {
            contraseñaGenerada = Validaciones.GenerarContraseñaAleatoria();
        }

        public string RecuperarPass(string pass)
        {
            return new Recuperacion().RecoverPassword2(pass, contraseñaGenerada);
        }
        private async Task Enviar()
        {
            await Task.Delay(1500);
            timer1.Enabled = true;
            await Task.Delay(1000);
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            lblProgress.Text = "0";
            lblMsj.Text = "";
            GenerarPass();
            lblProgress.Visible = true;
            lblProgress.BringToFront();
            await Enviar();
            conteo = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            conteo += 10;
            lblProgress.Text = conteo.ToString() + " %";
            if (conteo >= 50)
            {
                lblProgress.BackColor = Color.FromArgb(6, 176, 37);
            }
            else
            {
                lblProgress.BackColor = Color.White;
            }

            if (conteo < 100)
            {
                conteo += 10;
            }

            if (conteo == 100)
            {
                timer1.Enabled = false;
                var result = RecuperarPass(txtUser.Text);
                lblMsj.Text = result;
            }
        }
    }
}
