using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_Othelo
{
    class Board
    {

        private int m_BoardSize = 0;
        private int[,] m_Board = null;
        private bool m_BoardIsFull = false;

        public Board(int i_BoardSize)
        {
            m_BoardSize = i_BoardSize;
            m_Board = new int[i_BoardSize, i_BoardSize];

            // init middle tokens
            m_Board[(m_BoardSize / 2) - 1, (m_BoardSize / 2) - 1] = -1;
            m_Board[m_BoardSize / 2, m_BoardSize / 2] = -1;
            m_Board[(m_BoardSize / 2) - 1, m_BoardSize / 2] = 1;
            m_Board[m_BoardSize / 2, (m_BoardSize / 2) - 1] = 1;
        }

        public int Size
        {
            get { return m_BoardSize; }
            set { m_BoardSize = value; }
        }

        public bool BoardFull
        {
            get
            {
                return m_BoardIsFull;
            }

            set
            {
                m_BoardIsFull = value;
            }
        }

        public int getTokenByMatrixCoordinate(int i_row, int i_col)
        {
            return m_Board[i_row, i_col];
        }

        public int getTokenByMatrixCoordinate(Handler i_coordinates)
        {
            return m_Board[i_coordinates.Row, i_coordinates.Col];
        }

        public void addCurrentLegalMovesToBoard(List<Handler> i_currentLegalMovesArray)
        {
            foreach (Handler legalMove in i_currentLegalMovesArray)
            {
                m_Board[legalMove.Row, legalMove.Col] = 2;     
            }
        }

        public List<Handler> getCurrentLegalMovesArray(Player i_currentPlayer, Player i_otherPlayer)
        {
            List<Handler> o_LegalMovesArray = new List<Handler>();

            for (int i = 1; i < m_BoardSize - 1; i++)
            {
                for (int j = 1; j < m_BoardSize - 1; j++)
                {
                    List<Handler> o_LegalSurroundingCoordinates = new List<Handler>();
                    Handler coordinateToCheck = new Handler(-1, -1);
                    Handler legalCoordinate = null;

                    coordinateToCheck.Row = i;
                    coordinateToCheck.Col = j;
                    if (m_Board[i, j] == (int)i_otherPlayer.Color)
                    {
                        if ((legalCoordinate = getLegalCoordinateForDirection(coordinateToCheck,
                                                                              i_currentPlayer,
                                                                              i_otherPlayer,
                                                                              1, 0, 0, 0)) != null)
                        {
                            o_LegalSurroundingCoordinates.Add(legalCoordinate);
                        }

                        if ((legalCoordinate = getLegalCoordinateForDirection(coordinateToCheck,
                                                                              i_currentPlayer,
                                                                              i_otherPlayer,
                                                                              1, 0, 1, 0)) != null)
                        {
                            o_LegalSurroundingCoordinates.Add(legalCoordinate);
                        }

                        if ((legalCoordinate = getLegalCoordinateForDirection(coordinateToCheck,
                                                                              i_currentPlayer,
                                                                              i_otherPlayer,
                                                                              0, 0, 1, 0)) != null)
                        {
                            o_LegalSurroundingCoordinates.Add(legalCoordinate);
                        }

                        if ((legalCoordinate = getLegalCoordinateForDirection(coordinateToCheck,
                                                                              i_currentPlayer,
                                                                              i_otherPlayer,
                                                                              0, 1, 1, 0)) != null)
                        {
                            o_LegalSurroundingCoordinates.Add(legalCoordinate);
                        }

                        if ((legalCoordinate = getLegalCoordinateForDirection(coordinateToCheck,
                                                                              i_currentPlayer,
                                                                              i_otherPlayer,
                                                                              0, 1, 0, 0)) != null)
                        {
                            o_LegalSurroundingCoordinates.Add(legalCoordinate);
                        }

                        if ((legalCoordinate = getLegalCoordinateForDirection(coordinateToCheck,
                                                                              i_currentPlayer,
                                                                              i_otherPlayer,
                                                                              0, 1, 0, 1)) != null)
                        {
                            o_LegalSurroundingCoordinates.Add(legalCoordinate);
                        }

                        if ((legalCoordinate = getLegalCoordinateForDirection(coordinateToCheck,
                                                                              i_currentPlayer,
                                                                              i_otherPlayer,
                                                                              0, 0, 0, 1)) != null)
                        {
                            o_LegalSurroundingCoordinates.Add(legalCoordinate);
                        }

                        if ((legalCoordinate = getLegalCoordinateForDirection(coordinateToCheck,
                                                                              i_currentPlayer,
                                                                              i_otherPlayer,
                                                                              1, 0, 0, 1)) != null)
                        {
                            o_LegalSurroundingCoordinates.Add(legalCoordinate);
                        }

                        foreach (Handler surroundingCoordinate in o_LegalSurroundingCoordinates)
                        {
                            bool existsInArray = false;
                            foreach (Handler legalMove in o_LegalMovesArray)
                            {
                                if (surroundingCoordinate.Equals(legalMove))
                                {
                                    existsInArray = true;
                                }
                            }

                            if (existsInArray == false)
                            {
                                o_LegalMovesArray.Add(surroundingCoordinate);
                            }
                        }
                    }
                }
            }

            return o_LegalMovesArray;
        }

        private Handler getLegalCoordinateForDirection(Handler i_CoordinateToCheck, Player i_currentPlayer, Player i_otherPlayer, int N, int S, int E, int W)
        {
            Handler inDirection = new Handler(
                                                        i_CoordinateToCheck.Row + (S - N),
                                                        i_CoordinateToCheck.Col + (E - W));
            Handler counterDirection = new Handler(
                                                            i_CoordinateToCheck.Row - (S - N),
                                                            i_CoordinateToCheck.Col - (E - W));

            if (getTokenByMatrixCoordinate(inDirection) == 0 ||
                getTokenByMatrixCoordinate(inDirection) == 2 ||
                (getTokenByMatrixCoordinate(counterDirection) != 0 &&
                getTokenByMatrixCoordinate(counterDirection) != 2))
            {
                return null;
            }

            int row = inDirection.Row, col = inDirection.Col;
            while ((row < m_BoardSize) && (row >= 0) && (col < m_BoardSize) && (col >= 0))
            {
                if (m_Board[row, col] == 0 || m_Board[row, col] == 2)
                {
                    return null;
                }

                if (m_Board[row, col] == (int)i_currentPlayer.Color)
                {
                    return counterDirection;
                }

                row += S - N;
                col += E - W;
            }

            return null;
        }

        public void addToken(Player i_CurrentPlayer, Player i_OtherPlayer, Handler i_ChosenCoordinates)
        {                                                                                  // check all 8 directions
            flipCells(i_ChosenCoordinates, i_CurrentPlayer, i_OtherPlayer, 1, 0, 0, 0);
            flipCells(i_ChosenCoordinates, i_CurrentPlayer, i_OtherPlayer, 1, 0, 1, 0);
            flipCells(i_ChosenCoordinates, i_CurrentPlayer, i_OtherPlayer, 0, 0, 1, 0);
            flipCells(i_ChosenCoordinates, i_CurrentPlayer, i_OtherPlayer, 0, 1, 1, 0);
            flipCells(i_ChosenCoordinates, i_CurrentPlayer, i_OtherPlayer, 0, 1, 0, 0);
            flipCells(i_ChosenCoordinates, i_CurrentPlayer, i_OtherPlayer, 0, 1, 0, 1);
            flipCells(i_ChosenCoordinates, i_CurrentPlayer, i_OtherPlayer, 0, 0, 0, 1);
            flipCells(i_ChosenCoordinates, i_CurrentPlayer, i_OtherPlayer, 1, 0, 0, 1);

            
            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    if (m_Board[i, j] == 2)
                    {
                        m_Board[i, j] = 0;
                    }
                }
            }

            m_Board[i_ChosenCoordinates.Row, i_ChosenCoordinates.Col] = (int)i_CurrentPlayer.Color;
        }

        private void flipCells(Handler i_ChosenCoordinates, Player i_CurrentPlayer, Player i_OtherPlayer, int N, int S, int E, int W)
        {
            int row, coll;
            bool flip = false;
            List<Handler> cellsToFlip = new List<Handler>();

            row = i_ChosenCoordinates.Row + (S - N);
            coll = i_ChosenCoordinates.Col + (E - W);

            while (row < m_BoardSize && row >= 0 && coll < m_BoardSize && coll >= 0)
            {
                if (m_Board[row, coll] == 2 || m_Board[row, coll] == 0)
                {
                    break;
                }
                else if (m_Board[row, coll] == (int)i_OtherPlayer.Color)
                {
                    cellsToFlip.Add(new Handler(row, coll));
                }
                else if (m_Board[row, coll] == (int)i_CurrentPlayer.Color)
                {
                    flip = true;
                    break;
                }

                row += S - N;
                coll += E - W;
            }

            if (flip == true)
            {
                foreach (Handler coordinate in cellsToFlip)
                {
                    m_Board[coordinate.Row, coordinate.Col] = (int)i_CurrentPlayer.Color;
                }
            }
        }
    }
}
