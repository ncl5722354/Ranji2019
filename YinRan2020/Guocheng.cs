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


            ViewCaoZuo.Object_Position(0, 0, 1, 0.2, label1, this.Controls);   // 标题

            ViewCaoZuo.Object_Position(0.1, 0.21, 0.2, 0.1, label3, this.Controls);   // 下拉菜单

            ViewCaoZuo.Object_Position(0.4, 0.21, 0.4, 0.1, comboBox_guochengzhonglei, this.Controls);

            ViewCaoZuo.Object_Position(0.16, 0.35, 0.06, 0.1, pictureBox1, this.Controls);         // 主泵频率

            ViewCaoZuo.Object_Position(0.26, 0.35, 0.3, 0.1, label6, this.Controls);

            ViewCaoZuo.Object_Position(0.49, 0.35, 0.3, 0.1, textBox_pinlv, this.Controls);

            ViewCaoZuo.Object_Position(0.16, 0.5, 0.06, 0.1, pictureBox2, this.Controls);           // 提布频率

            ViewCaoZuo.Object_Position(0.26, 0.5, 0.3, 0.1, label7, this.Controls);

            ViewCaoZuo.Object_Position(0.49, 0.5, 0.3, 0.1, textBox_tibu, this.Controls);

            ViewCaoZuo.Object_Position(0.16, 0.65, 0.06, 0.1, pictureBox3, this.Controls);           // 风机频率

            ViewCaoZuo.Object_Position(0.26, 0.65, 0.3, 0.1, label8, this.Controls);

            ViewCaoZuo.Object_Position(0.49, 0.65, 0.3, 0.1, textBox_fengji, this.Controls);

            ViewCaoZuo.Object_Position(0.01, 0.89, 0.2, 0.1, button1, this.Controls);     // 确认

            ViewCaoZuo.Object_Position(0.3, 0.89, 0.2, 0.1, button2, this.Controls);      // 上一条

            ViewCaoZuo.Object_Position(0.6, 0.89, 0.2, 0.1, button3, this.Controls);      // 下一条
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

        private void Guocheng_Resize(object sender, EventArgs e)
        {
            init_view();
        }
    }
}
