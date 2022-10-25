using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using WindowsMemoryGame_Logic;

namespace WindowsMemoryGame_UI
{
    public partial class GameForm : Form
    {
        private Game m_Game;
        private bool m_IsFirstTurn = true;
        private readonly GameButton[,] r_ButtonMatrix;
        public GameForm(Game i_Game)
        {
            m_Game = i_Game;
            r_ButtonMatrix = new GameButton[m_Game.NumRows, m_Game.NumColls];
            buildButtonMatrix();
            InitializeComponent();
            updateScoreLabels();
        }

        private void updateScoreLabels()
        {
            Player player1 = m_Game.Player1;
            Player player2 = m_Game.Player2;
            GameButton bottomLeftButton = r_ButtonMatrix[0, m_Game.NumColls - 1];
            Point bottomLeftButtonLocation = new Point(bottomLeftButton.Left, bottomLeftButton.Bottom);

            string currentPlayer = string.Format("Current Player: {0}", m_Game.Player1Turn ? player1.PlayerName : player2.PlayerName);
            LabelCurrentPlayer.Text = currentPlayer;
            LabelCurrentPlayer.BackColor = (m_Game.Player1Turn ? Color.YellowGreen : Color.MediumSlateBlue);
            Point labelLocation = new Point(bottomLeftButtonLocation.X, bottomLeftButtonLocation.Y + 50);
            LabelCurrentPlayer.Location = labelLocation;

            string player1Score = string.Format("{0}: {1} Pairs", player1.PlayerName, player1.Score);
            labelPlayer1Score.Text = player1Score;
            labelLocation = new Point(labelLocation.X, labelLocation.Y + 35);
            labelPlayer1Score.Location = labelLocation;

            string player2Score = string.Format("{0}: {1} Pairs", player2.PlayerName, player2.Score);
            labelPlayer2Score.Text = player2Score;
            labelLocation = new Point(labelLocation.X, labelLocation.Y + 35);
            labelPlayer2Score.Location = labelLocation;

            labelPlayer1Score.Refresh();
            labelPlayer2Score.Refresh();
            LabelCurrentPlayer.Refresh();
        }

        private void buildButtonMatrix()
        {
            int numRows = r_ButtonMatrix.GetLength(0);
            int numColls = r_ButtonMatrix.GetLength(1);

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numColls; j++)
                {
                    GameButton button = new GameButton(m_Game.GameBoard.Board[i, j]);
                    r_ButtonMatrix[i, j] = button;
                    string buttonName = string.Format("button [{0},{1}]", i, j);
                    button.Index = (i, j);
                    button.Name = buttonName;
                    this.Controls.Add(button);
                    button.Click += GameButton_Click;
                    button.Location = new Point(20 + i * 100, 20 + j * 100);
                }
            }
        }

        private void GameButton_Click(object sender, EventArgs e)
        {
            GameButton gameButton = sender as GameButton;
            gameButton.Click -= GameButton_Click;
            playTurn(gameButton);

            if (!m_Game.Player1Turn && m_Game.Player2.IsComputer)
            {
                playComputerTurn();
            }
            if (m_Game.IsGameEnded())
            {
                this.Close();
            }
            m_IsFirstTurn = !m_IsFirstTurn;
        }

        private void playTurn(GameButton i_GameButton)
        {
            if (!m_IsFirstTurn)
            {
                playSecondTurn(i_GameButton);
                m_Game.FinishTurn();
                updateScoreLabels();
            }
            else
            {
                exposePlayerCellByColor(i_GameButton);
            }
        }

        private void playSecondTurn(GameButton i_SecondClickedButton)
        {
            exposePlayerCellByColor(i_SecondClickedButton);
            i_SecondClickedButton.Refresh();
            if (!m_Game.IsMatchingCells())
            {
                (int, int) firstCellIndex = m_Game.GameBoard.FirstCurrentExposedCellIndex;
                GameButton firstClickedButton = r_ButtonMatrix[firstCellIndex.Item1, firstCellIndex.Item2];
                Thread.Sleep(500);
                resetButton(firstClickedButton);
                resetButton(i_SecondClickedButton);
                firstClickedButton.Refresh();
                i_SecondClickedButton.Refresh();
            }
        }

        private void resetButton(GameButton i_Button)
        {
            i_Button.HideCell();
            i_Button.BackColor = Color.Silver;
            i_Button.Click += GameButton_Click;
        }

        private void exposePlayerCellByColor(GameButton i_GameButton)
        {
            m_Game.RevealCell(i_GameButton.Index);
            if (m_Game.Player1Turn)
            {
                i_GameButton.BackColor = Color.YellowGreen;
                i_GameButton.ShowCell();
            }
            else if (!m_Game.Player2.IsComputer)
            {
                i_GameButton.BackColor = Color.MediumSlateBlue;
                i_GameButton.ShowCell();
            }
        }

        private void playComputerTurn()
        {
            m_Game.ComputerRevealCell();
            (int, int) indexOfChosenButton = m_Game.GameBoard.FirstCurrentExposedCellIndex;
            GameButton firstComputerchosenButton = r_ButtonMatrix[indexOfChosenButton.Item1, indexOfChosenButton.Item2];
            firstComputerchosenButton.BackColor = Color.MediumSlateBlue;
            firstComputerchosenButton.ShowCell();
            firstComputerchosenButton.Refresh();
            Thread.Sleep(500);

            m_Game.ComputerRevealCell();
            indexOfChosenButton = m_Game.GameBoard.SecondCurrentExposedCellIndex;
            GameButton secondComputerchosenButton = r_ButtonMatrix[indexOfChosenButton.Item1, indexOfChosenButton.Item2];
            secondComputerchosenButton.BackColor = Color.MediumSlateBlue;
            secondComputerchosenButton.ShowCell();
            secondComputerchosenButton.Refresh();
            Thread.Sleep(500);

            if (!m_Game.IsMatchingCells())
            {
                resetComputerButton(firstComputerchosenButton, secondComputerchosenButton);
                m_Game.FinishTurn();
                updateScoreLabels();
            }
            else
            {
                firstComputerchosenButton.Click -= GameButton_Click;
                secondComputerchosenButton.Click -= GameButton_Click;
                m_Game.FinishTurn();
                if (!m_Game.IsGameEnded())
                {
                    this.playComputerTurn();
                }
            }
        }

        private void resetComputerButton(GameButton i_FirstComputerchosenButton, GameButton i_SecondComputerchosenButton)
        {
            i_FirstComputerchosenButton.HideCell();
            i_FirstComputerchosenButton.BackColor = Color.Silver;
            i_SecondComputerchosenButton.HideCell();
            i_SecondComputerchosenButton.BackColor = Color.Silver;
        }
    }
}
