using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Allus_DXExpress.DataRepository;

namespace Allus_DXExpress
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            employeesBEListBindingSource.DataSource = EmployeesBEList.Factory();
            gridControl1.RefreshDataSource();
        }

        private void gridView1_ColumnUnboundExpressionChanged(object sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {

        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column == colSalary)
            {
                var c = e.Column;
            }
        }
    }
}
