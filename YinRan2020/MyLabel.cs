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
        private int DT_Address = 0;               // 对应的DT地址


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

        public int Device_Address
        {
            get
            {
                return DT_Address;
            }
            set
            {
                DT_Address = value;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }


    }
}
