﻿using System;
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
using System.IO.Ports;
using Communication;

namespace YinRan2020
{
    public partial class Deivce_Info : Form
    {
        private string chejian_name;
        SerialPort sp_test = new SerialPort();                               // 串口检测单位

        /// <summary>
        ///  六个串口
        /// </summary>

        public  static port_moudbus modbus1 = new port_moudbus();
        public static  port_moudbus modbus2 = new port_moudbus();
        public static  port_moudbus modbus3 = new port_moudbus();
        public static  port_moudbus modbus4 = new port_moudbus();
        public static  port_moudbus modbus5 = new port_moudbus();
        public static  port_moudbus modbus6 = new port_moudbus();

        public Deivce_Info()
        {
            InitializeComponent();
            init_view();
        }

        private void init_view()
        {
            // 标题
            ViewCaoZuo.Object_Position(0.01, 0, 1, 0.05, label_title, this.Controls);

            // 工具栏
            ViewCaoZuo.Object_Position(0.01, 0.05, 1, 0.05, panel_tool, this.Controls);


            ViewCaoZuo.Object_Position(0.01, 0, 1, 1, toolStrip1, panel_tool.Controls);

            // 选择树形图
            ViewCaoZuo.Object_Position(0.01, 0.1, 0.1, 0.85, treeView1, this.Controls);

            // 串口信息
            ViewCaoZuo.Object_Position(0.12, 0.1, 0.85, 0.2, panel_com_info, this.Controls);

            // 数据设置标题
            ViewCaoZuo.Object_Position(0.12, 0.1, 0.85, 0.2, panel_dataset, this.Controls);

            // 表格背景
            ViewCaoZuo.Object_Position(0.12, 0.35, 0.85, 0.6, panel1, this.Controls);

            // 表格
            ViewCaoZuo.Object_Position(0.01, 0.01, 0.98, 0.98, myDataGridView1, panel1.Controls);



            Create_Device_Database();   // 创建串口通讯表

            // 波特率下拉菜单
            comboBox_botelv.Items.Clear();
            comboBox_botelv.Items.Add("2‘kps");
            comboBox_botelv.Items.Add("4800kps");
            comboBox_botelv.Items.Add("9600kps");
            comboBox_botelv.Items.Add("19200kps");
            comboBox_botelv.Items.Add("38400kps");

            // 数据位下拉菜单

            comboBox_shujuwei.Items.Clear();
            comboBox_shujuwei.Items.Add("8bits");
            comboBox_shujuwei.Items.Add("7bits");

            // 停止位
            comboBox_tingzhiwei.Items.Clear();
            comboBox_tingzhiwei.Items.Add("1bit");
            comboBox_tingzhiwei.Items.Add("2bits");

            // 校验位
            comboBox_jiaoyanwei.Items.Clear();
            comboBox_jiaoyanwei.Items.Add("none");
            comboBox_jiaoyanwei.Items.Add("odd");
            comboBox_jiaoyanwei.Items.Add("even");

            modbus1.com_num = 1;
            modbus2.com_num = 2;
            modbus3.com_num = 3;
            modbus4.com_num = 4;
            modbus5.com_num = 5;
            modbus6.com_num = 6;

            Read_All_Com();
        }

        public void Set_Chenjian(string name)
        {
            label_title.Text = name + "设备设置";
            chejian_name = name;
        }

        private void Create_Device_Database()
        {
            // 创建串口通讯数据库
            CreateSqlValueType[] create_cmd = new CreateSqlValueType[7];
            create_cmd[0] = new CreateSqlValueType("nvarchar(50)", "com_name", true);
            create_cmd[1] = new CreateSqlValueType("nvarchar(50)", "com_num");
            create_cmd[2] = new CreateSqlValueType("nvarchar(50)", "botelv");
            create_cmd[3] = new CreateSqlValueType("nvarchar(50)", "shujuwei");
            create_cmd[4] = new CreateSqlValueType("nvarchar(50)", "tingzhiwei");
            create_cmd[5] = new CreateSqlValueType("nvarchar(50)", "jiaoyanwei");
            create_cmd[6] = new CreateSqlValueType("nvarchar(50)", "chejian");
            MainView.builder.Create_Table("com_config", create_cmd);
        }

