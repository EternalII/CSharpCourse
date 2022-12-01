using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_03
{
    public class Program
    {
        public static void Main()
        {

            DrawDiamondForBeginners();
        }

        public static void DrawDiamondForBeginners()
        {
            string strHightOfDiamond;
            int hightOfDiamond;

            Console.WriteLine("Enter a number for Diamond height : ");
            strHightOfDiamond = Console.ReadLine();
            hightOfDiamond = IsValidInput(strHightOfDiamond);
            if (hightOfDiamond % 2 == 1)
            {
                hightOfDiamond++;
            }

          Ex01_02.Program.PrintStarPattern(9);
        }

        public static int IsValidInput(string i_StringInput)
        {
            bool isNotValid = true;

            while (isNotValid)
            {
                for (int i = 0; i < i_StringInput.Length; i++)
                {
                    if (!(Char.IsDigit(i_StringInput[i])))
                    {
                        i = 0;
                        Console.WriteLine("The input is invalid! Please enter a valid number : ");
                        i_StringInput = Console.ReadLine();
                    }
                }

                if (int.Parse(i_StringInput) < 0)
                {
                    Console.WriteLine("The input is invalid! Please enter a valid number : ");
                    i_StringInput = Console.ReadLine();
                }
                else
                {
                    isNotValid = false;
                }
            }

            return int.Parse(i_StringInput); ;
        }
    }
}
