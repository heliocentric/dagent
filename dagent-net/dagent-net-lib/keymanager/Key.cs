using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dagent_net_lib
{
    public class Key
    {
        public Key(String ID)
        {
            this._id = ID;
        }
        private String _id;
        public String ID
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
        public override string ToString()
        {
            return this.ID;
        }
    }
}
