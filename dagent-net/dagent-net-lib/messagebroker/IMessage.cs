using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dagent_net_lib.messagebroker
{
    public interface IMessage
    {
        string Type
        {
            get;
            set;
        }
        string From
        {
            get;
            set;
        }
        Byte[] Data
        {
            get;
            set;
        }
    }
}
