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
    public partial class frmSocioAlta : baseForm
    {
        public frmSocioAlta()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            var item = MapEntity();
            try
            {
                SocioDAC.Create(item);

                MessageBox.Show("El socio se creo con exito");
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        void Clear()
        {
            txtApellido.Text = "";
            txtDNI.Text = "";
            txtNombre.Text = "";
            textTelefono.Text = "";
        }

        SocioBE MapEntity()
        {
            SocioBE item = new SocioBE();
            item.Apellido = txtApellido.Text;
            item.Nombre = txtNombre.Text;
            item.DNI = txtDNI.Text;
            item.Telefono = textTelefono.Text;
            return item;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
