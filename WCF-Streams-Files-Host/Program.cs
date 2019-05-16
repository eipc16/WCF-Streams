using StreamingContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Streams_Files_Host
{
    class Program
    {
        private static string BASE_NAME = "Files";
        private static int PORT = 9007;

        static void Main(string[] args)
        {
            Uri baseAddress = new Uri($"http://localhost:{PORT}/{BASE_NAME}");

            ServiceHost host = new ServiceHost(typeof(FileService), baseAddress);
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.TransferMode = TransferMode.Streamed;
            binding.MaxReceivedMessageSize = 1000000000;
            binding.MaxBufferSize = 8192;

            try
            {
                ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(FileServiceInterface), binding, "endpoint_" + BASE_NAME);
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
            }
            catch (CommunicationException exception)
            {
                Console.WriteLine($"Exception encountered: {exception}");
                host.Abort();
            }
        }
    }
}
