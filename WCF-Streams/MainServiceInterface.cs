using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Streams
{
    [ServiceContract]
    public interface MainServiceInterface
    {
        [OperationContract]
        void SyncFunction(String data);

        [OperationContract(IsOneWay = true)]
        void ASyncFunction(String data);

    }
}
