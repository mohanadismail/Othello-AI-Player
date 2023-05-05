using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloAI
{
    internal class State
    {
        public readonly Player[,] board;
        public readonly int blackScore;
        public readonly int whiteScore;

        public State(Player[,] board)
        {
            this.board = board;
            blackScore = 0;
            whiteScore = 0;
            foreach (Player piece in board)
            {
                if (piece == Player.Black)
                {
                    blackScore++;
                }
                else if (piece == Player.White)
                {
                    whiteScore++;
                }
            }
        }

        /// <summary>
        /// This function returns a dictionary of all valid moves for the given player
        /// </summary>
        /// <param name="turn">the player whose turn is this</param>
        /// <returns>A dictionary where the key is a valid move, and the value is a list of coordinates of piece that would be flipped if this move is made</returns>
        public Dictionary<Coordinate, List<Coordinate>> getValidMoves(Player turn)
        {
            Dictionary<Coordinate, List<Coordinate>> validMoves = new Dictionary<Coordinate, List<Coordinate>>();
            // iterate through all the squares on the board
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] == Player.None)
                    {
                        List<Coordinate> flippedPieces = new();
                        bool isValidMove = false;
                        // iterate through all eight directions and check if this direction flips any pieces
                        foreach (Coordinate direction in Coordinate.directions)
                        {
                            List<Coordinate> flippedPiecesInThisDirection = new();
                            Coordinate current = new Coordinate(i, j);
                            current = current + direction;
                            while (current.isWithinBoard() && board[current.x, current.y] == Coordinate.otherPlayer(turn))
                            {
                                flippedPiecesInThisDirection.Add(current);
                                current = current + direction;
                            }
                            if (current.isWithinBoard() && board[current.x, current.y] == turn && flippedPiecesInThisDirection.Count > 0)
                            {
                                flippedPieces.AddRange(flippedPiecesInThisDirection);
                                isValidMove = true;
                                break;
                            }
                        }
                        if (isValidMove) validMoves.Add(new Coordinate(i, j), flippedPieces);
                    }
                }
            }
            return validMoves;
        }

        /// <summary>
        /// This function returns a new state with the given move applied
        /// </summary>
        /// <param name="turn">the player that wants to make this move</param>
        /// <param name="move">the coordinate of the piece the player wants to place</param>
        /// <returns>the new state after the move is applied and all flips are made</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the move is invalid for this player</exception>
        public State applyMove(Player turn, Coordinate move)
        {
            Player[,] newBoard = (Player[,])board.Clone();
            newBoard[move.x, move.y] = turn;
            foreach (Coordinate flippedPiece in getValidMoves(turn)[move])
            {
                newBoard[flippedPiece.x, flippedPiece.y] = turn;
            }
            return new State(newBoard);
        }
    }
}
