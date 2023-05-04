using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace OthelloAI
{
    internal abstract class Heuristic
    {
        int weight;

        public Heuristic(int weight)
        {
            this.weight = weight;
        }

        public abstract int calculateUtility(State board, Player max, Player min);
    }
}
