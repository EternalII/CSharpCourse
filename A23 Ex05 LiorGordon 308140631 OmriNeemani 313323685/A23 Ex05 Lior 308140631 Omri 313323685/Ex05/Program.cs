using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05
{
    class Program
    {
        static void Main()
        {
            othello form = new othello();
            form.ShowDialog();
        }
    }

    public class GameMode // useed in Game.cs for list
    {
        public int mode = 0;

        public GameMode(int boardSize)
        {
            mode = boardSize;
        }
    }
}
