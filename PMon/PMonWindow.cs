using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PMon
{
    public partial class PMonWindow : Form
    {
        private ulong CurrentTime = 0;
        private int KeepTime = 30;

        private Dictionary<string, Series> Disk;

        private Dictionary<string, Series> TXNIC;
        private Dictionary<string, Series> RXNIC;

        public PMonWindow()
        {
            InitializeComponent();
        }

        private double CurrentTimeData()
        {
            return CurrentTime;
        }

        private void Timer_update_Tick(object sender, EventArgs e)
        {
            CurrentTime++;

            double tdata = CurrentTimeData();

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
                TXNIC[netname].Points.AddXY(tdata, PC_NIC.GetTX(netname));
                RXNIC[netname].Points.AddXY(tdata, PC_NIC.GetRX(netname));
            }

            #endregion Network

            if (tdata >= KeepTime)
            {
                for (var i = 0; i < chart_main.ChartAreas.Count; i++)
                {
                    chart_main.ChartAreas[i].AxisX.ScaleView.Zoom(tdata - KeepTime, tdata);
                }
            }
        }

        private async void PMonWindow_Shown(object sender, EventArgs e)
        {
            chart_main.ChartAreas[1].Axes[1].Maximum = PC_RAM.FullRam;

            await Task.Run(() => PC_DISK.Init());
            Disk = new Dictionary<string, Series>();
            foreach (string dletter in PC_DISK.Drives)
            {
                Series series = new Series
                {
                    ChartArea = "carea_disk",
                    Name = $"Disk Active Time ({dletter})",
                    ChartType = SeriesChartType.Line
                };

                Disk.Add(dletter, series);
                chart_main.Series.Add(series);
            }

            await Task.Run(() => PC_NIC.Init());
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

                RXNIC.Add(netn, rxs);

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
            FormBorderStyle = flowlp_cmain.Visible? FormBorderStyle.FixedSingle : FormBorderStyle.None;
        }
    }
}