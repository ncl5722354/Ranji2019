using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using ViewConfig;

namespace YinRan2020
{
    public partial class Xiangxi : Form
    {
        public string JiGang_Name = "";

        public static int old_duan = -1;

        public static int loadcount = 0;

        int machine_num = 0;

        public event EventHandler return_to_zongmao = null;
        public Xiangxi()
        {
            InitializeComponent();
            init_view();
        }

        public void init_view()
        {
            ViewCaoZuo.Object_Position(0.01, 0.1, 0.9, 0.35, chart1, this.Controls);

            ViewCaoZuo.Object_Position(0.27, 0.5, 0.5, 0.49, dataGridView_craft, this.Controls);

            ViewCaoZuo.Object_Position(0.8, 0.5, 0.2, 0.05, textBox_danhao, this.Controls);

            ViewCaoZuo.Object_Position(0.8, 0.56, 0.2, 0.03, button_read_gongyi, this.Controls);

            ViewCaoZuo.Object_Position(0.01, 0.5, 0.25, 0.49, panel1, this.Controls);

            //ViewCaoZuo.Object_Position(0.4, 0.6, 0.35, 0.35, panel2, this.Controls);

            ViewCaoZuo.Object_Position(0.8, 0.65, 0.23, 0.34, panel3, this.Controls);

            ViewCaoZuo.Object_Position(0.9, 0.01, 0.09, 0.05, button_return, this.Controls);
        }

        public void Set_Yiliu()
        {
            //pictureBox1.Image = Properties.Resources.未标题_1;
        }

        public void Set_Qiliu()
        {
            //pictureBox1.Image = Properties.Resources._1;
        }


        private void button_read_gongyi_Click(object sender, EventArgs e)
        {
           
            try
            {
                dataGridView_craft.RowCount = 1;
                for (int i = 0; i < dataGridView_craft.ColumnCount; i++)
                {
                    dataGridView_craft[i, 0].Value = "";
                }



                ReFlash_Gongyi_Fanal("工艺" + textBox_danhao.Text);
                ReFlush_Exe_Craft();


                // 执行工单号需要记录

                string[] update_cmd = new string[1];
                update_cmd[0] = "gongdanhao='"+textBox_danhao.Text+"'";

                string where_cmd = "machine_num='" + machine_num.ToString() + "'";

                MainView.builder.Updata("gongdan", where_cmd, update_cmd);
            }
            catch { }
        }


        private void ReFlush_Exe_Craft()
        {

            //DataTable dt = new DataTable();


            try
            {
                ArrayList all_table = new ArrayList();
                int rowcount = 0;
                dataGridView_exe.RowCount = 1;
                for (int j = 0; j < dataGridView_exe.ColumnCount; j++)
                {
                    dataGridView_exe[j, 0].Value = "";
                }
                for (int i = 0; i < dataGridView_craft.Rows.Count; i++)
                {
                    DataGridViewRow dr = dataGridView_craft.Rows[i];
                    string craft_duan_name = dr.Cells[1].Value.ToString();


                    // 改变_dt_info再根据xiangxi改变
                    DataTable dt_info = MainView.builder.Select_Table(craft_duan_name + "info");

                    DataTable dt_xiangxi = MainView.builder.Select_Table(craft_duan_name + "xiangxi");


                    foreach (DataRow mydr in dt_info.Rows)
                    {
                        if (mydr[1].ToString() == "单个")
                        {
                            int address = int.Parse(mydr[2].ToString());
                            int row = int.Parse(mydr[3].ToString());
                            int col = int.Parse(mydr[4].ToString());
                            dt_xiangxi.Rows[row - 1][col] = dr.Cells[(address - 1) * 2 + 3].Value.ToString();
                        }
                        if (mydr[1].ToString() == "整列")
                        {
                            int address = int.Parse(mydr[2].ToString());
                            int row = int.Parse(mydr[3].ToString());
                            int col = int.Parse(mydr[4].ToString());
                            for (int z = 0; z < dt_xiangxi.Rows.Count; z++)
                            {
                                dt_xiangxi.Rows[z][col] = dr.Cells[(address - 1) * 2 + 3].Value.ToString();
                            }
                        }
                    }

                    all_table.Add(dt_xiangxi);
                }

                    foreach (DataTable dt1 in all_table)
                    {
                        rowcount = rowcount + dt1.Rows.Count;

                    }




                    dataGridView_exe.RowCount = rowcount;

                    int row_index = 0;
                    foreach (DataTable dt1 in all_table)
                    {
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            for (int z = 1; z < dt1.Columns.Count; z++)
                            {
                                dataGridView_exe[z - 1, row_index].Value = dr1[z].ToString();
                            }

                            row_index++;
                        }
                    }

                }
            
