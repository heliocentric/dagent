using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client;
using System.Net;
using Heijden.DNS;

namespace dagent_net_lib.messagebroker
{
    public class MessageBroker
    {
        public MessageBroker() : this("127.0.0.1","guest","guest",5672,System.Guid.NewGuid().ToString(),"/", "")
        {
        }
        public MessageBroker(String hostname, String username, String password, int port, string UUID, string Vhost, string Rootkey)
        {
            this.Hostname = hostname;
            this.Username = username;
            this.Password = password;
            this.Port = port;
            this.UUID = UUID;
            this.Vhost = Vhost;
            this.RootKey = Rootkey;
            this.Init();
        }
        public String Vhost;
        public String Hostname;
        public String Password;
        public String Username;
        public String UUID;
        public String RootKey;
        public int Port;
        public MessageBrokerChannel NewChannel()
        {
            MessageBrokerChannel channel = new MessageBrokerChannel(this._connection.CreateModel());
            return channel;
        }

        private IConnection _connection;
        public Boolean Init()
        {

            this.Hostname = Util.checkregstring("HKLM", @"SOFTWARE\dagent\messagebroker", "hostname", this.Hostname);
            this.Password = Util.checkregstring("HKLM", @"SOFTWARE\dagent\messagebroker", "password", this.Password);
            this.Username = Util.checkregstring("HKLM", @"SOFTWARE\dagent\messagebroker", "username", this.Username);
            this.UUID = Util.checkregstring("HKLM", @"SOFTWARE\dagent\messagebroker", "uuid", this.UUID);
            this.Port = Util.checkregint("HKLM", @"SOFTWARE\dagent\messagebroker", "port", this.Port);
            this.Vhost = Util.checkregstring("HKLM", @"SOFTWARE\dagent\messagebroker", "vhost", this.Vhost);
            this.RootKey = Util.checkregstring("HKLM", @"SOFTWARE\dagent\messagebroker", "rootkey", this.RootKey);
            /* 
             * Look for TXT records defining all the possible access methods which are available.
             */
            Resolver Resolver = new Resolver();
            Response response = Resolver.Query(this.Hostname,QType.TXT,QClass.ANY);
            LinkedList<Connector> AnyConnector = new LinkedList<Connector>();
            LinkedList<Connector> MacConnector = new LinkedList<Connector>();
            LinkedList<Connector> RouterIPConnector = new LinkedList<Connector>();
            foreach (AnswerRR answerRR in response.Answers)
            {
                switch (answerRR.Type)
                {
                    case Heijden.DNS.Type.TXT:
                        String[] strippedresponse = answerRR.RECORD.ToString().Split('\"');
                        String[] value = strippedresponse[1].Split('!');
                        if (value[0].ToLower().Equals("dagent"))
                        {
                            switch (value[1].ToLower())
                            {
                                case "connector":
                                    Connector conn = new Connector(value, 2);
                                    Util.log(this.ToString(), 99, conn.ToString());
                                    switch (conn.Match)
                                    {
                                        case "any":
                                            AnyConnector.AddLast(conn);
                                            break;
                                    }
                                    break;
                                case "rootkey":
                                    break;
                            }
                        }
                        break;
                }
            }
            /*
             * Fallback method to use DNS A Records
             */
            if (this._connection == null)
            {
                IPHostEntry ipentry = Dns.GetHostEntry(this.Hostname);
                foreach (IPAddress ip in ipentry.AddressList)
                {
                    try
                    {
                        Util.log(this.ToString(), 99, "Attempting connection to " + ip.ToString() + ":" + this.Port.ToString());
                        var factory = new ConnectionFactory()
                        {
                            HostName = ip.ToString(),
                            Password = this.Password,
                            UserName = this.Username,
                            Port = this.Port,
                            VirtualHost = this.Vhost
                        };
                        this._connection = factory.CreateConnection();
                        break;
                    }
                    catch (Exception e)
                    {
                        Util.log(this.ToString(), 1, e.ToString());
                    }

                }
                if (this._connection == null)
                {
                    Util.log(this.ToString(), 0, "Unable to connect to " + this.Hostname);
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
