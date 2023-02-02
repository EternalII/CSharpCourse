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
            //Size = new Size(((boardSize)*50), ((boardSize)*50));
            int numOfButtonsInRow = 0, numOfButtonsInCol = 0;
            int bPosX = 0;
            int bPosY = 0;
            while (numOfButtonsInCol < boardSize){
                bPosY = numOfButtonsInCol * 50;
                while (numOfButtonsInRow < boardSize)
                {
                    Button newButton = new Button();
                    Controls.Add(newButton);
                    newButton.Text = $"Button {numOfButtonsInRow+1}";
                    bPosX = (numOfButtonsInRow * 50);
                    newButton.Location = new Point(bPosX, bPosY);
                    newButton.Size = new Size(50, 50);
                    numOfButtonsInRow++;
                }
                numOfButtonsInRow = 0;
                numOfButtonsInCol++;
            }
        }

        private void Game_Load(object sender, EventArgs e)
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
    }
}
