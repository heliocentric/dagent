using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using RabbitMQ.Client;

namespace dagent_net_lib
{
    public class Agent
    {
        public String Hostname = "127.0.0.1";
        public String Password = "guest";
        public String Username = "guest";
        public String UUID = "00000000-0000-0000-0000-000000000000";
        public int Port = 5672;
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
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", true, false, false, null);

                    string message = "Hello World!";
                    var body = Encoding.UTF8.GetBytes(message);
                    var properties = channel.CreateBasicProperties();
                    properties.DeliveryMode = 2;
                    channel.BasicPublish("", "hello", properties, body);
                }
            }
 
        }
    }
}
