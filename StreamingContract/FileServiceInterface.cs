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

        [OperationContract]
        ResponseFileMessage getMStream(RequestFileMessage request);
        
    }

    [MessageContract]
    public class RequestFileMessage
    {
        [MessageBodyMember]
        public string name;
    }

    [MessageContract]
    public class ResponseFileMessage
    {
        [MessageHeader]
        public string name;

        [MessageHeader]
        public long size;

        [MessageBodyMember]
        public System.IO.Stream data;
    }
}
