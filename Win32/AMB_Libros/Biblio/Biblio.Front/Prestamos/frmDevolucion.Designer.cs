namespace Biblio.Front
{
    partial class frmDevolucion
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSelLibro = new System.Windows.Forms.Label();
            this.lblSelectedSocio = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ucPrestamosGrid1 = new Biblio.Front.ucPrestamosGrid();
            this.chkVerDevueltos = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(71)))), ((int)(((byte)(69)))));
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(9, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 24);
            this.label5.TabIndex = 16;
            this.label5.Text = "Devoluciones";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(71)))), ((int)(((byte)(69)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(914, 48);
            this.label4.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(8, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Libro";
            // 
            // lblSelLibro
            // 
            this.lblSelLibro.AutoSize = true;
            this.lblSelLibro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelLibro.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSelLibro.Location = new System.Drawing.Point(166, 103);
            this.lblSelLibro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelLibro.Name = "lblSelLibro";
            this.lblSelLibro.Size = new System.Drawing.Size(154, 20);
            this.lblSelLibro.TabIndex = 24;
            this.lblSelLibro.Text = "-----------------------------";
            // 
            // lblSelectedSocio
            // 
            this.lblSelectedSocio.AutoSize = true;
            this.lblSelectedSocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedSocio.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSelectedSocio.Location = new System.Drawing.Point(166, 63);
            this.lblSelectedSocio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelectedSocio.Name = "lblSelectedSocio";
            this.lblSelectedSocio.Size = new System.Drawing.Size(154, 20);
            this.lblSelectedSocio.TabIndex = 23;
            this.lblSelectedSocio.Text = "-----------------------------";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(9, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Socio";
            // 
            // ucPrestamosGrid1
            // 
            this.ucPrestamosGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPrestamosGrid1.Location = new System.Drawing.Point(11, 135);
            this.ucPrestamosGrid1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ucPrestamosGrid1.Name = "ucPrestamosGrid1";
            this.ucPrestamosGrid1.Size = new System.Drawing.Size(889, 336);
            this.ucPrestamosGrid1.TabIndex = 28;
            this.ucPrestamosGrid1.OnClickEvent += new System.EventHandler(this.ucPrestamosGrid1_OnClickEvent);
            // 
            // chkVerDevueltos
            // 
            this.chkVerDevueltos.AutoSize = true;
            this.chkVerDevueltos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(71)))), ((int)(((byte)(69)))));
            this.chkVerDevueltos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVerDevueltos.ForeColor = System.Drawing.Color.Ivory;
            this.chkVerDevueltos.Location = new System.Drawing.Point(472, 16);
            this.chkVerDevueltos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkVerDevueltos.Name = "chkVerDevueltos";
            this.chkVerDevueltos.Size = new System.Drawing.Size(116, 21);
            this.chkVerDevueltos.TabIndex = 29;
            this.chkVerDevueltos.Text = "Ver Devueltos";
            this.chkVerDevueltos.UseVisualStyleBackColor = false;
            this.chkVerDevueltos.CheckedChanged += new System.EventHandler(this.chkVerDevueltos_CheckedChanged);
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Image = global::Biblio.Front.Properties.Resources.save_as_24;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(650, 63);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(164, 35);
            this.btnGuardar.TabIndex = 27;
            this.btnGuardar.Text = "Guardar devolucion";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmDevolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 500);
            this.Controls.Add(this.chkVerDevueltos);
            this.Controls.Add(this.ucPrestamosGrid1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSelLibro);
            this.Controls.Add(this.lblSelectedSocio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "frmDevolucion";
            this.Text = "Devoluciones";
            this.Load += new System.EventHandler(this.frmDevolucion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSelLibro;
        private System.Windows.Forms.Label lblSelectedSocio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGuardar;
        private ucPrestamosGrid ucPrestamosGrid1;
        private System.Windows.Forms.CheckBox chkVerDevueltos;
    }
}