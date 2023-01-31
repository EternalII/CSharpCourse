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

    public class GameMode
    {
        public int mode = 0;

        public GameMode(int boardSize)
        {
            mode = boardSize;
        }
    }
}
