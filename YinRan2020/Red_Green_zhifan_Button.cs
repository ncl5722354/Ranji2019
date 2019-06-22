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

        /// <summary>
        ///  mode = 0 置反
        ///  mode = 1 置1
        ///  mode = 2 置2
        ///  truecolor
        ///  falsecolor
        /// </summary>
        /// 


        private string device_name = "";          // 设备名称属性
        private Color truecolor;
        private Color falsecolor;
        private Color show_color;
        private int mode = 0;
        int machine_num;
        int address;
        bool value = false;

        public  static int step = 0;
        public  static int xiazai_data1 = 2000; 
        public  static int xiazai_data2 = 2500;
        public  static int xiazai_data3 = 3000;
        public  static int xiazai_data4 = 3500;
        public  static int xiazai_data5 = 4000;
        public  static int xiazai_data6 = 4500;

        private value_name MyValue_Name = value_name.进水1;
        public DataGridView gongyidatagridview1 = null;
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
            料缸手自动
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
    }
}
