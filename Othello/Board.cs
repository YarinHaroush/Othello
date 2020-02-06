using System;
using System.Collections.Generic;
using System.Text;

namespace Othello
{
    internal class Board
    {
        private static int s_Columns, s_Rows;
        private static char[][] m_Board;
        private const bool v_m_IsComputer = true;
        private Player m_FirstPlayer = new Player("White", 'X', !v_m_IsComputer);
        private Player m_SecondPlayer;
        private bool m_Computer = true;
        private readonly char m_AvilableMoveSign;
        private readonly char m_EmptySign;

        public Board(int i_BoardSize, char i_AvilableMoveSign, char i_EmptySign, string PlayerType)
        {
            s_Rows = s_Columns = i_BoardSize;
            m_AvilableMoveSign = i_AvilableMoveSign;
            m_EmptySign = i_EmptySign;
            m_Computer = PlayerType == "Computer";
            m_SecondPlayer = new Player("Black", 'O', m_Computer);
            boardInitialized();
        }

        public Player FirstPlayer
        {
            get
            {
                return m_FirstPlayer;
            }

            set
            {
                m_FirstPlayer = value;
            }
        }

        public Player SecondPlayer
        {
            get
            {
                return m_SecondPlayer;
            }

            set
            {
                m_SecondPlayer = value;
            }
        }

        public bool TwoPlayers
        {
            get
            {
                return !m_Computer;
            }

            set
            {
                m_Computer = !value;
            }
        }

        public int Columns
        {
            get
            {
                return s_Columns;
            }

            set
            {
                if ((value == 6) || (value == 8))
                {
                    s_Columns = value - 1;
                }
            }
        }

        public int Rows
        {
            get
            {
                return s_Rows;
            }

            set
            {
                if ((value == 6) || (value == 8))
                {
                    s_Rows = value - 1;
                }
            }
        }

        public char[][] PlayBoard
        {
            get
            {
                return m_Board;
            }

            set
            {
                m_Board = value;
            }
        }

        public char AvilableMoveSign
        {
            get
            {
                return m_AvilableMoveSign;
            }
        }

        public char EmptySign
        {
            get
            {
                return m_EmptySign;
            }
        }

        private void boardInitialized()
        {
            int currentRow = 0, currentCol = 0;
            m_Board = new char[s_Rows][];

            for (currentRow = 0; currentRow < s_Rows; currentRow++)
            {
                m_Board[currentRow] = new char[s_Columns];
            }

            for (currentRow = 0; currentRow < s_Rows; currentRow++)
            {
                for (currentCol = 0; currentCol < s_Columns; currentCol++)
                {
                    m_Board[currentRow][currentCol] = m_EmptySign;
                }
            }

            m_Board[(s_Rows / 2) - 1][(s_Columns / 2) - 1] = 'O';
            m_Board[(s_Rows / 2) - 1][s_Columns / 2] = 'X';
            m_Board[s_Rows / 2][s_Columns / 2] = 'O';
            m_Board[s_Rows / 2][(s_Columns / 2) - 1] = 'X';
        }
    }
}
