﻿namespace AsimetricSimetric_Client
{
    partial class Form1
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtIteraciones = new System.Windows.Forms.TextBox();
            this.txtHashValue = new System.Windows.Forms.TextBox();
            this.txtAsimAEncriptar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSalt = new System.Windows.Forms.TextBox();
            this.chkContraseña = new System.Windows.Forms.CheckBox();
            this.txtHashEncriptado2 = new System.Windows.Forms.TextBox();
            this.btnAsimEncriptar = new System.Windows.Forms.Button();
            this.btnAsimGenerar = new System.Windows.Forms.Button();
            this.lblSalt = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Iteraciones";
            // 
            // txtIteraciones
            // 
            this.txtIteraciones.Location = new System.Drawing.Point(49, 67);
            this.txtIteraciones.Name = "txtIteraciones";
            this.txtIteraciones.Size = new System.Drawing.Size(167, 22);
            this.txtIteraciones.TabIndex = 22;
            this.txtIteraciones.Text = "1000";
            // 
            // txtHashValue
            // 
            this.txtHashValue.Location = new System.Drawing.Point(36, 295);
            this.txtHashValue.Multiline = true;
            this.txtHashValue.Name = "txtHashValue";
            this.txtHashValue.Size = new System.Drawing.Size(436, 53);
            this.txtHashValue.TabIndex = 21;
            // 
            // txtAsimAEncriptar
            // 
            this.txtAsimAEncriptar.Location = new System.Drawing.Point(526, 198);
            this.txtAsimAEncriptar.Multiline = true;
            this.txtAsimAEncriptar.Name = "txtAsimAEncriptar";
            this.txtAsimAEncriptar.ReadOnly = true;
            this.txtAsimAEncriptar.Size = new System.Drawing.Size(436, 41);
            this.txtAsimAEncriptar.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Texto a encriptar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Salt";
            // 
            // txtSalt
            // 
            this.txtSalt.Location = new System.Drawing.Point(293, 67);
            this.txtSalt.Name = "txtSalt";
            this.txtSalt.Size = new System.Drawing.Size(167, 22);
            this.txtSalt.TabIndex = 24;
            this.txtSalt.Text = "peco";
            // 
            // chkContraseña
            // 
            this.chkContraseña.AutoSize = true;
            this.chkContraseña.Location = new System.Drawing.Point(504, 68);
            this.chkContraseña.Name = "chkContraseña";
            this.chkContraseña.Size = new System.Drawing.Size(103, 21);
            this.chkContraseña.TabIndex = 26;
            this.chkContraseña.Text = "Contraseña";
            this.chkContraseña.UseVisualStyleBackColor = true;
            // 
            // txtHashEncriptado2
            // 
            this.txtHashEncriptado2.Location = new System.Drawing.Point(544, 423);
            this.txtHashEncriptado2.Multiline = true;
            this.txtHashEncriptado2.Name = "txtHashEncriptado2";
            this.txtHashEncriptado2.Size = new System.Drawing.Size(436, 53);
            this.txtHashEncriptado2.TabIndex = 27;
            // 
            // btnAsimEncriptar
            // 
            this.btnAsimEncriptar.Location = new System.Drawing.Point(504, 304);
            this.btnAsimEncriptar.Name = "btnAsimEncriptar";
            this.btnAsimEncriptar.Size = new System.Drawing.Size(152, 34);
            this.btnAsimEncriptar.TabIndex = 28;
            this.btnAsimEncriptar.Text = "HASH";
            this.btnAsimEncriptar.UseVisualStyleBackColor = true;
            this.btnAsimEncriptar.Click += new System.EventHandler(this.btnAsimEncriptar_Click);
            // 
            // btnAsimGenerar
            // 
            this.btnAsimGenerar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnAsimGenerar.Location = new System.Drawing.Point(504, 110);
            this.btnAsimGenerar.Name = "btnAsimGenerar";
            this.btnAsimGenerar.Size = new System.Drawing.Size(152, 34);
            this.btnAsimGenerar.TabIndex = 29;
            this.btnAsimGenerar.Text = "Generar Key";
            this.btnAsimGenerar.UseVisualStyleBackColor = true;
            this.btnAsimGenerar.Click += new System.EventHandler(this.btnAsimGenerar_Click);
            // 
            // lblSalt
            // 
            this.lblSalt.AutoSize = true;
            this.lblSalt.Location = new System.Drawing.Point(46, 9);
            this.lblSalt.Name = "lblSalt";
            this.lblSalt.Size = new System.Drawing.Size(0, 17);
            this.lblSalt.TabIndex = 30;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.SystemColors.Info;
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtUserName.Location = new System.Drawing.Point(116, 145);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(283, 22);
            this.txtUserName.TabIndex = 31;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.Info;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtPassword.Location = new System.Drawing.Point(116, 185);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(283, 22);
            this.txtPassword.TabIndex = 32;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 33;
            this.label4.Text = "Contraseña";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 34;
            this.label5.Text = "Usuario";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 442);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 34);
            this.button1.TabIndex = 35;
            this.button1.Text = "CHECK HASH";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 478);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblSalt);
            this.Controls.Add(this.btnAsimGenerar);
            this.Controls.Add(this.btnAsimEncriptar);
            this.Controls.Add(this.txtHashEncriptado2);
            this.Controls.Add(this.chkContraseña);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSalt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIteraciones);
            this.Controls.Add(this.txtHashValue);
            this.Controls.Add(this.txtAsimAEncriptar);
            this.Controls.Add(this.label3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIteraciones;
        private System.Windows.Forms.TextBox txtHashValue;
        private System.Windows.Forms.TextBox txtAsimAEncriptar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSalt;
        private System.Windows.Forms.CheckBox chkContraseña;
        private System.Windows.Forms.TextBox txtHashEncriptado2;
        private System.Windows.Forms.Button btnAsimEncriptar;
        private System.Windows.Forms.Button btnAsimGenerar;
        private System.Windows.Forms.Label lblSalt;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;

    }
}

