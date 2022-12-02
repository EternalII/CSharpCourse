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
            stats.biggetThanFirst(number);
            stats.smallest(number);
            stats.digitDivThree(number);
            stats.averageDigits(number);
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
            
            if (readLine.Length != 6)
            {
                Console.WriteLine("Invalid input, please try again\n");
                goto TryInputAgain;
            }    
            
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

        public int biggetThanFirst(int number) // works only for 6 digits
        {
            string stringNum = Convert.ToString(number);
            int flagFirstDigit = 0, biggerThanFirst = 0;
            char firstDigit = '0';
            
            foreach (char digit in stringNum)
            {
                if (flagFirstDigit == 0)
                {
                    firstDigit = digit;
                    flagFirstDigit++;
                }
                else
                {
                    if (firstDigit < digit)
                        biggerThanFirst++;
                }
            }

            Console.WriteLine($"There are {biggerThanFirst} digits that are bigger than the first one.");
            return biggerThanFirst;
        }

        public int smallest(int number)
        {
            int temp = number, smallest = number % 10, count = 0;

            while (count < 6)
            {
                if (smallest > temp % 10)
                {
                    smallest = temp % 10;
                }
                temp = temp / 10;
                count++;
            }
            Console.WriteLine($"The smallest digit in the number is {smallest}");
            return smallest;
        }
        
        public int digitDivThree(int number)
        {
            int temp = number, digit = number % 10, count = 0 ;
            int divByThree = 0;

            while (count < 6)
            {
                if (digit%3 == 0)
                {
                    divByThree++;
                }
                temp = temp / 10;
                digit = temp % 10;
                count++;
            }

            Console.WriteLine($"There are {divByThree} digits that can be divided by 3");
            return divByThree;
        }

        public int averageDigits(int number)
        {
            int temp = number, sum = number % 10, sizeNum = 6, count = 0 ;
            int average = 0;

            while (count < 6)
            {
                temp = temp / 10;
                sum = sum + temp % 10;
                count++;
            }

            average = sum / sizeNum;

            Console.WriteLine($"Average number for sum of all digits is {average}");
            return average;
        }
    }

}
