using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05.GameLogic
{
    public abstract class Player
    {
        public Disk playerDisk { get; }
        public int m_Score = 0;
        public int m_TotalScore = 0;
        public string m_Name;
        public bool m_Computer = false;

        protected Player()
        {
            playerDisk = new Disk();
            playerDisk.State = eDiskState.Empty;
        }
    }

    public class Player1 : Player
    {
        public Player1()
        {
            m_Name = "Player 1";
            playerDisk.State = eDiskState.Red;
        }

    }

    public class Player2 : Player
    {
        public Player2()
        {
            m_Name = "Player 2";
            playerDisk.State = eDiskState.Yellow;
        }
    }
}
