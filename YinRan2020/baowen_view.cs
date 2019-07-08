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
    public partial class baowen_view : UserControl
    {
        public static string ID;
        public static string gongyi_name;
        public static string baowenwendu="0";
        public static string baowenshijian="0";
        public static string zhubengpinlv="0";
        public static string tibupinlv="0";
        public static string fengjipinlv="0";
        public event EventHandler change = null;
        public baowen_view()
        {
            InitializeComponent();
            textBox_baowenwendu.Text = baowenwendu;
            textBox_baowenshijian.Text = baowenshijian;
            textBox_pinlv.Text = zhubengpinlv;
            textBox_tibu.Text = tibupinlv;
            textBox_fengji.Text = fengjipinlv;
            init_view();
        }

        public void init_view()
        {
            ViewCaoZuo.Object_Position(0, 0, 1, 0.2, label1, this.Controls);   // 标题

            ViewCaoZuo.Object_Position(0.01, 0.25, 0.2, 0.1, label2, this.Controls);        //保温温度

            ViewCaoZuo.Object_Position(0.24, 0.25, 0.2, 0.1, textBox_baowenwendu, this.Controls);

            ViewCaoZuo.Object_Position(0.01, 0.4, 0.2, 0.1, label3, this.Controls);        // 保温时间

            ViewCaoZuo.Object_Position(0.24, 0.4, 0.2, 0.1, textBox_baowenshijian, this.Controls);

            ViewCaoZuo.Object_Position(0.5, 0.25, 0.06, 0.1, pictureBox1, this.Controls);   // 主泵频率

            ViewCaoZuo.Object_Position(0.56, 0.25, 0.2, 0.1, label6, this.Controls);

            ViewCaoZuo.Object_Position(0.79, 0.25, 0.2, 0.1, textBox_pinlv, this.Controls);

            ViewCaoZuo.Object_Position(0.5, 0.4, 0.06, 0.1, pictureBox2, this.Controls);  // 提布频率

            ViewCaoZuo.Object_Position(0.56, 0.4, 0.2, 0.1, label7, this.Controls);

            ViewCaoZuo.Object_Position(0.79, 0.4, 0.2, 0.1, textBox_tibu, this.Controls);

            ViewCaoZuo.Object_Position(0.5, 0.55, 0.06, 0.1, pictureBox3, this.Controls);  // 风机频率

            ViewCaoZuo.Object_Position(0.56, 0.55, 0.2, 0.1, label8, this.Controls);

            ViewCaoZuo.Object_Position(0.79, 0.55, 0.2, 0.1, textBox_fengji, this.Controls);

            ViewCaoZuo.Object_Position(0.01, 0.89, 0.2, 0.1, button1, this.Controls);     // 确认

            ViewCaoZuo.Object_Position(0.3, 0.89, 0.2, 0.1, button2, this.Controls);      // 上一条

            ViewCaoZuo.Object_Position(0.6, 0.89, 0.2, 0.1, button3, this.Controls);      // 下一条
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

        private void button2_Click(object sender, EventArgs e)
        {
            baowenwendu = textBox_baowenwendu.Text;
            baowenshijian = textBox_baowenshijian.Text;
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
            insert_cmd[1] = "保温";
            insert_cmd[2] = baowenwendu;
            insert_cmd[3] = baowenshijian;
            insert_cmd[4] = zhubengpinlv;
            insert_cmd[5] = tibupinlv;
            insert_cmd[6] = fengjipinlv;
            

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
            baowenwendu = textBox_baowenwendu.Text;
            baowenshijian = textBox_baowenshijian.Text;
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
            insert_cmd[0] = (nowid+1).ToString();
            insert_cmd[1] = "保温";
            insert_cmd[2] = baowenwendu;
            insert_cmd[3] = baowenshijian;
            insert_cmd[4] = zhubengpinlv;
            insert_cmd[5] = tibupinlv;
            insert_cmd[6] = fengjipinlv;


            bool result = MainView.builder.Insert(gongyi_name, insert_cmd);
            if (result == true)
            {
                if (change != null)
                {
                    change(this, new EventArgs());
                }
            }
        }

        private void baowen_view_Load(object sender, EventArgs e)
        {

        }

        private void baowen_view_Resize(object sender, EventArgs e)
        {
            init_view();
        }
    }
}
