using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PMon
{
    public partial class PMonWindow : Form
    {
        private ulong CurrentTime = 0;

        private Dictionary<string, Series> Disk;

        private Dictionary<string, Series> TXNIC;
        private Dictionary<string, Series> RXNIC;

        public PMonWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart_main.ChartAreas[1].Axes[1].Maximum = PC_RAM.FullRam;


            Disk = new Dictionary<string, Series>();
            foreach (string dletter in PC_DISK.Drives)
            {
                Series series = new Series();

                series.ChartArea = "carea_disk";
                series.Name = $"Disk Active Time ({dletter})";
                series.ChartType = SeriesChartType.Line;

                chart_main.Series.Add(series);
                Disk.Add(dletter, series);
            }
            PC_DISK.Init();

            PC_NIC.Init();
            TXNIC = new Dictionary<string, Series>();
            RXNIC = new Dictionary<string, Series>();
            foreach (string netn in PC_NIC.NICNames)
            {
                Series txs = new Series
                {
                    ChartArea = "carea_net",
                    Name = $"TX {netn}",
                    ChartType = SeriesChartType.Line
                };

                TXNIC.Add(netn, txs);

                Series rxs = new Series
                {
                    ChartArea = "carea_net",
                    Name = $"RX {netn}",
                    ChartType = SeriesChartType.Line
                };

                chart_main.Series.Add(txs);
                chart_main.Series.Add(rxs);

                RXNIC.Add(netn, rxs);
            }
        }

        private float CurrentTimeData()
        {
            float current_time = CurrentTime * (1 - (timer_update.Interval / (float)1000));

            return current_time;
        }

        private void Timer_update_Tick(object sender, EventArgs e)
        {
            CurrentTime++;

            float tdata = CurrentTimeData();

            #region CPU

            chart_main.Series[0].Points.AddXY(tdata, PC_CPU.CPUUtilization());

            chart_main.Series[1].Points.AddXY(tdata, PC_CPU.CPUKernelTime());

            #endregion CPU

            #region RAM

            chart_main.Series[2].Points.AddXY(tdata, PC_RAM.UsedRAM());
            
            #endregion RAM

            #region Drive

            foreach (string dletter in PC_DISK.Drives)
            {
                Disk[dletter].Points.AddXY(tdata, PC_DISK.GetDiskPerc(dletter));
            }

            #endregion Drive

            #region Network

            foreach (string netname in PC_NIC.NICNames)
            {
                TXNIC[netname].Points.AddXY(tdata, (int)(PC_NIC.GetTX(netname) / 1024));
                RXNIC[netname].Points.AddXY(tdata, (int)(PC_NIC.GetRX(netname) / 1024));
            }

            #endregion Network
        }
    }
}
