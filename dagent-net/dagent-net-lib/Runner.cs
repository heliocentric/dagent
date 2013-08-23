using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace dagent_net_lib
{
    public class Runner
    {
        private Thread Main;
        private Agent agent;
        public void Run()
        {

        }
        public void Init(Boolean autostart)
        {
            this.agent = new Agent();
            this.Main = new Thread(new ThreadStart(this.agent.Start));

            this.Main.Start();
            if (autostart == true)
            {
                this.Start();
            }
        }
        public void Start()
        {
        }

        public void Stop()
        {
        }
        public void Pause()
        {
        }
        public void Resume()
        {
        }
        public void ForceSync()
        {
        }


    }
}
