using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_Othelo
{
    public enum ePlayerColor
    {
        White = -1,
        Black = 1
    }

    class Player
    {
        private string m_Name = null;
        private int m_Points = 0;
        private ePlayerColor m_Color;
        private bool m_isBot = false;
        private int m_LegalMovesCount = -1;

        public Player(string i_Name, ePlayerColor i_Color, bool i_isBot)
        {
            m_Name = i_Name;
            m_Color = i_Color;
            m_isBot = i_isBot;
        }

        public ePlayerColor Color
        {
            get
            {
                return m_Color;
            }
        }

        public string Name
        {
            get
            {
                return m_Name;
            }
        }

        public int Points
        {
            get
            {
                return m_Points;
            }

            set
            {
                m_Points = value;
            }
        }

        public int LegalMovesCount
        {
            get
            {
                return m_LegalMovesCount;
            }

            set
            {
                m_LegalMovesCount = value;
            }
        }

        public bool IsBot
        {
            get
            {
                return m_isBot;
            }
        }
    }
}
