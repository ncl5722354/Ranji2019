using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YinRan2020
{
    public partial class Update_Craft_Final : Form
    {
        public static string Craft_Name;
        public static string canshu1_shuoming;
        public static string canshu2_shuoming;
        public static string canshu3_shuoming;
        public static string canshu4_shuoming;
        public static string canshu5_shuoming;
        public static string canshu6_shuoming;
        public static string canshu7_shuoming;
        public static string canshu8_shuoming;
        public static string canshu9_shuoming;
        public static string canshu10_shuoming;

        public static string canshu1;
        public static string canshu2;
        public static string canshu3;
        public static string canshu4;
        public static string canshu5;
        public static string canshu6;
        public static string canshu7;
        public static string canshu8;
        public static string canshu9;
        public static string canshu10;

        public Update_Craft_Final()
        {
            InitializeComponent();
            label_value1.Text = canshu1_shuoming;
            label_value2.Text = canshu2_shuoming;
            label_value3.Text = canshu3_shuoming;
            label_value4.Text = canshu4_shuoming;
            label_value5.Text = canshu5_shuoming;
            label_value6.Text = canshu6_shuoming;
            label_value7.Text = canshu7_shuoming;
            label_value8.Text = canshu8_shuoming;
            label_value9.Text = canshu9_shuoming;
            label_value10.Text = canshu10_shuoming;

            textBox_value1.Text = canshu1;
            textBox_value2.Text = canshu2;
            textBox_value3.Text = canshu3;
            textBox_value4.Text = canshu4;
            textBox_value5.Text = canshu5;
            textBox_value6.Text = canshu6;
            textBox_value7.Text = canshu7;
            textBox_value8.Text = canshu8;
            textBox_value9.Text = canshu9;
            textBox_value10.Text = canshu10;
        }

        public void Set_Name(string title)
        {
            label_title.Text = title;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            canshu1 = textBox_value1.Text;
            canshu2 = textBox_value2.Text;
            canshu3 = textBox_value3.Text;
            canshu4 = textBox_value4.Text;
            canshu5 = textBox_value5.Text;
            canshu6 = textBox_value6.Text;
            canshu7 = textBox_value7.Text;
            canshu8 = textBox_value8.Text;
            canshu9 = textBox_value9.Text;
            canshu10 = textBox_value10.Text;
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}
