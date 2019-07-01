using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ViewConfig;

namespace YinRan2020
{
    public partial class Lishijilv : Form
    {

        public DateTime start_time = new DateTime();
        public int machine_num = 1;
        public Lishijilv()
        {
            InitializeComponent();
            init_view();
            start_time = DateTime.Now.AddHours(-5);
            show_chart();

        }

        private void init_view()
        {
            ViewCaoZuo.Object_Position(0.40, 0.01, 0.2, 0.1, label_title, this.Controls);

            ViewCaoZuo.Object_Position(0.01, 0.13, 0.98, 0.3, panel_chart, this.Controls);
            ViewCaoZuo.Object_Position(0, 0, 1, 1, chart1, panel_chart.Controls);

            ViewCaoZuo.Object_Position(0.01, 0.44, 0.98, 0.05, panel_caozuo, this.Controls);

            ViewCaoZuo.Object_Position(0, 0, 0.1, 0.90, button_qian1hour, panel_caozuo.Controls);

            ViewCaoZuo.Object_Position(0.1, 0, 0.1, 0.9, button_qian5min, panel_caozuo.Controls);

            ViewCaoZuo.Object_Position(0.2, 0, 0.1, 0.9, button_now, panel_caozuo.Controls);

            ViewCaoZuo.Object_Position(0.3, 0, 0.1, 0.9, button_next5min, panel_caozuo.Controls);

            ViewCaoZuo.Object_Position(0.4, 0, 0.1, 0.9, button_next1hour, panel_caozuo.Controls);

            ViewCaoZuo.Object_Position(0.55, 0, 0.3, 0.9, dateTimePicker_search, panel_caozuo.Controls);

            ViewCaoZuo.Object_Position(0.01, 0.5, 0.4, 0.49, groupBox1, this.Controls);
        }

        private void Lishijilv_Resize(object sender, EventArgs e)
        {
            init_view();
        }

        private void show_chart()
        {
            try
            {
                
               
                DateTime startendtime = start_time.AddHours(5);

                chart1.ChartAreas[0].AxisX.Minimum = start_time.ToOADate();
                chart1.ChartAreas[0].AxisX.Maximum = startendtime.ToOADate();

                string where_cmd2 = "machine_num='" + machine_num.ToString() + "' and value_name='机缸温度' and value_time>='" + start_time.ToString("yyyy-MM-dd HH:mm:ss") + "' and value_time<'" + startendtime.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                DataTable dt1 = MainView.builder.Select_Table("save_info", where_cmd2);

                foreach (DataRow row in dt1.Rows)
                {
                    DateTime nowtime = DateTime.Parse(row[3].ToString());
                    double value = double.Parse(row[4].ToString());
                    chart1.Series[0].Points.AddXY(nowtime.ToOADate(), value);
                }


            }
            catch { }


            // 显示操作
            try
            {
                chart1.Series[1].Points.Clear();
               
                string where_cmd1 = "machine_num='" + machine_num.ToString() + "'";
                DataTable starttimedt = MainView.builder.Select_Table("start_time", where_cmd1);

               
                DateTime startendtime = start_time.AddHours(5);
                string where_cmd2 = "machine_num='" + machine_num.ToString() + "' and mytime>='" + start_time.ToString("yyyy-MM-dd HH:mm:ss") + "' and mytime<='" + startendtime.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                DataTable dt1 = MainView.builder.Select_Table("caozuo_save", where_cmd2);

                foreach (DataRow dr in dt1.Rows)
                {
                    try
                    {
                        DateTime nowtime = DateTime.Parse(dr[2].ToString());
                        chart1.Series[1].Points.AddXY(nowtime.ToOADate(), 160);

                        chart1.Series[1].Points[chart1.Series[1].Points.Count - 1].Label = dr[4].ToString() + " " + dr[5].ToString();
                        //chart1.Series[1].Points[chart1.Series[1].Points.Count - 1].IsValueShownAsLabel = true;
                    }
                    catch { }
                }


            }
            catch { }


            // 跳段操作
            try
            {
                chart1.Series[2].Points.Clear();
                
                string where_cmd1 = "machine_num='" + machine_num.ToString() + "'";
                DataTable starttimedt = MainView.builder.Select_Table("start_time", where_cmd1);

                
                DateTime startendtime = start_time.AddHours(5);
                string where_cmd2 = "machine_num='" + machine_num.ToString() + "' and mytime>='" + start_time.ToString("yyyy-MM-dd HH:mm:ss") + "' and mytime<='" + startendtime.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                DataTable dt1 = MainView.builder.Select_Table("tiaoduan_save", where_cmd2);

                foreach (DataRow dr in dt1.Rows)
                {
                    try
                    {
                        DateTime nowtime = DateTime.Parse(dr[2].ToString());
                        chart1.Series[2].Points.AddXY(nowtime.ToOADate(), 250);

                        chart1.Series[2].Points[chart1.Series[2].Points.Count - 1].Label = " 段号:" + dr[4].ToString();
                        //chart1.Series[1].Points[chart1.Series[1].Points.Count - 1].IsValueShownAsLabel = true;
                    }
                    catch { }
                }


            }
            catch { }
        }

        private void button_2hao_Click(object sender, EventArgs e)
        {
            machine_num = 2;
            show_chart();
        }

