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
    public partial class jinliao_subview : UserControl
    {
        public static string gongyi_name;
       
        public static string ID;
        public static string huiliuyewei = "0";
        public static string jiaobanshijian = "0";
        public static string jinliaoshijian = "0";
        public static string zhubengpinlv= "0";
        public static string tibupinlv= "0";
        public static string fengjipinlv= "0";
        public static string gongyi_duan_name;
        

        public event EventHandler change = null;
        public jinliao_subview()
        {
            InitializeComponent();
            comboBox1.Items.Clear();
            comboBox1.Items.Add("中和助剂");
            comboBox1.Items.Add("染色助剂");
            comboBox1.Items.Add("分散染料");
            comboBox1.Items.Add("液碱");
            comboBox1.Items.Add("前处理助剂");
            comboBox1.Items.Add("元明粉");
            comboBox1.Items.Add("纯碱");
            comboBox1.Items.Add("保温粉");
            comboBox1.Items.Add("双氧水");
            comboBox1.Items.Add("纤维酶");
            comboBox1.Items.Add("阳离子染料");
            comboBox1.Items.Add("混纺染料");
            comboBox1.Items.Add("硫化染料");
            comboBox1.Items.Add("活性染料");
            comboBox1.Items.Add("中性染料");
            comboBox1.Items.Add("酸性染料");
            comboBox1.Items.Add("还原染料");
            comboBox1.Items.Add("冰醋酸");
            comboBox1.Items.Add("硫化碱");
            comboBox1.Items.Add("去油灵");
            comboBox1.Items.Add("皂洗剂");
            comboBox1.Items.Add("消泡剂");
            comboBox1.Items.Add("固色剂");
            comboBox1.Items.Add("高温匀染料");
            comboBox1.Items.Add("棉用匀染料");
            comboBox1.Items.Add("阳离子匀染料");
            comboBox1.Items.Add("酸性匀染料");
            comboBox1.Items.Add("膨化剂");
            comboBox1.Items.Add("柔软剂");
            comboBox1.Items.Add("增白剂");
            comboBox1.Items.Add("修补剂");
            comboBox1.Items.Add("防水剂");
            comboBox1.Items.Add("分散剂");
            comboBox1.Items.Add("防皱剂");
            comboBox1.Items.Add("精炼剂");
            comboBox1.Items.Add("酵素酶");
            comboBox1.Items.Add("除氧剂");
            init_view();
        }

        public void init_view()
        {
            comboBox1.Text = gongyi_duan_name;
            textBox_huiliuyewei.Text = huiliuyewei;
            textBox_jiaobanshijian.Text = jiaobanshijian;
            textBox_jinliaoshijian.Text = jinliaoshijian;
            textBox_pinlv.Text = zhubengpinlv;
            textBox_tibu.Text = tibupinlv;
            textBox_fengji.Text = fengjipinlv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            huiliuyewei = textBox_huiliuyewei.Text;
            jiaobanshijian = textBox_jiaobanshijian.Text;
            jinliaoshijian = textBox_jinliaoshijian.Text;
            zhubengpinlv = textBox_pinlv.Text;
            fengjipinlv = textBox_fengji.Text;
            tibupinlv = textBox_tibu.Text;

            if (comboBox1.Text == "") return;
            string[] update_cmd = new string[7];
            update_cmd[0] = "craft_name='" + comboBox1.Text + "'";
            update_cmd[1] = "value1='" + huiliuyewei + "'";
            update_cmd[2] = "value2='" + jiaobanshijian + "'";
            update_cmd[3] = "value3='" + jinliaoshijian + "'";
            update_cmd[4] = "value4='" + zhubengpinlv + "'";
            update_cmd[5] = "value5='" + tibupinlv + "'";
            update_cmd[6] = "value6='" + fengjipinlv + "'";

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
            huiliuyewei = textBox_huiliuyewei.Text;
            jiaobanshijian = textBox_jiaobanshijian.Text;
            jinliaoshijian = textBox_jinliaoshijian.Text;
            zhubengpinlv = textBox_pinlv.Text;
            fengjipinlv = textBox_fengji.Text;
            tibupinlv = textBox_tibu.Text;

            // 当前行的全部+1
            int nowid = int.Parse(ID);
            string[] update_cmd = new string[1];
            update_cmd[0] = "ID=ID+1";
            string where_cmd = "ID>='" + nowid.ToString() + "'";
            MainView.builder.Updata(gongyi_name, where_cmd, update_cmd);
            if (comboBox1.Text == "") return;

            // 插入当前一行
            string[] insert_cmd = new string[13];
            insert_cmd[0] = ID;
            insert_cmd[1] = comboBox1.Text;
            insert_cmd[2] = huiliuyewei;
            insert_cmd[3] = jiaobanshijian;
            insert_cmd[4] = jinliaoshijian;
            insert_cmd[5] = zhubengpinlv;
            insert_cmd[6] = tibupinlv;
            insert_cmd[7] = fengjipinlv;

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
            huiliuyewei = textBox_huiliuyewei.Text;
            jiaobanshijian = textBox_jiaobanshijian.Text;
            jinliaoshijian = textBox_jinliaoshijian.Text;
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
            insert_cmd[1] = comboBox1.Text;
            insert_cmd[2] = huiliuyewei;
            insert_cmd[3] = jiaobanshijian;
            insert_cmd[4] = jinliaoshijian;
            insert_cmd[5] = zhubengpinlv;
            insert_cmd[6] = tibupinlv;
            insert_cmd[7] = fengjipinlv;

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
