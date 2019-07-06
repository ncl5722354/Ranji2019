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
    public partial class Guocheng : UserControl
    {
        public static string gongyi_name;
        public static string ID;
        
        public static string zhubengpinlv;
        public static string tibupinlv;
        public static string fengjipinlv;
        public static string gongyi_duan_name;

        public event EventHandler change = null;
        public Guocheng()
        {
            InitializeComponent();
            init_view();
        }

        private void init_view()
        {
            comboBox_guochengzhonglei.Items.Clear();
            comboBox_guochengzhonglei.Items.Add("结束");
            comboBox_guochengzhonglei.Items.Add("取样");
            comboBox_guochengzhonglei.Items.Add("出布");
            comboBox_guochengzhonglei.Items.Add("自动暂停");
            comboBox_guochengzhonglei.Items.Add("停泵取样");
            comboBox_guochengzhonglei.Items.Add("进布");

            textBox_pinlv.Text = zhubengpinlv;
            textBox_tibu.Text = tibupinlv;
            textBox_fengji.Text = fengjipinlv;
            comboBox_guochengzhonglei.Text = gongyi_duan_name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            zhubengpinlv = textBox_pinlv.Text;
            fengjipinlv = textBox_fengji.Text;
            tibupinlv = textBox_tibu.Text;
            if (comboBox_guochengzhonglei.Text == "") return;
            string[] update_cmd = new string[4];
            update_cmd[0] = "craft_name='" + comboBox_guochengzhonglei.Text + "'";
           
            update_cmd[1] = "value1='" + zhubengpinlv + "'";
            update_cmd[2] = "value2='" + tibupinlv + "'";
            update_cmd[3] = "value3='" + fengjipinlv + "'";

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
            if (comboBox_guochengzhonglei.Text == "") return;
            string[] insert_cmd = new string[13];
            insert_cmd[0] = ID;
            insert_cmd[1] =  comboBox_guochengzhonglei.Text;
            
            insert_cmd[2] = zhubengpinlv;
            insert_cmd[3] = tibupinlv;
            insert_cmd[4] = fengjipinlv;

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
            insert_cmd[1] =  comboBox_guochengzhonglei.Text;
           
            insert_cmd[2] = zhubengpinlv;
            insert_cmd[3] = tibupinlv;
            insert_cmd[4] = fengjipinlv;

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
