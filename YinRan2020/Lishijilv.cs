using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ViewConfig;

namespace YinRan2020
{
    public partial class Lishijilv : Form
    {
        public Lishijilv()
        {
            InitializeComponent();
            init_view();
        }

        private void init_view()
        {
            ViewCaoZuo.Object_Position(0.40, 0.01, 0.2, 0.1, label_title, this.Controls);

            ViewCaoZuo.Object_Position(0.01, 0.13, 0.98, 0.3, panel_chart, this.Controls);
            ViewCaoZuo.Object_Position(0, 0, 1, 1, chart1, panel_chart.Controls);

            ViewCaoZuo.Object_Position(0.01, 0.44, 0.98, 0.05, panel_caozuo, this.Controls);

            ViewCaoZuo.Object_Position(0, 0, 0.1, 0.90, button_qian1hour, panel_caozuo.Controls);

            ViewCaoZuo.Object_Position(0.1, 0, 0.1, 0.9, button_qian5min, panel_caozuo.Controls);

            ViewCaoZuo.Object_Position(0.2, 0, 0.1, 0.9, button_now, panel_caozuo.Controls);

            ViewCaoZuo.Object_Position(0.3, 0, 0.1, 0.9, button_next5min, panel_caozuo.Controls);

            ViewCaoZuo.Object_Position(0.4, 0, 0.1, 0.9, button_next1hour, panel_caozuo.Controls);
        }

        private void Lishijilv_Resize(object sender, EventArgs e)
        {
            init_view();
        }
    }
}
