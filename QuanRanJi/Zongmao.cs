using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewConfig;

namespace QuanRanJi
{
    public partial class Zongmao : Form
    {
        public event EventHandler EnterToXiangxi = null;
        public int change_xiangxi_machine_num = 0;
        public Zongmao()
        {
            this.TopLevel = false;
            InitializeComponent();
            init_view();
        }

        public void init_view()
        {
            ViewCaoZuo.Object_Position(0.01, 0.01, 0.25, 0.45, zongmaoItem1, this.Controls);
            ViewCaoZuo.Object_Position(0.26, 0.01, 0.25, 0.45, zongmaoItem2, this.Controls);
            ViewCaoZuo.Object_Position(0.52, 0.01, 0.25, 0.45, zongmaoItem3, this.Controls);
            ViewCaoZuo.Object_Position(0.01, 0.5, 0.25, 0.45, zongmaoItem4, this.Controls);
            ViewCaoZuo.Object_Position(0.26, 0.5, 0.25, 0.45, zongmaoItem5, this.Controls);
            ViewCaoZuo.Object_Position(0.52, 0.5, 0.25, 0.45, zongmaoItem6, this.Controls);

            zongmaoItem1.Enter_Xiangxi += new EventHandler(enter_xiangxi);
            zongmaoItem2.Enter_Xiangxi += new EventHandler(enter_xiangxi);
            zongmaoItem3.Enter_Xiangxi += new EventHandler(enter_xiangxi);
            zongmaoItem4.Enter_Xiangxi += new EventHandler(enter_xiangxi);
            zongmaoItem5.Enter_Xiangxi += new EventHandler(enter_xiangxi);
            zongmaoItem6.Enter_Xiangxi += new EventHandler(enter_xiangxi);
           
        }

        private void enter_xiangxi(object sender, EventArgs e)
        {
            ZongmaoItem item = (ZongmaoItem)sender;
            int machine_num = item.Get_Machine_Num();
            change_xiangxi_machine_num = machine_num;
            if(EnterToXiangxi!=null)
            {
                EnterToXiangxi(this, new EventArgs());
            }
        }

        public void Set_Page(int page)
        {
            init_view();
            zongmaoItem1.Set_Machine_Num((page - 1) * 6 + 1);
            zongmaoItem2.Set_Machine_Num((page - 1) * 6 + 2);
            zongmaoItem3.Set_Machine_Num((page - 1) * 6 + 3);
            zongmaoItem4.Set_Machine_Num((page - 1) * 6 + 4);
            zongmaoItem5.Set_Machine_Num((page - 1) * 6 + 5);
            zongmaoItem6.Set_Machine_Num((page - 1) * 6 + 6);
            
        }
    }
}
