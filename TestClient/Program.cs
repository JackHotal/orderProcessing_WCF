using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestClient.SelfHostedOPService;
using TestClient.jwsopservice;


namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            StockQuote sq = new StockQuote();
            Console.WriteLine(sq.GetQuote("INTC"));
            */

            OrderClient oc = new OrderClient();
            Console.WriteLine(oc.getCustomer("1"));

            //OrderProcessingServiceClient opsc = new OrderProcessingServiceClient();
            //Console.WriteLine(opsc.getCustomer("1"));

            Console.ReadKey();
        }
    }
}
