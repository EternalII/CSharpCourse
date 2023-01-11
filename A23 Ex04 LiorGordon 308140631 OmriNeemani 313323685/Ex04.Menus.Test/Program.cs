using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus;

namespace Ex04.Menus.Test
{
    class Program
    {
        public static void Main()
        {
            MenuInterface intMenu = new MenuInterface();
        }
    }

    public class MenuInterface
    {
        Interfaces.IMenu m_MainMenu = new Interfaces.MainMenu();
        
        public void Show() 
        {
            //string userChoice = "0";
            //while (userChoice != "3")
            //{
            //    Console.Clear();
            //    m_MainMenu.Display();
            //    userChoice = Console.ReadLine();
            //    m_MainMenu.SelectOption(userChoice);
            //}
        }
    }
}
