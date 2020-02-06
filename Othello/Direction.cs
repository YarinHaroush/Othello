using System;
using System.Collections.Generic;
using System.Text;

namespace Othello
{
    internal struct Direction
    {
        private int m_Horizontal, m_Vertical;

        public Direction(int i_Vertical, int i_Horizontal)
        {
            m_Horizontal = i_Horizontal;
            m_Vertical = i_Vertical;
        }

        public int Horizontal
        {
            get
            {
                return m_Horizontal;
            }

            set
            {
                m_Horizontal = value;
            }
        }

        public int Vertical
        {
            get
            {
                return m_Vertical;
            }

            set
            {
                m_Vertical = value;
            }
        }

    }
}
