using System;
using System.Collections.Generic;

namespace Ex05
{
    public delegate void CpuMove();
    public enum ePlayer
    {
        Player1,
        Player2
    }
    public class Logic
    {
        public ePlayer m_Turn { get; set; }
        public readonly Player1 r_Player1 = new Player1();
        public readonly Player2 r_Player2 = new Player2();
        public Player CurrPlayer, Opponent;
        public int m_GameEnded = 0;
        public string m_winnerName;
        bool m_CanMove;
        public int m_numOfTurnsSkipped;
        public event CpuMove CpuHasMoved, CpuMakeMove;

        public Logic()
        {
            CurrPlayer = r_Player1;
            Opponent = r_Player2;
            m_Turn = ePlayer.Player1;
        }

        public void switchTurns()
        {
            if (m_Turn == ePlayer.Player1)
            {
                CurrPlayer = r_Player2;
                Opponent = r_Player1;
                m_Turn = ePlayer.Player2;
            }
            else
            {
                CurrPlayer = r_Player1;
                Opponent = r_Player2;
                m_Turn = ePlayer.Player1;
            }

        }

        public void CheckBoard(object board, int boardSize)
        {
            Disk[,] placePiece = board as Disk[,];

            clearPlaceables(board);
            m_CanMove = false;

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (placePiece[i, j].State == CurrPlayer.playerDisk.State)
                    {
                        checkAvailableMoves(board, boardSize, i, j);
                    }
                }
            }

            if (!m_CanMove)
            {
                switchTurns();
                m_numOfTurnsSkipped++;
                clearPlaceables(board);
                if (m_numOfTurnsSkipped > 2)
                {
                    CountScore(board);
                    m_GameEnded = 1;
                }
                else
                    CheckBoard(board, boardSize);
            }

