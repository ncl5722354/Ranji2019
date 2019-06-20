using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using ViewConfig;

namespace YinRan2020
{
    public partial class QiLiuGang : UserControl
    {
        public string JiGang_Name = "";
        public event EventHandler MyClick = null;
        public QiLiuGang()
        {
            InitializeComponent();
            init_view();

            
        }
        public void Set_Title(string name)
        {
            label_mengcheng.Text = name;
            JiGang_Name = name;
       
            
            
            // 显示标签的名字,必须设置!
            myLabel_wendu.Device_Name = name;     // 温度标签
            myLabel_wendu.init();

            myLabel_div10_shuiwei.Device_Name = name;  // 水位显示
            myLabel_div10_shuiwei.init();

            myLabel_time_gongyi.Device_Name = name;    // 运行时时间显示
            myLabel_time_gongyi.init();

            myLabel_time_zong.Device_Name = name;      // 总时长显示
            myLabel_time_zong.init();

            myLabel_Red_Yellow_start.Device_Name = name;      // 启动显示 
            myLabel_Red_Yellow_start.init();

            myLabel_Red_Yellow_zanting.Device_Name = name;    // 暂停显示
            myLabel_Red_Yellow_zanting.init();

            myLabel_Red_Yellow_zhubeng.Device_Name = name;    // 主泵显示
            myLabel_Red_Yellow_zhubeng.init();

            myLabel_Red_Yellow_tingzhi.Device_Name = name;    // 停止显示
            myLabel_Red_Yellow_tingzhi.init();

            myLabel_Red_Yellow_jinshui1.Device_Name = name;   // 进水1
            myLabel_Red_Yellow_jinshui1.init();

            myLabel_Red_Yellow_jinshui2.Device_Name = name;   // 进水2
            myLabel_Red_Yellow_jinshui2.init();

            myLabel_Red_Yellow_jinshui3.Device_Name = name;   // 进水3
            myLabel_Red_Yellow_jinshui3.init();

            myLabel_Red_Yellow_jinshui4.Device_Name = name;   // 进水4
            myLabel_Red_Yellow_jinshui4.init();

            myLabel_Red_Yellow_paishui1.Device_Name = name;   // 排水1
            myLabel_Red_Yellow_paishui1.init();

            myLabel_Red_Yellow_paishui2.Device_Name = name;   // 排水2
            myLabel_Red_Yellow_paishui2.init();

            myLabel_Red_Yellow_paishui3.Device_Name = name;   // 排水3
            myLabel_Red_Yellow_paishui3.init();

            myLabel_Red_Yellow_paishui4.Device_Name = name;   // 排水4
            myLabel_Red_Yellow_paishui4.init();

            myLabel_Gongyi_gongyi.Device_Name = name;         // 工艺显示
            myLabel_Gongyi_gongyi.init();
        
        }

        private void QiLiuGang_Resize(object sender, EventArgs e)
        {
            init_view();


        }

        private void init_view()
        {
            // 模拟量
            ViewCaoZuo.Object_Position(0.01, 0.01, 0.5, 0.5, pictureBox1, this.Controls);   // 机缸图片

            ViewCaoZuo.Object_Position(0.53, 0.01, 0.4, 0.1, label1, this.Controls);        // 机缸标题

            ViewCaoZuo.Object_Position(0.53, 0.13, 0.45, 0.12, label_mengcheng, this.Controls);  // 机缸名称

            ViewCaoZuo.Object_Position(0.01, 0.53, 0.3, 0.12, label_wendu, this.Controls);  // 温度标签

            ViewCaoZuo.Object_Position(0.3, 0.53, 0.3, 0.12, myLabel_wendu, this.Controls); // 温度显示

            ViewCaoZuo.Object_Position(0.01, 0.65, 0.3, 0.12, label_jigangshuiwei, this.Controls); // 水位标签

            ViewCaoZuo.Object_Position(0.3, 0.65, 0.3, 0.12, myLabel_div10_shuiwei, this.Controls);// 水位显示

            ViewCaoZuo.Object_Position(0.01, 0.77, 0.3, 0.12, label_duanshi, this.Controls);       // 工艺时长标签

            ViewCaoZuo.Object_Position(0.3, 0.77, 0.3, 0.12, myLabel_time_gongyi, this.Controls);  // 工艺运行时长显示

            ViewCaoZuo.Object_Position(0.01, 0.89, 0.3, 0.12, label_zongyunxingshijian, this.Controls);  // 总时长标签

            ViewCaoZuo.Object_Position(0.3, 0.89, 0.3, 0.12, myLabel_time_zong, this.Controls);          // 总时长显示

            ViewCaoZuo.Object_Position(0.6, 0.89, 0.2, 0.1, label_zhixinggongyi, this.Controls);        // 执行工艺标签

            ViewCaoZuo.Object_Position(0.8, 0.89, 0.2, 0.1, myLabel_Gongyi_gongyi, this.Controls);      // 执行工艺显示

            // 开关量

            ViewCaoZuo.Object_Position(0.55, 0.3, 0.1, 0.1, myLabel_Red_Yellow_start, this.Controls);     // 启动

            ViewCaoZuo.Object_Position(0.65, 0.3, 0.1, 0.1, myLabel_Red_Yellow_zanting, this.Controls);   // 暂停

            ViewCaoZuo.Object_Position(0.75, 0.3, 0.1, 0.1, myLabel_Red_Yellow_zhubeng, this.Controls);   // 主泵

            ViewCaoZuo.Object_Position(0.85, 0.3, 0.1, 0.1, myLabel_Red_Yellow_tingzhi, this.Controls);   // 停止

            ViewCaoZuo.Object_Position(0.65, 0.45, 0.1, 0.1, myLabel_Red_Yellow_jinshui1, this.Controls);   // 进水1

            ViewCaoZuo.Object_Position(0.65, 0.55, 0.1, 0.1, myLabel_Red_Yellow_jinshui2, this.Controls);   // 进水2

            ViewCaoZuo.Object_Position(0.65, 0.65, 0.1, 0.1, myLabel_Red_Yellow_jinshui3, this.Controls);   // 进水3

            ViewCaoZuo.Object_Position(0.65, 0.75, 0.1, 0.1, myLabel_Red_Yellow_jinshui4, this.Controls);   // 进水4

            ViewCaoZuo.Object_Position(0.85, 0.45, 0.1, 0.1, myLabel_Red_Yellow_paishui1, this.Controls);   // 进水1

            ViewCaoZuo.Object_Position(0.85, 0.55, 0.1, 0.1, myLabel_Red_Yellow_paishui2, this.Controls);   // 进水2

            ViewCaoZuo.Object_Position(0.85, 0.65, 0.1, 0.1, myLabel_Red_Yellow_paishui3, this.Controls);   // 进水3

            ViewCaoZuo.Object_Position(0.85, 0.75, 0.1, 0.1, myLabel_Red_Yellow_paishui4, this.Controls);   // 进水4

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(MyClick!=null)
            {
                MyClick(this, new EventArgs());
            }
        }
    }
}
