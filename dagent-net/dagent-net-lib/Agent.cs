using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace dagent_net_lib
{
    public class Agent : AgentControlContract
    {

        /* This function contains the start routines for the actual agent thread. 
         * Note, that only init does this, and you only want to init once, normally
         * when the computer is started. 
         * 
         * The agent will then begin it's initialization routine, which involves
         * sitting on a named pipe waiting for further instructions from this class.
         * This allows the code to be in both an embedded library, and a service. 
         * 
         */
        public void Start()
        {
        }

        #region AgentControlContract Members

        bool AgentControlContract.Start()
        {
            throw new NotImplementedException();
        }

        bool AgentControlContract.Stop()
        {
            throw new NotImplementedException();
        }

        bool AgentControlContract.Pause()
        {
            throw new NotImplementedException();
        }

        bool AgentControlContract.Resume()
        {
            throw new NotImplementedException();
        }

        bool AgentControlContract.ForceSync()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
