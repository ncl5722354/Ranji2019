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

namespace WarningSystem
{
    /// <summary>
    /// ZhuZi.xaml 的交互逻辑
    /// </summary>
    public partial class ZhuZi : UserControl
    {
        ArrayList thislist = new ArrayList();
        int left = 70;
        int height = 100;
        int width = 360;
        int mymode = 0;
        string myname = "";
        ArrayList all_putong_point = new ArrayList();

        bool Press = false;
        double suofang = 13;

        public static double origin_width = 0;   // 图片原始大小
        public static double origin_height = 0;



        ArrayList mylist = new ArrayList();

        double[] rukou = new double[65535];// double.Parse(MainWindow.Point_ini.IniReadValue(name, "rukou"));
        double[] chukou = new double[65535];// double.Parse(MainWindow.Point_ini.IniReadValue(name, "chukou"));

        double[] X1 = new double[65535];// double.Parse(MainWindow.Point_ini.IniReadValue(name, "X1"));
        double[] X2 = new double[65535];// double.Parse(MainWindow.Point_ini.IniReadValue(name, "X2"));
        double[] Y1 =new double[65535];// double.Parse(MainWindow.Point_ini.IniReadValue(name, "Y1"));
        double[] Y2 = new double[65535];// double.Parse(MainWindow.Point_ini.IniReadValue(name, "Y2"));

        double[] offsite_x = new double[65535];// double.Parse(MainWindow.Point_ini.IniReadValue(myname, "offsite_x"));
        double[] offsite_y = new double[65535];// double.Parse(MainWindow.Point_ini.IniReadValue(myname, "offsite_y"));
       
        //System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        //
        //double rukou = double.Parse(MainWindow.Point_ini.IniReadValue(name, "rukou"));
        //                double chukou = double.Parse(MainWindow.Point_ini.IniReadValue(name, "chukou"));
        //                points_count = (int)(Math.Abs(chukou - rukou) * 5);
        //                double X1 = double.Parse(MainWindow.Point_ini.IniReadValue(name, "X1"));
        //                double X2 = double.Parse(MainWindow.Point_ini.IniReadValue(name, "X2"));
        //                double Y1 = double.Parse(MainWindow.Point_ini.IniReadValue(name, "Y1"));
        //                double Y2 = double.Parse(MainWindow.Point_ini.IniReadValue(name, "Y2"));

        //                double offsite_x = double.Parse(MainWindow.Point_ini.IniReadValue(myname, "offsite_x"));
        //                double offsite_y = double.Parse(MainWindow.Point_ini.IniReadValue(myname, "offsite_y"));


        public ZhuZi(ArrayList list,int mode,string name)
        {
            InitializeComponent();
            thislist = list;
            mymode = mode;
            myname = name;
            //scrollviewer1.CanContentScroll = false;
           

            subgrid.Margin = new Thickness(left, 0, 0, 0);

            if (mode == 2)
            {
                subgrid.Width = this.width * 13;
                subgrid.Height = this.height * 13;
                origin_height = subgrid.Height / 13;
                origin_width = subgrid.Width / 13;

                int count = int.Parse(MainWindow.Point_ini.IniReadValue(myname, "count"));

                for (int i = 1; i <= count; i++)
                {
                    string linename = MainWindow.Point_ini.IniReadValue(myname, "line" + i.ToString());
                    mylist.Add(linename);
                }
            }
            init();

        }

