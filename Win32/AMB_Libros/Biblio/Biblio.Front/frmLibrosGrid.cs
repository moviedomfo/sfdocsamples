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
            
            libroListBindingSource.DataSource = LibrosDAC.Search("");
        }
    }
}
