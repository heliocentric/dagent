using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dagent_net_lib
{
    public class MessageBroker
    {
        public MessageBrokerChannel NewChannel()
        {
            return new MessageBrokerChannel();
        }
    }
}
