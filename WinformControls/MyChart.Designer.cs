namespace WinformControls
{
    partial class MyChart
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label_value1_name = new System.Windows.Forms.Label();
            this.label_value1 = new System.Windows.Forms.Label();
            this.label_value2_name = new System.Windows.Forms.Label();
            this.label_value2 = new System.Windows.Forms.Label();
            this.label_value3_name = new System.Windows.Forms.Label();
            this.label_value3 = new System.Windows.Forms.Label();
            this.label_value4_name = new System.Windows.Forms.Label();
            this.label_value4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Location = new System.Drawing.Point(30, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1139, 392);
            this.panel1.TabIndex = 0;
            // 
            // chart1
            // 
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
            chartArea1.AxisX.LabelStyle.Format = "yyyy-MM-dd HH:mm:ss";
            chartArea1.AxisX.LineWidth = 2;
            chartArea1.AxisY.LineWidth = 2;
            chartArea1.AxisY.Maximum = 200D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.CursorX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.LineWidth = 5;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series";
            series1.SmartLabelStyle.CalloutLineWidth = 5;
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "Series3";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Legend = "Legend1";
            series4.Name = "Series4";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(1129, 383);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            //this.chart1.CursorPositionChanging += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.chart1_CursorPositionChanging);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "光标位置时间";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "2018-10-09 12:23:00";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Linen;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(1175, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(184, 62);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label_value4);
            this.panel3.Controls.Add(this.label_value4_name);
            this.panel3.Controls.Add(this.label_value3);
            this.panel3.Controls.Add(this.label_value3_name);
            this.panel3.Controls.Add(this.label_value2);
            this.panel3.Controls.Add(this.label_value2_name);
            this.panel3.Controls.Add(this.label_value1);
            this.panel3.Controls.Add(this.label_value1_name);
            this.panel3.Location = new System.Drawing.Point(1175, 85);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(184, 323);
            this.panel3.TabIndex = 4;
            // 
            // label_value1_name
            // 
            this.label_value1_name.AutoSize = true;
            this.label_value1_name.Font = new System.Drawing.Font("微软雅黑", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_value1_name.Location = new System.Drawing.Point(7, 16);
            this.label_value1_name.Name = "label_value1_name";
            this.label_value1_name.Size = new System.Drawing.Size(39, 17);
            this.label_value1_name.TabIndex = 2;
            this.label_value1_name.Text = "参数1";
            // 
            // label_value1
            // 
            this.label_value1.AutoSize = true;
            this.label_value1.Font = new System.Drawing.Font("微软雅黑", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_value1.Location = new System.Drawing.Point(7, 42);
            this.label_value1.Name = "label_value1";
            this.label_value1.Size = new System.Drawing.Size(22, 17);
            this.label_value1.TabIndex = 3;
            this.label_value1.Text = "00";
            // 
            // label_value2_name
            // 
            this.label_value2_name.AutoSize = true;
            this.label_value2_name.Font = new System.Drawing.Font("微软雅黑", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_value2_name.Location = new System.Drawing.Point(7, 88);
            this.label_value2_name.Name = "label_value2_name";
            this.label_value2_name.Size = new System.Drawing.Size(39, 17);
            this.label_value2_name.TabIndex = 4;
            this.label_value2_name.Text = "参数2";
            // 
            // label_value2
            // 
            this.label_value2.AutoSize = true;
            this.label_value2.Font = new System.Drawing.Font("微软雅黑", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_value2.Location = new System.Drawing.Point(7, 114);
            this.label_value2.Name = "label_value2";
            this.label_value2.Size = new System.Drawing.Size(22, 17);
            this.label_value2.TabIndex = 5;
            this.label_value2.Text = "00";
            // 
            // label_value3_name
            // 
            this.label_value3_name.AutoSize = true;
            this.label_value3_name.Font = new System.Drawing.Font("微软雅黑", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_value3_name.Location = new System.Drawing.Point(7, 156);
            this.label_value3_name.Name = "label_value3_name";
            this.label_value3_name.Size = new System.Drawing.Size(39, 17);
            this.label_value3_name.TabIndex = 6;
            this.label_value3_name.Text = "参数3";
            // 
            // label_value3
            // 
            this.label_value3.AutoSize = true;
            this.label_value3.Font = new System.Drawing.Font("微软雅黑", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_value3.Location = new System.Drawing.Point(7, 183);
            this.label_value3.Name = "label_value3";
            this.label_value3.Size = new System.Drawing.Size(22, 17);
            this.label_value3.TabIndex = 7;
            this.label_value3.Text = "00";
            // 
            // label_value4_name
            // 
            this.label_value4_name.AutoSize = true;
            this.label_value4_name.Font = new System.Drawing.Font("微软雅黑", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_value4_name.Location = new System.Drawing.Point(7, 231);
            this.label_value4_name.Name = "label_value4_name";
            this.label_value4_name.Size = new System.Drawing.Size(39, 17);
            this.label_value4_name.TabIndex = 8;
            this.label_value4_name.Text = "参数4";
            // 
            // label_value4
            // 
            this.label_value4.AutoSize = true;
            this.label_value4.Font = new System.Drawing.Font("微软雅黑", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_value4.Location = new System.Drawing.Point(7, 259);
            this.label_value4.Name = "label_value4";
            this.label_value4.Size = new System.Drawing.Size(22, 17);
            this.label_value4.TabIndex = 9;
            this.label_value4.Text = "00";
            // 
            // MyChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MyChart";
            this.Size = new System.Drawing.Size(1382, 509);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label_value1_name;
        private System.Windows.Forms.Label label_value1;
        private System.Windows.Forms.Label label_value2;
        private System.Windows.Forms.Label label_value2_name;
        private System.Windows.Forms.Label label_value3_name;
        private System.Windows.Forms.Label label_value4_name;
        private System.Windows.Forms.Label label_value3;
        private System.Windows.Forms.Label label_value4;
    }
}
