using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloAI
{
    internal class Mobility : Heuristic
    {
        public Mobility(int weight) : base(weight)
        {
        }
        public override int calculateUtility(State board, Player max, Player min)
        {
            int maxMoves = board.getValidMoves(max).Count;
            int minMoves = board.getValidMoves(min).Count;
            if(maxMoves + minMoves == 0)
            {
                return 0;
            }

            int mobility = 100 * Math.Abs(maxMoves - minMoves) / (maxMoves + minMoves);
            return mobility;
        }
    }
}
