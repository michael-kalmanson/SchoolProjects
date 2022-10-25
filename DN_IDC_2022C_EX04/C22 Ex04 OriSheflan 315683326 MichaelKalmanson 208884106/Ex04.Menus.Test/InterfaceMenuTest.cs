using Ex04.Menus.Interfaces;
using Ex04.Menus.Test.MenuTestLogicInterfaces;

namespace Ex04.Menus.Test
{
    public class InterfaceMenuTest
    {
        MainMenu m_MainMenu;

        public InterfaceMenuTest(string i_MenuTitle)
        {
            this.m_MainMenu = new MainMenu(i_MenuTitle);
        }

        public void Run()
        {
            buildTestMenu();
            m_MainMenu.Show();
        }

        private void buildTestMenu()
        {
            m_MainMenu.AddMenu("Version and Spaces");
            m_MainMenu.EnterInnerLevel(1);
            m_MainMenu.AddFunction("Count Spaces", new CountSpaces());
            m_MainMenu.AddFunction("Show version", new ShowVersion());
            m_MainMenu.BackToOuterLevel();

            m_MainMenu.AddMenu("Show Date/Time");
            m_MainMenu.EnterInnerLevel(2);
            m_MainMenu.AddFunction("Show Time", new ShowTime());
            m_MainMenu.AddFunction("Show Date", new ShowDate());
            m_MainMenu.BackToOuterLevel();
        }
    }
}