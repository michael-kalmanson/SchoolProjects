using System;
using System.Collections.Generic;

namespace WindowsMemoryGame_Logic
{
    public class GameBoard
    {
        private readonly Cell[,] r_Board;
        private (int, int) m_FirstCurrentlyExposedCellIndex;
        private (int, int) m_SecondCurrentlyExposedCellIndex;
        private readonly HashSet<(int, int)> r_UnexposedCellsIndex;

        public GameBoard(int i_NumRows, int i_NumColls)
        {
            this.r_Board = new Cell[i_NumRows, i_NumColls];
            initializeGameBoard(this.r_Board);
            this.m_FirstCurrentlyExposedCellIndex = (-1, -1);
            this.m_SecondCurrentlyExposedCellIndex = (-1, -1);
            this.r_UnexposedCellsIndex = new HashSet<(int, int)>();
            initializeUnexposedCellsSetForComputer(this.r_UnexposedCellsIndex);
        }

        private static void initializeGameBoard(Cell[,] io_Board)
        {
            insertValuesToCards(io_Board);
            MixBoard(io_Board);
        }

        private static void insertValuesToCards(Cell[,] io_Board)
        {
            char newABCValue = 'A';
            bool flagForInsertsTwoNewValues = false;

            for (int i = 0; i < io_Board.GetLength(0); i++)
            {
                for (int j = 0; j < io_Board.GetLength(1); j++)
                {
                    io_Board[i, j].m_Value = newABCValue;
                    if (flagForInsertsTwoNewValues)
                    {
                        newABCValue++;
                    }
                    flagForInsertsTwoNewValues = !flagForInsertsTwoNewValues;
                }
            }
        }

        private static void MixBoard(Cell[,] io_Board)
        {
            Random rnd = new Random();
            int numsOfSwaps = io_Board.Length;
            for (int i = 0; i < numsOfSwaps; i++)
            {
                SwapRandomallyTwoCellsInBoard(io_Board, rnd);
            }
        }

        private static void SwapRandomallyTwoCellsInBoard(Cell[,] io_Board, Random i_Rnd)
        {
            int firstRndRowIndex = i_Rnd.Next(0, io_Board.GetLength(0));
            int firstRndColIndex = i_Rnd.Next(0, io_Board.GetLength(1));

            int secondRndRowIndex = i_Rnd.Next(0, io_Board.GetLength(0));
            int secondRndColIndex = i_Rnd.Next(0, io_Board.GetLength(1));

            Cell tempCellForSwap = io_Board[firstRndRowIndex, firstRndColIndex];
            io_Board[firstRndRowIndex, firstRndColIndex] = io_Board[secondRndRowIndex, secondRndColIndex];
            io_Board[secondRndRowIndex, secondRndColIndex] = tempCellForSwap;
        }

        private void initializeUnexposedCellsSetForComputer(HashSet<(int, int)> io_unexposedCells)
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    io_unexposedCells.Add((i, j));
                }
            }
        }

        public void RevealGameBoardCell((int, int) i_IndexOfCell)
        {
            this.Board[i_IndexOfCell.Item1, i_IndexOfCell.Item2].m_Exposed = true;

            if (this.FirstCurrentExposedCellIndex == (-1, -1))
            {
                this.FirstCurrentExposedCellIndex = i_IndexOfCell;
            }
            else
            {
                this.SecondCurrentExposedCellIndex = i_IndexOfCell;
            }

            r_UnexposedCellsIndex.Remove(i_IndexOfCell);

        }

        public (int, int) FirstCurrentExposedCellIndex
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

        public (int, int) SecondCurrentExposedCellIndex
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

        public Cell[,] Board
        {
            get
            {
                return this.r_Board;
            }
        }

        public HashSet<(int, int)> UnexposedCellsIndex
        {
            get
            {
                return this.r_UnexposedCellsIndex;
            }
        }

        public void CloseExposedCells()
        {
            this.r_UnexposedCellsIndex.Add(this.FirstCurrentExposedCellIndex);
            this.Board[this.FirstCurrentExposedCellIndex.Item1, this.FirstCurrentExposedCellIndex.Item2].m_Exposed = false;

            this.r_UnexposedCellsIndex.Add(this.SecondCurrentExposedCellIndex);
            this.Board[this.SecondCurrentExposedCellIndex.Item1, this.SecondCurrentExposedCellIndex.Item2].m_Exposed = false;
        }

        public void ResetChosenCells()
        {
            this.FirstCurrentExposedCellIndex = (-1, -1);
            this.FirstCurrentExposedCellIndex = (-1, -1);
        }
    }
}
