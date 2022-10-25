using Ex01_01;
using Ex01_04;
using System.Linq;

namespace Ex01_05
{
    public class Program
    {
        static int NUM_OF_DIGITS = 9;

        public static void Main()
        {
            string userInput = readInputFromUser();
            printStatsForUser(userInput);
            System.Console.WriteLine();
            System.Console.WriteLine("Press enter to terminate program.");
            System.Console.ReadLine();
        }

        private static string readInputFromUser()
        {
            System.Console.WriteLine("Hello!\nPlease enter 9 digits number (and then press enter)");
            string userInput = System.Console.ReadLine();

            System.Console.WriteLine();
            while (!isInputValid(userInput))
            {
                System.Console.WriteLine("Please try again:");
                userInput = System.Console.ReadLine();
                System.Console.WriteLine();
            }

            return userInput;
        }

        private static bool isInputValid(string i_userInput)
        {
            bool isValid = true;
            bool isNum = Ex01_04.Program.isInputNumber(i_userInput);

            if (i_userInput.Length != NUM_OF_DIGITS)
            {
                System.Console.WriteLine("Invalid length of input!");
                isValid = false;
            }
            else if (isNum == false)
            {
                System.Console.WriteLine("Invalid input! You must enter a number.");
                isValid = false;
            }

            return isValid;
        }

        // $G$ CSS-013 (-3) Bad parameter name (should be in the form of i_PascalCase).
        private static void printStatsForUser(string i_userInput)
        {
            int[] inputDigitsArr = convertInputToDigitsArray(i_userInput);
            printNumOfDigitsSmallerThanUnitsDigit(inputDigitsArr);
            printBiggestDigit(inputDigitsArr);
            Ex01_01.Program.printIfDividedBy3(inputDigitsArr, NUM_OF_DIGITS);
            printDigitsAverage(inputDigitsArr);
        }

        // $G$ CSS-013 (-3) Bad parameter name (should be in the form of i_PascalCase).
        private static int[] convertInputToDigitsArray(string i_userInput)
        {
            int[] digitsArray = new int[NUM_OF_DIGITS];

            for (int i = 0; i < NUM_OF_DIGITS; i++)
            {
                digitsArray[i] = (int)(i_userInput[i] - '0');
            }

            return digitsArray;
        }

        private static void printNumOfDigitsSmallerThanUnitsDigit(int[] i_inputDigitsArr)
        {
            int unitsDigit = i_inputDigitsArr[NUM_OF_DIGITS - 1];
            int numOfDigitsSmallerThanUnitsDigit = 0;

            for (int i = 0; i < NUM_OF_DIGITS - 1; i++)
            {
                if (unitsDigit > i_inputDigitsArr[i])
                {
                    numOfDigitsSmallerThanUnitsDigit++;
                }
            }

            string msg = string.Format(
@"The Number of Digits which are smaller than the units digit is {0}!", numOfDigitsSmallerThanUnitsDigit.ToString());
            System.Console.WriteLine(msg);
        }

        private static void printBiggestDigit(int[] i_inputDigitsArr)
        {
            int biggestDigit = i_inputDigitsArr.Max();
            string msg = string.Format(
@"The biggest digit is {0}!", biggestDigit.ToString());
            System.Console.WriteLine(msg);
        }

        private static void printDigitsAverage(int[] i_inputDigitsArr)
        {
            int sum = 0;
            float average = 0;

            for (int i = 0; i < NUM_OF_DIGITS; i++)
            {
                sum += i_inputDigitsArr[i];
            }

            average = sum / (float)NUM_OF_DIGITS;
            string msg = string.Format(
@"The average of all digits is {0}!", average.ToString());
            System.Console.WriteLine(msg);
        }
    }
}
