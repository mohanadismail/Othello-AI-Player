﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloAI
{
	internal class CornersCaptured : Heuristic
	{
        // Define the corner positions on the board as a static readonly field
        private static readonly List<(int, int)> cornerPositions = new List<(int, int)>
        {
            (0, 0), // Top-left corner (a1)
            (0, 7), // Top-right corner (a8)
            (7, 0), // Bottom-left corner (h1)
            (7, 7) // Bottom-right corner (h8)
         };

        public CornersCaptured(int weight) : base(weight)
		{
		}

		public override int calculateUtility(State state, Player maxPlayer, Player minPlayer)
        {
            int maxPlayerCornerValue = 0;
            int minPlayerCornerValue = 0;

            // Iterate through the corner positions and count the number of corners captured by each player
            foreach (var corner in cornerPositions)
            {
                var cornerPiece = state.board[corner.Item1, corner.Item2];
                if (cornerPiece == maxPlayer)
                {
                    maxPlayerCornerValue++;
                }
                else if (cornerPiece == minPlayer)
                {
                    minPlayerCornerValue++;
                }
            }

            int cornerHeuristicValue = 0;
            int totalCornerValue = maxPlayerCornerValue + minPlayerCornerValue;

            // Calculate the corner heuristic value based on the captured corners
            if (totalCornerValue != 0)
            {
                cornerHeuristicValue = (100 * (maxPlayerCornerValue - minPlayerCornerValue)) / totalCornerValue;
            }

            return cornerHeuristicValue;
        }
    }
}
