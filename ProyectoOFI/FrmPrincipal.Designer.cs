
namespace ProyectoOFI
{
    partial class frmInicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInicio));
            this.plTitulo = new System.Windows.Forms.Panel();
            this.LblUser = new System.Windows.Forms.Label();
            this.PlPerfil = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.plfooter = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.PlPrincipal = new System.Windows.Forms.Panel();
            this.LblPrincipal = new System.Windows.Forms.Label();
            this.PlOpciones = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.BtnHistorial = new System.Windows.Forms.Button();
            this.BtnReTK = new System.Windows.Forms.Button();
            this.BtnCerrarSesion = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.BtnReportes = new System.Windows.Forms.Button();
            this.BtnCatalogo = new System.Windows.Forms.Button();
            this.BtnUser = new System.Windows.Forms.Button();
            this.BtnComprasD = new System.Windows.Forms.Button();
            this.BtnAlmacen = new System.Windows.Forms.Button();
            this.BtnAnalisis = new System.Windows.Forms.Button();
            this.BtnSM = new System.Windows.Forms.Button();
            this.BtnCPatio = new System.Windows.Forms.Button();
            this.btnTransferencia = new System.Windows.Forms.Button();
            this.pbIcono = new System.Windows.Forms.PictureBox();
            this.PbPerfil = new System.Windows.Forms.PictureBox();
            this.plTitulo.SuspendLayout();
            this.PlPerfil.SuspendLayout();
            this.plfooter.SuspendLayout();
            this.panel4.SuspendLayout();
            this.PlPrincipal.SuspendLayout();
            this.PlOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbPerfil)).BeginInit();
            this.SuspendLayout();
            // 
            // plTitulo
            // 
            this.plTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(141)))), ((int)(((byte)(42)))));
            this.plTitulo.Controls.Add(this.LblUser);
            this.plTitulo.Controls.Add(this.PlPerfil);
            this.plTitulo.Controls.Add(this.label1);
            this.plTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTitulo.Location = new System.Drawing.Point(0, 0);
            this.plTitulo.Name = "plTitulo";
            this.plTitulo.Size = new System.Drawing.Size(1796, 74);
            this.plTitulo.TabIndex = 0;
            // 
            // LblUser
            // 
            this.LblUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.LblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUser.Location = new System.Drawing.Point(1453, 0);
            this.LblUser.Name = "LblUser";
            this.LblUser.Size = new System.Drawing.Size(244, 74);
            this.LblUser.TabIndex = 6;
            this.LblUser.Text = "--";
            this.LblUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlPerfil
            // 
            this.PlPerfil.Controls.Add(this.PbPerfil);
            this.PlPerfil.Dock = System.Windows.Forms.DockStyle.Right;
            this.PlPerfil.Location = new System.Drawing.Point(1697, 0);
            this.PlPerfil.Name = "PlPerfil";
            this.PlPerfil.Size = new System.Drawing.Size(99, 74);
            this.PlPerfil.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(140)))), ((int)(((byte)(42)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1796, 74);
            this.label1.TabIndex = 4;
            this.label1.Text = "CoffeeTec ofi";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // plfooter
            // 
            this.plfooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.plfooter.Controls.Add(this.BtnCerrarSesion);
            this.plfooter.Controls.Add(this.btnSalir);
            this.plfooter.Controls.Add(this.panel13);
            this.plfooter.Controls.Add(this.BtnReportes);
            this.plfooter.Controls.Add(this.panel14);
            this.plfooter.Controls.Add(this.BtnCatalogo);
            this.plfooter.Controls.Add(this.panel2);
            this.plfooter.Controls.Add(this.BtnUser);
            this.plfooter.Controls.Add(this.panel5);
            this.plfooter.Controls.Add(this.BtnComprasD);
            this.plfooter.Controls.Add(this.panel12);
            this.plfooter.Controls.Add(this.BtnAlmacen);
            this.plfooter.Controls.Add(this.panel10);
            this.plfooter.Controls.Add(this.BtnAnalisis);
            this.plfooter.Controls.Add(this.panel3);
            this.plfooter.Controls.Add(this.BtnSM);
            this.plfooter.Controls.Add(this.panel1);
            this.plfooter.Controls.Add(this.BtnCPatio);
            this.plfooter.Controls.Add(this.panel9);
            this.plfooter.Controls.Add(this.btnTransferencia);
            this.plfooter.Controls.Add(this.panel8);
            this.plfooter.Controls.Add(this.panel4);
            this.plfooter.Controls.Add(this.panel11);
            this.plfooter.Dock = System.Windows.Forms.DockStyle.Left;
            this.plfooter.Location = new System.Drawing.Point(0, 74);
            this.plfooter.Name = "plfooter";
            this.plfooter.Size = new System.Drawing.Size(191, 1012);
            this.plfooter.TabIndex = 3;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(11, 771);
            this.panel13.Margin = new System.Windows.Forms.Padding(2);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(180, 10);
            this.panel13.TabIndex = 34;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(11, 619);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(180, 10);
            this.panel2.TabIndex = 19;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(11, 543);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(180, 10);
            this.panel5.TabIndex = 24;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(11, 467);
            this.panel12.Margin = new System.Windows.Forms.Padding(2);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(180, 10);
            this.panel12.TabIndex = 32;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(11, 391);
            this.panel10.Margin = new System.Windows.Forms.Padding(2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(180, 10);
            this.panel10.TabIndex = 30;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(11, 315);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(180, 10);
            this.panel3.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(11, 238);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 11);
            this.panel1.TabIndex = 16;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(11, 162);
            this.panel9.Margin = new System.Windows.Forms.Padding(2);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(180, 10);
            this.panel9.TabIndex = 11;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(11, 91);
            this.panel8.Margin = new System.Windows.Forms.Padding(2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(180, 5);
            this.panel8.TabIndex = 13;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Fuchsia;
            this.panel4.Controls.Add(this.pbIcono);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(11, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(180, 91);
            this.panel4.TabIndex = 12;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Margin = new System.Windows.Forms.Padding(2);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(11, 1012);
            this.panel11.TabIndex = 14;
            // 
            // PlPrincipal
            // 
            this.PlPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.PlPrincipal.Controls.Add(this.PlOpciones);
            this.PlPrincipal.Controls.Add(this.LblPrincipal);
            this.PlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlPrincipal.Location = new System.Drawing.Point(191, 74);
            this.PlPrincipal.Name = "PlPrincipal";
            this.PlPrincipal.Size = new System.Drawing.Size(1605, 1012);
            this.PlPrincipal.TabIndex = 4;
            // 
            // LblPrincipal
            // 
            this.LblPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(181)))));
            this.LblPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 80F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPrincipal.ForeColor = System.Drawing.Color.White;
            this.LblPrincipal.Location = new System.Drawing.Point(0, 0);
            this.LblPrincipal.Name = "LblPrincipal";
            this.LblPrincipal.Size = new System.Drawing.Size(1605, 1012);
            this.LblPrincipal.TabIndex = 0;
            this.LblPrincipal.Text = "Bienvenido a \r\nCoffeeTec 👋";
            this.LblPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlOpciones
            // 
            this.PlOpciones.AutoScroll = true;
            this.PlOpciones.Controls.Add(this.BtnHistorial);
            this.PlOpciones.Controls.Add(this.panel7);
            this.PlOpciones.Controls.Add(this.BtnReTK);
            this.PlOpciones.Controls.Add(this.panel6);
            this.PlOpciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlOpciones.Location = new System.Drawing.Point(0, 0);
            this.PlOpciones.Name = "PlOpciones";
            this.PlOpciones.Size = new System.Drawing.Size(1605, 63);
            this.PlOpciones.TabIndex = 1;
            this.PlOpciones.Visible = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(10, 63);
            this.panel6.TabIndex = 28;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(157, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(10, 63);
            this.panel7.TabIndex = 31;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(11, 695);
            this.panel14.Margin = new System.Windows.Forms.Padding(2);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(180, 10);
            this.panel14.TabIndex = 35;
            // 
            // BtnHistorial
            // 
            this.BtnHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.BtnHistorial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnHistorial.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnHistorial.FlatAppearance.BorderSize = 0;
            this.BtnHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHistorial.Image = global::ProyectoOFI.Properties.Resources.icons8_historial_médico;
            this.BtnHistorial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnHistorial.Location = new System.Drawing.Point(167, 0);
            this.BtnHistorial.Margin = new System.Windows.Forms.Padding(2);
            this.BtnHistorial.Name = "BtnHistorial";
            this.BtnHistorial.Size = new System.Drawing.Size(147, 63);
            this.BtnHistorial.TabIndex = 30;
            this.BtnHistorial.Text = "Historial";
            this.BtnHistorial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnHistorial.UseVisualStyleBackColor = false;
            this.BtnHistorial.Click += new System.EventHandler(this.BtnHistorial_Click);
            // 
            // BtnReTK
            // 
            this.BtnReTK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.BtnReTK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnReTK.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnReTK.FlatAppearance.BorderSize = 0;
            this.BtnReTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReTK.Image = global::ProyectoOFI.Properties.Resources.icons8_historial_médico;
            this.BtnReTK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReTK.Location = new System.Drawing.Point(10, 0);
            this.BtnReTK.Margin = new System.Windows.Forms.Padding(2);
            this.BtnReTK.Name = "BtnReTK";
            this.BtnReTK.Size = new System.Drawing.Size(147, 63);
            this.BtnReTK.TabIndex = 29;
            this.BtnReTK.Text = "Reporte Ticket";
            this.BtnReTK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnReTK.UseVisualStyleBackColor = false;
            this.BtnReTK.Click += new System.EventHandler(this.BtnReTK_Click);
            // 
            // BtnCerrarSesion
            // 
            this.BtnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.BtnCerrarSesion.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnCerrarSesion.Image = global::ProyectoOFI.Properties.Resources.icons8_cerrar_sesión;
            this.BtnCerrarSesion.Location = new System.Drawing.Point(11, 847);
            this.BtnCerrarSesion.Name = "BtnCerrarSesion";
            this.BtnCerrarSesion.Size = new System.Drawing.Size(180, 66);
            this.BtnCerrarSesion.TabIndex = 23;
            this.BtnCerrarSesion.UseVisualStyleBackColor = false;
            this.BtnCerrarSesion.Click += new System.EventHandler(this.BtnCerrarSesion_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.btnSalir.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSalir.Image = global::ProyectoOFI.Properties.Resources.Atras;
            this.btnSalir.Location = new System.Drawing.Point(11, 781);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(180, 66);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // BtnReportes
            // 
            this.BtnReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.BtnReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnReportes.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnReportes.FlatAppearance.BorderSize = 0;
            this.BtnReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReportes.Image = global::ProyectoOFI.Properties.Resources.icons8_gráfico_combinado;
            this.BtnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReportes.Location = new System.Drawing.Point(11, 705);
            this.BtnReportes.Margin = new System.Windows.Forms.Padding(2);
            this.BtnReportes.Name = "BtnReportes";
            this.BtnReportes.Size = new System.Drawing.Size(180, 66);
            this.BtnReportes.TabIndex = 36;
            this.BtnReportes.Text = "Reportes";
            this.BtnReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnReportes.UseVisualStyleBackColor = false;
            this.BtnReportes.Click += new System.EventHandler(this.BtnReportes_Click);
            // 
            // BtnCatalogo
            // 
            this.BtnCatalogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.BtnCatalogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCatalogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnCatalogo.FlatAppearance.BorderSize = 0;
            this.BtnCatalogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCatalogo.Image = global::ProyectoOFI.Properties.Resources.icons8_magazine_50;
            this.BtnCatalogo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCatalogo.Location = new System.Drawing.Point(11, 629);
            this.BtnCatalogo.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCatalogo.Name = "BtnCatalogo";
            this.BtnCatalogo.Size = new System.Drawing.Size(180, 66);
            this.BtnCatalogo.TabIndex = 20;
            this.BtnCatalogo.Text = "Catálogo";
            this.BtnCatalogo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCatalogo.UseVisualStyleBackColor = false;
            this.BtnCatalogo.Visible = false;
            this.BtnCatalogo.Click += new System.EventHandler(this.BtnCatalogo_Click);
            // 
            // BtnUser
            // 
            this.BtnUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.BtnUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnUser.FlatAppearance.BorderSize = 0;
            this.BtnUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUser.Image = global::ProyectoOFI.Properties.Resources.icons8_usuario_masculino_en_círculo;
            this.BtnUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUser.Location = new System.Drawing.Point(11, 553);
            this.BtnUser.Margin = new System.Windows.Forms.Padding(2);
            this.BtnUser.Name = "BtnUser";
            this.BtnUser.Size = new System.Drawing.Size(180, 66);
            this.BtnUser.TabIndex = 22;
            this.BtnUser.Text = "Usuario";
            this.BtnUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnUser.UseVisualStyleBackColor = false;
            this.BtnUser.Visible = false;
            this.BtnUser.Click += new System.EventHandler(this.BtnUser_Click);
            // 
            // BtnComprasD
            // 
            this.BtnComprasD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.BtnComprasD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnComprasD.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnComprasD.FlatAppearance.BorderSize = 0;
            this.BtnComprasD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnComprasD.Image = global::ProyectoOFI.Properties.Resources.icons8_en_tránsito;
            this.BtnComprasD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnComprasD.Location = new System.Drawing.Point(11, 477);
            this.BtnComprasD.Margin = new System.Windows.Forms.Padding(2);
            this.BtnComprasD.Name = "BtnComprasD";
            this.BtnComprasD.Size = new System.Drawing.Size(180, 66);
            this.BtnComprasD.TabIndex = 33;
            this.BtnComprasD.Text = "Compras Directas";
            this.BtnComprasD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnComprasD.UseVisualStyleBackColor = false;
            this.BtnComprasD.Click += new System.EventHandler(this.BtnComprasD_Click);
            // 
            // BtnAlmacen
            // 
            this.BtnAlmacen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.BtnAlmacen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAlmacen.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnAlmacen.FlatAppearance.BorderSize = 0;
            this.BtnAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAlmacen.Image = global::ProyectoOFI.Properties.Resources.icons8_almacén;
            this.BtnAlmacen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAlmacen.Location = new System.Drawing.Point(11, 401);
            this.BtnAlmacen.Margin = new System.Windows.Forms.Padding(2);
            this.BtnAlmacen.Name = "BtnAlmacen";
            this.BtnAlmacen.Size = new System.Drawing.Size(180, 66);
            this.BtnAlmacen.TabIndex = 31;
            this.BtnAlmacen.Text = "Almacén";
            this.BtnAlmacen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnAlmacen.UseVisualStyleBackColor = false;
            this.BtnAlmacen.Click += new System.EventHandler(this.BtnAlmacen_Click);
            // 
            // BtnAnalisis
            // 
            this.BtnAnalisis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.BtnAnalisis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnAnalisis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAnalisis.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnAnalisis.FlatAppearance.BorderSize = 0;
            this.BtnAnalisis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAnalisis.Image = ((System.Drawing.Image)(resources.GetObject("BtnAnalisis.Image")));
            this.BtnAnalisis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAnalisis.Location = new System.Drawing.Point(11, 325);
            this.BtnAnalisis.Margin = new System.Windows.Forms.Padding(2);
            this.BtnAnalisis.Name = "BtnAnalisis";
            this.BtnAnalisis.Size = new System.Drawing.Size(180, 66);
            this.BtnAnalisis.TabIndex = 29;
            this.BtnAnalisis.Text = "Análisis";
            this.BtnAnalisis.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnAnalisis.UseVisualStyleBackColor = false;
            this.BtnAnalisis.Click += new System.EventHandler(this.BtnAnalisis_Click);
            // 
            // BtnSM
            // 
            this.BtnSM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.BtnSM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSM.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnSM.FlatAppearance.BorderSize = 0;
            this.BtnSM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSM.Image = global::ProyectoOFI.Properties.Resources.factory_50px;
            this.BtnSM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSM.Location = new System.Drawing.Point(11, 249);
            this.BtnSM.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSM.Name = "BtnSM";
            this.BtnSM.Size = new System.Drawing.Size(180, 66);
            this.BtnSM.TabIndex = 18;
            this.BtnSM.Text = "Secado Mecánico";
            this.BtnSM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSM.UseVisualStyleBackColor = false;
            this.BtnSM.Visible = false;
            this.BtnSM.Click += new System.EventHandler(this.BtnSM_Click);
            // 
            // BtnCPatio
            // 
            this.BtnCPatio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.BtnCPatio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCPatio.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnCPatio.FlatAppearance.BorderSize = 0;
            this.BtnCPatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCPatio.Image = global::ProyectoOFI.Properties.Resources.business_report_48px;
            this.BtnCPatio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCPatio.Location = new System.Drawing.Point(11, 172);
            this.BtnCPatio.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCPatio.Name = "BtnCPatio";
            this.BtnCPatio.Size = new System.Drawing.Size(180, 66);
            this.BtnCPatio.TabIndex = 15;
            this.BtnCPatio.Text = "Control de Patio";
            this.BtnCPatio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCPatio.UseVisualStyleBackColor = false;
            this.BtnCPatio.Visible = false;
            this.BtnCPatio.Click += new System.EventHandler(this.BtnCPatio_Click);
            // 
            // btnTransferencia
            // 
            this.btnTransferencia.BackColor = System.Drawing.Color.Transparent;
            this.btnTransferencia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransferencia.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTransferencia.FlatAppearance.BorderSize = 0;
            this.btnTransferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransferencia.Image = global::ProyectoOFI.Properties.Resources.Plan;
            this.btnTransferencia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransferencia.Location = new System.Drawing.Point(11, 96);
            this.btnTransferencia.Margin = new System.Windows.Forms.Padding(2);
            this.btnTransferencia.Name = "btnTransferencia";
            this.btnTransferencia.Size = new System.Drawing.Size(180, 66);
            this.btnTransferencia.TabIndex = 10;
            this.btnTransferencia.Text = "Transferencias";
            this.btnTransferencia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTransferencia.UseVisualStyleBackColor = false;
            this.btnTransferencia.Visible = false;
            this.btnTransferencia.Click += new System.EventHandler(this.BtnTransferencia_Click);
            // 
            // pbIcono
            // 
            this.pbIcono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.pbIcono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbIcono.Image = global::ProyectoOFI.Properties.Resources.Logo;
            this.pbIcono.Location = new System.Drawing.Point(0, 0);
            this.pbIcono.Name = "pbIcono";
            this.pbIcono.Size = new System.Drawing.Size(180, 91);
            this.pbIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIcono.TabIndex = 2;
            this.pbIcono.TabStop = false;
            // 
            // PbPerfil
            // 
            this.PbPerfil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbPerfil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PbPerfil.Image = global::ProyectoOFI.Properties.Resources.icons8_configuración_del_administrador;
            this.PbPerfil.Location = new System.Drawing.Point(0, 0);
            this.PbPerfil.Name = "PbPerfil";
            this.PbPerfil.Size = new System.Drawing.Size(99, 74);
            this.PbPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbPerfil.TabIndex = 0;
            this.PbPerfil.TabStop = false;
            this.PbPerfil.Click += new System.EventHandler(this.PbPerfil_Click);
            // 
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1796, 1086);
            this.Controls.Add(this.PlPrincipal);
            this.Controls.Add(this.plfooter);
            this.Controls.Add(this.plTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmInicio_Load);
            this.plTitulo.ResumeLayout(false);
            this.PlPerfil.ResumeLayout(false);
            this.plfooter.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.PlPrincipal.ResumeLayout(false);
            this.PlOpciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbPerfil)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel plfooter;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnTransferencia;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCPatio;
        private System.Windows.Forms.Button BtnSM;
        public System.Windows.Forms.Panel PlPrincipal;
        private System.Windows.Forms.Button BtnCatalogo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbIcono;
        private System.Windows.Forms.Button BtnUser;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BtnCerrarSesion;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel PlPerfil;
        private System.Windows.Forms.PictureBox PbPerfil;
        private System.Windows.Forms.Label LblUser;
        private System.Windows.Forms.Label LblPrincipal;
        private System.Windows.Forms.Button BtnAnalisis;
        private System.Windows.Forms.Button BtnAlmacen;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button BtnComprasD;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel PlOpciones;
        private System.Windows.Forms.Button BtnHistorial;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button BtnReTK;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button BtnReportes;
        private System.Windows.Forms.Panel panel14;
    }
}

