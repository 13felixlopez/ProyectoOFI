
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
            this.LblModulo = new System.Windows.Forms.Label();
            this.LblUser = new System.Windows.Forms.Label();
            this.PlPerfil = new System.Windows.Forms.Panel();
            this.PbPerfil = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PlPrincipal = new System.Windows.Forms.Panel();
            this.PlOpciones = new System.Windows.Forms.Panel();
            this.BtnConsolidaciones = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnGrafico = new System.Windows.Forms.Button();
            this.panel15 = new System.Windows.Forms.Panel();
            this.BtnHistorial = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.BtnReTK = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.LblPrincipal = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pbIcono = new System.Windows.Forms.PictureBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.plfooter = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTransferencia = new System.Windows.Forms.Button();
            this.BtnCPatio = new System.Windows.Forms.Button();
            this.BtnSM = new System.Windows.Forms.Button();
            this.BtnAnalisis = new System.Windows.Forms.Button();
            this.BtnAlmacen = new System.Windows.Forms.Button();
            this.BtnComprasD = new System.Windows.Forms.Button();
            this.BtnUser = new System.Windows.Forms.Button();
            this.BtnCatalogo = new System.Windows.Forms.Button();
            this.BtnReportes = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.BtnCerrarSesion = new System.Windows.Forms.Button();
            this.plTitulo.SuspendLayout();
            this.PlPerfil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbPerfil)).BeginInit();
            this.PlPrincipal.SuspendLayout();
            this.PlOpciones.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcono)).BeginInit();
            this.plfooter.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plTitulo
            // 
            this.plTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(141)))), ((int)(((byte)(42)))));
            this.plTitulo.Controls.Add(this.LblModulo);
            this.plTitulo.Controls.Add(this.LblUser);
            this.plTitulo.Controls.Add(this.PlPerfil);
            this.plTitulo.Controls.Add(this.label1);
            this.plTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTitulo.Location = new System.Drawing.Point(0, 0);
            this.plTitulo.Name = "plTitulo";
            this.plTitulo.Size = new System.Drawing.Size(1386, 74);
            this.plTitulo.TabIndex = 0;
            // 
            // LblModulo
            // 
            this.LblModulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblModulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.LblModulo.Location = new System.Drawing.Point(474, 0);
            this.LblModulo.Name = "LblModulo";
            this.LblModulo.Size = new System.Drawing.Size(569, 74);
            this.LblModulo.TabIndex = 7;
            this.LblModulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblUser
            // 
            this.LblUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.LblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUser.Location = new System.Drawing.Point(1043, 0);
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
            this.PlPerfil.Location = new System.Drawing.Point(1287, 0);
            this.PlPerfil.Name = "PlPerfil";
            this.PlPerfil.Size = new System.Drawing.Size(99, 74);
            this.PlPerfil.TabIndex = 5;
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
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(140)))), ((int)(((byte)(42)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(474, 74);
            this.label1.TabIndex = 4;
            this.label1.Text = "CoffeeTec ofi";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // PlPrincipal
            // 
            this.PlPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.PlPrincipal.Controls.Add(this.PlOpciones);
            this.PlPrincipal.Controls.Add(this.LblPrincipal);
            this.PlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlPrincipal.Location = new System.Drawing.Point(160, 74);
            this.PlPrincipal.Name = "PlPrincipal";
            this.PlPrincipal.Size = new System.Drawing.Size(1226, 714);
            this.PlPrincipal.TabIndex = 4;
            // 
            // PlOpciones
            // 
            this.PlOpciones.AutoScroll = true;
            this.PlOpciones.Controls.Add(this.BtnConsolidaciones);
            this.PlOpciones.Controls.Add(this.panel1);
            this.PlOpciones.Controls.Add(this.BtnGrafico);
            this.PlOpciones.Controls.Add(this.panel15);
            this.PlOpciones.Controls.Add(this.BtnHistorial);
            this.PlOpciones.Controls.Add(this.panel7);
            this.PlOpciones.Controls.Add(this.BtnReTK);
            this.PlOpciones.Controls.Add(this.panel6);
            this.PlOpciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlOpciones.Location = new System.Drawing.Point(0, 0);
            this.PlOpciones.Name = "PlOpciones";
            this.PlOpciones.Size = new System.Drawing.Size(1226, 63);
            this.PlOpciones.TabIndex = 1;
            this.PlOpciones.Visible = false;
            // 
            // BtnConsolidaciones
            // 
            this.BtnConsolidaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.BtnConsolidaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnConsolidaciones.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnConsolidaciones.FlatAppearance.BorderSize = 0;
            this.BtnConsolidaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConsolidaciones.Image = global::ProyectoOFI.Properties.Resources.Union;
            this.BtnConsolidaciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnConsolidaciones.Location = new System.Drawing.Point(492, 0);
            this.BtnConsolidaciones.Margin = new System.Windows.Forms.Padding(2);
            this.BtnConsolidaciones.Name = "BtnConsolidaciones";
            this.BtnConsolidaciones.Size = new System.Drawing.Size(168, 63);
            this.BtnConsolidaciones.TabIndex = 34;
            this.BtnConsolidaciones.Text = "Consolidaciones";
            this.BtnConsolidaciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnConsolidaciones.UseVisualStyleBackColor = false;
            this.BtnConsolidaciones.Click += new System.EventHandler(this.BtnConsolidaciones_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(482, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 63);
            this.panel1.TabIndex = 35;
            // 
            // BtnGrafico
            // 
            this.BtnGrafico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.BtnGrafico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGrafico.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnGrafico.FlatAppearance.BorderSize = 0;
            this.BtnGrafico.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGrafico.Image = global::ProyectoOFI.Properties.Resources.analitica;
            this.BtnGrafico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGrafico.Location = new System.Drawing.Point(324, 0);
            this.BtnGrafico.Margin = new System.Windows.Forms.Padding(2);
            this.BtnGrafico.Name = "BtnGrafico";
            this.BtnGrafico.Size = new System.Drawing.Size(158, 63);
            this.BtnGrafico.TabIndex = 32;
            this.BtnGrafico.Text = "Dashboard";
            this.BtnGrafico.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnGrafico.UseVisualStyleBackColor = false;
            this.BtnGrafico.Click += new System.EventHandler(this.BtnGrafico_Click);
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.panel15.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel15.Location = new System.Drawing.Point(314, 0);
            this.panel15.Margin = new System.Windows.Forms.Padding(2);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(10, 63);
            this.panel15.TabIndex = 33;
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
            this.BtnHistorial.Visible = false;
            this.BtnHistorial.Click += new System.EventHandler(this.BtnHistorial_Click);
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
            // BtnReTK
            // 
            this.BtnReTK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.BtnReTK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnReTK.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnReTK.FlatAppearance.BorderSize = 0;
            this.BtnReTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReTK.Image = global::ProyectoOFI.Properties.Resources.icons8_tareas_paralelas;
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
            // LblPrincipal
            // 
            this.LblPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(181)))));
            this.LblPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 80F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPrincipal.ForeColor = System.Drawing.Color.White;
            this.LblPrincipal.Location = new System.Drawing.Point(0, 0);
            this.LblPrincipal.Name = "LblPrincipal";
            this.LblPrincipal.Size = new System.Drawing.Size(1226, 714);
            this.LblPrincipal.TabIndex = 0;
            this.LblPrincipal.Text = "Bienvenido a \r\nCoffeeTec 👋";
            this.LblPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Margin = new System.Windows.Forms.Padding(2);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(11, 714);
            this.panel11.TabIndex = 14;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Fuchsia;
            this.panel4.Controls.Add(this.pbIcono);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(2, 2);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(144, 91);
            this.panel4.TabIndex = 12;
            // 
            // pbIcono
            // 
            this.pbIcono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.pbIcono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbIcono.Image = global::ProyectoOFI.Properties.Resources.Logo;
            this.pbIcono.Location = new System.Drawing.Point(0, 0);
            this.pbIcono.Name = "pbIcono";
            this.pbIcono.Size = new System.Drawing.Size(144, 91);
            this.pbIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIcono.TabIndex = 2;
            this.pbIcono.TabStop = false;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(11, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(149, 5);
            this.panel8.TabIndex = 13;
            // 
            // plfooter
            // 
            this.plfooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.plfooter.Controls.Add(this.flowLayoutPanel1);
            this.plfooter.Controls.Add(this.panel8);
            this.plfooter.Controls.Add(this.panel11);
            this.plfooter.Dock = System.Windows.Forms.DockStyle.Left;
            this.plfooter.Location = new System.Drawing.Point(0, 74);
            this.plfooter.Name = "plfooter";
            this.plfooter.Size = new System.Drawing.Size(160, 714);
            this.plfooter.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Controls.Add(this.btnTransferencia);
            this.flowLayoutPanel1.Controls.Add(this.BtnCPatio);
            this.flowLayoutPanel1.Controls.Add(this.BtnSM);
            this.flowLayoutPanel1.Controls.Add(this.BtnAnalisis);
            this.flowLayoutPanel1.Controls.Add(this.BtnAlmacen);
            this.flowLayoutPanel1.Controls.Add(this.BtnComprasD);
            this.flowLayoutPanel1.Controls.Add(this.BtnUser);
            this.flowLayoutPanel1.Controls.Add(this.BtnCatalogo);
            this.flowLayoutPanel1.Controls.Add(this.BtnReportes);
            this.flowLayoutPanel1.Controls.Add(this.btnSalir);
            this.flowLayoutPanel1.Controls.Add(this.BtnCerrarSesion);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(11, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(149, 709);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // btnTransferencia
            // 
            this.btnTransferencia.BackColor = System.Drawing.Color.Transparent;
            this.btnTransferencia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransferencia.FlatAppearance.BorderSize = 0;
            this.btnTransferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransferencia.Image = global::ProyectoOFI.Properties.Resources.Plan;
            this.btnTransferencia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransferencia.Location = new System.Drawing.Point(2, 97);
            this.btnTransferencia.Margin = new System.Windows.Forms.Padding(2);
            this.btnTransferencia.Name = "btnTransferencia";
            this.btnTransferencia.Size = new System.Drawing.Size(142, 66);
            this.btnTransferencia.TabIndex = 0;
            this.btnTransferencia.Text = "Transferencias";
            this.btnTransferencia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTransferencia.UseVisualStyleBackColor = false;
            this.btnTransferencia.Click += new System.EventHandler(this.BtnTransferencia_Click);
            // 
            // BtnCPatio
            // 
            this.BtnCPatio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.BtnCPatio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCPatio.FlatAppearance.BorderSize = 0;
            this.BtnCPatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCPatio.Image = global::ProyectoOFI.Properties.Resources.business_report_48px;
            this.BtnCPatio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCPatio.Location = new System.Drawing.Point(2, 167);
            this.BtnCPatio.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCPatio.Name = "BtnCPatio";
            this.BtnCPatio.Size = new System.Drawing.Size(144, 66);
            this.BtnCPatio.TabIndex = 1;
            this.BtnCPatio.Text = "Control de Patio";
            this.BtnCPatio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCPatio.UseVisualStyleBackColor = false;
            this.BtnCPatio.Click += new System.EventHandler(this.BtnCPatio_Click);
            // 
            // BtnSM
            // 
            this.BtnSM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.BtnSM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSM.FlatAppearance.BorderSize = 0;
            this.BtnSM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSM.Image = global::ProyectoOFI.Properties.Resources.factory_50px;
            this.BtnSM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSM.Location = new System.Drawing.Point(2, 237);
            this.BtnSM.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSM.Name = "BtnSM";
            this.BtnSM.Size = new System.Drawing.Size(142, 66);
            this.BtnSM.TabIndex = 2;
            this.BtnSM.Text = "Secado Mecánico";
            this.BtnSM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSM.UseVisualStyleBackColor = false;
            this.BtnSM.Click += new System.EventHandler(this.BtnSM_Click);
            // 
            // BtnAnalisis
            // 
            this.BtnAnalisis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.BtnAnalisis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnAnalisis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAnalisis.FlatAppearance.BorderSize = 0;
            this.BtnAnalisis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAnalisis.Image = ((System.Drawing.Image)(resources.GetObject("BtnAnalisis.Image")));
            this.BtnAnalisis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAnalisis.Location = new System.Drawing.Point(2, 307);
            this.BtnAnalisis.Margin = new System.Windows.Forms.Padding(2);
            this.BtnAnalisis.Name = "BtnAnalisis";
            this.BtnAnalisis.Size = new System.Drawing.Size(142, 66);
            this.BtnAnalisis.TabIndex = 3;
            this.BtnAnalisis.Text = "Análisis";
            this.BtnAnalisis.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnAnalisis.UseVisualStyleBackColor = false;
            this.BtnAnalisis.Click += new System.EventHandler(this.BtnAnalisis_Click);
            // 
            // BtnAlmacen
            // 
            this.BtnAlmacen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.BtnAlmacen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAlmacen.FlatAppearance.BorderSize = 0;
            this.BtnAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAlmacen.Image = global::ProyectoOFI.Properties.Resources.icons8_almacén;
            this.BtnAlmacen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAlmacen.Location = new System.Drawing.Point(2, 377);
            this.BtnAlmacen.Margin = new System.Windows.Forms.Padding(2);
            this.BtnAlmacen.Name = "BtnAlmacen";
            this.BtnAlmacen.Size = new System.Drawing.Size(142, 66);
            this.BtnAlmacen.TabIndex = 4;
            this.BtnAlmacen.Text = "Almacén";
            this.BtnAlmacen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnAlmacen.UseVisualStyleBackColor = false;
            this.BtnAlmacen.Click += new System.EventHandler(this.BtnAlmacen_Click);
            // 
            // BtnComprasD
            // 
            this.BtnComprasD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.BtnComprasD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnComprasD.FlatAppearance.BorderSize = 0;
            this.BtnComprasD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnComprasD.Image = global::ProyectoOFI.Properties.Resources.icons8_en_tránsito;
            this.BtnComprasD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnComprasD.Location = new System.Drawing.Point(2, 447);
            this.BtnComprasD.Margin = new System.Windows.Forms.Padding(2);
            this.BtnComprasD.Name = "BtnComprasD";
            this.BtnComprasD.Size = new System.Drawing.Size(142, 66);
            this.BtnComprasD.TabIndex = 5;
            this.BtnComprasD.Text = "Compras Directas";
            this.BtnComprasD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnComprasD.UseVisualStyleBackColor = false;
            this.BtnComprasD.Click += new System.EventHandler(this.BtnComprasD_Click);
            // 
            // BtnUser
            // 
            this.BtnUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.BtnUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnUser.FlatAppearance.BorderSize = 0;
            this.BtnUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUser.Image = global::ProyectoOFI.Properties.Resources.icons8_usuario_masculino_en_círculo;
            this.BtnUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUser.Location = new System.Drawing.Point(2, 517);
            this.BtnUser.Margin = new System.Windows.Forms.Padding(2);
            this.BtnUser.Name = "BtnUser";
            this.BtnUser.Size = new System.Drawing.Size(142, 66);
            this.BtnUser.TabIndex = 6;
            this.BtnUser.Text = "Usuario";
            this.BtnUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnUser.UseVisualStyleBackColor = false;
            this.BtnUser.Visible = false;
            this.BtnUser.Click += new System.EventHandler(this.BtnUser_Click);
            // 
            // BtnCatalogo
            // 
            this.BtnCatalogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.BtnCatalogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCatalogo.FlatAppearance.BorderSize = 0;
            this.BtnCatalogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCatalogo.Image = global::ProyectoOFI.Properties.Resources.icons8_magazine_50;
            this.BtnCatalogo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCatalogo.Location = new System.Drawing.Point(2, 587);
            this.BtnCatalogo.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCatalogo.Name = "BtnCatalogo";
            this.BtnCatalogo.Size = new System.Drawing.Size(142, 66);
            this.BtnCatalogo.TabIndex = 7;
            this.BtnCatalogo.Text = "Catálogo";
            this.BtnCatalogo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCatalogo.UseVisualStyleBackColor = false;
            this.BtnCatalogo.Click += new System.EventHandler(this.BtnCatalogo_Click);
            // 
            // BtnReportes
            // 
            this.BtnReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.BtnReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnReportes.FlatAppearance.BorderSize = 0;
            this.BtnReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReportes.Image = global::ProyectoOFI.Properties.Resources.icons8_gráfico_combinado;
            this.BtnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReportes.Location = new System.Drawing.Point(153, 5);
            this.BtnReportes.Margin = new System.Windows.Forms.Padding(5);
            this.BtnReportes.Name = "BtnReportes";
            this.BtnReportes.Size = new System.Drawing.Size(142, 66);
            this.BtnReportes.TabIndex = 8;
            this.BtnReportes.Text = "Reportes";
            this.BtnReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnReportes.UseVisualStyleBackColor = false;
            this.BtnReportes.Click += new System.EventHandler(this.BtnReportes_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::ProyectoOFI.Properties.Resources.Atras;
            this.btnSalir.Location = new System.Drawing.Point(151, 79);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(142, 66);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // BtnCerrarSesion
            // 
            this.BtnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.BtnCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCerrarSesion.Image = global::ProyectoOFI.Properties.Resources.icons8_cerrar_sesión;
            this.BtnCerrarSesion.Location = new System.Drawing.Point(151, 151);
            this.BtnCerrarSesion.Name = "BtnCerrarSesion";
            this.BtnCerrarSesion.Size = new System.Drawing.Size(142, 66);
            this.BtnCerrarSesion.TabIndex = 10;
            this.BtnCerrarSesion.UseVisualStyleBackColor = false;
            this.BtnCerrarSesion.Click += new System.EventHandler(this.BtnCerrarSesion_Click);
            // 
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.PlPrincipal);
            this.Controls.Add(this.plfooter);
            this.Controls.Add(this.plTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario";
            this.Load += new System.EventHandler(this.frmInicio_Load);
            this.plTitulo.ResumeLayout(false);
            this.PlPerfil.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbPerfil)).EndInit();
            this.PlPrincipal.ResumeLayout(false);
            this.PlOpciones.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcono)).EndInit();
            this.plfooter.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plTitulo;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel PlPrincipal;
        private System.Windows.Forms.Panel PlPerfil;
        private System.Windows.Forms.PictureBox PbPerfil;
        private System.Windows.Forms.Label LblUser;
        private System.Windows.Forms.Label LblPrincipal;
        private System.Windows.Forms.Panel PlOpciones;
        private System.Windows.Forms.Button BtnHistorial;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button BtnReTK;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button BtnGrafico;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button BtnUser;
        private System.Windows.Forms.Button BtnCatalogo;
        private System.Windows.Forms.Button BtnComprasD;
        private System.Windows.Forms.Button BtnAlmacen;
        private System.Windows.Forms.Button BtnReportes;
        private System.Windows.Forms.Button BtnAnalisis;
        private System.Windows.Forms.Button BtnCPatio;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button BtnSM;
        private System.Windows.Forms.Button btnTransferencia;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pbIcono;
        private System.Windows.Forms.Button BtnCerrarSesion;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel plfooter;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label LblModulo;
        private System.Windows.Forms.Button BtnConsolidaciones;
        private System.Windows.Forms.Panel panel1;
    }
}

