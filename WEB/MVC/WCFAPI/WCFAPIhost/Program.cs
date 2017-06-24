using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFAPI;

namespace WCFAPIhost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(WCFAPIService)))
            {
                host.Open();
                MetadataHelper.Log_ServiceHost(host);
                Console.ReadLine();
            }


        }

        void SetNetTcpBinding(ServiceHost host)
        {

            NetTcpBinding tcpBinding = new NetTcpBinding();
            Uri wUri = new Uri("net.tcp://santana:8001/WCFAPIService");
            tcpBinding.TransactionFlow = true;

            host.AddServiceEndpoint(typeof(IWCFAPIService), tcpBinding, wUri);
            host.Open();
        }
    }
}
