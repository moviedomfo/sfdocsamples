using Biblio.Common;
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
    public partial class frmLogin : baseForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                errorProvider1.SetError(txtUsuario, "Ingrese el nombre de usuario");
                return;
            }

            if (string.IsNullOrEmpty(txtPwd.Text))
            {
                errorProvider1.SetError(txtPwd, "Ingrese el nombre de usuario");
                return;
            }


            CommonHelpers.currenUser = SecurityDAC.Authenticate(txtUsuario.Text, txtPwd.Text);

            if (CommonHelpers.currenUser == null)
            {
                MessageBox.Show("Nombre de usuario o password incorrecto");
                return;
            }

            frmMain frmMain = new Front.frmMain();
            frmMain.Show();
            this.Hide();
        }
    }
}
