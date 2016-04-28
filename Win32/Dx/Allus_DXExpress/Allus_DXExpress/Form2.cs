using Allus_DXExpress.DataRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Allus_DXExpress
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //aplicamos el binding
            employeesBEListBindingSource.DataSource = EmployeesBEList.Factory();
            gridControl1.RefreshDataSource();
        }
    }
}
