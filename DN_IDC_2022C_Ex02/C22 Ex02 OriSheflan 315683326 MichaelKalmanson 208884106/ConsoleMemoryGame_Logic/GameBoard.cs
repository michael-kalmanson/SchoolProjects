using System;
using System.Collections.Generic;

namespace ConsoleMemoryGame_Logic
{
    public class GameBoard
    {
        private Cell[,] m_Board;
        private (int, int) m_FirstCurrentlyExposedCellIndex;
        private (int, int) m_SecondCurrentlyExposedCellIndex;
        // $G$ DSN-999 (-3) This Hashset should be readonly.
        private HashSet<(int, int)> m_UnexposedCellsIndex;

        public GameBoard(int i_NumRows, int i_NumColls)
        {
            this.m_Board = new Cell[i_NumRows, i_NumColls];
            initializeGameBoard(this.m_Board);
            this.m_FirstCurrentlyExposedCellIndex = (-1, -1);
            this.m_SecondCurrentlyExposedCellIndex = (-1, -1);
            this.m_UnexposedCellsIndex = new HashSet<(int, int)>();
            initializeUnexposedCellsSetForComputer(this.m_UnexposedCellsIndex);
        }

        private static void initializeGameBoard(Cell[,] io_board)
        {
            insertValuesToCards(io_board);
            MixBoard(io_board);
        }

        private static void insertValuesToCards(Cell[,] io_board)
        {
            char newABCValue = 'A';
            bool flagForInsertsTwoNewValues = false;

            for (int i = 0; i < io_board.GetLength(0); i++)
            {
                for (int j = 0; j < io_board.GetLength(1); j++)
                {
                    io_board[i, j].m_Value = newABCValue;
                    if (flagForInsertsTwoNewValues)
                    {
                        newABCValue++;
                    }
                    flagForInsertsTwoNewValues = !flagForInsertsTwoNewValues;
                }
            }
        }

        private static void MixBoard(Cell[,] io_board)
        {
            Random rnd = new Random();
            int numsOfSwaps = io_board.Length;
            for (int i = 0; i < numsOfSwaps; i++)
            {
                SwapRandomallyTwoCellsInBoard(io_board, rnd);
            }
        }

        private static void SwapRandomallyTwoCellsInBoard(Cell[,] io_board, Random rnd)
        {
            int firstRndRowIndex = rnd.Next(0, io_board.GetLength(0));
            int firstRndColIndex = rnd.Next(0, io_board.GetLength(1));

            int secondRndRowIndex = rnd.Next(0, io_board.GetLength(0));
            int secondRndColIndex = rnd.Next(0, io_board.GetLength(1));

            Cell tempCellForSwap = io_board[firstRndRowIndex, firstRndColIndex];
            io_board[firstRndRowIndex, firstRndColIndex] = io_board[secondRndRowIndex, secondRndColIndex];
            io_board[secondRndRowIndex, secondRndColIndex] = tempCellForSwap;
        }

        private void initializeUnexposedCellsSetForComputer(HashSet<(int, int)> io_unexposedCells)
        {
            for (int i = 0; i < M_Board.GetLength(0); i++)
            {
                for (int j = 0; j < M_Board.GetLength(1); j++)
                {
                    io_unexposedCells.Add((i, j));
                }
            }
        }

        public void RevealGameBoardCell((int, int) i_IndexOfCell)
        {
            this.M_Board[i_IndexOfCell.Item1, i_IndexOfCell.Item2].m_Exposed = true;

            if (this.M_FirstCurrentExposedCellIndex == (-1, -1))
            {
                this.M_FirstCurrentExposedCellIndex = i_IndexOfCell;
            }
            else
            {
                this.M_SecondCurrentExposedCellIndex = i_IndexOfCell;
            }

            m_UnexposedCellsIndex.Remove(i_IndexOfCell);

        }

        public (int, int) M_FirstCurrentExposedCellIndex
        {
            get
            {
                return this.m_FirstCurrentlyExposedCellIndex;
            }
            set
            {
                this.m_FirstCurrentlyExposedCellIndex = value;
            }
        }

        public (int, int) M_SecondCurrentExposedCellIndex
        {
            get
            {
                return this.m_SecondCurrentlyExposedCellIndex;
            }
            set
            {
                this.m_SecondCurrentlyExposedCellIndex = value;
            }
        }

        public Cell[,] M_Board
        {
            get
            {
                return this.m_Board;
            }
        }

        public HashSet<(int, int)> M_UnexposedCellsIndex
        {
            get
            {
                return this.m_UnexposedCellsIndex;
            }
            set
            {
                this.m_UnexposedCellsIndex = value;
            }
        }

        public void CloseExposedCells()
        {
            this.m_UnexposedCellsIndex.Add(this.M_FirstCurrentExposedCellIndex);
            this.M_Board[this.M_FirstCurrentExposedCellIndex.Item1, this.M_FirstCurrentExposedCellIndex.Item2].m_Exposed = false;

            this.m_UnexposedCellsIndex.Add(this.M_SecondCurrentExposedCellIndex);
            this.M_Board[this.M_SecondCurrentExposedCellIndex.Item1, this.M_SecondCurrentExposedCellIndex.Item2].m_Exposed = false;
        }

        public void ResetChosenCells()
        {
            this.M_FirstCurrentExposedCellIndex = (-1, -1);
            this.M_FirstCurrentExposedCellIndex = (-1, -1);
        }
    }
}
