using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using SqlConnect;

namespace YinRan2020
{
    public partial class AddCraft : Form
    {
        public static string Chejian_Name;                 // 车间名称
        public AddCraft()
        {
            InitializeComponent();
            init_view();
        }

        public void init_view()
        {
            // 初始化
            // 通讯协议
            comboBox_tongxunxieyi.Items.Clear();
            comboBox_tongxunxieyi.Items.Add("松下ModBus协议");
            comboBox_tongxunxieyi.Items.Add("松下专用协议");
            // 设备种类
            comboBox_shebeizhonglei.Items.Clear();
            comboBox_shebeizhonglei.Items.Add("溢流缸");
            comboBox_shebeizhonglei.Items.Add("气流缸");

            // 通讯端口
            comboBox_tongxunduankou.Items.Clear();
            comboBox_tongxunduankou.Items.Add("串口1");
            comboBox_tongxunduankou.Items.Add("串口2");
            comboBox_tongxunduankou.Items.Add("串口3");
            comboBox_tongxunduankou.Items.Add("串口4");
            comboBox_tongxunduankou.Items.Add("串口5");
            comboBox_tongxunduankou.Items.Add("串口6");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 添加设备
            string[] insert_cmd = new string[7];
            insert_cmd[0] = textBox_text_Device_Name.Text;          // ID
            insert_cmd[1] = textBox_text_Device_Name.Text;          // 名字
            insert_cmd[2] = Chejian_Name;                          // 车间名
            insert_cmd[3] = comboBox_shebeizhonglei.Text;           // 设备种类
            insert_cmd[4] = comboBox_tongxunduankou.Text;           // 通讯种类
            insert_cmd[5] = numericUpDown_zhanhao.Value.ToString(); // 站号
            insert_cmd[6] = comboBox_tongxunxieyi.Text;             // 通讯协议
            bool result =  MainView.builder.Insert("Device_Info", insert_cmd);
            if(result==true)
               this.Dispose();
        }
    }
}
