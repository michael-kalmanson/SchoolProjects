namespace ConsoleMemoryGame_Logic
{
    public struct Cell
    {
        public bool m_Exposed;
        public char m_Value;

        public Cell(char i_Value)
        {
            this.m_Value = i_Value;
            this.m_Exposed = false;
        }

        public void toString()
        {
            char chrToPrint = ' ';
            if (this.m_Exposed)
            {
                chrToPrint = this.m_Value;
            }
            System.Console.WriteLine();
        }

        public bool Equals(Cell cell2)
        {
            return this.m_Value == cell2.m_Value;
        }

        public static bool operator==(Cell cell1, Cell cell2)
        {
            return cell1.Equals(cell2);
        }

        public static bool operator!=(Cell cell1, Cell cell2)
        {
            return !cell1.Equals(cell2);
        }
    }
}
