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
    public partial class zongmao : Form
    {

        public string CheJian_Name="";
        public zongmao()
        {
            InitializeComponent();
            init_view();
        }

        public void init_view()
        {
            // 初始化画面
            ViewCaoZuo.Object_Position(0, 0, 1, 0.05, label_title, this.Controls);

            // 容器 
            ViewCaoZuo.Object_Position(0.01, 0.06, 0.95, 0.89, tabControl1, this.Controls);
        }

        private void zongmao_SizeChanged(object sender, EventArgs e)
        {
            init_view();
        }

        public void Set_Chejian(string name)
        {
            label_title.Text = name + "实时生产情况";
            CheJian_Name = name;
        }

        public void ReSet_Device_Info()
        {
            // 总貌中显示设备的信息
            for (int i = 0; i < 6; i++)
            {

                //tabControl1.TabPages[i].Controls.Clear();
                int count = tabControl1.TabPages[i].Controls.Count;

                for (int j = 0; j < count;j++)
                {
                    Control control = (Control)tabControl1.TabPages[i].Controls[0];
                    tabControl1.TabPages[i].Controls.Remove(control);
                    control.Dispose();
                }

                    //tabControl1.TabPages[i].Controls.Clear();
                    GC.Collect();
                // 读取本车间的名称，并从com1到com6在数据库中读取设备信息
                //string keyname = tabControl1.TabPages[i].Name + CheJian_Name;
                string where_cmd = "workshop='" + CheJian_Name + "' and Com='" + tabControl1.TabPages[i].Text + "'";
                DataTable dt = MainView.builder.Select_Table("Device_Info", where_cmd);
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    DataRow dr = dt.Rows[j];
                    if (dr[3].ToString() == "溢流缸")
                    {
                        YiLiuGang_Item item = new YiLiuGang_Item();
                        item.Set_Title(dr[0].ToString());
                        ViewCaoZuo.Object_Position(0.01 + (j % 3) * 0.3, 0.01 + (j / 3) * 0.3, 0.3, 0.3, item, tabControl1.TabPages[i].Controls);
                    }

                    if(dr[3].ToString()=="气流缸")
                    {
                        QiLiuGang item = new QiLiuGang();
                        item.Set_Title(dr[0].ToString());
                        ViewCaoZuo.Object_Position(0.01 + (j % 3) * 0.3, 0.01 + (j / 3) * 0.3, 0.3, 0.3, item, tabControl1.TabPages[i].Controls);
                    }
                }
            }
            

           

           
        }


    }
}
