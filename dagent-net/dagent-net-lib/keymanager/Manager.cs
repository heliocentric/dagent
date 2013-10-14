using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;
using Emmanuel.Cryptography.GnuPG;

namespace dagent_net_lib.keymanager
{
    public class Manager
    {
        public messagebroker.MessageBroker broker;
        public String secretkeyring;
        public String publickeyring;
        public Manager(messagebroker.MessageBroker Broker)
        {
            Util.log(this.ToString(), 99, "Run Path: " + Util.getApplicationPath());
            this.Constructor(Broker);
        }
        public void Constructor(messagebroker.MessageBroker Broker)
        {
            this.broker = Broker;
            this.FindGnuPG("");
            this.gpg = new GnuPGWrapper(this.gpgpath);
            this.gpghomepath = Util.getApplicationPath() + Path.DirectorySeparatorChar + "gnupg";
            this.gpg.homedirectory = this.gpghomepath;
            if (!Directory.Exists(this.gpghomepath)) {
                Directory.CreateDirectory(this.gpghomepath.Replace("file:\\", ""));
            }
            // Find key id for UUID@Hostname
            this.gpg.command = Commands.FindKey;
            this.gpg.arguments = this.broker.UUID + "@" + this.broker.Hostname;
            // If keyid == null
            //   then
            //     fetch keyid from pgp.mit.edu
            //     if keyid == null
            //       then
            //         generate host key
            // Save keyid for later
            // Download any new information for keyid from pgp.mit.edu
            // Send keyid to pgp.mit.edu (if anything needs to be sent)
            // Use keyid to sign messages from now on.
            // 
        }
        private String gpgpath;
        private String gpghomepath;
        private GnuPGWrapper gpg;
        public void FindGnuPG(String HintPath)
        {
            List<String> paths = new List<string>();
            paths.Add(HintPath);
            paths.Add(Util.getApplicationPath() + Path.DirectorySeparatorChar + "gnupg");
            paths.Add(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles) + Path.DirectorySeparatorChar + "GNU" + Path.DirectorySeparatorChar + "GnuPG");
            paths.Add(@"C:\Program Files\GNU\GnuPG");
            String gnupgpath = "";
            foreach (String path in paths)
            {
                String gpgexepath = path + Path.DirectorySeparatorChar + "gpg2.exe";
                if (File.Exists(gpgexepath))
                {
                    gnupgpath = path;
                    break;
                }
            }
            this.gpgpath = gnupgpath;
            Util.log(this.ToString(), 99, "Path to gpg.exe: " + this.gpgpath);
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
