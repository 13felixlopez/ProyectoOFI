namespace ProyectoOFI.Otros
{
    partial class FrmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfig));
            this.PlTitulo = new System.Windows.Forms.Panel();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.GbTransfer = new System.Windows.Forms.GroupBox();
            this.GbControlPatio = new System.Windows.Forms.GroupBox();
            this.GbSM = new System.Windows.Forms.GroupBox();
            this.BtnOperadores = new System.Windows.Forms.Button();
            this.BtnTurnos = new System.Windows.Forms.Button();
            this.BtnParos = new System.Windows.Forms.Button();
            this.BtnPatio = new System.Windows.Forms.Button();
            this.BtnUbicacionesPatio = new System.Windows.Forms.Button();
            this.BtnAgencia = new System.Windows.Forms.Button();
            this.BtnCert = new System.Windows.Forms.Button();
            this.BtnCompra = new System.Windows.Forms.Button();
            this.BtnEstf = new System.Windows.Forms.Button();
            this.BtnClientes = new System.Windows.Forms.Button();
            this.BtnCalidad = new System.Windows.Forms.Button();
            this.BtnRecibidor = new System.Windows.Forms.Button();
            this.BtnDaño = new System.Windows.Forms.Button();
            this.BtnAcopio = new System.Windows.Forms.Button();
            this.BtnAreaS = new System.Windows.Forms.Button();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PlTitulo.SuspendLayout();
            this.GbTransfer.SuspendLayout();
            this.GbControlPatio.SuspendLayout();
            this.GbSM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.PlTitulo.Size = new System.Drawing.Size(1070, 65);
            this.PlTitulo.TabIndex = 22;
            // 
            // LblTitulo
            // 
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.Location = new System.Drawing.Point(100, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(895, 65);
            this.LblTitulo.TabIndex = 2;
            this.LblTitulo.Text = "Configuraciones";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GbTransfer
            // 
            this.GbTransfer.Controls.Add(this.BtnAgencia);
            this.GbTransfer.Controls.Add(this.BtnCert);
            this.GbTransfer.Controls.Add(this.BtnCompra);
            this.GbTransfer.Controls.Add(this.BtnEstf);
            this.GbTransfer.Controls.Add(this.BtnClientes);
            this.GbTransfer.Controls.Add(this.BtnCalidad);
            this.GbTransfer.Controls.Add(this.BtnRecibidor);
            this.GbTransfer.Controls.Add(this.BtnDaño);
            this.GbTransfer.Controls.Add(this.BtnAcopio);
            this.GbTransfer.Controls.Add(this.BtnAreaS);
            this.GbTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GbTransfer.Location = new System.Drawing.Point(12, 71);
            this.GbTransfer.Name = "GbTransfer";
            this.GbTransfer.Size = new System.Drawing.Size(435, 428);
            this.GbTransfer.TabIndex = 23;
            this.GbTransfer.TabStop = false;
            this.GbTransfer.Text = "Tranferencias";
            // 
            // GbControlPatio
            // 
            this.GbControlPatio.Controls.Add(this.BtnPatio);
            this.GbControlPatio.Controls.Add(this.BtnUbicacionesPatio);
            this.GbControlPatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GbControlPatio.Location = new System.Drawing.Point(453, 71);
            this.GbControlPatio.Name = "GbControlPatio";
            this.GbControlPatio.Size = new System.Drawing.Size(251, 159);
            this.GbControlPatio.TabIndex = 24;
            this.GbControlPatio.TabStop = false;
            this.GbControlPatio.Text = "Control de Patio";
            // 
            // GbSM
            // 
            this.GbSM.Controls.Add(this.BtnOperadores);
            this.GbSM.Controls.Add(this.BtnTurnos);
            this.GbSM.Controls.Add(this.BtnParos);
            this.GbSM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GbSM.Location = new System.Drawing.Point(453, 232);
            this.GbSM.Name = "GbSM";
            this.GbSM.Size = new System.Drawing.Size(251, 267);
            this.GbSM.TabIndex = 24;
            this.GbSM.TabStop = false;
            this.GbSM.Text = "Secado Mecánico";
            // 
            // BtnOperadores
            // 
            this.BtnOperadores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnOperadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOperadores.Image = global::ProyectoOFI.Properties.Resources.MdiBank;
            this.BtnOperadores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOperadores.Location = new System.Drawing.Point(44, 44);
            this.BtnOperadores.Name = "BtnOperadores";
            this.BtnOperadores.Size = new System.Drawing.Size(162, 55);
            this.BtnOperadores.TabIndex = 13;
            this.BtnOperadores.Text = "Operadores";
            this.BtnOperadores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnOperadores.UseVisualStyleBackColor = true;
            // 
            // BtnTurnos
            // 
            this.BtnTurnos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTurnos.Image = global::ProyectoOFI.Properties.Resources.icons8_grupos_de_usuarios;
            this.BtnTurnos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnTurnos.Location = new System.Drawing.Point(44, 121);
            this.BtnTurnos.Name = "BtnTurnos";
            this.BtnTurnos.Size = new System.Drawing.Size(162, 55);
            this.BtnTurnos.TabIndex = 19;
            this.BtnTurnos.Text = "Turnos";
            this.BtnTurnos.UseVisualStyleBackColor = true;
            // 
            // BtnParos
            // 
            this.BtnParos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnParos.Image = global::ProyectoOFI.Properties.Resources.icons8_agregar_a_carrito_de_compras;
            this.BtnParos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnParos.Location = new System.Drawing.Point(44, 198);
            this.BtnParos.Name = "BtnParos";
            this.BtnParos.Size = new System.Drawing.Size(162, 55);
            this.BtnParos.TabIndex = 21;
            this.BtnParos.Text = "Paros";
            this.BtnParos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnParos.UseVisualStyleBackColor = true;
            // 
            // BtnPatio
            // 
            this.BtnPatio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnPatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPatio.Image = global::ProyectoOFI.Properties.Resources.icons8_fields_50;
            this.BtnPatio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPatio.Location = new System.Drawing.Point(71, 30);
            this.BtnPatio.Name = "BtnPatio";
            this.BtnPatio.Size = new System.Drawing.Size(109, 55);
            this.BtnPatio.TabIndex = 13;
            this.BtnPatio.Text = "Patio";
            this.BtnPatio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPatio.UseVisualStyleBackColor = true;
            this.BtnPatio.Click += new System.EventHandler(this.BtnPatio_Click);
            // 
            // BtnUbicacionesPatio
            // 
            this.BtnUbicacionesPatio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnUbicacionesPatio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUbicacionesPatio.Image = global::ProyectoOFI.Properties.Resources.MdiBank;
            this.BtnUbicacionesPatio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUbicacionesPatio.Location = new System.Drawing.Point(18, 96);
            this.BtnUbicacionesPatio.Name = "BtnUbicacionesPatio";
            this.BtnUbicacionesPatio.Size = new System.Drawing.Size(215, 55);
            this.BtnUbicacionesPatio.TabIndex = 13;
            this.BtnUbicacionesPatio.Text = "Ubicaciones de Patio";
            this.BtnUbicacionesPatio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnUbicacionesPatio.UseVisualStyleBackColor = true;
            // 
            // BtnAgencia
            // 
            this.BtnAgencia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnAgencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgencia.Image = global::ProyectoOFI.Properties.Resources.MdiBank;
            this.BtnAgencia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAgencia.Location = new System.Drawing.Point(23, 25);
            this.BtnAgencia.Name = "BtnAgencia";
            this.BtnAgencia.Size = new System.Drawing.Size(186, 55);
            this.BtnAgencia.TabIndex = 12;
            this.BtnAgencia.Text = "Agencia";
            this.BtnAgencia.UseVisualStyleBackColor = true;
            this.BtnAgencia.Click += new System.EventHandler(this.BtnAgencia_Click);
            // 
            // BtnCert
            // 
            this.BtnCert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnCert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCert.Image = global::ProyectoOFI.Properties.Resources.icons8_diploma_1;
            this.BtnCert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCert.Location = new System.Drawing.Point(238, 25);
            this.BtnCert.Name = "BtnCert";
            this.BtnCert.Size = new System.Drawing.Size(186, 55);
            this.BtnCert.TabIndex = 13;
            this.BtnCert.Text = "Certificaciones";
            this.BtnCert.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCert.UseVisualStyleBackColor = true;
            this.BtnCert.Click += new System.EventHandler(this.BtnCert_Click);
            // 
            // BtnCompra
            // 
            this.BtnCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCompra.Image = global::ProyectoOFI.Properties.Resources.icons8_agregar_a_carrito_de_compras;
            this.BtnCompra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCompra.Location = new System.Drawing.Point(23, 351);
            this.BtnCompra.Name = "BtnCompra";
            this.BtnCompra.Size = new System.Drawing.Size(186, 60);
            this.BtnCompra.TabIndex = 20;
            this.BtnCompra.Text = "Compras";
            this.BtnCompra.UseVisualStyleBackColor = true;
            this.BtnCompra.Click += new System.EventHandler(this.BtnCompra_Click);
            // 
            // BtnEstf
            // 
            this.BtnEstf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEstf.Image = global::ProyectoOFI.Properties.Resources.icons8_humedad;
            this.BtnEstf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEstf.Location = new System.Drawing.Point(238, 104);
            this.BtnEstf.Name = "BtnEstf";
            this.BtnEstf.Size = new System.Drawing.Size(186, 55);
            this.BtnEstf.TabIndex = 15;
            this.BtnEstf.Text = "Estado Fisico";
            this.BtnEstf.UseVisualStyleBackColor = true;
            this.BtnEstf.Click += new System.EventHandler(this.BtnEstf_Click);
            // 
            // BtnClientes
            // 
            this.BtnClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClientes.Image = global::ProyectoOFI.Properties.Resources.icons8_grupos_de_usuarios;
            this.BtnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnClientes.Location = new System.Drawing.Point(23, 267);
            this.BtnClientes.Name = "BtnClientes";
            this.BtnClientes.Size = new System.Drawing.Size(186, 60);
            this.BtnClientes.TabIndex = 18;
            this.BtnClientes.Text = "Clientes";
            this.BtnClientes.UseVisualStyleBackColor = true;
            this.BtnClientes.Click += new System.EventHandler(this.BtnClientes_Click);
            // 
            // BtnCalidad
            // 
            this.BtnCalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCalidad.Image = global::ProyectoOFI.Properties.Resources.icons8_garantía;
            this.BtnCalidad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCalidad.Location = new System.Drawing.Point(238, 183);
            this.BtnCalidad.Name = "BtnCalidad";
            this.BtnCalidad.Size = new System.Drawing.Size(186, 60);
            this.BtnCalidad.TabIndex = 17;
            this.BtnCalidad.Text = "Calidad";
            this.BtnCalidad.UseVisualStyleBackColor = true;
            this.BtnCalidad.Click += new System.EventHandler(this.BtnCalidad_Click);
            // 
            // BtnRecibidor
            // 
            this.BtnRecibidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRecibidor.Image = global::ProyectoOFI.Properties.Resources.icons8_usuario_masculino_en_círculo;
            this.BtnRecibidor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRecibidor.Location = new System.Drawing.Point(23, 183);
            this.BtnRecibidor.Name = "BtnRecibidor";
            this.BtnRecibidor.Size = new System.Drawing.Size(186, 60);
            this.BtnRecibidor.TabIndex = 16;
            this.BtnRecibidor.Text = "Recibidor";
            this.BtnRecibidor.UseVisualStyleBackColor = true;
            this.BtnRecibidor.Click += new System.EventHandler(this.BtnRecibidor_Click);
            // 
            // BtnDaño
            // 
            this.BtnDaño.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDaño.Image = global::ProyectoOFI.Properties.Resources.icons8_diversidad;
            this.BtnDaño.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDaño.Location = new System.Drawing.Point(238, 267);
            this.BtnDaño.Name = "BtnDaño";
            this.BtnDaño.Size = new System.Drawing.Size(186, 60);
            this.BtnDaño.TabIndex = 19;
            this.BtnDaño.Text = "Daño";
            this.BtnDaño.UseVisualStyleBackColor = true;
            this.BtnDaño.Click += new System.EventHandler(this.BtnDaño_Click);
            // 
            // BtnAcopio
            // 
            this.BtnAcopio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAcopio.Image = global::ProyectoOFI.Properties.Resources.MdiHandCoin;
            this.BtnAcopio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAcopio.Location = new System.Drawing.Point(23, 104);
            this.BtnAcopio.Name = "BtnAcopio";
            this.BtnAcopio.Size = new System.Drawing.Size(186, 55);
            this.BtnAcopio.TabIndex = 14;
            this.BtnAcopio.Text = "Acopio";
            this.BtnAcopio.UseVisualStyleBackColor = true;
            this.BtnAcopio.Click += new System.EventHandler(this.BtnAcopio_Click);
            // 
            // BtnAreaS
            // 
            this.BtnAreaS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAreaS.Image = global::ProyectoOFI.Properties.Resources.icons8_ubicación_en_todo_el_mundo__1_;
            this.BtnAreaS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAreaS.Location = new System.Drawing.Point(238, 351);
            this.BtnAreaS.Name = "BtnAreaS";
            this.BtnAreaS.Size = new System.Drawing.Size(186, 60);
            this.BtnAreaS.TabIndex = 21;
            this.BtnAreaS.Text = "Área de Secado";
            this.BtnAreaS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAreaS.UseVisualStyleBackColor = true;
            this.BtnAreaS.Click += new System.EventHandler(this.BtnAreaS_Click);
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCerrar.Image = global::ProyectoOFI.Properties.Resources.icons8_cerrar_ventana;
            this.BtnCerrar.Location = new System.Drawing.Point(995, 0);
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
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 692);
            this.Controls.Add(this.GbSM);
            this.Controls.Add(this.GbControlPatio);
            this.Controls.Add(this.GbTransfer);
            this.Controls.Add(this.PlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmConfig";
            this.PlTitulo.ResumeLayout(false);
            this.GbTransfer.ResumeLayout(false);
            this.GbControlPatio.ResumeLayout(false);
            this.GbSM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PlTitulo;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnCompra;
        private System.Windows.Forms.Button BtnClientes;
        private System.Windows.Forms.Button BtnRecibidor;
        private System.Windows.Forms.Button BtnAcopio;
        private System.Windows.Forms.Button BtnAgencia;
        private System.Windows.Forms.Button BtnAreaS;
        private System.Windows.Forms.Button BtnDaño;
        private System.Windows.Forms.Button BtnCalidad;
        private System.Windows.Forms.Button BtnEstf;
        private System.Windows.Forms.Button BtnCert;
        private System.Windows.Forms.GroupBox GbTransfer;
        private System.Windows.Forms.GroupBox GbControlPatio;
        private System.Windows.Forms.Button BtnUbicacionesPatio;
        private System.Windows.Forms.GroupBox GbSM;
        private System.Windows.Forms.Button BtnOperadores;
        private System.Windows.Forms.Button BtnTurnos;
        private System.Windows.Forms.Button BtnParos;
        private System.Windows.Forms.Button BtnPatio;
    }
}