            catch { }
        }

        public void Set_Title(string name)
        {
            label_title.Text = name;
            JiGang_Name = name;


            string where_cmd = "ID='" + JiGang_Name + "'";
            DataTable dt = MainView.builder.Select_Table("Device_Info", where_cmd);
            machine_num = int.Parse(dt.Rows[0][5].ToString());

            myLabel_Red_Yellow_jinshui.Device_Name = name;
            myLabel_Red_Yellow_jinshui.init();

            myLabel_Red_Yellow1.Device_Name = name;
            myLabel_Red_Yellow1.init();

            myLabel_Red_Yellow1.Device_Name = name;
            myLabel_Red_Yellow1.init();

            myLabel_Red_Yellow10.Device_Name = name;
            myLabel_Red_Yellow10.init();

            myLabel_Red_Yellow11.Device_Name = name;
            myLabel_Red_Yellow11.init();

            myLabel_Red_Yellow12.Device_Name = name;
            myLabel_Red_Yellow12.init();

            myLabel_Red_Yellow13.Device_Name = name;
            myLabel_Red_Yellow13.init();

            myLabel_Red_Yellow14.Device_Name = name;
            myLabel_Red_Yellow14.init();

            myLabel_Red_Yellow15.Device_Name = name;
            myLabel_Red_Yellow15.init();

            myLabel_Red_Yellow16.Device_Name = name;
            myLabel_Red_Yellow16.init();

            myLabel_Red_Yellow17.Device_Name = name;
            myLabel_Red_Yellow17.init();

            myLabel_Red_Yellow18.Device_Name = name;
            myLabel_Red_Yellow18.init();

            myLabel_Red_Yellow19.Device_Name = name;
            myLabel_Red_Yellow19.init();

            myLabel_Red_Yellow2.Device_Name = name;
            myLabel_Red_Yellow2.init();

            myLabel_Red_Yellow20.Device_Name = name;
            myLabel_Red_Yellow20.init();

            myLabel_Red_Yellow3.Device_Name = name;
            myLabel_Red_Yellow3.init();

            myLabel_Red_Yellow4.Device_Name = name;
            myLabel_Red_Yellow4.init();

            myLabel_Red_Yellow5.Device_Name = name;
            myLabel_Red_Yellow5.init();

            myLabel_Red_Yellow6.Device_Name = name;
            myLabel_Red_Yellow6.init();

            myLabel_Red_Yellow7.Device_Name = name;
            myLabel_Red_Yellow7.init();

            myLabel_Red_Yellow8.Device_Name = name;
            myLabel_Red_Yellow8.init();

            myLabel_Red_Yellow9.Device_Name = name;
            myLabel_Red_Yellow9.init();

            red_Green_zhifan_Button_shouzidong.Device_Name = name;
            red_Green_zhifan_Button_shouzidong.init();

            red_Green_zhifan_Button1.Device_Name = name;
            red_Green_zhifan_Button1.init();

            red_Green_zhifan_Button2.Device_Name = name;
            red_Green_zhifan_Button2.init();

            red_Green_zhifan_Button3.Device_Name = name;
            red_Green_zhifan_Button3.init();

            red_Green_zhifan_Button4.Device_Name = name;
            red_Green_zhifan_Button4.init();

            myLabel_Red_Yellow_shengwen.Device_Name = name;
            myLabel_Red_Yellow_shengwen.init();

            myLabel_Red_Yellow_lengque.Device_Name = name;
            myLabel_Red_Yellow_lengque.init();

            myLabel_wendu.Device_Name = name;
            myLabel_wendu.init();

            myLabel_shuiwei.Device_Name = name;
            myLabel_shuiwei.init();

            myLabel_liaogangshuiwei.Device_Name = name;
            myLabel_liaogangshuiwei.init();

            myLabel_duantime.Device_Name = name;
            myLabel_duantime.init();

            myLabel_zongtime.Device_Name = name;
            myLabel_zongtime.init();

            red_Green_zhifan_Button_qingqiukaishi.Device_Name = name;
            red_Green_zhifan_Button_qingqiukaishi.init();

            red_Green_zhifan_Button_zanting.Device_Name = name;
            red_Green_zhifan_Button_zanting.init();

            string linshi_where_cmd="machine_num='"+machine_num.ToString()+"'";
            DataTable linshitable = MainView.builder.Select_Table("linshi_craft", linshi_where_cmd);
            try
            {
                textBox_danhao.Text=linshitable.Rows[0][1].ToString();
                ReFlash_Gongyi_Fanal("工艺"+textBox_danhao.Text);
                ReFlush_Exe_Craft();

            }
            catch { }
        }

