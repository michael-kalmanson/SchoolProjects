namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            InterfaceMenuTest interfaceMenuTest = new InterfaceMenuTest("Interface Main Menu");
            interfaceMenuTest.Run();

            DelegateMenuTest delegateMenuTest = new DelegateMenuTest("Delegates Main Menu");
            delegateMenuTest.Run();
        }
    }
}