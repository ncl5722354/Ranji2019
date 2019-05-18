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
using SqlConnect;    

namespace YinRan2020
{
    public partial class MainView : Form
    {

        /// <summary>
        /// 定义窗体
        /// </summary>
        ///
        zongmao zongmao_view = new zongmao();              // 总貌窗体
        Deivce_Info device_info = new Deivce_Info();       // 设备管理窗体


        /// <summary>
        /// 定义数据库
        /// </summary>
        /// 
        public static SQL_Connect_Builder builder = new SQL_Connect_Builder(".", "YinRan2019", 1, 1000);             
        public MainView()
        {
            InitializeComponent();
            init_view();
            init_database();
        }

        private void init_database()
        {
            // 初始化数据库
            // 建立固定列表
            // 设备情况列表
            // 设备ID，设备名称，设备车间，设备种类，设备通讯端口，设备地址，通讯协议
            CreateSqlValueType[] create1 = new CreateSqlValueType[7];
            create1[0] = new CreateSqlValueType("nvarchar(50)", "ID", true);
            create1[1] = new CreateSqlValueType("nvarchar(50)","Name");
            create1[2] = new CreateSqlValueType("nvarchar(50)", "workshop");
            create1[3] = new CreateSqlValueType("nvarchar(50)","DeivceType");
            create1[4] = new CreateSqlValueType("nvarchar(50)", "Com");
            create1[5] = new CreateSqlValueType("nvarchar(50)", "Address");
            create1[6] = new CreateSqlValueType("nvarchar(50)","Protocol");
            builder.Create_Table("Device_Info", create1);
           // builder.Create_Database();
        }

        private void init_view()
        {
            // 初始化操作
            ViewCaoZuo.Max_Form(this);      // 屏幕最大化
            
            // 树形图的大小位置
            ViewCaoZuo.Object_Position(0.01, 0.1, 0.1, 0.8, treeView1, this.Controls);

            ViewCaoZuo.Object_Position(0.01, 0.05, 0.1, 0.05, label_caidanliebiao, this.Controls);

            ViewCaoZuo.Object_Position(0.01, 0, 1, 0.05, label_title, this.Controls);

            ViewCaoZuo.Object_Position(0.12, 0.06, 0.85, 0.84, panel_bg, this.Controls);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // 树形图选择
            switch (treeView1.SelectedNode.Name)
            {
                    //总貌一车间
                case "1chejianrealtimeshengchan":
                    Show_Chuangti(zongmao_view);
                    zongmao_view.Set_Chejian("一车间");
                    zongmao_view.ReSet_Device_Info();    // 显示总貌信息
                    break;
                    // 总貌二车间
                case "2chejianrealtimeshengchan":
                    Show_Chuangti(zongmao_view);
                    zongmao_view.Set_Chejian("二车间");
                    zongmao_view.ReSet_Device_Info();   // 显示总貌信息
                    break;
                    //  总貌三车间
                case "3chejianrealtimeshengchan":
                    Show_Chuangti(zongmao_view);
                    zongmao_view.Set_Chejian("三车间");
                    zongmao_view.ReSet_Device_Info();   // 显示总貌信息
                    break;
                    // 通讯设置1车间
                case "1chejiantongxun":
                    Show_Chuangti(device_info);
                    device_info.Set_Chenjian("一车间");
                    device_info.Read_Device_Info_Form_DataBase();
                    break;
                // 通讯设置2车间
                case "2chejiantongxun":
                    Show_Chuangti(device_info);
                    device_info.Set_Chenjian("二车间");
                    device_info.Read_Device_Info_Form_DataBase();
                    break;
                // 通讯设置3车间
                case "3chejiantongxun":
                    Show_Chuangti(device_info);
                    device_info.Set_Chenjian("三车间");
                    device_info.Read_Device_Info_Form_DataBase();
                    break;

            }

        }

        public void Show_Chuangti(Form form)
        {
            panel_bg.Controls.Clear();
            form.TopLevel = false;
            panel_bg.Controls.Add(form);
            form.Show();
            form.Left = 0;
            form.Top = 0;
            form.Width = panel_bg.Width;
            form.Height = panel_bg.Height;
        }
    }
}