        private void ReFlash_Gongyi_Fanal(string gongyi_name)
        {
            try
            {
                int duan_count = 0;
                dataGridView_craft.RowCount = 1;
                for (int i = 0; i < dataGridView_craft.ColumnCount; i++)
                {
                    dataGridView_craft[i, 0].Value = "";
                }

                DataTable dt = MainView.builder.Select_Table(gongyi_name);
                dataGridView_craft.RowCount = dt.Rows.Count;


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView_craft[0, i].Value = dt.Rows[i][0].ToString();
                    dataGridView_craft[1, i].Value = dt.Rows[i][1].ToString();
                    dataGridView_craft[3, i].Value = dt.Rows[i][2].ToString();
                    dataGridView_craft[5, i].Value = dt.Rows[i][3].ToString();
                    dataGridView_craft[7, i].Value = dt.Rows[i][4].ToString();
                    dataGridView_craft[9, i].Value = dt.Rows[i][5].ToString();
                    dataGridView_craft[11, i].Value = dt.Rows[i][6].ToString();
                    dataGridView_craft[13, i].Value = dt.Rows[i][7].ToString();
                    dataGridView_craft[15, i].Value = dt.Rows[i][8].ToString();
                    dataGridView_craft[17, i].Value = dt.Rows[i][9].ToString();
                    dataGridView_craft[19, i].Value = dt.Rows[i][10].ToString();
                    dataGridView_craft[21, i].Value = dt.Rows[i][11].ToString();
                    string where = "Gongyi_Name='" + dataGridView_craft[1, i].Value + "'";
                    DataTable gongyi_dt = MainView.builder.Select_Table("Craft_Name_Table", where);
                    DataRow dr = gongyi_dt.Rows[0];
                    dataGridView_craft[2, i].Value = dr[1].ToString();
                    dataGridView_craft[4, i].Value = dr[2].ToString();
                    dataGridView_craft[6, i].Value = dr[3].ToString();
                    dataGridView_craft[8, i].Value = dr[4].ToString();
                    dataGridView_craft[10, i].Value = dr[5].ToString();
                    dataGridView_craft[12, i].Value = dr[6].ToString();
                    dataGridView_craft[14, i].Value = dr[7].ToString();
                    dataGridView_craft[16, i].Value = dr[8].ToString();
                    dataGridView_craft[18, i].Value = dr[9].ToString();
                    dataGridView_craft[20, i].Value = dr[10].ToString();

                    DataTable sub_gongyi = MainView.builder.Select_Table(dataGridView_craft[1, i].Value + "xiangxi");
                    duan_count = duan_count + sub_gongyi.Rows.Count;
                    dataGridView_craft[23, i].Value = duan_count.ToString();
                }
            }
            catch { }

