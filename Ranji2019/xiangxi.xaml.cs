using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ranji2019
{
    /// <summary>
    /// xiangxi.xaml 的交互逻辑
    /// </summary>
    public partial class xiangxi : UserControl
    {
        private int machine_num = 0;

        // 定义转速1标签
        private MyLabel MyLabel_Zhuansu1_Label = new MyLabel(MainWindow.Usercontrol_Config);

        // 定义转速1显示
        private MyLabel MyLabel_Zhuansu1_Show = new MyLabel(MainWindow.Usercontrol_Config);

        // 定义转速2标签
        private MyLabel MyLabel_Zhuansu2_Label = new MyLabel(MainWindow.Usercontrol_Config);

        // 定久转速2显示
        private MyLabel MyLabel_Zhuansu2_Show = new MyLabel(MainWindow.Usercontrol_Config);
        
        // 定义张力标签
        private MyLabel MyLabel_Zhangli_Label = new MyLabel(MainWindow.Usercontrol_Config);

        // 定义张力显示
        private MyLabel MyLabel_Zhangli_Show = new MyLabel(MainWindow.Usercontrol_Config);

        // 温度显示
       // private MyLabel MyLabel_Wawef
        public xiangxi()
        {
            InitializeComponent();
            init_view();
        }

        public void Set_Machine_Num(int mynum)
        {
            machine_num = mynum;

            // 转速1名称
            MyLabel_Zhuansu1_Show.Value_Name = "转速1" + machine_num.ToString();

            // 转速2名称
            MyLabel_Zhuansu2_Show.Value_Name = "转速2" + machine_num.ToString();

            // 定义张力名称
            MyLabel_Zhangli_Show.Value_Name = "张力" + machine_num.ToString();

            

        }

        private void init_view()
        {
            myimage.Width = MainWindow.screen_width * 0.5;
            myimage.Height = MainWindow.scree_height * 0.5;
            myimage.Margin = new Thickness(MainWindow.screen_width*0.01, MainWindow.scree_height*0.01, 0, 0);
            
            
            // 转速1标签
            maingrid.Children.Add(MyLabel_Zhuansu1_Label);
            MyLabel_Zhuansu1_Label.Margin = new Thickness(MainWindow.screen_width * 0.02, MainWindow.scree_height * 0.06, 0, 0);
            MyLabel_Zhuansu1_Label.Width = MainWindow.screen_width * 0.05;
            MyLabel_Zhuansu1_Label.Height = MainWindow.scree_height * 0.04;
            MyLabel_Zhuansu1_Label.mode = 0;
            MyLabel_Zhuansu1_Label.Set_Text("转速1");

            // 转速1显示
            maingrid.Children.Add(MyLabel_Zhuansu1_Show);
            MyLabel_Zhuansu1_Show.Margin = new Thickness(MainWindow.screen_width * 0.065, MainWindow.scree_height * 0.06, 0, 0);
            MyLabel_Zhuansu1_Show.Width = MainWindow.screen_width * 0.1;
            MyLabel_Zhuansu1_Show.Height = MainWindow.scree_height * 0.04;
            MyLabel_Zhuansu1_Show.mode = 1;

            // 转速2标签
            maingrid.Children.Add(MyLabel_Zhuansu2_Label);
            MyLabel_Zhuansu2_Label.Margin = new Thickness(MainWindow.screen_width * 0.32, MainWindow.scree_height * 0.06, 0, 0);
            MyLabel_Zhuansu2_Label.Width = MainWindow.screen_width * 0.05;
            MyLabel_Zhuansu2_Label.Height = MainWindow.scree_height * 0.04;
            MyLabel_Zhuansu2_Label.mode = 0;
            MyLabel_Zhuansu2_Label.Set_Text("转速2");

            // 转速2显示
            maingrid.Children.Add(MyLabel_Zhuansu2_Show);
            MyLabel_Zhuansu2_Show.Margin = new Thickness(MainWindow.screen_width * 0.365, MainWindow.scree_height * 0.06, 0, 0);
            MyLabel_Zhuansu2_Show.Width = MainWindow.screen_width * 0.1;
            MyLabel_Zhuansu2_Show.Height = MainWindow.scree_height * 0.04;
            MyLabel_Zhuansu2_Show.mode = 1;

            // 张力标签
            maingrid.Children.Add(MyLabel_Zhangli_Label);
            MyLabel_Zhangli_Label.Margin = new Thickness(MainWindow.screen_width * 0.35, MainWindow.scree_height * 0.3, 0, 0);
            MyLabel_Zhangli_Label.Width = MainWindow.screen_width * 0.05;
            MyLabel_Zhangli_Label.Height = MainWindow.scree_height * 0.04;
            MyLabel_Zhangli_Label.mode = 0;
            MyLabel_Zhangli_Label.Set_Text("张力");

            // 张力显示
            maingrid.Children.Add(MyLabel_Zhangli_Show);
            MyLabel_Zhangli_Show.Margin = new Thickness(MainWindow.screen_width * (0.045+0.35), MainWindow.scree_height * 0.3, 0, 0);
            MyLabel_Zhangli_Show.Width = MainWindow.screen_width * 0.1;
            MyLabel_Zhangli_Show.Height = MainWindow.scree_height * 0.04;
            MyLabel_Zhangli_Show.mode = 1;


        }
    }
}
