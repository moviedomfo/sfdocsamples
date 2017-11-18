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
    }
}
