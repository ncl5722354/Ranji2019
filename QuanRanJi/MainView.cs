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
    public partial class MainView : Form
    {
        // 总貌画面
        Zongmao zongmao1 = new Zongmao();
        // 详细页面
        xiangxi xiangxi1 = new xiangxi();
        public MainView()
        {
            InitializeComponent();
            ViewCaoZuo.Max_Form(this);
            init_view();
        }

        private void init_view()
        {
            ViewCaoZuo.Object_Position(0.01, 0.01, 0.1, 0.9, treeView_main, this.Controls);
            ViewCaoZuo.Object_Position(0.12, 0.01, 0.8, 0.9, panel_subview, this.Controls);
            ViewCaoZuo.Object_Position(0.92, 0.01, 0.06, 0.04, button_close, this.Controls);
            ViewCaoZuo.Show_Form_In_Panel(zongmao1,panel_subview);

            // 总貌的进去详细页面的事件
            zongmao1.EnterToXiangxi += new EventHandler(ChangeToXiangxi);
        }

        private void treeView_main_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selected_text = treeView_main.SelectedNode.Text;
            switch (selected_text)
            {
                case "总貌1（1-6）":
                    zongmao1.Set_Page(1);
                    ViewCaoZuo.Show_Form_In_Panel(zongmao1, panel_subview);
                    break;
                case "总貌2（7-12）":
                    zongmao1.Set_Page(2);
                    ViewCaoZuo.Show_Form_In_Panel(zongmao1, panel_subview);
                    break;
                case "总貌3（13-18）":
                    zongmao1.Set_Page(3);
                    ViewCaoZuo.Show_Form_In_Panel(zongmao1, panel_subview);
                    break;
                case "总貌4（19-24）":
                    zongmao1.Set_Page(4);
                    ViewCaoZuo.Show_Form_In_Panel(zongmao1, panel_subview);
                    break;
                case "总貌5（25-30）":
                    zongmao1.Set_Page(5);
                    ViewCaoZuo.Show_Form_In_Panel(zongmao1, panel_subview);
                    break;
                case "总貌6（31-36）":
                    zongmao1.Set_Page(6);
                    ViewCaoZuo.Show_Form_In_Panel(zongmao1, panel_subview);
                    break;
                case "总貌7（37-42）":
                    zongmao1.Set_Page(7);
                    ViewCaoZuo.Show_Form_In_Panel(zongmao1, panel_subview);
                    break;
                case "总貌8（43-48）":
                    zongmao1.Set_Page(8);
                    ViewCaoZuo.Show_Form_In_Panel(zongmao1, panel_subview);
                    break;
                case "总貌9（49-54）":
                    zongmao1.Set_Page(9);
                    ViewCaoZuo.Show_Form_In_Panel(zongmao1, panel_subview);
                    break;
            }

        }

        private void ChangeToXiangxi(object sender,EventArgs e)
        {
            int num = zongmao1.change_xiangxi_machine_num;
            xiangxi1.Set_Machine_Num(num);
            ViewCaoZuo.Show_Form_In_Panel(xiangxi1, panel_subview);
        }



        
    }
}
