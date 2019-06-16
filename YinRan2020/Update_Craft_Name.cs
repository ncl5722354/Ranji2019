using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace YinRan2020
{
    public partial class Update_Craft_Name : Form
    {
        public static string Craft_Name = "";
        public static string Canshu1_Name = "";
        public static string Canshu2_Name = "";
        public static string Canshu3_Name = "";
        public static string Canshu4_Name = "";
        public static string Canshu5_Name = "";
        public static string Canshu6_Name = "";
        public static string Canshu7_Name = "";
        public static string Canshu8_Name = "";
        public static string Canshu9_Name = "";
        public static string Canshu10_Name = "";
        public static string beizhu = "";
        public Update_Craft_Name()
        {
            InitializeComponent();
            textBox_craft_name.Text = Craft_Name;
            textBox_canshu1_name.Text = Canshu1_Name;
            textBox_canshu2_name.Text = Canshu2_Name;
            textBox_canshu3_name.Text = Canshu3_Name;
            textBox_canshu4_name.Text = Canshu4_Name;
            textBox_canshu5_name.Text = Canshu5_Name;
            textBox_canshu6_name.Text = Canshu6_Name;
            textBox_canshu7_name.Text = Canshu7_Name;
            textBox_canshu8_name.Text = Canshu8_Name;
            textBox_canshu9_name.Text = Canshu9_Name;
            textBox_canshu10_name.Text = Canshu10_Name;
            textBox_beizhu.Text = beizhu;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 更新
            string[] update_cmd = new string[11];
            update_cmd[0] = "value1_name='" + textBox_canshu1_name.Text + "'";
            update_cmd[1] = "value2_name='" + textBox_canshu2_name.Text + "'";
            update_cmd[2] = "value3_name='" + textBox_canshu3_name.Text + "'";
            update_cmd[3] = "value4_name='" + textBox_canshu4_name.Text + "'";
            update_cmd[4] = "value5_name='" + textBox_canshu5_name.Text + "'";
            update_cmd[5] = "value6_name='" + textBox_canshu6_name.Text + "'";
            update_cmd[6] = "value7_name='" + textBox_canshu7_name.Text + "'";
            update_cmd[7] = "value8_name='" + textBox_canshu8_name.Text + "'";
            update_cmd[8] = "value9_name='" + textBox_canshu9_name.Text + "'";
            update_cmd[9] = "value10_name='" + textBox_canshu10_name.Text + "'";
            update_cmd[10] = "beizhu='" + textBox_beizhu.Text + "'";
            string where_cmd = "Gongyi_Name='" + Craft_Name + "'";
            MainView.builder.Updata("Craft_Name_Table", where_cmd, update_cmd);
            this.Dispose();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
