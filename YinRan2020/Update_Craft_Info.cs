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
    public partial class Update_Craft_Info : Form
    {
        public static string mode = "";
        public static string address = "";
        public static string row = "";
        public static string col = "";
        public static string ID = "";
        public Update_Craft_Info()
        {
            InitializeComponent();
            comboBox_mode.Text = mode;
            textBox_address.Text = address;
            textBox_row.Text = row;
            textBox_col.Text = col;

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
