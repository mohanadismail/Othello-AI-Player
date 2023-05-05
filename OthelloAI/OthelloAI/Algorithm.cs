using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloAI
{
    internal abstract class Algorithm
    {
        List<Heuristic> heuristics;

        public Algorithm(List<Heuristic> heuristics)
        {
            this.heuristics = heuristics;
        }

        public abstract State performNextMove(Player turn, StateNode node, int maxDepth, bool isMaximizingPlayer);

        protected int evaluateState(State state, Player max, Player min)
        {
            int score = 0;
            foreach (Heuristic heuristic in heuristics)
            {
                score += heuristic.calculateUtility(state, max, min) * heuristic.Weight;
            }
            return score;
        }
    }
}
