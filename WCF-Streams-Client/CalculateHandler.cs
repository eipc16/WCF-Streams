using System;
using WCF_Streams_Client.CalculateService;

namespace WCF_Streams_Client
{
    class CalculateHandler : CalculateServiceInterfaceCallback
    {
        public void returnCalculate(string result)
        {
            Console.WriteLine($"Result: {result}"); 
        }

        public void returnFactorial(double n)
        {
            Console.WriteLine($"Factorial: {n}");
        }
    }
}
