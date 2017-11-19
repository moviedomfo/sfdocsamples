using Biblio.Common.BE;
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
                    lblSelectedSocio.Text = currentSocio.ToString();
                }
            }
        }

        private void frmPrestamo_Load(object sender, EventArgs e)
        {
            this.ucLibrosGrid1.Search(String.Empty);
        }

        private void ucLibrosGrid1_OnDoubleClickEvent(object sender, EventArgs e)
        {
            
        }

        private void ucLibrosGrid1_OnClickEvent(object sender, EventArgs e)
        {
            lblSelLibro.Text = ucLibrosGrid1.currentLibro.Titulo;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (currentSocio == null)
                MessageBox.Show("debe seleccionar un socio");
            if (ucLibrosGrid1.currentLibro == null)
                MessageBox.Show("debe seleccionar un libro");


            LibrosDAC.Prestamo(currentSocio, ucLibrosGrid1.currentLibro);
        }
    }
}
