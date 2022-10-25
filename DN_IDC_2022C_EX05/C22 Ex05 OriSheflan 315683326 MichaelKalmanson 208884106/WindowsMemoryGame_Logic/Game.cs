using System;

namespace WindowsMemoryGame_Logic
{
    public class Game
    {
        private readonly GameBoard r_GameBoard;
        private Player m_Player1;
        private Player m_Player2;
        private bool m_Player1Turn;
        private int m_NumRows;
        private int m_NumColls;
        public Game(int i_NumRows, int i_NumColls, bool i_VsComputer, string i_NameOfPlayer1, string i_NameOfPlayer2 = "Computer")
        {
            this.m_NumRows = i_NumRows;
            this.m_NumColls = i_NumColls;
            this.r_GameBoard = new GameBoard(i_NumRows, i_NumColls);
            this.m_Player1 = new Player(i_NameOfPlayer1, false);
            this.m_Player2 = new Player(i_NameOfPlayer2, i_VsComputer);
            this.m_Player1Turn = true;
        }

        public bool IsGameEnded()
        {
            return (this.r_GameBoard.UnexposedCellsIndex.Count == 0);
        }

        public void ComputerRevealCell()
        {
            var it = r_GameBoard.UnexposedCellsIndex.GetEnumerator();
            Random rnd = new Random();
            int numOfIterates = rnd.Next(0, this.r_GameBoard.UnexposedCellsIndex.Count);
            it.MoveNext();
            (int, int) IndexOfCellToReveal = it.Current;
            for (int i = 0; i < numOfIterates; i++)
            {
                it.MoveNext();
                IndexOfCellToReveal = it.Current;

            }
            RevealCell(IndexOfCellToReveal);
        }

        public void RevealCell((int, int) i_IndexOfCell)
        {
            this.r_GameBoard.RevealGameBoardCell(i_IndexOfCell);
        }

        public bool IsMatchingCells()
        {
            Cell cell1 = this.r_GameBoard.Board[this.r_GameBoard.FirstCurrentExposedCellIndex.Item1, this.r_GameBoard.FirstCurrentExposedCellIndex.Item2];
            Cell cell2 = this.r_GameBoard.Board[this.r_GameBoard.SecondCurrentExposedCellIndex.Item1, this.r_GameBoard.SecondCurrentExposedCellIndex.Item2];
            return cell1 == cell2;
        }

        public void FinishTurn()
        {
            if (this.IsMatchingCells())
            {
                this.AddPoints();
            }
            else
            {
                this.r_GameBoard.CloseExposedCells();
                this.m_Player1Turn = !this.m_Player1Turn;
            }

            this.r_GameBoard.ResetChosenCells();
        }


        public void AddPoints()
        {
            if (m_Player1Turn)
            {
                this.m_Player1.AddPointToScore();
            }
            else
            {
                this.m_Player2.AddPointToScore();
            }
        }

        public ((int, int), (int ,int)) GetCurrentTurnTwoExposedCellsIndexes()
        {
            (int, int) firstCellIndex, secomdCellIndex;
            firstCellIndex = this.GameBoard.FirstCurrentExposedCellIndex;
            secomdCellIndex = this.GameBoard.SecondCurrentExposedCellIndex;

            return (firstCellIndex, secomdCellIndex);
        }

        public GameBoard GameBoard
        {
            get
            {
                return this.r_GameBoard;
            }
        }

        public Player Player1
        {
            get
            {
                return m_Player1;
            }
        }

        public Player Player2
        {
            get
            {
                return m_Player2;
            }
        }

        public bool Player1Turn
        {
            get
            {
                return m_Player1Turn;
            }
        }

        public int NumRows
        {
            get
            {
                return m_NumRows;
            }
        }

        public int NumColls
        {
            get
            {
                return m_NumColls;
            }
        }
    }
}