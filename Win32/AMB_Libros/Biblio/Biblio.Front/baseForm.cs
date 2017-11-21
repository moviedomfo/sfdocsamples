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
    public partial class baseForm : Form
    {
        public baseForm()
        {
            InitializeComponent();
            this.KeyDown += BaseForm_KeyDown;
            this.KeyPreview = true;
        }

        private void BaseForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
