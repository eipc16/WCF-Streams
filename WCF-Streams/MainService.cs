using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace WCF_Streams
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class MainService : MainServiceInterface
    {
        public void ASyncFunction(string data)
        {
            Console.WriteLine($"...{data}: Asynchronous function: START");
            Thread.Sleep(4000);
            Console.WriteLine($"...{data}: Asynchronous function: STOP");
            return;
        }

        public void SyncFunction(string data)
        {
            Console.WriteLine($"...{data}: Synchronous function: START");
            Thread.Sleep(2000);
            Console.WriteLine($"...{data}: Synchronous function: STOP");
            return;
        }
    }
}
