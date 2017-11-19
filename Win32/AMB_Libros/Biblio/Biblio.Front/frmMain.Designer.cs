namespace Biblio.Front
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.librosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altasLibroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaLibroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sociosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaSocioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaSocioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prestamosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 672);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(1425, 25);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(49, 20);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.librosToolStripMenuItem,
            this.sociosToolStripMenuItem,
            this.prestamosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1425, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // librosToolStripMenuItem
            // 
            this.librosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altasLibroToolStripMenuItem,
            this.consultaLibroToolStripMenuItem});
            this.librosToolStripMenuItem.Image = global::Biblio.Front.Properties.Resources.books;
            this.librosToolStripMenuItem.Name = "librosToolStripMenuItem";
            this.librosToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.librosToolStripMenuItem.Text = "Libros";
            // 
            // altasLibroToolStripMenuItem
            // 
            this.altasLibroToolStripMenuItem.Name = "altasLibroToolStripMenuItem";
            this.altasLibroToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.altasLibroToolStripMenuItem.Text = "Altas";
            this.altasLibroToolStripMenuItem.Click += new System.EventHandler(this.altasLibroToolStripMenuItem_Click);
            // 
            // consultaLibroToolStripMenuItem
            // 
            this.consultaLibroToolStripMenuItem.Name = "consultaLibroToolStripMenuItem";
            this.consultaLibroToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.consultaLibroToolStripMenuItem.Text = "Consulta";
            this.consultaLibroToolStripMenuItem.Click += new System.EventHandler(this.consultaLibroToolStripMenuItem_Click);
            // 
            // sociosToolStripMenuItem
            // 
            this.sociosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaSocioToolStripMenuItem,
            this.consultaSocioToolStripMenuItem});
            this.sociosToolStripMenuItem.Image = global::Biblio.Front.Properties.Resources.socios;
            this.sociosToolStripMenuItem.Name = "sociosToolStripMenuItem";
            this.sociosToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.sociosToolStripMenuItem.Text = "Socios";
            // 
            // altaSocioToolStripMenuItem
            // 
            this.altaSocioToolStripMenuItem.Name = "altaSocioToolStripMenuItem";
            this.altaSocioToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.altaSocioToolStripMenuItem.Text = "Alta";
            this.altaSocioToolStripMenuItem.Click += new System.EventHandler(this.altaSocioToolStripMenuItem_Click_1);
            // 
            // consultaSocioToolStripMenuItem
            // 
            this.consultaSocioToolStripMenuItem.Name = "consultaSocioToolStripMenuItem";
            this.consultaSocioToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.consultaSocioToolStripMenuItem.Text = "Consulta";
            this.consultaSocioToolStripMenuItem.Click += new System.EventHandler(this.consultaSocioToolStripMenuItem_Click);
            // 
            // prestamosToolStripMenuItem
            // 
            this.prestamosToolStripMenuItem.Image = global::Biblio.Front.Properties.Resources.descarga;
            this.prestamosToolStripMenuItem.Name = "prestamosToolStripMenuItem";
            this.prestamosToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.prestamosToolStripMenuItem.Text = "Prestamos";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1425, 697);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "Biblioteca";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

     
        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem librosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altasLibroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaLibroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sociosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaSocioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaSocioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prestamosToolStripMenuItem;
    }
}



