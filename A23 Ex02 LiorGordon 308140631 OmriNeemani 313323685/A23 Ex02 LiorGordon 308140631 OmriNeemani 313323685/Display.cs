using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_Othelo
{
    class Display
    {
        public static void printUI(string message, Player currentPlayer, Player playerOne, Player playerTwo, Board gameBoard)
        {
            StringBuilder uiString = new StringBuilder();

            uiString.Append(getTitleString());
            uiString.Append(getDividerString(gameBoard.Size));
            uiString.Append(message + Environment.NewLine);
            uiString.Append(getDividerString(gameBoard.Size));
            uiString.Append(getStatsString(currentPlayer, playerOne, playerTwo));
            uiString.Append(getDividerString(gameBoard.Size));
            uiString.Append(getBoardString(gameBoard));
            uiString.Append(getDividerString(0));

            Console.Write(uiString);
        }

        public static void printDivider(int boardSize = 0)
        {
            Console.WriteLine(getDividerString(boardSize));
        }

        public static string getDividerString(int boardSize = 0)
        {
            string dividerString = string.Empty;

            if (boardSize != 0)
            {
                dividerString += "--";
                for (int i = 0; i < boardSize; i++)
                {
                    dividerString += "----";
                }

                dividerString += "-";
            }

            dividerString += Environment.NewLine;

            return dividerString;
        }

        public static string getTitleString()
        {
            return "Othelo\\Reversii - Lior Gordon & Omri Neemani" + Environment.NewLine;
        }

        public static void printMessage(string message)
        {
            Console.WriteLine("Message: {0}", message);
        }

        public static string getStatsString(Player currentPlayer, Player player1, Player player2)
        {
            string statsString = "Turn:" + currentPlayer.Name + string.Empty +
                                 " || Points: P1:" + player1.Points +
                                 ", P2:" + player1.Points
                                 + Environment.NewLine;

            return statsString;
        }

        public static string getBoardString(Board i_Board)
        {
            int i, j, k, currentCellToken, boardSize = i_Board.Size;
            char charToPrint = 'A';
            string boardString = string.Empty;

            
            boardString += "   ";
            for (i = 0; i < boardSize; i++)
            {
                boardString += " " + charToPrint++ + "  ";
            }

            boardString += Environment.NewLine;
            boardString += "  =";
            for (i = 0; i < boardSize; i++)
            {
                boardString += "====";
            }

            boardString += Environment.NewLine;

            
            for (i = 0; i < boardSize; i++)
            {
                boardString += string.Empty + (i + 1) + " ";
                for (j = 0; j < boardSize; j++)
                {
                    currentCellToken = i_Board.getTokenByMatrixCoordinate(i, j);
                    if (currentCellToken == -1)
                    {
                        charToPrint = 'O';
                    }
                    else if (currentCellToken == 1)
                    {
                        charToPrint = 'X';
                    }
                    else if (currentCellToken == 2)
                    {
                        charToPrint = '=';
                    }
                    else
                    {
                        charToPrint = ' ';
                    }

                    boardString += "| " + charToPrint + " ";
                }

                boardString += "|" + Environment.NewLine;

                
                boardString += "  ";
                for (k = 0; k < boardSize; k++)
                {
                    boardString += "====";
                }

                boardString += "=" + Environment.NewLine;
            }

            return boardString;
        }

        public static void updateUI(string message, Player currentPlayer, Player player1, Player player2, Board gameBoard)
        {
            
            Ex02.ConsoleUtils.Screen.Clear();          
            printUI(message, currentPlayer, player1, player2, gameBoard);
        }

        public static void initGame(out string i_player1, out string i_player2, out int i_BoardSize, out bool i_isMultiplayer)
        {
            Console.WriteLine("Othelo\\Reversii - Lior Gordon & Omri Neemani");
            Console.WriteLine("-------------------------");

            Console.WriteLine("Choose game mode:");
            Console.WriteLine("1) Single Player");
            Console.WriteLine("2) Multiplayer");
            int isMultiplayerInput = int.Parse(Console.ReadLine());
            while (isMultiplayerInput != 1 && isMultiplayerInput != 2)
            {
                Console.WriteLine("Please choose 1 or 2");
                isMultiplayerInput = int.Parse(Console.ReadLine());
            }

            i_isMultiplayer = isMultiplayerInput == 1 ? false : true;

            //Display.printDivider(i_BoardSize);

            Console.WriteLine("Enter first player's name:");
            i_player1 = Console.ReadLine();
            if (i_isMultiplayer == true)
            {
                Console.WriteLine("Enter second player's name:");
                i_player2 = Console.ReadLine();
            }
            else
            {
                i_player2 = "Computer";
                Console.WriteLine("{0}, you will play against the computer", i_player1);
            }

            Console.WriteLine("Choose board size:" + Environment.NewLine +
                "1) 6x6" + Environment.NewLine +
                "2) 8x8");
            int boardSizeChoice = int.Parse(Console.ReadLine());
            while (boardSizeChoice != 1 && boardSizeChoice != 2)
            {
                Console.WriteLine("Choose option 1 or 2 for board size:");
                try
                {
                    boardSizeChoice = int.Parse(Console.ReadLine());
                }
                catch(Exception)
                {
                    Console.WriteLine("Invalid input, please try again:");
                }
            }

            i_BoardSize = boardSizeChoice == 1 ? 6 : 8;

            Display.printDivider(i_BoardSize);
        }

        public static bool printEndGame(Player i_WinningPlayer, Player i_player1, bool i_IsSinglePlayer)
        {
            char restartGame;

            if (i_WinningPlayer == null)
            {
                printMessage("Its a tie!");
            }
            else if (i_IsSinglePlayer == true)
            {
                if (i_WinningPlayer == i_player1)
                {
                    printMessage("Congratulations " + i_WinningPlayer.Name + ", you won!");
                }
                else
                {
                    printMessage(i_player1.Name + " you lost, maybe next time");
                }
            }
            else
            {                                                                       
                printMessage("Congratulations " + i_WinningPlayer.Name + ", you won! you are a true Othelo King!");
            }

            printMessage("Restart Game?\ninsert y/n");
            restartGame = char.Parse(Console.ReadLine());

            if (restartGame == 'y' || restartGame == 'Y')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
