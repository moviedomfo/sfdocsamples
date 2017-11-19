namespace Biblio.Front
{
    partial class frmPrestamo
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
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnBuscarSocio = new System.Windows.Forms.Button();
            this.ucLibrosGrid1 = new Biblio.Front.ucLibrosGrid();
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
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 29);
            this.label5.TabIndex = 14;
            this.label5.Text = "Prestamos";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(71)))), ((int)(((byte)(69)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1170, 59);
            this.label4.TabIndex = 13;
            // 
            // btnCrear
            // 
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrear.Location = new System.Drawing.Point(737, 516);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(143, 43);
            this.btnCrear.TabIndex = 16;
            this.btnCrear.Text = "Guardar";
            this.btnCrear.UseVisualStyleBackColor = true;
            // 
            // btnBuscarSocio
            // 
            this.btnBuscarSocio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarSocio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarSocio.Location = new System.Drawing.Point(17, 78);
            this.btnBuscarSocio.Name = "btnBuscarSocio";
            this.btnBuscarSocio.Size = new System.Drawing.Size(132, 37);
            this.btnBuscarSocio.TabIndex = 17;
            this.btnBuscarSocio.Text = "Buscar socio";
            this.btnBuscarSocio.UseVisualStyleBackColor = true;
            this.btnBuscarSocio.Click += new System.EventHandler(this.btnBuscarSocio_Click);
            // 
            // ucLibrosGrid1
            // 
            this.ucLibrosGrid1.Location = new System.Drawing.Point(12, 147);
            this.ucLibrosGrid1.Name = "ucLibrosGrid1";
            this.ucLibrosGrid1.Size = new System.Drawing.Size(821, 363);
            this.ucLibrosGrid1.TabIndex = 18;
            // 
            // frmPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 622);
            this.Controls.Add(this.ucLibrosGrid1);
            this.Controls.Add(this.btnBuscarSocio);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "frmPrestamo";
            this.Text = "frmPrestamo";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnBuscarSocio;
        private ucLibrosGrid ucLibrosGrid1;
    }
}