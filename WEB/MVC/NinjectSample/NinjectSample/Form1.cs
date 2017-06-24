using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Windows.Forms;
using Ninject;
using NinjectSample.Clases.IoC_1;
using NinjectSample.Clases.BE;
using NinjectSample.Clases.Svc;

namespace NinjectSample
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            NinjectWebCommon.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //IKernel kernel = new StandardKernel();
            //kernel.Bind<IPaisRepository>().To<PaisRepository>();
            //System.Web.Http.Dependencies.IDependencyResolver resolver = new NinjectResolver(kernel);
            //GlobalConfiguration.Configuration.DependencyResolver = resolver;

            var service = NinjectWebCommon.Get_Service<UserService>();

            var uData = service.Get("gerard");

            textBox1.Text = "Nombre actual = " + uData.FirstName;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var service = NinjectWebCommon.Get_Service<UserService>();
            var uData = service.Get("gerard");
            textBox1.Text = "Nombre actual = " + uData.FirstName;
            uData.FirstName = "Nombre actualizado";
            service.Update(uData);

        }
    }
}
