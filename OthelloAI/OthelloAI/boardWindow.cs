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
        Algorithm firstAlgorithm;
        Algorithm secondAlgorithm;
        Dictionary<Coordinate, List<Coordinate>> validMoves;
        Boolean gameOver = false;
        GameMode currentGameMode;
        Player currentHumanPlayerColor = Player.Black;

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

                    //Add logic depending on the state of the board and maybe make it a function that refreshes
                    button.Image = Properties.Resources.empty;
                    button.Tag = new Point(row, column);
                    button.Click += square_Click;
                    boardLayout.Controls.Add(button, column, row);
                    buttonsGrid[row, column] = button;
                }
            }
            if(currentGameMode != GameMode.AIVsAI)
            {
                button1.Hide();
            }
            //*********Algorithms Initialization***********


            changeTurn(Player.Black);
            validMoves = currentState.getValidMoves(currentTurn);
            updateBoard();
        }

        public void changeTurn(Player newTurn)
        {
            currentTurn = newTurn;
            if (currentGameMode == GameMode.PlayerVsAI && currentTurn != currentHumanPlayerColor)
            {
                //***********do ai move till turn changes**********
                //currentState = firstAlgorithm.perform.......
                changeTurn(Coordinate.otherPlayer(currentTurn));
                checkGameOver();
                updateBoard();
            }
            if(currentGameMode == GameMode.AIVsAI)
            {
                if(currentTurn == Player.White)
                {
                    //***********do first Algorithm stuff**************
                    validMoves = currentState.getValidMoves(currentTurn); //Not sure if neccessary
                    checkGameOver();
                    updateBoard();
                }
                else
                {
                    //***********do second Algorithm stuff***********
                    validMoves = currentState.getValidMoves(currentTurn); //Not sure if neccessary
                    checkGameOver();
                    updateBoard();
                }
            }
        }
        public boardWindow(GameMode currentGameMode, Player humanPlayerColor)
        {
            InitializeComponent();
            this.currentGameMode = currentGameMode;
            this.currentHumanPlayerColor = humanPlayerColor;
        }

        //Checks if the game is over and changes the currentTurn if there are no valid moves for the current player
        private void checkGameOver()
        {
            if (validMoves == null || validMoves.Count == 0)
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

            if (currentGameMode == GameMode.PlayerVsAI && currentTurn != currentHumanPlayerColor)
            {
                return;
            }

            if (currentGameMode == GameMode.AIVsAI)
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

        private void button1_Click(object sender, EventArgs e)
        {
            changeTurn(Coordinate.otherPlayer(currentTurn));
        }
    }
}
