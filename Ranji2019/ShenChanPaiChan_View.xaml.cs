using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;

namespace Ranji2019
{
    /// <summary>
    /// ShenChanPaiChan_View.xaml 的交互逻辑
    /// </summary>
    public partial class ShenChanPaiChan_View : UserControl
    {
        public ShenChanPaiChan_View()
        {
            InitializeComponent();
            init_view();                               // 窗体的初始化
        }

        public static ArrayList all_paichan_tiao = new ArrayList();            // 所有的排产条
        

        // 窗体的初始化
        public  void init_view()
        {
            //scrollviewer.Margin = new Thickness(0.02 * MainWindow.screen_width, 0.1 * MainWindow.scree_height, 0, 0);
            //scrollviewer.Width = 0.75 * MainWindow.screen_width;
            //scrollviewer.Height = 0.75 * MainWindow.scree_height;

            SolidColorBrush solidbrush=new SolidColorBrush();
            solidbrush.Color = Color.FromRgb(0,0,0);       // 黑色

            

            // 80个机缸的排产
            //
            // 24个刻度
            
           
        }
    }
}
