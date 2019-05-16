using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WCF_Streams;

namespace WCF_Streams_Host
{
    class Program
    {

        public static string BASE_NAME = "MainService";
        public static int PORT = 9005;

        static void Main(string[] args)
        {
            Uri baseAddress = new Uri($"http://localhost:{PORT}/{BASE_NAME}");
            ServiceHost host = new ServiceHost(typeof(MainService), baseAddress);

            try
            {
                ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(MainServiceInterface), new BasicHttpBinding(), "default_endpoint");
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior
                {
                    HttpGetEnabled = true
                };
                host.Description.Behaviors.Add(smb);

                host.Open();
                Console.WriteLine($"Service {BASE_NAME} has connected successfully and started working");
                Console.WriteLine("Press <ENTER> to finish!");
                Console.ReadLine();
       
                host.Close();
                Console.WriteLine($"Service {BASE_NAME} has finished working!");

            } catch (CommunicationException exception)
            {
                Console.WriteLine($"Exception encountered: {exception}");
                host.Abort();
            }
        }
    }
}
