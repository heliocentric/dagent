using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ServiceModel;
namespace dagent_net_lib
{
    public class Agent : AgentControlContract
    {

        public void Start()
        {
        }
        #region AgentControlContract Members

        public bool Start()
        {
            throw new NotImplementedException();
        }

        public bool Stop()
        {
            throw new NotImplementedException();
        }

        public bool Pause()
        {
            throw new NotImplementedException();
        }

        public bool Resume()
        {
            throw new NotImplementedException();
        }

        public bool ForceSync()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
