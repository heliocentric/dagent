using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dagent_net_lib.messagebroker
{
    public class TextMessage : IMessage
    {
        #region IMessage Members

        byte[] IMessage.Data
        {
            get
            {
                return Encoding.UTF8.GetBytes(this._val);
            }
            set
            {
                this._val = Encoding.UTF8.GetString(value) ;
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

        #endregion
        private string _val;
        public string value
        {
            get
            {
                return _val;
            }
            set
            {
                _val = value;
            }
        }

    }
}
