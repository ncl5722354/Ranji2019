using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace YinRan2020
{
    public class Device_Data
    {
        // 一车间数据
        public static int[,] chejian1_com1_DT = new int[100, 65535];
       

        public static bool[,] chejian1_com1_R = new bool[100, 65535];

        public static int[,] chejian1_com1_jicun = new int[100, 65535];

        // 二车间数据
        public static int[,] chejian2_com1_DT = new int[100, 65535];
        public static int[,] chejian2_com2_DT = new int[100, 65535];
        public static int[,] chejian2_com3_DT = new int[100, 65535];
        public static int[,] chejian2_com4_DT = new int[100, 65535];
        public static int[,] chejian2_com5_DT = new int[100, 65535];
        public static int[,] chejian2_com6_DT = new int[100, 65535];

        public static bool[,] chejian2_com1_R = new bool[100, 65535];
        public static bool[,] chejian2_com2_R = new bool[100, 65535];
        public static bool[,] chejian2_com3_R = new bool[100, 65535];
        public static bool[,] chejian2_com4_R = new bool[100, 65535];
        public static bool[,] chejian2_com5_R = new bool[100, 65535];
        public static bool[,] chejian2_com6_R = new bool[100, 65535];

        // 三车间数据
        public static int[,] chejian3_com1_DT = new int[100, 65535];
        

        public static bool[,] chejian3_com1_R = new bool[100, 65535];


        public static int[,] chejian3_com1_jicun = new int[100, 65535];

    }
}
