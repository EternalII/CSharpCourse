using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    class Console
    {
        public static void Main()
        {

        }
    }

    class RegisterVehicle
    {
        public string enterLicense()
        {
            System.Console.WriteLine("To enter vehicle into garage, please enter license number:");
            string license = System.Console.ReadLine();

            return license;
        }
    }
}
