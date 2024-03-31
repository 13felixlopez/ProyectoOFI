
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
            this.components = new System.ComponentModel.Container();
            this.plTitulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pbIcono = new System.Windows.Forms.PictureBox();
            this.plfooter = new System.Windows.Forms.Panel();
            this.BtnSM = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCPatio = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnTransferencia = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.timerAct = new System.Windows.Forms.Timer(this.components);
            this.PlPrincipal = new System.Windows.Forms.Panel();
            this.LblPrincipal = new System.Windows.Forms.Label();
            this.plTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcono)).BeginInit();
            this.plfooter.SuspendLayout();
            this.PlPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // plTitulo
            // 
            this.plTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.plTitulo.Controls.Add(this.label1);
            this.plTitulo.Controls.Add(this.pbIcono);
            this.plTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTitulo.Location = new System.Drawing.Point(0, 0);
            this.plTitulo.Name = "plTitulo";
            this.plTitulo.Size = new System.Drawing.Size(1246, 74);
            this.plTitulo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(101, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1145, 74);
            this.label1.TabIndex = 4;
            this.label1.Text = "Control de Cafe Recepción OFI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // pbIcono
            // 
            this.pbIcono.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbIcono.Image = global::ProyectoOFI.Properties.Resources.OFI_Make;
            this.pbIcono.Location = new System.Drawing.Point(0, 0);
            this.pbIcono.Name = "pbIcono";
            this.pbIcono.Size = new System.Drawing.Size(101, 74);
            this.pbIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIcono.TabIndex = 1;
            this.pbIcono.TabStop = false;
            // 
            // plfooter
            // 
            this.plfooter.BackColor = System.Drawing.Color.Fuchsia;
            this.plfooter.Controls.Add(this.BtnSM);
            this.plfooter.Controls.Add(this.panel1);
            this.plfooter.Controls.Add(this.BtnCPatio);
            this.plfooter.Controls.Add(this.btnSalir);
            this.plfooter.Controls.Add(this.panel9);
            this.plfooter.Controls.Add(this.btnTransferencia);
            this.plfooter.Controls.Add(this.panel8);
            this.plfooter.Controls.Add(this.panel4);
            this.plfooter.Controls.Add(this.panel11);
            this.plfooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plfooter.Location = new System.Drawing.Point(0, 418);
            this.plfooter.Name = "plfooter";
            this.plfooter.Size = new System.Drawing.Size(1246, 81);
            this.plfooter.TabIndex = 3;
            // 
            // BtnSM
            // 
            this.BtnSM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.BtnSM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSM.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnSM.FlatAppearance.BorderSize = 0;
            this.BtnSM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSM.Image = global::ProyectoOFI.Properties.Resources.factory_50px;
            this.BtnSM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSM.Location = new System.Drawing.Point(367, 5);
            this.BtnSM.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSM.Name = "BtnSM";
            this.BtnSM.Size = new System.Drawing.Size(170, 66);
            this.BtnSM.TabIndex = 18;
            this.BtnSM.Text = "Secado Mecánico";
            this.BtnSM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSM.UseVisualStyleBackColor = false;
            this.BtnSM.Click += new System.EventHandler(this.BtnSM_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Fuchsia;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(359, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(8, 66);
            this.panel1.TabIndex = 16;
            // 
            // BtnCPatio
            // 
            this.BtnCPatio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.BtnCPatio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCPatio.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnCPatio.FlatAppearance.BorderSize = 0;
            this.BtnCPatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCPatio.Image = global::ProyectoOFI.Properties.Resources.business_report_48px;
            this.BtnCPatio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCPatio.Location = new System.Drawing.Point(189, 5);
            this.BtnCPatio.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCPatio.Name = "BtnCPatio";
            this.BtnCPatio.Size = new System.Drawing.Size(170, 66);
            this.BtnCPatio.TabIndex = 15;
            this.BtnCPatio.Text = "Control de Patio";
            this.BtnCPatio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCPatio.UseVisualStyleBackColor = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSalir.Image = global::ProyectoOFI.Properties.Resources.Atras;
            this.btnSalir.Location = new System.Drawing.Point(1171, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 66);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Fuchsia;
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(181, 5);
            this.panel9.Margin = new System.Windows.Forms.Padding(2);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(8, 66);
            this.panel9.TabIndex = 11;
            // 
            // btnTransferencia
            // 
            this.btnTransferencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.btnTransferencia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransferencia.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTransferencia.FlatAppearance.BorderSize = 0;
            this.btnTransferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransferencia.Image = global::ProyectoOFI.Properties.Resources.Plan;
            this.btnTransferencia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransferencia.Location = new System.Drawing.Point(11, 5);
            this.btnTransferencia.Margin = new System.Windows.Forms.Padding(2);
            this.btnTransferencia.Name = "btnTransferencia";
            this.btnTransferencia.Size = new System.Drawing.Size(170, 66);
            this.btnTransferencia.TabIndex = 10;
            this.btnTransferencia.Text = "Transferencias";
            this.btnTransferencia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTransferencia.UseVisualStyleBackColor = false;
            this.btnTransferencia.Click += new System.EventHandler(this.BtnTransferencia_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Fuchsia;
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(11, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1235, 5);
            this.panel8.TabIndex = 13;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Fuchsia;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(11, 71);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1235, 10);
            this.panel4.TabIndex = 12;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Fuchsia;
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Margin = new System.Windows.Forms.Padding(2);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(11, 81);
            this.panel11.TabIndex = 14;
            // 
            // timerAct
            // 
            this.timerAct.Tick += new System.EventHandler(this.timerAct_Tick);
            // 
            // PlPrincipal
            // 
            this.PlPrincipal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PlPrincipal.Controls.Add(this.LblPrincipal);
            this.PlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlPrincipal.Location = new System.Drawing.Point(0, 74);
            this.PlPrincipal.Name = "PlPrincipal";
            this.PlPrincipal.Size = new System.Drawing.Size(1246, 344);
            this.PlPrincipal.TabIndex = 4;
            // 
            // LblPrincipal
            // 
            this.LblPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 80F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPrincipal.Location = new System.Drawing.Point(0, 0);
            this.LblPrincipal.Name = "LblPrincipal";
            this.LblPrincipal.Size = new System.Drawing.Size(1246, 344);
            this.LblPrincipal.TabIndex = 0;
            this.LblPrincipal.Text = "Bienvenido al \r\nSistema 👋";
            this.LblPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1246, 499);
            this.Controls.Add(this.PlPrincipal);
            this.Controls.Add(this.plfooter);
            this.Controls.Add(this.plTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmInicio_Load);
            this.plTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcono)).EndInit();
            this.plfooter.ResumeLayout(false);
            this.PlPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbIcono;
        private System.Windows.Forms.Panel plfooter;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Timer timerAct;
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
    }
}

