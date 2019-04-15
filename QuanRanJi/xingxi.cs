using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanRanJi
{
    public partial class xiangxi : Form
    {
        private int mymachine_num = 0;
        public xiangxi()
        {
            InitializeComponent();
        }

        public void Set_Machine_Num(int machine_num)
        {
            mymachine_num = machine_num;
            label_machine_num.Text = mymachine_num.ToString() + "号机";
        }

        private void label33_Click(object sender, EventArgs e)
        {

        }
    }
}
