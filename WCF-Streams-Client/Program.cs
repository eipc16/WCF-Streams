using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WCF_Streams_Client.MainService;

namespace WCF_Streams_Client
{
    class Program
    {
        private static String client_name = "Client 1";
        static void Main(string[] args)
        {

            MainServiceInterfaceClient client = new MainServiceInterfaceClient("BasicHttpBinding_MainServiceInterface");

            Console.WriteLine($"Starting client: {client_name}");

            start_sync(client, "Client 1");
            start_async(client, "Client 1");
            start_sync(client, "Client 1");
            client.Close();

            Console.WriteLine($"Client finished: {client_name}");
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
