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
    public partial class frmPrestamo : baseForm
    {
        SocioBE currentSocio { get; set; }
        LibroBE currentLibro { get; set; }
        public frmPrestamo()
        {
            InitializeComponent();
        }

        private void btnBuscarSocio_Click(object sender, EventArgs e)
        {
            using (frmSocioGrid frm = new frmSocioGrid())
            {
                if (frm.ShowDialog()== DialogResult.OK)
                {
                    currentSocio = frm.SelectedSocio;
                }
            }
        }
    }
}
