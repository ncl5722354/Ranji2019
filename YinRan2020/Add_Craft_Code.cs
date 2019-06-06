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
    public partial class Add_Craft_Code : Form
    {
        public static string craft_name = "";
        public static string craft_code = "";
        public Add_Craft_Code()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox_craft_code.Text=="")
            {
                MessageBox.Show("工艺代码不能空！");
                return;
            }
            if(textBox_craft_name.Text=="")
            {
                MessageBox.Show("工艺名称不能为空！");
                return;
            }
            craft_name = textBox_craft_name.Text;
            craft_code = textBox_craft_code.Text;
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
