using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YinRan2020
{
    public partial class MyLabel : UserControl
    {

        private string device_name = "";          // 设备名称属性
        //private string value_name = "";              // 对应的DT地址

        private value_name MyValue_Name=value_name.机缸温度;
        public enum value_name
        {
            // 模拟量输出
            机缸温度,
            料缸温度,
            机缸水位,
            料缸水位,
            主泵频率,
            运行段号,
            提布频率1,
            提布频率2
        };


        public MyLabel()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }


        // 属性的定义
        public string Device_Name
        {
            get
            {
                return device_name;
            }
            set
            {
                device_name = value;
            }
        }

        public value_name Value_Name
        {
            get
            {
                return MyValue_Name;
            }
            set
            {
                MyValue_Name = value;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void label1_Resize(object sender, EventArgs e)
        {

        }

        private void MyLabel_Resize(object sender, EventArgs e)
        {
            label1.Top = 0;
            label1.Left = 0;
            label1.Width = this.Width;
            label1.Height = this.Height;
        }


    }
}
