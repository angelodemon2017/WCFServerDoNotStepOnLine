using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace HostForGame
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost serviceHost = new ServiceHost(typeof(WCFServerDoNotStepOnLine.Service1)))
            {
                serviceHost.Open();
                Console.WriteLine("Game server started");
                Console.ReadLine();
            }
        }
    }
}
