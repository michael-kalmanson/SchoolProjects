namespace ConsoleMemoryGame_Logic
{
    public class Player
    {
        private int m_Score;
        // $G$ CSS-999 (-3) readonly members should be in form of r_PascalCased
        readonly public string m_PlayerName;
        private bool m_IsComputer;

        public Player(string i_Name, bool i_IsComputer)
        {
            this.m_PlayerName = i_Name;
            this.m_IsComputer = i_IsComputer;
            this.m_Score = 0;
        }

        public int M_Score
        {
            get { return m_Score; }
        }

        public string M_PlayerName
        {
            get { return m_PlayerName; }
        }

        public bool M_IsComputer
        {
            get { return m_IsComputer; }
        }

        public void AddPointToScore()
        {
            this.m_Score++;
        }

        // $G$ CSS-027 (-2) Unnecessary blank lines.
    }
}
