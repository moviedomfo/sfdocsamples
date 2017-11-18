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
        
        frmLibrosAlta childForm;
        public frmMain()
        {
            InitializeComponent();
        }

        private void AltaLibro_click(object sender, EventArgs e)
        {
            
            if (this.Contains(childForm))
                return;
            childForm = new frmLibrosAlta();
            childForm.MdiParent = this;
            childForm.Show();
        }

       
        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
    }
}