            if (CurrPlayer.m_Computer)
                CpuMakeMove?.Invoke();
        }

        int checkAvailableMoves(object board, int boardSize, int i, int j)
        {
            int availableMoves = 0;
            availableMoves += checkFlippable(board, boardSize, i - 1, j, -1, 0); // left
            availableMoves += checkFlippable(board, boardSize, i + 1, j, 1, 0); // right
            availableMoves += checkFlippable(board, boardSize, i, j - 1, 0, -1); // up
            availableMoves += checkFlippable(board, boardSize, i, j + 1, 0, 1); // down
            availableMoves += checkFlippable(board, boardSize, i - 1, j - 1, -1, -1); // upleft
            availableMoves += checkFlippable(board, boardSize, i + 1, j - 1, 1, -1); // upright
            availableMoves += checkFlippable(board, boardSize, i - 1, j + 1, -1, 1); // downleft
            availableMoves += checkFlippable(board, boardSize, i + 1, j + 1, 1, 1); // downright

            return availableMoves;
        }
        int checkFlippable(object board, int boardSize, int x, int y, int faceX, int faceY)
        {
            Disk[,] checkBoard = board as Disk[,];

            if ((x >= 0) && (x < boardSize) && (y >= 0) && (y < boardSize))
            {
                if (checkBoard[x, y].State == Opponent.playerDisk.State)
                {
                    while ((x >= 0) && (x < boardSize) && (y >= 0) && (y < boardSize))
                    {
                        x += faceX;
                        y += faceY;
                        if ((x >= 0) && (x < boardSize) && (y >= 0) && (y < boardSize))
                        {
                            if (checkBoard[x, y].State == eDiskState.Empty || checkBoard[x, y].State == eDiskState.Placeable)
                            {
                                checkBoard[x, y].State = eDiskState.Placeable;
                                m_CanMove = true;
                                checkBoard[x, y].m_FaceX = faceX;
                                checkBoard[x, y].m_FaceY = faceY;
                                checkBoard[x, y].m_PosX = x;
                                checkBoard[x, y].m_PosY = y;

                                return 1;
                            }
                            else
                                return 0;
                        }
                    }
                }
            }
            return 0;
        }

        public void UpdateBoard(object i_board, int boardSize, Disk placedDisk)
        {

            Disk[,] board = i_board as Disk[,];
            int x = placedDisk.m_PosX;
            int y = placedDisk.m_PosY;

            for (int faceX = -1; faceX<2; faceX++)
            {
                for (int faceY = -1; faceY<2; faceY++)
                {
                    x += faceX;
                    y += faceY;
                    if (IsFlippable(board, boardSize, x, y, faceX, faceY))
                    {
                        flipPieces(board, x, y, faceX, faceY);
                    }
                    x = placedDisk.m_PosX;
                    y = placedDisk.m_PosY;
                }
            }
        }

        bool IsFlippable(object board, int boardSize, int x, int y, int faceX, int faceY)
        {
            Disk[,] checkBoard = board as Disk[,];

            if ((x >= 0) && (x < boardSize) && (y >= 0) && (y < boardSize))
            {
                if (checkBoard[x, y].State == Opponent.playerDisk.State)
                {
                    while ((x >= 0) && (x < boardSize) && (y >= 0) && (y < boardSize))
                    {
                        x += faceX;
                        y += faceY;
                        if ((x >= 0) && (x < boardSize) && (y >= 0) && (y < boardSize))
                        {
                            if (checkBoard[x, y].State == CurrPlayer.playerDisk.State)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false ;
        }

        void flipPieces(object i_board, int x, int y, int faceX, int faceY)
        {
            Disk[,] board = i_board as Disk[,];

            while (board[x, y].State == Opponent.playerDisk.State)
            {
                board[x, y].State = CurrPlayer.playerDisk.State;
                x += faceX;
                y += faceY;
            }
        }


        void clearPlaceables(object board)
        {
            Disk[,] clearBoard = board as Disk[,];

            foreach (Disk square in clearBoard)
            {
                if (square.State == eDiskState.Placeable)
                    square.State = eDiskState.Empty;
            }
        }

        void CountScore(object i_Board)
        {
            Disk[,] board = i_Board as Disk[,];

            foreach (Disk each in board)
            {
                if (each.State == eDiskState.Red)
                {
                    r_Player1.m_Score++;
                }
                else if (each.State == eDiskState.Yellow)
                    r_Player2.m_Score++;
            }

            if (r_Player1.m_Score > r_Player2.m_Score)
            {
                r_Player1.m_TotalScore++;
                m_winnerName = r_Player1.m_Name;
            }
            else if (r_Player1.m_Score < r_Player2.m_Score)
            {
                r_Player2.m_TotalScore++;
                m_winnerName = r_Player2.m_Name;
            }
        }

        public void ResetBoard(object i_Board, int i_BoardSize)
        {
            Disk[,] board = i_Board as Disk[,];

            r_Player1.m_Score = 0;
            r_Player2.m_Score = 0;

            foreach (Disk each in board)
            {
                each.State = eDiskState.Empty;
            }
            board[i_BoardSize / 2, i_BoardSize / 2].State = eDiskState.Yellow;
            board[i_BoardSize / 2 - 1, i_BoardSize / 2 - 1].State = eDiskState.Yellow;
            board[i_BoardSize / 2, i_BoardSize / 2 - 1].State = eDiskState.Red;
            board[i_BoardSize / 2 - 1, i_BoardSize / 2].State = eDiskState.Red;
        }

        public void CPUPlay(object i_Board, int i_boardSize)
        {
            Disk[,] board = i_Board as Disk[,];
            List<Disk> movableLocations = new List<Disk>();

            foreach (Disk place in board)
            {
                if (place.State == eDiskState.Placeable)
                {
                    movableLocations.Add(place);
                }
            }

            var random = new Random();
            int index = random.Next(movableLocations.Count);

            if (movableLocations.Count == 0)
                return;
            movableLocations[index].State = CurrPlayer.playerDisk.State;
            UpdateBoard(board, i_boardSize, movableLocations[index]);

            CpuHasMoved?.Invoke();
            
        }

        public void RandomizeCPUPlayer()
        {
            var rand = new Random();
            if (rand.Next(2) == 0)
            {
                r_Player1.m_Computer = true;
            }
            else
            {
                r_Player2.m_Computer = true;
            }
        }

    }

    public abstract class Player
    {
        public Disk playerDisk { get; }
        public int m_Score = 0;
        public int m_TotalScore = 0;
        public string m_Name;
        public bool m_Computer = false;

        protected Player()
        {
            playerDisk = new Disk();
            playerDisk.State = eDiskState.Empty;
        }
    }

    public class Player1 : Player
    {
        public Player1()
        {
            m_Name = "Player 1";
            playerDisk.State = eDiskState.Red;
        }

    }

    public class Player2 : Player
    {
        public Player2()
        {
            m_Name = "Player 2";
            playerDisk.State = eDiskState.Yellow;
        }
    }
}
