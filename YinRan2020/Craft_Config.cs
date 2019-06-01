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
        }

        // 刷新工艺参数表格
        public void ReFlash_Craft_Canshu_Name()
        {
            // 清空表格
            dataGridView1.RowCount = 1;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1[i, 0].Value = "";
            }

            // 读取工艺名称与参数数据库
            DataTable dt = MainView.builder.Select_Table("Craft_Name_Table");
            try
            {
                dataGridView1.RowCount = dt.Rows.Count;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        dataGridView1[j, i].Value = dt.Rows[i][j].ToString();
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
            ViewCaoZuo.Object_Position(0, 0.1, 1, 0.85, dataGridView1, tabControl1.TabPages[0].Controls);
            //dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = 12;
            dataGridView1.Columns[0].HeaderText = "工艺名称";
            dataGridView1.Columns[1].HeaderText = "参数1名称";
            dataGridView1.Columns[2].HeaderText = "参数2名称";
            dataGridView1.Columns[3].HeaderText = "参数3名称";
            dataGridView1.Columns[4].HeaderText = "参数4名称";
            dataGridView1.Columns[5].HeaderText = "参数5名称";
            dataGridView1.Columns[6].HeaderText = "参数6名称";
            dataGridView1.Columns[7].HeaderText = "参数7名称";
            dataGridView1.Columns[8].HeaderText = "参数8名称";
            dataGridView1.Columns[9].HeaderText = "参数9名称";
            dataGridView1.Columns[10].HeaderText = "参数10名称";
            dataGridView1.Columns[11].HeaderText = "备注";

            dataGridView1.Columns[10].Width = 120;
            dataGridView1.Columns[11].Width = 400;
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
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
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
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
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

                //DeleteDevice view = new DeleteDevice();
                //view.Set_Title("是否删除工艺 " + key);
                //DialogResult result = view.ShowDialog();
                //if (result == DialogResult.OK)
                //{
                //    string where_cmd = "Gongyi_Name='" + key + "'";
                //    MainView.builder.Delete("Craft_Name_Table", where_cmd);
                //}
                ReFlash_Craft_Canshu_Name();
            }
            catch { }
        }

        
    }
}
