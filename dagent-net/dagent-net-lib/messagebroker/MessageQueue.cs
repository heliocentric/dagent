using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ;
using RabbitMQ.Client;

namespace dagent_net_lib.messagebroker
{
    public class MessageQueue
    {
        String _name;
        MessageBrokerChannel _channel;
        public MessageQueue(MessageBrokerChannel channel, String queuename)
        {
            this._name = queuename;
            this._channel = channel;
        }
    }
}
