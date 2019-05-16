using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WCF_Streams_Client.CalculateService;
using WCF_Streams_Client.MainService;

namespace WCF_Streams_Client
{
    class Program
    {
        private static readonly String client_name = "Client 1";
        private static readonly String client_calc = "Client 2";

        static void Main(string[] args)
        {

            MainServiceInterfaceClient client = new MainServiceInterfaceClient("BasicHttpBinding_MainServiceInterface");

            Console.WriteLine($"Starting client: {client_name}");

            start_sync(client, "Client 1");
            start_async(client, "Client 1");
            start_sync(client, "Client 1");
            client.Close();

            Console.WriteLine($"Client finished: {client_name}");


            //Callbacks
            Console.WriteLine($"\n\n\nStarting client: {client_calc}");

            CalculateHandler callbackHandler = new CalculateHandler();
            InstanceContext instanceContext = new InstanceContext(callbackHandler);
            CalculateService.CalculateServiceInterfaceClient client2 = new CalculateService.CalculateServiceInterfaceClient(instanceContext);

            start_factorial(client2, 10);
            start_factorial(client2, 20);
            start_calc(client2, 2);

            client2.Close();

            Console.WriteLine($"Client finished: {client_calc}");
        }

        static void start_factorial(CalculateService.CalculateServiceInterfaceClient client, int n)
        {
            Console.WriteLine($"...starting calcFactorial({n})...");
            client.calcFactorial(n);
        }

        static void start_calc(CalculateService.CalculateServiceInterfaceClient client, int secs)
        {
            Console.WriteLine($"...starting calculate({secs})...");
            client.calculate(secs);
            Console.WriteLine($"...waiting for calculations results");
        }

        static void start_sync(MainServiceInterfaceClient client, String message)
        {
            Console.WriteLine("...Starting synchronous function");
            client.SyncFunction("Client 1");
            Thread.Sleep(10);
            Console.WriteLine("..after synchronous function: ");

        }

        static void start_async(MainServiceInterfaceClient client, String message)
        {
            Console.WriteLine("...Starting asynchronous function");
            client.ASyncFunction("Client 1");
            Thread.Sleep(10);
            Console.WriteLine("...after asynchronous function: ");
        }
    }
}
