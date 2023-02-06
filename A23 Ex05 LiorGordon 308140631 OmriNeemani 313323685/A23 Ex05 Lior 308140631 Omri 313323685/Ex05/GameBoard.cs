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
    public partial class GameBoard : Form
    {
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
            int numOfRanks = 0, numOfFiles = 0, squareNum = 0; // Ranks - Horizontal squares, Files - Vertical squares, squareNum - total.
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
                    dynamicBox[numOfFiles, numOfRanks].Text = $"Button {numOfRanks + 1}";
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
        }

        private void square_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
