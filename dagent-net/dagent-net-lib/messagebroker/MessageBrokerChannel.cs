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
            if (message.Type != null)
            {
                var properties = this._channel.CreateBasicProperties();
                properties.DeliveryMode = 2;
                this._channel.ExchangeDeclare(message.Type, "fanout");
                this._channel.BasicPublish(message.Type, "", properties, message.Data);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
