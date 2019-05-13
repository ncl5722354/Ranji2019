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
    public partial class Deivce_Info : Form
    {
        public Deivce_Info()
        {
            InitializeComponent();
            init_view();
        }

        private void init_view()
        {
            // 标题
            ViewCaoZuo.Object_Position(0, 0, 1, 0.05, label_title, this.Controls);

            // 工具栏
            ViewCaoZuo.Object_Position(0, 0.05, 1, 0.05, panel_tool, this.Controls);

            ViewCaoZuo.Object_Position(0, 0, 1, 1, toolStrip1, panel_tool.Controls);
        }

        public void Set_Chenjian(string name)
        {
            label_title.Text = name + "设备设置";
        }

        private void Deivce_Info_Resize(object sender, EventArgs e)
        {
            init_view();
        }
    }
}
