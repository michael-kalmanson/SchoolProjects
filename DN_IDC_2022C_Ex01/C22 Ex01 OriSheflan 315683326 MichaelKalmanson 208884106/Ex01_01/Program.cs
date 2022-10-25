namespace Ex01_01
 {
    public class Program
    {
        static int NUM_OF_NUMBERS = 3;
        static int NUM_OF_DIGITS = 7;

        public static void Main()
        {
            string[] args = new string[2];
            args[0] = NUM_OF_NUMBERS.ToString();
            args[1] = NUM_OF_DIGITS.ToString();
            string msg = string.Format(
@"Hello!
Please enter {0} numbers with in binary format (only 0's and 1's allowed), each is {1} digits long.", args);

            System.Console.WriteLine(msg);
            string[] userBinaryInput = readInputFromUser();
            int[] userDecimalInput = convertBinaryArrToDecimalArr(userBinaryInput);
            System.Array.Sort(userDecimalInput); // now user_decimal_input is sorted.
            printDecimalArray(userDecimalInput);
            printStatsForUserInput(userBinaryInput, userDecimalInput);
            System.Console.WriteLine("Press enter to terminate program.");
            System.Console.ReadLine();
        }

        private static string[] readInputFromUser()
        {
            string[] userInput = new string[NUM_OF_NUMBERS];
            for (int i = 0; i < NUM_OF_NUMBERS; i++)
            {
                System.Console.WriteLine("Enter a number (and then press enter)");
                string currentInput = System.Console.ReadLine();
                if (isInputValid(currentInput))
                {
                    userInput[i] = currentInput;
                }
                else
                {
                    // is_input_valid print an error message with respect to user's mistake.
                    i--;
                }
            }

            return userInput;
        }

        private static bool isInputValid(string i_input)
        {
            bool isInputValid = true;

            if (i_input.Length != NUM_OF_DIGITS)
            {
                System.Console.WriteLine("Number doesn't have correct amount of digits, please try again:");
                isInputValid = false;
            }
            else
            {
                for (int i = 0; i < NUM_OF_DIGITS; i++)
                {
                    if (!i_input[i].Equals('0') && !i_input[i].Equals('1'))
                    {
                        System.Console.WriteLine("Number format isn't valid, only binary numbers are acceptable (o's or 1's).\nPlease try again:");
                        isInputValid = false;
                        break;
                    }
                }
            }

            return isInputValid;
        }

        private static int[] convertBinaryArrToDecimalArr(string[] i_userInputBinaryNumbers)
        {
            int[] decimalUserInput = new int[NUM_OF_NUMBERS];

            for (int i = 0; i < NUM_OF_NUMBERS; i++)
            {
                int power = (int)System.Math.Pow(2, NUM_OF_DIGITS - 1);
                for (int j = 0; j < NUM_OF_DIGITS; j++)
                {
                    if (i_userInputBinaryNumbers[i][j].Equals('1'))
                    {
                        decimalUserInput[i] += power;
                    }

                    power = power / 2;
                }
            }

            return decimalUserInput;
        }

        private static void printStatsForUserInput(string[] i_binaryNums, int[] i_decimalNums)
        {
            System.Console.WriteLine();
            printAverageNumOfDigits(i_binaryNums);
            printIfDividedBy3(i_decimalNums, NUM_OF_NUMBERS);
            printIfPalindrom(i_decimalNums);
        }

        private static void printAverageNumOfDigits(string[] i_binaryNums)
        {
            float numOf1 = 0;
            float numOf0 = 0;

            for (int i = 0; i < NUM_OF_NUMBERS; i++)
            {
                for (int j = 0; j < NUM_OF_DIGITS; j++)
                {
                    if (i_binaryNums[i][j].Equals('1'))
                    {
                        numOf1++;
                    }
                    else
                    {
                        numOf0++;
                    }
                }
            }

            string[] args = new string[2];
            args[0] = (numOf1 / NUM_OF_NUMBERS).ToString();
            args[1] = (numOf0 / NUM_OF_NUMBERS).ToString();
            string msg = string.Format("The average number of 1's for your input was {0} and the average number of 0's for your input was {1}!", args);
            System.Console.WriteLine(msg);
        }

        public static void printIfDividedBy3(int[] i_decimalNums, int i_numOfNumbers)
        {
            int numOfNumbersDividedBy3 = 0;
            string isOrAre = string.Empty;

            for (int i = 0; i < i_numOfNumbers; i++)
            {
                if (i_decimalNums[i] % 3 == 0)
                {
                    numOfNumbersDividedBy3++;
                }
            }

            if (numOfNumbersDividedBy3 == 1)
            {
                isOrAre = "is";
            }
            else
            {
                isOrAre = "are";
            }

            string msg = string.Format("Out of the numbers you gave, {0} {1} divisible by 3 without a remainder!", numOfNumbersDividedBy3.ToString(), isOrAre);
            System.Console.WriteLine(msg);
        }

        private static void printIfPalindrom(int[] i_decimalNums)
        {
            string[] stringDecimalNums = System.Array.ConvertAll(i_decimalNums, num => num.ToString());
            int numOfPalindromes = 0;
            string isOrAre = string.Empty;
            string sOrWithoutS = string.Empty;

            for (int i = 0; i < NUM_OF_NUMBERS; i++)
            {
                if (stringDecimalNums[i] == reverse(stringDecimalNums[i]))
                {
                    numOfPalindromes++;
                }
            }

            if (numOfPalindromes == 1)
            {
                isOrAre = "is";
            }
            else
            {
                isOrAre = "are";
                sOrWithoutS = "s";
            }

            string msg = string.Format("Out of the numbers you gave, {0} {1} palindrome{2}!", numOfPalindromes.ToString(), isOrAre, sOrWithoutS);
            System.Console.WriteLine(msg);
        }

        private static string reverse(string i_str)
        {
            char[] charArray = i_str.ToCharArray();
            System.Array.Reverse(charArray);
            return new string(charArray);
        }

        private static void printDecimalArray(int[] i_decimalArray)
        {
            int arrayLength = i_decimalArray.Length;

            System.Console.WriteLine();
            for (int i = 0; i < arrayLength; i++)
            {
                System.Console.WriteLine(i_decimalArray[i]);
            }
        }
    }
}
