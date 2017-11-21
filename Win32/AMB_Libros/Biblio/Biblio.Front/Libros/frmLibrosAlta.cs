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
    public partial class frmLibrosAlta : baseForm
    {
        public frmLibrosAlta()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            var libro = MapEntity();
            try
            {
                LibrosDAC.Create(libro);

                MessageBox.Show("El libro se creo con exito");
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool ValidateInputs()
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtAutor.Text))
            {
                errorProvider1.SetError(this.txtAutor, "Ingrese el nombre de autor");
                return false;
            }
            if (string.IsNullOrEmpty(txtIDSBN.Text))
            {
                errorProvider1.SetError(this.txtIDSBN, "Ingrese ISBN");
                return false;
            }
            if (string.IsNullOrEmpty(txttitulo.Text))
            {
                errorProvider1.SetError(this.txttitulo, "Ingrese titulo");
                return false;
            }
            return true;
        }
        void Clear()
        {
            txtAutor.Text = "";
            txttitulo.Text = "";
            txtIDSBN.Text = "";
            numStock.Value = 0;
        }

        LibroBE MapEntity()
        {
            LibroBE item = new LibroBE();
            item.Autor = txtAutor.Text;
            item.Titulo = txttitulo.Text;
            item.ISBN = txtIDSBN.Text;
            item.Stock = Convert.ToInt32(numStock.Value);
            return item;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(frmLibrosGrid frm = new frmLibrosGrid())
            {
                frm.ShowDialog();
            }
        }
    }
}
