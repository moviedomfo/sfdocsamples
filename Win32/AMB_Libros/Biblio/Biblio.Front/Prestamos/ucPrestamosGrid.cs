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
    [DefaultEvent("OnClickEvent")]
    public partial class ucPrestamosGrid : UserControl
    {
        public event EventHandler OnClickEvent;
        public PrestamosView currentPrestamosView;
        public PrestamosViewList prestamosViewList;
        public ucPrestamosGrid()
        {
            InitializeComponent();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            currentPrestamosView = (PrestamosView)this.prestamosViewListBindingSource.Current;
            if (OnClickEvent != null)
            {
                OnClickEvent(this, new EventArgs());
            }
        }
        public void Search()
        {
            prestamosViewList = PrestamosDAC.Search();
            Filter(false);
        }
        public void Filter(Boolean incluirDevueltos)
        {
            PrestamosViewList prestamosViewListAux = new PrestamosViewList();
            if(prestamosViewList==null)
            { return; }
            if (incluirDevueltos)
            {

                prestamosViewListAux = this.prestamosViewList;
               
            }
            else
            {
                var filterList = prestamosViewList.Where(p => p.Estado != "Devuelto");
                prestamosViewListAux.AddRange(filterList.ToList());
            }
            

            this.prestamosViewListBindingSource.DataSource = prestamosViewListAux;
        }
    }
}

