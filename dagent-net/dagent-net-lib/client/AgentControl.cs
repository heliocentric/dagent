using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace dagent_net_lib
{
    public class AgentControl
    {
        public Thread thread;
        public void Init(Boolean autostart)
        {
            Agent agent = new Agent();
            agent.Init();
            this.thread = new Thread(new ThreadStart(agent.Run));
            if (autostart == true)
            {
                this.thread.Start();
            }
        }

    }
}
