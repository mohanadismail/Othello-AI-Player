using OthelloAI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
namespace OthelloAI
{
    public partial class boardWindow : Form
    {
        State currentState;
        Button[,] buttonsGrid;
        private Player currentTurn = Player.Black;
        
        Dictionary<Coordinate, List<Coordinate>> validMoves;
        Boolean gameOver = false;
        Form1.gameMode currentGameMode;
        Player currentHumanPlayerColor = Player.Black;

        public void changeTurn(Player newTurn)
        {
            currentTurn = newTurn;
            if(currentGameMode == Form1.gameMode.PlayerVsAI && currentTurn != currentHumanPlayerColor)
            {
                //do ai move till turn changes
            }
        }
        public boardWindow(Form1.gameMode currentGameMode, Player humanPlayerColor)
        {
            InitializeComponent();
            this.currentGameMode = currentGameMode;
            this.currentHumanPlayerColor = humanPlayerColor;
        }

        //Checks if the game is over and changes the currentTurn if there are no valid moves for the current player
        private void checkGameOver()
        {
            if (validMoves.Count == 0)
            {
                changeTurn(Coordinate.otherPlayer(currentTurn));
                Dictionary<Coordinate, List<Coordinate>> otherPlayerValidMoves = currentState.getValidMoves(currentTurn);
                if (otherPlayerValidMoves.Count == 0)
                {
                    //Game Over
                    if (currentState.blackScore > currentState.whiteScore)
                    {
                        turnLabel.Text = "Game Over, BLACK WON!!!";
                        gameOver = true;
                        return;
                    }
                    else if (currentState.blackScore < currentState.whiteScore)
                    {
                        turnLabel.Text = "Game Over, WHITE WON!!!";
                        gameOver = true;
                        return;
                    }
                    else
                    {
                        turnLabel.Text = "Game Over, It's a Draw!!!";
                        gameOver = true;
                        return;
                    }
                }
            }
        }
        private void updateBoard()
        {
            for (int row = 0; row < buttonsGrid.GetLength(0); row++)
            {
                for (int column = 0; column < buttonsGrid.GetLength(1); column++)
                {
                    Coordinate currentCoordinate = new Coordinate(row, column);
                    if (currentState.board[row, column] == Player.White)
                    {
                        buttonsGrid[row, column].Image = Resources.white;
                    }
                    else if (currentState.board[row, column] == Player.Black)
                    {
                        buttonsGrid[row, column].Image = Resources.black;
                    }
                    else if (validMoves.ContainsKey(currentCoordinate))
                    {
                        buttonsGrid[row, column].Image = Resources.valid;
                    }

                    else
                    {
                        buttonsGrid[row, column].Image = Resources.empty;
                    }
                }
            }
            whiteScoreLabel.Text = currentState.whiteScore.ToString();
            blackScoreLabel.Text = currentState.blackScore.ToString();
            if (gameOver)
            {
                return;
            }
            if (currentTurn == Player.White)
            {
                turnLabel.Text = "White's turn";
            }
            else if (currentTurn == Player.Black)
            {
                turnLabel.Text = "Black's turn";
            }
            else
            {
                turnLabel.Text = "Hoyyyyyyaaa";
            }
        }
        private void boardWindow_Load(object sender, EventArgs e)
        {
            Player[,] board = new Player[8, 8];
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    board[row, column] = Player.None;
                }
            }
            board[3, 3] = Player.White;
            board[3, 4] = Player.Black;
            board[4, 3] = Player.Black;
            board[4, 4] = Player.White;
            currentState = new State(board);
            buttonsGrid = new Button[8, 8];
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    Button button = new Button();
                    button.Dock = DockStyle.Fill;
                    button.Margin = new Padding(0);

                    button.Image = Properties.Resources.empty;
                    boardLayout.Controls.Add(button, column, row);
                }
            }
            validMoves = currentState.getValidMoves(currentTurn);
            updateBoard();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void turnLabel_Click(object sender, EventArgs e)
        {

        }

        private void square_Click(object sender, EventArgs e)
        {
            if (gameOver)
            {
                return;
            }

            if(currentGameMode == Form1.gameMode.PlayerVsAI && currentTurn != currentHumanPlayerColor)
            {
                return;
            }

            if(currentGameMode == Form1.gameMode.AIVsAI)
            {
                return;
            }

            Button button = sender as Button;

            Point indices = (Point)button.Tag;
            int row = indices.X;
            int column = indices.Y;
            Coordinate currentMove = new Coordinate(row, column);
            validMoves = currentState.getValidMoves(currentTurn);

            if (validMoves.ContainsKey(currentMove))
            {
                //update current state 
                currentState = currentState.applyMove(currentTurn, currentMove);
                //swap currentTurn using the static method in Player 
                changeTurn(Coordinate.otherPlayer(currentTurn));
                //Update valid moves
                validMoves = currentState.getValidMoves(currentTurn);

            }
                checkGameOver();
                updateBoard();
        }

        private void blackScoreLabel_Click(object sender, EventArgs e)
        {

        }

        private void boardLayout_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
