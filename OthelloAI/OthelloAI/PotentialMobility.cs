using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OthelloAI
{
    internal class PotentialMobility:Heuristic
    {
        public PotentialMobility(int weight) : base(weight)
        {
        }
        public int getPotentialMoves(State state, Player player)
        {
            Player[,] board = state.board;
            int potentialMoves = 0;
            Player opponent;
            if(player == Player.White)
            {
                opponent = Player.Black;
            }
            else
            {
                opponent = Player.White;
            }
            // iterate through all the squares on the board
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] == Player.None)
                    {
                        // iterate through all eight directions and check if any has an oponent piece

                        Coordinate currentEmpty = new Coordinate(i, j);
                        foreach (Coordinate direction in Coordinate.directions)
                        {
                            Coordinate current = currentEmpty + direction;
                            if (current.isWithinBoard() && board[current.x, current.y] == opponent)
                            {
                                potentialMoves++;                                
                            }
                           
                        }
                       
                    }
                }
            }
            return potentialMoves;
        }
        public override int calculateUtility(State board, Player max, Player min)
        {
            int maxMoves = getPotentialMoves(board, max);
            int minMoves = getPotentialMoves(board, min);

            if (maxMoves + minMoves == 0)
            {
                return 0;
            }

            int mobility = 100 * (maxMoves - minMoves) / (maxMoves + minMoves);
            return mobility;
            
        }
    }
}
