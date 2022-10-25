using System.Runtime;
using System;
using ConsoleMemoryGame_Logic;
using System.Threading;
using System.Text;
using Ex02.ConsoleUtils;

namespace ConsoleMemoryGame_UI
{
    public class Program
    {
        public static void Main()
        {
            InitializeGame();
        }
        
        public static void InitializeGame()
        {
            Console.WriteLine("Welcome to Console Memory Game!");
            (int, int) SizeOfBoard = readBoardSizeFromUser();
            int numRows = SizeOfBoard.Item1;
            int numColls = SizeOfBoard.Item2;

            string player1Name = readPlayerNameFromUser("first player");
            string player2Name;
            bool playingVSComputer = readIsPlayingAgainstComputerFromUser();
            if (!playingVSComputer)
            {
                player2Name = readPlayerNameFromUser("second player");
            }
            else
            {
                player2Name = "Computer";
            }

            Game myGame = new Game(numRows, numColls, playingVSComputer, player1Name, player2Name);
            playGame(myGame);
        }

        private static void playGame(Game i_Game)
        {
            printOpenMessage(i_Game);
            while (!i_Game.IsGameEnded())
            {
                if (!i_Game.M_Player1Turn && i_Game.M_Player2.M_IsComputer)
                {
                    playComputerTurn(i_Game);
                }
                else
                {
                    playFirstMove(i_Game);
                    playSecondMove(i_Game);
                }

                i_Game.FinishTurn();//add points, reset the cells if neccesery and more background actions.
                printScore(i_Game);
            }
            announceWinner(i_Game);
            while (isUserWantToPlayAgain())
            {
                InitializeGame();
            }

            Console.WriteLine("Thank you for playing!");
            Thread.Sleep(2000);
        }

