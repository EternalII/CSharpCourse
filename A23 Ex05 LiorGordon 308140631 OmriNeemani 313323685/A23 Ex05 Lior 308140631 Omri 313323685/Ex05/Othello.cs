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

        public class GameMode
        {
            public int mode = 0;

            public GameMode(int boardSize)
            {
                mode = boardSize;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            GameBoard form = new GameBoard(listGameModes[modeIndex].mode);
            form.SelectMode = eGameModes.Versus;
            form.ShowDialog();
        }

        private void boardSize_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void vsCPU_Click(object sender, EventArgs e)
        {
            GameBoard form = new GameBoard(listGameModes[modeIndex].mode);
            form.SelectMode = eGameModes.SinglePlayer;
            form.ShowDialog();
        }
    }
}
