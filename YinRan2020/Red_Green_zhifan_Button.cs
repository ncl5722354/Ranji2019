using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace YinRan2020
{
    public partial class Red_Green_zhifan_Button : UserControl
    {
        private string device_name = "";          // 设备名称属性
        private Color truecolor;
        private Color falsecolor;
        private Color show_color;
        private int mode = 0;
        int machine_num;
        int address;
        bool value = false;

        public  static int step = 0;
        // 参数1
        public static int xiazai_data1 = 2000;
        public static int xiazai_data11 = 2100;
        public static int xiazai_data12 = 2200;

        // 参数2
        public static int xiazai_data2 = 2500;
        public static int xiazai_data21 = 2600;
        public static int xiazai_data22 = 2700;

        // 工艺代码
        public static int xiazai_data3 = 3000;
        public static int xiazai_data31 = 3100;
        public static int xiazai_data32 = 3200;

        // 主泵频率
        public static int xiazai_data4 = 3500;
        public static int xiazai_data41 = 3600;
        public static int xiazai_data42 = 3700;

        // 替补频率
        public static int xiazai_data5 = 4000;
        public static int xiazai_data51 = 4100;
        public static int xiazai_data52 = 4200;

        // 风机频率
        public static int xiazai_data6 = 4500;
        public static int xiazai_data61 = 4700;
        public static int xiazai_data62 = 4800;

        public static  int[] down_data1 = new int[2000];
        public static  int[] down_data2 = new int[2000];
        public static  int[] down_data3 = new int[2000];
        public static  int[] down_data4 = new int[2000];
        public static  int[] down_data5 = new int[2000];
        public static  int[] down_data6 = new int[2000];

        public static int datacount = 0;

        private value_name MyValue_Name = value_name.进水1;
        public DataGridView gongyidatagridview1 = null;

        public event EventHandler Qidong = null;
        public Red_Green_zhifan_Button()
        {
            InitializeComponent();
        }

        private void From_DataGridView_To_List()
        {

        }

        public enum value_name
        {
            //  逻辑量输入
            进水1,
            进水2,
            进水3,
            进水4,
            排水1,
            排水2,
            排水3,
            排水4,
            进料,
            启动,
            停止,
            暂停,
            疏水,
            溢流1,
            溢流2,
            料缸进水,
            料缸排水,
            排气,
            主泵,
            循环,
            搅拌,
            手自动,
            料缸手自动,
            请求运行,
            请求暂停
        };
        private void thread()
        {
            try
            {
                bool result = false;
                string[] insert_cmd = new string[4];
                insert_cmd[0] = device_name + MyValue_Name.ToString();
                insert_cmd[1] = device_name;
                insert_cmd[2] = Value_Name.ToString();
                insert_cmd[3] = "";
                MainView.builder.Insert("Real_Value_Table", insert_cmd);


                // 根据设备名称读取车间的信息
                string where_read_chejian = "ID='" + device_name + "'";
                DataTable dt_read_chejian = MainView.builder.Select_Table("Device_Info", where_read_chejian);
                string chejian_name = dt_read_chejian.Rows[0][2].ToString();

                // ======================== 一车间 ========================
                if (chejian_name == "一车间" && MainView.Connect_Chejian_Num == "1")
                {
                    // 只有一车间的值从DT中读,其他的值从数据库中读
                    string com_name = dt_read_chejian.Rows[0][4].ToString();        // 串口信息
                    machine_num = int.Parse(dt_read_chejian.Rows[0][5].ToString()); // 机号

                    // 读取数据的种类与地址
                    string where_data = "value_name='" + Value_Name.ToString() + "'";
                    DataTable dt_data = MainView.builder.Select_Table("Value_Config", where_data);
                    string Type = dt_data.Rows[0][1].ToString();                      // 数据种类
                    address = int.Parse(dt_data.Rows[0][2].ToString());           // 数据地址

                    if (com_name == "串口1")
                    {
                        //if (Type == "DT") //label1.Text = Device_Data.chejian1_com1_DT[machine_num, address].ToString();
                        if (Type == "R")
                        {
                            result = Device_Data.chejian1_com1_R[machine_num, address];
                            if (result == false)
                                show_color = falsecolor;
                            else
                                show_color = truecolor;
                        }
                    }
                    if (com_name == "串口2")
                    {
                        // if (Type == "DT") //label1.Text = Device_Data.chejian1_com2_DT[machine_num, address].ToString();
                        if (Type == "R")
                        {
                            result = Device_Data.chejian1_com1_R[machine_num, address];
                            if (result == false)
                                show_color = falsecolor;
                            else
                                show_color = truecolor;
                        }
                    }
                    if (com_name == "串口3")
                    {
                        // if (Type == "DT") //label1.Text = Device_Data.chejian1_com3_DT[machine_num, address].ToString();
                        if (Type == "R")
                        {
                            result = Device_Data.chejian1_com1_R[machine_num, address];
                            if (result == false)
                                show_color = falsecolor;
                            else
                                show_color = truecolor;
                        }
                    }
                    if (com_name == "串口4")
                    {
                        // if (Type == "DT") //label1.Text = Device_Data.chejian1_com4_DT[machine_num, address].ToString();
                        if (Type == "R")
                        {
                            result = Device_Data.chejian1_com1_R[machine_num, address];
                            if (result == false)
                                show_color = falsecolor;
                            else
                                show_color = truecolor;
                        }
                    }
                    if (com_name == "串口5")
                    {
                        //if (Type == "DT") label1.Text = Device_Data.chejian1_com5_DT[machine_num, address].ToString();
                        if (Type == "R")
                        {
                            result = Device_Data.chejian1_com1_R[machine_num, address];
                            if (result == false)
                                show_color = falsecolor;
                            else
                                show_color = truecolor;
                        }
                    }
                    if (com_name == "串口6")
                    {
                        // if (Type == "DT") label1.Text = Device_Data.chejian1_com6_DT[machine_num, address].ToString();
                        if (Type == "R")
                        {
                            result = Device_Data.chejian1_com1_R[machine_num, address];
                            if (result == false)
                                show_color = falsecolor;
                            else
                                show_color = truecolor;
                        }
                    }

                    // 在主程序上进行实时数据对实时数据库的保存

                }

                if (chejian_name == "一车间" && MainView.Connect_Chejian_Num != "1")
                {
                    try
                    {
                        string key = device_name + Value_Name;
                        string where_cmd = "value_ID='" + key + "'";
                        DataTable value_dt = MainView.builder.Select_Table("Real_Value_Table", where_cmd);
                        string value_string = value_dt.Rows[0][3].ToString();
                        if (value_string == "false")
                            show_color = falsecolor;
                        if (value_string == "true")
                            show_color = truecolor;
                        //label1.Text = value.ToString();
                    }
                    catch { }
                }

                // ======================== 二车间 ========================
                if (chejian_name == "二车间" && MainView.Connect_Chejian_Num == "2")
                {
                    // 只有一车间的值从DT中读,其他的值从数据库中读
                    string com_name = dt_read_chejian.Rows[0][4].ToString();        // 串口信息
                    machine_num = int.Parse(dt_read_chejian.Rows[0][5].ToString()); // 机号

                    // 读取数据的种类与地址
                    string where_data = "value_name='" + Value_Name.ToString() + "'";
                    DataTable dt_data = MainView.builder.Select_Table("Value_Config", where_data);
                    string Type = dt_data.Rows[0][1].ToString();                      // 数据种类
                    address = int.Parse(dt_data.Rows[0][2].ToString());           // 数据地址

                    if (com_name == "串口1")
                    {
                        // if (Type == "DT") label1.Text = Device_Data.chejian2_com1_DT[machine_num, address].ToString();
                        if (Type == "R")
                        {
                            result = Device_Data.chejian2_com1_R[machine_num, address];
                            if (result == false)
                                show_color = falsecolor;
                            else
                                show_color = truecolor;
                        }
                    }
                    if (com_name == "串口2")
                    {
                        // if (Type == "DT") label1.Text = Device_Data.chejian2_com2_DT[machine_num, address].ToString();
                        if (Type == "R")
                        {
                            result = Device_Data.chejian2_com2_R[machine_num, address];
                            if (result == false)
                                show_color = falsecolor;
                            else
                                show_color = truecolor;
                        }
                    }
                    if (com_name == "串口3")
                    {
                        //if (Type == "DT") label1.Text = Device_Data.chejian2_com3_DT[machine_num, address].ToString();
                        if (Type == "R")
                        {
                            result = Device_Data.chejian2_com3_R[machine_num, address];
                            if (result == false)
                                show_color = falsecolor;
                            else
                                show_color = truecolor;
                        }
                    }
                    if (com_name == "串口4")
                    {
                        // if (Type == "DT") label1.Text = Device_Data.chejian2_com4_DT[machine_num, address].ToString();
                        if (Type == "R")
                        {
                            result = Device_Data.chejian2_com4_R[machine_num, address];
                            if (result == false)
                                show_color = falsecolor;
                            else
                                show_color = truecolor;
                        }
                    }
                    if (com_name == "串口5")
                    {
                        // if (Type == "DT") label1.Text = Device_Data.chejian2_com5_DT[machine_num, address].ToString();
                        if (Type == "R")
                        {
                            result = Device_Data.chejian2_com5_R[machine_num, address];
                            if (result == false)
                                show_color = falsecolor;
                            else
                                show_color = truecolor;
                        }
                    }
                    if (com_name == "串口6")
                    {
                        //  if (Type == "DT") label1.Text = Device_Data.chejian2_com6_DT[machine_num, address].ToString();
                        if (Type == "R")
                        {
                            result = Device_Data.chejian2_com6_R[machine_num, address];
                            if (result == false)
                                show_color = falsecolor;
                            else
                                show_color = truecolor;
                        }
                    }

                    // 在主程序上进行实时数据对实时数据库的保存

                }

                if (chejian_name == "二车间" && MainView.Connect_Chejian_Num != "2")
                {
                    try
                    {
                        string key = device_name + Value_Name;
                        string where_cmd = "value_ID='" + key + "'";
                        DataTable value_dt = MainView.builder.Select_Table("Real_Value_Table", where_cmd);
                        string value_string = value_dt.Rows[0][3].ToString();
                        if (value_string == "false")
                            show_color = falsecolor;
                        if (value_string == "true")
                            show_color = truecolor;
                    }
                    catch { }
                }
                // ======================== 三车间 ========================
                if (chejian_name == "三车间" && MainView.Connect_Chejian_Num == "3")
                {
                    // 只有一车间的值从DT中读,其他的值从数据库中读
                    string com_name = dt_read_chejian.Rows[0][4].ToString();        // 串口信息
                    machine_num = int.Parse(dt_read_chejian.Rows[0][5].ToString()); // 机号

                    // 读取数据的种类与地址
                    string where_data = "value_name='" + Value_Name.ToString() + "'";
                    DataTable dt_data = MainView.builder.Select_Table("Value_Config", where_data);
                    string Type = dt_data.Rows[0][1].ToString();                      // 数据种类
                    address = int.Parse(dt_data.Rows[0][2].ToString());           // 数据地址

                    if (com_name == "串口1")
                    {
                        // if (Type == "DT") label1.Text = Device_Data.chejian3_com1_DT[machine_num, address].ToString();
                        if (Type == "R")
                        {
                           result = Device_Data.chejian3_com1_R[machine_num, address];
                            if (result == false)
                                show_color = falsecolor;
                            else
                                show_color = truecolor;
                        }
                    }
                    if (com_name == "串口2")
                    {
                        // if (Type == "DT") label1.Text = Device_Data.chejian3_com2_DT[machine_num, address].ToString();
                        if (Type == "R")
                        {
                            result = Device_Data.chejian3_com1_R[machine_num, address];
                            if (result == false)
                                show_color = falsecolor;
                            else
                                show_color = truecolor;
                        }
                    }
                    if (com_name == "串口3")
                    {
                        //  if (Type == "DT") label1.Text = Device_Data.chejian3_com3_DT[machine_num, address].ToString();
                        if (Type == "R")
                        {
                            result = Device_Data.chejian3_com1_R[machine_num, address];
                            if (result == false)
                                show_color = falsecolor;
                            else
                                show_color = truecolor;
                        }
                    }
                    if (com_name == "串口4")
                    {
                        // if (Type == "DT") label1.Text = Device_Data.chejian3_com4_DT[machine_num, address].ToString();
                        if (Type == "R")
                        {
                            result = Device_Data.chejian3_com1_R[machine_num, address];
                            if (result == false)
                                show_color = falsecolor;
                            else
                                show_color = truecolor;
                        }
                    }
                    if (com_name == "串口5")
                    {
                        // if (Type == "DT") label1.Text = Device_Data.chejian3_com5_DT[machine_num, address].ToString();
                        if (Type == "R")
                        {
                            result = Device_Data.chejian3_com1_R[machine_num, address];
                            if (result == false)
                                show_color = falsecolor;
                            else
                                show_color = truecolor;
                        }
                    }
                    if (com_name == "串口6")
                    {
                        // if (Type == "DT") label1.Text = Device_Data.chejian3_com6_DT[machine_num, address].ToString();
                        if (Type == "R")
                        {
                            result = Device_Data.chejian3_com1_R[machine_num, address];
                            if (result == false)
                                show_color = falsecolor;
                            else
                                show_color = truecolor;
                        }
                    }

                    // 在主程序上进行实时数据对实时数据库的保存

                }

                if (chejian_name == "三车间" && MainView.Connect_Chejian_Num != "3")
                {
                    try
                    {
                        string key = device_name + Value_Name;
                        string where_cmd = "value_ID='" + key + "'";
                        DataTable value_dt = MainView.builder.Select_Table("Real_Value_Table", where_cmd);
                        string value_string = value_dt.Rows[0][3].ToString();
                        if (value_string == "false")
                            show_color = falsecolor;
                        if (value_string == "true")
                            show_color = truecolor;
                    }
                    catch { }
                }

                value = result;

            }
            catch { }
        }

        public Color True_Color
        {
            get
            {
                return truecolor;
            }
            set
            {
                truecolor = value;

            }
        }
        public int Mode
        {
            get
            {
                return mode;
            }
            set
            {
                mode = value;

            }
        }

        public Color False_Color
        {
            get
            {
                return falsecolor;
            }
            set
            {
                falsecolor = value;

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
                button1.Text = value.ToString();
            }
        }



        public void init()
        {
            timer1.Enabled = true;
        }

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

        

        private void Red_Green_zhifan_Button_AutoSizeChanged(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread mythread = new Thread(thread);
            mythread.Start();
            button1.BackColor = show_color;

            port_moudbus mymodbus = null;

            string  where_cmd = "ID='" + device_name + "'";
            DataTable dt = MainView.builder.Select_Table("Device_Info", where_cmd);

            try
            {
                // int address = int.Parse(dt.Rows[0][5].ToString());
                if (dt.Rows[0][4].ToString() == "串口1")
                {
                    mymodbus = Deivce_Info.modbus1;
                }
                if (dt.Rows[0][4].ToString() == "串口2")
                {
                    mymodbus = Deivce_Info.modbus2;
                }
                if (dt.Rows[0][4].ToString() == "串口3")
                {
                    mymodbus = Deivce_Info.modbus3;
                }
                if (dt.Rows[0][4].ToString() == "串口4")
                {
                    mymodbus = Deivce_Info.modbus4;
                }
                if (dt.Rows[0][4].ToString() == "串口5")
                {
                    mymodbus = Deivce_Info.modbus5;
                }
                if (dt.Rows[0][4].ToString() == "串口6")
                {
                    mymodbus = Deivce_Info.modbus6;
                }
            }
            catch { }

            if (MyValue_Name == value_name.启动)
            {
                Xiangxi.loadcount++;
                #region                       // 下载第一步
                if (step == 1 && datacount <= 100)
                {
                    // 直接下载第二步
                    try
                    {
                        mymodbus.Send_Write_Cmd16(machine_num, datacount, xiazai_data2.ToString("X").PadLeft(4, '0'), down_data2);
                    }
                    catch { return; }
                }

                if (step == 1 && datacount > 100 && datacount <= 200)
                {
                    // 下载100以后的地址
                    int mycount = datacount - 100;
                    try
                    {
                        int[] mydata = new int[1000];
                        for (int i = 0; i < 1000; i++)
                        {
                            mydata[i] = down_data1[i + 100];
                        }
                        mymodbus.Send_Write_Cmd16(machine_num, mycount, xiazai_data11.ToString("X").PadLeft(4, '0'), mydata);
                    }
                    catch { return; }
                }


                if (step == 1 && datacount > 200)
                {
                    try
                    {
                        // 下载100-200以后的地址
                        int[] mydata = new int[1000];
                        for (int i = 0; i < 1000; i++)
                        {
                            mydata[i] = down_data1[i + 100];
                        }
                        mymodbus.Send_Write_Cmd16(machine_num, 100, xiazai_data11.ToString("X").PadLeft(4, '0'), mydata);
                    }
                    catch { return; }
                }

                if (step == 11 && datacount > 100 && datacount <= 200)
                {
                    try
                    {
                        // 下载完100以后，直接下载下一步
                        mymodbus.Send_Write_Cmd16(machine_num, 100, xiazai_data2.ToString("X").PadLeft(4, '0'), down_data2);
                    }
                    catch { return; }
                }

                if (step == 11 && datacount > 200)
                {
                    try
                    {
                        // 下载完100-200,再下载200以后
                        int mycount = datacount - 200;
                        try
                        {
                            int[] mydata = new int[1000];
                            for (int i = 0; i < 1000; i++)
                            {
                                mydata[i] = down_data1[i + 200];
                            }
                            mymodbus.Send_Write_Cmd16(machine_num, mycount, xiazai_data12.ToString("X").PadLeft(4, '0'), mydata);
                        }
                        catch { return; }
                    }
                    catch { return; }
                }

                if (step == 12 && datacount > 200)
                {
                    try
                    {
                        // 下载完200以后，直接下载下一条
                        try
                        {
                            mymodbus.Send_Write_Cmd16(machine_num, 100, xiazai_data2.ToString("X").PadLeft(4, '0'), down_data2);
                        }
                        catch { return; }
                    }
                    catch { return; }
                }
                #endregion

                #region                       // 下载第二步
                if (step == 2 && datacount <= 100)
                {
                    // 直接下载第三步
                    try
                    {
                        mymodbus.Send_Write_Cmd16(machine_num, datacount, xiazai_data3.ToString("X").PadLeft(4, '0'), down_data3);
                    }
                    catch { return; }
                }

                if (step == 2 && datacount > 100 && datacount <= 200)
                {
                    // 下载100以后的地址
                    int mycount = datacount - 100;
                    try
                    {
                        int[] mydata = new int[1000];
                        for (int i = 0; i < 1000; i++)
                        {
                            mydata[i] = down_data2[i + 100];
                        }
                        mymodbus.Send_Write_Cmd16(machine_num, mycount, xiazai_data21.ToString("X").PadLeft(4, '0'), mydata);
                    }
                    catch { return; }
                }


                if (step == 2 && datacount > 200)
                {
                    try
                    {
                        // 下载100-200以后的地址
                        int[] mydata = new int[1000];
                        for (int i = 0; i < 1000; i++)
                        {
                            mydata[i] = down_data2[i + 100];
                        }
                        mymodbus.Send_Write_Cmd16(machine_num, 100, xiazai_data21.ToString("X").PadLeft(4, '0'), mydata);
                    }
                    catch { return; }
                }

                if (step == 21 && datacount > 100 && datacount <= 200)
                {
                    try
                    {
                        // 下载完100以后，直接下载下一步
                        mymodbus.Send_Write_Cmd16(machine_num, 100, xiazai_data3.ToString("X").PadLeft(4, '0'), down_data3);
                    }
                    catch { return; }
                }

                if (step == 21 && datacount > 200)
                {
                    try
                    {
                        // 下载完100-200,再下载200以后
                        int mycount = datacount - 200;
                        try
                        {
                            int[] mydata = new int[1000];
                            for (int i = 0; i < 1000; i++)
                            {
                                mydata[i] = down_data2[i + 200];
                            }
                            mymodbus.Send_Write_Cmd16(machine_num, mycount, xiazai_data22.ToString("X").PadLeft(4, '0'), mydata);
                        }
                        catch { return; }
                    }
                    catch { return; }
                }

                if (step == 22 && datacount > 200)
                {
                    try
                    {
                        // 下载完200以后，直接下载下一条
                        try
                        {
                            mymodbus.Send_Write_Cmd16(machine_num, 100, xiazai_data3.ToString("X").PadLeft(4, '0'), down_data3);
                        }
                        catch { return; }
                    }
                    catch { return; }
                }
                #endregion

                #region                       // 下载第三步
                if (step == 3 && datacount <= 100)
                {
                    // 直接下载第四步
                    try
                    {
                        mymodbus.Send_Write_Cmd16(machine_num, datacount, xiazai_data4.ToString("X").PadLeft(4, '0'), down_data4);
                    }
                    catch { return; }
                }

                if (step == 3 && datacount > 100 && datacount <= 200)
                {
                    // 下载100以后的地址
                    int mycount = datacount - 100;
                    try
                    {
                        int[] mydata = new int[1000];
                        for (int i = 0; i < 1000; i++)
                        {
                            mydata[i] = down_data3[i + 100];
                        }
                        mymodbus.Send_Write_Cmd16(machine_num, mycount, xiazai_data31.ToString("X").PadLeft(4, '0'), mydata);
                    }
                    catch { return; }
                }


                if (step == 3 && datacount > 200)
                {
                    try
                    {
                        // 下载100-200以后的地址
                        int[] mydata = new int[1000];
                        for (int i = 0; i < 1000; i++)
                        {
                            mydata[i] = down_data3[i + 100];
                        }
                        mymodbus.Send_Write_Cmd16(machine_num, 100, xiazai_data31.ToString("X").PadLeft(4, '0'), mydata);
                    }
                    catch { return; }
                }

                if (step == 31 && datacount > 100 && datacount <= 200)
                {
                    try
                    {
                        // 下载完100以后，直接下载下一步
                        mymodbus.Send_Write_Cmd16(machine_num, 100, xiazai_data4.ToString("X").PadLeft(4, '0'), down_data4);
                    }
                    catch { return; }
                }

                if (step == 31 && datacount > 200)
                {
                    try
                    {
                        // 下载完100-200,再下载200以后
                        int mycount = datacount - 200;
                        try
                        {
                            int[] mydata = new int[1000];
                            for (int i = 0; i < 1000; i++)
                            {
                                mydata[i] = down_data3[i + 200];
                            }
                            mymodbus.Send_Write_Cmd16(machine_num, mycount, xiazai_data32.ToString("X").PadLeft(4, '0'), mydata);
                        }
                        catch { return; }
                    }
                    catch { return; }
                }

                if (step == 32 && datacount > 200)
                {
                    try
                    {
                        // 下载完200以后，直接下载下一条
                        try
                        {
                            mymodbus.Send_Write_Cmd16(machine_num, 100, xiazai_data4.ToString("X").PadLeft(4, '0'), down_data4);
                        }
                        catch { return; }
                    }
                    catch { return; }
                }
                #endregion

                #region                       // 下载第四步
                if (step == 4 && datacount <= 100)
                {
                    // 直接下载第四步
                    try
                    {
                        mymodbus.Send_Write_Cmd16(machine_num, datacount, xiazai_data5.ToString("X").PadLeft(4, '0'), down_data5);
                    }
                    catch { return; }
                }

                if (step == 4 && datacount > 100 && datacount <= 200)
                {
                    // 下载100以后的地址
                    int mycount = datacount - 100;
                    try
                    {
                        int[] mydata = new int[1000];
                        for (int i = 0; i < 1000; i++)
                        {
                            mydata[i] = down_data4[i + 100];
                        }
                        mymodbus.Send_Write_Cmd16(machine_num, mycount, xiazai_data41.ToString("X").PadLeft(4, '0'), mydata);
                    }
                    catch { return; }
                }


                if (step == 4 && datacount > 200)
                {
                    try
                    {
                        // 下载100-200以后的地址
                        int[] mydata = new int[1000];
                        for (int i = 0; i < 1000; i++)
                        {
                            mydata[i] = down_data4[i + 100];
                        }
                        mymodbus.Send_Write_Cmd16(machine_num, 100, xiazai_data41.ToString("X").PadLeft(4, '0'), mydata);
                    }
                    catch { return; }
                }

                if (step == 41 && datacount > 100 && datacount <= 200)
                {
                    try
                    {
                        // 下载完100以后，直接下载下一步
                        mymodbus.Send_Write_Cmd16(machine_num, 100, xiazai_data5.ToString("X").PadLeft(4, '0'), down_data5);
                    }
                    catch { return; }
                }

                if (step == 41 && datacount > 200)
                {
                    try
                    {
                        // 下载完100-200,再下载200以后
                        int mycount = datacount - 200;
                        try
                        {
                            int[] mydata = new int[1000];
                            for (int i = 0; i < 1000; i++)
                            {
                                mydata[i] = down_data4[i + 200];
                            }
                            mymodbus.Send_Write_Cmd16(machine_num, mycount, xiazai_data42.ToString("X").PadLeft(4, '0'), mydata);
                        }
                        catch { return; }
                    }
                    catch { return; }
                }

                if (step == 42 && datacount > 200)
                {
                    try
                    {
                        // 下载完200以后，直接下载下一条
                        try
                        {
                            mymodbus.Send_Write_Cmd16(machine_num, 100, xiazai_data5.ToString("X").PadLeft(4, '0'), down_data5);
                        }
                        catch { return; }
                    }
                    catch { return; }
                }
                #endregion

                #region                       // 下载第五步
                if (step == 5 && datacount <= 100)
                {
                    // 直接下载第四步
                    try
                    {
                        mymodbus.Send_Write_Cmd16(machine_num, datacount, xiazai_data6.ToString("X").PadLeft(4, '0'), down_data6);
                    }
                    catch { return; }
                }

                if (step == 5 && datacount > 100 && datacount <= 200)
                {
                    // 下载100以后的地址
                    int mycount = datacount - 100;
                    try
                    {
                        int[] mydata = new int[1000];
                        for (int i = 0; i < 1000; i++)
                        {
                            mydata[i] = down_data5[i + 100];
                        }
                        mymodbus.Send_Write_Cmd16(machine_num, mycount, xiazai_data51.ToString("X").PadLeft(4, '0'), mydata);
                    }
                    catch { return; }
                }


                if (step == 5 && datacount > 200)
                {
                    try
                    {
                        // 下载100-200以后的地址
                        int[] mydata = new int[1000];
                        for (int i = 0; i < 1000; i++)
                        {
                            mydata[i] = down_data5[i + 100];
                        }
                        mymodbus.Send_Write_Cmd16(machine_num, 100, xiazai_data51.ToString("X").PadLeft(4, '0'), mydata);
                    }
                    catch { return; }
                }

                if (step == 51 && datacount > 100 && datacount <= 200)
                {
                    try
                    {
                        // 下载完100以后，直接下载下一步
                        mymodbus.Send_Write_Cmd16(machine_num, 100, xiazai_data6.ToString("X").PadLeft(4, '0'), down_data6);
                    }
                    catch { return; }
                }

                if (step == 51 && datacount > 200)
                {
                    try
                    {
                        // 下载完100-200,再下载200以后
                        int mycount = datacount - 200;
                        try
                        {
                            int[] mydata = new int[1000];
                            for (int i = 0; i < 1000; i++)
                            {
                                mydata[i] = down_data5[i + 200];
                            }
                            mymodbus.Send_Write_Cmd16(machine_num, mycount, xiazai_data52.ToString("X").PadLeft(4, '0'), mydata);
                        }
                        catch { return; }
                    }
                    catch { return; }
                }

                if (step == 52 && datacount > 200)
                {
                    try
                    {
                        // 下载完200以后，直接下载下一条
                        try
                        {
                            mymodbus.Send_Write_Cmd16(machine_num, 100, xiazai_data6.ToString("X").PadLeft(4, '0'), down_data6);
                        }
                        catch { return; }
                    }
                    catch { return; }
                }
                #endregion

                #region                       // 下载第六步
                if (step == 6 && datacount <= 100)
                {
                    // 直接下载第六步
                    try
                    {
                        mymodbus.Send_Write_Cmd5(machine_num, (address + 2048).ToString("X").PadLeft(4, '0'), "FF00");



                        string[] update_cmd = new string[1];
                        update_cmd[0] = "start_time='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";

                        string where_cmd1 = "machine_num='" + machine_num.ToString() + "'";
                        MainView.builder.Updata("start_time", where_cmd1, update_cmd);
                        

                        step = 0;
                    }
                    catch { return; }
                }

                if (step == 6 && datacount > 100 && datacount <= 200)
                {
                    // 下载100以后的地址
                    int mycount = datacount - 100;
                    try
                    {
                        int[] mydata = new int[1000];
                        for (int i = 0; i < 1000; i++)
                        {
                            mydata[i] = down_data6[i + 100];
                        }
                        mymodbus.Send_Write_Cmd16(machine_num, mycount, xiazai_data61.ToString("X").PadLeft(4, '0'), mydata);
                    }
                    catch { return; }
                }


                if (step == 6 && datacount > 200)
                {
                    try
                    {
                        // 下载100-200以后的地址
                        int[] mydata = new int[1000];
                        for (int i = 0; i < 1000; i++)
                        {
                            mydata[i] = down_data6[i + 100];
                        }
                        mymodbus.Send_Write_Cmd16(machine_num, 100, xiazai_data61.ToString("X").PadLeft(4, '0'), mydata);
                    }
                    catch { return; }
                }

                if (step == 61 && datacount > 100 && datacount <= 200)
                {
                    try
                    {
                        // 下载完100以后，直接下载下一步
                        mymodbus.Send_Write_Cmd5(machine_num, (address + 2048).ToString("X").PadLeft(4, '0'), "FF00");
                        string[] update_cmd = new string[1];
                        update_cmd[0] = "start_time='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";

                        string where_cmd1 = "machine_num=" + machine_num.ToString() + "'";
                        MainView.builder.Updata("start_time", where_cmd1, update_cmd);
                        
                        step = 0;
                    }
                    catch { return; }
                }

                if (step == 61 && datacount > 200)
                {
                    try
                    {
                        // 下载完100-200,再下载200以后
                        int mycount = datacount - 200;
                        try
                        {
                            int[] mydata = new int[1000];
                            for (int i = 0; i < 1000; i++)
                            {
                                mydata[i] = down_data6[i + 200];
                            }
                            mymodbus.Send_Write_Cmd16(machine_num, mycount, xiazai_data62.ToString("X").PadLeft(4, '0'), mydata);
                        }
                        catch { return; }
                    }
                    catch { return; }
                }

                if (step == 62 && datacount > 200)
                {
                    try
                    {
                        // 下载完200以后，直接下载下一条
                        try
                        {
                            mymodbus.Send_Write_Cmd5(machine_num, (address + 2048).ToString("X").PadLeft(4, '0'), "FF00");
                            string[] update_cmd = new string[1];
                            update_cmd[0] = "start_time='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";

                            string where_cmd1 = "machine_num=" + machine_num.ToString() + "'";
                            MainView.builder.Updata("start_time", where_cmd1, update_cmd);
                            
                            step = 0;
                        }
                        catch { return; }
                    }
                    catch { return; }
                }
                #endregion
            }
        }

        private void Red_Green_zhifan_Button_Resize(object sender, EventArgs e)
        {
            AutoSize = false;
            button1.Top = 0;
            button1.Left = 0;
            button1.Width = this.Width;
            button1.Height = this.Height;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region   // mode=0
            if (mode==0)
            {
                DialogResult myresult = MessageBox.Show("是否确认操作","",MessageBoxButtons.OKCancel);
                if (myresult == DialogResult.OK)
                {

                    if(value==false)
                    {
                        string where_cmd = "ID='" + device_name + "'";
                        DataTable dt = MainView.builder.Select_Table("Device_Info", where_cmd);
                        
                        try
                        {
                            //int address=int.Parse(dt.Rows[0][5].ToString())+2048;
                            if (dt.Rows[0][4].ToString() == "串口1")
                            {
                                Deivce_Info.modbus1.Send_Write_Cmd5(machine_num, (address+2048).ToString("X").PadLeft(4,'0'), "FF00");
                            }
                            if (dt.Rows[0][4].ToString() == "串口2")
                            {
                                Deivce_Info.modbus2.Send_Write_Cmd5(machine_num, (address + 2048).ToString("X").PadLeft(4, '0'), "FF00");
                            }
                            if (dt.Rows[0][4].ToString() == "串口3")
                            {
                                Deivce_Info.modbus3.Send_Write_Cmd5(machine_num, (address + 2048).ToString("X").PadLeft(4, '0'), "FF00");
                            }
                            if (dt.Rows[0][4].ToString() == "串口4")
                            {
                                Deivce_Info.modbus4.Send_Write_Cmd5(machine_num, (address + 2048).ToString("X").PadLeft(4, '0'), "FF00");
                            }
                            if (dt.Rows[0][4].ToString() == "串口5")
                            {
                                Deivce_Info.modbus5.Send_Write_Cmd5(machine_num, (address + 2048).ToString("X").PadLeft(4, '0'), "FF00");
                            }
                            if (dt.Rows[0][4].ToString() == "串口6")
                            {
                                Deivce_Info.modbus6.Send_Write_Cmd5(machine_num, (address + 2048).ToString("X").PadLeft(4, '0'), "00ff");
                            }
                        }
                        catch { }
                    }
                    else
                    {
                        string where_cmd = "ID='" + device_name + "'";
                        DataTable dt = MainView.builder.Select_Table("Device_Info", where_cmd);

                        try
                        {
                            //int address = int.Parse(dt.Rows[0][5].ToString());
                            if (dt.Rows[0][4].ToString() == "串口1")
                            {
                                Deivce_Info.modbus1.Send_Write_Cmd5(machine_num, (address + 2048).ToString("X").PadLeft(4, '0'), "0000");
                            }
                            if (dt.Rows[0][4].ToString() == "串口2")
                            {
                                Deivce_Info.modbus2.Send_Write_Cmd5(machine_num, (address + 2048).ToString("X").PadLeft(4, '0'), "0000");
                            }
                            if (dt.Rows[0][4].ToString() == "串口3")
                            {
                                Deivce_Info.modbus3.Send_Write_Cmd5(machine_num, (address + 2048).ToString("X").PadLeft(4, '0'), "0000");
                            }
                            if (dt.Rows[0][4].ToString() == "串口4")
                            {
                                Deivce_Info.modbus4.Send_Write_Cmd5(machine_num, (address + 2048).ToString("X").PadLeft(4, '0'), "0000");
                            }
                            if (dt.Rows[0][4].ToString() == "串口5")
                            {
                                Deivce_Info.modbus5.Send_Write_Cmd5(machine_num, (address + 2048).ToString("X").PadLeft(4, '0'), "0000");
                            }
                            if (dt.Rows[0][4].ToString() == "串口6")
                            {
                                Deivce_Info.modbus6.Send_Write_Cmd5(machine_num, (address + 2048).ToString("X").PadLeft(4, '0'), "0000");
                            }
                        }
                        catch { }
                    }
                }
            }
            #endregion
            #region   // mode=1
            if (mode == 1)
            {
                DialogResult myresult = MessageBox.Show("是否确认操作", "", MessageBoxButtons.OKCancel);
                if (myresult == DialogResult.OK)
                {
                    string where_cmd = "ID='" + device_name + "'";
                    DataTable dt = MainView.builder.Select_Table("Device_Info", where_cmd);

                        if(MyValue_Name==value_name.启动)
                        {

                            // 启动
                            if(Qidong!=null)
                            {
                                try
                                {
                                    Qidong(this, new EventArgs());
                                }
                                catch
                                {
                                    MessageBox.Show("工艺出现错误!");
                                    return;
                                }
                            }
                            
                           
                            try
                            {
                                // int address = int.Parse(dt.Rows[0][5].ToString());
                                if (dt.Rows[0][4].ToString() == "串口1")
                                {
                                    if (datacount <= 100)
                                    {
                                        Deivce_Info.modbus1.Send_Write_Cmd16(machine_num, datacount, xiazai_data1.ToString("X").PadLeft(4, '0'), down_data1);
                                    }
                                    if(datacount>100)
                                    {
                                        Deivce_Info.modbus1.Send_Write_Cmd16(machine_num, 100, xiazai_data1.ToString("X").PadLeft(4, '0'), down_data1);
                                    }
                                   
                                }
                                if (dt.Rows[0][4].ToString() == "串口2")
                                {
                                    if (datacount <= 100)
                                    {
                                        Deivce_Info.modbus2.Send_Write_Cmd16(machine_num, datacount, xiazai_data1.ToString("X").PadLeft(4, '0'), down_data1);
                                    }
                                    if (datacount > 100)
                                    {
                                        Deivce_Info.modbus2.Send_Write_Cmd16(machine_num, 100, xiazai_data1.ToString("X").PadLeft(4, '0'), down_data1);
                                    }
                                }
                                if (dt.Rows[0][4].ToString() == "串口3")
                                {
                                    if (datacount <= 100)
                                    {
                                        Deivce_Info.modbus3.Send_Write_Cmd16(machine_num, datacount, xiazai_data1.ToString("X").PadLeft(4, '0'), down_data1);
                                    }
                                    if (datacount > 100)
                                    {
                                        Deivce_Info.modbus3.Send_Write_Cmd16(machine_num, 100, xiazai_data1.ToString("X").PadLeft(4, '0'), down_data1);
                                    }
                                }
                                if (dt.Rows[0][4].ToString() == "串口4")
                                {
                                    if (datacount <= 100)
                                    {
                                        Deivce_Info.modbus4.Send_Write_Cmd16(machine_num, datacount, xiazai_data1.ToString("X").PadLeft(4, '0'), down_data1);
                                    }
                                    if (datacount > 100)
                                    {
                                        Deivce_Info.modbus4.Send_Write_Cmd16(machine_num, 100, xiazai_data1.ToString("X").PadLeft(4, '0'), down_data1);
                                    }
                                }
                                if (dt.Rows[0][4].ToString() == "串口5")
                                {
                                    if (datacount <= 100)
                                    {
                                        Deivce_Info.modbus5.Send_Write_Cmd16(machine_num, datacount, xiazai_data1.ToString("X").PadLeft(4, '0'), down_data1);
                                    }
                                    if (datacount > 100)
                                    {
                                        Deivce_Info.modbus5.Send_Write_Cmd16(machine_num, 100, xiazai_data1.ToString("X").PadLeft(4, '0'), down_data1);
                                    }
                                }
                                if (dt.Rows[0][4].ToString() == "串口6")
                                {
                                    if (datacount <= 100)
                                    {
                                        Deivce_Info.modbus6.Send_Write_Cmd16(machine_num, datacount, xiazai_data1.ToString("X").PadLeft(4, '0'), down_data1);
                                    }
                                    if (datacount > 100)
                                    {
                                        Deivce_Info.modbus6.Send_Write_Cmd16(machine_num, 100, xiazai_data1.ToString("X").PadLeft(4, '0'), down_data1);
                                    }
                                }
                            }
                            catch { }




                            return;
                        }
                        where_cmd = "ID='" + device_name + "'";
                         dt = MainView.builder.Select_Table("Device_Info", where_cmd);

                        try
                        {
                           // int address = int.Parse(dt.Rows[0][5].ToString());
                            if (dt.Rows[0][4].ToString() == "串口1")
                            {
                                Deivce_Info.modbus1.Send_Write_Cmd5(machine_num, (address + 2048).ToString("X").PadLeft(4, '0'), "FF00");
                            }
                            if (dt.Rows[0][4].ToString() == "串口2")
                            {
                                Deivce_Info.modbus2.Send_Write_Cmd5(machine_num, (address + 2048).ToString("X").PadLeft(4, '0'), "FF00");
                            }
                            if (dt.Rows[0][4].ToString() == "串口3")
                            {
                                Deivce_Info.modbus3.Send_Write_Cmd5(machine_num, (address + 2048).ToString("X").PadLeft(4, '0'), "FF00");
                            }
                            if (dt.Rows[0][4].ToString() == "串口4")
                            {
                                Deivce_Info.modbus4.Send_Write_Cmd5(machine_num, (address + 2048).ToString("X").PadLeft(4, '0'), "FF00");
                            }
                            if (dt.Rows[0][4].ToString() == "串口5")
                            {
                                Deivce_Info.modbus5.Send_Write_Cmd5(machine_num, (address + 2048).ToString("X").PadLeft(4, '0'), "FF00");
                            }
                            if (dt.Rows[0][4].ToString() == "串口6")
                            {
                                Deivce_Info.modbus6.Send_Write_Cmd5(machine_num, (address + 2048).ToString("X").PadLeft(4, '0'), "FF00");
                            }
                        }
                        catch { }
                   
                }
            }
            #endregion

            #region   // mode=2
            if (mode == 2)
            {
                DialogResult myresult = MessageBox.Show("是否确认操作", "", MessageBoxButtons.OKCancel);
                if (myresult == DialogResult.OK)
                {


                    string where_cmd = "ID='" + device_name + "'";
                    DataTable dt = MainView.builder.Select_Table("Device_Info", where_cmd);

                    try
                    {
                        //int address = int.Parse(dt.Rows[0][5].ToString());
                        if (dt.Rows[0][4].ToString() == "串口1")
                        {
                            Deivce_Info.modbus1.Send_Write_Cmd5(machine_num, (address + 2048).ToString("X").PadLeft(4, '0'), "0000");
                        }
                        if (dt.Rows[0][4].ToString() == "串口2")
                        {
                            Deivce_Info.modbus2.Send_Write_Cmd5(machine_num, (address + 2048).ToString("X").PadLeft(4, '0'), "0000");
                        }
                        if (dt.Rows[0][4].ToString() == "串口3")
                        {
                            Deivce_Info.modbus3.Send_Write_Cmd5(machine_num, (address + 2048).ToString("X").PadLeft(4, '0'), "0000");
                        }
                        if (dt.Rows[0][4].ToString() == "串口4")
                        {
                            Deivce_Info.modbus4.Send_Write_Cmd5(machine_num, (address + 2048).ToString("X").PadLeft(4, '0'), "0000");
                        }
                        if (dt.Rows[0][4].ToString() == "串口5")
                        {
                            Deivce_Info.modbus5.Send_Write_Cmd5(machine_num, (address + 2048).ToString("X").PadLeft(4, '0'), "0000");
                        }
                        if (dt.Rows[0][4].ToString() == "串口6")
                        {
                            Deivce_Info.modbus6.Send_Write_Cmd5(machine_num, (address + 2048).ToString("X").PadLeft(4, '0'), "0000");
                        }
                    }
                    catch { }

                }
            }
            #endregion

        }

        private void Red_Green_zhifan_Button_Click(object sender, EventArgs e)
        {
           
        }

        private void Red_Green_zhifan_Button_Load(object sender, EventArgs e)
        {

        }
    }
}
