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
            Console.Clear();
            DelegatesMenu delegateMenu = new DelegatesMenu();
            delegateMenu.Run();
        }
    }

    public class MenuInterface
    {
        Interfaces.MainMenu m_MainMenu = new Interfaces.MainMenu();
        
        public void Show() // Method added as required in homework
        {
            m_MainMenu.Reset();
        }
    }
}
