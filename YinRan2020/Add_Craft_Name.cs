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
    public partial class Add_Craft_Name : Form
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

        public Add_Craft_Name()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_craft_name.Text == "") { MessageBox.Show("工艺名称不能为空"); return; }
            Craft_Name = textBox_craft_name.Text;
            Canshu1_Name = textBox_canshu1_name.Text;
            Canshu2_Name = textBox_canshu2_name.Text;
            Canshu3_Name = textBox_canshu3_name.Text;
            Canshu4_Name = textBox_canshu4_name.Text;
            Canshu5_Name = textBox_canshu5_name.Text;
            Canshu6_Name = textBox_canshu6_name.Text;
            Canshu7_Name = textBox_canshu7_name.Text;
            Canshu8_Name = textBox_canshu8_name.Text;
            Canshu9_Name = textBox_canshu9_name.Text;
            Canshu10_Name = textBox_canshu10_name.Text;
            beizhu = textBox_beizhu.Text;
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
