using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPConsoleClient.opservice;
using C=System.Console;

namespace OPConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderClient oc = new OrderClient();
            //db = new Order("ism6236", "ism6236bo");

            String [] aclist = oc.getProductIds();
            foreach (String s in aclist)
            {
                String p = oc.getProductDetail(s);
                C.WriteLine(String.Format("{0} --> {1}", s, p));
            }

            C.WriteLine();
            C.Write("Enter P to purchase,  L to list customer orders , Q to quit > ");

            String input = C.ReadLine();
            bool quit = false;
            List<String> ord = new List<String>();
            while (!quit)
            {
                int c = input[0];
                switch (c)
                {
                    case 'p':
                    case 'P':
                        C.Write("Enter Customer No: ");

                        String cno = C.ReadLine();
                        while (true)
                        {
                            C.Write("Enter Product No: ");
                            String pid = C.ReadLine();
                            C.Write("Enter Quantity: ");

                            String q = C.ReadLine();
                            C.Write("Enter Price: ");

                            String price = C.ReadLine();
                            String oline = String.Format("{0},0,{1},{2}", pid, price, q); //the GUI had inserted the description so I am inserting 0 as a place holder
                            ord.Add(oline);
                            C.Write("Enter N to add another product, P to finalize the purchase > ");

                            String d = C.ReadLine();
                            if (d.ToLower().Equals("p"))
                            {
                                break;
                            }
                        }
                        String[] x = new String[ord.Count];
                        for (int i = 0; i < ord.Count; i++) { x[i] = ord[i]; }
                        int n = oc.Purchase(cno, x);
                        //Update(accno, amt);
                        C.WriteLine(String.Format("{0} records got updated", n));
                        break;

                    case 'L':
                    case 'l':
                        C.Write("Enter Customer No: ");

                        cno = C.ReadLine();
                        String [] l = (string []) oc.getCustomerOrders(cno);
                        for (int i = 0; i < l.Length; i++)
                        {
                            String oid = l[i];
                            String [] od = oc.getOrderDetails(oid);
                            C.WriteLine(String.Format("OrderId: {0}", oid));
                            foreach (String s in od)
                            {
                                C.WriteLine(s);
                            }
                        }

                        break;
                    default:
                        quit = true;
                        break;

                }

                if (!quit)
                {
                    C.Write("Enter P to purchase,  L to list customer orders , Q to quit > ");

                    input = C.ReadLine();
                }

            }
        }
    }
}
