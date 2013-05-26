using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace winmonitorlib
{
    public class WinMonitor
    {
        private WebClient client;
        public void Start()
        {
            this.client = new WebClient();
            

        }
        public void Stop()
        {
        }
    }
}
