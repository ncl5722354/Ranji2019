using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YinRan2020
{
    public partial class Add_Craft_Final : Form
    {
        static string value1_title = "";
        static string value2_title = "";
        static string value3_title = "";
        static string value4_title = "";
        static string value5_title = "";
        static string value6_title = "";
        static string value7_title = "";
        static string value8_title = "";
        static string value9_title = "";
        static string value10_title = "";
        
        public  static string gongyi = "";

        public  static string value1 = "";
        public  static string value2 = "";
        public  static string value3 = "";
        public  static string value4 = "";
        public  static string value5 = "";
        public  static string value6 = "";
        public  static string value7 = "";
        public  static string value8 = "";
        public  static string value9 = "";
        public  static string value10 = "";
        
        public void set_title(string title)
        {
            label_title.Text = title;
        }
        public Add_Craft_Final()
        {
            InitializeComponent();

            comboBox_craft.Items.Clear();

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            value1 = textBox_value1.Text;
            value2 = textBox_value2.Text;
            value3 = textBox_value3.Text;
            value4 = textBox_value4.Text;
            value5 = textBox_value5.Text;
            value6 = textBox_value6.Text;
            value7 = textBox_value7.Text;
            value8 = textBox_value8.Text;
            value9 = textBox_value9.Text;
            value10 = textBox_value10.Text;
            gongyi = comboBox_craft.Text;
            DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void comboBox_craft_TextChanged(object sender, EventArgs e)
        {
            string key = comboBox_craft.Text;
            string where_cmd = "Gongyi_Name='" + key + "'";
            DataTable dt = MainView.builder.Select_Table("Craft_Name_Table",where_cmd);
            if(dt==null)
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
    }
}
