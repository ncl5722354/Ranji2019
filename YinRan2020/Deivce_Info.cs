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
using System.IO.Ports;

namespace YinRan2020
{
    public partial class Deivce_Info : Form
    {
        private string chejian_name;
        SerialPort sp_test = new SerialPort();                               // 串口检测单位

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

            // 表格背景
            ViewCaoZuo.Object_Position(0.12, 0.35, 0.85, 0.6, panel1, this.Controls);

            // 表格
            ViewCaoZuo.Object_Position(0.01, 0.01, 0.98, 0.98, myDataGridView1, panel1.Controls);



            Create_Device_Database();   // 创建串口通讯表

            // 波特率下拉菜单
            comboBox_botelv.Items.Clear();
            comboBox_botelv.Items.Add("2400kps");
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
            AddCraft view = new AddCraft();
            AddCraft.Chejian_Name = chejian_name;
            view.ShowDialog();
            Read_Device_Info_Form_DataBase(); // 重新读取表格
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
            }
            catch { panel_com_info.Visible = false; }
        }
        private void Read_Device_Info_Form_DataBase()
        {
            // 从数据库里面读取设备数据
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
            }catch{}
            try{


                // 读取设备信息
                string device_where_cmd = "workshop='" + chejian_name + "' and Com='" + treeView1.SelectedNode.Text.ToString() + "'";
                DataTable device_dt = MainView.builder.Select_Table("Device_Info", device_where_cmd);
                myDataGridView1.Read_Table(device_dt);
                string[] header_array = new string[7];
                header_array[0] = "设备";
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

            Read_Device_Info_Form_DataBase();


        }

           
    }
}
