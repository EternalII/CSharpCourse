using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_Othelo
{
    class Handler
    {
        private int m_Row = -1;
        private int m_Col = -1;

        public Handler(int i_Row, int i_Col)
        {
            m_Row = i_Row;
            m_Col = i_Col;
        }

        public int Row
        {
            get
            {
                return m_Row;
            }

            set
            {
                m_Row = value;
            }
        }

        public int Col
        {
            get
            {
                return m_Col;
            }

            set
            {
                m_Col = value;
            }
        }

        public static bool isLegalCoordinate(int i_Row, int i_Col, int i_BoardSize)
        {
            if (i_Row < 0 || i_Row > i_BoardSize - 1)
            {
                return false;
            }
            else if (i_Col < 0 || i_Col > i_BoardSize - 1)
            {
                return false;
            }

            return true;
        }

        public static bool foundCoordinatesInArray(Handler i_Coordinates, List<Handler> i_CoordinatesArray)
        {
            if (i_Coordinates == null)
            {
                return false;
            }

            foreach (Handler coordinate in i_CoordinatesArray)
            {
                if (coordinate.m_Row == i_Coordinates.m_Row && coordinate.m_Col == i_Coordinates.m_Col)
                {
                    return true;
                }
            }

            return false;
        }

        public static Handler parseCoordinates(string i_coordinatesStr)
        {
            if (i_coordinatesStr.Length < 2)
            {
                return null;
            }

            Handler o_Coordinates = null;
            int rowValue, collValue;
            char row, coll;

            row = i_coordinatesStr[0];
            rowValue = row - '0' - 1;

            if (i_coordinatesStr.Length > 2)
            {
                coll = i_coordinatesStr[2];
            }
            else
            {
                coll = i_coordinatesStr[1];
            }

            if (coll >= 'A' && coll <= 'H')
            {
                collValue = coll - 'A';
            }
            else if (coll >= 'a' && coll <= 'h')
            {
                collValue = coll - 'a';
            }
            else
            {                                  
                collValue = coll - '0' - 1;
            }

            o_Coordinates = new Handler(rowValue, collValue);
            return o_Coordinates;
        }

        public bool isLegalCoordinate(int i_BoardSize)
        {
            return isLegalCoordinate(m_Row, m_Col, i_BoardSize);
        }
    }
}
