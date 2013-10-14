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
            Message msg = new Message();
            
            return msg;
        }
        public void QueueBind(String Name, String Exchange, String Key)
        {
            this._channel.ExchangeDeclare(Exchange, "fanout");
            this._channel.QueueBind(Name, Exchange, Key);
        }
        public MessageQueue QueueDeclare()
        {
            return new MessageQueue(this, this._channel.QueueDeclare());
        }
        public MessageQueue QueueDeclare(String Name)
        {
            return new MessageQueue(this, this._channel.QueueDeclare(Name,false,false,false,null));
        }
        public MessageQueue QueueDeclare(String Name, Boolean Durable)
        {
            return new MessageQueue(this, this._channel.QueueDeclare(Name, Durable, false, false, null));
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
