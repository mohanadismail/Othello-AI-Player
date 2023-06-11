using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace OthelloAI
{
    public abstract class Heuristic
    {
        public Heuristic(int weight)
        {
            Weight = weight;
        }

        public int Weight { get; set; }

        public abstract int calculateUtility(State board, Player max, Player min);
    }
}
