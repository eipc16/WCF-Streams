using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StreamingContract
{
    public class FileService : FileServiceInterface
    {
        public Stream getStream(string name)
        {
            FileStream file;
            Console.WriteLine($"--> Started getStream({name})");

            string filePath = Path.Combine(System.Environment.CurrentDirectory, $"{name}");
            
            try
            {
                file = File.OpenRead(filePath);
            } catch (IOException e)
            {
                Console.WriteLine(string.Format($"Could not load file: {filePath}: "));
                Console.WriteLine(e.ToString());
                throw e;
            }
            return file;
        }

        public ResponseFileMessage getMStream(RequestFileMessage request)
        {
            ResponseFileMessage response = new ResponseFileMessage();
            FileStream file;
            Console.WriteLine($"--> Started getMStream({request.name})");

            string filePath = Path.Combine(System.Environment.CurrentDirectory, $"{request.name}");

            try
            {
                file = File.OpenRead(filePath);

                response.name = request.name;
                response.size = file.Length;
                response.data = file;

            }
            catch (IOException e)
            {
                Console.WriteLine(string.Format($"Could not load file: {filePath}: "));
                Console.WriteLine(e.ToString());
                throw e;
            }
            return response;
        }
    }
}
