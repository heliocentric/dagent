using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dagent_net_lib.messagebroker
{
    public class Message : IMessage
    {
        private string _from;
        public string From
        {
            get
            {
                return this._from;
            }
            set
            {
                this._from = value;
            }
        }
        private Byte[] _data;
        public Byte[] Data
        {
            get
            {
                return this._data;
            }
            set
            {
                this._data = value;
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
