using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dagent_net_lib.messagebroker
{
    public class TextMessage : IMessage
    {
        #region IMessage Members

        public byte[] Data
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

        public string From
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


        #region IMessage Members
        private string _type;
        public string Type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }

        #endregion
    }
}
