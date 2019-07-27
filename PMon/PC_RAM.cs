using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PMon
{
    class PC_RAM
    {
        private static PerformanceCounter PC_ARAM = new PerformanceCounter("Memory", "Available MBytes", string.Empty);

        public static ulong FullRam = GetFullRAM();

        public static float ARAM()
        {
            return PC_ARAM.NextValue();
        }

        public static float UsedRAM()
        {
            return FullRam - ARAM();
        }

        public static ulong GetFullRAM()
        {
            Microsoft.VisualBasic.Devices.ComputerInfo info = new Microsoft.VisualBasic.Devices.ComputerInfo();

            return info.TotalPhysicalMemory / 1024 / 1024;
        }
    }
}
