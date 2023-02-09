using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Ex05.GameLogic
{
    public enum eDiskState
    {
        Empty,
        Placeable,
        Yellow,
        Red
    }
    public class Disk : PictureBox
    {
        private eDiskState state;
        private readonly Image r_RedCoin = Properties.Resources.CoinRed;
        private readonly Image r_YellowCoin = Properties.Resources.CoinYellow;
       
        public int m_FaceX = 0;
        public int m_FaceY = 0;
        public int m_PosX = 0;
        public int m_PosY = 0;

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
                        BackColor = Color.Empty;
                        SizeMode = PictureBoxSizeMode.StretchImage;
                        break;
                    case eDiskState.Yellow:
                        Image = r_YellowCoin;
                        BackColor = Color.Empty;
                        SizeMode = PictureBoxSizeMode.StretchImage;
                        break;
                    case eDiskState.Empty:
                        BackColor = Color.Empty;
                        Image = null;
                        break;
                }
            }
        }
    }
}
