using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace dagent_net_lib
{
    interface AgentControlContract
    {
        Boolean Start();
        Boolean Stop();
        Boolean Pause();
        Boolean Resume();
        Boolean ForceSync();
    }
}
