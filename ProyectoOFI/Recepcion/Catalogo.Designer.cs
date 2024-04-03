namespace ProyectoOFI.Recepcion
{
    partial class Catalogo
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
            this.PlPrincipal = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.TxtAgencia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PlCentro = new System.Windows.Forms.Panel();
            this.DtAgencia = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.PlTitulo = new System.Windows.Forms.Panel();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.PlPrincipal.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.PlCentro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtAgencia)).BeginInit();
            this.PlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PlPrincipal
            // 
            this.PlPrincipal.Controls.Add(this.PlCentro);
            this.PlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlPrincipal.Location = new System.Drawing.Point(0, 0);
            this.PlPrincipal.Name = "PlPrincipal";
            this.PlPrincipal.Size = new System.Drawing.Size(579, 634);
            this.PlPrincipal.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnEditar);
            this.groupBox1.Controls.Add(this.BtnGuardar);
            this.groupBox1.Controls.Add(this.TxtAgencia);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(579, 196);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // BtnEditar
            // 
            this.BtnEditar.Image = global::ProyectoOFI.Properties.Resources.wired_outline_35_edit;
            this.BtnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEditar.Location = new System.Drawing.Point(298, 81);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(107, 74);
            this.BtnEditar.TabIndex = 2;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEditar.UseVisualStyleBackColor = true;
            this.BtnEditar.Visible = false;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Image = global::ProyectoOFI.Properties.Resources.icons8_guardar;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardar.Location = new System.Drawing.Point(133, 81);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(143, 74);
            this.BtnGuardar.TabIndex = 2;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // TxtAgencia
            // 
            this.TxtAgencia.Location = new System.Drawing.Point(228, 49);
            this.TxtAgencia.Name = "TxtAgencia";
            this.TxtAgencia.Size = new System.Drawing.Size(285, 26);
            this.TxtAgencia.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de Agencia:";
            // 
            // PlCentro
            // 
            this.PlCentro.Controls.Add(this.groupBox1);
            this.PlCentro.Controls.Add(this.DtAgencia);
            this.PlCentro.Controls.Add(this.PlTitulo);
            this.PlCentro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlCentro.Location = new System.Drawing.Point(0, 0);
            this.PlCentro.Name = "PlCentro";
            this.PlCentro.Size = new System.Drawing.Size(579, 634);
            this.PlCentro.TabIndex = 2;
            // 
            // DtAgencia
            // 
            this.DtAgencia.AllowUserToAddRows = false;
            this.DtAgencia.AllowUserToDeleteRows = false;
            this.DtAgencia.AllowUserToOrderColumns = true;
            this.DtAgencia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtAgencia.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtAgencia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DtAgencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtAgencia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DtAgencia.DefaultCellStyle = dataGridViewCellStyle2;
            this.DtAgencia.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DtAgencia.Location = new System.Drawing.Point(0, 261);
            this.DtAgencia.Name = "DtAgencia";
            this.DtAgencia.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DtAgencia.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DtAgencia.RowHeadersVisible = false;
            this.DtAgencia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DtAgencia.Size = new System.Drawing.Size(579, 373);
            this.DtAgencia.TabIndex = 5;
            this.DtAgencia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtAgencia_CellClick);
            this.DtAgencia.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtAgencia_CellContentClick);
            // 
            // Eliminar
            // 
            this.Eliminar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Eliminar.HeaderText = "";
            this.Eliminar.Image = global::ProyectoOFI.Properties.Resources.Delete;
            this.Eliminar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Width = 5;
            // 
            // PlTitulo
            // 
            this.PlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.PlTitulo.Controls.Add(this.LblTitulo);
            this.PlTitulo.Controls.Add(this.BtnCerrar);
            this.PlTitulo.Controls.Add(this.pictureBox1);
            this.PlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlTitulo.Location = new System.Drawing.Point(0, 0);
            this.PlTitulo.Name = "PlTitulo";
            this.PlTitulo.Size = new System.Drawing.Size(579, 65);
            this.PlTitulo.TabIndex = 3;
            // 
            // LblTitulo
            // 
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.Location = new System.Drawing.Point(100, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(404, 65);
            this.LblTitulo.TabIndex = 2;
            this.LblTitulo.Text = "Agregar Agencia";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCerrar.Image = global::ProyectoOFI.Properties.Resources.icons8_cerrar_ventana;
            this.BtnCerrar.Location = new System.Drawing.Point(504, 0);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(75, 65);
            this.BtnCerrar.TabIndex = 1;
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::ProyectoOFI.Properties.Resources.OFI_Make;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::ProyectoOFI.Properties.Resources.Delete;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            // 
            // Catalogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 634);
            this.Controls.Add(this.PlPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(579, 634);
            this.MinimumSize = new System.Drawing.Size(579, 634);
            this.Name = "Catalogo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgregarAgencia";
            this.PlPrincipal.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.PlCentro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtAgencia)).EndInit();
            this.PlTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Panel PlPrincipal;
        private System.Windows.Forms.Panel PlCentro;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.TextBox TxtAgencia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DtAgencia;
        private System.Windows.Forms.DataGridViewImageColumn Eliminar;
        private System.Windows.Forms.Panel PlTitulo;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
    }
}