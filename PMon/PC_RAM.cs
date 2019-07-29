using System.Diagnostics;
using Microsoft.VisualBasic.Devices;

namespace PMon
{
    internal class PC_RAM
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
            ComputerInfo info = new ComputerInfo();

            return info.TotalPhysicalMemory / 1024 / 1024;
        }
    }
}
