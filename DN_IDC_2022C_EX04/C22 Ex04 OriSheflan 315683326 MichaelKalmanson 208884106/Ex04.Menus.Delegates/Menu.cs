using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class Menu : MenuItem
    {
        private readonly List<MenuItem> r_MenuItems;

        public Menu(string i_Name, Menu i_PreviousMenu = null) : base(i_Name, i_PreviousMenu)
        {
            this.r_MenuItems = new List<MenuItem>();
        }

        public List<MenuItem> MenuItems
        {
            get
            {
                return r_MenuItems;
            }
        }

        public void AddItemToMenu(MenuItem i_MenuItem)
        {
            r_MenuItems.Add(i_MenuItem);
        }

        public void ShowMenu()
        {
            StringBuilder headLineAndSeparation = new StringBuilder();
            headLineAndSeparation.Append(MenuTitle);
            headLineAndSeparation.Append(Environment.NewLine);
            headLineAndSeparation.Append("==============");
            Console.WriteLine(headLineAndSeparation);
            int countOfMenuItems = 1;
            foreach (MenuItem menuItem in this.MenuItems)
            {
                Console.WriteLine(String.Format("{0}. {1}", countOfMenuItems.ToString(), menuItem.MenuTitle));
                countOfMenuItems++;
            }

            string backOrExit = "0. Back";
            if (this.PreviousMenu == null)
            {
                backOrExit = "0. Exit";
            }

            Console.WriteLine(backOrExit);
            Console.WriteLine("==============");
        }
    }
}