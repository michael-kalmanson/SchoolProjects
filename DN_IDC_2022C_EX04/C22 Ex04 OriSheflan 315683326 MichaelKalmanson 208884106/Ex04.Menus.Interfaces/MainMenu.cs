using System;
using System.Linq;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private Menu m_CurrentMenu;

        public MainMenu(string i_MainTitleName)
        {
            this.m_CurrentMenu = new Menu(i_MainTitleName);
        }

        public Menu CurrentLevelMenu
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
                    if ((intUserChoise >= 0) && (intUserChoise <= this.CurrentLevelMenu.MenuItems.Count()))
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number between 0 and {0}\nPlease select an option:", this.CurrentLevelMenu.MenuItems.Count());
                    }
                }
                else
                {
                    Console.WriteLine("Please enter an int - number\nPlease select an option:");
                }
            }

            return intUserChoise;
        }

        public void EnterInnerLevel(int i_userInput)
        {
            Menu ChosenItem = CurrentLevelMenu.MenuItems[i_userInput - 1] as Menu;
            if (ChosenItem != null)
            {
                CurrentLevelMenu = (Menu)CurrentLevelMenu.MenuItems[i_userInput - 1];
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public bool BackToOuterLevel()
        {
            bool success = false;
            if (CurrentLevelMenu.PreviousMenu != null)
            {
                CurrentLevelMenu = CurrentLevelMenu.PreviousMenu;
                success = true;
            }

            return success;
        }


        public void AddMenu(string i_name)
        {
            Menu newMenu = new Menu(i_name, this.CurrentLevelMenu);
            this.m_CurrentMenu.AddItemToMenu(newMenu);
        }

        public void AddFunction(string i_name, IExecuteFunction i_ExecuteFunction)
        {
            FunctionItem newFunction = new FunctionItem(i_name, this.m_CurrentMenu, i_ExecuteFunction);
            this.m_CurrentMenu.AddItemToMenu(newFunction);
        }

        public void Show()
        {
            int userInput;
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                CurrentLevelMenu.ShowMenu();
                Console.WriteLine("Please select an option:");
                userInput = GetInput();
                if (userInput == 0)
                {
                    if (BackToOuterLevel())
                    {
                        Console.Clear();
                        CurrentLevelMenu.ShowMenu();
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
                        FunctionItem executableItem = CurrentLevelMenu.MenuItems[userInput - 1] as FunctionItem;
                        Console.Clear();
                        Console.WriteLine(executableItem.MenuTitle);
                        Console.WriteLine();
                        executableItem.InvokeWhenChoose();
                        Console.WriteLine();
                        Console.WriteLine("Press any key to return to menu");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}