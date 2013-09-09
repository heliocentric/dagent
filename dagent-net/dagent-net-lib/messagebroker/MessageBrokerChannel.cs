using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client;

namespace dagent_net_lib.messagebroker
{
    public class MessageBrokerChannel
    {

        public MessageBrokerChannel(IModel channel)
        {
            this._channel = channel;
        }
        private IModel _channel;

        public IMessage Receive()
        {
            return new messagebroker.Message();
        }
        public Boolean Send(IMessage message)
        {
            return false;
        }
    }
}
