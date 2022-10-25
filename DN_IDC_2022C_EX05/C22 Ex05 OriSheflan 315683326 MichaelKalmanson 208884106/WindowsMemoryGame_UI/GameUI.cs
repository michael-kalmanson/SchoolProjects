using WindowsMemoryGame_Logic;
using System.Windows.Forms;

namespace WindowsMemoryGame_UI
{
    public class GameUI
    {
        private GameForm m_GameForm;
        // $G$ DSN-999 (-3) This member should have been readonly.
        private LoginForm m_LoginForm;
        private Game m_Game;

        public GameUI()
        {
            m_LoginForm = new LoginForm();
        }

        public void RunMemoryGame()
        {
            m_LoginForm.ShowDialog();
            if (m_LoginForm.IsLoggedIn)
            {
                buildGame();
                PlayGame();
            }
        }

        public void PlayGame()
        {
            runGameForm();
            if (m_Game.GameBoard.UnexposedCellsIndex.Count == 0)
            { 
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                string messageBoxText = announceWinner();
                DialogResult dialogResult = MessageBox.Show(messageBoxText, "End Game Message", buttons);
                if (dialogResult == DialogResult.Yes)
                {
                    buildGame();
                    PlayGame();
                }
            }
        }

        // $G$ CSS-028 (-5) A method shouldn't contain more than 1 return statement.
        private string announceWinner()
        {
            string anotherGameQuestion = "Would you like to play another game Sir/Madam?";
            if (m_Game.Player1.Score == m_Game.Player2.Score)
            {
                string tieMessage = string.Format(
@"It was a tie!
Both players finished with a score of {0}!
{1}", m_Game.Player1.Score.ToString(), anotherGameQuestion);
                return tieMessage;
            }
            else
            {
                string winner;
                string winnerScore;
                string loser;
                string loserScore;

                if (m_Game.Player1.Score > m_Game.Player2.Score)
                {
                    winner = m_Game.Player1.PlayerName;
                    winnerScore = m_Game.Player1.Score.ToString();
                    loser = m_Game.Player2.PlayerName;
                    loserScore = m_Game.Player2.Score.ToString();
                }
                else
                {
                    winner = m_Game.Player2.PlayerName;
                    winnerScore = m_Game.Player2.Score.ToString();
                    loser = m_Game.Player1.PlayerName;
                    loserScore = m_Game.Player1.Score.ToString();
                }

                string winnerMsg = string.Format(
@"Congragulations {0}! You won the game with a score of {1}.
{2} you were the loser with a score of {3}. Try harder next time...
{4}", winner, winnerScore, loser, loserScore, anotherGameQuestion);
                return winnerMsg;
            }
        }

        // $G$ CSS-999 (-3) Public methods should start with an upper-case letter.
        public void buildGame()
        {
            int numOfRows = getNumOfRows(m_LoginForm.TextButtonBoardSize);
            int numOfCols = getNumOfcols(m_LoginForm.TextButtonBoardSize);
            bool vsComputer = !m_LoginForm.CheckBoxAgainstAFriend;
            string NameOfPlayer1 = m_LoginForm.FirstPlayerName;
            string NameOfPlayer2 = m_LoginForm.SecondPlayerName;
            m_Game = new Game(numOfRows, numOfCols, vsComputer, NameOfPlayer1, NameOfPlayer2);
            m_GameForm = new GameForm(m_Game);
        }

        private void runGameForm()
        {
            m_GameForm.ShowDialog();
        }

        private static int getNumOfRows(string i_BoardSize)
        {
            return (int)char.GetNumericValue(i_BoardSize[0]);
        }

        private static int getNumOfcols(string i_BoardSize)
        { 
            return (int)char.GetNumericValue(i_BoardSize[4]);
        }

        public Game Game 
        {
            get
            {
                return this.m_Game;
            }
        }
    }
}
