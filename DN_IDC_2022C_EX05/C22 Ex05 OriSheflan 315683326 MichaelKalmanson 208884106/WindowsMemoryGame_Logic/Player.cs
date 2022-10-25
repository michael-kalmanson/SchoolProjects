namespace WindowsMemoryGame_Logic
{
    public class Player
    {
        private int m_Score;
        readonly public string r_PlayerName;
        private bool m_IsComputer;

        public Player(string i_Name, bool i_IsComputer)
        {
            this.r_PlayerName = i_Name;
            this.m_IsComputer = i_IsComputer;
            this.m_Score = 0;
        }

        public int Score
        {
            get { return m_Score; }
        }

        public string PlayerName
        {
            get { return r_PlayerName; }
        }

        public bool IsComputer
        {
            get { return m_IsComputer; }
        }

        public void AddPointToScore()
        {
            this.m_Score++;
        }
    }
}