using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace YinRan2020
{
    public partial class MyLabel_time : UserControl
    {
        private string device_name = "";          // 设备名称属性
        private string show_text = "";            // 

        private value_name MyValue_Name=value_name.工艺运行时间;
        public enum value_name
        {
            // 模拟量输出
            工艺运行时间,
            总运行时间
        };


        public MyLabel_time()
        {
            InitializeComponent();
            
        }


        public void init()
        {
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
        

        private void thread()
        {
            // 创建device_name的标签
            try
            {
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
                    int machine_num = int.Parse(dt_read_chejian.Rows[0][5].ToString()); // 机号

                    // 读取数据的种类与地址
                    string where_data = "value_name='" + Value_Name.ToString() + "'";
                    DataTable dt_data = MainView.builder.Select_Table("Value_Config", where_data);
                    string Type = dt_data.Rows[0][1].ToString();                      // 数据种类
                    int address = int.Parse(dt_data.Rows[0][2].ToString());           // 数据地址

                    DateTime datetime = DateTime.Parse("00:00:00");

                    if (com_name == "串口1")
                    {
                        int time = Device_Data.chejian1_com1_DT[machine_num, address];
                        datetime = datetime.AddSeconds(time);
                        if (Type == "DT") show_text = datetime.ToString("HH:mm:ss");
                        if (Type == "R") show_text = Device_Data.chejian1_com1_R[machine_num, address].ToString();
                    }
                    if (com_name == "串口2")
                    {
                        int time = Device_Data.chejian1_com2_DT[machine_num, address];
                        datetime = datetime.AddSeconds(time);
                        if (Type == "DT") show_text = datetime.ToString("HH:mm:ss");
                        if (Type == "R") show_text = Device_Data.chejian1_com2_R[machine_num, address].ToString();
                    }
                    if (com_name == "串口3")
                    {
                        int time = Device_Data.chejian1_com3_DT[machine_num, address];
                        datetime = datetime.AddSeconds(time);
                        if (Type == "DT") show_text = datetime.ToString("HH:mm:ss");
                        if (Type == "R") show_text = Device_Data.chejian1_com3_R[machine_num, address].ToString();
                    }
                    if (com_name == "串口4")
                    {
                        int time = Device_Data.chejian1_com4_DT[machine_num, address];
                        datetime = datetime.AddSeconds(time);
                        if (Type == "DT") show_text = datetime.ToString("HH:mm:ss");
                        if (Type == "R") show_text = Device_Data.chejian1_com4_R[machine_num, address].ToString();
                    }
                    if (com_name == "串口5")
                    {
                        int time = Device_Data.chejian1_com5_DT[machine_num, address];
                        datetime = datetime.AddSeconds(time);
                        if (Type == "DT") show_text = datetime.ToString("HH:mm:ss");
                        if (Type == "R") show_text = Device_Data.chejian1_com5_R[machine_num, address].ToString();
                    }
                    if (com_name == "串口6")
                    {
                        int time = Device_Data.chejian1_com6_DT[machine_num, address];
                        datetime = datetime.AddSeconds(time);
                        if (Type == "DT") show_text = datetime.ToString("HH:mm:ss");
                        if (Type == "R") show_text = Device_Data.chejian1_com6_R[machine_num, address].ToString();
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
                        int value = int.Parse(value_string);
                        DateTime datetime = DateTime.Parse("HH:mm:ss");
                        datetime = datetime.AddSeconds(value);

                        show_text = value.ToString("HH:mm:ss");
                    }
                    catch { }
                }

                // ======================== 二车间 ========================
                if (chejian_name == "二车间" && MainView.Connect_Chejian_Num == "2")
                {
                    // 只有一车间的值从DT中读,其他的值从数据库中读
                    string com_name = dt_read_chejian.Rows[0][4].ToString();        // 串口信息
                    int machine_num = int.Parse(dt_read_chejian.Rows[0][5].ToString()); // 机号

                    // 读取数据的种类与地址
                    string where_data = "value_name='" + Value_Name.ToString() + "'";
                    DataTable dt_data = MainView.builder.Select_Table("Value_Config", where_data);
                    string Type = dt_data.Rows[0][1].ToString();                      // 数据种类
                    int address = int.Parse(dt_data.Rows[0][2].ToString());           // 数据地址
                    DateTime datetime = DateTime.Parse("00:00:00");

                    if (com_name == "串口1")
                    {
                        int time = Device_Data.chejian2_com1_DT[machine_num, address];
                        datetime = datetime.AddSeconds(time);
                        if (Type == "DT") show_text = datetime.ToString("HH:mm:ss");
                        if (Type == "R") show_text = Device_Data.chejian2_com1_R[machine_num, address].ToString();
                    }
                    if (com_name == "串口2")
                    {
                        int time = Device_Data.chejian2_com2_DT[machine_num, address];
                        datetime = datetime.AddSeconds(time);
                        if (Type == "DT") show_text = datetime.ToString("HH:mm:ss");
                        if (Type == "R") show_text = Device_Data.chejian2_com2_R[machine_num, address].ToString();
                    }
                    if (com_name == "串口3")
                    {
                        int time = Device_Data.chejian2_com3_DT[machine_num, address];
                        datetime = datetime.AddSeconds(time);
                        if (Type == "DT") show_text = datetime.ToString("HH:mm:ss");
                        if (Type == "R") show_text = Device_Data.chejian2_com3_R[machine_num, address].ToString();
                    }
                    if (com_name == "串口4")
                    {
                        int time = Device_Data.chejian2_com4_DT[machine_num, address];
                        datetime = datetime.AddSeconds(time);
                        if (Type == "DT") show_text = datetime.ToString("HH:mm:ss");
                        if (Type == "R") show_text = Device_Data.chejian2_com4_R[machine_num, address].ToString();
                    }
                    if (com_name == "串口5")
                    {
                        int time = Device_Data.chejian2_com5_DT[machine_num, address];
                        datetime = datetime.AddSeconds(time);
                        if (Type == "DT") show_text = datetime.ToString("HH:mm:ss");
                        if (Type == "R") show_text = Device_Data.chejian2_com5_R[machine_num, address].ToString();
                    }
                    if (com_name == "串口6")
                    {
                        int time = Device_Data.chejian2_com6_DT[machine_num, address];
                        datetime = datetime.AddSeconds(time);
                        if (Type == "DT") show_text = datetime.ToString("HH:mm:ss");
                        if (Type == "R") show_text = Device_Data.chejian2_com6_R[machine_num, address].ToString();
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
                        int value = int.Parse(value_string);
                        DateTime datetime = DateTime.Parse("HH:mm:ss");
                        datetime = datetime.AddSeconds(value);

                        show_text = value.ToString("HH:mm:ss");
                    }
                    catch { }
                }
                // ======================== 三车间 ========================
                if (chejian_name == "三车间" && MainView.Connect_Chejian_Num == "3")
                {
                    // 只有一车间的值从DT中读,其他的值从数据库中读
                    string com_name = dt_read_chejian.Rows[0][4].ToString();        // 串口信息
                    int machine_num = int.Parse(dt_read_chejian.Rows[0][5].ToString()); // 机号

                    // 读取数据的种类与地址
                    string where_data = "value_name='" + Value_Name.ToString() + "'";
                    DataTable dt_data = MainView.builder.Select_Table("Value_Config", where_data);
                    string Type = dt_data.Rows[0][1].ToString();                      // 数据种类
                    int address = int.Parse(dt_data.Rows[0][2].ToString());           // 数据地址
                    DateTime datetime = DateTime.Parse("00:00:00");
                    if (com_name == "串口1")
                    {
                        int time = Device_Data.chejian3_com1_DT[machine_num, address];
                        datetime = datetime.AddSeconds(time);
                        if (Type == "DT") show_text = datetime.ToString("HH:mm:ss");
                        if (Type == "R") show_text = Device_Data.chejian3_com1_R[machine_num, address].ToString();
                    }
                    if (com_name == "串口2")
                    {
                        int time = Device_Data.chejian3_com2_DT[machine_num, address];
                        datetime = datetime.AddSeconds(time);
                        if (Type == "DT") show_text = datetime.ToString("HH:mm:ss");
                        if (Type == "R") show_text = Device_Data.chejian3_com2_R[machine_num, address].ToString();
                    }
                    if (com_name == "串口3")
                    {
                        int time = Device_Data.chejian3_com3_DT[machine_num, address];
                        datetime = datetime.AddSeconds(time);
                        if (Type == "DT") show_text = datetime.ToString("HH:mm:ss");
                        if (Type == "R") show_text = Device_Data.chejian3_com3_R[machine_num, address].ToString();
                    }
                    if (com_name == "串口4")
                    {
                        int time = Device_Data.chejian3_com4_DT[machine_num, address];
                        datetime = datetime.AddSeconds(time);
                        if (Type == "DT") show_text = datetime.ToString("HH:mm:ss");
                        if (Type == "R") show_text = Device_Data.chejian3_com4_R[machine_num, address].ToString();
                    }
                    if (com_name == "串口5")
                    {
                        int time = Device_Data.chejian3_com5_DT[machine_num, address];
                        datetime = datetime.AddSeconds(time);
                        if (Type == "DT") show_text = datetime.ToString("HH:mm:ss");
                        if (Type == "R") show_text = Device_Data.chejian3_com5_R[machine_num, address].ToString();
                    }
                    if (com_name == "串口6")
                    {
                        int time = Device_Data.chejian3_com6_DT[machine_num, address];
                        datetime = datetime.AddSeconds(time);
                        if (Type == "DT") show_text = datetime.ToString("HH:mm:ss");
                        if (Type == "R") show_text = Device_Data.chejian3_com6_R[machine_num, address].ToString();
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
                        int value = int.Parse(value_string);
                        DateTime datetime = DateTime.Parse("HH:mm:ss");
                        datetime = datetime.AddSeconds(value);

                        show_text = value.ToString("HH:mm:ss");
                    }
                    catch { }
                }


            }
            catch { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread mythread = new Thread(thread);
            mythread.Start();
            label1.Text = show_text;
        }



        

        private void label1_Resize(object sender, EventArgs e)
        {

        }

        private void MyLabel_Resize(object sender, EventArgs e)
        {
            AutoSize = false;
            label1.Top = 0;
            label1.Left = 0;
            label1.Width = this.Width;
            label1.Height = this.Height;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
