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
    public partial class Config_Value : Form
    {
        public static string Value_Type = "";
        public static int address = 0;
        public Config_Value()
        {
            InitializeComponent();
            comboBox1.Items.Clear();
            comboBox1.Items.Add("DT");
            comboBox1.Items.Add("R");
        }

        public void Set_Title(string title)
        {
            label1.Text = title;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "") { MessageBox.Show("数据类型不能为空!"); return; }
            Value_Type = comboBox1.Text;
            address = (int)numericUpDown1.Value;
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void Config_Value_Load(object sender, EventArgs e)
        {

        }
    }
}
