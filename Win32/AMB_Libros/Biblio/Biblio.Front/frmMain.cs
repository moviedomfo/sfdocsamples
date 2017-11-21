using Biblio.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblio.Front
{
    public partial class frmMain : Form
    {
        
        frmLibrosAlta librosAlta;
        frmLibrosGrid librosGrid;
        frmSocioAlta socioAlta;
        public frmMain()
        {
            InitializeComponent();
        }

        

       
        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

       

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
         
        }
        
        private void listadoLibrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           



        }

        private void altaSocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

      


        //void ShowForm(baseForm frm)
        //{
        //    if (this.Contains(frm))
        //        return;
        //    frm = new baseForm();
        //    frm.MdiParent = this;
        //    frm.Show();

        //}

      
        private void altasLibroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Contains(librosAlta))
                return;
            librosAlta = new frmLibrosAlta();
            librosAlta.MdiParent = this;
            librosAlta.Show();
        }

        private void consultaLibroToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (this.Contains(librosGrid))
                return;
            librosGrid = new frmLibrosGrid();
            librosGrid.MdiParent = this;
            librosGrid.Show();
        }


        frmSocioGrid frmSocioGrid;
        private void consultaSocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Contains(frmSocioGrid))
                return;
            frmSocioGrid = new frmSocioGrid();
            frmSocioGrid.MdiParent = this;
            frmSocioGrid.Show();
        }

        private void altaSocioToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (this.Contains(socioAlta))
                return;
            socioAlta = new frmSocioAlta();
            socioAlta.MdiParent = this;
            socioAlta.Show();
        }
        frmPrestamo frmPrestamo;
        private void prestamosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Contains(frmPrestamo))
                return;
            frmPrestamo = new frmPrestamo();
            frmPrestamo.MdiParent = this;
            frmPrestamo.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel.Text = CommonHelpers.currenUser.ToString();
        }
        frmDevolucion frmDevolucion;
        private void devolucionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                if (this.Contains(frmDevolucion))
                return;
            frmDevolucion = new frmDevolucion();
            frmDevolucion.MdiParent = this;
            frmDevolucion.Show();
        }
    }
}
