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

            comboBox_craft.Items.Clear();
            try
            {
                DataTable dt = MainView.builder.Select_Table("Craft_Name_Table");
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox_craft.Items.Add(dr[0].ToString());
                }
            }
            catch { }
            comboBox_craft.Text = Craft_Name;
            string key = comboBox_craft.Text;
            if (key == "升温" || key == "降温")
            {
                label2.Visible = true;
                textBox_sulv.Visible = true;
            }
            else
            {
                label2.Visible = false;
                textBox_sulv.Visible = false;
            }
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
            Craft_Name = comboBox_craft.Text;
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

        private void Update_Craft_Final_Load(object sender, EventArgs e)
        {

        }

        private void comboBox_craft_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = comboBox_craft.Text;
            string where_cmd = "Gongyi_Name='" + key + "'";
            DataTable dt = MainView.builder.Select_Table("Craft_Name_Table", where_cmd);
            if (dt == null)
            {
                label_value1.Text = "参数1说明";
                label_value2.Text = "参数2说明";
                label_value3.Text = "参数3说明";
                label_value4.Text = "参数4说明";
                label_value5.Text = "参数5说明";
                label_value6.Text = "参数6说明";
                label_value7.Text = "参数7说明";
                label_value8.Text = "参数8说明";
                label_value9.Text = "参数9说明";
                label_value10.Text = "参数10说明";
            }
            else
            {
                DataRow dr = dt.Rows[0];
                label_value1.Text = dr[1].ToString();
                label_value2.Text = dr[2].ToString();
                label_value3.Text = dr[3].ToString();
                label_value4.Text = dr[4].ToString();
                label_value5.Text = dr[5].ToString();
                label_value6.Text = dr[6].ToString();
                label_value7.Text = dr[7].ToString();
                label_value8.Text = dr[8].ToString();
                label_value9.Text = dr[9].ToString();
                label_value10.Text = dr[10].ToString();
            }
        }

        private void textBox_sulv_TextChanged(object sender, EventArgs e)
        {
            string key = comboBox_craft.Text;


            if (key == "升温" || key == "降温")
            {
                try
                {
                    double time = Math.Abs(double.Parse(textBox_value1.Text) - double.Parse(textBox_value2.Text)) / Math.Abs(double.Parse(textBox_sulv.Text));
                    int mytime = (int)(time);
                    textBox_value3.Text = mytime.ToString();
                }
                catch { textBox_value3.Text = "0"; }
            }
        }

        private void textBox_value1_Click(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            textbox.SelectAll();
        }
    }
}
