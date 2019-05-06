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

namespace YinRan2020
{
    public partial class zongmao : Form
    {
        public zongmao()
        {
            InitializeComponent();
            init_view();
        }

        public void init_view()
        {
            // 初始化画面
            ViewCaoZuo.Object_Position(0, 0, 1, 0.05, label_title, this.Controls);
        }

        private void zongmao_SizeChanged(object sender, EventArgs e)
        {
            init_view();
        }

        public void Set_Chejian(string name)
        {
            label_title.Text = name + "实时生产情况";
        }


    }
}
