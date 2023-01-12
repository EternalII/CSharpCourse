using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public class DelegatesMenu
    {
        private readonly AllMainMenu m_MainMenu = new AllMainMenu();

        public void Run()
        {
            Menu versionAndUppercase = new Menu("Version and Uppercase", m_MainMenu.Menu.Level + 1);
            Menu showDateAndTime = new Menu("Show Date/Time", m_MainMenu.Menu.Level + 1);
            ItemAction showDate = new ItemAction("Show Date");
            ItemAction showTime = new ItemAction("Show Time");
            ItemAction showVersion = new ItemAction("Show Version");
            ItemAction countUppercase = new ItemAction("Count Uppercase");


            m_MainMenu.Add(versionAndUppercase);
            m_MainMenu.Add(showDateAndTime);
            showDateAndTime.Add(showDate);
            showDateAndTime.Add(showTime);
            versionAndUppercase.Add(showVersion);
            versionAndUppercase.Add(countUppercase);
            showDate.ItemActivated += ShowDate_Operate;
            showTime.ItemActivated += ShowTime_Operate;
            showVersion.ItemActivated += ShowVersion_Operate;
            countUppercase.ItemActivated += CountUppercase_Operate;
            m_MainMenu.Show();
        }

        private void ShowDate_Operate()
        {
            MethodsPart methods = new MethodsPart();
            methods.ShowDate();
        }

        private void ShowTime_Operate()
        {
            MethodsPart methods = new MethodsPart();
            methods.ShowTime();
        }

        private void ShowVersion_Operate()
        {
            MethodsPart methods = new MethodsPart();
            methods.ShowVersion();
        }

        private void CountUppercase_Operate()
        {
            MethodsPart methods = new MethodsPart();
            methods.CountUppercase();
        }
    }
}
