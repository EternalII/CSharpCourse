using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;

namespace Ex01_01
{
    class BinaryToDec
    {
        public static void Main()
        {
            Conversion convert = new Conversion();
            bool validity = false; // checks if user input is valid, entering 8 bits with 0 and 1
            int timesInput = 0;
            string[] charBins = { "0", "0", "0" }; // saved values in char format
            int[] intBins = { 0, 0, 0 }, dec = { 0, 0, 0 }; // saved values in int format bot binary and dec

            //convert.test(); used examples from homework for private testing

            while (timesInput < 3)
            {
                System.Console.WriteLine("Enter 8 bits three times, enter each time:");
                string inputBinary = System.Console.ReadLine();
                validity = convert.checkBin(inputBinary);
                Console.Write($"Validity : {validity} \n");
                if (validity == true)
                {
                    charBins[timesInput] = inputBinary;
                    timesInput++;
                }
                else
                {
                    System.Console.WriteLine("Invalid input, please try again! \n");
                }
            }

            timesInput = 0; // restart count
            while (timesInput < 3) // go through all saved inputs
            {
                intBins[timesInput] = convert.convToInt(charBins[timesInput]); // convers to type int
                dec[timesInput] = convert.convToDec(intBins[timesInput]); // convers int bin to dec
                timesInput++;
            }

            convert.sortHighToLow(ref dec); // sorts it from highest to lowest

            foreach (int num in dec){
                Console.Write($"Decimal Value : {num} \n"); // print the binaries in dec values
            }


            convert.countDigitRepetition(charBins, out float refAvgZ, out float refAvgO);
            int countDivFour = convert.howManyDivideByFour(dec);
            int countDSet = convert.howManyDecreasingSet(dec);
            int countPol = convert.howManyPolindrom(dec);

            Console.Write($"Average number of zeroes : {refAvgZ} \n");
            Console.Write($"Average number of ones : {refAvgO} \n");
            Console.Write($"Amount of numbers divided by four : {countDivFour} \n");
            Console.Write($"Amount of numbers in a decreasing set : {countDSet} \n");
            Console.Write($"Amount of numbers that are polindroms : {countPol} \n");
        }

    }

    class Conversion
    {
        public int convToInt(string bins)
        {
            int intBins = 0;
            try
            {
                intBins = Int32.Parse(bins);
                //Console.WriteLine(intBins);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{bins}'\n");
            }

            return intBins;
        }

        public int convToDec(int intBins)
        {
            int decimalValue = Convert.ToInt32(intBins.ToString(), 2);

            return decimalValue;
        }
        public bool checkBin(string inputBins)
        {
            int length = inputBins.Length;

            if (length != 8) // checks the lengths is 8 digits
            {
                return false;
            }
            else
            {
                foreach (var digit in inputBins)
                {
                    if (digit != '0' && digit != '1') // fails if no binary values, and later counts 1s and 0s for average
                        return false;
                }
                return true;
            }
        }

        public void countDigitRepetition(string[] charBins, out float averageZeroes, out float averageOnes)
        {
            int countZeroes = 0;
            int countOnes = 0;
            int totalDigits = 0;
            averageZeroes = -1; 
            averageOnes = -1;

            foreach (string arr in charBins)
            {
                foreach (var digit in arr)
                {
                    if (digit == '0')
                        countZeroes++;
                    else if (digit == '1')
                        countOnes++;
                    totalDigits++;
                }
            }

            averageZeroes = (float) countZeroes / totalDigits;
            averageOnes = (float) countOnes / totalDigits;
        }

        public void sortHighToLow(ref int[] arr)
        {
            Array.Sort(arr);
            Array.Reverse(arr);
        }

        public int howManyDivideByFour(int[] dec)
        {
            int count = 0;

            foreach (int num in dec)
            {
                if (num % 4 == 0)
                    count++;
            }
            return count;
        }
        
        public int howManyDecreasingSet(int[] dec)
        {
            int count = 0;
            int first = 0, second = 0;
            int flag = 1; // flag to count if decreasing set or not. The moment something is not decreasing, it switches to 0

            foreach (int num in dec)
            {
                flag = 1; // reset flag
                int temp = num;
                while (temp/10 != 0) {
                    first = temp % 10;
                    temp /= 10;
                    second = temp % 10;
                    if (first > second)
                        flag = 0;
                }
                if (flag == 1)
                    count++;
            }
            return count;
        }

        public int howManyPolindrom(int[] dec)
        {
            int count = 0;

            foreach (int num in dec)
            {
                int rem = 0, sum = 0, temp = 0;

                temp = num;
                while (temp > 0) {
                    rem = temp % 10;
                    temp = temp / 10;
                    sum = sum * 10 + rem; // gets reversed number
                }
                if (num == sum)
                    count++;
            }

            return count;
        }

        internal void test()
        {
            Conversion conv = new Conversion();
            int[] dec = { 64, 123, 121 };
            int countPol = conv.howManyPolindrom(dec);
            int countDec = conv.howManyDecreasingSet(dec);
            int countDivFour = conv.howManyDivideByFour(dec);

            Console.Write($"Test Pol: '{countPol}'\n");
            Console.Write($"Test Dec: '{countDec}'\n");
            Console.Write($"Test Div: '{countDivFour}'\n");
        }
    }
}
