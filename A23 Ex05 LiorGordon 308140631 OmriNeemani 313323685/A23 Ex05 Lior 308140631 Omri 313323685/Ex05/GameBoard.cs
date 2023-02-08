using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05
{
    public enum eGameModes
    {
        SinglePlayer,
        Versus
    }
    public partial class GameBoard : Form
    {
        public eGameModes SelectMode;
        Logic GameLogic = new Logic();
        string m_title;
        Disk[,] dynamicBox;
        int m_BoardSize;
        public GameBoard()
        {
            InitializeComponent();
        }

        public GameBoard(int boardSize)
        {
            InitializeComponent();
            InitializeBoard(boardSize);
        }

        private void InitializeBoard(int boardSize)
        {
            GameLogic.CpuHasMoved += GameLogic_CpuHasMoved;
            GameLogic.CpuMakeMove += GameLogic_CpuMakeMove;

            m_BoardSize = boardSize;
            dynamicBox = new Disk[boardSize, boardSize];
            int numOfRanks = 0, numOfFiles = 0, squareNum = 0; // Ranks - Horizontal squares, Files - Vertical squares, squareNum - total num of disks.
            int bPosX = 0;
            int bPosY = 0;

            while (numOfFiles < boardSize)
            {
                bPosY = numOfFiles * 50;
                while (numOfRanks < boardSize)
                {
                    dynamicBox[numOfRanks, numOfFiles] = new Disk();
                    dynamicBox[numOfRanks, numOfFiles].State = eDiskState.Empty;
                    dynamicBox[numOfRanks, numOfFiles].BorderStyle = BorderStyle.Fixed3D;
                    Controls.Add(dynamicBox[numOfRanks, numOfFiles]);
                    bPosX = (numOfRanks * 50);
                    dynamicBox[numOfRanks, numOfFiles].Location = new Point(bPosX, bPosY);
                    dynamicBox[numOfRanks, numOfFiles].Size = new Size(50, 50);
                    dynamicBox[numOfRanks, numOfFiles].Click += square_Click;
                    numOfRanks++;
                    squareNum++;
                }
                numOfRanks = 0;
                numOfFiles++;
            }
            // places both yellow and red disks in the center
            dynamicBox[boardSize/2, boardSize/2].State = eDiskState.Yellow;
            dynamicBox[boardSize/2 - 1, boardSize/2 - 1].State = eDiskState.Yellow;
            dynamicBox[boardSize/2, boardSize/2 - 1].State = eDiskState.Red;
            dynamicBox[boardSize/2 - 1, boardSize/2].State = eDiskState.Red;

            GameLogic.CheckBoard(dynamicBox, boardSize);

            if (SelectMode == eGameModes.SinglePlayer)
            {
                GameLogic.RandomizeCPUPlayer();
                if (GameLogic.r_Player1.m_Computer == true)
                    GameLogic.CPUPlay(dynamicBox, boardSize);
            }
        }

        private void GameLogic_CpuMakeMove()
        {
            GameLogic.CPUPlay(dynamicBox, m_BoardSize);
        }

        private void GameLogic_CpuHasMoved()
        {
            GameLogic.m_numOfTurnsSkipped = 0;
            GameLogic.switchTurns();
            GameLogic.CheckBoard(dynamicBox, m_BoardSize);
        }

        private void square_Click(object sender, EventArgs e)
        {
            Disk dsk = sender as Disk;
            if (dsk.State == eDiskState.Placeable)
            {
                dsk.State = GameLogic.CurrPlayer.playerDisk.State;
                GameLogic.m_numOfTurnsSkipped = 0;
                GameLogic.UpdateBoard(dynamicBox, m_BoardSize, dsk);
                GameLogic.switchTurns();
                GameLogic.CheckBoard(dynamicBox, m_BoardSize);
            }

            if (GameLogic.m_Turn == ePlayer.Player1)
                Text = m_title + " | Red's turn";
            else
                Text = m_title + " | Yellow's turn";

            if (GameLogic.m_GameEnded == 1)
            {
                string message = $"{GameLogic.m_winnerName} won!\n" +
                    $"Red: {GameLogic.r_Player1.m_Score} [{GameLogic.r_Player1.m_TotalScore}] \n" +
                    $"Yellow: {GameLogic.r_Player2.m_Score} [{GameLogic.r_Player2.m_TotalScore}] \n" +
                    $"Would you like another round?";
                string title = "Game Over";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    GameLogic.ResetBoard(dynamicBox, m_BoardSize);
                    GameLogic.CheckBoard(dynamicBox, m_BoardSize);
                    GameLogic.m_GameEnded = 0;
                }
                else
                {
                    Close(); 
                }
            }
        }

        private void Game_Load(object sender, EventArgs e)
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            CenterToScreen();
            if (SelectMode == eGameModes.SinglePlayer)
                Text = "Player vs CPU";
            else
                Text = "Player vs Player";
            m_title = Text;
            Text = m_title + " | Red's turn";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
