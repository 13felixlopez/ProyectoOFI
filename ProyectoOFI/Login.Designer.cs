namespace ProyectoOFI
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.PlTitulo = new System.Windows.Forms.Panel();
            this.LblDB = new System.Windows.Forms.Label();
            this.CambiarServidor = new System.Windows.Forms.Button();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtUser = new System.Windows.Forms.TextBox();
            this.PlUser = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PlPass = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtPass = new System.Windows.Forms.TextBox();
            this.PlBotones = new System.Windows.Forms.Panel();
            this.Lblrestablecer = new System.Windows.Forms.LinkLabel();
            this.BtnInicio = new System.Windows.Forms.Button();
            this.PbLogo = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PlTitulo.SuspendLayout();
            this.PlUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PlPass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.PlBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlTitulo
            // 
            this.PlTitulo.Controls.Add(this.LblDB);
            this.PlTitulo.Controls.Add(this.CambiarServidor);
            this.PlTitulo.Controls.Add(this.BtnCerrar);
            this.PlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlTitulo.Location = new System.Drawing.Point(636, 0);
            this.PlTitulo.Name = "PlTitulo";
            this.PlTitulo.Size = new System.Drawing.Size(460, 52);
            this.PlTitulo.TabIndex = 0;
            // 
            // LblDB
            // 
            this.LblDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.LblDB.Location = new System.Drawing.Point(49, 0);
            this.LblDB.Name = "LblDB";
            this.LblDB.Size = new System.Drawing.Size(362, 52);
            this.LblDB.TabIndex = 8;
            this.LblDB.Text = "--";
            this.LblDB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblDB.Visible = false;
            // 
            // CambiarServidor
            // 
            this.CambiarServidor.BackgroundImage = global::ProyectoOFI.Properties.Resources.data_backup_80px;
            this.CambiarServidor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CambiarServidor.Dock = System.Windows.Forms.DockStyle.Left;
            this.CambiarServidor.Location = new System.Drawing.Point(0, 0);
            this.CambiarServidor.Name = "CambiarServidor";
            this.CambiarServidor.Size = new System.Drawing.Size(49, 52);
            this.CambiarServidor.TabIndex = 2;
            this.CambiarServidor.UseVisualStyleBackColor = true;
            this.CambiarServidor.Visible = false;
            this.CambiarServidor.Click += new System.EventHandler(this.CambiarServidor_Click);
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCerrar.Image = global::ProyectoOFI.Properties.Resources.icons8_cerrar_ventana;
            this.BtnCerrar.Location = new System.Drawing.Point(411, 0);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(49, 52);
            this.BtnCerrar.TabIndex = 1;
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(120, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 41);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ingrese el Usuario:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtUser
            // 
            this.TxtUser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.TxtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.TxtUser.Location = new System.Drawing.Point(120, 52);
            this.TxtUser.Name = "TxtUser";
            this.TxtUser.Size = new System.Drawing.Size(301, 26);
            this.TxtUser.TabIndex = 0;
            // 
            // PlUser
            // 
            this.PlUser.Controls.Add(this.pictureBox1);
            this.PlUser.Controls.Add(this.label2);
            this.PlUser.Controls.Add(this.TxtUser);
            this.PlUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlUser.Location = new System.Drawing.Point(636, 236);
            this.PlUser.Name = "PlUser";
            this.PlUser.Size = new System.Drawing.Size(460, 100);
            this.PlUser.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProyectoOFI.Properties.Resources.icons8_usuario;
            this.pictureBox1.Location = new System.Drawing.Point(39, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // PlPass
            // 
            this.PlPass.Controls.Add(this.pictureBox2);
            this.PlPass.Controls.Add(this.label3);
            this.PlPass.Controls.Add(this.TxtPass);
            this.PlPass.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlPass.Location = new System.Drawing.Point(636, 336);
            this.PlPass.Name = "PlPass";
            this.PlPass.Size = new System.Drawing.Size(460, 100);
            this.PlPass.TabIndex = 6;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ProyectoOFI.Properties.Resources.icons8_bloquear;
            this.pictureBox2.Location = new System.Drawing.Point(39, 28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(63, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(120, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(301, 41);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ingrese la Contraseña:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtPass
            // 
            this.TxtPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.TxtPass.Location = new System.Drawing.Point(120, 52);
            this.TxtPass.Name = "TxtPass";
            this.TxtPass.PasswordChar = '*';
            this.TxtPass.Size = new System.Drawing.Size(301, 26);
            this.TxtPass.TabIndex = 4;
            this.TxtPass.UseSystemPasswordChar = true;
            // 
            // PlBotones
            // 
            this.PlBotones.Controls.Add(this.Lblrestablecer);
            this.PlBotones.Controls.Add(this.BtnInicio);
            this.PlBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlBotones.Location = new System.Drawing.Point(636, 436);
            this.PlBotones.Name = "PlBotones";
            this.PlBotones.Size = new System.Drawing.Size(460, 100);
            this.PlBotones.TabIndex = 7;
            // 
            // Lblrestablecer
            // 
            this.Lblrestablecer.AutoSize = true;
            this.Lblrestablecer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lblrestablecer.Location = new System.Drawing.Point(156, 71);
            this.Lblrestablecer.Name = "Lblrestablecer";
            this.Lblrestablecer.Size = new System.Drawing.Size(147, 16);
            this.Lblrestablecer.TabIndex = 1;
            this.Lblrestablecer.TabStop = true;
            this.Lblrestablecer.Text = "¿Olvidó su contraseña?";
            this.Lblrestablecer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lblrestablecer_LinkClicked);
            // 
            // BtnInicio
            // 
            this.BtnInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.BtnInicio.Location = new System.Drawing.Point(163, 14);
            this.BtnInicio.Name = "BtnInicio";
            this.BtnInicio.Size = new System.Drawing.Size(135, 44);
            this.BtnInicio.TabIndex = 0;
            this.BtnInicio.Text = "Iniciar Sesión";
            this.BtnInicio.UseVisualStyleBackColor = true;
            this.BtnInicio.Click += new System.EventHandler(this.BtnInicio_Click);
            // 
            // PbLogo
            // 
            this.PbLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.PbLogo.Image = global::ProyectoOFI.Properties.Resources.DRY_SYSTEM;
            this.PbLogo.Location = new System.Drawing.Point(0, 0);
            this.PbLogo.Name = "PbLogo";
            this.PbLogo.Size = new System.Drawing.Size(636, 645);
            this.PbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbLogo.TabIndex = 1;
            this.PbLogo.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(636, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 184);
            this.panel1.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("Montserrat", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(141)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(219, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(241, 105);
            this.label6.TabIndex = 2;
            this.label6.Text = "SYSTEM";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("Montserrat", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(0)))), ((int)(((byte)(100)))));
            this.label5.Location = new System.Drawing.Point(0, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(219, 105);
            this.label5.TabIndex = 1;
            this.label5.Text = "DRY";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(460, 79);
            this.label4.TabIndex = 0;
            this.label4.Text = "Bienvenidos a";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 645);
            this.Controls.Add(this.PlBotones);
            this.Controls.Add(this.PlPass);
            this.Controls.Add(this.PlUser);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PlTitulo);
            this.Controls.Add(this.PbLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.PlTitulo.ResumeLayout(false);
            this.PlUser.ResumeLayout(false);
            this.PlUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PlPass.ResumeLayout(false);
            this.PlPass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.PlBotones.ResumeLayout(false);
            this.PlBotones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PlTitulo;
        private System.Windows.Forms.PictureBox PbLogo;
        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtUser;
        private System.Windows.Forms.Panel PlUser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel PlPass;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtPass;
        private System.Windows.Forms.Panel PlBotones;
        private System.Windows.Forms.LinkLabel Lblrestablecer;
        private System.Windows.Forms.Button BtnInicio;
        private System.Windows.Forms.Button CambiarServidor;
        private System.Windows.Forms.Label LblDB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}