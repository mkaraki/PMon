using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMon
{
    class PC_CPU
    {
        private static PerformanceCounter PC_Utilization = new PerformanceCounter("Processor Information", "% Processor Utility", "_Total");
        private static PerformanceCounter PC_KernelTime = new PerformanceCounter("Processor Information", "% Privileged Utility", "_Total");

        public static float CPUUtilization()
        {
            return PC_Utilization.NextValue();
        }

        public static float CPUKernelTime()
        {
            return PC_KernelTime.NextValue();
        }
    }
}
