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

    internal class AlphaBetaPruning : Algorithm
    {
        public AlphaBetaPruning(List<Heuristic> heuristics) : base(heuristics)
        {
        }
        public override State performNextMove(Player turn, StateNode node, int maxDepth, bool isMaximizingPlayer)
        {
            int alpha = int.MinValue;
            int beta = int.MaxValue;
            StateNode? bestNode = null;
            node.generateValidNextStates(turn);
            if (isMaximizingPlayer)
            {
                foreach (StateNode child in node.validNextStates)
                {
                    int score = performRecursiveAlgorithm(Coordinate.otherPlayer(turn), child, maxDepth, 1, !isMaximizingPlayer, alpha, beta);
                    if (score > alpha)
                    {
                        alpha = score;
                        bestNode = child;
                    }
                }
            }
            else
            {
                foreach (StateNode child in node.validNextStates)
                {
                    int score = performRecursiveAlgorithm(Coordinate.otherPlayer(turn), child, maxDepth, 1, !isMaximizingPlayer, alpha, beta);
                    if (score < beta)
                    {
                        beta = score;
                        bestNode = child;
                    }
                }
            }
            return bestNode.state;
        }

        private int performRecursiveAlgorithm(Player turn, StateNode node, int maxDepth, int depth, bool isMaximizingPlayer, int alpha, int beta)
        {
            if (depth == maxDepth)
            {
                if (isMaximizingPlayer) return evaluateState(node.state, turn, Coordinate.otherPlayer(turn));
                else return evaluateState(node.state, Coordinate.otherPlayer(turn), turn);
            }
            node.generateValidNextStates(turn);
            if (isMaximizingPlayer)
            {
                foreach (StateNode child in node.validNextStates)
                {
                    alpha = Math.Max(alpha, performRecursiveAlgorithm(Coordinate.otherPlayer(turn), child, maxDepth, depth + 1, false, alpha, beta));
                    if (alpha >= beta) return int.MaxValue;
                }
                return alpha;
            }
            else
            {
                foreach (StateNode child in node.validNextStates)
                {
                    beta = Math.Min(beta, performRecursiveAlgorithm(Coordinate.otherPlayer(turn), child, maxDepth, depth + 1, true, alpha, beta));
                    if (alpha >= beta) return int.MinValue;
                }
                return beta;
            }
        }
    }
}
