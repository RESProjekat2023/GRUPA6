using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common;
using projekatERS.DataBaseCRUD;
using projekatERS.Worker;

namespace projekatERS.LoadBalancer
{
    public class Program
    {
        static void Main(string[] args)
        {


            ServiceHost host = new ServiceHost(typeof(Service));
            
                host.AddServiceEndpoint(typeof(IPotrosnjaBrojilo),
                     new NetTcpBinding(),
                   new Uri("net.tcp://localhost:4000/IPotrosnjaBrojilo"));
                host.Open();
                Console.WriteLine("Servis1 je uspesno pokrenut");

            



                ServiceHost host1 = new ServiceHost(typeof(DataBaseAnaliticsServiceImpl));
                
                    host1.AddServiceEndpoint(typeof(IDataBaseAnaliticsService),
                         new NetTcpBinding(),
                       new Uri("net.tcp://localhost:4001/IDataBaseAnaliticsService"));
                    host1.Open();
                    Console.WriteLine("Servis2 je uspesno pokrenut");

                    Console.ReadKey();
                
            
        }
    }
}
