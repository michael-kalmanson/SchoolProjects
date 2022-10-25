namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        private string m_MenuTitle;
        private Menu m_PreviousMenu;
        private bool m_IsMainMenu;

        public MenuItem(string i_MenuTitle, Menu i_PreviousMenu)
        {
            m_MenuTitle = i_MenuTitle;
            m_PreviousMenu = i_PreviousMenu;
            if (m_PreviousMenu == null)
            {
                m_IsMainMenu = true;
            }
            else
            {
                m_IsMainMenu = false;
            }
        }

        public string MenuTitle
        {
            get
            {
                return m_MenuTitle;
            }
        }

        public Menu PreviousMenu
        {
            get
            {
                return m_PreviousMenu;
            }
        }

        public bool IsmainMenu
        {
            get
            {
                return m_IsMainMenu;
            }
        }
    }
}