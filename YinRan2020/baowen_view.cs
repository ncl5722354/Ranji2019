using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YinRan2020
{
    public partial class baowen_view : UserControl
    {
        public static string ID;
        public static string gongyi_name;
        public static string baowenwendu;
        public static string baowenshijian;
        public static string zhubengpinlv;
        public static string tibupinlv;
        public static string fengjipinlv;
        public event EventHandler change = null;
        public baowen_view()
        {
            InitializeComponent();
            textBox_baowenwendu.Text = baowenwendu;
            textBox_baowenshijian.Text = baowenshijian;
            textBox_pinlv.Text = zhubengpinlv;
            textBox_tibu.Text = tibupinlv;
            textBox_fengji.Text = fengjipinlv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baowenwendu = textBox_baowenwendu.Text;
            baowenshijian = textBox_baowenshijian.Text;
            zhubengpinlv = textBox_pinlv.Text;
            tibupinlv = textBox_tibu.Text;
            fengjipinlv = textBox_fengji.Text;
            string[] update_cmd = new string[6];
            update_cmd[0] = "craft_name='保温'";
            update_cmd[1] = "value1='" + baowenwendu + "'";
            update_cmd[2] = "value2='" + baowenshijian + "'";
            update_cmd[3] = "value3='" + zhubengpinlv + "'";
            update_cmd[4] = "value4='" + tibupinlv + "'";
            update_cmd[5] = "value5='" + fengjipinlv + "'";

            string where_cmd = "ID='" + ID + "'";
            MainView.builder.Updata(gongyi_name, where_cmd, update_cmd);
            if(change!=null)
            {
                change(this, new EventArgs());
            }

        }
    }
}
