using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace YinRan2020
{
    public partial class MyDataGridView : UserControl
    {
        public MyDataGridView()
        {
            InitializeComponent();
        }

        private void DataGrid_ReSize()
        {
            dataGridView1.Top = 0;
            dataGridView1.Left = 0;
            dataGridView1.Width = this.Width;
            dataGridView1.Height = this.Height;
        }

        // 设置表格头名称
        public void Set_Header(string[] header_arraylist)
        {
            for(int i=0;i<=dataGridView1.Columns.Count;i++)
            {
                try
                {
                    dataGridView1.Columns[i].HeaderText = "";
                }
                catch { }
            }
            for (int i = 0; i <= dataGridView1.Columns.Count; i++)
            {
                try
                {
                    dataGridView1.Columns[i].HeaderText = header_arraylist[i];
                }
                catch { }
            }
        }

        // 读取表格
        public void Read_Table(DataTable dt)
        {
            dataGridView1.ColumnCount = 1;
            dataGridView1.RowCount = 1;
            dataGridView1[0, 0].Value = "";
            try
            {
                dataGridView1.RowCount = dt.Rows.Count;
                dataGridView1.ColumnCount = dt.Columns.Count;
                
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        dataGridView1[j, i].Value = dt.Rows[i][j].ToString();
                    }
                }
            }
            catch { }
        }

        private void MyDataGridView_Resize(object sender, EventArgs e)
        {
            DataGrid_ReSize();
        }

        // 返回表格的某个数据
        public string Get_Value(int row, int col)
        {
            return dataGridView1[col, row].Value.ToString();
        }

        // 返回表格选中的一行
        public DataGridViewRow Selected_Row()
        {
            return dataGridView1.SelectedRows[0];
        }
    }
}
