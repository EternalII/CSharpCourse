using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class VersionAndUppercase : GeneralMenu
    {
        protected override List<string> options { get; set; } = new List<string>() { };

        public VersionAndUppercase()
        {
            Console.Clear();
            Console.WriteLine("**[Interface] Version And Uppercase**");
            AddOption("Show Version");
            AddOption("Count Uppercase");
            AddOption("Return");
            Display();
            RequestOption();
        }

        override public void TriggerMenu(string option)
        {
            object triggerOption;

            switch (option)
            {
                case "Show Version":
                    triggerOption = new ShowVersion();
                    break;
                case "Count Uppercase":
                    triggerOption = new CountUppercase();
                    break;
                case "Return":
                    break;
                default:
                    Console.WriteLine("Option not implemented yet.");
                    break;
            }
            Console.Clear();
            Display();
        }
    }


    public class ShowVersion
    {
        public ShowVersion()
        {
            printVersion();
            Console.WriteLine("Press any key to move back to the menu");
            Console.ReadKey();
        }
        private void printVersion()
        {
            Console.WriteLine("Version: 23.1.4.8859");
        }
    }

    public class CountUppercase
    {
        public CountUppercase()
        {
            Console.WriteLine("Write any text, and the program will count how many uppercases there are in it.");
            int upperCount = getInputGetCount();
            Console.WriteLine("There are {0} UpperCases", upperCount);

            Console.WriteLine("Press any key to move back to the menu");
            Console.ReadKey();
        }

        private int getInputGetCount()
        {
            string input = Console.ReadLine();
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsUpper(input[i])) count++;
            }

            return count;
        }
    }
}
