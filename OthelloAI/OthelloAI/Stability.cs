using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OthelloAI
{
    internal class Stability:Heuristic
    {
       enum StabilityType
        {
            Stable=1,
            SemiStable=0,
            Unstable=-1
        }
        public Stability(int weight) : base(weight)
        {
        }

        public override int calculateUtility(State board, Player max, Player min) 
        {
            int max_player_stability = 0;
            int min_player_stability = 0;

            //make a function to determine stability of a piece

            //iterate through the board
            
            //if the piece is stable, add 1 to the stability of the player who owns it

            //if the piece is unstable, subtract 1 from the stability of the player who owns it

            //if the piece is semi-stable, do nothing
            for(int row=0;row<8;row++)
            {
                for(int col=0;col<8;col++)
                {
                    if(board.board[row,col]==max)
                    {
                        max_player_stability+=(int)CheckStability(row,col,board,max);
                    }
                    else if(board.board[row,col]==min)
                    {
                        min_player_stability+=(int)CheckStability(row,col,board,min);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            //after evaluation of the board and iterating, return the equation 
        
            if(max_player_stability+min_player_stability!=0)
            {
                return 100*(max_player_stability-min_player_stability)/(max_player_stability+min_player_stability);
            }
            return 0;
        }
        private StabilityType CheckStability(int row, int col ,State board,Player player)
        {
            /*checks for Unstable*/

            //Check if piece is flankable by the other player
            if(IsFlankable(row,col,board,player))
            {
                return StabilityType.Unstable;
            }

            /*Checks for Stable*/
            //1. Check if the piece is in a corner
            if((row==0 && col==0) || (row==0 && col==7) || (row==7 && col==0) || (row==7 && col==7))
            {
                return StabilityType.Stable;
            }
            //2. Check if the piece is adjacent to a corner
            if(board.board[0,0]==player) // this is bottom left corner
            {
                if((row==0 && col==1) || (row==1 && col==0))
                {
                    return StabilityType.Stable;
                }
            }
            if(board.board[0,7]==player) //this is bottom right corner
            {
                if((row==0 && col==6) || (row==1 && col==7))
                {
                    return StabilityType.Stable;
                }
            }
            if(board.board[7,0]==player) //this is top left corner
            {
                if((row==7 && col==1) || (row==6 && col==0))
                {
                    return StabilityType.Stable;
                }
            }
            if(board.board[7,7]==player) //this is top right corner
            {
                if((row==7 && col==6) || (row==6 && col==7))
                {
                    return StabilityType.Stable;
                }
            }

            //TODO:More checks for stable

            return StabilityType.SemiStable;
        }
        private bool IsFlankable(int row, int col, State board, Player player)
        {
            StateNode node=new StateNode(board);
            node.generateValidNextStates(player==Player.Black?Player.White:Player.Black);
            foreach(StateNode state in node.validNextStates)
            {
                if(state.state.board[row,col]!=player)
                {
                    return true;
                }
            }
            return false;
        }

    }
}// End namespace OthelloAI