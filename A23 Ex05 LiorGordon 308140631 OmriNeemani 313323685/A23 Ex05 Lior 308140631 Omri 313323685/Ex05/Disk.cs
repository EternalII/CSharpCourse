using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Ex05
{
    enum eDiskState
    {
        Empty,
        Placeable,
        Yellow,
        Red
    }
    class Disk : PictureBox
    {
        private eDiskState state;
        private readonly Image r_RedCoin = Properties.Resources.CoinRed;
        private readonly Image r_YellowCoin = Properties.Resources.CoinYellow;
        public eDiskState State
        {
            get { return state; }
            set 
            {
                state = value;
                switch (state)
                {
                    case eDiskState.Placeable:
                        BackColor = Color.MediumSeaGreen;
                        break;
                    case eDiskState.Red:
                        Image = r_RedCoin;
                        SizeMode = PictureBoxSizeMode.StretchImage;
                        break;
                    case eDiskState.Yellow:
                        Image = r_YellowCoin;
                        SizeMode = PictureBoxSizeMode.StretchImage;
                        break;
                }
            }
        }
    }
}
