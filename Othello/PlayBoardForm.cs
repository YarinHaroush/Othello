using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Othello
{
    internal partial class PlayBoardForm : Form
    {
        Board m_Board;
        int m_NextMove;
        char m_CurrentPlayerSign;

        public PlayBoardForm(Board i_board)
        {
            InitializeComponent(i_board);
        }

        private void buttonPlayTurn_Click(object sender, EventArgs e)
        {
            int col, row, place = 0;

            col = ((Button)sender).Location.X / ((Button)sender).Width;
            row = ((Button)sender).Location.Y / ((Button)sender).Height;
            place = col * 10;
            place += row;
            m_NextMove = place;
            UI.GameManagement(this, NextMove, m_CurrentPlayerSign);

            if (m_CurrentPlayerSign == 'X')
            {
                m_CurrentPlayerSign = 'O';
            }
            else
            {
                m_CurrentPlayerSign = 'X';
            }
            BoardRefresh();

        }

        public void BoardRefresh()
        {
            int currentRow = 0, currentCol = 0;
            GameRulesAndLogic.CheckValidMoves(m_Board, m_CurrentPlayerSign);

            for (currentRow = 0; currentRow < m_Board.Rows; currentRow++)
            {
                for (currentCol = 0; currentCol < m_Board.Columns; currentCol++)
                {
                    if (m_Board.PlayBoard[currentRow][currentCol] == m_Board.FirstPlayer.Sign)
                    {
                        if (m_Board.FirstPlayer.Name == "Black")
                        {
                            setBlackButton(m_GameBoardButtons[currentRow][currentCol]);
                        }
                        else
                        {
                            setWhiteButton(m_GameBoardButtons[currentRow][currentCol]);
                        }
                    }
                    else if (m_Board.PlayBoard[currentRow][currentCol] == m_Board.SecondPlayer.Sign)
                    {
                        if (m_Board.SecondPlayer.Name == "Black")
                        {
                            setBlackButton(m_GameBoardButtons[currentRow][currentCol]);
                        }
                        else
                        {
                            setWhiteButton(m_GameBoardButtons[currentRow][currentCol]);
                        }
                    }

                    if (m_Board.PlayBoard[currentRow][currentCol] == m_Board.AvilableMoveSign)
                    {
                        m_GameBoardButtons[currentRow][currentCol].BackColor = Color.LawnGreen;
                        m_GameBoardButtons[currentRow][currentCol].Enabled = true;
                    }
                    else
                    {
                        if (m_GameBoardButtons[currentRow][currentCol].BackColor == Color.LawnGreen)
                        {
                            m_GameBoardButtons[currentRow][currentCol].BackColor = Color.LightGray;
                        }
                        m_GameBoardButtons[currentRow][currentCol].Enabled = false;
                    }
                }
            }

        }

        public int NextMove
        {
            get
            {
                return m_NextMove;
            }
        }

        public Board Board
        {
            get
            {
                return m_Board;
            }
        }
    }
}
