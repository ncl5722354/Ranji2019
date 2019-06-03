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
    public partial class UpdateCraft_Code : Form
    {
        public static string craft_name = "";
        public static string craft_code = "";

        public UpdateCraft_Code()
        {
            InitializeComponent();
            textBox_craft_name.Text = craft_name;
            textBox_craft_code.Text = craft_code;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox_craft_code.Text=="")
            {
                MessageBox.Show("工艺代码不能为空！");
                return;
            }

            string[] update_cmd = new string[1];
            update_cmd[0] = "Craft_Code='" + textBox_craft_code.Text + "'";

            string where_cmd = "Craft_Name='" + textBox_craft_name.Text + "'";

            MainView.builder.Updata("Craft_Name_Code",where_cmd,update_cmd);
            this.Dispose();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
