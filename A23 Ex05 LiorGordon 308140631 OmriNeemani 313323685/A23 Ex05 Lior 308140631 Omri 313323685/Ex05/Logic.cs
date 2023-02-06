using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05
{
    enum ePlayer
    {
        Player1,
        Player2
    }
    class Logic
    {
        ePlayer Turn { get; set; }

        Logic()
        {
            Turn = ePlayer.Player1;
        }

        public void switchTurns()
        {
            if (Turn == ePlayer.Player1)
                Turn = ePlayer.Player2;
            else
                Turn = ePlayer.Player1;
        }
    }

    class Player1
    {
        Disk playerDisk { get; }

        Player1()
        {
            playerDisk.State = eDiskState.Red;
        }

    }

    class Player2
    {
        Disk playerDisk { get; }

        Player2()
        {
            playerDisk.State = eDiskState.Yellow;
        }
    }
}
