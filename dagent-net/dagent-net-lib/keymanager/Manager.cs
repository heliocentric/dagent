using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dagent_net_lib.keymanager
{
    public class Manager
    {
        public String secretkeyring;
        public String publickeyring;
        public Manager(String UUID)
        {
            
        }
        public KeyData Sign(KeyData data) 
        {
            return new KeyData();
        }
        public KeyData Encrypt(KeyData data)
        {
            return new KeyData();
        }
        public KeyData Decrypt(KeyData data)
        {
            return new KeyData();
        }
        public KeyData Verify(KeyData data)
        {
            return new KeyData();
        }
    }
}
