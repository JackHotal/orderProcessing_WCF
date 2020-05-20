using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderProcessingService;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace SelfHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1 of the address configuration procedure: Create a URI to serve as the base address.
            Uri baseAddress = new Uri("http://localhost:8000/MyServices");

            // Step 2 of the hosting procedure: Create ServiceHost
            ServiceHost selfHost = new ServiceHost(typeof(OrderProcessingService.OPService), baseAddress);
            try
            {

                // Step 3 of the hosting procedure: Add a service endpoint.
                selfHost.AddServiceEndpoint(typeof(IOrder), new WSHttpBinding(), "OPService");

                // Step 4 of the hosting procedure: Enable metadata exchange.
                // This allows creation of wsdl
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                // Step 5 of the hosting procedure: Start (and then stop) the service.
                selfHost.Open();
                Console.WriteLine(selfHost.Description.Endpoints[0].Address.ToString());
                Console.WriteLine(selfHost.Description.Endpoints[0].ListenUri.ToString());
                Console.WriteLine(selfHost.Description.Endpoints[0].Binding.ToString());

                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                //Need this to keep the host running
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                selfHost.Close();
            } //try
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
            finally { Console.ReadKey(); }

        }
    }
}