        public void ReSet(ArrayList list)
        {
            
            if (mymode == 2)
            {
                try
                {
#region
                    //    all_putong_point.Clear();
                    //    subgrid.Children.Clear();
                    //    int shu = thislist.Count;

                    //    for (int i = 1; i <= shu; i++)
                    //    {
                    //        try
                    //        {
                    //            DataList.Data_Struct datastruct = (DataList.Data_Struct)thislist[i - 1];
                    //            Label position = new Label();
                    //            position.Content = datastruct.位移量.ToString("#0.000") + " mm";
                    //            position.FontSize = 10;
                    //            position.Margin = new Thickness(0, i * 20 + 40, 0, 0);
                    //            subgrid.Children.Add(position);
                    //            position.Foreground = System.Windows.Media.Brushes.White;

                    //            Label yidong = new Label();
                    //            yidong.Content = "  ";
                    //            yidong.FontSize = 10;
                    //            yidong.Width = datastruct.位移量 * 10;
                    //            // yidong.Height = topimage.Height / 3;
                    //            yidong.VerticalAlignment = VerticalAlignment.Top;
                    //            yidong.HorizontalAlignment = HorizontalAlignment.Left;
                    //            yidong.Margin = new Thickness(140 - yidong.Width, i * 20 + 40, 0, 0);
                    //            if (datastruct.位移量 <= 0.5)
                    //            {
                    //                yidong.Background = System.Windows.Media.Brushes.Blue;
                    //            }
                    //            if (datastruct.位移量 > 0.5 && datastruct.位移量 < 2)
                    //            {
                    //                yidong.Background = System.Windows.Media.Brushes.Yellow;
                    //            }
                    //            if (datastruct.位移量 >= 2)
                    //            {
                    //                yidong.Background = System.Windows.Media.Brushes.Red;
                    //            }
                    //            subgrid.Children.Add(yidong);



                    //            Label position1 = new Label();
                    //            position1.Content = datastruct.位置.ToString("#0");
                    //            position1.FontSize = 10;
                    //            position1.VerticalAlignment = VerticalAlignment.Top;
                    //            position1.HorizontalAlignment = HorizontalAlignment.Left;
                    //            position1.Margin = new Thickness(150, i * 20 + 40, 0, 0);

                    //            subgrid.Children.Add(position1);

                    //            subgrid.VerticalAlignment = VerticalAlignment.Top;
                    //            subgrid.HorizontalAlignment = HorizontalAlignment.Left;
                    //            subgrid.Margin = new Thickness(left, 0, 0, 0);
                    //            subgrid.Height = (shu) * position1.Height;
                    //        }
                    //        catch { }
                    //    }
                    //}
                    //catch { }
#endregion
                    subgrid.Background = Brushes.LightGray;
                    all_putong_point.Clear();
                    subgrid.Children.Clear();
                   
                    int index=0;
                    foreach (string name in mylist)
                    {
                        int points_count = 0;
                        int my_count = 0;
                       
                        double rukou1 =  double.Parse(MainWindow.Point_ini.IniReadValue(name, "rukou"));
                        double chukou1 = double.Parse(MainWindow.Point_ini.IniReadValue(name, "chukou"));
                        points_count = (int)(Math.Abs(chukou1 - rukou1) * 5);

                        double X11 = double.Parse(MainWindow.Point_ini.IniReadValue(name, "X1"));
                        double X21 = double.Parse(MainWindow.Point_ini.IniReadValue(name, "X2"));
                        double Y11 = double.Parse(MainWindow.Point_ini.IniReadValue(name, "Y1"));
                        double Y21 = double.Parse(MainWindow.Point_ini.IniReadValue(name, "Y2"));

                        double offsite_x1 = double.Parse(MainWindow.Point_ini.IniReadValue(myname, "offsite_x"));
                        double offsite_y1 = double.Parse(MainWindow.Point_ini.IniReadValue(myname, "offsite_y"));

                        //index++;
                    

                        double mywidth = 0;
                        double myheight = 0;

                        myheight = origin_height * suofang;
                        mywidth = origin_width * suofang;
                        subgrid.Margin = new Thickness(subgrid.Margin.Left - (mywidth - subgrid.Width) / 2, subgrid.Margin.Top - (myheight - subgrid.Height) / 2, 0, 0);
                        subgrid.Width = mywidth;
                        subgrid.Height = myheight;


                        points_count = (int)(Math.Abs(chukou1 - rukou1) * 5);
                        foreach (DataList.Data_Struct item in MainWindow.Real_Data_List)
                        {
                            if (item.位置 >= rukou1 && item.位置 <= chukou1)
                            {
                                try
                                {
                                    my_count++;
                                    double x = (X21 - X11) / points_count * my_count + X11;
                                    double y = (Y21 - Y11) / points_count * my_count + Y11;

                                    putongpoint point = new putongpoint(x, y);
                                    point.key = item.位置.ToString();
                                    point.Width = 2;
                                    point.Height = 2;
                                    if (rukou1 < 2411)
                                        point.Margin = new Thickness((x - 400) * suofang - 400, (y - 100) * suofang- 500, 0, 0);
                                    if (rukou1 < 2934 && rukou1>=2361)
                                        point.Margin = new Thickness((x - 400) * suofang - 1400, (y - 100) * suofang - 300, 0, 0);
                                    if (rukou1 >= 2934)
                                        point.Margin = new Thickness((x - 400) * suofang - 1400, (y - 100) * suofang - 500, 0, 0);
                                    //

                                   

                                    //
                                    //
                                    subgrid.Children.Add(point);
                                    all_putong_point.Add(point);
                                }
                                catch { }
                               
                            }

                        }

                        foreach (putongpoint point in all_putong_point)
                        {
                            try
                            {

                                double position = double.Parse(point.key);
                                int index1 = MainWindow.Dizhi_Index.IndexOf(position);
                                DataList.Data_Struct data_struct = (DataList.Data_Struct)MainWindow.Real_Data_List[index1];

                                point.weiyi = data_struct.应变量;
                                //point.Set_Warn_is_not();
                                if(point.weiyi<1)
                                {
                                    ScaleTransform transform = new ScaleTransform(1, 1);
                                    point.RenderTransformOrigin = new Point(0.5, 0.5);
                                    point.RenderTransform = transform;
                                    point.Set_Warn_is_not();
                                }

                                if (point.weiyi >= 1 && point.weiyi<=5)
                                {
                                    ScaleTransform transform=new ScaleTransform(point.weiyi,point.weiyi);
                                    point.RenderTransformOrigin=new Point(0.5,0.5);
                                    point.RenderTransform=transform;
                                 
                                    if (point.weiyi >= 2) point.Set_Warn_is();
                                }
                                if(point.weiyi>5)
                                {
                                    ScaleTransform transform = new ScaleTransform(5, 5);
                                    point.RenderTransformOrigin = new Point(0.5, 0.5);
                                    point.RenderTransform = transform;
                                    point.Set_Warn_is();
                                }


                                if (point.key == data_struct.位置.ToString())
                                {
                                    
                                    try
                                    {
                                        point.weiyi = data_struct.位移量;
                                    }
                                    catch { }
                                }
                            }
                            catch { }
                        }

                    }
                }

                catch { }
               
            }

            if (mymode == 1)
            {
                thislist = list;
                subgrid.Children.Clear();
                Image topimage = new Image();
                string path = System.Environment.CurrentDirectory + "\\zhu_tou.png";
                BitmapImage imagetop = new BitmapImage(new Uri(path, UriKind.Absolute));
                topimage.Source = imagetop;
                topimage.Margin = new Thickness(left, 0, 0, 0);
                subgrid.Children.Add(topimage);
                topimage.VerticalAlignment = VerticalAlignment.Top;
                topimage.HorizontalAlignment = HorizontalAlignment.Left;
                topimage.Height = height;


                int shu = thislist.Count;
                int tu_shu = (shu + 1) / 2;
                double my_tu_shu = (double)tu_shu / 2 / 3 + 1;

                int a = (int)Math.Ceiling(my_tu_shu);

                for (int i = 1; i <= a; i++)
                {
                    Image shenimage = new Image();
                    string shenpath = System.Environment.CurrentDirectory + "\\zhu_shen.png";
                    BitmapImage imageshen = new BitmapImage(new Uri(shenpath, UriKind.Absolute));
                    shenimage.Height = height;
                    shenimage.Source = imageshen;
                    shenimage.Margin = new Thickness(left, topimage.Height * i, 0, 0);
                    //shenimage.Width = width;
                    subgrid.Children.Add(shenimage);
                    shenimage.VerticalAlignment = VerticalAlignment.Top;
                    shenimage.HorizontalAlignment = HorizontalAlignment.Left;
                }

                Image dimage = new Image();
                string dipath = System.Environment.CurrentDirectory + "\\zhu_di.png";
                BitmapImage imagedi = new BitmapImage(new Uri(dipath, UriKind.Absolute));
                dimage.Height = height;
                //dimage.Width = width;
                dimage.Source = imagedi;
                dimage.Margin = new Thickness(left, (my_tu_shu + 1) * topimage.Height, 0, 0);
                subgrid.Children.Add(dimage);
                dimage.VerticalAlignment = VerticalAlignment.Top;
                dimage.HorizontalAlignment = HorizontalAlignment.Left;

                subgrid.VerticalAlignment = VerticalAlignment.Top;
                subgrid.HorizontalAlignment = HorizontalAlignment.Left;
               // subgrid.Margin = new Thickness(left, 0, 0, 0);
               // subgrid.Height = (my_tu_shu + 3) * topimage.Height;

                for (int i = 0; i < shu / 2 ; i++)
                {
                    try
                    {
                        DataList.Data_Struct datastruct = (DataList.Data_Struct)thislist[i];
                        Label position = new Label();
                        position.Content = datastruct.位移量.ToString("#0.000") + " mm";
                        position.FontSize = 10;
                        position.Margin = new Thickness(0, topimage.Height + (double)i * ((my_tu_shu - 1) * topimage.Height) / ((double)shu / 2), 0, 0);
                        subgrid.Children.Add(position);
                        position.Foreground = System.Windows.Media.Brushes.White;

                        Label yidong = new Label();
                        yidong.Content = "  ";
                        yidong.FontSize = 10;
                        yidong.Width = datastruct.位移量 * 10;
                        yidong.Height = topimage.Height / 3;
                        yidong.VerticalAlignment = VerticalAlignment.Top;
                        yidong.HorizontalAlignment = HorizontalAlignment.Left;
                        yidong.Margin = new Thickness(140 - yidong.Width, topimage.Height + (double)i * ((my_tu_shu - 1) * topimage.Height) / ((double)shu / 2), 0, 0);
                        
                        // 标尺
                        Label shendu = new Label();
                        shendu.Content = (i * 0.2).ToString() + "m";
                        shendu.VerticalAlignment = VerticalAlignment.Top;
                        shendu.HorizontalAlignment = HorizontalAlignment.Left;
                        shendu.Margin = new Thickness(90 - yidong.Width, topimage.Height + (double)i * ((my_tu_shu - 1) * topimage.Height) / ((double)shu / 2), 0, 0);
                        subgrid.Children.Add(shendu);

                        if (datastruct.位移量 <= 0.5)
                        {
                            yidong.Background = System.Windows.Media.Brushes.Blue;
                        }
                        if (datastruct.位移量 > 0.5 && datastruct.位移量 < 2)
                        {
                            yidong.Background = System.Windows.Media.Brushes.Yellow;
                        }
                        if (datastruct.位移量 >= 2)
                        {
                            yidong.Background = System.Windows.Media.Brushes.Red;
                        }
                        subgrid.Children.Add(yidong);



                        Label position1 = new Label();
                        position1.Content = datastruct.位置.ToString("#0");
                        position1.FontSize = 10;
                        position1.Margin = new Thickness(140, topimage.Height + i * ((my_tu_shu - 1) * topimage.Height) / (shu / 2), 0, 0);
                        subgrid.Children.Add(position1);


                        DataList.Data_Struct datastruct1 = (DataList.Data_Struct)thislist[shu - 1 - i];
                        Label position2 = new Label();
                        position2.Content = datastruct1.位移量.ToString("#0.000") + " mm";
                        position2.FontSize = 10;
                        position2.Margin = new Thickness(width, topimage.Height + (double)i * ((my_tu_shu - 1) * topimage.Height) / ((double)shu / 2), 0, 0);
                        subgrid.Children.Add(position2);
                        position2.Foreground = System.Windows.Media.Brushes.White;

                        Label yidong1 = new Label();
                        yidong1.Content = "  ";
                        yidong1.FontSize = 10;
                        yidong1.Width = datastruct1.位移量 * 10;
                        yidong1.Height = topimage.Height / 3;
                        yidong1.Margin = new Thickness(271, topimage.Height + (double)i * ((my_tu_shu - 1) * topimage.Height) / ((double)shu / 2), 0, 0);
                        yidong1.VerticalAlignment = VerticalAlignment.Top;
                        yidong1.HorizontalAlignment = HorizontalAlignment.Left;
                        if (datastruct1.位移量 <= 0.5)
                        {
                            yidong1.Background = System.Windows.Media.Brushes.Blue;
                        }
                        if (datastruct1.位移量 > 0.5 && datastruct.位移量 < 2)
                        {
                            yidong1.Background = System.Windows.Media.Brushes.Yellow;
                        }
                        if (datastruct1.位移量 >= 2)
                        {
                            yidong1.Background = System.Windows.Media.Brushes.Red;
                        }

                        subgrid.Children.Add(yidong1);

                        Label position3 = new Label();
                        position3.Content = datastruct1.位置.ToString("#0");
                        position3.FontSize = 10;
                        position3.Margin = new Thickness(230, topimage.Height + i * ((my_tu_shu - 1) * topimage.Height) / (shu / 2), 0, 0);
                        subgrid.Children.Add(position3);
                    }
                    catch { }
                }
            }
        }

