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
    public partial class Add_CraftDuan : Form
    {
        public static string value1 = "";
        public static string value2 = "";
        public static string craft_name = "";
        public static string zhubengpinlv = "";
        public static string tibupinlv = "";

        public Add_CraftDuan()
        {
            InitializeComponent();

            DataTable dt = MainView.builder.Select_Table("Craft_Name_Code");
            comboBox_craft.Items.Clear();
            foreach(DataRow dr in dt.Rows)
            {
                comboBox_craft.Items.Add(dr[0]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void Set_Title(string title)
        {
            label_title.Text = title;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_value1.Text == "") { MessageBox.Show("参数1不能为空！"); return; }
            if (textBox_value2.Text == "") { MessageBox.Show("参数2不能为空！"); return; }
            if (comboBox_craft.Text == "") { MessageBox.Show("工艺不能为空！"); return; }
            if (textBox_zhubengpinlv.Text == "") { MessageBox.Show("主泵频率不能为空！"); return; }
            if (textBox_tibupinlv.Text == "") { MessageBox.Show("提布频率不能为空！"); return; }
            value1 = textBox_value1.Text;
            value2 = textBox_value2.Text;
            craft_name = comboBox_craft.Text;
            zhubengpinlv = textBox_zhubengpinlv.Text;
            tibupinlv = textBox_tibupinlv.Text;
            DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}
