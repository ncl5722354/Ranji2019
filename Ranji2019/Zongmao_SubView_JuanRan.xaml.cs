﻿using System;
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
    /// Zongmao_SubView_JuanRan.xaml 的交互逻辑
    /// </summary>
    public partial class Zongmao_SubView_JuanRan : UserControl
    {

        public int machine_num = 0;
        public Zongmao_SubView_JuanRan()
        {
            InitializeComponent();
            init_view();
        }

        // 定义界面信息
        #region
        // 温度标签
        private MyLabel MyLabel_Wendu_Label = new MyLabel(MainWindow.Usercontrol_Config);
           
           // 温度显示
        private MyLabel MyLabel_Wendu_Show = new MyLabel(MainWindow.Usercontrol_Config);
           
           // 水位标签
        private MyLabel MyLabel_ShuiWei_Label = new MyLabel(MainWindow.Usercontrol_Config);
           
           // 水位显示
        private MyLabel MyLabel_ShuiWei_Show = new MyLabel(MainWindow.Usercontrol_Config);
           
           // 转速1标签
        private MyLabel MyLabel_Zhuansu_Label = new MyLabel(MainWindow.Usercontrol_Config);

          //  转速1显示
        private MyLabel MyLabel_Zhuansu_Show = new MyLabel(MainWindow.Usercontrol_Config);

          //  转速2标签
        private MyLabel MyLabel_Zhuansu2_Label = new MyLabel(MainWindow.Usercontrol_Config);

          // 转速2显示
        private MyLabel MyLabel_Zhuansu2_Show = new MyLabel(MainWindow.Usercontrol_Config);

<<<<<<< HEAD
=======
          // 张力标签
        private MyLabel MyLabel_Zhangli_Label = new MyLabel(MainWindow.Usercontrol_Config);

          // 张力显示
        private MyLabel MyLabel_Zhangli_Show = new MyLabel(MainWindow.Usercontrol_Config);


          // 启动标签
        private MyLabel MyLabel_Start_Show = new MyLabel(MainWindow.Usercontrol_Config);

          // 暂停标签 
        private MyLabel MyLabel_Pause_Show = new MyLabel(MainWindow.Usercontrol_Config);
>>>>>>> faf0363c8b660ee6bed408897fdc14387bfc404c
        #endregion



        public void Set_Machine_Num(int mynum)
        {
            machine_num = mynum;
<<<<<<< HEAD
=======
            // 设置变量名
>>>>>>> faf0363c8b660ee6bed408897fdc14387bfc404c
            label_machine_num.Content = mynum.ToString() + "机号";

            MyLabel_Wendu_Show.Value_Name = "主缸温度" + machine_num.ToString();

            MyLabel_ShuiWei_Show.Value_Name = "主缸水位" + machine_num.ToString();

            MyLabel_Zhuansu_Show.Value_Name = "转速1" + machine_num.ToString();

            MyLabel_Zhuansu2_Show.Value_Name = "转速2" + machine_num.ToString();

<<<<<<< HEAD
=======
            MyLabel_Zhangli_Show.Value_Name = "张力" + machine_num.ToString();

            MyLabel_Start_Show.Value_Name = "开始" + machine_num.ToString();

            MyLabel_Pause_Show.Value_Name = "暂停" + machine_num.ToString();
>>>>>>> faf0363c8b660ee6bed408897fdc14387bfc404c
            
        }

        // 初始化界面 信息
        private void init_view()
        {
            // 温度标签
            maingrid.Children.Add(MyLabel_Wendu_Label);
            MyLabel_Wendu_Label.Margin = new Thickness(MainWindow.screen_width * 0.001, MainWindow.scree_height * 0.07, 0, 0);
            MyLabel_Wendu_Label.Width = MainWindow.screen_width * 0.05;
            MyLabel_Wendu_Label.Height = MainWindow.scree_height * 0.04;
            MyLabel_Wendu_Label.mode = 0;
            MyLabel_Wendu_Label.Set_Text("主缸温度");
            
            // 温度显示
            maingrid.Children.Add(MyLabel_Wendu_Show);
            MyLabel_Wendu_Show.Margin = new Thickness(MainWindow.screen_width * 0.06, MainWindow.scree_height * 0.07, 0, 0);
            MyLabel_Wendu_Show.Width = MainWindow.screen_width * 0.1;
            MyLabel_Wendu_Show.Height = MainWindow.scree_height * 0.04;
            MyLabel_Wendu_Show.mode = 1;

            // 水位标签
            maingrid.Children.Add(MyLabel_ShuiWei_Label);
            MyLabel_ShuiWei_Label.Margin = new Thickness(MainWindow.screen_width * 0.001, MainWindow.scree_height * 0.12, 0, 0);
            MyLabel_ShuiWei_Label.Width = MainWindow.screen_width * 0.05;
            MyLabel_ShuiWei_Label.Height = MainWindow.scree_height * 0.04;
            MyLabel_ShuiWei_Label.mode = 0;
            MyLabel_ShuiWei_Label.Set_Text("主缸液位");

            // 水位显示
            maingrid.Children.Add(MyLabel_ShuiWei_Show);
            MyLabel_ShuiWei_Show.Margin = new Thickness(MainWindow.screen_width * 0.06, MainWindow.scree_height * 0.12, 0, 0);
            MyLabel_ShuiWei_Show.Width = MainWindow.screen_width * 0.1;
            MyLabel_ShuiWei_Show.Height = MainWindow.scree_height * 0.04;
            MyLabel_ShuiWei_Show.mode = 1;

            // 转速1标签
            maingrid.Children.Add(MyLabel_Zhuansu_Label);
            MyLabel_Zhuansu_Label.Margin = new Thickness(MainWindow.screen_width * 0.001, MainWindow.scree_height * 0.17, 0, 0);
            MyLabel_Zhuansu_Label.Width = MainWindow.screen_width * 0.05;
            MyLabel_Zhuansu_Label.Height = MainWindow.scree_height * 0.04;
            MyLabel_Zhuansu_Label.mode = 0;
            MyLabel_Zhuansu_Label.Set_Text("转速1");

            // 转速1显示
            maingrid.Children.Add(MyLabel_Zhuansu_Show);
            MyLabel_Zhuansu_Show.Margin = new Thickness(MainWindow.screen_width * 0.06, MainWindow.scree_height * 0.17, 0, 0);
            MyLabel_Zhuansu_Show.Width = MainWindow.screen_width * 0.1;
            MyLabel_Zhuansu_Show.Height = MainWindow.scree_height * 0.04;
            MyLabel_Zhuansu_Show.mode = 1;

            // 转速2标签
            maingrid.Children.Add(MyLabel_Zhuansu2_Label);
            MyLabel_Zhuansu2_Label.Margin = new Thickness(MainWindow.screen_width * 0.001, MainWindow.scree_height * 0.22, 0, 0);
            MyLabel_Zhuansu2_Label.Width = MainWindow.screen_width * 0.05;
            MyLabel_Zhuansu2_Label.Height = MainWindow.scree_height * 0.04;
            MyLabel_Zhuansu2_Label.mode = 0;
            MyLabel_Zhuansu2_Label.Set_Text("转速2");

            // 转速2显示
            maingrid.Children.Add(MyLabel_Zhuansu2_Show);
            MyLabel_Zhuansu2_Show.Margin = new Thickness(MainWindow.screen_width * 0.06, MainWindow.scree_height * 0.22, 0, 0);
            MyLabel_Zhuansu2_Show.Width = MainWindow.screen_width * 0.1;
            MyLabel_Zhuansu2_Show.Height = MainWindow.scree_height * 0.04;
            MyLabel_Zhuansu2_Show.mode = 1;
<<<<<<< HEAD
=======

            // 张力标签
            maingrid.Children.Add(MyLabel_Zhangli_Label);
            MyLabel_Zhangli_Label.Margin = new Thickness(MainWindow.screen_width * 0.001, MainWindow.scree_height * 0.27, 0, 0);
            MyLabel_Zhangli_Label.Width = MainWindow.screen_width * 0.05;
            MyLabel_Zhangli_Label.Height = MainWindow.scree_height * 0.04;
            MyLabel_Zhangli_Label.mode = 0;
            MyLabel_Zhangli_Label.Set_Text("张力");

            // 张力显示
            maingrid.Children.Add(MyLabel_Zhangli_Show);
            MyLabel_Zhangli_Show.Margin = new Thickness(MainWindow.screen_width * 0.06, MainWindow.scree_height * 0.27, 0, 0);
            MyLabel_Zhangli_Show.Width = MainWindow.screen_width * 0.1;
            MyLabel_Zhangli_Show.Height = MainWindow.scree_height * 0.04;
            MyLabel_Zhangli_Show.mode = 1;

            // 开始显示 
            maingrid.Children.Add(MyLabel_Start_Show);
            MyLabel_Start_Show.Margin = new Thickness(MainWindow.screen_width * 0.02, MainWindow.scree_height * 0.32, 0, 0);
            MyLabel_Start_Show.Width = MainWindow.screen_width * 0.07;
            MyLabel_Start_Show.Height = MainWindow.scree_height * 0.04;
            MyLabel_Start_Show.mode = 7;
            MyLabel_Start_Show.Set_Text("启动");
            MyLabel_Start_Show.config_inifile = MainWindow.Color_Config;

            // 暂停显示
            maingrid.Children.Add(MyLabel_Pause_Show);
            MyLabel_Pause_Show.Margin = new Thickness(MainWindow.screen_width * 0.12, MainWindow.scree_height * 0.32, 0, 0);
            MyLabel_Pause_Show.Width = MainWindow.screen_width * 0.07;
            MyLabel_Pause_Show.Height = MainWindow.scree_height * 0.04;
            MyLabel_Pause_Show.mode = 7;
            MyLabel_Pause_Show.Set_Text("暂停");
            MyLabel_Pause_Show.config_inifile = MainWindow.Color_Config;

>>>>>>> faf0363c8b660ee6bed408897fdc14387bfc404c
        }
    }
}
