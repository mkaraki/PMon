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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart_main = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer_update = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.numud_updatems = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numud_keeptime = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.chart_main)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numud_updatems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numud_keeptime)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_main
            // 
            this.chart_main.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.MaximumAutoSize = 0F;
            chartArea1.AxisY.Maximum = 100D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.Title = "%";
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Top;
            chartArea1.Name = "carea_cpu";
            chartArea2.AxisX.MaximumAutoSize = 0F;
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.AxisY.Title = "MB";
            chartArea2.AxisY2.Maximum = 100D;
            chartArea2.AxisY2.Minimum = 0D;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "carea_ram";
            chartArea3.AxisX.MaximumAutoSize = 0F;
            chartArea3.AxisY.Maximum = 100D;
            chartArea3.AxisY.Minimum = 0D;
            chartArea3.AxisY.Title = "%";
            chartArea3.BackColor = System.Drawing.Color.Transparent;
            chartArea3.Name = "carea_disk";
            chartArea4.AxisX.MaximumAutoSize = 0F;
            chartArea4.AxisY.Title = "Kbyte/s";
            chartArea4.BackColor = System.Drawing.Color.Transparent;
            chartArea4.Name = "carea_net";
            this.chart_main.ChartAreas.Add(chartArea1);
            this.chart_main.ChartAreas.Add(chartArea2);
            this.chart_main.ChartAreas.Add(chartArea3);
            this.chart_main.ChartAreas.Add(chartArea4);
            this.chart_main.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart_main.Legends.Add(legend1);
            this.chart_main.Location = new System.Drawing.Point(3, 33);
            this.chart_main.Name = "chart_main";
            this.chart_main.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "carea_cpu";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "CPU Time (%)";
            series2.ChartArea = "carea_cpu";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Blue;
            series2.Legend = "Legend1";
            series2.Name = "CPU Kernel Time (%)";
            series3.ChartArea = "carea_ram";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Red;
            series3.Legend = "Legend1";
            series3.Name = "RAM Used (MB)";
            this.chart_main.Series.Add(series1);
            this.chart_main.Series.Add(series2);
            this.chart_main.Series.Add(series3);
            this.chart_main.Size = new System.Drawing.Size(812, 281);
            this.chart_main.TabIndex = 0;
            this.chart_main.Text = "chart1";
            // 
            // timer_update
            // 
            this.timer_update.Interval = 1000;
            this.timer_update.Tick += new System.EventHandler(this.Timer_update_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.chart_main, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(818, 317);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.numud_updatems);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.numud_keeptime);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(812, 24);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Update Interval (ms)";
            // 
            // numud_updatems
            // 
            this.numud_updatems.Location = new System.Drawing.Point(111, 3);
            this.numud_updatems.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numud_updatems.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numud_updatems.Name = "numud_updatems";
            this.numud_updatems.Size = new System.Drawing.Size(120, 20);
            this.numud_updatems.TabIndex = 1;
            this.numud_updatems.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numud_updatems.ValueChanged += new System.EventHandler(this.NumericUpDown1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Keep Time";
            // 
            // numud_keeptime
            // 
            this.numud_keeptime.Location = new System.Drawing.Point(301, 3);
            this.numud_keeptime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numud_keeptime.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numud_keeptime.Name = "numud_keeptime";
            this.numud_keeptime.Size = new System.Drawing.Size(120, 20);
            this.numud_keeptime.TabIndex = 3;
            this.numud_keeptime.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numud_keeptime.ValueChanged += new System.EventHandler(this.Numud_keeptime_ValueChanged);
            // 
            // PMonWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(818, 317);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PMonWindow";
            this.Opacity = 0.9D;
            this.Text = "PMon";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.PMonWindow_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.chart_main)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numud_updatems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numud_keeptime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_main;
        private System.Windows.Forms.Timer timer_update;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numud_updatems;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numud_keeptime;
    }
}

