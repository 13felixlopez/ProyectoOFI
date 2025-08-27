using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using ProyectoOFI.Recepcion;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoOFI
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void transferenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlPrincipal.Controls.Clear();
            Transferencia tr = new Transferencia
            {
                Dock = DockStyle.Fill
            };
            PlPrincipal.Controls.Add(tr);
            transferenciaToolStripMenuItem.Enabled = false;
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            LblPrincipal.Text = Login.NombreA + "\r\nBienvenido a \r\nDry System ofi 👋";
            ValidarPermisos();
        }
        private void ValidarPermisos()
        {
            DataTable dt = new DataTable();
            DModulos funcion = new DModulos();
            LPermisos parametros = new LPermisos();
            parametros.IdUser = Login.Iduser;
            funcion.PermisosUser(ref dt, Login.Iduser);
            foreach (DataRow rowpermisos in dt.Rows)
            {
                string Modulo = Convert.ToString(rowpermisos["Modulo"]);
                if (Modulo == "Usuarios")
                {
                    usuarioToolStripMenuItem.Visible = true;
                }
            }
            if (Login.login.Trim().StartsWith("Admin", StringComparison.OrdinalIgnoreCase))
            {
                usuarioToolStripMenuItem.Visible = true;
            }
        }
    }
}
