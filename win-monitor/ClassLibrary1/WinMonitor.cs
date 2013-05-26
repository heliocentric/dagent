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
        private WRegistry registry = new WRegistry();
        private WebClient client;
        public void Start()
        {
            String URI = registry.URL + "/api.php";
            this.client = new WebClient();
            System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
            reqparm.Add();
            byte[] responsebytes = client.UploadValues(URI, "POST", reqparm);
            string responsebody = Encoding.UTF8.GetString(responsebytes);
        }
        public void Stop()
        {
        }
    }
}
