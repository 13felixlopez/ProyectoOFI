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
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoOFI
{
    public partial class frmInicio : Form
    {
        private Form FrmActivo = null;
        public frmInicio()
        {
            InitializeComponent();
            MedirPantalla();
        }
        private void MedirPantalla()
        {
            this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnTransferencia_Click(object sender, EventArgs e)
        {
            BtnUser.Enabled = true;
            BtnCPatio.Enabled = true;
            BtnReTK.Enabled = true;
            BtnAnalisis.Enabled = true;
            BtnAlmacen.Enabled = true;
            BtnComprasD.Enabled = true;
            PlPrincipal.Controls.Clear();
            Transferencia tr = new Transferencia
            {
                Dock = DockStyle.Fill
            };
            PlPrincipal.Controls.Add(tr);
            btnTransferencia.Enabled = false;
            LblModulo.Text = "Transferencia";
        }

        private void BtnSM_Click(object sender, EventArgs e)
        {
            SMecánico sm = new SMecánico();
            sm.ShowDialog();
            btnTransferencia.Enabled = true;
        }

        private void BtnCatalogo_Click(object sender, EventArgs e)
        {
            FrmConfig Cg = new FrmConfig();
            AbrirFrm(Cg);
            //Cg.ShowDialog();
        }

        private void BtnUser_Click(object sender, EventArgs e)
        {
            btnTransferencia.Enabled = true;
            BtnUser.Enabled = false;
            BtnCPatio.Enabled = true;
            BtnReTK.Enabled = true;
            BtnAnalisis.Enabled = true;
            BtnAlmacen.Enabled = true;
            BtnComprasD.Enabled = true;
            PlPrincipal.Controls.Clear();
            UCUsuario tr = new UCUsuario
            {
                Dock = DockStyle.Fill
            };
            PlPrincipal.Controls.Add(tr);
            LblModulo.Text = "Usuarios";
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            LblUser.Text = Login.NombreA;
            LblPrincipal.Text = Login.NombreA + "\r\nBienvenido a \r\nCoffeeTec ofi 👋";
            ValidarPermisos();
            CambiarColor(BtnAlmacen);
            CambiarColor(btnTransferencia);
            CambiarColor(BtnCPatio);
            CambiarColor(BtnSM);
            CambiarColor(BtnAlmacen);
            CambiarColor(BtnReTK);
            CambiarColor(BtnCatalogo);
            CambiarColor(BtnHistorial);
            CambiarColor(BtnCerrarSesion);
            CambiarColor(BtnAnalisis);
            CambiarColor(btnSalir);
            CambiarColor(BtnComprasD);
            CambiarColor(BtnUser);
            CambiarColor(BtnReportes);
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
                if (Modulo == "Transferencia")
                {
                    btnTransferencia.Visible = true;
                }
                if (Modulo == "ControlPatio")
                {
                    BtnCPatio.Visible = true;
                }
                if (Modulo == "SM")
                {
                    BtnSM.Visible = true;
                }
                if ((Modulo == "Catalogo"))
                {
                    BtnCatalogo.Visible = true;
                }
                if (Modulo == "Usuarios")
                {
                    BtnUser.Visible = true;
                }
                if (Modulo == "Compra Directa")
                {
                    BtnComprasD.Visible = true;
                }
                if (Modulo == "Reportes")
                {
                    BtnReportes.Visible = true;
                }
                if (Modulo == "Almacen")
                {
                    BtnAlmacen.Visible = true;
                }
                if (Modulo == "Historial")
                {
                    BtnHistorial.Visible = true;
                }
                if (Modulo == "Digitacion")
                {
                    BtnDigitacion.Visible = true;
                }
            }
            if (Login.login.Trim().StartsWith("Admin", StringComparison.OrdinalIgnoreCase))
            {
                btnTransferencia.Visible = true;
                BtnCPatio.Visible = true;
                BtnSM.Visible = true;
                BtnCatalogo.Visible = true;
                BtnUser.Visible = true;
                BtnComprasD.Visible = true;
                BtnReportes.Visible = true;
                BtnAlmacen.Visible = true;
                BtnHistorial.Visible = true;
                BtnDigitacion.Visible = true;
            }
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Dispose();
            Login lg = new Login();
            lg.ShowDialog();
        }

        private void BtnHistorial_Click(object sender, EventArgs e)
        {
            FrmHistorial HI = new FrmHistorial();
            HI.ShowDialog();
        }

        private void PbPerfil_Click(object sender, EventArgs e)
        {
            Dispose();
            FrmPerfil perfil = new FrmPerfil();
            perfil.ShowDialog();
        }

        private void BtnCPatio_Click(object sender, EventArgs e)
        {
            btnTransferencia.Enabled = true;
            BtnUser.Enabled = true;
            BtnCPatio.Enabled = false;
            BtnReTK.Enabled = true;
            BtnAnalisis.Enabled = true;
            BtnAlmacen.Enabled = true;
            BtnComprasD.Enabled = true;
            PlPrincipal.Controls.Clear();
            CUControlPatio tr = new CUControlPatio
            {
                Dock = DockStyle.Fill
            };
            PlPrincipal.Controls.Add(tr);
            LblModulo.Text = "Control de Patio";
        }

        private void BtnReTK_Click(object sender, EventArgs e)
        {
            btnTransferencia.Enabled = true;
            BtnUser.Enabled = true;
            BtnCPatio.Enabled = true;
            BtnReTK.Enabled = false;
            BtnAnalisis.Enabled = true;
            BtnAlmacen.Enabled = true;
            BtnComprasD.Enabled = true;
            PlPrincipal.Controls.Clear();
            CUReporteTK tK = new CUReporteTK
            {
                Dock = DockStyle.Fill
            };
            PlPrincipal.Controls.Add(tK);
        }

        private void BtnAnalisis_Click(object sender, EventArgs e)
        {
            btnTransferencia.Enabled = true;
            BtnUser.Enabled = true;
            BtnCPatio.Enabled = true;
            BtnReTK.Enabled = true;
            BtnAnalisis.Enabled = false;
            BtnAlmacen.Enabled = true;
            BtnComprasD.Enabled = true;
            PlPrincipal.Controls.Clear();
            Catacion al = new Catacion
            {
                Dock = DockStyle.Fill
            };
            PlPrincipal.Controls.Add(al);
            LblModulo.Text = "Análisis";
        }

        private void BtnAlmacen_Click(object sender, EventArgs e)
        {
            btnTransferencia.Enabled = true;
            BtnUser.Enabled = true;
            BtnCPatio.Enabled = true;
            BtnReTK.Enabled = true;
            BtnAnalisis.Enabled = true;
            BtnAlmacen.Enabled = false;
            BtnComprasD.Enabled = true;
            PlPrincipal.Controls.Clear();
            Almacen.Almacen al = new Almacen.Almacen
            {
                Dock = DockStyle.Fill
            };
            PlPrincipal.Controls.Add(al);
            LblModulo.Text = "Almacén";
        }
        public void CambiarColor(Button Btn)
        {
            // Guardar el color original del botón
            Color colorOriginal = Btn.BackColor;

            // Evento cuando el puntero entra en el botón
            Btn.MouseEnter += (sender, e) =>
            {
                // Cambiar el color al pasar el puntero por encima
                Btn.BackColor = Color.Orange;
            };

            // Evento cuando el puntero sale del botón
            Btn.MouseLeave += (sender, e) =>
            {
                // Restaurar el color original al quitar el puntero
                Btn.BackColor = colorOriginal;
            };
        }

        private void BtnComprasD_Click(object sender, EventArgs e)
        {
            btnTransferencia.Enabled = true;
            BtnUser.Enabled = true;
            BtnCPatio.Enabled = true;
            BtnReTK.Enabled = true;
            BtnAnalisis.Enabled = true;
            BtnAlmacen.Enabled = true;
            BtnComprasD.Enabled = false;
            PlPrincipal.Controls.Clear();
            ComprasDirectas CD = new ComprasDirectas
            {
                Dock = DockStyle.Fill
            };
            PlPrincipal.Controls.Add(CD);
            LblModulo.Text = "Compras Directas";
        }

        private void BtnReportes_Click(object sender, EventArgs e)
        {
            btnTransferencia.Enabled = true;
            BtnUser.Enabled = true;
            BtnCPatio.Enabled = true;
            BtnReTK.Enabled = true;
            BtnAnalisis.Enabled = true;
            BtnAlmacen.Enabled = true;
            BtnComprasD.Enabled = true;
            PlPrincipal.Controls.Clear();
            PlPrincipal.Controls.Add(LblPrincipal);
            PlPrincipal.Controls.Add(PlOpciones);
            if (PlOpciones.Visible == true)
            {
                PlOpciones.Visible = false;
            }
            else
            {
                PlOpciones.Visible = true;
            }
            LblModulo.Text = "";
        }

        private void BtnGrafico_Click(object sender, EventArgs e)
        {
            btnTransferencia.Enabled = true;
            BtnUser.Enabled = true;
            BtnCPatio.Enabled = true;
            BtnReTK.Enabled = true;
            BtnAnalisis.Enabled = true;
            BtnAlmacen.Enabled = true;
            BtnComprasD.Enabled = true;
            PlPrincipal.Controls.Clear();
            Dashboard dashboard = new Dashboard
            {
                Dock = DockStyle.Fill
            };
            PlPrincipal.Controls.Add(dashboard);
        }

        private void BtnConsolidaciones_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DReporte funcion = new DReporte();
            funcion.ReporteConsolidados(ref dt);
            string Nombre = "Lotes Consolidados ";
            FrmLotes_Tendido LT = new FrmLotes_Tendido(dt, Nombre);
            LT.ShowDialog();
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

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            Process.Start("https://13felixlopez.github.io/Proceso/");
        }

        private void BtnDigitacion_Click(object sender, EventArgs e)
        {
            Digitacion dg = new Digitacion();
            dg.ShowDialog();
        }
    }
}
