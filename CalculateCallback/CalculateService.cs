using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace CalculateCallback
{
    [ServiceBehavior(InstanceContextMode =InstanceContextMode.PerSession)]
    public class CalculateService : CalculateServiceInterface
    {
        double result;
        CalculateCallbackHandler callback = null;

        public CalculateService()
        {
            callback = OperationContext.Current.GetCallbackChannel<CalculateCallbackHandler>();
        }

        public void calcFactorial(double n)
        {
            Console.WriteLine($"...started calcFactorial({n})");
            Thread.Sleep(1000);
            result = 1;
            for (int i = 1; i <= n; i++)
                result *= i;

            callback.returnFactorial(result);
        }

        public void calculate(int secs)
        {
            Console.WriteLine($"...started calculate({secs})");

            if (secs < 10)
                Thread.Sleep(secs * 1000);
            else
                Thread.Sleep(1000);

            callback.returnCalculate($"Total calculation time: {secs + 1} seconds");
        }
    }
}
