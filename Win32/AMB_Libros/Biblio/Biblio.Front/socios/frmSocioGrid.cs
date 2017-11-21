using Biblio.Common.BE;
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
    public partial class frmSocioGrid : baseForm
    {
        public SocioBE SelectedSocio {get;set;}
        public frmSocioGrid()
        {
            InitializeComponent();
        }

        private void ucSociosGrid1_OnDoubleClickEvent(object sender, EventArgs e)
        {
            this.SelectedSocio = ucSociosGrid1.currentSocio;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ucSociosGrid1_OnClickEvent(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if (ucSociosGrid1.currentSocio == null)
                return;
            this.SelectedSocio = ucSociosGrid1.currentSocio;
            lblSelected.Text = ucSociosGrid1.currentSocio.ToString();
=======
            if (ucSociosGrid1.currentSocio != null)
            {
                this.SelectedSocio = ucSociosGrid1.currentSocio;
                lblSelected.Text = ucSociosGrid1.currentSocio.ToString();
            }
            else
            {
                 this.SelectedSocio = null;
                  this.lblSelected.Text = "-----------";
            }
>>>>>>> parent of 7dc2355... Merge remote-tracking branch 'origin/master'
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmSocioGrid_Load(object sender, EventArgs e)
        {
            ucSociosGrid1.Search(String.Empty);
        }
    }
}
