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
    public partial class frmDevolucion : baseForm
    {

        PrestamosView currentPrestamos { get; set; }
        public frmDevolucion()
        {
            InitializeComponent();
        }



        private void ucPrestamosGrid1_OnClickEvent(object sender, EventArgs e)
        {
            lblSelectedSocio.Text = "----------------";
            lblSelLibro.Text = "----------------";

            if (ucPrestamosGrid1.currentPrestamosView != null)
            {
                if (ucPrestamosGrid1.currentPrestamosView.Estado == "Prestado")
                {
                    lblSelectedSocio.Text = ucPrestamosGrid1.currentPrestamosView.Socio;
                    lblSelLibro.Text = ucPrestamosGrid1.currentPrestamosView.Titulo;
                }
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ucPrestamosGrid1.currentPrestamosView == null)
            {
                MessageBox.Show("Seleccione un libro para su devolucion");
                return;
            }

            PrestamosDAC.Devolucion(ucPrestamosGrid1.currentPrestamosView.IdPrestamo);
            ucPrestamosGrid1.Search();

        }

        private void frmDevolucion_Load(object sender, EventArgs e)
        {
            ucPrestamosGrid1.Search();
        }

        private void chkVerDevueltos_CheckedChanged(object sender, EventArgs e)
        {
            ucPrestamosGrid1.Filter(chkVerDevueltos.Checked);


        }
    }
}
