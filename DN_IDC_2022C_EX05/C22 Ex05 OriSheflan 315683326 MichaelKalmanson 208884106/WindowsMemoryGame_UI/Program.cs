using System;

namespace WindowsMemoryGame_UI
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            GameUI gameUI = new GameUI();
            gameUI.RunMemoryGame();
        }
    }
}