        private void init()
        {
            int i = 0;
            foreach (string name in mylist)
            {
                //int points_count = 0;
                //int my_count = 0;
                //points_count = (int)(Math.Abs(chukou - rukou) * 5);
                rukou[i] = double.Parse(MainWindow.Point_ini.IniReadValue(name, "rukou"));
                chukou[i] = double.Parse(MainWindow.Point_ini.IniReadValue(name, "chukou"));

                X1[i] = double.Parse(MainWindow.Point_ini.IniReadValue(name, "X1"));
                X2[i] = double.Parse(MainWindow.Point_ini.IniReadValue(name, "X2"));
                Y1[i] = double.Parse(MainWindow.Point_ini.IniReadValue(name, "Y1"));
                Y2[i] = double.Parse(MainWindow.Point_ini.IniReadValue(name, "Y2"));

                offsite_x[i] = double.Parse(MainWindow.Point_ini.IniReadValue(myname, "offsite_x"));
                offsite_y[i] = double.Parse(MainWindow.Point_ini.IniReadValue(myname, "offsite_y"));
                i++;
            }
            //int a = 0;
            // 用画来弄个柱子
            // 头
           // ReSet()
            //if (mymode == 2)
            //{
            //    try
            //    {
            //        all_putong_point.Clear();
            //        //    //int count = int.Parse(MainWindow.Point_ini.IniReadValue(myname, "count"));
            //        //    //ArrayList mylist = new ArrayList();
            //        //    //for (int i = 1; i <= count; i++)
            //        //    //{
            //        //    //    string linename = MainWindow.Point_ini.IniReadValue(myname, "line" + i.ToString());
            //        //    //    mylist.Add(linename);
            //        //    //}
            //        //    //foreach (string name in mylist)
            //        //    //{
            //        //    //    int points_count = 0;

            //        //    //    int my_count = 0;
            //        //    //    double rukou = double.Parse(MainWindow.Point_ini.IniReadValue(name, "rukou"));
            //        //    //    double chukou = double.Parse(MainWindow.Point_ini.IniReadValue(name, "chukou"));
            //        //    //    points_count = (int)(Math.Abs(chukou - rukou) * 5);
            //        //    //    double X1 = double.Parse(MainWindow.Point_ini.IniReadValue(name, "X1"));
            //        //    //    double X2 = double.Parse(MainWindow.Point_ini.IniReadValue(name, "X2"));
            //        //    //    double Y1 = double.Parse(MainWindow.Point_ini.IniReadValue(name, "Y1"));
            //        //    //    double Y2 = double.Parse(MainWindow.Point_ini.IniReadValue(name, "Y2"));

            //        //    //    double offsite_x = double.Parse(MainWindow.Point_ini.IniReadValue(myname, "offsite_x"));
            //        //    //    double offsite_y = double.Parse(MainWindow.Point_ini.IniReadValue(myname, "offsite_y"));


            //        //    //    // 计算过的图片位置
            //        //    //    double x1 = (X1 - offsite_x) * 60;
            //        //    //    double x2 = (X2 - offsite_x) * 60;
            //        //    //    double y1 = (Y1 - offsite_y) * 60;
            //        //    //    double y2 = (Y2 - offsite_y) * 60;


            //        //    //    subgrid.Margin = new Thickness(left, 0, 0, 0);
            //        //    //    subgrid.Width = this.width * 20;
            //        //    //    subgrid.Height = this.height * 40;

            //        //    //    Image line = new Image();
            //        //    //    string path = System.Environment.CurrentDirectory + "\\putongxianlu.png";

            //        //    //    BitmapImage lineimage = new BitmapImage(new Uri(path, UriKind.Absolute));

            //        //    //    line.Source = lineimage;
            //        //    //    line.Width = 10;
            //        //    //    line.Stretch = Stretch.Fill;
            //        //    //    line.Height = Math.Sqrt((x2 - x1)*(x2-x1)+(y2-y1)*(y2-y1))-1;
            //        //    //    line.VerticalAlignment = VerticalAlignment.Top;
            //        //    //    line.HorizontalAlignment = HorizontalAlignment.Left;
            //        //    //    line.Margin = new Thickness((x1 + x2) / 2 - line.Height / 2 -300, (y1 + y2) / 2 - line.Width / 2 - 200, 0, 0);
            //        //    //    subgrid.Children.Add(line);

            //        //    //    double angle = 0;
            //        //    //    if (x1 == x2) angle = 0;
            //        //    //    if (y2 == y1) angle = 90;
            //        //    //    if (x1 != x2 && y1 != y2) angle = 90 - Math.Atan2(y1 - y2, x2 - x1) / 3.14 * 180;

            //        //    //    RotateTransform myrotatetransform = new RotateTransform(angle);
            //        //    //    line.RenderTransformOrigin = new Point(0.5, 0.5);
            //        //    //    line.RenderTransform = myrotatetransform;

            //        //    //    foreach (DataList.Data_Struct item in MainWindow.Real_Data_List)
            //        //    //    {
            //        //    //        if (item.位置 >= rukou && item.位置 <= chukou)
            //        //    //        {
            //        //    //            try
            //        //    //            {
            //        //    //                my_count++;
            //        //    //                double x = (x2 - x1) / points_count * my_count + x1;
            //        //    //                double y = (y2 - y1) / points_count * my_count + y1;
            //        //    //                Label position = new Label();
            //        //    //                position.Content = item.位置.ToString();
            //        //    //                position.Margin = new Thickness(x - 300, y - 230, 0, 0);
            //        //    //                position.FontSize = 5;
            //        //    //                subgrid.Children.Add(position);

            //        //    //                //putongpoint point = new putongpoint(x, y);
            //        //    //                //point.key = item.位置.ToString();
            //        //    //                //point.Width = 2;
            //        //    //                //point.Height = 2;
            //        //    //                //point.Margin = new Thickness((x - 400) * 10 - 800, (y - 100) * 10 - 800, 0, 0);
            //        //    //                //maingrid.Children.Add(point);
            //        //    //                //all_putong_point.Add(point);
            //        //    //            }
            //        //    //            catch { }
            //        //    //        }

            //        //    //    }


            //        //    //}

            //        //    int count = int.Parse(MainWindow.Point_ini.IniReadValue(myname, "count"));
            //        //    ArrayList list = new ArrayList();
            //        //    for (int i = 1; i <= count; i++)
            //        //    {
            //        //        string linename = MainWindow.Point_ini.IniReadValue(myname, "line" + i.ToString());
            //        //        list.Add(linename);
            //        //    }
            //        //    foreach (string name in list)
            //        //    {
            //        //        int points_count = 0;
            //        //        int my_count = 0;
            //        //        double rukou = double.Parse(MainWindow.Point_ini.IniReadValue(name, "rukou"));
            //        //        double chukou = double.Parse(MainWindow.Point_ini.IniReadValue(name, "chukou"));
            //        //        double X1 = double.Parse(MainWindow.Point_ini.IniReadValue(name, "X1"));
            //        //        double X2 = double.Parse(MainWindow.Point_ini.IniReadValue(name, "X2"));
            //        //        double Y1 = double.Parse(MainWindow.Point_ini.IniReadValue(name, "Y1"));
            //        //        double Y2 = double.Parse(MainWindow.Point_ini.IniReadValue(name, "Y2"));
            //        //        points_count = (int)(Math.Abs(chukou - rukou) * 5);
            //        //        foreach (DataList.Data_Struct item in MainWindow.Real_Data_List)
            //        //        {
            //        //            if (item.位置 >= rukou && item.位置 <= chukou)
            //        //            {
            //        //                try
            //        //                {
            //        //                    my_count++;
            //        //                    double x = (X2 - X1) / points_count * my_count + X1;
            //        //                    double y = (Y2 - Y1) / points_count * my_count + Y1;

            //        //                    putongpoint point = new putongpoint(x, y);
            //        //                    point.key = item.位置.ToString();
            //        //                    point.Width = 2;
            //        //                    point.Height = 2;
            //        //                    point.Margin = new Thickness((x - 400) * 10 - 800, (y - 100) * 10 - 800, 0, 0);
            //        //                    maingrid.Children.Add(point);
            //        //                    all_putong_point.Add(point);
            //        //                }
            //        //                catch { }
            //        //            }

            //        //        }

            //        //    }
            //        //}
            //        //catch { }
            //        int shu = thislist.Count;

            //        for (int i = 1; i <= shu; i++)
            //        {
            //            try
            //            {
            //                DataList.Data_Struct datastruct = (DataList.Data_Struct)thislist[i - 1];
            //                Label position = new Label();
            //                position.Content = datastruct.位移量.ToString("#0.000") + " mm";
            //                position.FontSize = 10;
            //                position.Margin = new Thickness(0, i * 20 + 40, 0, 0);
            //                subgrid.Children.Add(position);
            //                position.Foreground = System.Windows.Media.Brushes.White;

            //                Label yidong = new Label();
            //                yidong.Content = "  ";
            //                yidong.FontSize = 10;
            //                yidong.Width = datastruct.位移量 * 10;
            //                // yidong.Height = topimage.Height / 3;
            //                yidong.VerticalAlignment = VerticalAlignment.Top;
            //                yidong.HorizontalAlignment = HorizontalAlignment.Left;
            //                yidong.Margin = new Thickness(140 - yidong.Width, i * 20 + 40, 0, 0);
            //                if (datastruct.位移量 <= 0.5)
            //                {
            //                    yidong.Background = System.Windows.Media.Brushes.Blue;
            //                }
            //                if (datastruct.位移量 > 0.5 && datastruct.位移量 < 2)
            //                {
            //                    yidong.Background = System.Windows.Media.Brushes.Yellow;
            //                }
            //                if (datastruct.位移量 >= 2)
            //                {
            //                    yidong.Background = System.Windows.Media.Brushes.Red;
            //                }
            //                subgrid.Children.Add(yidong);



            //                Label position1 = new Label();
            //                position1.Content = datastruct.位置.ToString("#0");
            //                position1.FontSize = 10;
            //                position1.VerticalAlignment = VerticalAlignment.Top;
            //                position1.HorizontalAlignment = HorizontalAlignment.Left;
            //                position1.Margin = new Thickness(150, i * 20 + 40, 0, 0);

            //                subgrid.Children.Add(position1);

            //                subgrid.VerticalAlignment = VerticalAlignment.Top;
            //                subgrid.HorizontalAlignment = HorizontalAlignment.Left;
            //                subgrid.Margin = new Thickness(left, 0, 0, 0);
            //                subgrid.Height = (shu) * position1.Height;
            //            }
            //            catch { }
            //        }
            //    }


            //    catch { }
            //}

        //    if (mymode == 1)
        //    {
        //        Image topimage = new Image();
        //        string path = System.Environment.CurrentDirectory + "\\zhu_tou.png";
        //        BitmapImage imagetop = new BitmapImage(new Uri(path, UriKind.Absolute));
        //        topimage.Source = imagetop;
        //        topimage.Margin = new Thickness(left, 0, 0, 0);
        //        subgrid.Children.Add(topimage);
        //        topimage.VerticalAlignment = VerticalAlignment.Top;
        //        topimage.HorizontalAlignment = HorizontalAlignment.Left;
        //        topimage.Height = height;


        //        int shu = thislist.Count;
        //        int tu_shu = (shu + 1) / 2;
        //        double my_tu_shu = (double)tu_shu / 2 / 3 + 1;

        //        int a = (int)Math.Ceiling(my_tu_shu);

        //        for (int i = 1; i <= a; i++)
        //        {
        //            Image shenimage = new Image();
        //            string shenpath = System.Environment.CurrentDirectory + "\\zhu_shen.png";
        //            BitmapImage imageshen = new BitmapImage(new Uri(shenpath, UriKind.Absolute));
        //            shenimage.Height = height;
        //            shenimage.Source = imageshen;
        //            shenimage.Margin = new Thickness(left, topimage.Height * i, 0, 0);
        //            //    shenimage.Width = width;
        //            subgrid.Children.Add(shenimage);
        //            shenimage.VerticalAlignment = VerticalAlignment.Top;
        //            shenimage.HorizontalAlignment = HorizontalAlignment.Left;
        //        }

        //        Image dimage = new Image();
        //        string dipath = System.Environment.CurrentDirectory + "\\zhu_di.png";
        //        BitmapImage imagedi = new BitmapImage(new Uri(dipath, UriKind.Absolute));
        //        dimage.Height = height;
        //        //dimage.Width = width;
        //        dimage.Source = imagedi;
        //        dimage.Margin = new Thickness(left, (my_tu_shu + 1) * topimage.Height, 0, 0);
        //        subgrid.Children.Add(dimage);
        //        dimage.VerticalAlignment = VerticalAlignment.Top;
        //        dimage.HorizontalAlignment = HorizontalAlignment.Left;

        //        subgrid.VerticalAlignment = VerticalAlignment.Top;
        //        subgrid.HorizontalAlignment = HorizontalAlignment.Left;
        //        subgrid.Margin = new Thickness(left, 0, 0, 0);
        //        subgrid.Height = (my_tu_shu + 3) * topimage.Height;

        //        for (int i = 0; i < shu / 2 + 3; i++)
        //        {
        //            try
        //            {
        //                DataList.Data_Struct datastruct = (DataList.Data_Struct)thislist[i];
        //                Label position = new Label();
        //                position.Content = datastruct.位移量.ToString("#0.000") + " mm";
        //                position.FontSize = 10;
        //                position.Margin = new Thickness(0, topimage.Height + (double)i * ((my_tu_shu - 1) * topimage.Height) / ((double)shu / 2), 0, 0);
        //                subgrid.Children.Add(position);
        //                position.Foreground = System.Windows.Media.Brushes.White;

        //                Label yidong = new Label();
        //                yidong.Content = "  ";
        //                yidong.FontSize = 10;
        //                yidong.Width = datastruct.位移量 * 10;
        //                yidong.Height = topimage.Height / 3;
        //                yidong.VerticalAlignment = VerticalAlignment.Top;
        //                yidong.HorizontalAlignment = HorizontalAlignment.Left;
        //                yidong.Margin = new Thickness(140 - yidong.Width, topimage.Height + (double)i * ((my_tu_shu - 1) * topimage.Height) / ((double)shu / 2), 0, 0);
        //                if (datastruct.位移量 <= 0.5)
        //                {
        //                    yidong.Background = System.Windows.Media.Brushes.Blue;
        //                }
        //                if (datastruct.位移量 > 0.5 && datastruct.位移量 < 2)
        //                {
        //                    yidong.Background = System.Windows.Media.Brushes.Yellow;
        //                }
        //                if (datastruct.位移量 >= 2)
        //                {
        //                    yidong.Background = System.Windows.Media.Brushes.Red;
        //                }
        //                subgrid.Children.Add(yidong);



        //                Label position1 = new Label();
        //                position1.Content = datastruct.位置.ToString("#0");
        //                position1.FontSize = 10;
        //                position1.Margin = new Thickness(150, topimage.Height + i * ((my_tu_shu - 1) * topimage.Height) / (shu / 2), 0, 0);
        //                subgrid.Children.Add(position1);


        //                DataList.Data_Struct datastruct1 = (DataList.Data_Struct)thislist[shu - 1 - i];
        //                Label position2 = new Label();
        //                position2.Content = datastruct1.位移量.ToString("#0.000") + " mm";
        //                position2.FontSize = 10;
        //                position2.Margin = new Thickness(width, topimage.Height + (double)i * ((my_tu_shu - 1) * topimage.Height) / ((double)shu / 2), 0, 0);
        //                subgrid.Children.Add(position2);
        //                position2.Foreground = System.Windows.Media.Brushes.White;

        //                Label yidong1 = new Label();
        //                yidong1.Content = "  ";
        //                yidong1.FontSize = 10;
        //                yidong1.Width = datastruct1.位移量 * 10;
        //                yidong1.Height = topimage.Height / 3;
        //                yidong1.Margin = new Thickness(271, topimage.Height + (double)i * ((my_tu_shu - 1) * topimage.Height) / ((double)shu / 2), 0, 0);
        //                yidong1.VerticalAlignment = VerticalAlignment.Top;
        //                yidong1.HorizontalAlignment = HorizontalAlignment.Left;
        //                if (datastruct1.位移量 <= 0.5)
        //                {
        //                    yidong1.Background = System.Windows.Media.Brushes.Blue;
        //                }
        //                if (datastruct1.位移量 > 0.5 && datastruct.位移量 < 2)
        //                {
        //                    yidong1.Background = System.Windows.Media.Brushes.Yellow;
        //                }
        //                if (datastruct1.位移量 >= 2)
        //                {
        //                    yidong1.Background = System.Windows.Media.Brushes.Red;
        //                }

        //                subgrid.Children.Add(yidong1);

        //                Label position3 = new Label();
        //                position3.Content = datastruct1.位置.ToString("#0");
        //                position3.FontSize = 10;
        //                position3.Margin = new Thickness(230, topimage.Height + i * ((my_tu_shu - 1) * topimage.Height) / (shu / 2), 0, 0);
        //                subgrid.Children.Add(position3);
        //            }
        //            catch { }

        //        }



        //    }

            
        }

