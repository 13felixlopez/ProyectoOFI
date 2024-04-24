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
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtUser = new System.Windows.Forms.TextBox();
            this.PlUser = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PlPass = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtPass = new System.Windows.Forms.TextBox();
            this.PbLogo = new System.Windows.Forms.PictureBox();
            this.PlBotones = new System.Windows.Forms.Panel();
            this.Lblrestablecer = new System.Windows.Forms.LinkLabel();
            this.BtnInicio = new System.Windows.Forms.Button();
            this.PlTitulo.SuspendLayout();
            this.PlUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PlPass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).BeginInit();
            this.PlBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlTitulo
            // 
            this.PlTitulo.Controls.Add(this.BtnCerrar);
            this.PlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlTitulo.Location = new System.Drawing.Point(636, 0);
            this.PlTitulo.Name = "PlTitulo";
            this.PlTitulo.Size = new System.Drawing.Size(460, 52);
            this.PlTitulo.TabIndex = 0;
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCerrar.Image = global::ProyectoOFI.Properties.Resources.icons8_cerrar_ventana;
            this.BtnCerrar.Location = new System.Drawing.Point(411, 0);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(49, 52);
            this.BtnCerrar.TabIndex = 3;
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(636, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(460, 163);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bienvenidos \r\nSistema para seguimiento\r\nde Lotes ofi";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.TxtUser.TabIndex = 1;
            // 
            // PlUser
            // 
            this.PlUser.Controls.Add(this.pictureBox1);
            this.PlUser.Controls.Add(this.label2);
            this.PlUser.Controls.Add(this.TxtUser);
            this.PlUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlUser.Location = new System.Drawing.Point(636, 215);
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
            this.PlPass.Location = new System.Drawing.Point(636, 315);
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
            // PbLogo
            // 
            this.PbLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.PbLogo.Image = global::ProyectoOFI.Properties.Resources.Logo;
            this.PbLogo.Location = new System.Drawing.Point(0, 0);
            this.PbLogo.Name = "PbLogo";
            this.PbLogo.Size = new System.Drawing.Size(636, 645);
            this.PbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbLogo.TabIndex = 1;
            this.PbLogo.TabStop = false;
            // 
            // PlBotones
            // 
            this.PlBotones.Controls.Add(this.Lblrestablecer);
            this.PlBotones.Controls.Add(this.BtnInicio);
            this.PlBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlBotones.Location = new System.Drawing.Point(636, 415);
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
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 645);
            this.Controls.Add(this.PlBotones);
            this.Controls.Add(this.PlPass);
            this.Controls.Add(this.PlUser);
            this.Controls.Add(this.label1);
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
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).EndInit();
            this.PlBotones.ResumeLayout(false);
            this.PlBotones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PlTitulo;
        private System.Windows.Forms.PictureBox PbLogo;
        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.Label label1;
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
    }
}