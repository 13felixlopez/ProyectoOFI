using ProyectoOFI.ControlPatio;
using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using ProyectoOFI.Recepcion;
using ProyectoOFI.Usuario;
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
            Habilitar(transferenciaToolStripMenuItem);
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

        private void secadoNaturalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlPrincipal.Controls.Clear();
            CUControlPatio tr = new CUControlPatio
            {
                Dock = DockStyle.Fill
            };
            PlPrincipal.Controls.Add(tr);
            Habilitar(secadoNaturalToolStripMenuItem);
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlPrincipal.Controls.Clear();
            UCUsuario tr = new UCUsuario
            {
                Dock = DockStyle.Fill
            };
            PlPrincipal.Controls.Add(tr);
            Habilitar(usuarioToolStripMenuItem);
        }
        private void Habilitar(ToolStripMenuItem control)
        {
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                HabilitarRecursivo(item, control);
            }
        }

        private void HabilitarRecursivo(ToolStripMenuItem item, ToolStripMenuItem control)
        {
            if (item == control)
            {
                item.Enabled = false;
            }
            else
            {
                item.Enabled = true;
            }

            // Si este item tiene submenús, recorrerlos también
            foreach (ToolStripMenuItem subItem in item.DropDownItems)
            {
                HabilitarRecursivo(subItem, control);
            }
        }

    }
}
