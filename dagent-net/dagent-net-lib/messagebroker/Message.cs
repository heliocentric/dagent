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

        #region IMessage Members

        string IMessage.Type
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IMessage.From
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        byte[] IMessage.Data
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
