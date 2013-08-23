using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace dagent_net_lib
{
    [ServiceContract]
    interface AgentControlContract
    {
        [OperationContract]
        Boolean Start();
        [OperationContract]
        Boolean Stop();
        [OperationContract]
        Boolean Pause();
        [OperationContract]
        Boolean Resume();
        [OperationContract]
        Boolean ForceSync();
    }
}
