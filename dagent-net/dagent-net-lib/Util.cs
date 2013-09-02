using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Instrumentation;
using System.Management;
using System.Diagnostics;

namespace dagent_net_lib
{
    public class Util
    {
        public static String checkregstring(string hive_HKLM_or_HKCU, string registryRoot, string valueName, string defaultvalue)
        {
            return defaultvalue;
        }
        public static int checkregint(string hive_HKLM_or_HKCU, string registryRoot, string valueName, int defaultvalue)
        {
            return defaultvalue;
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
