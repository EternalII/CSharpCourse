using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public class AllMainMenu
    {
        private readonly Menu m_Menu = new Menu();

        public Menu Menu
        {
            get { return m_Menu; }
        }


        public void Add(ItemMenu i_MenuItem)
        {
            m_Menu.Add(i_MenuItem);
        }

        public void Show()
        {
            m_Menu.Show();
        }
    }
}

