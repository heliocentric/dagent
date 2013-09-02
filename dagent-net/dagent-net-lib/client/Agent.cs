using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Windows.Forms;

namespace dagent_net_lib
{
    public class Agent
    {
        public String Hostname = "127.0.0.1";
        public String Password = "guest";
        public String Username = "guest";
        public String UUID = System.Guid.NewGuid().ToString();
        public int Port = 5672;
        public void Init()
        {
            this.Hostname = Util.checkregstring("HKLM",@"SOFTWARE\dagent\messagebroker", "hostname", this.Hostname);
            this.Password = Util.checkregstring("HKLM", @"SOFTWARE\dagent\messagebroker", "password", this.Password);
            this.Username = Util.checkregstring("HKLM", @"SOFTWARE\dagent\messagebroker", "username", this.Username);
            this.UUID = Util.checkregstring("HKLM", @"SOFTWARE\dagent\messagebroker", "uuid", this.UUID);
            this.Port = Util.checkregint("HKLM", @"SOFTWARE\dagent\messagebroker", "port", this.Port);
        }
        private Thread MQWorker;
        private IModel MQWorker_Channel;

        private void MQWorker_Run()
        {
           
            this.MQWorker_Channel.ExchangeDeclare("dagent.online","fanout");
            var presencequeue = this.MQWorker_Channel.QueueDeclare();
            this.MQWorker_Channel.QueueBind(presencequeue,"dagent.online",this.UUID);
            var consumer = new QueueingBasicConsumer(this.MQWorker_Channel);
            this.MQWorker_Channel.BasicConsume(presencequeue, true, consumer);
            
            while (true)
            {
                /*
                var ea = (BasicDeliverEventArgs) consumer.Queue.Dequeue();
                 */
                /*
                 * Throw away everything we receive for the time being.
                 */
                Thread.Sleep(1000);
            }
        }

        public void Run()
        {
            var factory = new ConnectionFactory() {
                HostName = this.Hostname,
                Password = this.Password,
                UserName = this.Username,
                Port = this.Port
            };
            using (var connection = factory.CreateConnection())
            {
                this.MQWorker_Channel = connection.CreateModel();
                this.MQWorker = new Thread(new ThreadStart(this.MQWorker_Run));
                this.MQWorker.Start();
                using (var channel = connection.CreateModel())
                {
                    Boolean end = false;
                    int counter = 0;
                    channel.ExchangeDeclare("dagent.hostinfo", "fanout");
                    channel.ExchangeDeclare("dagent.online", "fanout");
                    while (end != true)
                    {
                        counter += 1;
                        counter = counter % 15;
                        var message = "<dagent>";
                        message += "<hostinfo>";
                        message += "<uuid>" + this.UUID + "</uuid>";
                        message += "<uptime>" + Util.getUptime() + "</uptime>";
                        message += "</hostinfo>";
                        message += "</dagent>";
                        var body = Encoding.UTF8.GetBytes(message);
                        channel.BasicPublish("dagent.online", "", null, body);
                        if (counter == 1)
                        {
                            message = "<dagent>";
                            message += "<hostinfo>";
                            message += "<uuid>" + this.UUID + "</uuid>";
                            message += "<uptime>" + Util.getUptime() + "</uptime>";
                            message += "<user>" + Util.getUserName() + "</user>";
                            message += "<hostname>" + Util.getHostName() + "</hostname>";
                            message += "<installeddate>" + Util.getInstalledDate() + "</installeddate>";
                            message += "<ipaddress>" + Util.getIPAddress() + "</ipaddress>";
                            message += "<macaddress>" + Util.getMacAddress() + "</macaddress>";
                            message += "<os>" + Util.getOperatingSystem() + "</os>";
                            message += "<kernel>" + Util.getOSKernel() + "</kernel>";
                            message += "<architecture>" + Util.getArchitecture() + "</architecture>";
                            message += "</hostinfo>";
                            message += "</dagent>";
                            MessageBox.Show(message);
                            body = Encoding.UTF8.GetBytes(message);
                            channel.BasicPublish("dagent.hostinfo", "", null, body);
                        }

                        /* sleep for approximately 1 minute */
                        Thread.Sleep(60000);
                    }
                }
            }
        }
    }
}
