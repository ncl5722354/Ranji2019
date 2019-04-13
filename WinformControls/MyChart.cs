using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinformControls
{
    public partial class MyChart : UserControl
    {
        public MyChart()
        {
            InitializeComponent();
        }

        // 曲线设定名称
        // 参数是曲线的索引
        public void ReName_Serial(int serial_index,string serial_name)
        {
            chart1.Series[serial_index].Name = serial_name;
            switch(serial_index)
            {
                case 0:
                    label_value1_name.Text = serial_name;
                    break;
                case 1:
                    label_value2_name.Text = serial_name;
                    break;
                case 2:
                    label_value3_name.Text = serial_name;
                    break;
                case 3:
                    label_value4_name.Text = serial_name;
                    break;
            }
        }

        // 曲线设定颜色
        // 参数是曲线的索引
        public void ReColor_Serial(int serial_index,Color color)
        {
            chart1.Series[serial_index].Color = color;
            switch (serial_index)
            {
                case 0:
                    label_value1_name.BackColor = color;
                    label_value1.BackColor = color;
                    break;
                case 1:
                    label_value2_name.BackColor = color;
                    label_value2.BackColor = color;
                    break;
                case 2:
                    label_value3_name.BackColor = color;
                    label_value3.BackColor = color;
                    break;
                case 3:
                    label_value4_name.BackColor = color;
                    label_value4.BackColor = color;
                    break;
            }

        }

        // 曲线消除一条线
        public void Clear_Serial(int serial_index)
        {
            chart1.Series[serial_index].Points.Clear();
        }


        // 某个曲线加入一个点
        public void Insert_Point(int serial_index,DateTime thistime,double value)
        {
            chart1.Series[serial_index].Points.AddXY(thistime.ToOADate(), value);
        }


        // 重新定位开始和结束
        public void Reset_Start_End(DateTime starttime,DateTime endtime)
        {
            chart1.ChartAreas[0].AxisX.Minimum = starttime.ToOADate();
            chart1.ChartAreas[0].AxisX.Maximum = endtime.ToOADate();
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                double x_pox = e.X;


                x_pox = chart1.ChartAreas[0].AxisX.PixelPositionToValue(x_pox);
                
                
                chart1.ChartAreas[0].CursorX.Position = x_pox;


                //chart1.Series[0].Points.

                for (int i = 0; i < chart1.Series[0].Points.Count; i++)
                {
                    if ( Math.Round(chart1.Series[0].Points[i].XValue,3) == Math.Round(x_pox,3))
                    {
                        label_value1.Text = chart1.Series[0].Points[i].YValues[0].ToString();
                    }
                }

                for (int i = 0; i < chart1.Series[1].Points.Count; i++)
                {
                    if (Math.Round(chart1.Series[1].Points[i].XValue, 3) == Math.Round(x_pox, 3))
                    {
                        label_value2.Text = chart1.Series[1].Points[i].YValues[0].ToString();
                    }
                }
            }
            catch { }
        }

       

    }
}
