using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    interface Interface1
    {
        void showMenu();
        void addMenuItem();
        void removeMenuItem();
        
        List <string> menuItems { get; set; }
    }
}
