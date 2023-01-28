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
    public partial class Form1 : Form
    {
        int i = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            i++;
            switch(i){
                case 1:
                    boardSize.Text = "Board Size: 6x6 (click to increase)";
                    break;
                case 2:
                    boardSize.Text = "Board Size: 8x8 (click to increase)";
                    break;
                case 3:
                    boardSize.Text = "Board Size: 10x10 (click to increase)";
                    i = 0;
                    break;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void boardSize_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
