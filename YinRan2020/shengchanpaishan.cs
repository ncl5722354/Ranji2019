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

        public shengchanpaishan()
        {
            
            InitializeComponent();

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
            for(int i=1;i<=300;i++)
            {
                comboBox_gongyihao.Items.Add("工艺" + i.ToString().PadLeft(3, '0'));

            }


            // 
            ReFlush_GongDan_List();
        }

        private void button_readgongyi_Click(object sender, EventArgs e)
        {
            ReFlash_Gongyi_Fanal(comboBox_gongyihao.Text);
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
                            insert_cmd1[12] = dataGridView_craft[22, i].Value.ToString();
                            MainView.builder.Insert("工艺" + textBox_danhao.Text, insert_cmd1);
                        }

                    }
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
                dataGridView_craft.RowCount = 1;
                for (int i = 0; i < dataGridView_craft.ColumnCount; i++)
                {
                    dataGridView_craft[i, 0].Value = "";
                }
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                ReFlash_Gongyi_Fanal("工艺" + dr.Cells[0].Value.ToString());
                textBox_danhao.Text = dr.Cells[0].Value.ToString();
                comboBox_gongyihao.Text = dr.Cells[2].Value.ToString();
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
                    MainView.builder.Insert(selected_gongyi, insert_cmd);
                }
                ReFlash_Gongyi_Fanal(selected_gongyi);
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
                
                ReFlash_Gongyi_Fanal("工艺" + textBox_danhao.Text);
                
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

                    string where_cmd1 = "ID='" + dr.Cells[0].Value.ToString() + "'";
                    string[] update_cmd = new string[10];
                    update_cmd[0] = "value1='" + Update_Craft_Final.canshu1 + "'";
                    update_cmd[1] = "value2='" + Update_Craft_Final.canshu2 + "'";
                    update_cmd[2] = "value3='" + Update_Craft_Final.canshu3 + "'";
                    update_cmd[3] = "value4='" + Update_Craft_Final.canshu4 + "'";
                    update_cmd[4] = "value5='" + Update_Craft_Final.canshu5 + "'";
                    update_cmd[5] = "value6='" + Update_Craft_Final.canshu6 + "'";
                    update_cmd[6] = "value7='" + Update_Craft_Final.canshu7 + "'";
                    update_cmd[7] = "value8='" + Update_Craft_Final.canshu8 + "'";
                    update_cmd[8] = "value9='" + Update_Craft_Final.canshu9 + "'";
                    update_cmd[9] = "value10='" + Update_Craft_Final.canshu10 + "'";

                    MainView.builder.Updata(craft_name, where_cmd1, update_cmd);

                    ReFlash_Gongyi_Fanal(craft_name);
                }


                



            }
            catch { }
        }
    }
}
