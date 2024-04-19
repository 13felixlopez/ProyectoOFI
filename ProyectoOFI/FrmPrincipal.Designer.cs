
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
            this.PbPerfil = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.plfooter = new System.Windows.Forms.Panel();
            this.BtnHistorial = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.BtnCerrarSesion = new System.Windows.Forms.Button();
            this.BtnUser = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnCatalogo = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnSM = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCPatio = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnTransferencia = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pbIcono = new System.Windows.Forms.PictureBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.PlPrincipal = new System.Windows.Forms.Panel();
            this.LblPrincipal = new System.Windows.Forms.Label();
            this.plTitulo.SuspendLayout();
            this.PlPerfil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbPerfil)).BeginInit();
            this.plfooter.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcono)).BeginInit();
            this.PlPrincipal.SuspendLayout();
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
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1796, 74);
            this.label1.TabIndex = 4;
            this.label1.Text = "Control de Cafe Recepción ofi";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // plfooter
            // 
            this.plfooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.plfooter.Controls.Add(this.BtnHistorial);
            this.plfooter.Controls.Add(this.panel5);
            this.plfooter.Controls.Add(this.BtnCerrarSesion);
            this.plfooter.Controls.Add(this.BtnUser);
            this.plfooter.Controls.Add(this.panel3);
            this.plfooter.Controls.Add(this.BtnCatalogo);
            this.plfooter.Controls.Add(this.panel2);
            this.plfooter.Controls.Add(this.BtnSM);
            this.plfooter.Controls.Add(this.panel1);
            this.plfooter.Controls.Add(this.BtnCPatio);
            this.plfooter.Controls.Add(this.btnSalir);
            this.plfooter.Controls.Add(this.panel9);
            this.plfooter.Controls.Add(this.btnTransferencia);
            this.plfooter.Controls.Add(this.panel8);
            this.plfooter.Controls.Add(this.panel4);
            this.plfooter.Controls.Add(this.panel11);
            this.plfooter.Dock = System.Windows.Forms.DockStyle.Left;
            this.plfooter.Location = new System.Drawing.Point(0, 74);
            this.plfooter.Name = "plfooter";
            this.plfooter.Size = new System.Drawing.Size(191, 884);
            this.plfooter.TabIndex = 3;
            // 
            // BtnHistorial
            // 
            this.BtnHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.BtnHistorial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnHistorial.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnHistorial.FlatAppearance.BorderSize = 0;
            this.BtnHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHistorial.Image = global::ProyectoOFI.Properties.Resources.icons8_historial_médico;
            this.BtnHistorial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnHistorial.Location = new System.Drawing.Point(11, 477);
            this.BtnHistorial.Margin = new System.Windows.Forms.Padding(2);
            this.BtnHistorial.Name = "BtnHistorial";
            this.BtnHistorial.Size = new System.Drawing.Size(180, 66);
            this.BtnHistorial.TabIndex = 25;
            this.BtnHistorial.Text = "Historial";
            this.BtnHistorial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnHistorial.UseVisualStyleBackColor = false;
            this.BtnHistorial.Click += new System.EventHandler(this.BtnHistorial_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(11, 467);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(180, 10);
            this.panel5.TabIndex = 24;
            // 
            // BtnCerrarSesion
            // 
            this.BtnCerrarSesion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnCerrarSesion.Image = global::ProyectoOFI.Properties.Resources.icons8_cerrar_sesión;
            this.BtnCerrarSesion.Location = new System.Drawing.Point(11, 752);
            this.BtnCerrarSesion.Name = "BtnCerrarSesion";
            this.BtnCerrarSesion.Size = new System.Drawing.Size(180, 66);
            this.BtnCerrarSesion.TabIndex = 23;
            this.BtnCerrarSesion.UseVisualStyleBackColor = true;
            this.BtnCerrarSesion.Click += new System.EventHandler(this.BtnCerrarSesion_Click);
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
            this.BtnUser.Location = new System.Drawing.Point(11, 401);
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
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(11, 391);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(180, 10);
            this.panel3.TabIndex = 21;
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
            this.BtnCatalogo.Location = new System.Drawing.Point(11, 325);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(11, 315);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(180, 10);
            this.panel2.TabIndex = 19;
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
            // btnSalir
            // 
            this.btnSalir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSalir.Image = global::ProyectoOFI.Properties.Resources.Atras;
            this.btnSalir.Location = new System.Drawing.Point(11, 818);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(180, 66);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
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
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Margin = new System.Windows.Forms.Padding(2);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(11, 884);
            this.panel11.TabIndex = 14;
            // 
            // PlPrincipal
            // 
            this.PlPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.PlPrincipal.Controls.Add(this.LblPrincipal);
            this.PlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlPrincipal.Location = new System.Drawing.Point(191, 74);
            this.PlPrincipal.Name = "PlPrincipal";
            this.PlPrincipal.Size = new System.Drawing.Size(1605, 884);
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
            this.LblPrincipal.Size = new System.Drawing.Size(1605, 884);
            this.LblPrincipal.TabIndex = 0;
            this.LblPrincipal.Text = "Bienvenido al \r\nSistema 👋";
            this.LblPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1796, 958);
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
            ((System.ComponentModel.ISupportInitialize)(this.PbPerfil)).EndInit();
            this.plfooter.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcono)).EndInit();
            this.PlPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel plfooter;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label LblPrincipal;
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
        private System.Windows.Forms.Button BtnHistorial;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel PlPerfil;
        private System.Windows.Forms.PictureBox PbPerfil;
        private System.Windows.Forms.Label LblUser;
    }
}