            try
            {
                string[] update_cmd = new string[1];
                update_cmd[0] = "craft_table='" + textBox_danhao.Text + "'";

                string where_cmd = "machine_num='"+machine_num.ToString()+"'";
                MainView.builder.Updata("linshi_craft", where_cmd, update_cmd);
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void red_Green_zhifan_Button_shouzidong_Load(object sender, EventArgs e)
        {

        }

        private void red_Green_zhifan_Button1_Load(object sender, EventArgs e)
        {

        }

        private void red_Green_zhifan_Button1_Click(object sender, EventArgs e)
        {
            //dataGridView_exe
            
        }

        private void red_Green_zhifan_Button1_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void red_Green_zhifan_Button1_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void red_Green_zhifan_Button1_Qidong(object sender, EventArgs e)
        {
            Red_Green_zhifan_Button.datacount = dataGridView_exe.Rows.Count;
            try
            {
                for (int i = 0; i < dataGridView_exe.Rows.Count; i++)
                {
                    Red_Green_zhifan_Button.down_data1[i] = int.Parse(dataGridView_exe[0, i].Value.ToString());
                    Red_Green_zhifan_Button.down_data2[i] = int.Parse(dataGridView_exe[1, i].Value.ToString());

                    string where_cmd = "Craft_Name='" + dataGridView_exe[2, i].Value.ToString() + "'";
                    DataTable dt = MainView.builder.Select_Table("Craft_Name_Code", where_cmd);
                    DataRow dr = dt.Rows[0];
                    Red_Green_zhifan_Button.down_data3[i] = int.Parse(dr[1].ToString());
                    Red_Green_zhifan_Button.down_data4[i] = int.Parse(dataGridView_exe[3, i].Value.ToString());
                    Red_Green_zhifan_Button.down_data5[i] = int.Parse(dataGridView_exe[4, i].Value.ToString());
                    Red_Green_zhifan_Button.down_data6[i] = int.Parse(dataGridView_exe[5, i].Value.ToString());
                }
            }
            catch { throw;}
        }

        private void Xiangxi_Resize(object sender, EventArgs e)
        {
            init_view();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Red_Green_zhifan_Button.step == 0)
                progressBar_down.Value = 0;
             if (Red_Green_zhifan_Button.step == 1)
                 progressBar_down.Value = 5;
             if (Red_Green_zhifan_Button.step == 11)
                 progressBar_down.Value = 10;
            if (Red_Green_zhifan_Button.step == 12)
                progressBar_down.Value = 15;
            if (Red_Green_zhifan_Button.step == 2)
                progressBar_down.Value = 20;
            if (Red_Green_zhifan_Button.step == 21)
                progressBar_down.Value = 25;
            if (Red_Green_zhifan_Button.step == 22)
                progressBar_down.Value = 30;
            if (Red_Green_zhifan_Button.step == 3)
                progressBar_down.Value = 35;
            if (Red_Green_zhifan_Button.step == 31)
                progressBar_down.Value = 40;
            if (Red_Green_zhifan_Button.step == 32)
                progressBar_down.Value = 45;
            if (Red_Green_zhifan_Button.step == 4)
                progressBar_down.Value = 50;
            if (Red_Green_zhifan_Button.step == 41)
                progressBar_down.Value = 55;
            if (Red_Green_zhifan_Button.step == 42)
                progressBar_down.Value = 60;
            if (Red_Green_zhifan_Button.step == 5)
                progressBar_down.Value = 65;
            if (Red_Green_zhifan_Button.step == 51)
                progressBar_down.Value = 70;
            if (Red_Green_zhifan_Button.step == 52)
                progressBar_down.Value = 75;
            if (Red_Green_zhifan_Button.step == 6)
                progressBar_down.Value = 80;
            if (Red_Green_zhifan_Button.step == 61)
                progressBar_down.Value = 85;
            if (Red_Green_zhifan_Button.step == 62)
                progressBar_down.Value = 90;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            show_chart();
        }

        public void selected_datagridview_cells(object sender)
        {
            try
            {
                DataGridView datagridview = (DataGridView)sender;
                int selected_index = datagridview.SelectedCells[0].RowIndex;

                for (int i = 0; i < datagridview.Rows.Count; i++)
                {
                    if (i == selected_index)
                    {
                        datagridview.Rows[i].Selected = true;
                    }
                    else
                    {
                        datagridview.Rows[i].Selected = false;
                    }
                }

            }
            catch { }
        }

