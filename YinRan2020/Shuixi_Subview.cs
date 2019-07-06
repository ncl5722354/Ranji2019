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
    public partial class Shuixi_Subview : UserControl
    {

        public static string gongyi_name;
        public static string ID;
        public static string shangxian;
        public static string xiaxian;
        public static string dunshu_shijian;
        public static string zhubengpinlv;
        public static string tibupinlv;
        public static string fengjipinlv;
        public static string gongyi_duan_name;
        public event EventHandler change = null;
        public Shuixi_Subview()
        {
            InitializeComponent();
            init_view();
            try
            {
                comboBox_shuixitype.Text = gongyi_duan_name.Substring(0, 2);
            }
            catch { }
            try
            {
                int jin = int.Parse(gongyi_duan_name.Substring(5, 1));
                int pai = int.Parse(gongyi_duan_name.Substring(7, 1));
                numericUpDown_jinshui.Value = jin;
                numericUpDown_chushui.Value = pai;
                textBox_shangxianshuiwei.Text = shangxian;
                textBox_xiaxianshuiwei.Text = xiaxian;
                textBox_shuiliang.Text = dunshu_shijian;
                textBox_pinlv.Text = zhubengpinlv;
                textBox_tibu.Text = tibupinlv;
                textBox_fengji.Text = fengjipinlv;
            }
            catch { }
        }

        private void init_view()
        {
            comboBox_shuixitype.Items.Clear();
            comboBox_shuixitype.Items.Add("吨数");
            comboBox_shuixitype.Items.Add("时间");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            shangxian = textBox_shangxianshuiwei.Text;
            xiaxian = textBox_xiaxianshuiwei.Text;
            dunshu_shijian = textBox_shuiliang.Text;
            zhubengpinlv = textBox_pinlv.Text;
            fengjipinlv = textBox_fengji.Text;
            tibupinlv = textBox_tibu.Text;


            if (comboBox_shuixitype.Text == "") return;
            string[] update_cmd = new string[7];
            update_cmd[0] = "craft_name='"+comboBox_shuixitype.Text+"水洗"+"进"+numericUpDown_jinshui.Value.ToString()+"出"+numericUpDown_chushui.Value.ToString()+"'";
            update_cmd[1] = "value1='" + shangxian + "'";
            update_cmd[2] = "value2='" + xiaxian + "'";
            update_cmd[3] = "value3='" + dunshu_shijian + "'";
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

        private void comboBox_shuixitype_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_shuixitype.Items[comboBox_shuixitype.SelectedIndex].ToString() == "吨数")
                {
                    label4.Text = "吨数";
                }
                if (comboBox_shuixitype.Items[comboBox_shuixitype.SelectedIndex].ToString() == "时间")
                {
                    label4.Text = "时间";
                }
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            shangxian = textBox_shangxianshuiwei.Text;
            xiaxian = textBox_xiaxianshuiwei.Text;
            dunshu_shijian = textBox_shuiliang.Text;
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
            insert_cmd[1] = comboBox_shuixitype.Text + "水洗" + "进" + numericUpDown_jinshui.Value.ToString() + "出" + numericUpDown_chushui.Value.ToString();
            insert_cmd[2] = shangxian;
            insert_cmd[3] = xiaxian;
            insert_cmd[4] = dunshu_shijian;
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
            shangxian = textBox_shangxianshuiwei.Text;
            xiaxian = textBox_xiaxianshuiwei.Text;
            dunshu_shijian = textBox_shuiliang.Text;
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
            // 插入当前一行
            string[] insert_cmd = new string[13];
            insert_cmd[0] = (nowid+1).ToString();
            insert_cmd[1] = comboBox_shuixitype.Text + "水洗" + "进" + numericUpDown_jinshui.Value.ToString() + "出" + numericUpDown_chushui.Value.ToString();
            insert_cmd[2] = shangxian;
            insert_cmd[3] = xiaxian;
            insert_cmd[4] = dunshu_shijian;
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
