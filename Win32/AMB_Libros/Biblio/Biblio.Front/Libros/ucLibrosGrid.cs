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
    public partial class ucLibrosGrid : UserControl
    {
        public event EventHandler OnDoubleClickEvent;
        public event EventHandler OnClickEvent;
        public LibroBE currentLibro;
        public ucLibrosGrid()
        {
            InitializeComponent();
        }

     

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //casteo el libro del actual libro en el datasource
            currentLibro = (LibroBE)this.libroListBindingSource.Current;
            if (OnDoubleClickEvent != null)
            {
                OnDoubleClickEvent(this, new EventArgs());
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            currentLibro = (LibroBE)this.libroListBindingSource.Current;
            if (OnClickEvent != null)
            {
                OnClickEvent(this, new EventArgs());
            }
        }

        public void Search(string txtToSearch)
        {
            libroListBindingSource.DataSource = LibrosDAC.Search(txtToSearch);
        }
    }
}
