using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloAI
{
    internal class CoinParity:Heuristic
    {
        public CoinParity(int weight) : base(weight)
        {
        }
        public override int calculateUtility(State board, Player max, Player min)
        {
            int maxScore, minScore;
            if (max == Player.White)
            {
                maxScore = board.whiteScore; minScore = board.blackScore;
            }
            else
            {
                maxScore = board.blackScore; minScore = board.whiteScore;
            }
            if (maxScore + minScore == 0)
            {
                return 0;
            }
            return 100 * (maxScore - minScore) / (maxScore + minScore);
        }
    }
    
}
