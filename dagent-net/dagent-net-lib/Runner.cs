using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

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
            MessageBox.Show("Starting");
        }

        public void Stop()
        {
            MessageBox.Show("Stopping");
        }
        public void Pause()
        {
            
            MessageBox.Show("Pausing");
        }
        public void Resume()
        {
            MessageBox.Show("Resuming");
        }
        public void ForceSync() {
            MessageBox.Show("Syncing");
        }


    }
}
