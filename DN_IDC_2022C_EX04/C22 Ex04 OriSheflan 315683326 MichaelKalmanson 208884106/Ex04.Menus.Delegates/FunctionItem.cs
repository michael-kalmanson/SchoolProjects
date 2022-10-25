using System;

namespace Ex04.Menus.Delegates
{
    public class FunctionItem : MenuItem
    {
        public event Action UserChoiceExcecution;
        public FunctionItem(string i_Name, Menu i_PreviousMenu, Action i_ExcecutionFunction) : base(i_Name, i_PreviousMenu)
        {
            UserChoiceExcecution += i_ExcecutionFunction;
        }

        public void InvokeWhenUserChose()
        {
            OnUserChose();
        }

        protected virtual void OnUserChose()
        {
            if (UserChoiceExcecution != null)
            {
                UserChoiceExcecution.Invoke();
            }
        }
    }
}