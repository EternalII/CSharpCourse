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
            Conversion c = new Conversion();
            bool validity = false; // checks if user input is valid, entering 8 bits with 0 and 1
            int timesInput = 0;
            string[] stingBins = { "0", "0", "0" };
            int[] intBins = { 0, 0, 0 };

            while (timesInput < 3)
            {
                System.Console.WriteLine("Enter 8 bits three times, enter each time:");
                string inputBinary = System.Console.ReadLine();
                validity = c.checkBin(inputBinary);
                Console.Write($"Validity : {validity} \n");
                if (validity == true) {
                    stingBins[timesInput] = inputBinary;
                    timesInput++; 
                }
                else { System.Console.WriteLine("Invalid input, please try again! \n"); }
            }

            timesInput = 0; // restart count
            while (timesInput < 3) // go through all saved inputs
            {
                intBins[timesInput] = c.convToInt(stingBins[timesInput]);
                int dec = c.convToDec(intBins[timesInput]);
                Console.Write($"Decimal Value : {dec} \n");
                timesInput++;
            }
            
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

            if (length != 8)
            {
                return false;
            }
            else
            {
                foreach (var digit in inputBins)
                    if (digit != '0' && digit != '1')
                        return false;
            }

            return true;
        }
    }
}
