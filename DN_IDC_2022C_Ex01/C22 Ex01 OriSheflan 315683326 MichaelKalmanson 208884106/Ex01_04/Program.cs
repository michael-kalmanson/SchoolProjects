namespace Ex01_04
{
    public class Program
    {
        static int LENGTH_OF_INPUT = 9;

        // $G$ DSN-006 (-5) The Main method should only be an access point to the program. Should look something like:
        // public static void Main() { Run(); } 
        public static void Main()
        {
            string userInput = readInputFromUser();
            bool isNum = isInputNumber(userInput);
            if (isNum)
            {
                printStatsForNum(userInput);
            }
            else
            {
                printStatsForWord(userInput);
            }

            System.Console.WriteLine();
            System.Console.WriteLine("Press enter to terminate program.");
            System.Console.ReadLine();
        }

        // $G$ NTT-999 (-10) You should have used Environment.NewLine instead of "\n".
        private static string readInputFromUser()
        {
            System.Console.WriteLine("Hello!\nPlease enter either a 9 English letters string (only lower or upper case letters allowed) or a 9 digits number (and then press enter)"); 
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

        // $G$ CSS-013 (-3) Bad parameter name (should be in the form of i_PascalCase).
        private static bool isInputValid(string i_userInput)
        {
            bool isValid = true;
            bool isNum = isInputNumber(i_userInput);
            bool isWord = isInputWord(i_userInput);

            if (i_userInput.Length != LENGTH_OF_INPUT)
            {
                System.Console.WriteLine("Invalid length of input!");
                isValid = false;
            }
            else if (isNum == false && isWord == false)
            {
                System.Console.WriteLine("Invalid input! You must enter either a number or a word.");
                isValid = false;
            }

            return isValid;
        }

        public static bool isInputNumber(string i_userInput)
        {
            return int.TryParse(i_userInput, out int o_intUserInput);
        }

        // $G$ CSS-013 (-3) Bad parameter name (should be in the form of i_PascalCase).
        // $G$ NTT-005 (-10) You should have used the Char (class) methods such as IsDigit, IsLower, IsLetter etc.
        private static bool isInputWord(string i_userInput)
        {
            int lengthOfWord = i_userInput.Length;
            bool isWord = true;
            for (int i = 0; i < lengthOfWord; i++)
            {
                if (i_userInput[i] < 65 || (i_userInput[i] > 90 && i_userInput[i] < 97) || i_userInput[i] > 122)
                {
                    isWord = false;
                }
            }

            return isWord;
        }

        private static void printStatsForNum(string i_userInput)
        {
            printIfPalindrom(i_userInput);
            printIfDividedBy3(int.Parse(i_userInput));
        }

        private static void printStatsForWord(string i_userInput)
        {
            printIfPalindrom(i_userInput);
            printNumberOfLowercasesInWord(i_userInput);
        }

        private static void printIfPalindrom(string i_userInput)
        {
            bool isInputPalindrom = isPalindromRecursive(i_userInput, 0, i_userInput.Length - 1);
            string isInputPalindromString = string.Empty;

            if (isInputPalindrom)
            {
                isInputPalindromString = "is";
            }
            else
            {
                isInputPalindromString = "isn't";
            }

            string msg = string.Format(
@"Your input {0} a palindrom!", isInputPalindromString);
            System.Console.WriteLine(msg);
        }

        private static bool isPalindromRecursive(string i_userInput, int i_startIndex, int i_endIndex)
        {
            bool doesCharMatchPalindrom = i_userInput[i_startIndex] == i_userInput[i_endIndex];
            bool weNeedToStop = i_startIndex == i_endIndex;
            bool isPalindrom = true;

            if (!weNeedToStop)
            {
                isPalindrom = doesCharMatchPalindrom && isPalindromRecursive(i_userInput, i_startIndex + 1, i_endIndex - 1);
            }

            return isPalindrom;
        }

        private static void printNumberOfLowercasesInWord(string i_userInput)
        {
            int wordLength = i_userInput.Length;
            int countOfLowercases = 0;
            for (int i = 0; i < wordLength; i++)
            {
                if (i_userInput[i] > 96 && i_userInput[i] < 123)
                {
                    countOfLowercases++;
                }
            }

            string numOfLowercases = countOfLowercases.ToString();
            string msg = string.Format(
@"The number of lowercase letters in the word is {0}!", numOfLowercases);
            System.Console.WriteLine(msg);
        }

        // $G$ CSS-013 (-3) Bad parameter name (should be in the form of i_PascalCase).
        private static void printIfDividedBy3(int i_userInputNum)
        {
            string isDividedBy3 = string.Empty;
            if (i_userInputNum % 3 == 0)
            {
                isDividedBy3 = "is";
            }
            else
            {
                isDividedBy3 = "isn't";
            }

            string msg = string.Format(
@"The number you entered {0} divided by 3 without remainder!", isDividedBy3);
            System.Console.WriteLine(msg);
        }
    }
}
