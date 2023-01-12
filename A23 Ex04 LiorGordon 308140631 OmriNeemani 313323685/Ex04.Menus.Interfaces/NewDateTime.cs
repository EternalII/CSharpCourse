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
            menuName = "Show Date/Time";
            Console.Clear();
            //Console.WriteLine("**[Interface] Show Date/Time**");
            AddOption("Show Date");
            AddOption("Show Time");
            AddOption("Return");
            Display();
            RequestOption();
        }

        override public void TriggerMenu(string option)
        {
            object triggerOption;

            switch (option)
            {
                case "Show Date":
                    triggerOption = new ShowDate();
                    break;
                case "Show Time":
                    triggerOption = new ShowTime();
                    break;
                case "Return": // Return implemented in RequestOption()
                    break;
                default:
                    Console.WriteLine("Option not implemented yet.");
                    break;
            }

            Console.Clear();
            Display();
        }

        public class ShowDate
        {
            public ShowDate()
            {
                DateTime date = DateTime.Now;
                Console.WriteLine("Today's date is " + date.ToString("dd.MM.yyyy"));

                Console.WriteLine("Press any key to move back to the menu");
                Console.ReadKey();
            }
        }

        public class ShowTime
        {
            public ShowTime()
            {
                DateTime date = DateTime.Now;
                Console.WriteLine("The time right now is {0}", date.ToShortTimeString());

                Console.WriteLine("Press any key to move back to the menu");
                Console.ReadKey();
            }
        }
    }
}
