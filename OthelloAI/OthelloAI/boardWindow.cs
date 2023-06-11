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
using System.Transactions;
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
        int firstAlgorithmDepth;
        Algorithm secondAlgorithm;
        int secondAlgorithmDepth;
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
            if (currentGameMode != GameMode.AIVsAI)
            {
                nextMoveButton.Hide();
            }


            changeTurn(Player.Black);
            validMoves = currentState.getValidMoves(currentTurn);
            updateBoard();
        }

        public void changeTurn(Player newTurn)
        {
            if (gameOver)
            {
                return;
            }

            int gameState = checkGameOver();
            if (currentGameMode == GameMode.PlayerVsPlayer)
            {
                if (gameState == 1)
                {
                    currentTurn = newTurn;
                }
            }
            if (currentGameMode == GameMode.PlayerVsAI)
            {
                if (newTurn == currentHumanPlayerColor)
                {
                    currentTurn = currentHumanPlayerColor;
                    validMoves = currentState.getValidMoves(currentTurn);
                    updateBoard();
                }
                else
                {
                    currentTurn = Coordinate.otherPlayer(currentHumanPlayerColor);
                    currentState = firstAlgorithm.performNextMove(currentTurn, new StateNode(currentState), firstAlgorithmDepth, true);
                    gameState = checkGameOver();

                    if (gameState == 1)
                    {
                        currentTurn = currentHumanPlayerColor;
                        validMoves = currentState.getValidMoves(currentTurn);
                        updateBoard();
                    }
                    else if (gameState == 0)
                    {
                        while (checkGameOver() == 0 && currentState != null)
                        {
                            currentState = firstAlgorithm.performNextMove(currentTurn, new StateNode(currentState), firstAlgorithmDepth, true);
                        }
                        currentTurn = currentHumanPlayerColor;
                        updateBoard();
                    }
                    else
                    {
                        return;
                    }

                }
                if (currentState == null)
                    return;
                validMoves = currentState.getValidMoves(Coordinate.otherPlayer(newTurn));
            }
            if (currentGameMode == GameMode.AIVsAI)
            {
                if (currentTurn == Player.Black)
                {
                    currentState = firstAlgorithm.performNextMove(currentTurn, new StateNode(currentState), firstAlgorithmDepth, true);
                    validMoves = currentState.getValidMoves(currentTurn); //Not sure if neccessary
                    gameState = checkGameOver();

                    if (gameState == 1)
                    {
                        currentTurn = Player.White;
                        validMoves = currentState.getValidMoves(currentTurn);
                        updateBoard();
                    }
                    else if (gameState == 0)
                    {
                        while (checkGameOver() == 0 && currentState != null)
                        {
                            currentState = firstAlgorithm.performNextMove(currentTurn, new StateNode(currentState), firstAlgorithmDepth, true);
                        }
                        currentTurn = Player.White;
                        validMoves = currentState.getValidMoves(currentTurn);
                        updateBoard();
                    }
                }
                else
                {
                    currentState = secondAlgorithm.performNextMove(currentTurn, new StateNode(currentState), secondAlgorithmDepth, true);
                    validMoves = currentState.getValidMoves(currentTurn); //Not sure if neccessary
                    gameState = checkGameOver();

                    if (gameState == 1)
                    {
                        currentTurn = Player.Black;
                        validMoves = currentState.getValidMoves(currentTurn);
                        updateBoard();
                    }
                    else if (gameState == 0)
                    {
                        while (checkGameOver() == 0 && currentState != null)
                        {
                            currentState = secondAlgorithm.performNextMove(currentTurn, new StateNode(currentState), secondAlgorithmDepth, true);
                        }
                        currentTurn = Player.Black;
                        validMoves = currentState.getValidMoves(currentTurn);
                        updateBoard();
                    }
                }
            }
        }
        //Human vs Human
        public boardWindow(GameMode currentGameMode)
        {
            InitializeComponent();
            this.currentGameMode = currentGameMode;
        }
        //Human vs Ai
        public boardWindow(GameMode currentGameMode, Player humanPlayerColor, int difficulty)
        {
            InitializeComponent();
            this.currentGameMode = currentGameMode;
            this.currentHumanPlayerColor = humanPlayerColor;
            (firstAlgorithm, firstAlgorithmDepth) = chooseAlgorithm(difficulty);
        }

        public boardWindow(GameMode currentGameMode, int firstAlgorithmDifficulty, int secondAlgorithmDifficulty)
        {
            InitializeComponent();
            this.currentGameMode = currentGameMode;
            (firstAlgorithm, firstAlgorithmDepth) = chooseAlgorithm(firstAlgorithmDifficulty);
            (secondAlgorithm, secondAlgorithmDepth) = chooseAlgorithm(secondAlgorithmDifficulty);
        }

        //Checks if the game is over before changing turns 
        //returns 1 if the other player has moves
        //returns 0 if the other player does not have moves
        //returns -1 if game is over

        private int checkGameOver()
        {
            if (gameOver)
                return 0;
            Dictionary<Coordinate, List<Coordinate>> otherPlayerValidMoves = currentState.getValidMoves(Coordinate.otherPlayer(currentTurn));
            if (otherPlayerValidMoves == null || otherPlayerValidMoves.Count == 0)
            {
                validMoves = currentState.getValidMoves(currentTurn);
                if (validMoves.Count == 0)
                {
                    updateBoard();
                    //Game Over
                    if (currentState.blackScore > currentState.whiteScore)
                    {
                        turnLabel.Text = "Game Over, BLACK WON!!!";
                        gameOver = true;
                        return -1;
                    }
                    else if (currentState.blackScore < currentState.whiteScore)
                    {
                        turnLabel.Text = "Game Over, WHITE WON!!!";
                        gameOver = true;
                        return -1;
                    }
                    else
                    {
                        turnLabel.Text = "Game Over, It's a Draw!!!";
                        gameOver = true;
                        return -1;
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 1;
            }
        }
        private void updateBoard()
        {
            if (currentState == null)
                return;
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
                    else if (validMoves != null && validMoves.ContainsKey(currentCoordinate))
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
                if (currentState != null)
                    validMoves = currentState.getValidMoves(currentTurn);

                if (currentGameMode == GameMode.PlayerVsPlayer)
                {
                    updateBoard();

                }
            }
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

        private (Algorithm, int) chooseAlgorithm(int difficulty)
        {
            if (difficulty == 0)
            {
                List<Heuristic> heuristics = new List<Heuristic>();
                heuristics.Add(new CoinParity(-1));
                Algorithm algorithm = new AlphaBetaPruning(heuristics);
                return (algorithm, 2);
            }
            else if (difficulty == 1)
            {
                List<Heuristic> heuristics = new List<Heuristic>();
                heuristics.Add(new Stability(1));
                Algorithm algorithm = new AlphaBetaPruning(heuristics);
                return (algorithm, 5);
            }
            else //(difficulty == 2)
            {
                List<Heuristic> heuristics = new List<Heuristic>();
                heuristics.Add(new CornersCaptured(30));
                heuristics.Add(new PotentialMobility(5));
                heuristics.Add(new Stability(25));
                Algorithm algorithm = new AlphaBetaPruning(heuristics);
                return (algorithm, 3);
            }



        }
    }
}
