using Biblio.DAC;
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
    public partial class frmLibrosGrid : baseForm
    {
        public frmLibrosGrid()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLibrosGrid_Load(object sender, EventArgs e)
        {
             ucLibrosGrid1.Search("");
        }

        private void ucLibrosGrid1_OnClickEvent(object sender, EventArgs e)
        {
            if(ucLibrosGrid1.currentLibro!=null)
            {
                lblSelected.Text = ucLibrosGrid1.currentLibro.Titulo;
            }
            else
            { lblSelected.Text = "-----------------"; }
            
        }

        private void ucLibrosGrid1_OnDoubleClickEvent(object sender, EventArgs e)
        {

        }
    }
}
