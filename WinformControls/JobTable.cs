using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformControls
{
    public partial class JobTable : UserControl
    {

        public void Set_Machine_Num(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Label mylabel = new Label();
                mylabel.Font = new Font(new FontFamily("黑体"), 24, FontStyle.Regular);
                mylabel.Left = 30;
                mylabel.Top = i * 200 + 30;
                mylabel.Height = 80;
                mylabel.Text = (i + 1).ToString() + "号机";
                panel1.Controls.Add(mylabel);
            }
        }

        public JobTable()
        {
            InitializeComponent();
        }
    }
}
