using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PMon
{
    class PC_DISK
    {
        public static string[] Drives = System.IO.Directory.GetLogicalDrives();

        private static Dictionary<string, PerformanceCounter> DiskTimePCs;

        public static void Init()
        {
            DiskTimePCs = new Dictionary<string, PerformanceCounter>();


            foreach (var drv in Drives)
            {

                string instance = "0 " + drv.TrimEnd('\\');

                DiskTimePCs.Add(
                    drv,
                    new PerformanceCounter("PhysicalDisk", "% Disk Time", instance)
                    );
            }
        }

        public static float GetDiskPerc(string drv)
        {
            return DiskTimePCs[drv].NextValue();
        }
    }
}
