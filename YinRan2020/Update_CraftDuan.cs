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
    public partial class Update_CraftDuan : Form
    {
        public static string value1 = "";
        public static string value2 = "";
        public static string craft_name = "";
        public static string zhubengpinlv = "";
        public static string tibupinlv = "";
        public static string ID = "";
        public static string fengjipinlv = "";

        public Update_CraftDuan()
        {
            InitializeComponent();
            textBox_value1.Text = value1;
            textBox_value2.Text = value2;
            comboBox_craft.Text = craft_name;
            textBox_zhubengpinlv.Text = zhubengpinlv;
            textBox_tibupinlv.Text = tibupinlv;
            textBox_fengjipinlv.Text = fengjipinlv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            value1 = textBox_value1.Text;
            value2 = textBox_value2.Text;
            craft_name = comboBox_craft.Text;
            zhubengpinlv = textBox_zhubengpinlv.Text;
            tibupinlv = textBox_tibupinlv.Text;
            fengjipinlv = textBox_fengjipinlv.Text;
            DialogResult = DialogResult.OK;

            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void Set_Title(string title)
        {
            label_title.Text = title;
        }

    }
}
