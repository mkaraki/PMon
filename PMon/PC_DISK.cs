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
        public static List<string> Drives;

        private static Dictionary<string, PerformanceCounter> DiskTimePCs;

        public static void Init()
        {
            DiskTimePCs = new Dictionary<string, PerformanceCounter>();

            var pcc = new PerformanceCounterCategory("PhysicalDisk");

            Drives = new List<string>();

            foreach (var drv in pcc.GetInstanceNames())
            {
                if (drv == "_Total") return;

                Drives.Add(drv);

                DiskTimePCs.Add(
                    drv,
                    new PerformanceCounter("PhysicalDisk", "% Disk Time", drv)
                    );
            }
        }

        public static float GetDiskPerc(string drv)
        {
            return DiskTimePCs[drv].NextValue();
        }
    }
}
