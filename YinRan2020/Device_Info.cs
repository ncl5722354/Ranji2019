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
    public partial class Device_Info : Form
    {
        public Device_Info()
        {
            InitializeComponent();
            init_view();
        }
        private void init_view()
        {
            ViewCaoZuo.Object_Position(0, 0, 1, 0.05, label_title, this.Controls);
        }

        public void Set_Title(string name)
        {
            label_title.Text = name;
        }
    }
}
