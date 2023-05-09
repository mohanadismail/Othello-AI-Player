using OthelloAI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
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
        Player currentTurn = Player.Black;
        public boardWindow()
        {
            InitializeComponent();
        }

        private void updateBoard()
        {
            for (int row = 0; row < buttonsGrid.GetLength(0); row++)
            {
                for (int column = 0; column < buttonsGrid.GetLength(1); column++)
                {
                    if (currentState.board[row, column] == Player.None)
                    {
                        buttonsGrid[row, column].Image = Resources.empty;
                    }
                    else if (currentState.board[row, column] == Player.White)
                    {
                        buttonsGrid[row, column].Image = Resources.white;
                    }
                    else
                    {
                        buttonsGrid[row, column].Image = Resources.black;
                    }
                }
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

            whiteScoreLabel.Text = currentState.whiteScore.ToString();
            blackScoreLabel.Text = currentState.blackScore.ToString();
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

                    //Add logic depending on the state of the board and maybe make it a function that refreshes
                    button.Image = Properties.Resources.empty;
                    button.Tag = new Point(row, column);
                    button.Click += square_Click;
                    boardLayout.Controls.Add(button, column, row);
                    buttonsGrid[row, column] = button;
                }
            }

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
            Button button = sender as Button;

            Point indices = (Point)button.Tag;
            int row = indices.X;
            int column = indices.Y;
            Coordinate currentMove = new Coordinate(row, column);
            Dictionary<Coordinate, List<Coordinate>> validMoves = currentState.getValidMoves(currentTurn);

            if (validMoves.ContainsKey(currentMove))
            {
                currentState.applyMove(currentTurn, currentMove);
                //swap currentTurn using the static method in Player called 
                currentTurn = Coordinate.otherPlayer(currentTurn);
            }
            else
            {
                MessageBox.Show("This move is not valid, get good loser!");
            }
           
            updateBoard();
            
        }

        private void blackScoreLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
