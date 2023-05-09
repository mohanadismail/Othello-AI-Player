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

    internal class MiniMax : Algorithm
    {
        public MiniMax(List<Heuristic> heuristics) : base(heuristics) { }
        /// <summary>
        /// MinMax Algorithm Implementation without pruning of unwanted branches 
        /// </summary>
        /// <param name="turn"></param>
        /// <param name="node"></param>
        /// <param name="maxDepth"></param>
        /// <param name="isMaximizingPlayer"></param>
        /// <returns></returns>
        public override State performNextMove(Player turn, StateNode node, int maxDepth, bool isMaximizingPlayer)
        {
            // return if it's a leaf state
            if (maxDepth == 0) return node.state;

            int maxNextStateEvaluation = int.MinValue, minNextStateEvaluation = int.MaxValue, nextStateEvaluation;
            Player otherPlayerTurn = Coordinate.otherPlayer(turn);
            State nextState, bestNextState = null;

            node.generateValidNextStates(turn);
            foreach (StateNode nextStateNode in node.validNextStates)
            {
                // performing the next move to the nextStateNode
                nextState = performNextMove(otherPlayerTurn, nextStateNode, maxDepth - 1, !isMaximizingPlayer);

                // Evaluate the movement
                // if the heurisitc for this movement is the best among all possible states
                // update bestNextState, and maxNextStateEvaluation
                if (isMaximizingPlayer)
                {
                    nextStateEvaluation = evaluateState(nextState, turn, otherPlayerTurn);
                    if (maxNextStateEvaluation < nextStateEvaluation) bestNextState = nextState;
                    maxNextStateEvaluation = Math.Max(maxNextStateEvaluation, nextStateEvaluation);
                }
                else
                {
                    nextStateEvaluation = evaluateState(nextState, otherPlayerTurn, turn);
                    if (minNextStateEvaluation > nextStateEvaluation) bestNextState = nextState;
                    minNextStateEvaluation = Math.Min(minNextStateEvaluation, nextStateEvaluation);
                }
            }

            return bestNextState;
        }
    }
}
