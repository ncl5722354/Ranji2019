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

namespace YinRan2020
{
    public partial class Xiangxi : Form
    {
        public string JiGang_Name = "";
        public Xiangxi()
        {
            InitializeComponent();
        }

        public void Set_Yiliu()
        {
            pictureBox1.Image = Properties.Resources.未标题_1;
        }

        public void Set_Qiliu()
        {
            pictureBox1.Image = Properties.Resources._1;
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
            }
            catch { }
        }

        public void Set_Title(string name)
        {
            label_title.Text = name;
            JiGang_Name = name;

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

        }

        private void ReFlash_Gongyi_Fanal(string gongyi_name)
        {
            try
            {
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
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
