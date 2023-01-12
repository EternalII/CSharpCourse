using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    public class MethodsPart
    {
        public void ShowDate()
        {
            Console.WriteLine(DateTime.Now.ToShortDateString());
        }

        public void ShowTime()
        {
            Console.WriteLine(DateTime.Now.ToShortTimeString());
        }

        public void ShowVersion()
        {
            Console.WriteLine("Version: 23.1.4.8859");
        }

        public void CountUppercase()
        {
            string userSentence;
            int uppercaseCounter = 0;

            Console.WriteLine("Please enter a sentence: ");
            userSentence = Console.ReadLine();

            while (userSentence == string.Empty)
            {
                Console.WriteLine("Illegal input. Try again.");
                userSentence = Console.ReadLine();
            }

            foreach (char letter in userSentence)
            {
                if (letter >= 'A' && letter <= 'Z')
                {
                    uppercaseCounter++;
                }
            }

            Console.WriteLine(string.Format(
                 "The sentence: \"{0}\" contains {1} uppercase letters.",
                 userSentence,
                 uppercaseCounter));
        }
    }
}