using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_05
{
    class Ex05
    {
        public static void main()
        {
            
            
        }

    }
     

    class numStatistics
    {
        public int getUserInput()
        {

            string readLine;
            int userInput = -1;

            Console.WriteLine("Please enter 6 digits: \n");
            readLine = Console.ReadLine();
            userInput = Convert.ToInt32(readLine);
            Console.WriteLine($"userInput\n");
            return userInput;
        }

    }
}
