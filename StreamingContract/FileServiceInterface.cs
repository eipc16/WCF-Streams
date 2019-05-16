using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StreamingContract
{
    [ServiceContract]
    public interface FileServiceInterface
    {
        [OperationContract]
        System.IO.Stream getStream(String name);
    }
}
