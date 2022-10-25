using Ex01_02;

namespace Ex01_03
{
    public class Program
    {
        public static void Main()
        {
            int userInputHeightOfDiamond = getUserInput();
            Ex01_02.Program.Print_diamond(userInputHeightOfDiamond);
            System.Console.WriteLine("Press enter to terminate program.");
            System.Console.ReadLine();
        }

        private static int getUserInput()
        {
            System.Console.WriteLine("Please enter requested height of the diamond (and then press enter).");
            string userInput = System.Console.ReadLine();
            int intUserInput = 0;
            while (!int.TryParse(userInput, out intUserInput) || intUserInput < 0)
            {
                System.Console.WriteLine("Entered an invalid input, please try again:");
                System.Console.WriteLine("Please enter requested height of the diamond (and then press enter).");
                userInput = System.Console.ReadLine();
            }

            return intUserInput;
        }
    }
}