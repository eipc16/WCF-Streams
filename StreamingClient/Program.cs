using StreamingClient.FileService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingClient
{
    class Program
    {
        static void Main(string[] args)
        {
            FileServiceInterfaceClient client = new FileServiceInterfaceClient();
            string filePath = Path.Combine(System.Environment.CurrentDirectory, "client.png");

            Console.WriteLine("Starting getStream()");
            Stream stream = client.getStream("image.png");
            SaveFile(stream, filePath);

            client.Close();
            Console.WriteLine("\nPress <ENTER> to exit!");
            Console.ReadLine();
        }

        static void SaveFile(Stream instream, string dest)
        {
            const int bufferLength = 8192;
            int bytecount = 0;
            int counter = 0;
            byte[] buffer = new byte[bufferLength];

            Console.WriteLine($"--> Saving file: {dest}");
            FileStream outstream = File.Open(dest, FileMode.Create, FileAccess.Write);

            while((counter = instream.Read(buffer, 0, bufferLength)) > 0)
            {
                outstream.Write(buffer, 0, counter);
                Console.Write($".{counter}");
                bytecount += counter;
            }

            Console.WriteLine($"\nSaved {bytecount} bytes");

            outstream.Close();
            instream.Close();
            Console.WriteLine($"--> File {dest} saved!");
        }
    }
}
