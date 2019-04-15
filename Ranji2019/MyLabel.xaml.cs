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
using FileOperation;
using System.Collections;

namespace Ranji2019
{
    /// <summary>
    /// MyLabel.xaml 的交互逻辑
    /// </summary>
    public partial class MyLabel : UserControl
    {
        public string Value_Name = "";                      // 标签的值
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();                    // 更新的时钟
        public int mode = 0;                    // 模式=0：  显示内容
                                                // 模式=1：  显示数字
                                                // 模式=2：  显示数字/10
                                                // 模式=3：  显示对秒计时的时间
                                                // 模式=5:   显示数字+1
                                                // 模式=6;   显示分段字符串
                                                             // 分段字符串写在配置文件中，名字写在type字段中

                                                // 模式=7;   显示分段颜色
                                                             // 分段颜色写在配置文件中，名字写在type字段中

        public IniFile inifile = null;
        public IniFile config_inifile = null;
        public MyLabel(IniFile ini)
        {
            InitializeComponent();

            // 设置时钟
            timer.Interval = 300;
            timer.Tick += new EventHandler(Tick);
            timer.Enabled = true;

            inifile = ini;               //配置文件

            ReSet();
        }

        public void Set_Color(string color)
        {
            BrushConverter brushConverter = new BrushConverter();
            mylabel.Background = (Brush)brushConverter.ConvertFromString(color);
        }

        public void Set_Text(string txt)
        {
            mylabel.Content = txt;
        }

        private void Tick(object sender,EventArgs e)
        {
            ReSet();
            // 更新消息
            // mode=0
            #region
            if (mode == 0)
            {

            }
            #endregion     // mode=0
            // mode=1
            #region
            if (mode == 1)
            {
                string type = inifile.IniReadValue(Value_Name, "type");
                string address = inifile.IniReadValue(Value_Name,"address");
                string machine_num=inifile.IniReadValue(Value_Name,"machine_num");
                try
                {
                    if(type=="DT")
                    {
                        Set_Text(RealTime_data.DT[int.Parse(machine_num), int.Parse(address)].ToString());
                        return;
                    }
                    Set_Text("??");

                }
                catch { Set_Text("??"); }
            }
            #endregion
            // mode=2
            #region
            if (mode == 2)
            {
                string type = inifile.IniReadValue(Value_Name, "type");
                string address = inifile.IniReadValue(Value_Name, "address");
                string machine_num = inifile.IniReadValue(Value_Name, "machine_num");
                try
                {
                    if (type == "DT")
                    {
                        double value = RealTime_data.DT[int.Parse(machine_num), int.Parse(address)];
                        value = value / 10;
                        Set_Text(value.ToString());
                        return;
                    }
                    Set_Text("??");

                }
                catch { Set_Text("??"); }
            }
            #endregion
            // mode=3
            #region
            if (mode == 3)
            {
                string type = inifile.IniReadValue(Value_Name, "type");
                string address = inifile.IniReadValue(Value_Name, "address");
                string machine_num = inifile.IniReadValue(Value_Name, "machine_num");
                try
                {
                    if (type == "DT")
                    {
                        int value = RealTime_data.DT[int.Parse(machine_num), int.Parse(address)];

                        DateTime mytime = DateTime.Parse("00:00:00");
                        mytime.AddMinutes(value);
                        Set_Text(mytime.ToString("HH:mm:ss"));
                        return;
                    }
                    Set_Text("??:??:??");

                }
                catch { Set_Text("??:??:??"); }
            }
            #endregion
            // mode=5
            #region
            if (mode == 5)
            {
                string type = inifile.IniReadValue(Value_Name, "type");
                string address = inifile.IniReadValue(Value_Name, "address");
                string machine_num = inifile.IniReadValue(Value_Name, "machine_num");
                try
                {
                    if (type == "DT")
                    {
                        int value = RealTime_data.DT[int.Parse(machine_num), int.Parse(address)];
                        value = value + 1;
                        Set_Text(value.ToString());
                        return;
                    }
                    Set_Text("??");

                }
                catch { Set_Text("??"); }
            }
            #endregion
            // mode=6
            // 分段字符串
            #region
            try
            {
                if (mode == 6)
                {
                    if (config_inifile == null) return;
                    if (Value_Name == "") return;
                    ArrayList allname = config_inifile.ReadSections();

                    string type = inifile.IniReadValue(Value_Name, "type");
                    string address = inifile.IniReadValue(Value_Name, "address");
                    string machine_num = inifile.IniReadValue(Value_Name, "machine_num");
                    int myvalue = -1;
                    try
                    {
                        if (type == "DT")
                        {
                            myvalue = RealTime_data.DT[int.Parse(machine_num), int.Parse(address)];
                        }
                    }
                    catch { }
                    foreach (string index in allname)
                    {
                        if (double.Parse(index) == myvalue)
                        {
                            string value = config_inifile.IniReadValue(index, "gongyi");
                            Set_Text(value);
                            return;
                        }
                    }
                }
                
            }
            catch { }
            #endregion
            // mode=7
            // 颜色
            #region
            try
            {
                if (mode == 7)
                {
                    if (config_inifile == null) return;
                    if (Value_Name == "") return;
                    ArrayList allname = config_inifile.ReadSections();
                    string type = inifile.IniReadValue(Value_Name, "type");
                    string address = inifile.IniReadValue(Value_Name, "address");
                    string machine_num = inifile.IniReadValue(Value_Name, "machine_num");
                    int myvalue = -1;
                    try
                    {
                        if (type == "DT")
                        {
                            myvalue = RealTime_data.DT[int.Parse(machine_num), int.Parse(address)];
                        }
                        if (type == "R")
                        {
                            myvalue = RealTime_data.R[int.Parse(machine_num), int.Parse(address)];
                        }

                        foreach (string index in allname)
                        {
                            if (double.Parse(index) == myvalue)
                            {
                                string value = config_inifile.IniReadValue(index, "color");

                                Set_Color(value);
                                return;
                            }
                        }


                    }
                    catch { }
                }
            }
            catch { }
            #endregion
        }

        public void ReSet()
        {
            mylabel.Margin = new Thickness(0, 0, 0, 0);
            mylabel.Width = this.Width;
            mylabel.Height = this.Height;
            rectangle.Margin = new Thickness(0, 0, 0, 0);
            rectangle.Width = this.Width;
            rectangle.Height = this.Height;
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ReSet();
        }
    }
}
