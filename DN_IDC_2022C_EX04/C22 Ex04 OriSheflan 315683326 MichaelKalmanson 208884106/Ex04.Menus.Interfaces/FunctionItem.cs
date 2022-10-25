namespace Ex04.Menus.Interfaces
{
    public class FunctionItem : MenuItem
    {
        private IExecuteFunction m_ExecuteFunction;
        public FunctionItem(string i_Name, Menu i_PreviousMenu, IExecuteFunction executeFunction) : base(i_Name, i_PreviousMenu)
        {
            m_ExecuteFunction = executeFunction;
        }

        public IExecuteFunction ExecuteFunction
        {
            get
            {
                return m_ExecuteFunction;
            }
            set
            {
                this.m_ExecuteFunction = value;
            }
        }

        public void InvokeWhenChoose()
        {
            m_ExecuteFunction.Execute();
        }
    }
}
