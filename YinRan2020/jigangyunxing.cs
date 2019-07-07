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
    public partial class jigangyunxing : UserControl
    {
        public static string gongyi_name;
        public static string ID;
        public static string yunxingshijian = "0";
        public static string zhubengpinlv = "0";
        public static string tibupinlv = "0";
        public static string fengjipinlv = "0";
        public static string gongyi_duan_name = "0";
        public event EventHandler change = null;
        public jigangyunxing()
        {
            InitializeComponent();
            init_view();
        }

        private void init_view()
        {
            

            textBox_pinlv.Text = zhubengpinlv;
            textBox_tibu.Text = tibupinlv;
            textBox_fengji.Text = fengjipinlv;
            textBox_yunxingshijian.Text = yunxingshijian;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            zhubengpinlv = textBox_pinlv.Text;
            fengjipinlv = textBox_fengji.Text;
            tibupinlv = textBox_tibu.Text;
            yunxingshijian = textBox_yunxingshijian.Text;
            string[] update_cmd = new string[5];
            update_cmd[0] = "craft_name='染机运行一'";
            update_cmd[1] = "value1='" + yunxingshijian + "'";
            update_cmd[2] = "value2='" + zhubengpinlv + "'";
            update_cmd[3] = "value3='" + tibupinlv + "'";
            update_cmd[4] = "value4='" + fengjipinlv + "'";

            string wherer_cmd = "ID='" + ID + "'";
            bool result = MainView.builder.Updata(gongyi_name, wherer_cmd, update_cmd);
            if (result == true)
            {
                if (change != null)
                {
                    change(this, new EventArgs());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yunxingshijian = textBox_yunxingshijian.Text;
            zhubengpinlv = textBox_pinlv.Text;
            fengjipinlv = textBox_fengji.Text;
            tibupinlv = textBox_tibu.Text;

            // 当前行的全部+1
            int nowid = int.Parse(ID);
            string[] update_cmd = new string[1];
            update_cmd[0] = "ID=ID+1";
            string where_cmd = "ID>='" + nowid.ToString() + "'";
            MainView.builder.Updata(gongyi_name, where_cmd, update_cmd);


            // 插入当前一行
           
            string[] insert_cmd = new string[13];
            insert_cmd[0] = ID;
            insert_cmd[1] = "染机运行一";
            insert_cmd[2] = yunxingshijian;
            insert_cmd[3] = zhubengpinlv;
            insert_cmd[4] = tibupinlv;
            insert_cmd[5] = fengjipinlv;

            bool result = MainView.builder.Insert(gongyi_name, insert_cmd);
            if (result == true)
            {
                if (change != null)
                {
                    change(this, new EventArgs());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            yunxingshijian = textBox_yunxingshijian.Text;
            zhubengpinlv = textBox_pinlv.Text;
            fengjipinlv = textBox_fengji.Text;
            tibupinlv = textBox_tibu.Text;

            // 当前行的全部+1
            int nowid = int.Parse(ID);
            string[] update_cmd = new string[1];
            update_cmd[0] = "ID=ID+1";
            string where_cmd = "ID>'" + nowid.ToString() + "'";
            MainView.builder.Updata(gongyi_name, where_cmd, update_cmd);


            // 插入当前一行
            string[] insert_cmd = new string[13];
            insert_cmd[0] = (nowid + 1).ToString();
            insert_cmd[1] = "染机运行一";
            insert_cmd[2] = yunxingshijian;
            insert_cmd[3] = zhubengpinlv;
            insert_cmd[4] = tibupinlv;
            insert_cmd[5] = fengjipinlv;

            bool result = MainView.builder.Insert(gongyi_name, insert_cmd);
            if (result == true)
            {
                if (change != null)
                {
                    change(this, new EventArgs());
                }
            }
        }

    }
}
