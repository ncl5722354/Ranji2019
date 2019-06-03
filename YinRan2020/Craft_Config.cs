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

            ViewCaoZuo.Object_Position(0,0.1, 0.2, 0.8, panel_gongyiduan_info, tabControl1.TabPages[1].Controls);

            //
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
                if(result==false)
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

                MainView.builder.Insert("Craft_Name_Code",insert_cmd);
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
        /// shuoming： 1     单个单元或整列      行数      列数
        ///            2     单个单元或整列      行数      列数
        ///            3     单个单元或整列      行数      列数
        ///            4     单个单元或整列      行数      列数
        ///            5     单个单元或整列      行数      列数
        ///            6     单个单元或整列      行数      列数
        ///            7     单个单元或整列      行数      列数
        ///            8     单个单元或整列      行数      列数       
        ///            9     单个单元或整列      行数      列数
        ///           10     单个单元或整列      行数      列数
        ///           

        //  更新所有的工艺段名字
        private void Reflush_Gongyiduan_List()
        {
            comboBox_gongyi.Items.Clear();
            try
            {
                DataTable dt = MainView.builder.Select_Table("Craft_Name_Table");
                foreach(DataRow dr in dt.Rows)
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

            if(comboBox_gongyi.Text=="")
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
                CreateSqlValueType[] create_cmd = new CreateSqlValueType[4];
                create_cmd[0] = new CreateSqlValueType("nvarchar(50)", "ID");
                create_cmd[1] = new CreateSqlValueType("nvarchar(50)", "mode");
                create_cmd[2] = new CreateSqlValueType("nvarchar(50)","row_index");
                create_cmd[3] = new CreateSqlValueType("nvarchar(50)", "col_index");
                MainView.builder.Create_Table(craft_name + "info", create_cmd); 
            }

        }
    }
}
