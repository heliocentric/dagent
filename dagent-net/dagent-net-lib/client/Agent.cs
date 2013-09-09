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
        }
        private Thread MQWorker;
        private IModel MQWorker_Channel;
        private MessageBroker Broker;
        private void MQWorker_Run()
        {
        }

        public void Run()
        {
            MessageBrokerChannel channel = this.Broker.NewChannel();
            int counter = 0;
            Boolean end = false;
            while (end != true)
            {
                TextMessage msg = new TextMessage();
                counter += 1;
                counter = counter % 15;
                msg.value = "<dagent>";
                msg.value += "<hostinfo>";
                msg.value += "<uuid>" + this.Broker.UUID + "</uuid>";
                msg.value += "<uptime>" + Util.getUptime() + "</uptime>";
                msg.value += "</hostinfo>";
                msg.value += "</dagent>";

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
                    MessageBox.Show(msg.value);
                }

                /* sleep for approximately 1 minute */
                Thread.Sleep(60000);
            }
        }
    }
}