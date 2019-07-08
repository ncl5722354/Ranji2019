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
    public partial class shengchanpaishan : Form
    {
        int pre_selected_index = 0;
        public shengchanpaishan()
        {
            
            InitializeComponent();
            try
            {
                comboBox_gongyi.Items.Clear();
                DataTable dt = MainView.builder.Select_Table("Shengchanpaichan");
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox_gongyi.Items.Add(dr[0].ToString());
                }
            }
            catch { }

        }

        public void Set_Title(string title)
        {
            label_title.Text = title;
            init_view();
        }

        public void init_view()
        {
            ViewCaoZuo.Object_Position(0.42, 0.01, 0.1, 0.05, label_title, this.Controls);

            // 初始化工艺号
            for(int i=1;i<=400;i++)
            {
                comboBox_gongyihao.Items.Add(i.ToString());

            }
           

            ViewCaoZuo.Object_Position(0.01, 0.15, 0.5, 0.15, panel1, this.Controls);
            ViewCaoZuo.Object_Position(0.01, 0.35, 0.5, 0.64, panel2, this.Controls);
            ViewCaoZuo.Object_Position(0.51, 0.15, 0.48, 0.35, panel_datagridview, this.Controls);
            ViewCaoZuo.Object_Position(0, 0.1, 1, 0.9, dataGridView_craft, panel2.Controls);
            ViewCaoZuo.Object_Position(0, 0.1, 1, 0.9, dataGridView1, panel_datagridview.Controls);
            ViewCaoZuo.Object_Position(0.51, 0.55, 0.48, 0.44, panel_craft_info, this.Controls);

            //// panel_gongyinfo里的信息
            //ViewCaoZuo.Object_Position(0, 0, 1, 0.1, label_gongyititle, panel_gongyiinfo.Controls);
            //ViewCaoZuo.Object_Position(0, 0.1, 0.3, 0.08, label_canshu1, panel_gongyiinfo.Controls);
            //ViewCaoZuo.Object_Position(0, 0.1 + 0.08, 0.3, 0.08, label_canshu2, panel_gongyiinfo.Controls);
            //ViewCaoZuo.Object_Position(0, 0.1 + 0.08 * 2, 0.3, 0.08, label_canshu3, panel_gongyiinfo.Controls);
            //ViewCaoZuo.Object_Position(0, 0.1 + 0.08 * 3, 0.3, 0.08, label_canshu4, panel_gongyiinfo.Controls);
            //ViewCaoZuo.Object_Position(0, 0.1 + 0.08 * 4, 0.3, 0.08, label_canshu5, panel_gongyiinfo.Controls);
            //ViewCaoZuo.Object_Position(0, 0.1 + 0.08 * 5, 0.3, 0.08, label_canshu6, panel_gongyiinfo.Controls);
            //ViewCaoZuo.Object_Position(0, 0.1 + 0.08 * 6, 0.3, 0.08, label_canshu7, panel_gongyiinfo.Controls);
            //ViewCaoZuo.Object_Position(0, 0.1 + 0.08 * 7, 0.3, 0.08, label_canshu8, panel_gongyiinfo.Controls);
            //ViewCaoZuo.Object_Position(0, 0.1 + 0.08 * 8, 0.3, 0.08, label_canshu9, panel_gongyiinfo.Controls);
            //ViewCaoZuo.Object_Position(0, 0.1 + 0.08 * 9, 0.3, 0.08, label_canshu10, panel_gongyiinfo.Controls);
            // 
            ReFlush_GongDan_List();
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

        private void button_readgongyi_Click(object sender, EventArgs e)
        {
            string gongyihao = comboBox_gongyihao.Text.PadLeft(3, '0');
            ReFlash_Gongyi_Fanal_qiliu(gongyihao);
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

                DataTable dt = MainView.builder.Select_Table("工艺"+gongyi_name);
                try
                {
                    if (dt == null)
                        dt = MainView.builder.Select_Table(gongyi_name);
                    if (dt.Rows.Count == 0)
                        dt = MainView.builder.Select_Table(gongyi_name);
                }
                catch { }
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

        private void ReFlash_Gongyi_Fanal_qiliu(string gongyi_name)
        {
            try
            {
                dataGridView_craft.RowCount = 1;
                for (int i = 0; i < dataGridView_craft.ColumnCount; i++)
                {
                    dataGridView_craft[i, 0].Value = "";
                }

                DataTable dt = MainView.builder.Select_Table("工艺" + gongyi_name+"气流");
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
            try
            {
                if (comboBox_gongyihao.Text != "")
                {
                    string id = textBox_danhao.Text;
                    string[] insert_cmd = new string[3];
                    insert_cmd[0] = textBox_danhao.Text;
                    insert_cmd[1] = "待生产";
                    insert_cmd[2] = comboBox_gongyihao.Text;
                    bool result = MainView.builder.Insert("Shengchanpaichan", insert_cmd);
                    if (result == true)
                    {
                        // 产生一个表保存起来
                        CreateSqlValueType[] create_cmd = new CreateSqlValueType[13];
                        create_cmd[0] = new CreateSqlValueType("int", "ID", true);
                        create_cmd[1] = new CreateSqlValueType("nvarchar(50)", "craft_name");
                        create_cmd[2] = new CreateSqlValueType("nvarchar(50)", "value1");
                        create_cmd[3] = new CreateSqlValueType("nvarchar(50)", "value2");
                        create_cmd[4] = new CreateSqlValueType("nvarchar(50)", "value3");
                        create_cmd[5] = new CreateSqlValueType("nvarchar(50)", "value4");
                        create_cmd[6] = new CreateSqlValueType("nvarchar(50)", "value5");
                        create_cmd[7] = new CreateSqlValueType("nvarchar(50)", "value6");
                        create_cmd[8] = new CreateSqlValueType("nvarchar(50)", "value7");
                        create_cmd[9] = new CreateSqlValueType("nvarchar(50)", "value8");
                        create_cmd[10] = new CreateSqlValueType("nvarchar(50)", "value9");
                        create_cmd[11] = new CreateSqlValueType("nvarchar(50)", "value10");
                        create_cmd[12] = new CreateSqlValueType("nvarchar(50)", "beizhu");

                        MainView.builder.Create_Table("工艺"+textBox_danhao.Text, create_cmd);

                        for(int i=0;i<dataGridView_craft.RowCount;i++)
                        {
                            string[] insert_cmd1 = new string[13];
                            insert_cmd1[0] = dataGridView_craft[0, i].Value.ToString();
                            insert_cmd1[1] = dataGridView_craft[1, i].Value.ToString();
                            insert_cmd1[2] = dataGridView_craft[3, i].Value.ToString();
                            insert_cmd1[3] = dataGridView_craft[5, i].Value.ToString();
                            insert_cmd1[4] = dataGridView_craft[7, i].Value.ToString();
                            insert_cmd1[5] = dataGridView_craft[9, i].Value.ToString();
                            insert_cmd1[6] = dataGridView_craft[11, i].Value.ToString();
                            insert_cmd1[7] = dataGridView_craft[13, i].Value.ToString();
                            insert_cmd1[8] = dataGridView_craft[15, i].Value.ToString();
                            insert_cmd1[9] = dataGridView_craft[17, i].Value.ToString();
                            insert_cmd1[10] = dataGridView_craft[19, i].Value.ToString();
                            insert_cmd1[11] = dataGridView_craft[21, i].Value.ToString();
                            insert_cmd1[12] = "";
                            MainView.builder.Insert("工艺" + textBox_danhao.Text, insert_cmd1);
                        }

                    }
                    else
                    {
                        // 进行更新
                        MainView.builder.Delete("工艺" + textBox_danhao.Text);
                        for (int i = 0; i < dataGridView_craft.RowCount; i++)
                        {
                            string[] insert_cmd1 = new string[13];
                            insert_cmd1[0] = dataGridView_craft[0, i].Value.ToString();
                            insert_cmd1[1] = dataGridView_craft[1, i].Value.ToString();
                            insert_cmd1[2] = dataGridView_craft[3, i].Value.ToString();
                            insert_cmd1[3] = dataGridView_craft[5, i].Value.ToString();
                            insert_cmd1[4] = dataGridView_craft[7, i].Value.ToString();
                            insert_cmd1[5] = dataGridView_craft[9, i].Value.ToString();
                            insert_cmd1[6] = dataGridView_craft[11, i].Value.ToString();
                            insert_cmd1[7] = dataGridView_craft[13, i].Value.ToString();
                            insert_cmd1[8] = dataGridView_craft[15, i].Value.ToString();
                            insert_cmd1[9] = dataGridView_craft[17, i].Value.ToString();
                            insert_cmd1[10] = dataGridView_craft[19, i].Value.ToString();
                            insert_cmd1[11] = dataGridView_craft[21, i].Value.ToString();
                            insert_cmd1[12] = "";
                            MainView.builder.Insert("工艺" + textBox_danhao.Text, insert_cmd1);
                        }
                    }
                }
                
            }
            catch { }
            comboBox_gongyi.Items.Clear();
            try
            {

                DataTable dt = MainView.builder.Select_Table("Shengchanpaichan");
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox_gongyi.Items.Add(dr[0].ToString());
                }
            }
            catch { }
            ReFlush_GongDan_List();
        }

        private void ReFlush_GongDan_List()
        {
            DataTable dt = MainView.builder.Select_Table("Shengchanpaichan");
            dataGridView1.RowCount = 1;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1[i, 0].Value = "";
            }
            try
            {
                dataGridView1.RowCount = dt.Rows.Count;
                for(int i=0;i<dataGridView1.RowCount;i++)
                {
                    for(int j=0;j<dataGridView1.ColumnCount;j++)
                    {
                        dataGridView1[j, i].Value = dt.Rows[i][j].ToString();
                    }
                }
            }
            catch { }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
               
                ReFlash_Gongyi_Fanal(comboBox_gongyi.Text);
                textBox_danhao.Text = comboBox_gongyi.Text;
            }
            catch { }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string selected_gongyi = "工艺" + textBox_danhao.Text;
                Add_Craft_Final view = new Add_Craft_Final();
                view.set_title(selected_gongyi);
                DialogResult result = view.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // 添加一条工艺
                    DataTable dt = MainView.builder.Select_Table(selected_gongyi);
                    if(dt==null)
                    {
                        MessageBox.Show("先添加到工艺再修改");
                        return;
                    }
                    int rows = dt.Rows.Count;
                    string[] insert_cmd = new string[13];
                    insert_cmd[0] = (rows + 1).ToString();
                    insert_cmd[1] = Add_Craft_Final.gongyi;
                    insert_cmd[2] = Add_Craft_Final.value1;
                    insert_cmd[3] = Add_Craft_Final.value2;
                    insert_cmd[4] = Add_Craft_Final.value3;
                    insert_cmd[5] = Add_Craft_Final.value4;
                    insert_cmd[6] = Add_Craft_Final.value5;
                    insert_cmd[7] = Add_Craft_Final.value6;
                    insert_cmd[8] = Add_Craft_Final.value7;
                    insert_cmd[9] = Add_Craft_Final.value8;
                    insert_cmd[10] = Add_Craft_Final.value9;
                    insert_cmd[11] = Add_Craft_Final.value10;
                    insert_cmd[12] = "";
                    bool resutl= MainView.builder.Insert(selected_gongyi, insert_cmd);
                    if(resutl==true)
                    {
                        ReFlash_Gongyi_Fanal(selected_gongyi);
                    }
                }
                //ReFlash_Gongyi_Fanal(selected_gongyi);
            }
            catch { }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            try
            {
                string craft_name = "工艺"+textBox_danhao.Text;

                DataGridViewRow dr = dataGridView_craft.SelectedRows[0];

                int selected_index_int = int.Parse(dr.Cells[0].Value.ToString());
                DeleteDevice view = new DeleteDevice();
                view.Set_Title("删除工艺" + dr.Cells[0].Value.ToString());
                DialogResult reslut = view.ShowDialog();
                if (reslut == DialogResult.OK)
                {
                    string where_cmd = "ID='" + dr.Cells[0].Value.ToString() + "'";
                    bool is_delete = MainView.builder.Delete(craft_name, where_cmd);

                    //

                    if (is_delete == true)
                    {
                        // 将所有后面的ID号减1
                        DataTable dt = MainView.builder.Select_Table(craft_name);
                        foreach (DataRow mydr in dt.Rows)
                        {
                            if (int.Parse(mydr[0].ToString()) > selected_index_int)
                            {
                                string[] update_cmd = new string[1];
                                int myindex = int.Parse(mydr[0].ToString());
                                update_cmd[0] = "ID='" + (myindex - 1).ToString() + "'";

                                string update_where_cmd = "ID='" + myindex.ToString() + "'";
                                MainView.builder.Updata(craft_name, update_where_cmd, update_cmd);

                            }
                        }


                    }
                }
                ReFlash_Gongyi_Fanal(craft_name);
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView_craft.RowCount = 1;
                for (int i = 0; i < dataGridView_craft.ColumnCount; i++)
                {
                    dataGridView_craft[i, 0].Value = "";
                }
                
                ReFlash_Gongyi_Fanal(textBox_danhao.Text);
                
            }
            catch { }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                // 选择的工艺名称
                string craft_name = "工艺" + textBox_danhao.Text;

                // 选择的行
                 DataGridViewRow dr = dataGridView_craft.SelectedRows[0];


                string key = dr.Cells[1].Value.ToString();
                string where_cmd = "Gongyi_Name='" + key + "'";
                DataTable dt = MainView.builder.Select_Table("Craft_Name_Table", where_cmd);
                if (dt == null)
                {
                    Update_Craft_Final.canshu1_shuoming = "参数1说明";
                    Update_Craft_Final.canshu2_shuoming = "参数2说明";
                    Update_Craft_Final.canshu3_shuoming = "参数3说明";
                    Update_Craft_Final.canshu4_shuoming = "参数4说明";
                    Update_Craft_Final.canshu5_shuoming = "参数5说明";
                    Update_Craft_Final.canshu6_shuoming = "参数6说明";
                    Update_Craft_Final.canshu7_shuoming = "参数7说明";
                    Update_Craft_Final.canshu8_shuoming = "参数8说明";
                    Update_Craft_Final.canshu9_shuoming = "参数9说明";
                    Update_Craft_Final.canshu10_shuoming = "参数10说明";
                }
                else
                {
                    DataRow dr1 = dt.Rows[0];
                    
                    
                    Update_Craft_Final.Craft_Name = dr.Cells[1].Value.ToString();
                    Update_Craft_Final.canshu1 = dr.Cells[3].Value.ToString();
                    Update_Craft_Final.canshu2 = dr.Cells[5].Value.ToString();
                    Update_Craft_Final.canshu3 = dr.Cells[7].Value.ToString();
                    Update_Craft_Final.canshu4 = dr.Cells[9].Value.ToString();
                    Update_Craft_Final.canshu5 = dr.Cells[11].Value.ToString();
                    Update_Craft_Final.canshu6 = dr.Cells[13].Value.ToString();
                    Update_Craft_Final.canshu7 = dr.Cells[15].Value.ToString();
                    Update_Craft_Final.canshu8 = dr.Cells[17].Value.ToString();
                    Update_Craft_Final.canshu9 = dr.Cells[19].Value.ToString();
                    Update_Craft_Final.canshu10 = dr.Cells[21].Value.ToString();

                    Update_Craft_Final.canshu1_shuoming = dr.Cells[2].Value.ToString();
                    Update_Craft_Final.canshu2_shuoming = dr.Cells[4].Value.ToString();
                    Update_Craft_Final.canshu3_shuoming = dr.Cells[6].Value.ToString();
                    Update_Craft_Final.canshu4_shuoming = dr.Cells[8].Value.ToString();
                    Update_Craft_Final.canshu5_shuoming = dr.Cells[10].Value.ToString();
                    Update_Craft_Final.canshu6_shuoming = dr.Cells[12].Value.ToString();
                    Update_Craft_Final.canshu7_shuoming = dr.Cells[14].Value.ToString();
                    Update_Craft_Final.canshu8_shuoming = dr.Cells[16].Value.ToString();
                    Update_Craft_Final.canshu9_shuoming = dr.Cells[18].Value.ToString();
                    Update_Craft_Final.canshu10_shuoming = dr.Cells[20].Value.ToString();


                    Update_Craft_Final view = new Update_Craft_Final();
                    DialogResult result = view.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string where_cmd1 = "ID='" + dr.Cells[0].Value.ToString() + "'";
                        string[] update_cmd = new string[11];
                        update_cmd[0] = "craft_name='" + Update_Craft_Final.Craft_Name + "'";
                        update_cmd[1] = "value1='" + Update_Craft_Final.canshu1 + "'";
                        update_cmd[2] = "value2='" + Update_Craft_Final.canshu2 + "'";
                        update_cmd[3] = "value3='" + Update_Craft_Final.canshu3 + "'";
                        update_cmd[4] = "value4='" + Update_Craft_Final.canshu4 + "'";
                        update_cmd[5] = "value5='" + Update_Craft_Final.canshu5 + "'";
                        update_cmd[6] = "value6='" + Update_Craft_Final.canshu6 + "'";
                        update_cmd[7] = "value7='" + Update_Craft_Final.canshu7 + "'";
                        update_cmd[8] = "value8='" + Update_Craft_Final.canshu8 + "'";
                        update_cmd[9] = "value9='" + Update_Craft_Final.canshu9 + "'";
                        update_cmd[10] = "value10='" + Update_Craft_Final.canshu10 + "'";

                        MainView.builder.Updata(craft_name, where_cmd1, update_cmd);

                        ReFlash_Gongyi_Fanal(craft_name);
                    }
                }
            }
            catch { }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                // 选择的工艺名称
                string craft_name = "工艺" + textBox_danhao.Text;

                // 选择的行
                DataGridViewRow dr = dataGridView_craft.SelectedRows[0];

                string id = dr.Cells[0].Value.ToString();
                //string key = dr.Cells[1].Value.ToString();
                //string where_cmd = "Gongyi_Name='" + key + "'";
                //DataTable dt = MainView.builder.Select_Table("Craft_Name_Table", where_cmd);

                Add_Craft_Final view = new Add_Craft_Final();

                int selected_index_int = int.Parse(dr.Cells[0].Value.ToString());


                DialogResult reslut = view.ShowDialog();
                if (reslut == DialogResult.OK)
                {

                    // 将所有后面的ID号加1
                    try
                    {
                        DataTable dt = MainView.builder.Select_Table(craft_name);
                        //foreach (DataRow mydr in dt.Rows)
                        //{
                        for (int i = dt.Rows.Count - 1; i >= 0; i--)
                        {
                            DataRow mydr = dt.Rows[i];
                            if (int.Parse(mydr[0].ToString()) >= selected_index_int + 1)
                            {
                                string[] update_cmd = new string[1];
                                int myindex = int.Parse(mydr[0].ToString());
                                update_cmd[0] = "ID='" + (myindex + 1).ToString() + "'";

                                string update_where_cmd = "ID='" + myindex.ToString() + "'";
                                MainView.builder.Updata(craft_name, update_where_cmd, update_cmd);

                            }
                        }
                        //}
                    }
                    catch { }



                    string where_cmd = "ID='" + dr.Cells[0].Value.ToString() + "'";
                   // bool is_delete = MainView.builder.Delete(craft_name, where_cmd);

                    //
                    //int rows = dt.Rows.Count;
                    string[] insert_cmd = new string[13];
                    insert_cmd[0] = (selected_index_int + 1).ToString();
                    insert_cmd[1] = Add_Craft_Final.gongyi;
                    insert_cmd[2] = Add_Craft_Final.value1;
                    insert_cmd[3] = Add_Craft_Final.value2;
                    insert_cmd[4] = Add_Craft_Final.value3;
                    insert_cmd[5] = Add_Craft_Final.value4;
                    insert_cmd[6] = Add_Craft_Final.value5;
                    insert_cmd[7] = Add_Craft_Final.value6;
                    insert_cmd[8] = Add_Craft_Final.value7;
                    insert_cmd[9] = Add_Craft_Final.value8;
                    insert_cmd[10] = Add_Craft_Final.value9;
                    insert_cmd[11] = Add_Craft_Final.value10;
                    insert_cmd[12] = "";

                    bool is_delete= MainView.builder.Insert(craft_name, insert_cmd);




                    
                        


                    
                    ReFlash_Gongyi_Fanal(craft_name);
                }

            }
            catch { }
        }

        private void ReFlush_Craft_Return(object sender, EventArgs e)
        {
            string selected_gongyi = textBox_danhao.Text;
            ReFlash_Gongyi_Fanal(selected_gongyi);
        }


        private void dataGridView_craft_Click(object sender, EventArgs e)
        {
            selected_datagridview_cells(sender);
            
            DataGridViewRow dr = dataGridView_craft.SelectedRows[0];
            pre_selected_index = dataGridView_craft.SelectedRows[0].Cells[0].RowIndex;
            panel_craft_info.Controls.Clear();
            if (dr.Cells[1].Value.ToString() == "升温")
            {
                Shengwen_subview.gongyi_name = "工艺" + textBox_danhao.Text;
                Shengwen_subview.ID = dr.Cells[0].Value.ToString();
                Shengwen_subview.start_wendu = dr.Cells[3].Value.ToString();
                Shengwen_subview.end_wendu = dr.Cells[5].Value.ToString();
                Shengwen_subview.shengwen_time = dr.Cells[7].Value.ToString();
                Shengwen_subview.zhubengpinlv = dr.Cells[9].Value.ToString();
                Shengwen_subview.tibupinlv = dr.Cells[11].Value.ToString();
                Shengwen_subview.fengjipinlv = dr.Cells[13].Value.ToString();
                Shengwen_subview view = new Shengwen_subview();
                ViewCaoZuo.Object_Position(0, 0, 1, 1, view, panel_craft_info.Controls);
                view.change += new EventHandler(ReFlush_Craft_Return);
            }
            if (dr.Cells[1].Value.ToString() == "降温")
            {

                Jiangwen_subview.gongyi_name = "工艺" + textBox_danhao.Text;
                Jiangwen_subview.ID = dr.Cells[0].Value.ToString();
                Jiangwen_subview.start_wendu = dr.Cells[3].Value.ToString();
                Jiangwen_subview.end_wendu = dr.Cells[5].Value.ToString();
                Jiangwen_subview.shengwen_time = dr.Cells[7].Value.ToString();
                Jiangwen_subview.zhubengpinlv = dr.Cells[9].Value.ToString();
                Jiangwen_subview.tibupinlv = dr.Cells[11].Value.ToString();
                Jiangwen_subview.fengjipinlv = dr.Cells[13].Value.ToString();
                Jiangwen_subview view = new Jiangwen_subview();
                ViewCaoZuo.Object_Position(0, 0, 1, 1, view, panel_craft_info.Controls);
                view.change += new EventHandler(ReFlush_Craft_Return);
            }
            if (dr.Cells[1].Value.ToString() == "保温")
            {
                baowen_view.ID = dr.Cells[0].Value.ToString();
                baowen_view.gongyi_name = "工艺" + textBox_danhao.Text;
                baowen_view.baowenwendu = dr.Cells[3].Value.ToString();
                baowen_view.baowenshijian = dr.Cells[5].Value.ToString();
                baowen_view.zhubengpinlv = dr.Cells[7].Value.ToString();
                baowen_view.tibupinlv = dr.Cells[9].Value.ToString();
                baowen_view.fengjipinlv = dr.Cells[11].Value.ToString();
                baowen_view view = new baowen_view();
                ViewCaoZuo.Object_Position(0, 0, 1, 1, view, panel_craft_info.Controls);
                view.change += new EventHandler(ReFlush_Craft_Return);
            }
            if (dr.Cells[1].Value.ToString() == "机缸进水一" || dr.Cells[1].Value.ToString() == "机缸进水二" || dr.Cells[1].Value.ToString() == "机缸进水三" || dr.Cells[1].Value.ToString() == "机缸进水四" ||
                dr.Cells[1].Value.ToString() == "停泵进水一" || dr.Cells[1].Value.ToString() == "停泵进水二" || dr.Cells[1].Value.ToString() == "停泵进水三" || dr.Cells[1].Value.ToString() == "停泵进水四")
            {

                JinShui_subview.ID = dr.Cells[0].Value.ToString();
                JinShui_subview.gongyi_name = "工艺" + textBox_danhao.Text;
                JinShui_subview.gongyi_duan_name = dr.Cells[1].Value.ToString();
                JinShui_subview.mubiaoshuiwei = dr.Cells[3].Value.ToString();

                JinShui_subview.zhubengpinlv = dr.Cells[5].Value.ToString();
                JinShui_subview.tibupinlv = dr.Cells[7].Value.ToString();
                JinShui_subview.fengjipinlv = dr.Cells[9].Value.ToString();
                JinShui_subview view = new JinShui_subview();
                ViewCaoZuo.Object_Position(0, 0, 1, 1, view, panel_craft_info.Controls);
                view.change += new EventHandler(ReFlush_Craft_Return);
            }

            if (dr.Cells[1].Value.ToString() == "机缸排水一" || dr.Cells[1].Value.ToString() == "机缸排水二" || dr.Cells[1].Value.ToString() == "机缸排水三" || dr.Cells[1].Value.ToString() == "机缸排水四" ||
                dr.Cells[1].Value.ToString() == "停泵排水一" || dr.Cells[1].Value.ToString() == "停泵排水二" || dr.Cells[1].Value.ToString() == "停泵排水三" || dr.Cells[1].Value.ToString() == "停泵排水四")
            {

                Paishui_subview.ID = dr.Cells[0].Value.ToString();
                Paishui_subview.gongyi_name = "工艺" + textBox_danhao.Text;
                Paishui_subview.gongyi_duan_name = dr.Cells[1].Value.ToString();
                Paishui_subview.mubiaoshuiwei = dr.Cells[3].Value.ToString();

                Paishui_subview.zhubengpinlv = dr.Cells[5].Value.ToString();
                Paishui_subview.tibupinlv = dr.Cells[7].Value.ToString();
                Paishui_subview.fengjipinlv = dr.Cells[9].Value.ToString();
                Paishui_subview view = new Paishui_subview();
                ViewCaoZuo.Object_Position(0, 0, 1, 1, view, panel_craft_info.Controls);
                view.change += new EventHandler(ReFlush_Craft_Return);
            }
            try
            {
                if (dr.Cells[1].Value.ToString().Substring(2, 2) == "水洗")
                {

                    Shuixi_Subview.ID = dr.Cells[0].Value.ToString();
                    Shuixi_Subview.gongyi_name = "工艺" + textBox_danhao.Text;
                    Shuixi_Subview.gongyi_duan_name = dr.Cells[1].Value.ToString();
                    Shuixi_Subview.shangxian = dr.Cells[3].Value.ToString();
                    Shuixi_Subview.xiaxian = dr.Cells[5].Value.ToString();
                    Shuixi_Subview.dunshu_shijian = dr.Cells[7].Value.ToString();

                    Shuixi_Subview.zhubengpinlv = dr.Cells[9].Value.ToString();
                    Shuixi_Subview.tibupinlv = dr.Cells[11].Value.ToString();
                    Shuixi_Subview.fengjipinlv = dr.Cells[13].Value.ToString();
                    Shuixi_Subview view = new Shuixi_Subview();
                    ViewCaoZuo.Object_Position(0, 0, 1, 1, view, panel_craft_info.Controls);
                    view.change += new EventHandler(ReFlush_Craft_Return);
                }
            }
            catch { }
            try
            {
                string gongyi_name = dr.Cells[1].Value.ToString();
                if (gongyi_name == "中和助剂" || gongyi_name == "染色助剂" || gongyi_name == "分散染料" || gongyi_name == "液碱" ||
                                 gongyi_name == "前处理助剂" || gongyi_name == "元明粉" || gongyi_name == "纯碱" || gongyi_name == "保温粉" ||
                                 gongyi_name == "双氧水" || gongyi_name == "纤维酶" || gongyi_name == "阳离子染料" || gongyi_name == "混纺染料" ||
                                 gongyi_name == "硫化染料" || gongyi_name == "活性染料" || gongyi_name == "中性染料" || gongyi_name == "酸性染料" ||
                                 gongyi_name == "还原染料" || gongyi_name == "冰醋酸" || gongyi_name == "硫化碱" || gongyi_name == "去油灵" ||
                                 gongyi_name == "皂洗剂" || gongyi_name == "消泡剂" || gongyi_name == "固色剂" || gongyi_name == "高温匀染剂" ||
                                 gongyi_name == "棉用匀染剂" || gongyi_name == "阳离子匀染剂" || gongyi_name == "阳离子匀染剂" || gongyi_name == "酸性匀染剂" ||
                                 gongyi_name == "酸性匀染剂" || gongyi_name == "膨化剂" || gongyi_name == "柔软剂" || gongyi_name == "增白剂" ||
                                 gongyi_name == "修补剂" || gongyi_name == "防水剂" || gongyi_name == "分散剂" || gongyi_name == "防皱剂" ||
                                 gongyi_name == "精炼剂" || gongyi_name == "酵素酶" || gongyi_name == "除氧酶")      // 回流搅拌助剂类
                {

                    jinliao_subview.ID = dr.Cells[0].Value.ToString();
                    jinliao_subview.gongyi_name = "工艺" + textBox_danhao.Text;
                    jinliao_subview.gongyi_duan_name = dr.Cells[1].Value.ToString();
                    jinliao_subview.huiliuyewei = dr.Cells[3].Value.ToString();
                    jinliao_subview.jiaobanshijian = dr.Cells[5].Value.ToString();
                    jinliao_subview.jinliaoshijian = dr.Cells[7].Value.ToString();

                    jinliao_subview.zhubengpinlv = dr.Cells[9].Value.ToString();
                    jinliao_subview.tibupinlv = dr.Cells[11].Value.ToString();
                    jinliao_subview.fengjipinlv = dr.Cells[13].Value.ToString();
                    jinliao_subview view = new jinliao_subview();
                    ViewCaoZuo.Object_Position(0, 0, 1, 1, view, panel_craft_info.Controls);
                    view.change += new EventHandler(ReFlush_Craft_Return);
                }
            }
            catch { }

            try
            {
                string gongyi_name = dr.Cells[1].Value.ToString();
                if (gongyi_name == "结束" || gongyi_name == "取样" || gongyi_name == "出布" || gongyi_name == "自动暂停" || gongyi_name == "停泵取样" || gongyi_name == "进布")           // 机缸过程类
                {

                    Guocheng.ID = dr.Cells[0].Value.ToString();
                    Guocheng.gongyi_name = "工艺" + textBox_danhao.Text;
                    Guocheng.gongyi_duan_name = dr.Cells[1].Value.ToString();


                    Guocheng.zhubengpinlv = dr.Cells[3].Value.ToString();
                    Guocheng.tibupinlv = dr.Cells[5].Value.ToString();
                    Guocheng.fengjipinlv = dr.Cells[7].Value.ToString();
                    Guocheng view = new Guocheng();
                    ViewCaoZuo.Object_Position(0, 0, 1, 1, view, panel_craft_info.Controls);
                    view.change += new EventHandler(ReFlush_Craft_Return);
                }
            }
            catch { }

            try
            {
                string gongyi_name = dr.Cells[1].Value.ToString();
                if (gongyi_name == "染机运行一" || gongyi_name == "染机运行二" || gongyi_name == "染机运行三")           // 机缸运行类
                {

                    jigangyunxing.ID = dr.Cells[0].Value.ToString();
                    jigangyunxing.gongyi_name = "工艺" + textBox_danhao.Text;
                    jigangyunxing.gongyi_duan_name = dr.Cells[1].Value.ToString();

                    jigangyunxing.yunxingshijian = dr.Cells[3].Value.ToString();
                    jigangyunxing.zhubengpinlv = dr.Cells[5].Value.ToString();
                    jigangyunxing.tibupinlv = dr.Cells[7].Value.ToString();
                    jigangyunxing.fengjipinlv = dr.Cells[9].Value.ToString();
                    jigangyunxing view = new jigangyunxing();
                    ViewCaoZuo.Object_Position(0, 0, 1, 1, view, panel_craft_info.Controls);
                    view.change += new EventHandler(ReFlush_Craft_Return);
                }
            }
            catch { }
        }

        private void dataGridView_craft_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                // 选择的工艺名称
                string craft_name = "工艺" + textBox_danhao.Text;

                // 选择的行
                DataGridViewRow dr = dataGridView_craft.SelectedRows[0];


                string key = dr.Cells[1].Value.ToString();
                string where_cmd = "Gongyi_Name='" + key + "'";
                DataTable dt = MainView.builder.Select_Table("Craft_Name_Table", where_cmd);
                if (dt == null)
                {
                    Update_Craft_Final.canshu1_shuoming = "参数1说明";
                    Update_Craft_Final.canshu2_shuoming = "参数2说明";
                    Update_Craft_Final.canshu3_shuoming = "参数3说明";
                    Update_Craft_Final.canshu4_shuoming = "参数4说明";
                    Update_Craft_Final.canshu5_shuoming = "参数5说明";
                    Update_Craft_Final.canshu6_shuoming = "参数6说明";
                    Update_Craft_Final.canshu7_shuoming = "参数7说明";
                    Update_Craft_Final.canshu8_shuoming = "参数8说明";
                    Update_Craft_Final.canshu9_shuoming = "参数9说明";
                    Update_Craft_Final.canshu10_shuoming = "参数10说明";
                }
                else
                {
                    DataRow dr1 = dt.Rows[0];


                    Update_Craft_Final.Craft_Name = dr.Cells[1].Value.ToString();
                    Update_Craft_Final.canshu1 = dr.Cells[3].Value.ToString();
                    Update_Craft_Final.canshu2 = dr.Cells[5].Value.ToString();
                    Update_Craft_Final.canshu3 = dr.Cells[7].Value.ToString();
                    Update_Craft_Final.canshu4 = dr.Cells[9].Value.ToString();
                    Update_Craft_Final.canshu5 = dr.Cells[11].Value.ToString();
                    Update_Craft_Final.canshu6 = dr.Cells[13].Value.ToString();
                    Update_Craft_Final.canshu7 = dr.Cells[15].Value.ToString();
                    Update_Craft_Final.canshu8 = dr.Cells[17].Value.ToString();
                    Update_Craft_Final.canshu9 = dr.Cells[19].Value.ToString();
                    Update_Craft_Final.canshu10 = dr.Cells[21].Value.ToString();

                    Update_Craft_Final.canshu1_shuoming = dr.Cells[2].Value.ToString();
                    Update_Craft_Final.canshu2_shuoming = dr.Cells[4].Value.ToString();
                    Update_Craft_Final.canshu3_shuoming = dr.Cells[6].Value.ToString();
                    Update_Craft_Final.canshu4_shuoming = dr.Cells[8].Value.ToString();
                    Update_Craft_Final.canshu5_shuoming = dr.Cells[10].Value.ToString();
                    Update_Craft_Final.canshu6_shuoming = dr.Cells[12].Value.ToString();
                    Update_Craft_Final.canshu7_shuoming = dr.Cells[14].Value.ToString();
                    Update_Craft_Final.canshu8_shuoming = dr.Cells[16].Value.ToString();
                    Update_Craft_Final.canshu9_shuoming = dr.Cells[18].Value.ToString();
                    Update_Craft_Final.canshu10_shuoming = dr.Cells[20].Value.ToString();


                    Update_Craft_Final view = new Update_Craft_Final();
                    DialogResult result = view.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string where_cmd1 = "ID='" + dr.Cells[0].Value.ToString() + "'";
                        string[] update_cmd = new string[11];
                        update_cmd[0] = "craft_name='" + Update_Craft_Final.Craft_Name + "'";
                        update_cmd[1] = "value1='" + Update_Craft_Final.canshu1 + "'";
                        update_cmd[2] = "value2='" + Update_Craft_Final.canshu2 + "'";
                        update_cmd[3] = "value3='" + Update_Craft_Final.canshu3 + "'";
                        update_cmd[4] = "value4='" + Update_Craft_Final.canshu4 + "'";
                        update_cmd[5] = "value5='" + Update_Craft_Final.canshu5 + "'";
                        update_cmd[6] = "value6='" + Update_Craft_Final.canshu6 + "'";
                        update_cmd[7] = "value7='" + Update_Craft_Final.canshu7 + "'";
                        update_cmd[8] = "value8='" + Update_Craft_Final.canshu8 + "'";
                        update_cmd[9] = "value9='" + Update_Craft_Final.canshu9 + "'";
                        update_cmd[10] = "value10='" + Update_Craft_Final.canshu10 + "'";

                        MainView.builder.Updata(craft_name, where_cmd1, update_cmd);

                        ReFlash_Gongyi_Fanal(craft_name);
                    }
                }
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string gongyiname = comboBox_gongyihao.Text.PadLeft(3, '0');
            ReFlash_Gongyi_Fanal(gongyiname);
        }

        private void comboBox_gongyi_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox_gongyi_TextUpdate(object sender, EventArgs e)
        {
            
        }
    }
}
