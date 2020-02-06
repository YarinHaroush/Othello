using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Othello
{
    public partial class OthelloGameSettings : Form
    {
        private int m_BoardSize = 6;
        private string m_PlayerType = string.Empty;

        public OthelloGameSettings()
        {
            InitializeComponent();
        }

        private void buttonChangeBoardSize_Click(object sender, EventArgs e)
        {
            string currentMsg = this.buttonChangeBoardSize.Text;
            StringBuilder currentSize = new StringBuilder();
            StringBuilder newMsg = new StringBuilder();
            int size;

            foreach(char c in currentMsg)
            {
                if (char.IsDigit(c))
                {
                    currentSize.Append(c.ToString());
                }
                else if (c == 'X')
                {
                    break;
                }
            }

            size = int.Parse(currentSize.ToString());
            if (size == 12)
            {
                size = 6;
            }
            else
            {
                size += 2;
            }

            newMsg.Append("Board Size: " + size + "X" + size + " (click to increase)");
            this.buttonChangeBoardSize.Text = newMsg.ToString();
            m_BoardSize = size;
        }

        private void buttonPlayAgainstComputer_Click(object sender, EventArgs e)
        {
            m_PlayerType = "Computer";
            this.Close();
        }

        private void buttonPlayAgainstFriend_Click(object sender, EventArgs e)
        {
            m_PlayerType = "Person";
            this.Close();
        }

        public int BoardSize
        {
            get
            {
                return m_BoardSize;
            }            
        }

        public string PlayerType
        {
            get
            {
                return m_PlayerType;
            }
        }
    }
}
