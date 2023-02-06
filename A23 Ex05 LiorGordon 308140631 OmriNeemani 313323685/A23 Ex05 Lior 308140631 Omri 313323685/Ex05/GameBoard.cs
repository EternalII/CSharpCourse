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
            Disk[,] dynamicBox;
            dynamicBox = new Disk[boardSize * boardSize, boardSize * boardSize];
            int numOfRanks = 0, numOfFiles = 0, squareNum = 0; // Ranks - Horizontal squares, Files - Vertical squares, squareNum - total num of disks.
            int bPosX = 0;
            int bPosY = 0;
            while (numOfFiles < boardSize)
            {
                bPosY = numOfFiles * 50;
                while (numOfRanks < boardSize)
                {
                    dynamicBox[numOfFiles, numOfRanks] = new Disk();
                    dynamicBox[numOfFiles, numOfRanks].State = eDiskState.Empty;
                    dynamicBox[numOfFiles, numOfRanks].BorderStyle = BorderStyle.Fixed3D;
                    Controls.Add(dynamicBox[numOfFiles, numOfRanks]);
                    bPosX = (numOfRanks * 50);
                    dynamicBox[numOfFiles, numOfRanks].Location = new Point(bPosX, bPosY);
                    dynamicBox[numOfFiles, numOfRanks].Size = new Size(50, 50);
                    dynamicBox[numOfFiles, numOfRanks].Click += square_Click;
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
        }

        private void square_Click(object sender, EventArgs e)
        {
            Disk dsk = sender as Disk;
            if (dsk.State == eDiskState.Placeable)
            {   
                dsk.State = eDiskState.Placeable;
            }
        }

        private void Game_Load(object sender, EventArgs e)
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            if (SelectMode == eGameModes.SinglePlayer)
                Text = "Player vs CPU";
            else
                Text = "Player vs Player";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
