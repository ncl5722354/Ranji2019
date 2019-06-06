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
    public partial class Add_Craft_info : Form
    {
        public  static string mode = "";
        public  static string address = "";
        public  static string row = "";
        public  static string col = "";
        public Add_Craft_info()
        {
            InitializeComponent();
            comboBox_mode.Items.Clear();
            comboBox_mode.Items.Add("单个");
            comboBox_mode.Items.Add("整列");
        }

        public void Set_Title(string title)
        {
            label_title.Text = title;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mode = comboBox_mode.Text;
            address = textBox_address.Text;
            row = textBox_row.Text;
            col = textBox_col.Text;
            DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
