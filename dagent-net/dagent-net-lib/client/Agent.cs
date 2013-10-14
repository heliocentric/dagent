using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Windows.Forms;
using dagent_net_lib.messagebroker;

namespace dagent_net_lib
{
    public class Agent
    {
        public void Init()
        {
            this.Broker = new MessageBroker();
            this.random = new Random();
        }
        private MessageBroker Broker;
        private Random random;


        private Thread HostInfo;
        private MessageBrokerChannel HostInfo_Channel;
        private void HostInfo_Run()
        {
            int counter = 0;
            Boolean end = false;
            while (end != true)
            {
                TextMessage msg = new TextMessage();
                msg.Type = "dagent.presence";
                counter += 1;
                counter = counter % 15;
                msg.value = "<dagent>";
                msg.value += "<hostinfo>";
                msg.value += "<uuid>" + this.Broker.UUID + "</uuid>";
                msg.value += "<uptime>" + Util.getUptime() + "</uptime>";
                msg.value += "</hostinfo>";
                msg.value += "</dagent>";
                this.HostInfo_Channel.Send(msg);
                msg.Type = "dagent.hostinfo";
                if (counter == 1)
                {
                    msg.value = "<dagent>";
                    msg.value += "<hostinfo>";
                    msg.value += "<uuid>" + this.Broker.UUID + "</uuid>";
                    msg.value += "<uptime>" + Util.getUptime() + "</uptime>";
                    msg.value += "<user>" + Util.getUserName() + "</user>";
                    msg.value += "<hostname>" + Util.getHostName() + "</hostname>";
                    msg.value += "<installeddate>" + Util.getInstalledDate() + "</installeddate>";
                    msg.value += "<ipaddress>" + Util.getIPAddress() + "</ipaddress>";
                    msg.value += "<macaddress>" + Util.getMacAddress() + "</macaddress>";
                    msg.value += "<os>" + Util.getOperatingSystem() + "</os>";
                    msg.value += "<kernel>" + Util.getOSKernel() + "</kernel>";
                    msg.value += "<architecture>" + Util.getArchitecture() + "</architecture>";
                    msg.value += "</hostinfo>";
                    msg.value += "</dagent>";
                    this.HostInfo_Channel.Send(msg);
                    // MessageBox.Show(msg.value);
                }

                /* sleep for approximately 1 minute */
                Thread.Sleep(50000 + this.random.Next(1,30));
            }
        
        }

        private Thread KeyManagerThread;
        public MessageBrokerChannel KeyManager_Channel;
        public keymanager.Manager KeyManager;
        public void KeyManager_Run()
        {
        }
        public void Run()
        {
            this.KeyManager = new keymanager.Manager(this.Broker);
            this.HostInfo_Channel = this.Broker.NewChannel();
            this.HostInfo = new Thread(new ThreadStart(this.HostInfo_Run));
            this.HostInfo.Start();
            this.KeyManager_Channel = this.Broker.NewChannel();
            this.KeyManagerThread = new Thread(new ThreadStart(this.KeyManager_Run));
        }
    }
}