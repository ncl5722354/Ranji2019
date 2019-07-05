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


namespace YinRan2020
{
    public partial class zongmao : Form
    {
        public event EventHandler Click_Yiliu = null;
        public event EventHandler Click_Qiliu = null;
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

           for(int i=0;i<6;i++)
           {
               tabControl1.TabPages[i].Width =(int)( tabControl1.Width * 0.99);
               tabControl1.TabPages[i].Height =(int)( tabControl1.Height * 0.99);
           }


           ReSet_Device_Info();
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
            // 按照设备号进行排列
            for (int i = 0; i < 6; i++)
            {
                int count = tabControl1.TabPages[i].Controls.Count;

                for (int j = 0; j < count; j++)
                {
                    Control control = (Control)tabControl1.TabPages[i].Controls[0];
                    tabControl1.TabPages[i].Controls.Remove(control);
                    control.Dispose();
                }

                for (int j = 1; j <= 12; j++)
                {
                    try
                    {
                        int machine_num = i * 12 + j;
                        string where_cmd = "Address='" + machine_num.ToString() + "'";
                        DataTable dt_machine = MainView.builder.Select_Table("Device_Info", where_cmd);
                        DataRow dr = dt_machine.Rows[0];
                        if (dr[3].ToString() == "溢流缸")
                        {
                            if(machine_num>65)
                            {
                                MessageBox.Show("超过最大限制，请联系厂家升级！");
                            }
                            YiLiuGang_Item item = new YiLiuGang_Item();
                            item.MyClick += new EventHandler(Click_Yiliu);
                            item.Set_Title(dr[0].ToString());
                            ViewCaoZuo.Object_Position(0 + ((j-1) % 4) * 0.25, 0.01 + ((j-1) / 4) * 0.31, 0.24, 0.3, item, tabControl1.TabPages[i].Controls);
                        }

                        if (dr[3].ToString() == "气流缸")
                        {
                            if (machine_num > 65)
                            {
                                MessageBox.Show("超过最大限制，请联系厂家升级！");
                            } 
                            QiLiuGang item = new QiLiuGang();
                            item.Set_Title(dr[0].ToString());
                            item.MyClick += new EventHandler(Click_Qiliu);
                            ViewCaoZuo.Object_Position(0 + ((j-1) % 4) * 0.25, 0.01 + ((j-1) / 4) * 0.31, 0.24, 0.3, item, tabControl1.TabPages[i].Controls);
                        }
                    }
                    catch { }
                }
            }
        }

        private void Show_Yiliu(object sender,EventArgs e)
        {
            Click_Yiliu(sender, e);
        }

        private void Show_Qiliu(object sender,EventArgs e)
        {
            Click_Qiliu(sender, e);
        }

        private void tabControl1_Resize(object sender, EventArgs e)
        {
           // init_view();
        }

        private void zongmao_Resize(object sender, EventArgs e)
        {
            //init_view();
        }

        private void tabPage6_Resize(object sender, EventArgs e)
        {
            //init_view();
        }

        private void tabPage5_Resize(object sender, EventArgs e)
        {
            //init_view();
        }

        private void tabPage4_Resize(object sender, EventArgs e)
        {
            //init_view();
        }

        private void tabPage3_Resize(object sender, EventArgs e)
        {
            //init_view();
        }

        private void tabPage2_Resize(object sender, EventArgs e)
        {
            //init_view();
        }

        private void tabPage1_Resize(object sender, EventArgs e)
        {
            //init_view();
        }
    }
}
