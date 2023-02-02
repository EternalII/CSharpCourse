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
    public partial class othello : Form
    {
        //int i = 1;
        //public event EventHandler GameButtonTriggered;
        List<GameMode> listGameModes = new List<GameMode>();
        int modeIndex = 0;


        public othello()
        {
            InitializeComponent();
            listGameModes.Add(new GameMode(6));
            listGameModes.Add(new GameMode(8));
            listGameModes.Add(new GameMode(10));
            listGameModes.Add(new GameMode(12));

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //i++;
            //switch (i)
            //{
            //    case 1:
            //        boardSize.Text = "Board Size: 6x6 (click to increase)";
            //        break;
            //    case 2:
            //        boardSize.Text = "Board Size: 8x8 (click to increase)";
            //        break;
            //    case 3:
            //        boardSize.Text = "Board Size: 10x10 (click to increase)";
            //        i = 0;
            //        break;
            //}
            GameMode chooseMode;
            modeIndex++;
            if (modeIndex < listGameModes.Count) 
            {
                chooseMode = listGameModes[modeIndex];
                boardSize.Text = $"Board Size: {chooseMode.mode}x{chooseMode.mode} (click to increase)";
            }
            else
            {
                modeIndex = 0;
                chooseMode = listGameModes[modeIndex];
                boardSize.Text = $"Board Size: {chooseMode.mode}x{chooseMode.mode} (click to increase)";
            }
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Game form = new Game(listGameModes[modeIndex].mode);
            form.ShowDialog();
        }

        private void boardSize_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void vsCPU_Click(object sender, EventArgs e)
        {
            Game form = new Game(listGameModes[modeIndex].mode);
            form.ShowDialog();
        }
    }
}
