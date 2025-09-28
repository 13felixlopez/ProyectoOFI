using ProyectoOFI.Analisis;
using ProyectoOFI.Compras;
using ProyectoOFI.ControlPatio;
using ProyectoOFI.Datos;
using ProyectoOFI.Logica;
using ProyectoOFI.Otros;
using ProyectoOFI.Recepcion;
using ProyectoOFI.Reportes;
using ProyectoOFI.SM;
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
        private Form FrmActivo = null;
        public FrmMenu()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            base.OnLoad(e);

            // Hacemos el ajuste inicial al cargar.
            //AjustarAlTamanoDePantalla();

            // Opcional: Asegurar que no se pueda cambiar de tamaño.
            // Estas propiedades solo necesitan establecerse una vez.
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //this.MinimizeBox = true;
            //this.MaximizeBox = false;
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
            //AjustarAlTamanoDePantalla();
        }
        private void AjustarAlTamanoDePantalla()
        {
            // Si realmente necesitas esta bandera, mantenla. Si no, puedes omitirla.
            // if (isAdjusting) return; 

            try
            {
                // isAdjusting = true; // Si la usas, descomenta

                // 1. Asegúrate de que el estado es Normal antes de cambiar el tamaño
                // Esto permite que el ajuste de tamaño se haga sin interferir con el estado Maximized.
                this.WindowState = FormWindowState.Normal;

                // Obtener la pantalla actual
                Screen screen = Screen.FromControl(this);

                // 2. Ajustar el tamaño y la ubicación a los límites de la pantalla principal
                // Para que se ajuste al tamaño de la pantalla, usa los límites de trabajo (WorkingArea) 
                // para evitar que oculte la barra de tareas. Si quieres toda la pantalla, usa Bounds.

                // Opción Recomendada: Usar WorkingArea (deja la barra de tareas visible)
                this.Location = screen.WorkingArea.Location;
                this.Size = screen.WorkingArea.Size;

                // Si realmente quieres que ocupe TODA la pantalla, usa Bounds:
                // this.Location = screen.Bounds.Location;
                // this.Size = screen.Bounds.Size;

                // 3. Maximizar el formulario
                // Esto le indica a Windows que gestione la ventana en estado maximizado.
                this.WindowState = FormWindowState.Maximized;
            }
            finally
            {
                // isAdjusting = false; // Si la usas, descomenta
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

        private void catalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConfig Cg = new FrmConfig();
            AbrirFrm(Cg);
        }
        private void AbrirFrm(Form hijo)
        {
            if (FrmActivo != null)
            {
                FrmActivo.Close();
            }

            FrmActivo = hijo;
            hijo.TopLevel = false;
            hijo.Dock = DockStyle.Fill;
            PlPrincipal.Controls.Add(hijo);
            PlPrincipal.Tag = hijo;
            hijo.BringToFront();
            hijo.Show();
        }

        private void secadoMecanicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SMecánico Cg = new SMecánico();
            AbrirFrm(Cg);
            Habilitar(secadoMecanicoToolStripMenuItem);
        }

        private void almacenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlPrincipal.Controls.Clear();
            Almacen.Almacen tr = new Almacen.Almacen
            {
                Dock = DockStyle.Fill
            };
            PlPrincipal.Controls.Add(tr);
            Habilitar(almacenToolStripMenuItem);
        }

        private void compraDirectaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlPrincipal.Controls.Clear();
            ComprasDirectas tr = new ComprasDirectas
            {
                Dock = DockStyle.Fill
            };
            PlPrincipal.Controls.Add(tr);
            Habilitar(compraDirectaToolStripMenuItem);
        }

        private void reporteTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlPrincipal.Controls.Clear();
            CUReporteTK tr = new CUReporteTK
            {
                Dock = DockStyle.Fill
            };
            PlPrincipal.Controls.Add(tr);
            Habilitar(reporteTicketToolStripMenuItem);
        }

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHistorial Cg = new FrmHistorial();
            AbrirFrm(Cg);
            Habilitar(historialToolStripMenuItem);
        }

        private void consolidacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DReporte funcion = new DReporte();
            funcion.ReporteConsolidados(ref dt);
            string Nombre = "Lotes Consolidados ";
            FrmLotes_Tendido Cg = new FrmLotes_Tendido(dt, Nombre);
            AbrirFrm(Cg);
            Habilitar(consolidacionesToolStripMenuItem);
        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPerfil Cg = new FrmPerfil();
            AbrirFrm(Cg);
            Habilitar(perfilToolStripMenuItem);
        }
    }
}
