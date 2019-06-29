using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YinRan2020
{
    public partial class Password : Form
    {
        public Password()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "ncl5722354")
            {
                this.DialogResult = DialogResult.OK;
                this.Dispose();
            }
        }
    }
}
