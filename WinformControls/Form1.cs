using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformControls
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            jobTable1.Set_Machine_Num(50);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            

        }
    }
}
