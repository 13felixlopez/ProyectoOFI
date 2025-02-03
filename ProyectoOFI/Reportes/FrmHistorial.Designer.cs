namespace ProyectoOFI.Reportes
{
    partial class FrmHistorial
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHistorial));
            this.PlTitulo = new System.Windows.Forms.Panel();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PlOpciones = new System.Windows.Forms.Panel();
            this.PlFiltroFecha = new System.Windows.Forms.Panel();
            this.DtpFin = new System.Windows.Forms.DateTimePicker();
            this.BtnFiltroFecha = new System.Windows.Forms.Button();
            this.DtpInicio = new System.Windows.Forms.DateTimePicker();
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.CbBuscador = new System.Windows.Forms.ComboBox();
            this.CbBuscar = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.plfooter = new System.Windows.Forms.Panel();
            this.btn_atras = new System.Windows.Forms.Button();
            this.btn_Sig = new System.Windows.Forms.Button();
            this.btn_Primera = new System.Windows.Forms.Button();
            this.btn_Ultima = new System.Windows.Forms.Button();
            this.lbl_totalPaginas = new System.Windows.Forms.Label();
            this.Label35 = new System.Windows.Forms.Label();
            this.lbl_Pagina = new System.Windows.Forms.Label();
            this.Label25 = new System.Windows.Forms.Label();
            this.DtHistorial = new System.Windows.Forms.DataGridView();
            this.PlCarga = new System.Windows.Forms.Panel();
            this.PbCarga = new System.Windows.Forms.PictureBox();
            this.PbExcel = new System.Windows.Forms.PictureBox();
            this.PlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PlOpciones.SuspendLayout();
            this.PlFiltroFecha.SuspendLayout();
            this.plfooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtHistorial)).BeginInit();
            this.PlCarga.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbCarga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // PlTitulo
            // 
            this.PlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(115)))), ((int)(((byte)(192)))));
            this.PlTitulo.Controls.Add(this.LblTitulo);
            this.PlTitulo.Controls.Add(this.BtnCerrar);
            this.PlTitulo.Controls.Add(this.pictureBox1);
            this.PlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlTitulo.Location = new System.Drawing.Point(0, 0);
            this.PlTitulo.Name = "PlTitulo";
            this.PlTitulo.Size = new System.Drawing.Size(1386, 65);
            this.PlTitulo.TabIndex = 7;
            // 
            // LblTitulo
            // 
            this.LblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(100, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(1211, 65);
            this.LblTitulo.TabIndex = 2;
            this.LblTitulo.Text = "Historial de Cambios";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
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
            this.pictureBox1.Image = global::ProyectoOFI.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // PlOpciones
            // 
            this.PlOpciones.BackColor = System.Drawing.Color.White;
            this.PlOpciones.Controls.Add(this.PbExcel);
            this.PlOpciones.Controls.Add(this.PlFiltroFecha);
            this.PlOpciones.Controls.Add(this.txtBuscador);
            this.PlOpciones.Controls.Add(this.CbBuscador);
            this.PlOpciones.Controls.Add(this.CbBuscar);
            this.PlOpciones.Controls.Add(this.label3);
            this.PlOpciones.Controls.Add(this.label4);
            this.PlOpciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlOpciones.Location = new System.Drawing.Point(0, 65);
            this.PlOpciones.Name = "PlOpciones";
            this.PlOpciones.Size = new System.Drawing.Size(1386, 67);
            this.PlOpciones.TabIndex = 8;
            // 
            // PlFiltroFecha
            // 
            this.PlFiltroFecha.Controls.Add(this.DtpFin);
            this.PlFiltroFecha.Controls.Add(this.BtnFiltroFecha);
            this.PlFiltroFecha.Controls.Add(this.DtpInicio);
            this.PlFiltroFecha.Location = new System.Drawing.Point(611, 6);
            this.PlFiltroFecha.Name = "PlFiltroFecha";
            this.PlFiltroFecha.Size = new System.Drawing.Size(341, 50);
            this.PlFiltroFecha.TabIndex = 13;
            this.PlFiltroFecha.Visible = false;
            // 
            // DtpFin
            // 
            this.DtpFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.DtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFin.Location = new System.Drawing.Point(140, 11);
            this.DtpFin.Name = "DtpFin";
            this.DtpFin.Size = new System.Drawing.Size(118, 26);
            this.DtpFin.TabIndex = 5;
            // 
            // BtnFiltroFecha
            // 
            this.BtnFiltroFecha.Location = new System.Drawing.Point(264, 3);
            this.BtnFiltroFecha.Name = "BtnFiltroFecha";
            this.BtnFiltroFecha.Size = new System.Drawing.Size(65, 44);
            this.BtnFiltroFecha.TabIndex = 6;
            this.BtnFiltroFecha.Text = "Filtrar";
            this.BtnFiltroFecha.UseVisualStyleBackColor = true;
            this.BtnFiltroFecha.Click += new System.EventHandler(this.BtnFiltroFecha_Click);
            // 
            // DtpInicio
            // 
            this.DtpInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.DtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpInicio.Location = new System.Drawing.Point(16, 12);
            this.DtpInicio.Name = "DtpInicio";
            this.DtpInicio.Size = new System.Drawing.Size(118, 26);
            this.DtpInicio.TabIndex = 5;
            // 
            // txtBuscador
            // 
            this.txtBuscador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBuscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtBuscador.Location = new System.Drawing.Point(618, 17);
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(161, 26);
            this.txtBuscador.TabIndex = 12;
            this.txtBuscador.TextChanged += new System.EventHandler(this.txtBuscador_TextChanged);
            // 
            // CbBuscador
            // 
            this.CbBuscador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CbBuscador.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CbBuscador.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.CbBuscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.CbBuscador.FormattingEnabled = true;
            this.CbBuscador.Items.AddRange(new object[] {
            "Ticket",
            "Calidad"});
            this.CbBuscador.Location = new System.Drawing.Point(618, 16);
            this.CbBuscador.Name = "CbBuscador";
            this.CbBuscador.Size = new System.Drawing.Size(168, 28);
            this.CbBuscador.TabIndex = 10;
            this.CbBuscador.Visible = false;
            this.CbBuscador.SelectedIndexChanged += new System.EventHandler(this.CbBuscador_SelectedIndexChanged);
            // 
            // CbBuscar
            // 
            this.CbBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CbBuscar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CbBuscar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.CbBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.CbBuscar.FormattingEnabled = true;
            this.CbBuscar.Location = new System.Drawing.Point(358, 16);
            this.CbBuscar.Name = "CbBuscar";
            this.CbBuscar.Size = new System.Drawing.Size(168, 28);
            this.CbBuscar.TabIndex = 11;
            this.CbBuscar.SelectedIndexChanged += new System.EventHandler(this.CbBuscar_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(542, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Buscar:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(127, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Elija lo que desee buscar:";
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
            this.plfooter.Location = new System.Drawing.Point(0, 728);
            this.plfooter.Name = "plfooter";
            this.plfooter.Size = new System.Drawing.Size(1386, 60);
            this.plfooter.TabIndex = 9;
            // 
            // btn_atras
            // 
            this.btn_atras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_atras.BackColor = System.Drawing.Color.Silver;
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
            this.btn_atras.Click += new System.EventHandler(this.btn_atras_Click);
            // 
            // btn_Sig
            // 
            this.btn_Sig.BackColor = System.Drawing.Color.Silver;
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
            this.btn_Sig.Click += new System.EventHandler(this.btn_Sig_Click);
            // 
            // btn_Primera
            // 
            this.btn_Primera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Primera.BackColor = System.Drawing.Color.Silver;
            this.btn_Primera.FlatAppearance.BorderSize = 0;
            this.btn_Primera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Primera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Primera.Location = new System.Drawing.Point(938, 7);
            this.btn_Primera.Name = "btn_Primera";
            this.btn_Primera.Size = new System.Drawing.Size(154, 46);
            this.btn_Primera.TabIndex = 26;
            this.btn_Primera.Text = "Primera Página";
            this.btn_Primera.UseVisualStyleBackColor = false;
            this.btn_Primera.Click += new System.EventHandler(this.btn_Primera_Click);
            // 
            // btn_Ultima
            // 
            this.btn_Ultima.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Ultima.BackColor = System.Drawing.Color.Silver;
            this.btn_Ultima.FlatAppearance.BorderSize = 0;
            this.btn_Ultima.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Ultima.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Ultima.Location = new System.Drawing.Point(778, 7);
            this.btn_Ultima.Name = "btn_Ultima";
            this.btn_Ultima.Size = new System.Drawing.Size(154, 46);
            this.btn_Ultima.TabIndex = 25;
            this.btn_Ultima.Text = "Última Página";
            this.btn_Ultima.UseVisualStyleBackColor = false;
            this.btn_Ultima.Click += new System.EventHandler(this.btn_Ultima_Click);
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
            // DtHistorial
            // 
            this.DtHistorial.AllowUserToAddRows = false;
            this.DtHistorial.AllowUserToDeleteRows = false;
            this.DtHistorial.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtHistorial.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DtHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtHistorial.BackgroundColor = System.Drawing.Color.Silver;
            this.DtHistorial.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtHistorial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DtHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtHistorial.DefaultCellStyle = dataGridViewCellStyle3;
            this.DtHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DtHistorial.Location = new System.Drawing.Point(0, 132);
            this.DtHistorial.Name = "DtHistorial";
            this.DtHistorial.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtHistorial.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DtHistorial.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtHistorial.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DtHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtHistorial.Size = new System.Drawing.Size(1386, 596);
            this.DtHistorial.TabIndex = 10;
            // 
            // PlCarga
            // 
            this.PlCarga.Controls.Add(this.PbCarga);
            this.PlCarga.Location = new System.Drawing.Point(522, 262);
            this.PlCarga.Name = "PlCarga";
            this.PlCarga.Size = new System.Drawing.Size(250, 172);
            this.PlCarga.TabIndex = 11;
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
            // PbExcel
            // 
            this.PbExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PbExcel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbExcel.Image = global::ProyectoOFI.Properties.Resources.sobresalir;
            this.PbExcel.Location = new System.Drawing.Point(1045, 6);
            this.PbExcel.Name = "PbExcel";
            this.PbExcel.Size = new System.Drawing.Size(64, 50);
            this.PbExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbExcel.TabIndex = 14;
            this.PbExcel.TabStop = false;
            this.PbExcel.Click += new System.EventHandler(this.PbExcel_Click);
            // 
            // FrmHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.PlCarga);
            this.Controls.Add(this.DtHistorial);
            this.Controls.Add(this.plfooter);
            this.Controls.Add(this.PlOpciones);
            this.Controls.Add(this.PlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmHistorial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmHistorial";
            this.Load += new System.EventHandler(this.FrmHistorial_Load);
            this.PlTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PlOpciones.ResumeLayout(false);
            this.PlOpciones.PerformLayout();
            this.PlFiltroFecha.ResumeLayout(false);
            this.plfooter.ResumeLayout(false);
            this.plfooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtHistorial)).EndInit();
            this.PlCarga.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbCarga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbExcel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PlTitulo;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel PlOpciones;
        public System.Windows.Forms.Panel plfooter;
        internal System.Windows.Forms.Button btn_atras;
        internal System.Windows.Forms.Button btn_Sig;
        internal System.Windows.Forms.Button btn_Primera;
        internal System.Windows.Forms.Button btn_Ultima;
        internal System.Windows.Forms.Label lbl_totalPaginas;
        internal System.Windows.Forms.Label Label35;
        internal System.Windows.Forms.Label lbl_Pagina;
        internal System.Windows.Forms.Label Label25;
        private System.Windows.Forms.DataGridView DtHistorial;
        private System.Windows.Forms.Panel PlCarga;
        private System.Windows.Forms.PictureBox PbCarga;
        private System.Windows.Forms.Panel PlFiltroFecha;
        private System.Windows.Forms.DateTimePicker DtpFin;
        private System.Windows.Forms.Button BtnFiltroFecha;
        private System.Windows.Forms.DateTimePicker DtpInicio;
        private System.Windows.Forms.TextBox txtBuscador;
        private System.Windows.Forms.ComboBox CbBuscador;
        private System.Windows.Forms.ComboBox CbBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox PbExcel;
    }
}