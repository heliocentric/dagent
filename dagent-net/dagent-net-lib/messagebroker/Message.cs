using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dagent_net_lib.messagebroker
{
    public class Message : IMessage
    {
        public string From
        {
            get
            {
                return "";
            }
            set
            {
            }
        }
        public Byte[] Data
        {
            get
            {
                return new Byte[1];
            }
            set
            {
            }
        }
    }
}
