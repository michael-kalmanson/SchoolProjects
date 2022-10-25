using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    namespace MenuTestLogicDelegates
    {
        public class DelegatesLogic
        {
            public void CountSpaces()
            {
                string inputSentence;
                int CounterSpaces = 0;
                Console.WriteLine("Please enter your sentence:");
                inputSentence = Console.ReadLine();
                foreach (char c in inputSentence)
                {
                    if (char.IsWhiteSpace(c))
                    {
                        CounterSpaces++;
                    }
                }

                Console.WriteLine(string.Format("There are {0} Spaces in your sentence.", CounterSpaces));
            }

            public void ShowVersion()
            {
                System.Console.WriteLine("Version: 22.3.4.8650");
            }

            public void ShowTime()
            {
                Console.WriteLine(DateTime.Now.TimeOfDay);
            }

            public void ShowDate()
            {
                Console.WriteLine(DateTime.Now.ToShortDateString());
            }
        }
    }

    namespace MenuTestLogicInterfaces
    {
        public class CountSpaces : IExecuteFunction
        {
            public void Execute()
            {
                string inputSentence;
                int CounterSpaces = 0;
                Console.WriteLine("Please enter your sentence:");
                inputSentence = Console.ReadLine();
                foreach (char c in inputSentence)
                {
                    if (char.IsWhiteSpace(c))
                    {
                        CounterSpaces++;
                    }
                }

                Console.WriteLine(string.Format("There are {0} Spaces in your sentence.", CounterSpaces));
            }
        }

        public class ShowVersion : IExecuteFunction
        {
            public void Execute()
            {
                System.Console.WriteLine("Version: 22.3.4.8650");
            }
        }

        public class ShowTime : IExecuteFunction
        {
            public void Execute()
            {
                Console.WriteLine(DateTime.Now.TimeOfDay);
            }
        }

        public class ShowDate : IExecuteFunction
        {
            public void Execute()
            {
                Console.WriteLine(DateTime.Now.ToShortDateString());
            }
        }
    }
}