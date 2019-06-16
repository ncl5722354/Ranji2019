using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using ViewConfig;
using SqlConnect;
using FileOperation;
using System.Runtime.InteropServices;

namespace YinRan2020
{
    public partial class MainView : Form
    {

        /// <summary>
        /// 定义窗体
        /// </summary>
        
        
        zongmao zongmao_view = new zongmao();                     // 总貌窗体
        Deivce_Info device_info = new Deivce_Info();              // 设备管理窗体
        
        Craft_Config gongyi_edit_view = new Craft_Config();         // 工艺编辑
        shengchanpaishan shengchan_view = new shengchanpaishan();   // 生产排产



        public static string Connect_Chejian_Num = "";        //连接的车间名称  本软件连接的车间名称,
        public static IniFile inifile = new IniFile("D:\\config\\YinRan2019config.ini");

        #region 内存回收
       [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);

        /// <summary>
        /// 释放内存
        /// </summary>
        
        public static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
                // .SetProcessWorkingSetSize();
            }
        }
        #endregion


        /// <summary>
        /// 定义数据库
        /// </summary>
        /// 
        public static SQL_Connect_Builder builder = new SQL_Connect_Builder(".", "YinRan2019", 1, 100000);             
        public MainView()
        {
            InitializeComponent();
            init_view();
            init_database();
            Connect_Chejian_Num = inifile.IniReadValue("连接", "车间号");                    // 读取本机的车间号
            if (Connect_Chejian_Num == "")
            {
                inifile.IniWriteValue("连接", "车间号", "1");
            }
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

            // 创建实时数据库 
            CreateSqlValueType[] create_real_data = new CreateSqlValueType[4];
            create_real_data[0] = new CreateSqlValueType("nvarchar(50)", "value_ID", true);
            create_real_data[1] = new CreateSqlValueType("nvarchar(50)", "device_name");
            create_real_data[2] = new CreateSqlValueType("nvarchar(50)", "value_name");
            create_real_data[3] = new CreateSqlValueType("nvarchar(50)", "value");
            builder.Create_Table("Real_Value_Table", create_real_data);

            // 数据存放地址  所有的设备都相同
            CreateSqlValueType[] data_address = new CreateSqlValueType[4];
            data_address[0] = new CreateSqlValueType("nvarchar(50)", "value_name", true);
            data_address[1] = new CreateSqlValueType("nvarchar(50)", "value_type");
            data_address[2] = new CreateSqlValueType("nvarchar(50)", "value_address");
            builder.Create_Table("Value_Config", data_address);

            //============== 所有的MyLabel 地址存放初始化 ==============//
               
            foreach(MyLabel.value_name name in Enum.GetValues(typeof(MyLabel.value_name)))
            {
                string[] insert_cmd = new string[3];
                insert_cmd[0] = name.ToString();
                insert_cmd[1] = "";
                insert_cmd[2] = "";
                builder.Insert("Value_Config", insert_cmd);
            }

            //============== 所有的MyLabeltimne 地址存放初始化 ==============//

            foreach (MyLabel_time.value_name name in Enum.GetValues(typeof(MyLabel_time.value_name)))
            {
                string[] insert_cmd = new string[3];
                insert_cmd[0] = name.ToString();
                insert_cmd[1] = "";
                insert_cmd[2] = "";
                builder.Insert("Value_Config", insert_cmd);
            }

            //============== 所有的MyLabeltimne 地址存放初始化 ==============//

            foreach (MyLabel_Red_Yellow.value_name name in Enum.GetValues(typeof(MyLabel_Red_Yellow.value_name)))
            {
                string[] insert_cmd = new string[3];
                insert_cmd[0] = name.ToString();
                insert_cmd[1] = "";
                insert_cmd[2] = "";
                builder.Insert("Value_Config", insert_cmd);
            }

            //试验
            Device_Data.chejian1_com1_DT[11, 10] = 3705;
            Device_Data.chejian1_com1_R[12, 15] = true;
            Device_Data.chejian1_com1_R[10, 20] = true;


            // 工艺管理有关数据库
            //     工艺名称与参数名称之间的关系
            CreateSqlValueType[] create_gongyi = new CreateSqlValueType[12];
            create_gongyi[0] = new CreateSqlValueType("nvarchar(50)", "Gongyi_Name", true);
            create_gongyi[1] = new CreateSqlValueType("nvarchar(50)", "value1_name");
            create_gongyi[2] = new CreateSqlValueType("nvarchar(50)", "value2_name");
            create_gongyi[3] = new CreateSqlValueType("nvarchar(50)", "value3_name");
            create_gongyi[4] = new CreateSqlValueType("nvarchar(50)", "value4_name");
            create_gongyi[5] = new CreateSqlValueType("nvarchar(50)", "value5_name");
            create_gongyi[6] = new CreateSqlValueType("nvarchar(50)", "value6_name");
            create_gongyi[7] = new CreateSqlValueType("nvarchar(50)", "value7_name");
            create_gongyi[8] = new CreateSqlValueType("nvarchar(50)", "value8_name");
            create_gongyi[9] = new CreateSqlValueType("nvarchar(50)", "value9_name");
            create_gongyi[10] = new CreateSqlValueType("nvarchar(50)", "value10_name");
            create_gongyi[11] = new CreateSqlValueType("nvarchar(255)", "beizhu");

            builder.Create_Table("Craft_Name_Table", create_gongyi);



            //=============================================================================

            // 工艺代码表
            CreateSqlValueType[] create_craft_code = new CreateSqlValueType[2];
            create_craft_code[0] = new CreateSqlValueType("nvarchar(50)", "Craft_Name", true);
            create_craft_code[1] = new CreateSqlValueType("nvarchar(50)", "Craft_Code");
            builder.Create_Table("Craft_Name_Code", create_craft_code);


            //===============================================================================

            // 生产排产
            CreateSqlValueType[] shenchanpaichan_crate_sql_type = new CreateSqlValueType[3];
            shenchanpaichan_crate_sql_type[0] = new CreateSqlValueType("nvarchar(50)", "ID", true);
            shenchanpaichan_crate_sql_type[1] = new CreateSqlValueType("nvarchar(50)", "state");
            shenchanpaichan_crate_sql_type[2] = new CreateSqlValueType("nvarchar(50)","工艺名");
            builder.Create_Table("Shengchanpaichan", shenchanpaichan_crate_sql_type);


            //===============================================================================
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

                // 工艺一车间
                case "gongyiguanli_1chejian":
                    Show_Chuangti(gongyi_edit_view);
                    gongyi_edit_view.Set_Title("一车间");
                    break;

                // 工艺二车间
                case "gongyiguanli_2chejian":
                    Show_Chuangti(gongyi_edit_view);
                    gongyi_edit_view.Set_Title("两车间");
                    break;

                // 工艺三车间
                case "gongyiguanli_3chejian":
                    Show_Chuangti(gongyi_edit_view);
                    gongyi_edit_view.Set_Title("三车间");
                    break;
                
                // 一车间排产
                case "shengchan_1chejian":
                    Show_Chuangti(shengchan_view);
                    shengchan_view.Set_Title("一车间排产");
                    break;
                // 二车间排产
                case "shengchan_2chejian":
                    Show_Chuangti(shengchan_view);
                    shengchan_view.Set_Title("二车间排产");
                    break;
                // 三车间排产
                case "shengchan_3chejian":
                    Show_Chuangti(shengchan_view);
                    shengchan_view.Set_Title("三车间排产");
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            ClearMemory();
        }
    }
}
