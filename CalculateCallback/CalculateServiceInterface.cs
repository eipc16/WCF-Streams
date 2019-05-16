using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CalculateCallback
{
    [ServiceContract (
        SessionMode =SessionMode.Required,
        CallbackContract = typeof(CalculateCallbackHandler)                
        )]
    public interface CalculateServiceInterface
    {
        [OperationContract(IsOneWay = true)]
        void calcFactorial(double n);

        [OperationContract]
        void calculate(int secs);
    }

    public interface CalculateCallbackHandler
    {
        [OperationContract(IsOneWay = true)]
        void returnFactorial(double n);

        [OperationContract(IsOneWay = true)]
        void returnCalculate(string result);
    }
}
