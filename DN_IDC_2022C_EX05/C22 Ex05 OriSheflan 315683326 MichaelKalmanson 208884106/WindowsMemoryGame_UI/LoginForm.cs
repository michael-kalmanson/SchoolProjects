using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsMemoryGame_UI
{
    public partial class LoginForm : Form
    {
        private List<string> m_BoardSize;
        private int m_IndexForBoardSize;
        private bool m_IsLoggedIn = false;

        public LoginForm()
        {
            InitializeComponent();
            InitializeBoardSize();
        }
        
        private void InitializeBoardSize()
        {
            m_BoardSize = new List<string>()
            {"4 x 4", "4 x 5", "4 x 6", "5 x 4", "5 x 6", "6 x 4", "6 x 5", "6 x 6"};
            m_IndexForBoardSize = 0;
        }

        public bool IsLoggedIn
        {
            get { return m_IsLoggedIn; }
        }

        private void checkBoxAgainstAFriend_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAgainstAFriend.CheckState == CheckState.Checked)
            {
                textBoxSecondPlayerName.Enabled = true;
                textBoxSecondPlayerName.Text = "";
                textBoxSecondPlayerName.BackColor = Color.White;
            }
            else
            {
                textBoxSecondPlayerName.Enabled = false;
                textBoxSecondPlayerName.Text = "- Computer -";
                textBoxSecondPlayerName.BackColor = Color.Silver;
            }
        }

        private void buttonBoardSize_Click(object sender, EventArgs e)
        {
            m_IndexForBoardSize = (m_IndexForBoardSize + 1) % m_BoardSize.Count;
            buttonBoardSize.Text = m_BoardSize[m_IndexForBoardSize];

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (textBoxFirstPlayerName.Text == string.Empty || textBoxSecondPlayerName.Text == string.Empty)
            {
                new NoNameErrorForm().ShowDialog();
            }
            else
            {
                m_IsLoggedIn = true;
                this.Close();
            }
        }
    }
}
