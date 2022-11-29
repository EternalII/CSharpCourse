using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;

namespace Ex01_02
{

    class SimpleDaimond
    {
       
        public static void PrintStarPattern(int N)
        {
            PrintPatternInternal(1, N, 2);
            PrintPatternInternal(N - 2, N, -2);
        }

        public static void PrintPatternInternal(int k, int N, int delta)
        {
            if (k < 1 || k > N)
            {
                return;
            }

            PrintLine(k, N);
            PrintPatternInternal(k + delta, N, delta);
        }

        public static void Print(int n, char c)
        {
            if (n < 0)
            {
                throw new ArgumentException();
            }

            for (int i = 1; i <= n; i++)
            {
                Console.Write(c);
            }
        }

        public static void PrintLine(int k, int N)
        {
            Print((N - k) / 2, ' ');
            Print(k, '*');
            Console.WriteLine();
        }

        public static void Main()
        {
            PrintStarPattern(9);
        }
    }
}








//public static int Main()
//{
//    int row, i, j, k;
//    row = 9;
//    upperPartOfDiamond(row, 0); // print uper part of triangle
//    lowerPartOfDiamond(row, 1);// print lower part of diamond
//    return 0;
//}

//static void moveTonextLine(int k, int i, int z)
//{
//    if (k == i)// Base case
//        return;
//    Console.WriteLine("* ");
//    moveTonextLine(k + z, i, z);
//}
//static void addSpaceInDiamond(int row, int i, int z) // print space of diamond
//{
//    if (row == i)
//        return;
//    Console.WriteLine(" ");
//    addSpaceInDiamond(row + z, i, z); // send recursive call
//}
//static void upperPartOfDiamond(int row, int i)
//{
//    if (i > row)// Base case
//        return;
//    addSpaceInDiamond(row, i, -1);
//    moveTonextLine(0, i, 1);
//    Console.WriteLine();
//    upperPartOfDiamond(row, i + 1);// send recursive call
//}
//static void lowerPartOfDiamond(int row, int i)// print next line of diamond
//{
//    if (i > row) // Base case
//        return;
//    addSpaceInDiamond(0, i, 1);
//    moveTonextLine(row, i, -1);
//    //Console.WriteLine();
//    lowerPartOfDiamond(row, i + 1); // send recursive call

//}