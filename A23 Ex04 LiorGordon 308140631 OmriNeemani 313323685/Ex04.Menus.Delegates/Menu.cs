using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public class Menu : ItemMenu
    {
        private const string k_MainHeader = "Delegates Menu:";
        private const int k_FirstLevel = 1;
        private const string k_Seperator = "--------------------------------------------------------------------";
        private const string k_IllegalInputMessage = "Illegal input.";
        private const bool k_isQuitItem = true;
        private readonly int r_Level;
        private readonly Dictionary<int, ItemMenu> r_MenuItems = new Dictionary<int, ItemMenu>();

        public Dictionary<int, ItemMenu> MenuItems
        {
            get { return r_MenuItems; }
        }

        public int Level
        {
            get { return r_Level; }
        }

        public Menu(string i_ItemName, int i_ItemLevel)
            : base(i_ItemName)
        {
            r_Level = i_ItemLevel;
            ItemMenu quit = new ItemMenu("Back", k_isQuitItem);
            Add(quit);
        }

        public Menu()
             : base(k_MainHeader)
        {
            r_Level = k_FirstLevel;
            ItemMenu quit = new ItemMenu("Exit", k_isQuitItem);
            Add(quit);
        }

        public void Add(ItemMenu i_MenuItem)
        {
            r_MenuItems.Add(r_MenuItems.Count, i_MenuItem);
        }

        public void Show()
        {
            bool isMenuActive = true;

            while (isMenuActive)
            {
                printHeader();
                printMenu();
                string userChoiceString = Console.ReadLine();
                int userChoise;
                Console.Clear();
                if (int.TryParse(userChoiceString, out userChoise) && r_MenuItems.ContainsKey(userChoise))
                {
                    handleKeyPressed(userChoise, ref isMenuActive);
                }
                else
                {
                    Console.WriteLine(k_IllegalInputMessage);
                }
            }
        }

        private void printHeader()
        {
            string headerMessage = string.Format(@"{0}. {1}", r_Level, Name);
            Console.WriteLine(headerMessage);
            Console.WriteLine(k_Seperator);
        }

        private void printMenu()
        {
            string choiceRequest = string.Format(@"Enter Selection or press {0}", r_MenuItems[0].Name);
            Console.WriteLine(choiceRequest);
            foreach (KeyValuePair<int, ItemMenu> menuItem in r_MenuItems)
            {
                Console.WriteLine(string.Format(@"[{0}] {1}", menuItem.Key, menuItem.Value.Name));
            }
        }

        private void handleKeyPressed(int userChoise, ref bool isMenuActive)
        {
            Menu menu = r_MenuItems[userChoise] as Menu;
            ItemAction action = r_MenuItems[userChoise] as ItemAction;

            if (menu != null)
            {
                menu.Show();
            }
            else if (action != null)
            {
                action.DoWhenOperated();
            }
            else if (r_MenuItems[userChoise].IsQuit)
            {
                isMenuActive = false;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}
