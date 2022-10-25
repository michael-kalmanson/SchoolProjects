namespace WindowsMemoryGame_UI
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxFirstPlayerName = new System.Windows.Forms.TextBox();
            this.textBoxSecondPlayerName = new System.Windows.Forms.TextBox();
            this.checkBoxAgainstAFriend = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonBoardSize = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxFirstPlayerName
            // 
            this.textBoxFirstPlayerName.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxFirstPlayerName.Location = new System.Drawing.Point(142, 12);
            this.textBoxFirstPlayerName.Name = "textBoxFirstPlayerName";
            this.textBoxFirstPlayerName.Size = new System.Drawing.Size(123, 20);
            this.textBoxFirstPlayerName.TabIndex = 10;        
            // 
            // textBoxSecondPlayerName
            // 
            this.textBoxSecondPlayerName.BackColor = System.Drawing.Color.Silver;
            this.textBoxSecondPlayerName.Enabled = false;
            this.textBoxSecondPlayerName.Location = new System.Drawing.Point(142, 42);
            this.textBoxSecondPlayerName.Name = "textBoxSecondPlayerName";
            this.textBoxSecondPlayerName.Size = new System.Drawing.Size(123, 20);
            this.textBoxSecondPlayerName.TabIndex = 20;
            this.textBoxSecondPlayerName.Text = "- Computer -";
            // 
            // checkBoxAgainstAFriend
            // 
            this.checkBoxAgainstAFriend.AutoSize = true;
            this.checkBoxAgainstAFriend.Location = new System.Drawing.Point(299, 44);
            this.checkBoxAgainstAFriend.Name = "checkBoxAgainstAFriend";
            this.checkBoxAgainstAFriend.Size = new System.Drawing.Size(102, 17);
            this.checkBoxAgainstAFriend.TabIndex = 30;
            this.checkBoxAgainstAFriend.Text = "Against a Friend";
            this.checkBoxAgainstAFriend.UseVisualStyleBackColor = true;
            this.checkBoxAgainstAFriend.CheckedChanged += new System.EventHandler(this.checkBoxAgainstAFriend_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "First Player Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Second Player Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Board Size:";
            // 
            // buttonBoardSize
            // 
            this.buttonBoardSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonBoardSize.FlatAppearance.BorderColor = System.Drawing.Color.RosyBrown;
            this.buttonBoardSize.Location = new System.Drawing.Point(26, 121);
            this.buttonBoardSize.Name = "buttonBoardSize";
            this.buttonBoardSize.Size = new System.Drawing.Size(107, 68);
            this.buttonBoardSize.TabIndex = 40;
            this.buttonBoardSize.Text = "4 x 4";
            this.buttonBoardSize.UseVisualStyleBackColor = false;
            this.buttonBoardSize.Click += new System.EventHandler(this.buttonBoardSize_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.Lime;
            this.buttonStart.Location = new System.Drawing.Point(326, 166);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 50;
            this.buttonStart.Text = "Start!";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.buttonStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(435, 201);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonBoardSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxAgainstAFriend);
            this.Controls.Add(this.textBoxSecondPlayerName);
            this.Controls.Add(this.textBoxFirstPlayerName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox textBoxFirstPlayerName;
        private System.Windows.Forms.TextBox textBoxSecondPlayerName;
        private System.Windows.Forms.CheckBox checkBoxAgainstAFriend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonBoardSize;
        private System.Windows.Forms.Button buttonStart;

        public string FirstPlayerName
        {
            get
            {
                return this.textBoxFirstPlayerName.Text;
            }
        }

        public string SecondPlayerName
        {
            get
            {
                return this.textBoxSecondPlayerName.Text;
            }
        }

        public string TextButtonBoardSize
        {
            get
            {
                return this.buttonBoardSize.Text;
            }
        }

        public bool CheckBoxAgainstAFriend
        {
            get
            {
                return this.checkBoxAgainstAFriend.Checked;
            }
        }
    }
}