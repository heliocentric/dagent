﻿using System;
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
        public String secretkeyring;
        public String publickeyring;
        public Manager(String UUID)
        {
            Util.log(this.ToString(), 99, "Run Path: " + Util.getApplicationPath());
            this.Constructor(UUID);
        }
        public void Constructor(String UUID)
        {
            this.FindGnuPG("");
            this.gpg = new GnuPGWrapper(this.gpgpath);
            this.gpghomepath = Util.getApplicationPath() + Path.DirectorySeparatorChar + "gnupg";
            this.gpg.homedirectory = this.gpghomepath;
            if (!Directory.Exists(this.gpghomepath)) {
                Directory.CreateDirectory(this.gpghomepath.Replace("file:\\", ""));
            }
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