        private static (int, int) readBoardSizeFromUser()
        {
            int numRows;
            int numColls;
            string msg = string.Format(
@"Please enter your choice for game board size.
Possible answers are two even number between 4 to 6, one representing rows and one representing colls.
");
            Console.WriteLine(msg);
            Console.WriteLine("Please enter a number for number of rows (and then press enter):");
            string firstNumberInput = readNumberFromUser();

            while (!isBoardSizeInputValid(firstNumberInput, out numRows))
            {
                firstNumberInput = readNumberFromUser();
            }

            Console.WriteLine("Please enter a number for number of colls (and then press enter):");
            string secondNumberInput = readNumberFromUser();
            while (!isBoardSizeInputValid(secondNumberInput, out numColls))
            {
                secondNumberInput = readNumberFromUser();
            }

            return (numRows, numColls);
        }

        private static string readNumberFromUser()
        {
            return Console.ReadLine();
        }

        private static bool isBoardSizeInputValid(string i_UserInput, out int o_InputNumber)
        {
            bool isValid = true;
            o_InputNumber = -1;

            if (i_UserInput.Length != 1)
            {
                isValid = false;
                Console.WriteLine("The number you entered wasn't a one digit integer!");
            }
            else if (!int.TryParse(i_UserInput, out o_InputNumber))
            {
                isValid = false;
                Console.WriteLine("You must enter a number!");
            }
            else if (o_InputNumber > 6 || o_InputNumber < 4 || o_InputNumber % 2 != 0)
            {
                isValid = false;
                Console.WriteLine("The number must be an even integer between 4 and 6!");
            }

            if (!isValid)
            {
                Console.WriteLine("Please try again:");
            }

            return isValid;
        }

        private static string readPlayerNameFromUser(string i_PlayerNum)
        {
            Console.WriteLine(string.Format("Please enter {0} name (and then press enter):", i_PlayerNum));
            return Console.ReadLine();
        }

        private static bool readIsPlayingAgainstComputerFromUser()
        {
            bool falseFor2PlayerAndTrueFor1Player;
            Console.WriteLine("Press 1 for playing against the computer and 2 for playing against another player (and then press enter):");
            string oneForComputerOrTwoForPlayer = Console.ReadLine();
            while (!isPlayerChoiseBetweenComputerOrPlayerValid(oneForComputerOrTwoForPlayer))
            {
                Console.WriteLine("Please try again:");
                oneForComputerOrTwoForPlayer = Console.ReadLine();
            }

            if (oneForComputerOrTwoForPlayer.Equals("1"))
            {
                falseFor2PlayerAndTrueFor1Player = true;
            }
            else
            {
                falseFor2PlayerAndTrueFor1Player = false;
            }

            return falseFor2PlayerAndTrueFor1Player;
        }

        private static bool isPlayerChoiseBetweenComputerOrPlayerValid(string i_OneForComputerOrTwoForPlayer)
        {
            bool isInputValid = (i_OneForComputerOrTwoForPlayer.Equals("1") || i_OneForComputerOrTwoForPlayer.Equals("2"));
            if (!isInputValid)
            {
                Console.WriteLine("Invalid input! You must enter either 1- for playing against the copmuter, or 2- for playing against another player.");
            }
            return isInputValid;
        }

        private static string checkWhichPlayerPlaysNow(Game i_Game)
        {
            string nameOfPlayerWithTurn;
            if (i_Game.M_Player1Turn)
            {
                nameOfPlayerWithTurn = i_Game.M_Player1.M_PlayerName;
            }
            else
            {
                nameOfPlayerWithTurn = i_Game.M_Player2.M_PlayerName;
            }

            return nameOfPlayerWithTurn;
        }

        private static void playComputerTurn(Game i_Game)
        {
            printGameBoard(i_Game);
            Thread.Sleep(1000);
            Screen.Clear();
            i_Game.ComputerRevealCell();
            printGameBoard(i_Game);
            Thread.Sleep(2000);
            Screen.Clear();
            i_Game.ComputerRevealCell();
            printGameBoard(i_Game);
            Thread.Sleep(2000);
            Screen.Clear();
        }

        private static void playFirstMove(Game i_Game)
        {
            printGameBoard(i_Game);
            string nameOfPlayerWithTurn = checkWhichPlayerPlaysNow(i_Game);
            string turnMsg = string.Format(
@"It's {0} turn. {0} please choose the first cell you want to expose (and then press enter).", nameOfPlayerWithTurn);
            Console.WriteLine(turnMsg);
            (int, int) firstCellChoice = readPlayerCellChoice(i_Game);
            i_Game.RevealCell(firstCellChoice);
            i_Game.M_GameBoard.M_FirstCurrentExposedCellIndex = firstCellChoice;
            Screen.Clear();
            printGameBoard(i_Game);
            Thread.Sleep(2000);
        }

        private static void playSecondMove(Game i_Game)
        {
            string turnMsg = string.Format(
@"Please choose the second cell you want to expose (and then press enter).");
            Console.WriteLine(turnMsg);
            (int, int) secondCellChoice = readPlayerCellChoice(i_Game);
            i_Game.RevealCell(secondCellChoice);
            i_Game.M_GameBoard.M_SecondCurrentExposedCellIndex = secondCellChoice;
            Screen.Clear();
            printGameBoard(i_Game);
            Thread.Sleep(2000);
            Screen.Clear();
        }

        private static void printScore(Game i_Game)
        {
            string[] argsForStringFormat = new string[4];
            argsForStringFormat[0] = i_Game.M_Player1.M_PlayerName.ToString();
            argsForStringFormat[1] = i_Game.M_Player1.M_Score.ToString();
            argsForStringFormat[2] = i_Game.M_Player2.M_PlayerName.ToString();
            argsForStringFormat[3] = i_Game.M_Player2.M_Score.ToString();
            string scoreMsg = string.Format(
@"End of turn.
{0}'s score: {1}.
{2}'s score: {3}.", argsForStringFormat);
            Console.WriteLine(scoreMsg);
            Thread.Sleep(2000);
            Screen.Clear();
        }

        private static void printOpenMessage(Game i_Game)
        {
            string startGameMsg = string.Format(
@"Game has started, {0} is playing against {1}!
The format for choosing a cell is one digit for row number and one letter for coll number, for example: 2C.
Each turn you will be Choosing 2 cells, if the two cells you chose match, you will be gained a point and the cells will remain exposed for the rest of the game.
At any point of the game, you can enter Q to finish the game.
Press enter to continue:", i_Game.M_Player1.M_PlayerName, i_Game.M_Player2.M_PlayerName);
            Console.WriteLine(startGameMsg);
            Console.ReadLine();
            Screen.Clear();
        }

        private static void announceWinner(Game i_Game)
        {
            if (i_Game.M_Player1.M_Score == i_Game.M_Player2.M_Score)
            {
                string tieMessage = string.Format(
@"It was a tie!
Both players finished with a score of {0}!", i_Game.M_Player1.M_Score.ToString());
                Console.WriteLine(tieMessage);
            }
            else
            {
                string winner;
                string winnerScore;
                string loser;
                string loserScore;

                if (i_Game.M_Player1.M_Score > i_Game.M_Player2.M_Score)
                {
                    winner = i_Game.M_Player1.M_PlayerName;
                    winnerScore = i_Game.M_Player1.M_Score.ToString();
                    loser = i_Game.M_Player2.M_PlayerName;
                    loserScore = i_Game.M_Player2.M_Score.ToString();
                }
                else
                {
                    winner = i_Game.M_Player2.M_PlayerName;
                    winnerScore = i_Game.M_Player2.M_Score.ToString();
                    loser = i_Game.M_Player1.M_PlayerName;
                    loserScore = i_Game.M_Player1.M_Score.ToString();
                }

                string winnerMsg = string.Format(
@"Congragulations {0}! You won the game with a score of {1}.
{2} you were the loser with a score of {3}. Try harder next time...", winner, winnerScore, loser, loserScore);
                Console.WriteLine(winnerMsg);
            }

            Console.WriteLine(Environment.NewLine);
        }

        private static (int, int) readPlayerCellChoice(Game i_Game)
        {
            string playerCellChoice = Console.ReadLine();
            while (!isPlayerChoiceValid(playerCellChoice, i_Game))
            {
                //If choice isn't valid isPlayerChoiseValid prints an error message.
                Console.WriteLine("Please try again:");
                playerCellChoice = Console.ReadLine();
            }

            return convertPlayerChoiseToIntTuple(playerCellChoice);
        }

        private static bool isPlayerChoiceValid(string i_PlayerCellChoice, Game i_Game)
        {
            bool isValid = true;

            if (i_PlayerCellChoice.Equals("Q"))
            {
                Screen.Clear();
                Console.WriteLine("Ok, exiting game...");
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
            else if (i_PlayerCellChoice.Length != 2)
            {
                Console.WriteLine("Invalid length! Only 2 characters can simbole a cell in the game.");
                isValid = false;
            }
            else
            {
                int playerRowChoice = i_PlayerCellChoice[0] - '0' - 1;
                int playerCollChoice = i_PlayerCellChoice[1] - 'A';
                (int, int) playerCellChoice = (playerRowChoice, playerCollChoice);
                if (playerRowChoice < 0 || playerRowChoice >= i_Game.M_NumRows || playerCollChoice < 0 || playerCollChoice >= i_Game.M_NumColls)
                {
                    string errorMessage = string.Format(
    @"You chose an unvalid cell. It is either outside the gameboard or consists of illegel letters.
Your choice must consist of a number between 0 and {0}, and a letter between A and {1}", i_Game.M_NumRows.ToString(), ((char)('A' + i_Game.M_NumColls)).ToString());
                    Console.WriteLine(errorMessage);
                    isValid = false;
                }
                else if (!i_Game.M_GameBoard.M_UnexposedCellsIndex.Contains(playerCellChoice))
                {
                    Console.WriteLine("The cell you chose has allready been exposed, therefore you cant choose it.");
                    isValid = false;
                }
            }
            return isValid;
        }

        private static (int, int) convertPlayerChoiseToIntTuple(string i_PlayerCellChoise)
        {
            int numRows = (i_PlayerCellChoise[0] - '0' - 1);
            int numCols = (i_PlayerCellChoise[1] - 'A');
            return (numRows, numCols);
        }

        private static bool isUserWantToPlayAgain()
        {
            bool isUserWantToPlayAgain = false;
            string playAgainQuestion = string.Format(
@"Great game! Would you like to play another one? (enter y/n and then press enter)");
            Console.WriteLine(playAgainQuestion);
            string userAnswer = Console.ReadLine();
            while (!(userAnswer.Equals("y") || userAnswer.Equals("n")))
            {
                Console.WriteLine("Invalid answer. please press 'y' for playing another game and 'n' to stop playing.");
                userAnswer = Console.ReadLine();
            }

            if (userAnswer.Equals("y"))
            {
                isUserWantToPlayAgain = true;
            }
            else if (userAnswer.Equals("n"))
            {
                isUserWantToPlayAgain = false;
            }
            return isUserWantToPlayAgain;
        }

        private static void printGameBoard(Game i_Game)
        {
            StringBuilder board = new StringBuilder();
            string first2Lines = buildFirst2Lines(i_Game);
            board.Append(first2Lines);
            int numRows = i_Game.M_NumRows;
            string newLine = string.Format("{0}  ", Environment.NewLine);
            for (int i = 0; i < numRows; i++)
            {
                board.Append(newLine);
                board.Append(buildLine(i_Game, i));
                board.Append(buildNewLineAndSeparationLine(i_Game));
            }
            Console.WriteLine(board);
        }

        // $G$ NTT-001 (-10) You should have used string formatting instead of concatenation.
        private static string buildFirst2Lines(Game i_Game)
        {
            int numColls = i_Game.M_NumColls;
            StringBuilder first2Lines = new StringBuilder();
            first2Lines.Append("      ");
            char letter = 'A';
            for (int i = 0; i < numColls; i++)
            {
                first2Lines.Append((char)(letter + i));
                first2Lines.Append("   ");
            }

            first2Lines.Append(buildNewLineAndSeparationLine(i_Game));
            return first2Lines.ToString();
        }

        private static string buildNewLineAndSeparationLine(Game i_Game)
        {
            int numOfSeparators = (4 * i_Game.M_NumColls) + 1;
            string newLine = string.Format("{0}    ", Environment.NewLine);
            StringBuilder separationLine = new StringBuilder();
            separationLine.Append(newLine);
            for (int i = 0; i < numOfSeparators; i++)
            {
                separationLine.Append("=");
            }

            return separationLine.ToString();
        }

        private static string buildLine(Game i_Game, int i_CurrentRow)
        {
            StringBuilder line = new StringBuilder();
            line.Append((i_CurrentRow + 1).ToString());
            string collsSeparator = " | "; 

            for (int j = 0; j < i_Game.M_NumColls; j++)
            {
                line.Append(collsSeparator);
                line.Append(getSpaceOrCellValue(i_Game, i_CurrentRow, j));
            }
            line.Append(" |");
            return line.ToString();

        }

        private static string getSpaceOrCellValue(Game i_Game, int i_CurrentRow, int i_CurrentColl)
        {
            char spaceOrCellValue = ' ';
            if (i_Game.M_GameBoard.M_Board[i_CurrentRow, i_CurrentColl].m_Exposed)
            {
                spaceOrCellValue = i_Game.M_GameBoard.M_Board[i_CurrentRow, i_CurrentColl].m_Value;
            }
            return spaceOrCellValue.ToString();
        }
    }
}
