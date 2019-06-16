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
using System.Collections;

namespace YinRan2020
{
    public partial class Craft_Config : Form
    {

        public string Title = "";
        public Craft_Config()
        {
            InitializeComponent();
            init_view();
            ReFlash_Craft_Canshu_Name();
            ReFlash_Craft_Name_Code();
        }

        // 刷新工艺参数表格
        public void ReFlash_Craft_Canshu_Name()
        {
            // 清空表格
            dataGridView_craft_name.RowCount = 1;
            for (int i = 0; i < dataGridView_craft_name.Columns.Count; i++)
            {
                dataGridView_craft_name[i, 0].Value = "";
            }

            // 读取工艺名称与参数数据库
            DataTable dt = MainView.builder.Select_Table("Craft_Name_Table");
            try
            {
                dataGridView_craft_name.RowCount = dt.Rows.Count;
                for (int i = 0; i < dataGridView_craft_name.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView_craft_name.Columns.Count; j++)
                    {
                        dataGridView_craft_name[j, i].Value = dt.Rows[i][j].ToString();
                    }
                }
            }
            catch { }
        }


        // 刷新工艺名称与工艺代码对照表
        public void ReFlash_Craft_Name_Code()
        {
            // 清空表格
            dataGridView_craft_code.RowCount = 1;
            for (int i = 0; i < dataGridView_craft_code.Columns.Count; i++)
            {
                dataGridView_craft_code[i, 0].Value = "";
            }

            // 读取工艺名称与参数数据库
            DataTable dt = MainView.builder.Select_Table("Craft_Name_Code");
            try
            {
                dataGridView_craft_code.RowCount = dt.Rows.Count;
                for (int i = 0; i < dataGridView_craft_code.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView_craft_code.Columns.Count; j++)
                    {
                        dataGridView_craft_code[j, i].Value = dt.Rows[i][j].ToString();
                    }
                }
            }
            catch { }
        }

        private void init_view()
        {
            ViewCaoZuo.Object_Position(0.37, 0.01, 0.26, 0.15, label_title, this.Controls);

            ViewCaoZuo.Object_Position(0, 0.15, 1, 0.75, tabControl1, this.Controls);

            // 工艺名称对应表格
            ViewCaoZuo.Object_Position(0, 0.1, 1, 0.85, dataGridView_craft_name, tabControl1.TabPages[0].Controls);

            // 工艺代码对应表格
            ViewCaoZuo.Object_Position(0, 0.1, 1, 0.85, dataGridView_craft_code, tabControl1.TabPages[3].Controls);


            // 工艺段设置的相关信息

            ViewCaoZuo.Object_Position(0, 0.1, 0.2, 0.8, panel_gongyiduan_info, tabControl1.TabPages[1].Controls);

            //xiangxi

            ViewCaoZuo.Object_Position(0.3, 0.05, 0.4, 0.9, panel_xiangxi, tabControl1.TabPages[1].Controls);
            ViewCaoZuo.Object_Position(0, 0.1, 1, 0.9, dataGridView_xiangxi, panel_xiangxi.Controls);

            // info
            ViewCaoZuo.Object_Position(0.75, 0.05, 0.4, 0.9, panel_info, tabControl1.TabPages[1].Controls);
            ViewCaoZuo.Object_Position(0, 0.1, 1, 0.9, dataGridView_info, panel_info.Controls);


            // listbox craft
            ViewCaoZuo.Object_Position(0.01, 0.1, 0.2, 0.9, listBox_gongyi, tabControl1.TabPages[2].Controls);


            // datagridview_craft
            ViewCaoZuo.Object_Position(0.25, 0.1, 0.5, 0.9, panel_craft, tabControl1.TabPages[2].Controls);
            ViewCaoZuo.Object_Position(0, 0.05, 1, 0.9, dataGridView_craft, panel_craft.Controls);
            ViewCaoZuo.Object_Position(0.76, 0.1, 0.23, 0.9, dataGridView_exe, tabControl1.TabPages[2].Controls);
            //
            

            listBox_gongyi.Items.Clear();
            for (int i = 1; i <= 300; i++)
            {
                listBox_gongyi.Items.Add("工艺" + i.ToString().PadLeft(3, '0'));

                // 建立300个工艺库
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

               // MainView.builder.Create_Table("工艺" + i.ToString().PadLeft(3, '0'), create_cmd);
            }

            //dataGridView1.RowCount = 1;
            dataGridView_craft_name.ColumnCount = 12;
            dataGridView_craft_name.Columns[0].HeaderText = "工艺名称";
            dataGridView_craft_name.Columns[1].HeaderText = "参数1名称";
            dataGridView_craft_name.Columns[2].HeaderText = "参数2名称";
            dataGridView_craft_name.Columns[3].HeaderText = "参数3名称";
            dataGridView_craft_name.Columns[4].HeaderText = "参数4名称";
            dataGridView_craft_name.Columns[5].HeaderText = "参数5名称";
            dataGridView_craft_name.Columns[6].HeaderText = "参数6名称";
            dataGridView_craft_name.Columns[7].HeaderText = "参数7名称";
            dataGridView_craft_name.Columns[8].HeaderText = "参数8名称";
            dataGridView_craft_name.Columns[9].HeaderText = "参数9名称";
            dataGridView_craft_name.Columns[10].HeaderText = "参数10名称";
            dataGridView_craft_name.Columns[11].HeaderText = "备注";

            dataGridView_craft_name.Columns[10].Width = 120;
            dataGridView_craft_name.Columns[11].Width = 400;


            // 
            dataGridView_info.ColumnCount = 5;
            dataGridView_info.Columns[0].HeaderText = "ID";
            dataGridView_info.Columns[1].HeaderText = "模式";
            dataGridView_info.Columns[2].HeaderText = "地址";
            dataGridView_info.Columns[3].HeaderText = "行数";
            dataGridView_info.Columns[4].HeaderText = "列数";
            dataGridView_info.Columns[0].Width = 60;
            dataGridView_info.Columns[1].Width = 60;
            dataGridView_info.Columns[2].Width = 60;
            dataGridView_info.Columns[3].Width = 60;
            dataGridView_info.Columns[4].Width = 60;
        }

        public void Set_Title(string title)
        {
            label_title.Text = title + "工艺设计";
            Title = title;
        }

        private void Craft_Config_Resize(object sender, EventArgs e)
        {
            init_view();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Add_Craft_Name view = new Add_Craft_Name();
            DialogResult resut = view.ShowDialog();
            if (resut == DialogResult.OK)
            {
                string[] inser_cmd = new string[12];
                inser_cmd[0] = Add_Craft_Name.Craft_Name;
                inser_cmd[1] = Add_Craft_Name.Canshu1_Name;
                inser_cmd[2] = Add_Craft_Name.Canshu2_Name;
                inser_cmd[3] = Add_Craft_Name.Canshu3_Name;
                inser_cmd[4] = Add_Craft_Name.Canshu4_Name;
                inser_cmd[5] = Add_Craft_Name.Canshu5_Name;
                inser_cmd[6] = Add_Craft_Name.Canshu6_Name;
                inser_cmd[7] = Add_Craft_Name.Canshu7_Name;
                inser_cmd[8] = Add_Craft_Name.Canshu8_Name;
                inser_cmd[9] = Add_Craft_Name.Canshu9_Name;
                inser_cmd[10] = Add_Craft_Name.Canshu10_Name;
                inser_cmd[11] = Add_Craft_Name.beizhu;
                bool result = MainView.builder.Insert("Craft_Name_Table", inser_cmd);
                if (result == false)
                {
                    MessageBox.Show("检查是否已经有此工艺！");
                }
                ReFlash_Craft_Canshu_Name();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView_craft_name.SelectedRows[0];
                string key = dr.Cells[0].Value.ToString();
                DeleteDevice view = new DeleteDevice();
                view.Set_Title("是否删除工艺 " + key);
                DialogResult result = view.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string where_cmd = "Gongyi_Name='" + key + "'";
                    MainView.builder.Delete("Craft_Name_Table", where_cmd);
                }
                ReFlash_Craft_Canshu_Name();
            }
            catch { }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView_craft_name.SelectedRows[0];
                string key = dr.Cells[0].Value.ToString();

                Update_Craft_Name.Craft_Name = dr.Cells[0].Value.ToString();
                Update_Craft_Name.Canshu1_Name = dr.Cells[1].Value.ToString();
                Update_Craft_Name.Canshu2_Name = dr.Cells[2].Value.ToString();
                Update_Craft_Name.Canshu3_Name = dr.Cells[3].Value.ToString();
                Update_Craft_Name.Canshu4_Name = dr.Cells[4].Value.ToString();
                Update_Craft_Name.Canshu5_Name = dr.Cells[5].Value.ToString();
                Update_Craft_Name.Canshu6_Name = dr.Cells[6].Value.ToString();
                Update_Craft_Name.Canshu7_Name = dr.Cells[7].Value.ToString();
                Update_Craft_Name.Canshu8_Name = dr.Cells[8].Value.ToString();
                Update_Craft_Name.Canshu9_Name = dr.Cells[9].Value.ToString();
                Update_Craft_Name.Canshu10_Name = dr.Cells[10].Value.ToString();
                Update_Craft_Name.beizhu = dr.Cells[11].Value.ToString();
                Update_Craft_Name view = new Update_Craft_Name();
                view.ShowDialog();


                ReFlash_Craft_Canshu_Name();

            }
            catch { }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Add_Craft_Code view = new Add_Craft_Code();
            DialogResult result = view.ShowDialog();
            if (result == DialogResult.OK)
            {
                string[] insert_cmd = new string[2];
                insert_cmd[0] = Add_Craft_Code.craft_name;
                insert_cmd[1] = Add_Craft_Code.craft_code;

                MainView.builder.Insert("Craft_Name_Code", insert_cmd);
            }
            ReFlash_Craft_Name_Code();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView_craft_code.SelectedRows[0];
                string key = dr.Cells[0].Value.ToString();
                DeleteDevice view = new DeleteDevice();
                view.Set_Title("是否删除工艺名称 " + key);
                DialogResult result = view.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string where_cmd = "Craft_Name='" + key + "'";
                    MainView.builder.Delete("Craft_Name_Code", where_cmd);
                }
                ReFlash_Craft_Name_Code();

            }
            catch { }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView_craft_code.SelectedRows[0];
                string key = dr.Cells[0].Value.ToString();
                string value = dr.Cells[1].Value.ToString();
                UpdateCraft_Code.craft_name = key;
                UpdateCraft_Code.craft_code = value;
                UpdateCraft_Code view = new UpdateCraft_Code();
                view.ShowDialog();
                ReFlash_Craft_Name_Code();
            }
            catch { }
        }

        private void tabControl1_Resize(object sender, EventArgs e)
        {
            init_view();
        }


        /// 工艺代码表
        ///
        /// 每一个工艺都对应着两个列表，一个是工艺详细的说明(工艺名+xiangxi)，一个是工艺本身每个元素对应的格子(工艺名+shuoming)
        ///
        /// xiangxi:   序号  参数1  参数2  工艺  主泵频率  提布频率 
        /// 
        /// shuoming： 1     单个单元或整列   参数地址      行数      列数
        ///            2     单个单元或整列   参数地址      行数      列数
        ///            3     单个单元或整列   参数地址      行数      列数
        ///            4     单个单元或整列   参数地址      行数      列数
        ///            5     单个单元或整列   参数地址      行数      列数
        ///            6     单个单元或整列   参数地址      行数      列数
        ///            7     单个单元或整列   参数地址      行数      列数
        ///            8     单个单元或整列   参数地址      行数      列数       
        ///            9     单个单元或整列   参数地址      行数      列数
        ///           10     单个单元或整列   参数地址      行数      列数
        ///           


        //  更新所有的工艺段名字
        private void Reflush_Gongyiduan_List()
        {
            comboBox_gongyi.Items.Clear();
            try
            {
                DataTable dt = MainView.builder.Select_Table("Craft_Name_Table");
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox_gongyi.Items.Add(dr[0].ToString());
                }
            }
            catch { }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            Reflush_Gongyiduan_List(); // 更新所有的工艺段名字
        }

        private void button_read_gongyiduan_Click(object sender, EventArgs e)
        {
            // 读取工艺xiangxi和工艺info
            // 如果没有就建立一个

            if (comboBox_gongyi.Text == "")
            {
                MessageBox.Show("选择一个需要编辑的工艺段!");
                return;
            }
            string craft_name = comboBox_gongyi.Text;
            DataTable xiangxi = MainView.builder.Select_Table(craft_name + "xiangxi");
            DataTable info = MainView.builder.Select_Table(craft_name + "info");

            // 没有xiangxi这张表
            if (xiangxi == null)
            {
                CreateSqlValueType[] create_cmd = new CreateSqlValueType[9];
                create_cmd[0] = new CreateSqlValueType("int", "ID", true);
                create_cmd[1] = new CreateSqlValueType("nvarchar(50)", "value1");
                create_cmd[2] = new CreateSqlValueType("nvarchar(50)", "value2");
                create_cmd[3] = new CreateSqlValueType("nvarchar(50)", "Craft");
                create_cmd[4] = new CreateSqlValueType("nvarchar(50)", "zhubenpinlv");
                create_cmd[5] = new CreateSqlValueType("nvarchar(50)", "tibupinlv");
                MainView.builder.Create_Table(craft_name + "xiangxi", create_cmd);
            }

            if (info == null)
            {
                CreateSqlValueType[] create_cmd = new CreateSqlValueType[5];
                create_cmd[0] = new CreateSqlValueType("nvarchar(50)", "ID");
                create_cmd[1] = new CreateSqlValueType("nvarchar(50)", "mode");
                create_cmd[2] = new CreateSqlValueType("nvarchar(50)", "address");
                create_cmd[3] = new CreateSqlValueType("nvarchar(50)", "row_index");
                create_cmd[4] = new CreateSqlValueType("nvarchar(50)", "col_index");
                MainView.builder.Create_Table(craft_name + "info", create_cmd);
            }
            ReFlush_Xiangxi(craft_name);
            ReFlush_Info(craft_name);
        }

        // 读取xiangxi
        private void ReFlush_Xiangxi(string xiangxi_name)
        {
            try
            {
                DataTable dt = MainView.builder.Select_Table(xiangxi_name + "xiangxi");
                dataGridView_xiangxi.RowCount = 1;
                for (int i = 0; i < dataGridView_xiangxi.ColumnCount; i++)
                {
                    dataGridView_xiangxi[i, 0].Value = "";
                }

                dataGridView_xiangxi.RowCount = dt.Rows.Count;
                for (int i = 0; i < dataGridView_xiangxi.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView_xiangxi.ColumnCount; j++)
                    {
                        dataGridView_xiangxi[j, i].Value = dt.Rows[i][j].ToString();
                    }
                }
            }
            catch { }
        }

        private void ReFlush_Info(string info_name)
        {
            try
            {
                DataTable dt = MainView.builder.Select_Table(info_name + "info");
                dataGridView_info.RowCount = 1;
                for (int i = 0; i < dataGridView_info.ColumnCount; i++)
                {
                    dataGridView_info[i, 0].Value = "";
                }
                dataGridView_info.RowCount = dt.Rows.Count;
                for (int i = 0; i < dataGridView_info.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView_info.ColumnCount; j++)
                    {
                        dataGridView_info[j, i].Value = dt.Rows[i][j].ToString();
                    }
                }
            }
            catch { }
        }

        private void ReFlush_Craft(string craft_name)
        {

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (comboBox_gongyi.Text == "")
            {
                MessageBox.Show("必须选择要编辑的工艺段");
                return;
            }
            Add_CraftDuan view = new Add_CraftDuan();
            view.Set_Title("为工艺段" + comboBox_gongyi.Text + "添加工艺");
            DialogResult result = view.ShowDialog();
            if (result == DialogResult.OK)
            {
                string craft_name = comboBox_gongyi.Text;
                DataTable xiangxi = MainView.builder.Select_Table(craft_name + "xiangxi");
                int rowcount = xiangxi.Rows.Count;
                rowcount++;
                string[] insert_cmd = new string[6];
                insert_cmd[0] = rowcount.ToString();
                insert_cmd[1] = Add_CraftDuan.value1;
                insert_cmd[2] = Add_CraftDuan.value2;
                insert_cmd[3] = Add_CraftDuan.craft_name;
                insert_cmd[4] = Add_CraftDuan.zhubengpinlv;
                insert_cmd[5] = Add_CraftDuan.tibupinlv;
                MainView.builder.Insert(craft_name + "xiangxi", insert_cmd);
                ReFlush_Xiangxi(craft_name);
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            try
            {
                string craft_name = comboBox_gongyi.Text;
                //DataGridViewRow dr = dataGridView_craft_name.SelectedRows[0];
                //string key = dr.Cells[0].Value.ToString();
                DataGridViewRow dr = dataGridView_xiangxi.SelectedRows[0];
                string selected_index = dr.Cells[0].Value.ToString();
                int selected_index_int = int.Parse(selected_index);
                DeleteDevice view = new DeleteDevice();
                view.Set_Title("是否删除第" + selected_index + "条工艺");

                DialogResult result = view.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string where_cmd = "ID='" + selected_index + "'";
                    bool is_delete = MainView.builder.Delete(craft_name + "xiangxi", where_cmd);

                    if (is_delete == true)
                    {
                        // 将所有后面的ID号减1
                        DataTable dt = MainView.builder.Select_Table(craft_name + "xiangxi");
                        foreach (DataRow mydr in dt.Rows)
                        {
                            if (int.Parse(mydr[0].ToString()) > selected_index_int)
                            {
                                string[] update_cmd = new string[1];
                                int myindex = int.Parse(mydr[0].ToString());
                                update_cmd[0] = "ID='" + (myindex - 1).ToString() + "'";

                                string update_where_cmd = "ID='" + myindex.ToString() + "'";
                                MainView.builder.Updata(craft_name + "xiangxi", update_where_cmd, update_cmd);

                            }
                        }

                    }
                }
                ReFlush_Xiangxi(craft_name);
            }
            catch { }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            try
            {
                string craft_name = comboBox_gongyi.Text;
                //DataGridViewRow dr = dataGridView_craft_name.SelectedRows[0];
                //string key = dr.Cells[0].Value.ToString();
                DataGridViewRow dr = dataGridView_xiangxi.SelectedRows[0];

                Update_CraftDuan.ID = dr.Cells[0].Value.ToString();
                Update_CraftDuan.value1 = dr.Cells[1].Value.ToString();
                Update_CraftDuan.value2 = dr.Cells[2].Value.ToString();
                Update_CraftDuan.craft_name = dr.Cells[3].Value.ToString();
                Update_CraftDuan.zhubengpinlv = dr.Cells[4].Value.ToString();
                Update_CraftDuan.tibupinlv = dr.Cells[5].Value.ToString();

                Update_CraftDuan view = new Update_CraftDuan();
                view.Set_Title("更新工艺段 " + comboBox_gongyi.Text);
                DialogResult result = view.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string[] update_cmd = new string[5];
                    update_cmd[0] = "value1='" + Update_CraftDuan.value1 + "'";
                    update_cmd[1] = "value2='" + Update_CraftDuan.value2 + "'";
                    update_cmd[2] = "Craft='" + Update_CraftDuan.craft_name + "'";
                    update_cmd[3] = "zhubenpinlv='" + Update_CraftDuan.zhubengpinlv + "'";
                    update_cmd[4] = "tibupinlv='" + Update_CraftDuan.tibupinlv + "'";
                    string where_cmd = "ID='" + Update_CraftDuan.ID + "'";

                    MainView.builder.Updata(craft_name + "xiangxi", where_cmd, update_cmd);
                }

                ReFlush_Xiangxi(craft_name);



            }
            catch { }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_gongyi.Text == "")
                {
                    MessageBox.Show("必须选择要编辑的工艺段");
                    return;
                }
                Add_Craft_info view = new Add_Craft_info();
                string craft_name = comboBox_gongyi.Text;
                DataTable dt = MainView.builder.Select_Table(craft_name + "info");

                int rows = dt.Rows.Count;   //现在有多少行

                view.Set_Title("编辑工艺段" + comboBox_gongyi.Text);
                DialogResult result = view.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string[] insert_cmd = new string[5];
                    insert_cmd[0] = (rows + 1).ToString();
                    insert_cmd[1] = Add_Craft_info.mode;
                    insert_cmd[2] = Add_Craft_info.address;
                    insert_cmd[3] = Add_Craft_info.row;
                    insert_cmd[4] = Add_Craft_info.col;

                    MainView.builder.Insert(craft_name + "info", insert_cmd);
                }
                ReFlush_Info(craft_name);
            }
            catch { }
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            try
            {
                string craft_name = comboBox_gongyi.Text;

                DataGridViewRow dr = dataGridView_info.SelectedRows[0];

                string key = dr.Cells[0].Value.ToString();
                int selected_index_int = int.Parse(key);
                DeleteDevice view = new DeleteDevice();
                view.Set_Title("删除工艺段设置项");
                DialogResult result = view.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string where_cmd = "ID='" + key + "'";
                    bool is_delete = MainView.builder.Delete(craft_name + "info", where_cmd);

                    // 后面的ID号-1

                    if (is_delete == true)
                    {
                        // 将所有后面的ID号减1
                        DataTable dt = MainView.builder.Select_Table(craft_name + "info");
                        foreach (DataRow mydr in dt.Rows)
                        {
                            if (int.Parse(mydr[0].ToString()) > selected_index_int)
                            {
                                string[] update_cmd = new string[1];
                                int myindex = int.Parse(mydr[0].ToString());
                                update_cmd[0] = "ID='" + (myindex - 1).ToString() + "'";

                                string update_where_cmd = "ID='" + myindex.ToString() + "'";
                                MainView.builder.Updata(craft_name + "info", update_where_cmd, update_cmd);

                            }
                        }

                    }
                }
                ReFlush_Info(craft_name);
            }
            catch { }
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            try
            {
                string craft_name = comboBox_gongyi.Text;

                DataGridViewRow dr = dataGridView_info.SelectedRows[0];

                Update_Craft_Info.ID = dr.Cells[0].Value.ToString();
                Update_Craft_Info.mode = dr.Cells[1].Value.ToString();
                Update_Craft_Info.address = dr.Cells[2].Value.ToString();
                Update_Craft_Info.row = dr.Cells[3].Value.ToString();
                Update_Craft_Info.col = dr.Cells[4].Value.ToString();
                Update_Craft_Info view = new Update_Craft_Info();
                DialogResult result = view.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string[] update_cmd = new string[4];
                    update_cmd[0] = "mode='" + Update_Craft_Info.mode + "'";
                    update_cmd[1] = "address='" + Update_Craft_Info.address + "'";
                    update_cmd[2] = "row_index='" + Update_Craft_Info.row + "'";
                    update_cmd[3] = "col_index='" + Update_Craft_Info.col + "'";

                    string where_cmd = "ID='" + Update_Craft_Info.ID + "'";

                    MainView.builder.Updata(craft_name + "info", where_cmd, update_cmd);
                }
                ReFlush_Info(craft_name);
            }
            catch { }
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            try
            {
                string selected_gongyi = listBox_gongyi.Items[listBox_gongyi.SelectedIndex].ToString();
                Add_Craft_Final view = new Add_Craft_Final();
                view.set_title(selected_gongyi);
                DialogResult result = view.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // 添加一条工艺
                    DataTable dt = MainView.builder.Select_Table(selected_gongyi);
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

        private void listBox_gongyi_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                ReFlash_Gongyi_Fanal(listBox_gongyi.Items[listBox_gongyi.SelectedIndex].ToString());
                ReFlush_Exe_Craft();
            }
            catch { }
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {

            try
            {
                string craft_name = listBox_gongyi.Items[listBox_gongyi.SelectedIndex].ToString();
                //DataGridViewRow dr = dataGridView_craft_name.SelectedRows[0];
                //string key = dr.Cells[0].Value.ToString();
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


        // 刷新执行工艺
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

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            try
            {
                // 选择的工艺名称
                string craft_name = listBox_gongyi.Items[listBox_gongyi.SelectedIndex].ToString();

                // 选择的行
                DataGridViewRow dr = dataGridView_craft.SelectedRows[0];


                string key = dr.Cells[0].Value.ToString();
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
                    Update_Craft_Final.canshu1 = dr1[1].ToString();
                    Update_Craft_Final.canshu2 = dr1[2].ToString();
                    Update_Craft_Final.canshu3 = dr1[3].ToString();
                    Update_Craft_Final.canshu4 = dr1[4].ToString();
                    Update_Craft_Final.canshu5 = dr1[5].ToString();
                    Update_Craft_Final.canshu6 = dr1[6].ToString();
                    Update_Craft_Final.canshu7 = dr1[7].ToString();
                    Update_Craft_Final.canshu8 = dr1[8].ToString();
                    Update_Craft_Final.canshu9 = dr1[9].ToString();
                    Update_Craft_Final.canshu10 = dr1[10].ToString();

                    Update_Craft_Final view = new Update_Craft_Final();
                    DialogResult result = view.ShowDialog();


                }



            }
            catch { }
        }
    }
}