        private void subgrid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (mymode == 2)
            {
                double oldsuofang = suofang;
                if (e.Delta > 0)
                {
                    suofang = suofang + 1;

                    if (suofang >= 20)
                        suofang = 20;
                }
                else if (e.Delta < 0)
                {
                    suofang = suofang - 1;
                    if (suofang <= 1) suofang = 1;
                }



                ReSet(all_putong_point);



                //foreach (putongpoint point in all_putong_point)
                //{
                //    double left = 0;
                //    double top = 0;
                //    if (point.Margin.Left < e.GetPosition(subgrid).X)
                //    {
                //        left = point.Margin.Left - point.Margin.Left / 100 * e.Delta;
                //    }
                //    if (point.Margin.Left > e.GetPosition(subgrid).X)
                //    {
                //        left = point.Margin.Left + point.Margin.Left / 100 * e.Delta;
                //    }
                //    if (point.Margin.Top < e.GetPosition(subgrid).Y)
                //    {
                //        top = point.Margin.Top - point.Margin.Top / 100 * e.Delta;
                //    }
                //    if (point.Margin.Left > e.GetPosition(subgrid).X)
                //    {
                //        top = point.Margin.Top + point.Margin.Top / 100 * e.Delta;
                //    }

                //    point.Margin = new Thickness(left, top, 0, 0);
                //}
            }
        }

        private void ReSet_Suofang(double mysuofang)
        {
            
        }

        private void scrollviewer1_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            
        }

        double pre_pos_x = 0;
        double pre_pos_y = 0;

        private void subgrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
                Press = true;
                pre_pos_x = e.GetPosition(subgrid).X;
                pre_pos_y = e.GetPosition(subgrid).Y;
        }

        private void subgrid_MouseLeave(object sender, MouseEventArgs e)
        {
            Press = false;
        }

        double now_pos_x = 0;
        double now_pos_y = 0;
        private void subgrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (Press == true)
            {
                now_pos_x = e.GetPosition(subgrid).X;
                now_pos_y = e.GetPosition(subgrid).Y;

                double move_x = now_pos_x - pre_pos_x;
                double move_y = now_pos_y - pre_pos_y;

                // 移动图片

                subgrid.Margin = new Thickness(subgrid.Margin.Left + move_x, subgrid.Margin.Top + move_y, 0, 0);
            }
        }

        private void subgrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Press = false;
        }
    }
}
