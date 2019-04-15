using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewConfig;

namespace QuanRanJi
{
   
    public partial class ZongmaoItem : UserControl
    {

        public event EventHandler Enter_Xiangxi = null;
        private int mymachine_num = 0;
        public ZongmaoItem()
        {
            InitializeComponent();
            init_view();
        }

        private void init_view()
        {
            ViewCaoZuo.Object_Position(0.01, 0.01, 0.1, 0.03, label_machine_num, this.Controls);
        }

        public void Set_Machine_Num(int num)
        {
            // 设定总貌界面的号码
            label_machine_num.Text = num.ToString()+"号机";
            mymachine_num = num;
        }

        public int Get_Machine_Num()
        {
            return mymachine_num;
        }

        private void label_machine_num_Click(object sender, EventArgs e)
        {
            if (Enter_Xiangxi != null)
            {
                Enter_Xiangxi(this, new EventArgs());
            }
        }
    }
}
