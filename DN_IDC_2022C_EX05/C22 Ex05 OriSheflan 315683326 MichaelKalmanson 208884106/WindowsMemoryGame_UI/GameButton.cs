using System.Windows.Forms;
using WindowsMemoryGame_Logic;

namespace WindowsMemoryGame_UI
{
    public class GameButton : Button
    {
        Cell m_Cell;
        (int, int) m_Index;

        public GameButton(Cell i_Cell)
        {
            m_Cell = i_Cell;
            InitializeComponent();
        }

        public (int, int) Index
        {
            get
            {
                return m_Index;
            }
            set
            {
                this.m_Index = value;
            }
        }

        public Cell Cell
        {
            get
            {
                return m_Cell;
            }
            set
            {
                this.m_Cell = value;
            }
        }

        private void InitializeComponent()
        {
            //this.gameButton1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gameButton1
            // 
            this.BackColor = System.Drawing.Color.Silver;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "gameButton";
            this.Size = new System.Drawing.Size(75, 75);
            this.TabIndex = 0;
            this.UseVisualStyleBackColor = false;
            this.ResumeLayout(false);
        }

        public void ShowCell()
        {
            this.Text = m_Cell.ToString();
        }

        public void HideCell()
        {
            this.Text = string.Empty;
        }
    }
}
