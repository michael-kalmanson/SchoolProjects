using Ex04.Menus.Delegates;
using Ex04.Menus.Test.MenuTestLogicDelegates;

namespace Ex04.Menus.Test
{
    public class DelegateMenuTest
    {
        MainMenu m_MainMenu;

        public DelegateMenuTest(string i_MenuTitle)
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
            m_MainMenu.AddFunction("Count Spaces", new DelegatesLogic().CountSpaces);
            m_MainMenu.AddFunction("Show version", new DelegatesLogic().ShowVersion);
            m_MainMenu.BackToOuterLevel();

            m_MainMenu.AddMenu("Show Date/Time");
            m_MainMenu.EnterInnerLevel(2);
            m_MainMenu.AddFunction("Show Time", new DelegatesLogic().ShowTime);
            m_MainMenu.AddFunction("Show Date", new DelegatesLogic().ShowDate);
            m_MainMenu.BackToOuterLevel();
        }
    }
}