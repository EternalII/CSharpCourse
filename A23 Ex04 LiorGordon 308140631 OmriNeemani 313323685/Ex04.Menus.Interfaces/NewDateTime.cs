using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    class NewDateTime : GeneralMenu
    {
        protected override List<string> options { get; set; } = new List<string>() { };

        public NewDateTime()
        {
            Console.Clear();
            Console.WriteLine("**[Interface] Show Date/Time**");
            AddOption("Show Date");
            AddOption("Show Time");
            AddOption("Return");
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
                    break;
                case "Exit":
                    break;
                default:
                    Console.WriteLine("Option not implemented yet.");
                    break;
            }
        }
    }
}
