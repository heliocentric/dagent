using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Instrumentation;
using System.Management;
using System.Diagnostics;
using Microsoft.Win32;
namespace dagent_net_lib
{
    public class Util
    {
        /*
         * These routines exist solely to abstract it into something like sqlite later
         */
        public static String checkregstring(string hive_HKLM_or_HKCU, string registryRoot, string valueName, string defaultvalue)
        {
            string keyName;
            switch (hive_HKLM_or_HKCU)
            {
                case "HKLM":
                    keyName = "HKEY_LOCAL_MACHINE\\" + registryRoot;
                    break;
                case "HKCU":
                default:
                    keyName = "HKEY_CURRENT_USER\\" + registryRoot;
                    break;
            }
            string retval = (string) Registry.GetValue(keyName, valueName, defaultvalue);
            Registry.SetValue(keyName, valueName, retval);
            return retval;
       }
        public static int checkregint(string hive_HKLM_or_HKCU, string registryRoot, string valueName, int defaultvalue)
        {
            string keyName;
            switch (hive_HKLM_or_HKCU)
            {
                case "HKLM":
                    keyName = "HKEY_LOCAL_MACHINE\\" + registryRoot;
                    break;
                case "HKCU":
                default:
                    keyName = "HKEY_CURRENT_USER\\" + registryRoot;
                    break;
            }
            int retval = (int)Registry.GetValue(keyName, valueName, defaultvalue);
            Registry.SetValue(keyName, valueName, retval);
            return retval;
        }
        public static double getUptime()
        {
                using (var uptime = new PerformanceCounter("System", "System Up Time"))
                {
                    uptime.NextValue();       //Call this an extra time before reading its value
                    return TimeSpan.FromSeconds(uptime.NextValue()).TotalSeconds;
                }
        }
        public static String getUserName()
        {

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT UserName FROM Win32_ComputerSystem");
            ManagementObjectCollection collection = searcher.Get();
            return (string)collection.Cast<ManagementBaseObject>().First()["UserName"];
        }
        public static String getHostName()
        {
            return System.Environment.MachineName;
        }
        public static String getIPAddress()
        {
            return "";
        }
        public static String getMacAddress()
        {
            return "";
        }
        public static String getInstalledDate()
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"\SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            if (key != null)
            {
                DateTime startDate = new DateTime(1970, 1, 1, 0, 0, 0);
                Int64 regVal = Convert.ToInt64(key.GetValue("InstallDate").ToString());

                DateTime installDate = startDate.AddSeconds(regVal);

                return installDate.ToString();
            }

            return "NULL";
        }
        public static String getOSKernel()
        {
            return System.Environment.OSVersion.Platform.ToString();
        }
        public static String getOSVersion()
        {
            return System.Environment.OSVersion.Version.ToString();
        }
        public static String getOSServicePack()
        {
            return System.Environment.OSVersion.ServicePack.ToString();
        }
        public static String getOperatingSystem()
        {
            return System.Environment.OSVersion.VersionString;
        }
        public static String getArchitecture()
        {
            return "";
        }
    }
}
