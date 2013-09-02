using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dagent_net_lib
{
    public class MessageBroker
    {
        public MessageBroker()
        {
        }
        private String Hostname;
        private String Username;
        private String Password;
        private int Port;
        private String UUID;
        public MessageBrokerChannel NewChannel()
        {
            return new MessageBrokerChannel();
        }
    }
}
