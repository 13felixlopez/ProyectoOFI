namespace ProyectoOFI.Recepcion
{
    partial class Consolidar
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtTicketCons = new System.Windows.Forms.TextBox();
            this.PnTKCons = new System.Windows.Forms.Panel();
            this.PnTickets = new System.Windows.Forms.Panel();
            this.LblTotalSacos = new System.Windows.Forms.Label();
            this.LblTotalPeso = new System.Windows.Forms.Label();
            this.BtnConsolidar = new System.Windows.Forms.Button();
            this.DtTickets = new System.Windows.Forms.DataGridView();
            this.dtTKCons = new System.Windows.Forms.DataGridView();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.PnTKCons.SuspendLayout();
            this.PnTickets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtTickets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTKCons)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnCancelar);
            this.panel1.Controls.Add(this.BtnConsolidar);
            this.panel1.Controls.Add(this.TxtTicketCons);
            this.panel1.Controls.Add(this.LblTotalPeso);
            this.panel1.Controls.Add(this.LblTotalSacos);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1261, 62);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(176, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "N° de Ticket:";
            // 
            // TxtTicketCons
            // 
            this.TxtTicketCons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTicketCons.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTicketCons.Location = new System.Drawing.Point(354, 17);
            this.TxtTicketCons.Name = "TxtTicketCons";
            this.TxtTicketCons.Size = new System.Drawing.Size(204, 29);
            this.TxtTicketCons.TabIndex = 1;
            // 
            // PnTKCons
            // 
            this.PnTKCons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.PnTKCons.Controls.Add(this.dtTKCons);
            this.PnTKCons.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PnTKCons.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnTKCons.Location = new System.Drawing.Point(0, 62);
            this.PnTKCons.Name = "PnTKCons";
            this.PnTKCons.Size = new System.Drawing.Size(1261, 240);
            this.PnTKCons.TabIndex = 1;
            // 
            // PnTickets
            // 
            this.PnTickets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.PnTickets.Controls.Add(this.DtTickets);
            this.PnTickets.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnTickets.Location = new System.Drawing.Point(0, 302);
            this.PnTickets.Name = "PnTickets";
            this.PnTickets.Size = new System.Drawing.Size(1261, 240);
            this.PnTickets.TabIndex = 2;
            // 
            // LblTotalSacos
            // 
            this.LblTotalSacos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblTotalSacos.AutoSize = true;
            this.LblTotalSacos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalSacos.Location = new System.Drawing.Point(606, 19);
            this.LblTotalSacos.Name = "LblTotalSacos";
            this.LblTotalSacos.Size = new System.Drawing.Size(101, 24);
            this.LblTotalSacos.TabIndex = 0;
            this.LblTotalSacos.Text = "Sacos: 00";
            // 
            // LblTotalPeso
            // 
            this.LblTotalPeso.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblTotalPeso.AutoSize = true;
            this.LblTotalPeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalPeso.Location = new System.Drawing.Point(755, 19);
            this.LblTotalPeso.Name = "LblTotalPeso";
            this.LblTotalPeso.Size = new System.Drawing.Size(146, 24);
            this.LblTotalPeso.TabIndex = 0;
            this.LblTotalPeso.Text = "Peso (Kgs): 00";
            // 
            // BtnConsolidar
            // 
            this.BtnConsolidar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.BtnConsolidar.FlatAppearance.BorderSize = 0;
            this.BtnConsolidar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnConsolidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConsolidar.Location = new System.Drawing.Point(949, 13);
            this.BtnConsolidar.Name = "BtnConsolidar";
            this.BtnConsolidar.Size = new System.Drawing.Size(135, 37);
            this.BtnConsolidar.TabIndex = 2;
            this.BtnConsolidar.Text = "Consolidar";
            this.BtnConsolidar.UseVisualStyleBackColor = false;
            // 
            // DtTickets
            // 
            this.DtTickets.BackgroundColor = System.Drawing.Color.Teal;
            this.DtTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtTickets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtTickets.Location = new System.Drawing.Point(0, 0);
            this.DtTickets.Name = "DtTickets";
            this.DtTickets.Size = new System.Drawing.Size(1261, 240);
            this.DtTickets.TabIndex = 0;
            // 
            // dtTKCons
            // 
            this.dtTKCons.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dtTKCons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtTKCons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtTKCons.Location = new System.Drawing.Point(0, 0);
            this.dtTKCons.Name = "dtTKCons";
            this.dtTKCons.Size = new System.Drawing.Size(1261, 240);
            this.dtTKCons.TabIndex = 0;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnCancelar.FlatAppearance.BorderSize = 0;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.Color.White;
            this.BtnCancelar.Location = new System.Drawing.Point(1101, 13);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(135, 37);
            this.BtnCancelar.TabIndex = 2;
            this.BtnCancelar.Text = "Cerrar";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // Consolidar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PnTickets);
            this.Controls.Add(this.PnTKCons);
            this.Controls.Add(this.panel1);
            this.Name = "Consolidar";
            this.Size = new System.Drawing.Size(1261, 542);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PnTKCons.ResumeLayout(false);
            this.PnTickets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtTickets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTKCons)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtTicketCons;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblTotalPeso;
        private System.Windows.Forms.Label LblTotalSacos;
        private System.Windows.Forms.Panel PnTKCons;
        private System.Windows.Forms.Panel PnTickets;
        private System.Windows.Forms.Button BtnConsolidar;
        private System.Windows.Forms.DataGridView dtTKCons;
        private System.Windows.Forms.DataGridView DtTickets;
        private System.Windows.Forms.Button BtnCancelar;
    }
}
