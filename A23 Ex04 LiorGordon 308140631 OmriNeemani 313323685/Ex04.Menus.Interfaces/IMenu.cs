using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public interface IMenu
    {
        void Display();
        void AddOption(string option);
        void RemoveOption(string option);
        void SelectOption(int option);
    }

    abstract public class GeneralMenu : IMenu
    {
        protected abstract List<string> options { get; set; }

        public void Display()
        {
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, options[i]);
            }
            Console.WriteLine("Please select an option:");
        }

        public void AddOption(string option)
        {
            options.Add(option);
        }
        public void RemoveOption(string option)
        {
            if (options.Contains(option))
            {
                options.Remove(option);
                Console.WriteLine("{0] has been removed from the menu.", option);
            }
            else
            {
                Console.WriteLine("{0} does not exist in the menu.", option);
            }
        }

        public void SelectOption(int optionNumber)
        {
            string option = "0";
            try
            {
                option = options[optionNumber]; // option number becomes option string name
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }

            if (options.Contains(option))
            {
                TriggerMenu(option);
            }
            else
            {
                Console.WriteLine("Invalid option selected. Please try again.");
            }
        }

        public abstract void TriggerMenu(string option);

        public string RequestOption()
        {
            int optionNumber = 1;
            string option = null;
            bool isParsable;

            while ((optionNumber-1 != options.IndexOf("Exit")) && (optionNumber - 1 != options.IndexOf("Return")))
            {
                option = Console.ReadLine();
                isParsable = Int32.TryParse(option, out optionNumber);
                if (isParsable)
                {
                    SelectOption(optionNumber - 1);
                }
                else
                {
                    Console.WriteLine("Failed to parse user input.");
                    return null;
                }
            }

            return option;
        }
    }

    public class MainMenu : GeneralMenu
    {
        protected override List<string> options { get; set; } = new List<string>() { };

        public MainMenu()
        {
            Console.Clear();
            Console.WriteLine("**[Interface] Main Menu**");
            AddOption("Version and Uppercase");
            AddOption("Show Date/Time");
            AddOption("Exit");
            Display();
            RequestOption();
        }

        override public void TriggerMenu(string option)
        {
            IMenu optionMenu;

            switch (option)
            {
                case "Version and Uppercase":
                    optionMenu = new VersionAndUppercase();
                    break;
                case "Show Date/Time":
                    optionMenu = new NewDateTime();
                    break;
                case "Exit":
                    break;
                default:
                    Console.WriteLine("Option not implemented yet.");
                    break;
            }
            Console.Clear();
            Display();
        }
    }
}
