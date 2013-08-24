using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dagent_net_lib
{
    public class AgentOperation
    {
        public OperationType Type;
        public enum OperationType
        {
            AgentStart,
            AgentStop,
            AgentPause,
            AgentResume,
            SyncNow
        }
    }
}
