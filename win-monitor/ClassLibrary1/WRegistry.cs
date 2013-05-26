using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace winmonitorlib
{
    public class WRegistry
    {
        public String keypath = "SOFTWARE\\onsite\\winmonitor";
        public RegistryKey regroot;
        public WRegistry()
        {
            RegistryKey rootkey;
            rootkey = Registry.CurrentUser;
            rootkey.CreateSubKey(this.keypath);
            this.regroot = rootkey.OpenSubKey(this.keypath,true);
        }
        public string URL
        {
            get
            {
                return getRegKey("URL");
            }
            set
            {
                this.setRegKey("URL", value);
            }
        }
        public string APIKey
        {
            get
            {
                return getRegKey("APIKey");
            }
            set
            {
                this.setRegKey("APIKey", value);
            }
        }
        public string ComputerID
        {
            get
            {
                return getRegKey("ComputerID");
            }
            set
            {
                this.setRegKey("ComputerID", value);
            }
        }
        public string CompanyID
        {
            get
            {
                return getRegKey("CompanyID");
            }
            set
            {
                this.setRegKey("CompanyID",value);
            }
        }
        private void setRegKey(String name, String Value)
        {
            this.regroot.SetValue(name, Value);
        }
        private String getRegKey(String name)
        {
            return (String) this.regroot.GetValue(name);
        }
    }
}