        private void show_chart()
        {
            try
            {
                chart1.Series[0].Points.Clear();
                string where_cmd = "ID='" + JiGang_Name + "'";
                DataTable dt = MainView.builder.Select_Table("Device_Info", where_cmd);
                machine_num = int.Parse(dt.Rows[0][5].ToString());
                string where_cmd1 = "machine_num='" + machine_num.ToString() + "'";
                DataTable starttimedt = MainView.builder.Select_Table("start_time", where_cmd1);

                DateTime starttime = DateTime.Parse(starttimedt.Rows[0][1].ToString());
                DateTime startendtime = starttime.AddHours(5);

                chart1.ChartAreas[0].AxisX.Minimum = starttime.ToOADate();
                chart1.ChartAreas[0].AxisX.Maximum = startendtime.ToOADate();

                string where_cmd2="machine_num='"+machine_num.ToString()+"' and value_name='机缸温度' and value_time>='"+starttime.ToString("yyyy-MM-dd HH:mm:ss")+"' and value_time<'"+startendtime.ToString("yyyy-MM-dd HH:mm:ss")+"'";
                DataTable dt1 = MainView.builder.Select_Table("save_info", where_cmd2);

                foreach (DataRow row in dt1.Rows)
                {
                    DateTime nowtime = DateTime.Parse(row[3].ToString());
                    double value=double.Parse(row[4].ToString());
                    chart1.Series[0].Points.AddXY(nowtime.ToOADate(), value);
                }

                
            }
            catch { }


            // 显示操作
            try
            {
                chart1.Series[1].Points.Clear();
                string where_cmd = "ID='" + JiGang_Name + "'";
                DataTable dt = MainView.builder.Select_Table("Device_Info", where_cmd);
                machine_num = int.Parse(dt.Rows[0][5].ToString());
                string where_cmd1 = "machine_num='" + machine_num.ToString() + "'";
                DataTable starttimedt = MainView.builder.Select_Table("start_time", where_cmd1);

                DateTime starttime = DateTime.Parse(starttimedt.Rows[0][1].ToString());
                DateTime startendtime = starttime.AddHours(5);
                string where_cmd2 = "machine_num='" + machine_num.ToString() + "' and mytime>='" + starttime.ToString("yyyy-MM-dd HH:mm:ss") + "' and mytime<='" + startendtime.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                DataTable dt1 = MainView.builder.Select_Table("caozuo_save", where_cmd2);

                foreach(DataRow dr in dt1.Rows)
                {
                    try
                    {
                        DateTime nowtime = DateTime.Parse(dr[2].ToString());
                        chart1.Series[1].Points.AddXY(nowtime.ToOADate(), 160);
                        
                        chart1.Series[1].Points[chart1.Series[1].Points.Count - 1].Label = dr[4].ToString() + " " + dr[5].ToString();
                        //chart1.Series[1].Points[chart1.Series[1].Points.Count - 1].IsValueShownAsLabel = true;
                    }
                    catch { }
                }


            }
            catch { }


            // 跳段操作
            try
            {
                chart1.Series[2].Points.Clear();
                string where_cmd = "ID='" + JiGang_Name + "'";
                DataTable dt = MainView.builder.Select_Table("Device_Info", where_cmd);
                machine_num = int.Parse(dt.Rows[0][5].ToString());
                string where_cmd1 = "machine_num='" + machine_num.ToString() + "'";
                DataTable starttimedt = MainView.builder.Select_Table("start_time", where_cmd1);

                DateTime starttime = DateTime.Parse(starttimedt.Rows[0][1].ToString());
                DateTime startendtime = starttime.AddHours(5);
                string where_cmd2 = "machine_num='" + machine_num.ToString() + "' and mytime>='" + starttime.ToString("yyyy-MM-dd HH:mm:ss") + "' and mytime<='" + startendtime.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                DataTable dt1 = MainView.builder.Select_Table("tiaoduan_save", where_cmd2);

                foreach (DataRow dr in dt1.Rows)
                {
                    try
                    {
                        DateTime nowtime = DateTime.Parse(dr[2].ToString());
                        chart1.Series[2].Points.AddXY(nowtime.ToOADate(), 250);

                        chart1.Series[2].Points[chart1.Series[2].Points.Count - 1].Label = " 段号:" + dr[4].ToString();
                        //chart1.Series[1].Points[chart1.Series[1].Points.Count - 1].IsValueShownAsLabel = true;
                    }
                    catch { }
                }


            }
            catch { }
        }

