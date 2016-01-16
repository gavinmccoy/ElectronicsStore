using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace StockCheckWebService
{
    class Program
    {
        static void Main(string[] args)
        {
            //Uri baseAddress = new Uri("http://localhost:8000/StockCheckWebService/StockCheckService");
            Uri baseAddress = new Uri("http://localhost:8000/");

            ServiceHost selfHost = new ServiceHost(typeof(StockCheckService), baseAddress);

            try
            {
                selfHost.AddServiceEndpoint(
                    typeof(IStockCheck),
                    new BasicHttpBinding(),
                    "StockCheckService");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                selfHost.Open();
                Console.WriteLine("The service is ready. Press <ENTER> to terminate service.");
                Console.ReadLine();

                selfHost.Close();

            }

            catch(CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
        }
    }
}
