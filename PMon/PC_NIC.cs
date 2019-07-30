using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;

namespace PMon
{
    class PC_NIC
    {
        private static NetworkInterface[] NICs = NetworkInterface.GetAllNetworkInterfaces();
        public static List<string> NICNames;

        private static string[] NICBlackList = {
            "Npcap Loopback Adapter",
            "Teredo Tunneling Pseudo-Interface",
        };

        private static Dictionary<string, PerformanceCounter> TXPCs;
        private static Dictionary<string, PerformanceCounter> RXPCs;

        public static void Init()
        {
            TXPCs = new Dictionary<string, PerformanceCounter>();
            RXPCs = new Dictionary<string, PerformanceCounter>();
            NICNames = new List<string>();

            var pcc = new PerformanceCounterCategory("Network Interface");

            foreach (string netname in pcc.GetInstanceNames())
            {
                bool isBlack = false;
                foreach (var bl in NICBlackList)
                {
                    if (netname.Contains(bl))
                    {
                        isBlack = true;
                        break;
                    }
                }
                if (isBlack) continue;

                TXPCs.Add(netname, new PerformanceCounter("Network Interface", "Bytes Sent/sec", netname));
                try { TXPCs[netname].NextValue(); TXPCs[netname].NextValue(); }
                catch { TXPCs.Remove(netname); continue; }
                RXPCs.Add(netname, new PerformanceCounter("Network Interface", "Bytes Received/sec", netname));
                NICNames.Add(netname);
            }
        }

        public static float GetTX(string name)
        {
            return TXPCs[name].NextValue() * 8 / 1024;
        }

        public static float GetRX(string name)
        {
            return RXPCs[name].NextValue() * 8 / 1024;
        }
    }
}
