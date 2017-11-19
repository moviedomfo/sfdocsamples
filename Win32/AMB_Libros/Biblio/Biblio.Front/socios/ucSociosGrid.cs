using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblio.Common.BE;
using Biblio.DAC;

namespace Biblio.Front
{
    [ToolboxItem(true)]
    [DefaultEvent("OnDoubleClickEvent")]
    public partial class ucSociosGrid : UserControl
    {
        public event EventHandler OnDoubleClickEvent;
        public event EventHandler OnClickEvent;
        public SocioBE currentSocio;
        public ucSociosGrid()
        {
            InitializeComponent();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            currentSocio = (SocioBE)this.socioBEListBindingSource.Current;
            if (OnClickEvent != null)
            {
                OnClickEvent(this, new EventArgs());
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            currentSocio = (SocioBE)this.socioBEListBindingSource.Current;
            if (OnDoubleClickEvent != null)
            {
                OnDoubleClickEvent(this, new EventArgs());
            }
        }
    }
}
