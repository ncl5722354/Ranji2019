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
using System.Threading;

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

        Xiangxi xiangxi_view = new Xiangxi();                       // 详细页面

        Lishijilv lishijilu = new Lishijilv();


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
            // 工艺名称与参数名称之间的关系
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
            // 启动日期
            CreateSqlValueType[] qidongriqi = new CreateSqlValueType[2];
            qidongriqi[0] = new CreateSqlValueType("int","machine_num");
            qidongriqi[1] = new CreateSqlValueType("datetime", "start_time");

            builder.Create_Table("start_time",qidongriqi);
            for(int i=1;i<=100;i++)
            {
                string[] insert_cmd = new string[2];
                insert_cmd[0] = i.ToString();
                insert_cmd[1] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                builder.Insert("start_time", insert_cmd);
            }

            // 临时工艺表
            CreateSqlValueType[] linshi_craft = new CreateSqlValueType[3];
            linshi_craft[0] = new CreateSqlValueType("int", "machine_num");
            linshi_craft[1] = new CreateSqlValueType("nvarchar(50)","craft_table");
            builder.Create_Table("linshi_craft", linshi_craft);

            for(int i=1;i<=100;i++)
            {
                string[] insert_cmd = new string[2];
                insert_cmd[0] = i.ToString();
                insert_cmd[1] = "";
                builder.Insert("linshi_craft", insert_cmd);
            }


            // 执行的工单号
            // 机号  工单号
            CreateSqlValueType[] gongdan_exe = new CreateSqlValueType[2];
            gongdan_exe[0] = new CreateSqlValueType("int", "machine_num");
            gongdan_exe[1] = new CreateSqlValueType("nvarchar(50)","gongdanhao");
            builder.Create_Table("gongdan", gongdan_exe);

            for(int i=1;i<=100;i++)
            {
                string[] insert_cmd = new string[2];
                insert_cmd[0] = i.ToString();
                insert_cmd[1] = "";
                builder.Insert("gongdan",insert_cmd);
            }

            //

            // 操作记录表

            // 操作记录ID="机号+时间" 机号  time="时间" 工单号="" 变量=""  动作="";

            // **单独开发工艺运行情况记录**

            CreateSqlValueType[] caozuo_create = new CreateSqlValueType[6];
            caozuo_create[0] = new CreateSqlValueType("nvarchar(50)", "ID", true);
            caozuo_create[1] = new CreateSqlValueType("int","machine_num");
            caozuo_create[2] = new CreateSqlValueType("datetime","mytime");
            caozuo_create[3] = new CreateSqlValueType("nvarchar(50)", "gongdanhao");
            caozuo_create[4] = new CreateSqlValueType("nvarchar(50)", "bianliang");
            caozuo_create[5] = new CreateSqlValueType("nvarchar(50)", "dongzuo");

            builder.Create_Table("caozuo_save",caozuo_create);
            // 

            // 跳段记录
            // 记录 ID="机号+时间" 机号 时间 工单 跳段  跳段内容
            CreateSqlValueType[] tiaoduan_save = new CreateSqlValueType[6];
            tiaoduan_save[0] = new CreateSqlValueType("nvarchar(50)", "ID", true);
            tiaoduan_save[1] = new CreateSqlValueType("int","machine_num");
            tiaoduan_save[2] = new CreateSqlValueType("datetime","mytime");
            tiaoduan_save[3] = new CreateSqlValueType("nvarchar(50)","gongdan");
            tiaoduan_save[4] = new CreateSqlValueType("nvarchar(50)","tiaoduan");
            tiaoduan_save[5] = new CreateSqlValueType("nvarchar(max)","tiaoduanneirong");

            builder.Create_Table("tiaoduan_save", tiaoduan_save);

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

            zongmao_view.Click_Yiliu += new EventHandler(Show_xiangxi_Yiliu);
            zongmao_view.Click_Qiliu += new EventHandler(Show_xiangxi_Qiliu);
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
                // 一车间历史
                case "1chejianshenchanjilu":
                    Show_Chuangti(lishijilu);
                    break;
                // 二车间历史
                case "2chejianshenchanjilu":
                    Show_Chuangti(lishijilu);
                    break;
                // 三车间历史
                case "3chejianshenchanjilu":
                    Show_Chuangti(lishijilu);
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

        private void Save_Info()
        {
            // 温度信息保存
            CreateSqlValueType[] createsaveinfo = new CreateSqlValueType[5];
            createsaveinfo[0] = new CreateSqlValueType("nvarchar(50)", "ID", true);
            createsaveinfo[1] = new CreateSqlValueType("int", "machine_num");
            createsaveinfo[2] = new CreateSqlValueType("nvarchar(50)", "value_name");
            createsaveinfo[3] = new CreateSqlValueType("datetime", "value_time");
            createsaveinfo[4] = new CreateSqlValueType("nvarchar(50)","value");

            MainView.builder.Create_Table("save_info", createsaveinfo);

            string where_cmd = "value_name='机缸温度'";

            DataTable dt = MainView.builder.Select_Table("Value_Config", where_cmd);

            int wendu_address = 0;

            try
            {
                wendu_address = int.Parse(dt.Rows[0][2].ToString());
            }
            catch { return; }

            for (int i = 1; i < 100; i++)
            {
                string[] insert_cmd = new string[5];
                insert_cmd[0] = DateTime.Now.ToString("yyyyMMddHHmmss") + i.ToString();
                insert_cmd[1] = i.ToString();
                insert_cmd[2] = "机缸温度";
                insert_cmd[3] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                insert_cmd[4] = Device_Data.chejian3_com1_DT[i, wendu_address].ToString();

                MainView.builder.Insert("save_info", insert_cmd);
            }
        }

        private void Show_xiangxi_Yiliu(object sender,EventArgs e)
        {
            Show_Chuangti(xiangxi_view);
            xiangxi_view.Set_Yiliu();
            YiLiuGang_Item item = (YiLiuGang_Item)sender;
            xiangxi_view.Set_Title(item.JiGang_Name);
        }

        private void Show_xiangxi_Qiliu(object sender,EventArgs e)
        {
            Show_Chuangti(xiangxi_view);
            xiangxi_view.Set_Qiliu();
            QiLiuGang item = (QiLiuGang)sender;
            xiangxi_view.Set_Title(item.JiGang_Name);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Thread thread = new Thread(Save_Info);
            thread.Start();
        }

        public void play_stop_qingqiu(int machine_num)
        {
            if (player1.playState != WMPLib.WMPPlayState.wmppsPlaying && player1.playState != WMPLib.WMPPlayState.wmppsTransitioning)
            {
                player1.URL = "D:/config/wav/" + machine_num.ToString().PadLeft(2,'0') + "0.wav";
                player1.Ctlcontrols.play();
            }
        }
        public void play_start_qingqiu(int machine_num)
        {
            if (player1.playState != WMPLib.WMPPlayState.wmppsPlaying && player1.playState != WMPLib.WMPPlayState.wmppsTransitioning)
            {
                player1.URL = "D:/config/wav/"+machine_num.ToString().PadLeft(2,'0') + ".WAV";
                player1.Ctlcontrols.play();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {

                string where_cmd_start = "value_name='请求运行'";
                string where_cmd_stop = "value_name='请求暂停'";

                DataTable start_table = MainView.builder.Select_Table("Value_Config", where_cmd_start);
                DataTable stop_table = MainView.builder.Select_Table("Value_Config", where_cmd_stop);
                try
                {
                    int start_address = int.Parse(start_table.Rows[0][2].ToString());
                    int stop_address = int.Parse(stop_table.Rows[0][2].ToString());


                    if(Device_Data.chejian3_com1_R[i,start_address]==true)
                    {
                        play_start_qingqiu(i);
                        return;
                    }
                    if (Device_Data.chejian3_com1_R[i, stop_address] == true)
                    {
                        play_stop_qingqiu(i);
                        return;
                    }

                }
                catch { }

                
            }
        }

        private void timer_tiaoduan_save_Tick(object sender, EventArgs e)
        {
            save_tiaoduan();
        }

        public void save_tiaoduan()
        {
            for(int i=1;i<=100;i++)
            {
                string where_duan_save = "machine_num='" + i.ToString() + "'";
                DataTable dt_duan_save = MainView.builder.Select_Table("tiaoduan_save",where_duan_save);
                if(dt_duan_save==null)
                {
                    // 开始的信号
                   

                    
                }
                else if(dt_duan_save.Rows.Count==0)
                {
                    try
                    {
                        // 读取期待工单地址
                        string where_qidong = "value_name='启动'";
                        DataTable qidong_table = MainView.builder.Select_Table("Value_Config", where_qidong);
                        int qidong_address = int.Parse(qidong_table.Rows[0][2].ToString());
                        if (Device_Data.chejian3_com1_R[i, qidong_address] == true)
                        {
                            // 插入
                            string[] insert_cmd = new string[6];
                            insert_cmd[0] = DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString() + i.ToString();
                            insert_cmd[1] = i.ToString();
                            insert_cmd[2] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                            // 读取工单号
                            string where_gongdan_cmd = "machine_num='" + i.ToString() + "'";
                            DataTable gongdan_table = MainView.builder.Select_Table("gongdan", where_gongdan_cmd);

                            string gongdanname = gongdan_table.Rows[0][1].ToString();
                            insert_cmd[3] = gongdanname;

                            //  读取现在的段号
                            string where_cmd_nowduan = "value_name='运行段号'";
                            DataTable dt_nowduan = MainView.builder.Select_Table("Value_Config", where_cmd_nowduan);


                            int duan_value = int.Parse(dt_nowduan.Rows[0][2].ToString());
                            int duan = Device_Data.chejian3_com1_DT[i, duan_value];

                            // 读取临时表格

                            DataTable linshigongdan = MainView.builder.Select_Table("工艺" + gongdanname);

                            int zongduancount = 0;
                            string gongyistring = "";
                            int myduan=0;
                            for (int j = 0; j < linshigongdan.Rows.Count; j++)
                            {
                                DataRow dr = linshigongdan.Rows[j];
                                // 单个工艺的段号

                                string gongyi = dr[1].ToString();                    // 工艺名称

                                // 读取工艺名称占多少段\
                                
                                DataTable sub_duan = MainView.builder.Select_Table(gongyi+"xiangxi");

                                if (duan >= zongduancount && duan < zongduancount + sub_duan.Rows.Count)
                                {
                                    // 这时候j就是段号
                                    insert_cmd[4] = (j + 1).ToString();
                                    myduan=j;
                                    break;
                                }
                            }

                            // 读取工艺
                            string gongyi_name = linshigongdan.Rows[myduan][1].ToString();

                            string where_gongyi_name = "Gongyi_Name='" + gongyi_name + "'";
                            DataTable dt_gongyi_info = MainView.builder.Select_Table("Craft_Name_Table", where_gongyi_name);
                            string gongyi_info = gongyi_name;
                            for(int z=1;z<=10;z++)
                            {
                                gongyi_info = gongyi_info + " " + dt_gongyi_info.Rows[0][z].ToString() + ":" + linshigongdan.Rows[0][z + 1].ToString();
                            }

                            insert_cmd[5] = gongyi_info;
                            MainView.builder.Insert("tiaoduan_save",insert_cmd);


                            //
                            //insert_cmd[4] = "";

                        }

                    }
                    catch { }
                }
                else if (dt_duan_save.Rows.Count > 0)
                {
                    try
                    {
                        // 读取期待工单地址
                        string where_qidong = "value_name='启动'";
                        DataTable qidong_table = MainView.builder.Select_Table("Value_Config", where_qidong);
                        int qidong_address = int.Parse(qidong_table.Rows[0][2].ToString());
                        if (Device_Data.chejian3_com1_R[i, qidong_address] == true)
                        {
                            // 插入
                            string[] insert_cmd = new string[6];
                            insert_cmd[0] = DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString() + i.ToString();
                            insert_cmd[1] = i.ToString();
                            insert_cmd[2] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                            // 读取工单号
                            string where_gongdan_cmd = "machine_num='" + i.ToString() + "'";
                            DataTable gongdan_table = MainView.builder.Select_Table("gongdan", where_gongdan_cmd);

                            string gongdanname = gongdan_table.Rows[0][1].ToString();
                            insert_cmd[3] = gongdanname;

                            //  读取现在的段号
                            string where_cmd_nowduan = "value_name='运行段号'";
                            DataTable dt_nowduan = MainView.builder.Select_Table("Value_Config", where_cmd_nowduan);


                            int duan_value = int.Parse(dt_nowduan.Rows[0][2].ToString());
                            int duan = Device_Data.chejian3_com1_DT[i, duan_value];

                            // 读取临时表格

                            DataTable linshigongdan = MainView.builder.Select_Table("工艺" + gongdanname);

                            int zongduancount = 0;
                            string gongyistring = "";
                            int myduan = 0;
                            for (int j = 0; j < linshigongdan.Rows.Count; j++)
                            {
                                DataRow dr = linshigongdan.Rows[j];
                                // 单个工艺的段号

                                string gongyi = dr[1].ToString();                    // 工艺名称

                                // 读取工艺名称占多少段\

                                DataTable sub_duan = MainView.builder.Select_Table(gongyi + "xiangxi");

                                if (duan >= zongduancount && duan < zongduancount + sub_duan.Rows.Count)
                                {
                                    // 这时候j就是段号
                                    insert_cmd[4] = (j + 1).ToString();
                                    myduan = j;
                                    break;
                                }
                                zongduancount = sub_duan.Rows.Count;
                            }

                            // 读取工艺
                            string gongyi_name = linshigongdan.Rows[myduan][1].ToString();

                            string where_gongyi_name = "Gongyi_Name='" + gongyi_name + "'";
                            DataTable dt_gongyi_info = MainView.builder.Select_Table("Craft_Name_Table", where_gongyi_name);
                            string gongyi_info = gongyi_name;
                            for (int z = 1; z <= 10; z++)
                            {
                                gongyi_info = gongyi_info + " " + dt_gongyi_info.Rows[0][z].ToString() + ":" + linshigongdan.Rows[0][z + 1].ToString();
                            }

                            insert_cmd[5] = gongyi_info;

                            // 读取相应的表里面最新的一条

                            string where_pre_dt_cmd = "machine_num='" + i.ToString() + "'";
                            DataTable pre_dt = MainView.builder.Select_Table("tiaoduan_save",where_pre_dt_cmd);
                            DataRow pre_dr = pre_dt.Rows[pre_dt.Rows.Count - 1];
                            if (pre_dr[3].ToString() != insert_cmd[3] || pre_dr[4].ToString() != insert_cmd[4] || pre_dr[5].ToString() != insert_cmd[5])
                            {
                                if (insert_cmd[4] != "")
                                {
                                    MainView.builder.Insert("tiaoduan_save", insert_cmd);
                                }
                            }


                           

                        }

                    }
                    catch { }
                }
            }
        }
    }
}
