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
    /// Zongmao_Subview.xaml 的交互逻辑
    /// </summary>
    public partial class Zongmao_Subview : UserControl
    {
        public int machine_num = 0;
        public Zongmao_Subview()
        {
            InitializeComponent();
            init_view();                // 初始化界面
        }

        private MyLabel Label_Wendu = new MyLabel(MainWindow.Usercontrol_Config);                    // 温度字符标签
        private MyLabel Label_Wendu_Show = new MyLabel(MainWindow.Usercontrol_Config);               // 温度显示
       
        private MyLabel Label_Shuiwei = new MyLabel(MainWindow.Usercontrol_Config);                  // 主缸水位标签
        private MyLabel Label_Shuiwei_Show = new MyLabel(MainWindow.Usercontrol_Config);             // 主缸水位显示

        private MyLabel Label_ZhixingGongyi = new MyLabel(MainWindow.Usercontrol_Config);            // 执行工艺标签
        private MyLabel Label_ZhixingGongyi_Show = new MyLabel(MainWindow.Usercontrol_Config);       // 执行工艺显示

        private MyLabel Label_Gongyi_Shijian = new MyLabel(MainWindow.Usercontrol_Config);           // 工艺时间标签
        private MyLabel Label_Gongyi_Shijian_Show = new MyLabel(MainWindow.Usercontrol_Config);      // 工艺时间显示

        private MyLabel Label_Yunxing_Shijian = new MyLabel(MainWindow.Usercontrol_Config);          // 运行时间
        private MyLabel Label_Yunxing_Shijian_Show = new MyLabel(MainWindow.Usercontrol_Config);     // 运行时间显示

        private MyLabel Label_Start = new MyLabel(MainWindow.Usercontrol_Config);                    // 开始显示

        //private MyLabel Label_Stop = new MyLabel(MainWindow.Usercontrol_Config);                     // 

        private MyLabel Label_Pasue = new MyLabel(MainWindow.Usercontrol_Config);                    // 暂停

        public void Set_Machine_Num(int mynum)
        {
            machine_num = mynum;
            label_machine_num.Content = mynum.ToString() + "机号";

            // 标签值的设定

            // 主标温度标签名称
            Label_Wendu_Show.Value_Name = "主缸温度" + machine_num.ToString();

            // 主缸水位标签名称
            Label_Shuiwei_Show.Value_Name = "主缸水位" + machine_num.ToString();

            // 执行工艺标签名称
            Label_ZhixingGongyi_Show.Value_Name = "执行工艺" + machine_num.ToString();

            // 工艺时间标签名称
            Label_Gongyi_Shijian_Show.Value_Name = "工艺时间" + machine_num.ToString();

            // 运行时间标签名称
            Label_Yunxing_Shijian_Show.Value_Name = "运行时间" + machine_num.ToString();

            // 运行状态显示
            Label_Start.Value_Name = "开始" + machine_num.ToString();

            // 暂停状态显示
            Label_Pasue.Value_Name = "暂停" + machine_num.ToString();
        }

        // 初始化界面
        public void init_view()
        {
            // 机号标签
            label_machine_num.Margin = new Thickness(MainWindow.screen_width * 0.01, MainWindow.scree_height * 0.01, 0, 0);
            label_machine_num.Width = MainWindow.screen_width * 0.1;
            label_machine_num.Height = MainWindow.scree_height * 0.04;


            label_machine_num_frame.Margin = new Thickness(MainWindow.screen_width * 0.01, MainWindow.scree_height * 0.01, 0, 0);
            label_machine_num_frame.Width = MainWindow.screen_width * 0.1;
            label_machine_num_frame.Height = MainWindow.scree_height * 0.04;

            // 主缸温度
            maingrid.Children.Add(Label_Wendu);
            Label_Wendu.Margin = new Thickness(MainWindow.screen_width * 0.001, MainWindow.scree_height * 0.07, 0, 0);
            Label_Wendu.Width = MainWindow.screen_width * 0.05;
            Label_Wendu.Height = MainWindow.scree_height * 0.04;
            Label_Wendu.mode = 0;
            Label_Wendu.Set_Text("主缸温度");

            maingrid.Children.Add(Label_Wendu_Show);
            Label_Wendu_Show.Margin = new Thickness(MainWindow.screen_width * 0.06, MainWindow.scree_height * 0.07, 0, 0);
            Label_Wendu_Show.Width = MainWindow.screen_width * 0.1;
            Label_Wendu_Show.Height = MainWindow.scree_height * 0.04;
            Label_Wendu_Show.mode = 1;

            // 主缸水位
            maingrid.Children.Add(Label_Shuiwei);
            Label_Shuiwei.Margin = new Thickness(MainWindow.screen_width * 0.001, MainWindow.scree_height * 0.12, 0, 0);
            Label_Shuiwei.Width = MainWindow.screen_width * 0.05;
            Label_Shuiwei.Height = MainWindow.scree_height * 0.04;
            Label_Shuiwei.mode = 0;
            Label_Shuiwei.Set_Text("主缸水位");

            maingrid.Children.Add(Label_Shuiwei_Show);
            Label_Shuiwei_Show.Margin = new Thickness(MainWindow.screen_width * 0.06, MainWindow.scree_height * 0.12, 0, 0);
            Label_Shuiwei_Show.Width = MainWindow.screen_width * 0.1;
            Label_Shuiwei_Show.Height = MainWindow.scree_height * 0.04;
            Label_Shuiwei_Show.mode = 1;


            // 执行工艺
            maingrid.Children.Add(Label_ZhixingGongyi);
            Label_ZhixingGongyi.Margin = new Thickness(MainWindow.screen_width * 0.001, MainWindow.scree_height * 0.17, 0, 0);
            Label_ZhixingGongyi.Width = MainWindow.screen_width * 0.05;
            Label_ZhixingGongyi.Height = MainWindow.scree_height * 0.04;
            Label_ZhixingGongyi.mode = 0;
            Label_ZhixingGongyi.Set_Text("执行工艺");

            maingrid.Children.Add(Label_ZhixingGongyi_Show);
            Label_ZhixingGongyi_Show.Margin = new Thickness(MainWindow.screen_width * 0.06, MainWindow.scree_height * 0.17, 0, 0);
            Label_ZhixingGongyi_Show.Width = MainWindow.screen_width * 0.1;
            Label_ZhixingGongyi_Show.Height = MainWindow.scree_height * 0.04;
            Label_ZhixingGongyi_Show.mode = 6;
            Label_ZhixingGongyi_Show.config_inifile = MainWindow.Gongyi_Config;
            

            // 工艺时间
            maingrid.Children.Add(Label_Gongyi_Shijian);
            Label_Gongyi_Shijian.Margin = new Thickness(MainWindow.screen_width * 0.001, MainWindow.scree_height * 0.22, 0, 0);
            Label_Gongyi_Shijian.Width = MainWindow.screen_width * 0.05;
            Label_Gongyi_Shijian.Height = MainWindow.scree_height * 0.04;
            Label_Gongyi_Shijian.mode = 0;
            Label_Gongyi_Shijian.Set_Text("工艺时间");

            maingrid.Children.Add(Label_Gongyi_Shijian_Show);
            Label_Gongyi_Shijian_Show.Margin = new Thickness(MainWindow.screen_width * 0.06, MainWindow.scree_height * 0.22, 0, 0);
            Label_Gongyi_Shijian_Show.Width = MainWindow.screen_width * 0.1;
            Label_Gongyi_Shijian_Show.Height = MainWindow.scree_height * 0.04;
            Label_Gongyi_Shijian_Show.mode = 3;

            // 运行时间
            maingrid.Children.Add(Label_Yunxing_Shijian);
            Label_Yunxing_Shijian.Margin = new Thickness(MainWindow.screen_width * 0.001, MainWindow.scree_height * 0.27, 0, 0);
            Label_Yunxing_Shijian.Width = MainWindow.screen_width * 0.05;
            Label_Yunxing_Shijian.Height = MainWindow.scree_height * 0.04;
            Label_Yunxing_Shijian.mode = 0;
            Label_Yunxing_Shijian.Set_Text("运行时间");

            maingrid.Children.Add(Label_Yunxing_Shijian_Show);
            Label_Yunxing_Shijian_Show.Margin = new Thickness(MainWindow.screen_width * 0.06, MainWindow.scree_height * 0.27, 0, 0);
            Label_Yunxing_Shijian_Show.Width = MainWindow.screen_width * 0.1;
            Label_Yunxing_Shijian_Show.Height = MainWindow.scree_height * 0.04;
            Label_Yunxing_Shijian_Show.mode = 3;

            // 运行状态
            maingrid.Children.Add(Label_Start);
            Label_Start.Margin = new Thickness(MainWindow.screen_width * 0.001, MainWindow.scree_height * 0.32, 0, 0);
            Label_Start.Width = MainWindow.screen_width * 0.05;
            Label_Start.Height = MainWindow.scree_height * 0.04;
            Label_Start.mode = 7;
            Label_Start.Set_Text("运行");
            Label_Start.config_inifile = MainWindow.Color_Config;

            // 暂停状态
            maingrid.Children.Add(Label_Pasue);
            Label_Pasue.Margin = new Thickness(MainWindow.screen_width * 0.06, MainWindow.scree_height * 0.32, 0, 0);
            Label_Pasue.Width = MainWindow.screen_width * 0.05;
            Label_Pasue.Height = MainWindow.scree_height * 0.04;
            Label_Pasue.mode = 7;
            Label_Pasue.Set_Text("暂停");
            Label_Pasue.config_inifile = MainWindow.Color_Config;
        }
    }
}
