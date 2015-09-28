using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace ServiceRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            System.ServiceModel.ServiceHost host = new System.ServiceModel.ServiceHost(typeof(TravelMSWebService.Service1));
            host.Open();
            Console.WriteLine("Accounts service started... Press any key to stop.");
            Console.ReadKey();
            host.Close();
            Console.WriteLine("Accounts service stopped.");
            Console.ReadLine();
        }
    }
}
