namespace Client2
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkUseProxy = new System.Windows.Forms.CheckBox();
            this.cmbDomain = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserProxy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPwdProxy = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProxyAddress = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnConcurrency = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(826, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Test service";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 230);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(985, 289);
            this.textBox1.TabIndex = 1;
            // 
            // chkUseProxy
            // 
            this.chkUseProxy.AutoSize = true;
            this.chkUseProxy.Location = new System.Drawing.Point(25, 12);
            this.chkUseProxy.Name = "chkUseProxy";
            this.chkUseProxy.Size = new System.Drawing.Size(93, 21);
            this.chkUseProxy.TabIndex = 2;
            this.chkUseProxy.Text = "Use proxy";
            this.chkUseProxy.UseVisualStyleBackColor = true;
            this.chkUseProxy.CheckedChanged += new System.EventHandler(this.chkUseProxy_CheckedChanged);
            // 
            // cmbDomain
            // 
            this.cmbDomain.FormattingEnabled = true;
            this.cmbDomain.Items.AddRange(new object[] {
            "allus-ar",
            "allus-pr"});
            this.cmbDomain.Location = new System.Drawing.Point(146, 21);
            this.cmbDomain.Name = "cmbDomain";
            this.cmbDomain.Size = new System.Drawing.Size(186, 24);
            this.cmbDomain.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Proxy Domain";
            // 
            // txtUserProxy
            // 
            this.txtUserProxy.Location = new System.Drawing.Point(157, 58);
            this.txtUserProxy.Name = "txtUserProxy";
            this.txtUserProxy.Size = new System.Drawing.Size(175, 22);
            this.txtUserProxy.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Proxy username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Proxy password";
            // 
            // txtPwdProxy
            // 
            this.txtPwdProxy.Location = new System.Drawing.Point(157, 92);
            this.txtPwdProxy.Name = "txtPwdProxy";
            this.txtPwdProxy.PasswordChar = 'X';
            this.txtPwdProxy.Size = new System.Drawing.Size(175, 22);
            this.txtPwdProxy.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtProxyAddress);
            this.groupBox1.Controls.Add(this.cmbDomain);
            this.groupBox1.Controls.Add(this.txtPwdProxy);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUserProxy);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(25, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 159);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "Port";
            // 
            // txtProxyAddress
            // 
            this.txtProxyAddress.Location = new System.Drawing.Point(157, 124);
            this.txtProxyAddress.Name = "txtProxyAddress";
            this.txtProxyAddress.Size = new System.Drawing.Size(175, 22);
            this.txtProxyAddress.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDomain);
            this.groupBox2.Controls.Add(this.txtPwd);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtUser);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(432, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(376, 151);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(144, 25);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(175, 22);
            this.txtDomain.TabIndex = 9;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(144, 95);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = 'X';
            this.txtPwd.Size = new System.Drawing.Size(175, 22);
            this.txtPwd.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Domain";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Password";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(144, 61);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(175, 22);
            this.txtUser.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Username";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(429, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "WCF Security credentials";
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSaveSettings.Location = new System.Drawing.Point(826, 32);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(159, 35);
            this.btnSaveSettings.TabIndex = 11;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = false;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(826, 148);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(159, 35);
            this.button2.TabIndex = 12;
            this.button2.Text = "Test Fault Contract";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnConcurrency
            // 
            this.btnConcurrency.Location = new System.Drawing.Point(826, 189);
            this.btnConcurrency.Name = "btnConcurrency";
            this.btnConcurrency.Size = new System.Drawing.Size(171, 35);
            this.btnConcurrency.TabIndex = 13;
            this.btnConcurrency.Text = "Test ConcurrencyMode";
            this.btnConcurrency.UseVisualStyleBackColor = true;
            this.btnConcurrency.Click += new System.EventHandler(this.btnConcurrency_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(606, 189);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(175, 22);
            this.txtInput.TabIndex = 14;
            this.txtInput.Text = "89";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 521);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnConcurrency);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkUseProxy);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "WCF security test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Leave += new System.EventHandler(this.Form1_Leave);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox chkUseProxy;
        private System.Windows.Forms.ComboBox cmbDomain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserProxy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPwdProxy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtProxyAddress;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnConcurrency;
        private System.Windows.Forms.TextBox txtInput;
    }
}

