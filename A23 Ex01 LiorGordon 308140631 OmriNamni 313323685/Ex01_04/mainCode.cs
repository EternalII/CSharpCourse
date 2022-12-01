using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_04
{
    class mainCode
    {
        public static void Main()
        {
            int charType = -1;
            stringAnalysis sAnalize = new stringAnalysis(); // must be either only numbers or letters, not mixed.
            string userInput;

            userInput = sAnalize.getInput(out int stringType); //type 1 is char, type 2 is number
            charType = sAnalize.validate(userInput);

            //Console.WriteLine($"\n string type is {stringType}"); // for testing the string type in getInput return

            sAnalize.isPalindrome(userInput);
            if (charType == 2)
                sAnalize.isDividedByThree(userInput);
            if (charType == 1)
                sAnalize.howManyCapitalized(userInput);
        }
    }

    class stringAnalysis
    {
        public string getInput(out int type)
        {
            int flag = -1; // flag for validity. -1 false input, 1 is char, 2 is number

            System.Console.WriteLine("Enter 6 letters or numbers: ");
            string userInput = System.Console.ReadLine();
            while (flag == -1)
            {
                flag = validate(userInput);
                if (flag == -1)
                {
                    Console.WriteLine("Bad input, please try again. \n");
                    System.Console.WriteLine("Enter 6 letters or numbers: ");
                    userInput = System.Console.ReadLine();
                }
            }
            Console.WriteLine("\n");

            type = flag;
            return userInput;
        }

        public int validate(string s) // return -1 if invalid input, return 1 if char, return 2 if number
        {
            int length = s.Length;
            bool isNum = false; //checks if first char is a number or a letter

            if (string.IsNullOrEmpty(s))
                return -1;

            isNum = char.IsDigit(s[0]);
            if (isNum == false)
            {
                isNum = char.IsLetter(s[0]); // flag temporary checks if letter
                if (isNum == false) // not a letter, fail
                    return -1; // neither valid character or number
                isNum = false; // passes check, is letter
            }


            if (length == 6)
                if (isNum == false) // checks that's all are letters
                {
                    foreach (char letter in s)
                    {
                        if (!char.IsLetter(letter))
                            return -1;
                    }
                    return 1;
                }
                else
                    {
                        foreach (char letter in s)
                        {
                            if (!char.IsNumber(letter))
                                return -1;
                        }
                    return 2;
                }


            return -1; // wrong length
        }


        public bool isPalindrome(string userInput)
        {
            char[] ch = userInput.ToCharArray();
            Array.Reverse(ch);
            string rev = new string(ch);

            bool isPol = userInput.Equals(rev, StringComparison.OrdinalIgnoreCase);


            if (isPol == true) // Checking whether string is palindrome or not  
            {
                //Console.WriteLine("String is Palindrome \n Entered String Was {0} and reverse string is {1}", userInput, rev);
                Console.WriteLine("Input is a Palindrome.\n");
            }
            else
            {
                //Console.WriteLine("String is not Palindrome \n Entered String Was {0} and reverse string is {1}", userInput, rev);
                Console.WriteLine("Input is NOT a Palindrome.\n");
            }

            return isPol;
        }

        public bool isDividedByThree(string userInput)
        {
            int inputAsInt = -1;

            try
            {
                inputAsInt = Int32.Parse(userInput);
                //Console.WriteLine(intBins);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{userInput}'\n");
            }

            if (inputAsInt % 3 == 0)
            {
                Console.WriteLine("Input is divisable by 3.\n");
                return true;
            }

            Console.WriteLine("Input is NOT divisable by 3.\n");
            return false;
        }

        public int howManyCapitalized(string userInput)
        {
            int countCapitalized = 0;
            foreach (char c in userInput){
                if (Char.IsUpper(c))
                    countCapitalized++;
            }

            Console.WriteLine($"There are {countCapitalized} upper case characters.\n");
            return countCapitalized;
        }
    }
}
