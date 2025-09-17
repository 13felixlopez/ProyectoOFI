using ProyectoOFI.Analisis;
using ProyectoOFI.ControlPatio;
using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using ProyectoOFI.Recepcion;
using ProyectoOFI.Reportes;
using ProyectoOFI.Usuario;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoOFI
{
    public partial class FrmMenu : Form
    {
        // Bandera para evitar que el evento se dispare a sí mismo y cree un bucle.
        private bool isAdjusting = false;
        public FrmMenu()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            base.OnLoad(e);

            // Hacemos el ajuste inicial al cargar.
            AjustarAlTamanoDePantalla();

            // Opcional: Asegurar que no se pueda cambiar de tamaño.
            // Estas propiedades solo necesitan establecerse una vez.
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = true;
            this.MaximizeBox = false;
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

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
            Login lg = new Login();
            lg.ShowDialog();
        }

        private void FrmMenu_LocationChanged(object sender, EventArgs e)
        {
            // Cuando el formulario se mueva, volvemos a ajustar.
            AjustarAlTamanoDePantalla();
        }
        private void AjustarAlTamanoDePantalla()
        {
            // Si ya estamos ajustando, salimos para evitar parpadeos o bucles.
            if (isAdjusting) return;

            try
            {
                isAdjusting = true; // Activamos la bandera

                // Obtenemos la pantalla donde se encuentra actualmente el formulario.
                Screen screen = Screen.FromControl(this);

                // Ajustamos la posición y el tamaño a la nueva pantalla.
                this.WindowState = FormWindowState.Normal;
                this.Location = screen.WorkingArea.Location;
                this.Size = screen.WorkingArea.Size;
            }
            finally
            {
                isAdjusting = false; // Desactivamos la bandera, incluso si hay un error.
            }
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlPrincipal.Controls.Clear();
            Dashboard tr = new Dashboard
            {
                Dock = DockStyle.Fill
            };
            PlPrincipal.Controls.Add(tr);
            Habilitar(dashboardToolStripMenuItem);
        }

        private void cataciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlPrincipal.Controls.Clear();
            Catacion tr = new Catacion
            {
                Dock = DockStyle.Fill
            };
            PlPrincipal.Controls.Add(tr);
            Habilitar(cataciónToolStripMenuItem);
        }
    }
}
