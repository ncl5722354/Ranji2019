using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ViewConfig;

namespace YinRan2020
{
    public partial class Shengwen_subview : UserControl
    {
        public static string gongyi_name;
        public static string ID;
        public static string start_wendu;
        public static string end_wendu;
        public static string shengwen_time;
        public static string shengwen_sulv;
        public static string zhubengpinlv;
        public static string tibupinlv;
        public static string fengjipinlv;
        public static string gongyi_duan_name;

        public event EventHandler change = null;

        public static bool xiugai_time = false;
        public static bool xiugai_sulv = false;
        public Shengwen_subview()
        {
            InitializeComponent();
            textBox_startwendu.Text = start_wendu;
            textBox_endwendu.Text = end_wendu;
            textBox_time.Text = shengwen_time;
            textBox_pinlv.Text = zhubengpinlv;
            textBox_fengji.Text = fengjipinlv;
            textBox_tibu.Text = tibupinlv;
            Draw_Line();
        }

        private void init_view()
        {

        }
        

        private void Draw_Line()
        {
            chart1.Series[0].Points.Clear();
            try
            {
                chart1.Series[0].Points.AddXY(0, double.Parse(textBox_startwendu.Text));
                chart1.Series[0].Points.AddXY(double.Parse(textBox_time.Text), double.Parse(textBox_endwendu.Text));
                chart1.ChartAreas[0].AxisX.Maximum = double.Parse(textBox_time.Text);
                chart1.ChartAreas[0].AxisX.Minimum = 0;
            }
            catch { }
        }
        private void textBox_startwendu_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                    textBox_sulv.Text = "0";
                    textBox_sulv.Text = (Math.Round(Math.Abs(double.Parse(textBox_startwendu.Text) - double.Parse(textBox_endwendu.Text)) / double.Parse(textBox_time.Text), 2)).ToString();
                    Draw_Line();
                    
            }
            catch { textBox_sulv.Text = "0"; }
        }

        private void textBox_endwendu_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox_sulv.Text = "0";
                textBox_sulv.Text = (Math.Round(Math.Abs(double.Parse(textBox_startwendu.Text) - double.Parse(textBox_endwendu.Text)) / double.Parse(textBox_time.Text), 2)).ToString();
                Draw_Line();
            }
            catch { textBox_sulv.Text = "0"; }
        }

        private void textBox_time_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (xiugai_sulv == false)
                {
                    xiugai_time = true;
                    textBox_sulv.Text = "0";
                    textBox_sulv.Text = (Math.Round(Math.Abs(double.Parse(textBox_startwendu.Text) - double.Parse(textBox_endwendu.Text)) / double.Parse(textBox_time.Text), 2)).ToString();
                    Draw_Line();                    
                    xiugai_time = false;
                }
            }
            catch { textBox_sulv.Text = "0"; }
        }

        private void textBox_sulv_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (xiugai_time == false)
                {
                    xiugai_sulv = true;
                    if (textBox_sulv.Text != "正无穷大" && textBox_sulv.Text != "0")
                    {
                        textBox_time.Text = ((int)(Math.Abs(double.Parse(textBox_startwendu.Text) - double.Parse(textBox_endwendu.Text)) / double.Parse(textBox_sulv.Text))).ToString();
                        Draw_Line();
                    }
                    xiugai_sulv = false;
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            start_wendu = textBox_startwendu.Text;
            end_wendu=textBox_endwendu.Text;
            shengwen_time=textBox_time.Text ;
            zhubengpinlv= textBox_pinlv.Text ;
            fengjipinlv=textBox_fengji.Text;
            tibupinlv=textBox_tibu.Text;

            string[] update_cmd = new string[7];
            update_cmd[0] = "craft_name='升温'";
            update_cmd[1] = "value1='"+  start_wendu+"'";
            update_cmd[2] = "value2='" + end_wendu + "'";
            update_cmd[3] = "value3='" + shengwen_time + "'";
            update_cmd[4] = "value4='" + zhubengpinlv + "'";
            update_cmd[5] = "value5='" + tibupinlv + "'";
            update_cmd[6] = "value6='" + fengjipinlv + "'";

            string wherer_cmd = "ID='" + ID + "'";
            bool result = MainView.builder.Updata(gongyi_name, wherer_cmd, update_cmd);
            if (result == true)
            {
                if(change!=null)
                {
                    change(this, new EventArgs());
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 当前行的全部+1
            int nowid = int.Parse(ID);
            string[] update_cmd = new string[1];
            update_cmd[0] = "ID=ID+1";
            string where_cmd = "ID>='" + nowid.ToString() + "'";
            MainView.builder.Updata(gongyi_name, where_cmd, update_cmd);

        }
    }
}
