namespace ProyectoOFI.ControlPatio
{
    partial class FrmExcelCP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExcelCP));
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblFiltros = new System.Windows.Forms.Label();
            this.CLBFiltros = new System.Windows.Forms.CheckedListBox();
            this.PlCerrar = new System.Windows.Forms.Panel();
            this.BtnCerrarFiltro = new System.Windows.Forms.Button();
            this.PlFiltros = new System.Windows.Forms.Panel();
            this.BtnFiltrar = new System.Windows.Forms.Button();
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.plOpciones = new System.Windows.Forms.Panel();
            this.PbExcel = new System.Windows.Forms.PictureBox();
            this.PbFiltro = new System.Windows.Forms.PictureBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.PlTitulo = new System.Windows.Forms.Panel();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DtLotes = new System.Windows.Forms.DataGridView();
            this.PlCerrar.SuspendLayout();
            this.PlFiltros.SuspendLayout();
            this.plOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbFiltro)).BeginInit();
            this.PlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtLotes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(192)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 773);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1386, 15);
            this.panel1.TabIndex = 32;
            // 
            // LblFiltros
            // 
            this.LblFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFiltros.Location = new System.Drawing.Point(0, 0);
            this.LblFiltros.Name = "LblFiltros";
            this.LblFiltros.Size = new System.Drawing.Size(184, 42);
            this.LblFiltros.TabIndex = 3;
            this.LblFiltros.Text = "Filtros";
            this.LblFiltros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CLBFiltros
            // 
            this.CLBFiltros.CheckOnClick = true;
            this.CLBFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLBFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLBFiltros.FormattingEnabled = true;
            this.CLBFiltros.Items.AddRange(new object[] {
            "Ticket",
            "Calidad",
            "Estado Fisico",
            "Daño",
            "Fecha Recibido",
            "Sacos",
            "Peso",
            "MTNR",
            "Tipo Compra",
            "Certificación",
            "MTNT",
            "Área de Secado",
            "Recibidor",
            "Digitador",
            "Proceso",
            "Proceso SN",
            "Consolidado",
            "Fecha Tendido",
            "Patio",
            "UbicacionP",
            "Folio",
            "Fecha de Enfarde",
            "Dias de Secado",
            "Sacos Enfardados",
            "Humedad de Levante",
            "Digitador Enfarde",
            "Fecha Envio",
            "DNIN",
            "Estado Fisico Envio",
            "Destino",
            "Digitador Envio"});
            this.CLBFiltros.Location = new System.Drawing.Point(0, 42);
            this.CLBFiltros.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.CLBFiltros.Name = "CLBFiltros";
            this.CLBFiltros.Size = new System.Drawing.Size(233, 294);
            this.CLBFiltros.TabIndex = 1;
            this.CLBFiltros.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CLBFiltros_ItemCheck);
            // 
            // PlCerrar
            // 
            this.PlCerrar.Controls.Add(this.LblFiltros);
            this.PlCerrar.Controls.Add(this.BtnCerrarFiltro);
            this.PlCerrar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlCerrar.Location = new System.Drawing.Point(0, 0);
            this.PlCerrar.Name = "PlCerrar";
            this.PlCerrar.Size = new System.Drawing.Size(233, 42);
            this.PlCerrar.TabIndex = 0;
            // 
            // BtnCerrarFiltro
            // 
            this.BtnCerrarFiltro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnCerrarFiltro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCerrarFiltro.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCerrarFiltro.Image = global::ProyectoOFI.Properties.Resources.icons8_cerrar_ventana;
            this.BtnCerrarFiltro.Location = new System.Drawing.Point(184, 0);
            this.BtnCerrarFiltro.Name = "BtnCerrarFiltro";
            this.BtnCerrarFiltro.Size = new System.Drawing.Size(49, 42);
            this.BtnCerrarFiltro.TabIndex = 2;
            this.BtnCerrarFiltro.UseVisualStyleBackColor = true;
            this.BtnCerrarFiltro.Click += new System.EventHandler(this.BtnCerrarFiltro_Click);
            // 
            // PlFiltros
            // 
            this.PlFiltros.Controls.Add(this.CLBFiltros);
            this.PlFiltros.Controls.Add(this.BtnFiltrar);
            this.PlFiltros.Controls.Add(this.PlCerrar);
            this.PlFiltros.Location = new System.Drawing.Point(1152, 150);
            this.PlFiltros.MaximumSize = new System.Drawing.Size(233, 395);
            this.PlFiltros.MinimumSize = new System.Drawing.Size(233, 395);
            this.PlFiltros.Name = "PlFiltros";
            this.PlFiltros.Size = new System.Drawing.Size(233, 395);
            this.PlFiltros.TabIndex = 31;
            this.PlFiltros.Visible = false;
            // 
            // BtnFiltrar
            // 
            this.BtnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnFiltrar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFiltrar.Image = global::ProyectoOFI.Properties.Resources.task_alt_FILL1_wght400_GRAD0_opsz24;
            this.BtnFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFiltrar.Location = new System.Drawing.Point(0, 336);
            this.BtnFiltrar.Margin = new System.Windows.Forms.Padding(10);
            this.BtnFiltrar.Name = "BtnFiltrar";
            this.BtnFiltrar.Size = new System.Drawing.Size(233, 59);
            this.BtnFiltrar.TabIndex = 2;
            this.BtnFiltrar.Text = "Aplicar Filtro";
            this.BtnFiltrar.UseVisualStyleBackColor = true;
            this.BtnFiltrar.Click += new System.EventHandler(this.BtnFiltrar_Click);
            // 
            // txtBuscador
            // 
            this.txtBuscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtBuscador.Location = new System.Drawing.Point(673, 18);
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(199, 26);
            this.txtBuscador.TabIndex = 2;
            this.txtBuscador.TextChanged += new System.EventHandler(this.txtBuscador_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(1004, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descargar Excel:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(569, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Buscar:";
            // 
            // plOpciones
            // 
            this.plOpciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.plOpciones.Controls.Add(this.PbExcel);
            this.plOpciones.Controls.Add(this.PbFiltro);
            this.plOpciones.Controls.Add(this.txtBuscador);
            this.plOpciones.Controls.Add(this.label1);
            this.plOpciones.Controls.Add(this.label3);
            this.plOpciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.plOpciones.Location = new System.Drawing.Point(0, 65);
            this.plOpciones.Name = "plOpciones";
            this.plOpciones.Size = new System.Drawing.Size(1386, 62);
            this.plOpciones.TabIndex = 29;
            // 
            // PbExcel
            // 
            this.PbExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbExcel.Image = global::ProyectoOFI.Properties.Resources.icons8_nube_comprobado;
            this.PbExcel.Location = new System.Drawing.Point(1183, 6);
            this.PbExcel.Name = "PbExcel";
            this.PbExcel.Size = new System.Drawing.Size(64, 50);
            this.PbExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbExcel.TabIndex = 4;
            this.PbExcel.TabStop = false;
            this.PbExcel.Click += new System.EventHandler(this.PbExcel_Click);
            // 
            // PbFiltro
            // 
            this.PbFiltro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PbFiltro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbFiltro.Image = global::ProyectoOFI.Properties.Resources.filter_list_FILL0_wght400_GRAD0_opsz24;
            this.PbFiltro.Location = new System.Drawing.Point(906, 6);
            this.PbFiltro.Name = "PbFiltro";
            this.PbFiltro.Size = new System.Drawing.Size(64, 50);
            this.PbFiltro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbFiltro.TabIndex = 4;
            this.PbFiltro.TabStop = false;
            this.PbFiltro.Click += new System.EventHandler(this.PbFiltro_Click);
            // 
            // LblTitulo
            // 
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(100, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1211, 65);
            this.LblTitulo.TabIndex = 2;
            this.LblTitulo.Text = "Exportar a Excel";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlTitulo
            // 
            this.PlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(115)))), ((int)(((byte)(192)))));
            this.PlTitulo.Controls.Add(this.LblTitulo);
            this.PlTitulo.Controls.Add(this.BtnCerrar);
            this.PlTitulo.Controls.Add(this.pictureBox1);
            this.PlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlTitulo.Location = new System.Drawing.Point(0, 0);
            this.PlTitulo.Name = "PlTitulo";
            this.PlTitulo.Size = new System.Drawing.Size(1386, 65);
            this.PlTitulo.TabIndex = 28;
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCerrar.Image = global::ProyectoOFI.Properties.Resources.icons8_cerrar_ventana;
            this.BtnCerrar.Location = new System.Drawing.Point(1311, 0);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(75, 65);
            this.BtnCerrar.TabIndex = 1;
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::ProyectoOFI.Properties.Resources.DRY_SYSTEM;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // DtLotes
            // 
            this.DtLotes.AllowUserToAddRows = false;
            this.DtLotes.AllowUserToDeleteRows = false;
            this.DtLotes.AllowUserToOrderColumns = true;
            this.DtLotes.AllowUserToResizeRows = false;
            this.DtLotes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtLotes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DtLotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DtLotes.DefaultCellStyle = dataGridViewCellStyle1;
            this.DtLotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtLotes.Location = new System.Drawing.Point(0, 127);
            this.DtLotes.Name = "DtLotes";
            this.DtLotes.ReadOnly = true;
            this.DtLotes.RowHeadersVisible = false;
            this.DtLotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtLotes.ShowCellToolTips = false;
            this.DtLotes.ShowEditingIcon = false;
            this.DtLotes.Size = new System.Drawing.Size(1386, 646);
            this.DtLotes.TabIndex = 30;
            this.DtLotes.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DtLotes_CellPainting);
            // 
            // FrmExcelCP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.PlFiltros);
            this.Controls.Add(this.DtLotes);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.plOpciones);
            this.Controls.Add(this.PlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmExcelCP";
            this.Text = "FrmExcelCP";
            this.Load += new System.EventHandler(this.FrmExcelCP_Load);
            this.PlCerrar.ResumeLayout(false);
            this.PlFiltros.ResumeLayout(false);
            this.plOpciones.ResumeLayout(false);
            this.plOpciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbFiltro)).EndInit();
            this.PlTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtLotes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblFiltros;
        private System.Windows.Forms.CheckedListBox CLBFiltros;
        private System.Windows.Forms.Button BtnFiltrar;
        private System.Windows.Forms.Panel PlCerrar;
        private System.Windows.Forms.Button BtnCerrarFiltro;
        private System.Windows.Forms.Panel PlFiltros;
        private System.Windows.Forms.PictureBox PbExcel;
        private System.Windows.Forms.PictureBox PbFiltro;
        private System.Windows.Forms.TextBox txtBuscador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel plOpciones;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel PlTitulo;
        private System.Windows.Forms.DataGridView DtLotes;
    }
}