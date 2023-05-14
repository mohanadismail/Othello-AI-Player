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
            int whiteScore = board.whiteScore;
            int blackScore = board.blackScore;
            int coinParity = 100* Math.Abs(whiteScore - blackScore)/(whiteScore+blackScore);         
            return coinParity;
        }
    }
    
}
