using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Ex01_02
{

    public class Program
    {
       
        public static void PrintStarPattern(int io_LongestLine)
        {
            PrintPatternInternal(1, io_LongestLine, 2);
            PrintPatternInternal(io_LongestLine - 2, io_LongestLine, -2);
        }

        public static void PrintPatternInternal(int io_AsteriskOrSpace, int io_LongestLine, int delta)
        {
            if (io_AsteriskOrSpace < 1 || io_AsteriskOrSpace > io_LongestLine)
            {
                return;
            }

            PrintLine(io_AsteriskOrSpace, io_LongestLine);
            PrintPatternInternal(io_AsteriskOrSpace + delta, io_LongestLine, delta);
        }

        public static void Print(int io_AsteriskOrSpace, char c)
        {
            if (io_AsteriskOrSpace < 0)
            {
                throw new ArgumentException();
            }

            for (int i = 1; i <= io_AsteriskOrSpace; i++)
            {
                Console.Write(c);
            }
        }

     

        public static void PrintLine(int io_AsteriskOrSpace, int io_LongestLine)
        {
            Print((io_LongestLine - io_AsteriskOrSpace) / 2, ' ');
            Print(io_AsteriskOrSpace, '*');
            Console.WriteLine();
        }

        public static void Main()
        {
            PrintStarPattern(9);
        }
    }
}

