using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_05
{
    class Ex05
    {
        public static void Main()
        {
            int number = 0;
            numStatistics stats = new numStatistics();
            
            number = stats.getUserInput();
            //stats.biggetThanFirst(number);
            //stats.smallest(number);
            //stats.digitDivThree(number);
            //stats.averageDigits(number);
        }

    }
     

    class numStatistics
    {
        public int getUserInput()
        {

            string readLine;
            int userInput = -1, countChars = 0;

            TryInputAgain:
            Console.WriteLine("Please enter 6 digits: \n");
            readLine = Console.ReadLine();
            
            try
            {
                userInput = Convert.ToInt32(readLine);
            }
            catch(Exception)
            {
                Console.WriteLine("Invalid input, please try again\n");
                goto TryInputAgain;
            }

            foreach (int num in readLine)
            {
                countChars++;
            }

            return userInput;
        }

    }
}