        private void timer_duan_Tick(object sender, EventArgs e)
        {
            string where_cmd = "value_name='运行段号'";
            DataTable dt = MainView.builder.Select_Table("Value_Config", where_cmd);

            try
            {
                int duan_value = int.Parse(dt.Rows[0][2].ToString());
                int duan = Device_Data.chejian3_com1_DT[machine_num, duan_value];
                for (int j = 0; j < dataGridView_craft.ColumnCount; j++)
                {
                    dataGridView_craft.Rows[0].Cells[j].Style.BackColor = System.Drawing.Color.Gray;
                }
                if(duan!=old_duan)
                {
                    for(int i=0;i<dataGridView_craft.Rows.Count;i++)
                    {

                        // 工艺前
                        int duancount = int.Parse(dataGridView_craft[23, i].Value.ToString());




                        if(duancount<=duan)
                        {
                            for(int j=0;j<dataGridView_craft.ColumnCount;j++)
                            {

                                
                                dataGridView_craft.Rows[i+1].Cells[j].Style.BackColor = System.Drawing.Color.Gray;
                            }
                        }
                        else
                        {
                            for (int j = 0; j < dataGridView_craft.ColumnCount; j++)
                            {
                                dataGridView_craft.Rows[i+1].Cells[j].Style.BackColor = System.Drawing.Color.White;
                            }
                        }
                    }
                }
            }
            catch { }

        }

        private void button_tiaoduan_Click(object sender, EventArgs e)
        {
            //读取地址
            string where_cmd = "value_name='运行段号'";
            DataTable dt = MainView.builder.Select_Table("Value_Config", where_cmd);

            // 读取串口号
            string where_cmd1 = "ID='" + JiGang_Name + "'";
            DataTable dt_com = MainView.builder.Select_Table("Device_Info", where_cmd1);

            try
            {
                int tiaoduan_address = int.Parse(dt.Rows[0][2].ToString());
                string chuankou = dt_com.Rows[0][4].ToString();

               // DataGridViewSelectedRowCollection rows = dataGridView_craft.SelectedRows;
                int rowindex = dataGridView_craft.SelectedCells[0].RowIndex;
                port_moudbus modbus = null;
                if (chuankou == "串口1")
                {
                    modbus = Deivce_Info.modbus1;
                }
                if (chuankou == "串口2")
                {
                    modbus = Deivce_Info.modbus2;
                }
                if (chuankou == "串口3")
                {
                    modbus = Deivce_Info.modbus3;
                }
                if (chuankou == "串口4")
                {
                    modbus = Deivce_Info.modbus4;
                }
                if (chuankou == "串口5")
                {
                    modbus = Deivce_Info.modbus5;
                }
                if (chuankou == "串口6")
                {
                    modbus = Deivce_Info.modbus6;
                }


                if(rowindex==0)
                {
                    modbus.Send_Write_Cmd6(machine_num, tiaoduan_address.ToString("X").PadLeft(4, '0'), "0000");
                }
                else
                {
                    int duan = int.Parse(dataGridView_craft[23, rowindex - 1].Value.ToString());
                    modbus.Send_Write_Cmd6(machine_num, tiaoduan_address.ToString("X").PadLeft(4, '0'), duan.ToString("X").PadLeft(4,'0'));
                }

                
            }
            catch { }

        }

        private void button_return_Click(object sender, EventArgs e)
        {
            if(return_to_zongmao!=null)
            {
                return_to_zongmao(this, new EventArgs());
            }
        }

        private void dataGridView_craft_Click(object sender, EventArgs e)
        {
            selected_datagridview_cells(sender);
        }

        private void Xiangxi_Load(object sender, EventArgs e)
        {

        }
    }
}
