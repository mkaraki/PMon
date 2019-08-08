using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PMon
{
    public partial class PMonWindow : Form
    {
        private int KeepTime = 30;

        private Dictionary<string, int> Disk;

        private Dictionary<string, int> TXNIC;
        private Dictionary<string, int> RXNIC;

        private Dictionary<int, List<double>> Charts = new Dictionary<int, List<double>>();
        private Dictionary<int, Series> ChartIdPairs = new Dictionary<int, Series>();

        public PMonWindow()
        {
            InitializeComponent();

            foreach (var series in chart_main.Series)
            {
                RegisterChart(series);
            }
        }

        private void Timer_update_Tick(object sender, EventArgs e)
        {
            #region CPU

            Charts[0].Add(PC_CPU.CPUUtilization());

            Charts[1].Add(PC_CPU.CPUKernelTime());

            #endregion CPU

            #region RAM

            Charts[2].Add(PC_RAM.UsedRAM());

            #endregion RAM

            #region Drive

            foreach (string dletter in PC_DISK.Drives)
            {
                Charts[Disk[dletter]].Add(PC_DISK.GetDiskPerc(dletter));
            }

            #endregion Drive

            #region Network

            foreach (string netname in PC_NIC.NICNames)
            {
                Charts[TXNIC[netname]].Add(PC_NIC.GetTX(netname));
                Charts[RXNIC[netname]].Add(PC_NIC.GetRX(netname));
            }

            #endregion Network

            UpdateChartView();
        }

        private void UpdateChartView()
        {
            if (Charts[0].Count >= KeepTime)
                foreach (var kvp in Charts)
                {
                    kvp.Value.RemoveRange(0, Charts[kvp.Key].Count - KeepTime);
                }

            Console.WriteLine(Charts[0].Count);

            foreach (var p in ChartIdPairs)
            {
                p.Value.Points.Clear();
                for (int i = 0; i < Charts[p.Key].Count; i++)
                    p.Value.Points.AddXY(i, Charts[p.Key][i]);
            }
        }

        private async void PMonWindow_Shown(object sender, EventArgs e)
        {
            chart_main.ChartAreas[1].Axes[1].Maximum = PC_RAM.FullRam;

            await Task.Run(() => PC_DISK.Init());
            Disk = new Dictionary<string, int>();
            foreach (string dletter in PC_DISK.Drives)
            {
                Series series = new Series
                {
                    ChartArea = "carea_disk",
                    Name = $"Disk Active Time ({dletter})",
                    ChartType = SeriesChartType.Line
                };

                Disk.Add(dletter, RegisterChart(series));
                chart_main.Series.Add(series);
            }

            await Task.Run(() => PC_NIC.Init());
            TXNIC = new Dictionary<string, int>();
            RXNIC = new Dictionary<string, int>();
            foreach (string netn in PC_NIC.NICNames)
            {
                Series txs = new Series
                {
                    ChartArea = "carea_net",
                    Name = $"TX {netn}",
                    ChartType = SeriesChartType.Line
                };

                TXNIC.Add(netn, RegisterChart(txs));

                Series rxs = new Series
                {
                    ChartArea = "carea_net",
                    Name = $"RX {netn}",
                    ChartType = SeriesChartType.Line
                };

                RXNIC.Add(netn, RegisterChart(rxs));

                chart_main.Series.Add(txs);
                chart_main.Series.Add(rxs);
            }

            timer_update.Enabled = true;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer_update.Interval = (int)numud_updatems.Value;
        }

        private void Numud_keeptime_ValueChanged(object sender, EventArgs e)
        {
            KeepTime = (int)numud_keeptime.Value;
        }

        private void Btn_reinit_Click(object sender, EventArgs e)
        {
            PMonWindow_Shown(null, null);
        }

        private void Chart_main_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            flowlp_cmain.Visible = !flowlp_cmain.Visible;
            FormBorderStyle = flowlp_cmain.Visible ? FormBorderStyle.FixedSingle : FormBorderStyle.None;
        }

        private int RegisterChart(Series series)
        {
            int newid = Charts.Count;

            Charts.Add(newid, new List<double>());
            ChartIdPairs.Add(newid, series);

            return newid;
        }
    }
}