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
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
        }

        public Game(int boardSize)
        {
            InitializeComponent();
            Button[] dynamicButton;
            dynamicButton = new Button[boardSize * boardSize];
            int numOfButtonsInRow = 0, numOfButtonsInCol = 0, buttonNum = 0;
            int bPosX = 0;
            int bPosY = 0;
            while (numOfButtonsInCol < boardSize){
                bPosY = numOfButtonsInCol * 50;
                while (numOfButtonsInRow < boardSize)
                {
                    dynamicButton[buttonNum] = new Button();
                    Controls.Add(dynamicButton[buttonNum]);
                    dynamicButton[buttonNum].Text = $"Button {numOfButtonsInRow+1}";
                    bPosX = (numOfButtonsInRow * 50);
                    dynamicButton[buttonNum].Location = new Point(bPosX, bPosY);
                    dynamicButton[buttonNum].Size = new Size(50, 50);
                    numOfButtonsInRow++;
                    buttonNum++;
                }
                numOfButtonsInRow = 0;
                numOfButtonsInCol++;
            }
        }

        private void Game_Load(object sender, EventArgs e)
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
        }
    }
}
