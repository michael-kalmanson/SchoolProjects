using System;
using System.Linq;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        public Menu m_CurrentMenu;

        public MainMenu(string i_MainTitleName)
        {
            m_CurrentMenu = new Menu(i_MainTitleName);
        }

        public Menu CurrentMenu
        {
            get
            {
                return this.m_CurrentMenu;
            }
            set
            {
                m_CurrentMenu = value;
            }
        }

        // $G$ CSS-013 (-3) Bad parameter name (should be in the form of i_PascalCase).
        public void AddMenu(string i_name)
        {
            Menu newMenu = new Menu(i_name, this.CurrentMenu);
            this.CurrentMenu.MenuItems.Add(newMenu);
        }

        // $G$ CSS-013 (-3) Bad parameter name (should be in the form of i_PascalCase).
        public void AddFunction(string i_name, Action i_ExcecutionFunction)
        {
            FunctionItem newFunction = new FunctionItem(i_name, this.CurrentMenu, i_ExcecutionFunction);
            this.CurrentMenu.MenuItems.Add(newFunction);
        }

        public int GetInput()
        {
            int intUserChoise = 0;
            string userInput;
            bool isValidInput = false;

            while (!isValidInput)
            {
                userInput = Console.ReadLine();
                if (int.TryParse(userInput, out intUserChoise))
                {
                    if ((intUserChoise >= 0) && (intUserChoise <= this.CurrentMenu.MenuItems.Count()))
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number between 0 and {0}\nPlease select an option:", this.CurrentMenu.MenuItems.Count());
                    }
                }
                else
                {
                    Console.WriteLine("Please enter an int - number\nPlease select an option:");
                }
            }

            return intUserChoise;
        }

        // $G$ CSS-013 (-3) Bad parameter name (should be in the form of i_PascalCase).
        public void EnterInnerLevel(int i_userInput)
        {
            Menu ChosenItem = CurrentMenu.MenuItems[i_userInput - 1] as Menu;
            if (ChosenItem != null)
            {
                CurrentMenu = (Menu)CurrentMenu.MenuItems[i_userInput - 1];
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public bool BackToOuterLevel()
        {
            bool success = false;
            if (CurrentMenu.PreviousMenu != null)
            {
                CurrentMenu = CurrentMenu.PreviousMenu;
                success = true;
            }

            return success;
        }

        public void Show()
        {
            int userInput;
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                CurrentMenu.ShowMenu();
                Console.WriteLine("Please select an option:");
                userInput = GetInput();
                if (userInput == 0)
                {
                    if (BackToOuterLevel())
                    {
                        Console.Clear();
                        CurrentMenu.ShowMenu();
                    }
                    else
                    {
                        exit = true;
                    }
                }
                else
                {
                    try
                    {
                        EnterInnerLevel(userInput);
                    }
                    catch
                    {
                        FunctionItem executableItem = CurrentMenu.MenuItems[userInput - 1] as FunctionItem;
                        Console.Clear();
                        Console.WriteLine(executableItem.MenuTitle);
                        Console.WriteLine();
                        executableItem.InvokeWhenUserChose();
                        Console.WriteLine();
                        Console.WriteLine("Press any key to return to menu");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
