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
    }
}
