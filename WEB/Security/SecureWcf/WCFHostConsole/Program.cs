using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using SecureWcf;

namespace WCFHostConsole
{
    //Se debe abrir en Run As administrator por tema de permisos
    //To start both client and host from Visual Studio
    //  1-In Solution Explorer, right-click the solution name.
    //  2-Click Set Startup Projects.
    //  3-In the Solution <name> Properties dialog box, select Multiple Startup Projects.
    //  4-In the Multiple Startup Projects grid, on the line that corresponds to the server project, click Action and choose Start.
    //  5-On the line that corresponds to the client project, click Action and choose Start.
    class Program
    {
        static ServiceHost serviceHost = null;
        static void Main(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

           //Uri ur = new Uri("net.tcp://localhost:9000/CoreSecurity.svc");
            serviceHost = new ServiceHost(typeof(CoreSecurity));
            serviceHost.Open();
            Console.WriteLine("The server is ready and listen on tcp port 9000");
            Console.ReadLine();
        }
    }
}
