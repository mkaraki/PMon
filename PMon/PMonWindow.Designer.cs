namespace PMon
{
    partial class PMonWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart_main = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer_update = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart_main)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_main
            // 
            this.chart_main.BackColor = System.Drawing.Color.Transparent;
            chartArea9.AxisX.MaximumAutoSize = 0F;
            chartArea9.AxisY.Maximum = 100D;
            chartArea9.AxisY.Minimum = 0D;
            chartArea9.AxisY.Title = "%";
            chartArea9.BackColor = System.Drawing.Color.Transparent;
            chartArea9.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Top;
            chartArea9.Name = "carea_cpu";
            chartArea10.AxisX.MaximumAutoSize = 0F;
            chartArea10.AxisY.Minimum = 0D;
            chartArea10.AxisY.Title = "MB";
            chartArea10.AxisY2.Maximum = 100D;
            chartArea10.AxisY2.Minimum = 0D;
            chartArea10.BackColor = System.Drawing.Color.Transparent;
            chartArea10.Name = "carea_ram";
            chartArea11.AxisX.MaximumAutoSize = 0F;
            chartArea11.AxisY.Maximum = 100D;
            chartArea11.AxisY.Minimum = 0D;
            chartArea11.AxisY.Title = "%";
            chartArea11.BackColor = System.Drawing.Color.Transparent;
            chartArea11.Name = "carea_disk";
            chartArea12.AxisX.MaximumAutoSize = 0F;
            chartArea12.AxisY.Title = "Kbyte/s";
            chartArea12.BackColor = System.Drawing.Color.Transparent;
            chartArea12.Name = "carea_net";
            this.chart_main.ChartAreas.Add(chartArea9);
            this.chart_main.ChartAreas.Add(chartArea10);
            this.chart_main.ChartAreas.Add(chartArea11);
            this.chart_main.ChartAreas.Add(chartArea12);
            this.chart_main.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chart_main.Legends.Add(legend3);
            this.chart_main.Location = new System.Drawing.Point(0, 0);
            this.chart_main.Name = "chart_main";
            this.chart_main.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series7.ChartArea = "carea_cpu";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Color = System.Drawing.Color.Red;
            series7.Legend = "Legend1";
            series7.Name = "CPU Time (%)";
            series8.ChartArea = "carea_cpu";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Color = System.Drawing.Color.Blue;
            series8.Legend = "Legend1";
            series8.Name = "CPU Kernel Time (%)";
            series9.ChartArea = "carea_ram";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Color = System.Drawing.Color.Red;
            series9.Legend = "Legend1";
            series9.Name = "RAM Used (MB)";
            this.chart_main.Series.Add(series7);
            this.chart_main.Series.Add(series8);
            this.chart_main.Series.Add(series9);
            this.chart_main.Size = new System.Drawing.Size(671, 249);
            this.chart_main.TabIndex = 0;
            this.chart_main.Text = "chart1";
            // 
            // timer_update
            // 
            this.timer_update.Interval = 1000;
            this.timer_update.Tick += new System.EventHandler(this.Timer_update_Tick);
            // 
            // PMonWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(671, 249);
            this.Controls.Add(this.chart_main);
            this.Name = "PMonWindow";
            this.Opacity = 0.9D;
            this.Text = "PMon";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.PMonWindow_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.chart_main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_main;
        private System.Windows.Forms.Timer timer_update;
    }
}

