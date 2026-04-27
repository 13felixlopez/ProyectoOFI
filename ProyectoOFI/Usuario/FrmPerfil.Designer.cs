namespace ProyectoOFI.Usuario
{
    partial class FrmPerfil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPerfil));
            this.panel11 = new System.Windows.Forms.Panel();
            this.TxtUser = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.LblUser = new System.Windows.Forms.Label();
            this.lblNombreApellidos = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtNombreApellidos = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PlPass = new System.Windows.Forms.Panel();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.LblPass = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblMayu = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.PlTitulo = new System.Windows.Forms.Panel();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.PlDatos = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1.SuspendLayout();
            this.PlPass.SuspendLayout();
            this.PlTitulo.SuspendLayout();
            this.PlDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel11.Location = new System.Drawing.Point(168, 92);
            this.panel11.Margin = new System.Windows.Forms.Padding(2);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(374, 1);
            this.panel11.TabIndex = 682;
            // 
            // TxtUser
            // 
            this.TxtUser.BackColor = System.Drawing.SystemColors.Control;
            this.TxtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUser.Enabled = false;
            this.TxtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUser.Location = new System.Drawing.Point(168, 66);
            this.TxtUser.Margin = new System.Windows.Forms.Padding(2);
            this.TxtUser.Name = "TxtUser";
            this.TxtUser.Size = new System.Drawing.Size(374, 26);
            this.TxtUser.TabIndex = 681;
            this.TxtUser.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(84, 72);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(68, 20);
            this.label20.TabIndex = 680;
            this.label20.Text = "Usuario:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnGuardar);
            this.flowLayoutPanel1.Controls.Add(this.btnActualizar);
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(230, 364);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(272, 64);
            this.flowLayoutPanel1.TabIndex = 679;
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreo.ForeColor = System.Drawing.Color.Red;
            this.lblCorreo.Location = new System.Drawing.Point(546, 107);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(20, 25);
            this.lblCorreo.TabIndex = 678;
            this.lblCorreo.Text = "*";
            // 
            // LblUser
            // 
            this.LblUser.AutoSize = true;
            this.LblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUser.ForeColor = System.Drawing.Color.Red;
            this.LblUser.Location = new System.Drawing.Point(545, 67);
            this.LblUser.Name = "LblUser";
            this.LblUser.Size = new System.Drawing.Size(20, 25);
            this.LblUser.TabIndex = 676;
            this.LblUser.Text = "*";
            // 
            // lblNombreApellidos
            // 
            this.lblNombreApellidos.AutoSize = true;
            this.lblNombreApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreApellidos.ForeColor = System.Drawing.Color.Red;
            this.lblNombreApellidos.Location = new System.Drawing.Point(545, 21);
            this.lblNombreApellidos.Name = "lblNombreApellidos";
            this.lblNombreApellidos.Size = new System.Drawing.Size(20, 25);
            this.lblNombreApellidos.TabIndex = 677;
            this.lblNombreApellidos.Text = "*";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(168, 133);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(374, 1);
            this.panel3.TabIndex = 674;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(168, 133);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(374, 1);
            this.panel5.TabIndex = 675;
            // 
            // txtCorreo
            // 
            this.txtCorreo.BackColor = System.Drawing.SystemColors.Control;
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.Location = new System.Drawing.Point(168, 107);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(2);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(374, 26);
            this.txtCorreo.TabIndex = 673;
            this.txtCorreo.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(168, 47);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(374, 1);
            this.panel4.TabIndex = 672;
            // 
            // txtNombreApellidos
            // 
            this.txtNombreApellidos.BackColor = System.Drawing.SystemColors.Control;
            this.txtNombreApellidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreApellidos.Location = new System.Drawing.Point(168, 21);
            this.txtNombreApellidos.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreApellidos.Name = "txtNombreApellidos";
            this.txtNombreApellidos.Size = new System.Drawing.Size(374, 26);
            this.txtNombreApellidos.TabIndex = 671;
            this.txtNombreApellidos.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(87, 110);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.TabIndex = 669;
            this.label8.Text = "Correo: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(87, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 670;
            this.label2.Text = "Correo: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 668;
            this.label1.Text = "Nombre y apellidos:";
            // 
            // PlPass
            // 
            this.PlPass.Controls.Add(this.txtContraseña);
            this.PlPass.Controls.Add(this.label12);
            this.PlPass.Controls.Add(this.panel10);
            this.PlPass.Controls.Add(this.panel8);
            this.PlPass.Controls.Add(this.LblPass);
            this.PlPass.Controls.Add(this.label13);
            this.PlPass.Controls.Add(this.lblMayu);
            this.PlPass.Controls.Add(this.lblMin);
            this.PlPass.Controls.Add(this.lblNum);
            this.PlPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.PlPass.Location = new System.Drawing.Point(23, 133);
            this.PlPass.Name = "PlPass";
            this.PlPass.Size = new System.Drawing.Size(577, 104);
            this.PlPass.TabIndex = 683;
            // 
            // txtContraseña
            // 
            this.txtContraseña.BackColor = System.Drawing.SystemColors.Control;
            this.txtContraseña.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.Location = new System.Drawing.Point(143, 19);
            this.txtContraseña.Margin = new System.Windows.Forms.Padding(2);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(280, 26);
            this.txtContraseña.TabIndex = 653;
            this.txtContraseña.TextChanged += new System.EventHandler(this.txtContraseña_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 22);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 20);
            this.label12.TabIndex = 652;
            this.label12.Text = "Contraseña:";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel10.Location = new System.Drawing.Point(143, 45);
            this.panel10.Margin = new System.Windows.Forms.Padding(2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(280, 1);
            this.panel10.TabIndex = 654;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel8.Location = new System.Drawing.Point(143, 45);
            this.panel8.Margin = new System.Windows.Forms.Padding(2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(280, 1);
            this.panel8.TabIndex = 654;
            // 
            // LblPass
            // 
            this.LblPass.AutoSize = true;
            this.LblPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPass.ForeColor = System.Drawing.Color.Red;
            this.LblPass.Location = new System.Drawing.Point(435, 19);
            this.LblPass.Name = "LblPass";
            this.LblPass.Size = new System.Drawing.Size(21, 26);
            this.LblPass.TabIndex = 656;
            this.LblPass.Text = "*";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(462, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 53);
            this.label13.TabIndex = 655;
            this.label13.Text = "La contraseña no puede ser menor a 6 caracteres";
            // 
            // lblMayu
            // 
            this.lblMayu.AutoSize = true;
            this.lblMayu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMayu.ForeColor = System.Drawing.Color.DimGray;
            this.lblMayu.Location = new System.Drawing.Point(171, 57);
            this.lblMayu.Name = "lblMayu";
            this.lblMayu.Size = new System.Drawing.Size(70, 15);
            this.lblMayu.TabIndex = 657;
            this.lblMayu.Text = "-Mayúscula";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMin.ForeColor = System.Drawing.Color.DimGray;
            this.lblMin.Location = new System.Drawing.Point(337, 57);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(68, 15);
            this.lblMin.TabIndex = 660;
            this.lblMin.Text = "-Minúscula";
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNum.ForeColor = System.Drawing.Color.DimGray;
            this.lblNum.Location = new System.Drawing.Point(261, 57);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(56, 15);
            this.lblNum.TabIndex = 659;
            this.lblNum.Text = "-Número";
            // 
            // PlTitulo
            // 
            this.PlTitulo.Controls.Add(this.LblTitulo);
            this.PlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlTitulo.Location = new System.Drawing.Point(0, 0);
            this.PlTitulo.Name = "PlTitulo";
            this.PlTitulo.Size = new System.Drawing.Size(758, 61);
            this.PlTitulo.TabIndex = 684;
            // 
            // LblTitulo
            // 
            this.LblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblTitulo.Font = new System.Drawing.Font("Lucida Fax", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.Location = new System.Drawing.Point(0, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(758, 61);
            this.LblTitulo.TabIndex = 0;
            this.LblTitulo.Text = "Configuración de perfil";
            this.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Image = global::ProyectoOFI.Properties.Resources.icons8_ok_32;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(10, 8);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(118, 41);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Editar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Image = global::ProyectoOFI.Properties.Resources.icons8_ok_32;
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.Location = new System.Drawing.Point(132, 8);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(2);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(122, 41);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Visible = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // PlDatos
            // 
            this.PlDatos.Controls.Add(this.panel4);
            this.PlDatos.Controls.Add(this.label1);
            this.PlDatos.Controls.Add(this.PlPass);
            this.PlDatos.Controls.Add(this.label2);
            this.PlDatos.Controls.Add(this.panel11);
            this.PlDatos.Controls.Add(this.label8);
            this.PlDatos.Controls.Add(this.TxtUser);
            this.PlDatos.Controls.Add(this.txtNombreApellidos);
            this.PlDatos.Controls.Add(this.label20);
            this.PlDatos.Controls.Add(this.txtCorreo);
            this.PlDatos.Controls.Add(this.panel5);
            this.PlDatos.Controls.Add(this.lblCorreo);
            this.PlDatos.Controls.Add(this.panel3);
            this.PlDatos.Controls.Add(this.LblUser);
            this.PlDatos.Controls.Add(this.lblNombreApellidos);
            this.PlDatos.Enabled = false;
            this.PlDatos.Location = new System.Drawing.Point(64, 72);
            this.PlDatos.Name = "PlDatos";
            this.PlDatos.Size = new System.Drawing.Size(630, 257);
            this.PlDatos.TabIndex = 685;
            // 
            // FrmPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 461);
            this.Controls.Add(this.PlDatos);
            this.Controls.Add(this.PlTitulo);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPerfil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Perfil";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPerfil_FormClosed);
            this.Load += new System.EventHandler(this.FrmPerfil_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.PlPass.ResumeLayout(false);
            this.PlPass.PerformLayout();
            this.PlTitulo.ResumeLayout(false);
            this.PlDatos.ResumeLayout(false);
            this.PlDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TextBox TxtUser;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label LblUser;
        private System.Windows.Forms.Label lblNombreApellidos;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtNombreApellidos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PlPass;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label LblPass;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblMayu;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Panel PlTitulo;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel PlDatos;
    }
}