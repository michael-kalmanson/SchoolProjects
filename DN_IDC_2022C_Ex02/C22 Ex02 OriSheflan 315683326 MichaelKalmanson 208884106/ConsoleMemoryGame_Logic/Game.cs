using System;
namespace ConsoleMemoryGame_Logic
{
    public class Game
    {
        private GameBoard m_GameBoard;
        private Player m_Player1;
        private Player m_Player2;
        private bool m_Player1Turn;
        private int m_NumRows;
        private int m_NumColls;

        public Game(int i_NumRows, int i_NumColls, bool i_VsComputer, string i_NameOfPlayer1, string i_NameOfPlayer2 = "Computer")
        {
            this.m_NumRows = i_NumRows;
            this.m_NumColls = i_NumColls;
            this.m_GameBoard = new GameBoard(i_NumRows, i_NumColls);
            this.m_Player1 = new Player(i_NameOfPlayer1, false);
            this.m_Player2 = new Player(i_NameOfPlayer2, i_VsComputer);
            this.m_Player1Turn = true;
        }

        public bool IsGameEnded()
        {
            return (this.m_GameBoard.M_UnexposedCellsIndex.Count == 0);
        }

        public void ComputerRevealCell()
        {
            var it = m_GameBoard.M_UnexposedCellsIndex.GetEnumerator();
            Random rnd = new Random();
            int numOfIterates = rnd.Next(0, this.m_GameBoard.M_UnexposedCellsIndex.Count);
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
            this.m_GameBoard.RevealGameBoardCell(i_IndexOfCell);
        }

        public bool IsMatchingCells()
        {
            Cell cell1 = this.m_GameBoard.M_Board[this.m_GameBoard.M_FirstCurrentExposedCellIndex.Item1, this.m_GameBoard.M_FirstCurrentExposedCellIndex.Item2];
            Cell cell2 = this.m_GameBoard.M_Board[this.m_GameBoard.M_SecondCurrentExposedCellIndex.Item1, this.m_GameBoard.M_SecondCurrentExposedCellIndex.Item2];
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
                this.m_GameBoard.CloseExposedCells();
                this.m_Player1Turn = !this.m_Player1Turn;
            }

            this.m_GameBoard.ResetChosenCells();
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

        public GameBoard M_GameBoard
        {
            get
            {
                return this.m_GameBoard;
            }
        }

        public Player M_Player1
        {
            get
            {
                return m_Player1;
            }
        }

        public Player M_Player2
        {
            get
            {
                return m_Player2;
            }
        }

        public bool M_Player1Turn
        {
            get
            {
                return m_Player1Turn;
            }
        }

        public int M_NumRows
        {
            get
            {
                return m_NumRows;
            }
        }

        public int M_NumColls
        {
            get
            {
                return m_NumColls;
            }
        }
    }
}