        private void button_3hao_Click(object sender, EventArgs e)
        {
            machine_num = 3;
            show_chart();
        }

        private void button_4hao_Click(object sender, EventArgs e)
        {
            machine_num = 4;
            show_chart();
        }

        private void button_5hao_Click(object sender, EventArgs e)
        {
            machine_num = 5;
            show_chart();
        }

        private void button_6hao_Click(object sender, EventArgs e)
        {
            machine_num = 6;
            show_chart();
        }

        private void button_7hao_Click(object sender, EventArgs e)
        {
            machine_num = 7;
            show_chart();
        }

        private void button_8hao_Click(object sender, EventArgs e)
        {
            machine_num = 8;
            show_chart();
        }

        private void button_9hao_Click(object sender, EventArgs e)
        {
            machine_num = 9;
            show_chart();
        }

        private void button_10hao_Click(object sender, EventArgs e)
        {
            machine_num = 10;
            show_chart();
        }

        private void button_11hao_Click(object sender, EventArgs e)
        {
            machine_num = 11;
            show_chart();
        }

        private void button_12hao_Click(object sender, EventArgs e)
        {
            machine_num = 12;
            show_chart();
        }

        private void button_13hao_Click(object sender, EventArgs e)
        {
            machine_num = 13;
            show_chart();
        }

        private void button_14hao_Click(object sender, EventArgs e)
        {
            machine_num = 14;
            show_chart();
        }

        private void button_15hao_Click(object sender, EventArgs e)
        {
            machine_num = 15;
            show_chart();
        }

        private void button_16hao_Click(object sender, EventArgs e)
        {
            machine_num = 16;
            show_chart();
        }

        private void button_17hao_Click(object sender, EventArgs e)
        {
            machine_num = 17;
            show_chart();
        }

        private void button_18hao_Click(object sender, EventArgs e)
        {
            machine_num = 18;
            show_chart();
        }

        private void button_19hao_Click(object sender, EventArgs e)
        {
            machine_num = 19;
            show_chart();
        }

        private void button_20hao_Click(object sender, EventArgs e)
        {
            machine_num = 20;
            show_chart();
        }

        private void button_21hao_Click(object sender, EventArgs e)
        {
            machine_num = 21;
            show_chart();
        }

        private void button_22hao_Click(object sender, EventArgs e)
        {
            machine_num = 22;
            show_chart();
        }

        private void button_23hao_Click(object sender, EventArgs e)
        {
            machine_num = 23;
            show_chart();
        }

        private void button_24hao_Click(object sender, EventArgs e)
        {
            machine_num = 24;
            show_chart();
        }

        private void button_25hao_Click(object sender, EventArgs e)
        {
            machine_num = 25;
            show_chart();
        }

        private void button_26hao_Click(object sender, EventArgs e)
        {
            machine_num = 26;
            show_chart();
        }

        private void button_27hao_Click(object sender, EventArgs e)
        {
            machine_num = 27;
            show_chart();
        }

        private void button_28hao_Click(object sender, EventArgs e)
        {
            machine_num = 28;
            show_chart();
        }

        private void button_29hao_Click(object sender, EventArgs e)
        {
            machine_num = 29;
            show_chart();
        }

        private void button_30hao_Click(object sender, EventArgs e)
        {
            machine_num = 30;
            show_chart();
        }

        private void button_31hao_Click(object sender, EventArgs e)
        {
            machine_num = 31;
            show_chart();
        }

        private void button_32hao_Click(object sender, EventArgs e)
        {
            machine_num = 32;
            show_chart();
        }

        private void button_33hao_Click(object sender, EventArgs e)
        {
            machine_num = 33;
            show_chart();
        }

        private void button_34hao_Click(object sender, EventArgs e)
        {
            machine_num = 34;
            show_chart();
        }

        private void button_35hao_Click(object sender, EventArgs e)
        {
            machine_num = 35;
            show_chart();
        }

        private void button_36hao_Click(object sender, EventArgs e)
        {
            machine_num = 36;
            show_chart();
        }

        private void button_37hao_Click(object sender, EventArgs e)
        {
            machine_num = 37;
            show_chart();
        }

        private void button_38hao_Click(object sender, EventArgs e)
        {
            machine_num = 38;
            show_chart();
        }

        private void button_39hao_Click(object sender, EventArgs e)
        {
            machine_num = 39;
            show_chart();
        }

        private void button_40hao_Click(object sender, EventArgs e)
        {
            machine_num = 40;
            show_chart();
        }

        private void button_41hao_Click(object sender, EventArgs e)
        {
            machine_num = 41;
            show_chart();
        }

        private void button_42hao_Click(object sender, EventArgs e)
        {
            machine_num = 42;
            show_chart();
        }

        private void button_43hao_Click(object sender, EventArgs e)
        {
            machine_num = 43;
            show_chart();
        }

        private void button_44hao_Click(object sender, EventArgs e)
        {
            machine_num = 44;
            show_chart();
        }

        private void button_45hao_Click(object sender, EventArgs e)
        {
            machine_num = 45;
            show_chart();
        }

        private void button_1hao_Click(object sender, EventArgs e)
        {
            machine_num = 1;
            show_chart();
        }
    }
}
