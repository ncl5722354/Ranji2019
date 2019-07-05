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
        }

        private void init_view()
        {

        }

        private void textBox_startwendu_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                    textBox_sulv.Text = "0";
                    textBox_sulv.Text = (Math.Round(Math.Abs(double.Parse(textBox_startwendu.Text) - double.Parse(textBox_endwendu.Text)) / double.Parse(textBox_time.Text), 2)).ToString();
                    
            }
            catch { textBox_sulv.Text = "0"; }
        }

        private void textBox_endwendu_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox_sulv.Text = "0";
                textBox_sulv.Text = (Math.Round(Math.Abs(double.Parse(textBox_startwendu.Text) - double.Parse(textBox_endwendu.Text)) / double.Parse(textBox_time.Text), 2)).ToString();
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
                        textBox_time.Text = ((int)(Math.Abs(double.Parse(textBox_startwendu.Text) - double.Parse(textBox_endwendu.Text)) / double.Parse(textBox_sulv.Text))).ToString();
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

            string[] update_cmd = new string[13];


            

        }
    }
}