        private void Deivce_Info_Resize(object sender, EventArgs e)
        {
            init_view();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // 添加一个数据
            try
            {
                if (treeView1.SelectedNode.Text.Substring(0, 2) == "串口")
                {
                    AddCraft view = new AddCraft();
                    AddCraft.Chejian_Name = chejian_name;
                    view.ShowDialog();
                    Read_Device_Info_Form_DataBase(); // 重新读取表格
                }
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 保存时如果找不到相应的串口号，就插入一个，否则更新一个

            Save_Com_Info();          // 保存信息

        }

        private void Save_Com_Info()
        {
            // 输入异常处理
            if (comboBox_chuankouhao.Text == "") { MessageBox.Show("串口号不能为空！"); return; };
            if (comboBox_botelv.Text == "") { MessageBox.Show("波特率不能为空！"); return; }
            if (comboBox_shujuwei.Text == "") { MessageBox.Show("数据位不能为空！"); return; }
            if (comboBox_tingzhiwei.Text == "") { MessageBox.Show("停止位不能为空！"); return; }
            if (comboBox_jiaoyanwei.Text == "") { MessageBox.Show("校验位不能为空！"); return; }
            string com_name = "";
            try
            {
                com_name = treeView1.SelectedNode.Text;
            }
            catch { MessageBox.Show("选择正确的串口！"); }
            if (com_name == "串口1" || com_name == "串口2" || com_name == "串口3" || com_name == "串口4" || com_name == "串口5" || com_name == "串口6")
            {
                com_name = com_name + chejian_name;    //串口名字


                // 更新失败，插入一行
                string[] insert_cmd = new string[7];
                insert_cmd[0] = com_name;
                insert_cmd[1] = comboBox_chuankouhao.Text;
                insert_cmd[2] = comboBox_botelv.Text;
                insert_cmd[3] = comboBox_shujuwei.Text;
                insert_cmd[4] = comboBox_tingzhiwei.Text;
                insert_cmd[5] = comboBox_jiaoyanwei.Text;
                insert_cmd[6] = chejian_name;
                bool result = MainView.builder.Insert("com_config", insert_cmd);


                if (result == false)
                {
                    string[] update_cmd = new string[7];
                    update_cmd[0] = "com_name='" + com_name + "'";
                    update_cmd[1] = "com_num='" + comboBox_chuankouhao.Text + "'";
                    update_cmd[2] = "botelv='" + comboBox_botelv.Text + "'";
                    update_cmd[3] = "shujuwei='" + comboBox_shujuwei.Text + "'";
                    update_cmd[4] = "tingzhiwei='" + comboBox_tingzhiwei.Text + "'";
                    update_cmd[5] = "jiaoyanwei='" + comboBox_jiaoyanwei.Text + "'";
                    update_cmd[6] = "chejian='" + chejian_name + "'";
                    string where_cmd = "com_name='" + com_name + "'";
                    MainView.builder.Updata("com_config", where_cmd, update_cmd);
                }

            }
            else
            {
                MessageBox.Show("选择正确的串口！");
            }

        }

        private void comboBox_chuankouhao_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_chuankouhao_DropDown(object sender, EventArgs e)
        {
            // 更新本机串口信息
            comboBox_chuankouhao.Items.Clear();
            for (int i = 1; i <= 100; i++)
            {
                sp_test.PortName = "com" + i.ToString();
                try
                {
                    sp_test.Open();
                    comboBox_chuankouhao.Items.Add("com" + i.ToString());
                    sp_test.Close();
                }
                catch { }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {
                string com_name = treeView1.SelectedNode.Text;

                if (com_name == "串口1" || com_name == "串口2" || com_name == "串口3" || com_name == "串口4" || com_name == "串口5" || com_name == "串口6")
                {
                    panel_com_info.Visible = true;
                }
                else
                {
                    panel_com_info.Visible = false;
                }

                if(com_name=="数据设置")
                {
                    panel_dataset.Visible = true;
                }
                else
                {
                    panel_dataset.Visible = false;
                }
            }
            catch { panel_com_info.Visible = false; }
        }

        public void Read_All_Com()
        {
            for (int i = 1; i <= 6; i++)
            {
                try
                {
                    string where_cmd = "com_name='" + "串口" + i.ToString() + "三车间'";

                    DataTable dt = MainView.builder.Select_Table("com_config", where_cmd);

                    DataRow dr = dt.Rows[0];
                    if (i == 1)
                    {
                        try
                        {
                            modbus1.sp_config(dr[1].ToString(), dr[2].ToString(), dr[5].ToString(), dr[3].ToString(), dr[4].ToString());
                        }
                        catch { }
                       
                    }
                    if (i == 2)
                    {
                        try
                        {
                            modbus2.sp_config(dr[1].ToString(), dr[2].ToString(), dr[5].ToString(), dr[3].ToString(), dr[4].ToString());
                        }
                        catch { }

                    }
                    if (i == 3)
                    {
                        try
                        {
                            modbus3.sp_config(dr[1].ToString(), dr[2].ToString(), dr[5].ToString(), dr[3].ToString(), dr[4].ToString());
                        }
                        catch { }

                    }
                    if (i == 4)
                    {
                        try
                        {
                            modbus4.sp_config(dr[1].ToString(), dr[2].ToString(), dr[5].ToString(), dr[3].ToString(), dr[4].ToString());
                        }
                        catch { }

                    }
                    if (i == 5)
                    {
                        try
                        {
                            modbus5.sp_config(dr[1].ToString(), dr[2].ToString(), dr[5].ToString(), dr[3].ToString(), dr[4].ToString());
                        }
                        catch { }

                    }
                    if (i == 6)
                    {
                        try
                        {
                            modbus6.sp_config(dr[1].ToString(), dr[2].ToString(), dr[5].ToString(), dr[3].ToString(), dr[4].ToString());
                        }
                        catch { }

                    }
                }
                catch { }
            }
        }
        public  void Read_Device_Info_Form_DataBase()
        {
            // 从数据库里面读取设备数据

            // 分辩是否是读取的串口还是数据设置
            if (treeView1.SelectedNode==null) return;
            if (treeView1.SelectedNode.Text.Substring(0, 2) == "串口")
            {
                Clear_Info(); //清空信息
                try
                {
                    // 读取串口信息
                    string where_cmd = "com_name='" + treeView1.SelectedNode.Text.ToString() + chejian_name + "'";

                    DataTable dt = MainView.builder.Select_Table("com_config", where_cmd);
                    DataRow dr = dt.Rows[0];
                    comboBox_chuankouhao.Text = dr[1].ToString();
                    comboBox_botelv.Text = dr[2].ToString();
                    comboBox_shujuwei.Text = dr[3].ToString();
                    comboBox_tingzhiwei.Text = dr[4].ToString();
                    comboBox_jiaoyanwei.Text = dr[5].ToString();
                }
                catch { }
                try
                {


                    // 读取设备信息
                    string device_where_cmd = "workshop='" + chejian_name + "' and Com='" + treeView1.SelectedNode.Text.ToString() + "'";
                    DataTable device_dt = MainView.builder.Select_Table("Device_Info", device_where_cmd);
                    myDataGridView1.Read_Table(device_dt);
                    string[] header_array = new string[7];
                    header_array[0] = "设备ID";
                    header_array[1] = "设备名称";
                    header_array[2] = "车间名称";
                    header_array[3] = "设备型号";
                    header_array[4] = "通讯串口";
                    header_array[5] = "设备地址";
                    header_array[6] = "通讯协议";
                    myDataGridView1.Set_Header(header_array);  // 设置表格的表头 
                }
                catch { }
            }
            try
            {
                if (treeView1.SelectedNode.Text.Substring(0, 4) == "数据设置")
                {

                    try
                    {
                        DataTable dt = MainView.builder.Select_Table("Value_Config");
                        myDataGridView1.Read_Table(dt);
                        string[] header_array = new string[3];
                        header_array[0] = "数据名称";
                        header_array[1] = "数据类型";
                        header_array[2] = "数据地址";
                        myDataGridView1.Set_Header(header_array);
                    }
                    catch { }

                }
            }
            catch { }



        }

        public void Clear_Info()
        {
            // 清空信息
            comboBox_chuankouhao.Text = "";
            comboBox_botelv.Text = "";
            comboBox_jiaoyanwei.Text = "";
            comboBox_shujuwei.Text = "";
            comboBox_tingzhiwei.Text = "";
            label_zhuangtai.Text = "";
        }




        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Password view = new Password();
            DialogResult reslut = view.ShowDialog();
            if(reslut==DialogResult.OK)
            Read_Device_Info_Form_DataBase();


        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode.Text.Substring(0, 2) == "串口")
                {
                    DeleteDevice view = new DeleteDevice();
                    view.Set_Title("是否删除设备“" + myDataGridView1.Selected_Row().Cells[0].Value.ToString() + "”");
                    DialogResult result = view.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        Delete_Device();
                    }
                }
            }
            catch { }
        }

        private void Delete_Device()
        {
            try
            {
                DataGridViewRow dr = myDataGridView1.Selected_Row();
                string where_cmd = "ID='" + dr.Cells[0].Value.ToString() + "'";
                MainView.builder.Delete("Device_Info", where_cmd);
                Read_Device_Info_Form_DataBase();
            }
            catch { }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView1.SelectedNode.Text.Substring(0, 4) == "数据设置")
                {
                    DataGridViewRow dr = myDataGridView1.Selected_Row();
                    Config_Value view = new Config_Value();
                    view.Set_Title(dr.Cells[0].Value.ToString()+"设置");
                    DialogResult result = view.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string myvalue_type = Config_Value.Value_Type;
                        int address = Config_Value.address;
                        string[] update_cmd = new string[2];
                        update_cmd[0] = "value_type='" + myvalue_type + "'";
                        update_cmd[1] = "value_address='" + address.ToString() + "'";
                        string where_cmd = "value_name='" + dr.Cells[0].Value.ToString() + "'";
                        MainView.builder.Updata("Value_Config", where_cmd, update_cmd);
                        Read_Device_Info_Form_DataBase();
                    }
                }
            }
            catch { }
        }

        private void timer_send1_Tick(object sender, EventArgs e)
        {
            if (modbus1.sp.IsOpen == true)
            {
                if (modbus1.cmd_num > 11)
                {
                    modbus1.cmd_num = 1;
                    modbus1.send_machine_num = modbus1.send_machine_num + 1;
                }
                if (modbus1.send_machine_num > 70) modbus1.send_machine_num = 1;
                if (modbus1.send_is == false && modbus1.receive_is == false)
                {
                    //串口1没有数据发送 发送数据
                    //com1_biaozhi.BackColor = System.Drawing.Color.Red;
                    string where_cmd = "Address='" + modbus1.send_machine_num.ToString() + "' and Com='串口1'";
                    DataTable dt = MainView.builder.Select_Table("Device_Info", where_cmd);
                    while (dt==null || dt.Rows.Count==0)
                    {
                        modbus1.send_machine_num = modbus1.send_machine_num + 1; //换下一号
                        if (modbus1.send_machine_num > 70)
                        {
                            modbus1.send_machine_num = 1;
                            return;
                        }
                        where_cmd = "Address='" + modbus1.send_machine_num.ToString() + "' and Com='串口1'";
                        dt = MainView.builder.Select_Table("Device_Info", where_cmd);
                    }

                    string cmd = MainView.inifile.IniReadValue("CMD", "cmd" + modbus1.cmd_num);
                    cmd = modbus1.send_machine_num.ToString("X").PadLeft(2, '0') + cmd;
                    modbus1.send_address_high = gethighaddress(cmd);
                    modbus1.send_address_low = getlowaddress(cmd);
                    modbus1.send_gongnengma = getgongnengma(cmd);
                    if (modbus1.xunjian_is == true)
                    {
                        //modbus1.sp.DiscardInBuffer();
                        modbus1.send_data(cmd);
                        modbus1.time_out = 0;
                        modbus1.send_is = true;
                    }
                }
                if (modbus1.send_is == true && modbus1.receive_is == false)
                {
                    modbus1.time_out = modbus1.time_out + 1;
                    if (modbus1.time_out > 50)
                    {
                        //超时了
                        modbus1.send_is = false;

                        modbus1.send_machine_num = modbus1.send_machine_num + 1;
                        modbus1.cmd_num = 1;

                    }
                }
                if (modbus1.send_is == true && modbus1.receive_is == true)
                {
                    modbus1.cmd_num = modbus1.cmd_num + 1;
                    modbus1.time_out = 0;
                    modbus1.send_is = false;
                    modbus1.receive_is = false;
                }
            }
        }
        private int gethighaddress(string cmd)
        {
            // 从命令里面获得高位地址
            int highaddress = 0;
            try
            {
                string address_string = cmd.Substring(4, 4);
                int address_int = Convert.ToInt32(address_string, 16);
                highaddress = address_int / 256;
            }
            catch
            {
            }
            return highaddress;
        }

        private int getlowaddress(string cmd)
        {
            // 从命令里面获得低位地址
            int lowaddress = 0;
            try
            {
                string address_string = cmd.Substring(4, 4);
                int address_int = Convert.ToInt32(address_string, 16);
                lowaddress = address_int % 256;
            }
            catch
            {
            }
            return lowaddress;
        }

        private int getgongnengma(string cmd)
        {
            // 从命令里面获得功能码
            int gongnengma = 0;
            try
            {
                gongnengma = int.Parse(cmd.Substring(2, 2));
            }
            catch
            {
            }
            return gongnengma;
        }

        private void timer_send2_Tick(object sender, EventArgs e)
        {
            if (modbus2.sp.IsOpen == true)
            {
                if (modbus2.cmd_num > 11)
                {
                    modbus2.cmd_num = 1;
                    modbus2.send_machine_num = modbus2.send_machine_num + 1;
                }
                if (modbus2.send_machine_num > 70) modbus2.send_machine_num = 1;
                if (modbus2.send_is == false && modbus2.receive_is == false)
                {
                    //串口1没有数据发送 发送数据
                    //com1_biaozhi.BackColor = System.Drawing.Color.Red;
                    string where_cmd = "Address='" + modbus2.send_machine_num.ToString() + "' and Com='串口2'";
                    DataTable dt = MainView.builder.Select_Table("Device_Info", where_cmd);
                    while (dt == null || dt.Rows.Count == 0)
                    {
                        modbus2.send_machine_num = modbus2.send_machine_num + 1; //换下一号
                        if (modbus2.send_machine_num > 70)
                        {
                            modbus2.send_machine_num = 1;
                            return;
                        }
                        where_cmd = "Address='" + modbus2.send_machine_num.ToString() + "' and Com='串口2'";
                        dt = MainView.builder.Select_Table("Device_Info", where_cmd);
                    }

                    string cmd = MainView.inifile.IniReadValue("CMD", "cmd" + modbus2.cmd_num);
                    cmd = modbus2.send_machine_num.ToString("X").PadLeft(2, '0') + cmd;
                    modbus2.send_address_high = gethighaddress(cmd);
                    modbus2.send_address_low = getlowaddress(cmd);
                    modbus2.send_gongnengma = getgongnengma(cmd);
                    if (modbus2.xunjian_is == true)
                    {
                        //modbus1.sp.DiscardInBuffer();
                        modbus2.send_data(cmd);
                        modbus2.time_out = 0;
                        modbus2.send_is = true;
                    }
                }
                if (modbus2.send_is == true && modbus2.receive_is == false)
                {
                    modbus2.time_out = modbus2.time_out + 1;
                    if (modbus2.time_out > 50)
                    {
                        //超时了
                        modbus2.send_is = false;

                        modbus2.send_machine_num = modbus2.send_machine_num + 1;
                        modbus2.cmd_num = 1;

                    }
                }
                if (modbus2.send_is == true && modbus2.receive_is == true)
                {
                    modbus2.cmd_num = modbus2.cmd_num + 1;
                    modbus2.time_out = 0;
                    modbus2.send_is = false;
                    modbus2.receive_is = false;
                }
            }
        }

        private void timer_send3_Tick(object sender, EventArgs e)
        {
            if (modbus3.sp.IsOpen == true)
            {
                if (modbus3.cmd_num > 11)
                {
                    modbus3.cmd_num = 1;
                    modbus3.send_machine_num = modbus3.send_machine_num + 1;
                }
                if (modbus3.send_machine_num > 70) modbus3.send_machine_num = 1;
                if (modbus3.send_is == false && modbus3.receive_is == false)
                {
                    //串口1没有数据发送 发送数据
                    //com1_biaozhi.BackColor = System.Drawing.Color.Red;
                    string where_cmd = "Address='" + modbus3.send_machine_num.ToString() + "' and Com='串口3'";
                    DataTable dt = MainView.builder.Select_Table("Device_Info", where_cmd);
                    while (dt == null || dt.Rows.Count == 0)
                    {
                        modbus3.send_machine_num = modbus3.send_machine_num + 1; //换下一号
                        if (modbus3.send_machine_num > 70)
                        {
                            modbus3.send_machine_num = 1;
                            return;
                        }
                        where_cmd = "Address='" + modbus3.send_machine_num.ToString() + "' and Com='串口3'";
                        dt = MainView.builder.Select_Table("Device_Info", where_cmd);
                    }

                    string cmd = MainView.inifile.IniReadValue("CMD", "cmd" + modbus3.cmd_num);
                    cmd = modbus3.send_machine_num.ToString("X").PadLeft(2, '0') + cmd;
                    modbus3.send_address_high = gethighaddress(cmd);
                    modbus3.send_address_low = getlowaddress(cmd);
                    modbus3.send_gongnengma = getgongnengma(cmd);
                    if (modbus3.xunjian_is == true)
                    {
                        //modbus1.sp.DiscardInBuffer();
                        modbus3.send_data(cmd);
                        modbus3.time_out = 0;
                        modbus3.send_is = true;
                    }
                }
                if (modbus3.send_is == true && modbus3.receive_is == false)
                {
                    modbus3.time_out = modbus3.time_out + 1;
                    if (modbus3.time_out > 50)
                    {
                        //超时了
                        modbus3.send_is = false;

                        modbus3.send_machine_num = modbus3.send_machine_num + 1;
                        modbus3.cmd_num = 1;

                    }
                }
                if (modbus3.send_is == true && modbus3.receive_is == true)
                {
                    modbus3.cmd_num = modbus3.cmd_num + 1;
                    modbus3.time_out = 0;
                    modbus3.send_is = false;
                    modbus3.receive_is = false;
                }
            }
        }

    }
}
