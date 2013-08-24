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

        public void Run()
        {
        }
        /*
         * These two threads should only read variables under 'this'
         * Never write.
         * This allows us to avoid locking issues.
         * Any real work is sent to the Process Thread
         * that waits on global blocking queue.
         * 
         */
        private Thread CommandThread;
        private Thread MulticastListenThread;
        private Thread Dispatcherhread;
        private void RunDispatcherThread()
        {

        }
        #region AgentControlContract Members

        bool AgentControlContract.Start()
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
