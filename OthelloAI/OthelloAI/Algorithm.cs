using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloAI
{
    internal abstract class Algorithm
    {
        protected List<Heuristic> heuristics;

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
            if (node.validNextStates.Count == 0) {
                node.generateValidNextStates(Coordinate.otherPlayer(turn));
                if (node.validNextStates.Count == 0)
                {
                    return null;
                }
                else
                {
                    isMaximizingPlayer = !isMaximizingPlayer;
                    turn = Coordinate.otherPlayer(turn);
                }
            }
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
            if (node.validNextStates.Count == 0)
            {
                if (isMaximizingPlayer) return evaluateState(node.state, turn, Coordinate.otherPlayer(turn));
                else return evaluateState(node.state, Coordinate.otherPlayer(turn), turn);
            }
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

    internal class AlphaBetaPruningIterative : Algorithm
    {
        public AlphaBetaPruningIterative(List<Heuristic> heuristics) : base(heuristics)
        {
        }

        public override State performNextMove(Player turn, StateNode node, int maxDepth, bool isMaximizingPlayer)
        {
            State? bestState = null;
            int currentDepth = 1;
            Algorithm alphaBeta = new AlphaBetaPruning(this.heuristics);
            while (currentDepth <= maxDepth)
            {
                bestState = alphaBeta.performNextMove(turn, node, currentDepth, isMaximizingPlayer);
                currentDepth++;
            }
            return bestState;
        }
    }
}
