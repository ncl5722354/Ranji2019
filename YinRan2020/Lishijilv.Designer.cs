namespace YinRan2020
{
    partial class Lishijilv
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.label_title = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel_chart = new System.Windows.Forms.Panel();
            this.panel_caozuo = new System.Windows.Forms.Panel();
            this.button_next1hour = new System.Windows.Forms.Button();
            this.button_next5min = new System.Windows.Forms.Button();
            this.button_now = new System.Windows.Forms.Button();
            this.button_qian5min = new System.Windows.Forms.Button();
            this.button_qian1hour = new System.Windows.Forms.Button();
            this.dateTimePicker_search = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel_chart.SuspendLayout();
            this.panel_caozuo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.BackColor = System.Drawing.Color.Cyan;
            this.label_title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_title.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_title.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_title.Location = new System.Drawing.Point(473, 31);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(327, 64);
            this.label_title.TabIndex = 0;
            this.label_title.Text = "历史记录";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.SkyBlue;
            this.chart1.BackSecondaryColor = System.Drawing.Color.White;
            this.chart1.BorderlineColor = System.Drawing.Color.Black;
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart1.BorderlineWidth = 4;
            this.chart1.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart1.BorderSkin.BorderWidth = 2;
            this.chart1.BorderSkin.PageColor = System.Drawing.Color.Gray;
            chartArea1.AxisX.LabelStyle.Format = "yyyy-MM-dd HH:mm:ss";
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(4, 3);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "温度";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1174, 247);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "所选择的曲线";
            this.chart1.Titles.Add(title1);
            // 
            // panel_chart
            // 
            this.panel_chart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_chart.Controls.Add(this.chart1);
            this.panel_chart.Location = new System.Drawing.Point(32, 110);
            this.panel_chart.Name = "panel_chart";
            this.panel_chart.Size = new System.Drawing.Size(1180, 253);
            this.panel_chart.TabIndex = 2;
            // 
            // panel_caozuo
            // 
            this.panel_caozuo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_caozuo.Controls.Add(this.dateTimePicker_search);
            this.panel_caozuo.Controls.Add(this.button_next1hour);
            this.panel_caozuo.Controls.Add(this.button_next5min);
            this.panel_caozuo.Controls.Add(this.button_now);
            this.panel_caozuo.Controls.Add(this.button_qian5min);
            this.panel_caozuo.Controls.Add(this.button_qian1hour);
            this.panel_caozuo.Location = new System.Drawing.Point(32, 370);
            this.panel_caozuo.Name = "panel_caozuo";
            this.panel_caozuo.Size = new System.Drawing.Size(1180, 52);
            this.panel_caozuo.TabIndex = 3;
            // 
            // button_next1hour
            // 
            this.button_next1hour.BackgroundImage = global::YinRan2020.Properties.Resources.control_fastforward_net;
            this.button_next1hour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_next1hour.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_next1hour.Location = new System.Drawing.Point(468, 3);
            this.button_next1hour.Name = "button_next1hour";
            this.button_next1hour.Size = new System.Drawing.Size(110, 42);
            this.button_next1hour.TabIndex = 5;
            this.button_next1hour.UseVisualStyleBackColor = true;
            // 
            // button_next5min
            // 
            this.button_next5min.BackgroundImage = global::YinRan2020.Properties.Resources.navigate_next;
            this.button_next5min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_next5min.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_next5min.Location = new System.Drawing.Point(352, 3);
            this.button_next5min.Name = "button_next5min";
            this.button_next5min.Size = new System.Drawing.Size(110, 42);
            this.button_next5min.TabIndex = 4;
            this.button_next5min.UseVisualStyleBackColor = true;
            // 
            // button_now
            // 
            this.button_now.BackgroundImage = global::YinRan2020.Properties.Resources.control_stop;
            this.button_now.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_now.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_now.Location = new System.Drawing.Point(236, 3);
            this.button_now.Name = "button_now";
            this.button_now.Size = new System.Drawing.Size(110, 42);
            this.button_now.TabIndex = 4;
            this.button_now.UseVisualStyleBackColor = true;
            // 
            // button_qian5min
            // 
            this.button_qian5min.BackgroundImage = global::YinRan2020.Properties.Resources.navigate_previous;
            this.button_qian5min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_qian5min.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_qian5min.Location = new System.Drawing.Point(120, 3);
            this.button_qian5min.Name = "button_qian5min";
            this.button_qian5min.Size = new System.Drawing.Size(110, 42);
            this.button_qian5min.TabIndex = 1;
            this.button_qian5min.UseVisualStyleBackColor = true;
            // 
            // button_qian1hour
            // 
            this.button_qian1hour.BackgroundImage = global::YinRan2020.Properties.Resources.control_rewind;
            this.button_qian1hour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_qian1hour.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_qian1hour.Location = new System.Drawing.Point(4, 3);
            this.button_qian1hour.Name = "button_qian1hour";
            this.button_qian1hour.Size = new System.Drawing.Size(110, 42);
            this.button_qian1hour.TabIndex = 0;
            this.button_qian1hour.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker_search
            // 
            this.dateTimePicker_search.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_search.Location = new System.Drawing.Point(625, 3);
            this.dateTimePicker_search.Name = "dateTimePicker_search";
            this.dateTimePicker_search.Size = new System.Drawing.Size(317, 34);
            this.dateTimePicker_search.TabIndex = 6;
            // 
            // Lishijilv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 589);
            this.Controls.Add(this.panel_caozuo);
            this.Controls.Add(this.panel_chart);
            this.Controls.Add(this.label_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Lishijilv";
            this.Text = "Lishijilv";
            this.Resize += new System.EventHandler(this.Lishijilv_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel_chart.ResumeLayout(false);
            this.panel_caozuo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel_chart;
        private System.Windows.Forms.Panel panel_caozuo;
        private System.Windows.Forms.Button button_qian1hour;
        private System.Windows.Forms.Button button_qian5min;
        private System.Windows.Forms.Button button_now;
        private System.Windows.Forms.Button button_next5min;
        private System.Windows.Forms.Button button_next1hour;
        private System.Windows.Forms.DateTimePicker dateTimePicker_search;
    }
}