namespace ProyectoOFI.SM
{
    partial class SecadoMecanico
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtInventarioSM = new System.Windows.Forms.DataGridView();
            this.plOpciones = new System.Windows.Forms.Panel();
            this.plAgregar = new System.Windows.Forms.Panel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CbOrdenar = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.plfooter = new System.Windows.Forms.Panel();
            this.btn_atras = new System.Windows.Forms.Button();
            this.btn_Sig = new System.Windows.Forms.Button();
            this.btn_Primera = new System.Windows.Forms.Button();
            this.btn_Ultima = new System.Windows.Forms.Button();
            this.lbl_totalPaginas = new System.Windows.Forms.Label();
            this.Label35 = new System.Windows.Forms.Label();
            this.lbl_Pagina = new System.Windows.Forms.Label();
            this.Label25 = new System.Windows.Forms.Label();
            this.timerAct = new System.Windows.Forms.Timer(this.components);
            this.PlCarga = new System.Windows.Forms.Panel();
            this.PbCarga = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtInventarioSM)).BeginInit();
            this.plOpciones.SuspendLayout();
            this.plAgregar.SuspendLayout();
            this.plfooter.SuspendLayout();
            this.PlCarga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbCarga)).BeginInit();
            this.SuspendLayout();
            // 
            // dtInventarioSM
            // 
            this.dtInventarioSM.AllowUserToAddRows = false;
            this.dtInventarioSM.AllowUserToDeleteRows = false;
            this.dtInventarioSM.AllowUserToOrderColumns = true;
            this.dtInventarioSM.AllowUserToResizeRows = false;
            this.dtInventarioSM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtInventarioSM.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtInventarioSM.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtInventarioSM.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtInventarioSM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtInventarioSM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtInventarioSM.Location = new System.Drawing.Point(0, 62);
            this.dtInventarioSM.Name = "dtInventarioSM";
            this.dtInventarioSM.ReadOnly = true;
            this.dtInventarioSM.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtInventarioSM.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtInventarioSM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtInventarioSM.ShowCellToolTips = false;
            this.dtInventarioSM.ShowEditingIcon = false;
            this.dtInventarioSM.Size = new System.Drawing.Size(1225, 398);
            this.dtInventarioSM.TabIndex = 9;
            // 
            // plOpciones
            // 
            this.plOpciones.BackColor = System.Drawing.Color.White;
            this.plOpciones.Controls.Add(this.plAgregar);
            this.plOpciones.Controls.Add(this.textBox1);
            this.plOpciones.Controls.Add(this.CbOrdenar);
            this.plOpciones.Controls.Add(this.label3);
            this.plOpciones.Controls.Add(this.label2);
            this.plOpciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.plOpciones.Location = new System.Drawing.Point(0, 0);
            this.plOpciones.Name = "plOpciones";
            this.plOpciones.Size = new System.Drawing.Size(1225, 62);
            this.plOpciones.TabIndex = 10;
            // 
            // plAgregar
            // 
            this.plAgregar.Controls.Add(this.btnAgregar);
            this.plAgregar.Dock = System.Windows.Forms.DockStyle.Right;
            this.plAgregar.Location = new System.Drawing.Point(1134, 0);
            this.plAgregar.Name = "plAgregar";
            this.plAgregar.Size = new System.Drawing.Size(91, 62);
            this.plAgregar.TabIndex = 3;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregar.Image = global::ProyectoOFI.Properties.Resources.add_64px;
            this.btnAgregar.Location = new System.Drawing.Point(0, 0);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(91, 62);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(683, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 26);
            this.textBox1.TabIndex = 2;
            // 
            // CbOrdenar
            // 
            this.CbOrdenar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CbOrdenar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.CbOrdenar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbOrdenar.FormattingEnabled = true;
            this.CbOrdenar.Items.AddRange(new object[] {
            "Fecha Recibido",
            "Ticket",
            "MTNR",
            "Calidad",
            "Estado Fisico",
            "Recibidor",
            "Digitador"});
            this.CbOrdenar.Location = new System.Drawing.Point(399, 16);
            this.CbOrdenar.Name = "CbOrdenar";
            this.CbOrdenar.Size = new System.Drawing.Size(168, 28);
            this.CbOrdenar.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(582, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Buscar:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(293, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ordenar";
            // 
            // plfooter
            // 
            this.plfooter.BackColor = System.Drawing.Color.Red;
            this.plfooter.Controls.Add(this.btn_atras);
            this.plfooter.Controls.Add(this.btn_Sig);
            this.plfooter.Controls.Add(this.btn_Primera);
            this.plfooter.Controls.Add(this.btn_Ultima);
            this.plfooter.Controls.Add(this.lbl_totalPaginas);
            this.plfooter.Controls.Add(this.Label35);
            this.plfooter.Controls.Add(this.lbl_Pagina);
            this.plfooter.Controls.Add(this.Label25);
            this.plfooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plfooter.Location = new System.Drawing.Point(0, 460);
            this.plfooter.Name = "plfooter";
            this.plfooter.Size = new System.Drawing.Size(1225, 60);
            this.plfooter.TabIndex = 11;
            // 
            // btn_atras
            // 
            this.btn_atras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_atras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_atras.FlatAppearance.BorderSize = 0;
            this.btn_atras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_atras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_atras.ForeColor = System.Drawing.Color.Black;
            this.btn_atras.Location = new System.Drawing.Point(90, 7);
            this.btn_atras.Name = "btn_atras";
            this.btn_atras.Size = new System.Drawing.Size(154, 46);
            this.btn_atras.TabIndex = 20;
            this.btn_atras.Text = "Página Anterior";
            this.btn_atras.UseVisualStyleBackColor = false;
            // 
            // btn_Sig
            // 
            this.btn_Sig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_Sig.FlatAppearance.BorderSize = 0;
            this.btn_Sig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Sig.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sig.ForeColor = System.Drawing.Color.Black;
            this.btn_Sig.Location = new System.Drawing.Point(250, 7);
            this.btn_Sig.Name = "btn_Sig";
            this.btn_Sig.Size = new System.Drawing.Size(159, 46);
            this.btn_Sig.TabIndex = 19;
            this.btn_Sig.Text = "Página Siguiente";
            this.btn_Sig.UseVisualStyleBackColor = false;
            // 
            // btn_Primera
            // 
            this.btn_Primera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Primera.BackColor = System.Drawing.Color.Silver;
            this.btn_Primera.FlatAppearance.BorderSize = 0;
            this.btn_Primera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Primera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Primera.Location = new System.Drawing.Point(850, 7);
            this.btn_Primera.Name = "btn_Primera";
            this.btn_Primera.Size = new System.Drawing.Size(154, 46);
            this.btn_Primera.TabIndex = 26;
            this.btn_Primera.Text = "Primera Página";
            this.btn_Primera.UseVisualStyleBackColor = false;
            // 
            // btn_Ultima
            // 
            this.btn_Ultima.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Ultima.BackColor = System.Drawing.Color.Silver;
            this.btn_Ultima.FlatAppearance.BorderSize = 0;
            this.btn_Ultima.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Ultima.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Ultima.Location = new System.Drawing.Point(690, 7);
            this.btn_Ultima.Name = "btn_Ultima";
            this.btn_Ultima.Size = new System.Drawing.Size(154, 46);
            this.btn_Ultima.TabIndex = 25;
            this.btn_Ultima.Text = "Última Página";
            this.btn_Ultima.UseVisualStyleBackColor = false;
            // 
            // lbl_totalPaginas
            // 
            this.lbl_totalPaginas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_totalPaginas.AutoSize = true;
            this.lbl_totalPaginas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_totalPaginas.ForeColor = System.Drawing.Color.Black;
            this.lbl_totalPaginas.Location = new System.Drawing.Point(652, 20);
            this.lbl_totalPaginas.Name = "lbl_totalPaginas";
            this.lbl_totalPaginas.Size = new System.Drawing.Size(19, 20);
            this.lbl_totalPaginas.TabIndex = 24;
            this.lbl_totalPaginas.Text = "0";
            // 
            // Label35
            // 
            this.Label35.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label35.AutoSize = true;
            this.Label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label35.ForeColor = System.Drawing.Color.White;
            this.Label35.Location = new System.Drawing.Point(495, 20);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(58, 20);
            this.Label35.TabIndex = 21;
            this.Label35.Text = "Pagina";
            // 
            // lbl_Pagina
            // 
            this.lbl_Pagina.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Pagina.AutoSize = true;
            this.lbl_Pagina.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Pagina.ForeColor = System.Drawing.Color.Black;
            this.lbl_Pagina.Location = new System.Drawing.Point(562, 20);
            this.lbl_Pagina.Name = "lbl_Pagina";
            this.lbl_Pagina.Size = new System.Drawing.Size(19, 20);
            this.lbl_Pagina.TabIndex = 22;
            this.lbl_Pagina.Text = "0";
            // 
            // Label25
            // 
            this.Label25.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label25.AutoSize = true;
            this.Label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label25.ForeColor = System.Drawing.Color.White;
            this.Label25.Location = new System.Drawing.Point(607, 20);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(27, 20);
            this.Label25.TabIndex = 23;
            this.Label25.Text = "de";
            // 
            // PlCarga
            // 
            this.PlCarga.Controls.Add(this.PbCarga);
            this.PlCarga.Location = new System.Drawing.Point(487, 174);
            this.PlCarga.Name = "PlCarga";
            this.PlCarga.Size = new System.Drawing.Size(250, 172);
            this.PlCarga.TabIndex = 12;
            // 
            // PbCarga
            // 
            this.PbCarga.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PbCarga.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PbCarga.Image = global::ProyectoOFI.Properties.Resources.loading_12;
            this.PbCarga.Location = new System.Drawing.Point(0, 0);
            this.PbCarga.Name = "PbCarga";
            this.PbCarga.Size = new System.Drawing.Size(250, 172);
            this.PbCarga.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbCarga.TabIndex = 0;
            this.PbCarga.TabStop = false;
            // 
            // SecadoMecanico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PlCarga);
            this.Controls.Add(this.dtInventarioSM);
            this.Controls.Add(this.plOpciones);
            this.Controls.Add(this.plfooter);
            this.Name = "SecadoMecanico";
            this.Size = new System.Drawing.Size(1225, 520);
            this.Load += new System.EventHandler(this.SecadoMecanico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtInventarioSM)).EndInit();
            this.plOpciones.ResumeLayout(false);
            this.plOpciones.PerformLayout();
            this.plAgregar.ResumeLayout(false);
            this.plfooter.ResumeLayout(false);
            this.plfooter.PerformLayout();
            this.PlCarga.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbCarga)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dtInventarioSM;
        private System.Windows.Forms.Panel plOpciones;
        private System.Windows.Forms.Panel plAgregar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox CbOrdenar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel plfooter;
        internal System.Windows.Forms.Button btn_atras;
        internal System.Windows.Forms.Button btn_Sig;
        internal System.Windows.Forms.Button btn_Primera;
        internal System.Windows.Forms.Button btn_Ultima;
        internal System.Windows.Forms.Label lbl_totalPaginas;
        internal System.Windows.Forms.Label Label35;
        internal System.Windows.Forms.Label lbl_Pagina;
        internal System.Windows.Forms.Label Label25;
        private System.Windows.Forms.Timer timerAct;
        private System.Windows.Forms.Panel PlCarga;
        private System.Windows.Forms.PictureBox PbCarga;
    }
}
