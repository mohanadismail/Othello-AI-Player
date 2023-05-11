using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloAI
{
    public enum Player
    {
        None,
        Black,
        White
    }

    public enum GameMode
    {
        PlayerVsPlayer,
        PlayerVsAI,
        AIVsAI
    }

    internal class Coordinate
    {
        public readonly int x;
        public readonly int y;

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static readonly List<Coordinate> directions = new()
        {
            new Coordinate(0, 1),
            new Coordinate(0, -1),
            new Coordinate(1, 0),
            new Coordinate(-1, 0),
            new Coordinate(1, 1),
            new Coordinate(1, -1),
            new Coordinate(-1, 1),
            new Coordinate(-1, -1)
        };

        public bool isWithinBoard()
        {
            return x >= 0 && x < 8 && y >= 0 && y < 8;
        }

        /// <summary>
        /// This function returns the other player
        /// </summary>
        /// <param name="turn">the current player</param>
        public static Player otherPlayer(Player turn)
        {
            if (turn == Player.Black)
            {
                return Player.White;
            }
            else if (turn == Player.White)
            {
                return Player.Black;
            }
            else
            {
                return Player.None;
            }
        }

        /// <summary>
        /// This function is used to solve hashing collisions
        /// </summary>
        public override bool Equals(object? obj)
        {
            return obj is Coordinate coordinate &&
                   x == coordinate.x &&
                   y == coordinate.y;
        }

        /// <summary>
        /// This function is used so that coordinates of the same x and y values are considered equal
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }

        public static Coordinate operator +(Coordinate a, Coordinate b)
        {
            return new Coordinate(a.x + b.x, a.y + b.y);
        }


    }

    /// <summary>
    /// This class represents a node in the game search tree. It contains a state, all valid next states, and a reference to the parent node.
    /// </summary>
    internal class StateNode
    {
        public State state;
        public List<StateNode>? validNextStates;
        public StateNode? parentNode;

        public StateNode(State state, StateNode? parentNode = null)
        {
            this.state = state;
            validNextStates = null;
            this.parentNode = parentNode;
        }

        /// <summary>
        /// This function populates the children nodes of the current state node only on request.
        /// </summary>
        /// <param name="turn">the player's turn for which the next states should be generated</param>
        public void generateValidNextStates(Player turn)
        {
            validNextStates = new List<StateNode>();
            Dictionary<Coordinate, List<Coordinate>> validMoves = this.state.getValidMoves(turn);
            // iterate on all valid moves
            foreach (KeyValuePair<Coordinate, List<Coordinate>> move in validMoves)
            {
                State newState = new State((Player[,])this.state.board.Clone());
                // place the current player's piece
                newState.board[move.Key.x, move.Key.y] = turn;
                // flip all pieces corresponding to this move
                foreach (Coordinate flippedPiece in move.Value)
                {
                    newState.board[flippedPiece.x, flippedPiece.y] = turn;
                }
                validNextStates.Add(new StateNode(newState, this));
            }
        }
    }
}
