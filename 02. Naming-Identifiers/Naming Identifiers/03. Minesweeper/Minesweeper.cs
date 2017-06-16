namespace _03.Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class Minesweeper
    {
        private static void Main()
        {
            string command = string.Empty;
            char[,] gameBoard = CreateGameBoard();
            char[,] bombs = GenerateBombs();
            int pointsCounter = 0;
            bool isDead = false;
            List<Player> players = new List<Player>(6);
            int row = 0;
            int col = 0;
            bool gameHasBegun = false;
            const int MaximumTurns = 35;
            bool hasWon = false;

            do
            {
                if (!gameHasBegun)
                {
                    string startMessage = 
                        "Let's play \"Minichki\". Try your luck finding the fields withouth mines." +
                        "The command 'top' shows the ranking, 'restart' starts a new game and 'exit' leaves the game.";

                    Console.WriteLine(startMessage);
                    PrintBoard(gameBoard);
                    gameHasBegun = true;
                }

                Console.Write("Input row and column: ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) 
                        && int.TryParse(command[2].ToString(), out col)
                        && row <= gameBoard.GetLength(0) && col <= gameBoard.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintRankings(players);
                        break;
                    case "restart":
                        gameBoard = CreateGameBoard();
                        bombs = GenerateBombs();
                        PrintBoard(gameBoard);
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye, bye!");
                        break;
                    case "turn":
                        ProceedWithTheNextTurn(bombs, row, col, gameBoard, ref pointsCounter, MaximumTurns, ref hasWon, ref isDead);
                        break;
                    default:
                        Console.WriteLine(Environment.NewLine + "Error! Invalid command" + Environment.NewLine);
                        break;
                }

                if (isDead)
                {
                    PrintBoard(bombs);
                    string message = $"{Environment.NewLine}Hrrr! You died heroicly with {pointsCounter}. Input your nickname: ";
                    Console.Write(message);
                    AddPlayerToRankings(pointsCounter, players);

                    players.Sort((player1, player2) => player2.Name.CompareTo(player1.Name));
                    players.Sort((player1, player2) => player2.Points.CompareTo(player1.Points));
                    PrintRankings(players);
                    
                    StartTheGameOver(ref gameBoard, ref bombs, ref pointsCounter, ref hasWon, ref gameHasBegun, ref isDead);
                }

                if (hasWon)
                {
                    string message =
                        $"{Environment.NewLine}Congratulations! You opened up {MaximumTurns} cells withouth loosig a single drop of blood. " +
                        "Enter your name, bro: ";
                    Console.WriteLine(message);
                    PrintBoard(bombs);
                    AddPlayerToRankings(pointsCounter, players);

                    players.Sort((player1, player2) => player2.Name.CompareTo(player1.Name));
                    players.Sort((player1, player2) => player2.Points.CompareTo(player1.Points));
                    PrintRankings(players);

                    StartTheGameOver(ref gameBoard, ref bombs, ref pointsCounter, ref hasWon, ref gameHasBegun, ref isDead);
                }
            }
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("Yeaaaaaa.");
            Console.Read();
        }

        private static char[,] CreateGameBoard()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] GenerateBombs()
        {
            const int Cols = 5;
            const int Rows = 10;
            char[,] playingField = new char[Cols, Rows];

            for (int i = 0; i < Cols; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    playingField[i, j] = '-';
                }
            }

            List<int> numbers = new List<int>();
            while (numbers.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!numbers.Contains(randomNumber))
                {
                    numbers.Add(randomNumber);
                }
            }

            foreach (int number in numbers)
            {
                int col = number / Rows;
                int row = number % Rows;
                if (row == 0 && number != 0)
                {
                    col--;
                    row = Rows;
                }
                else
                {
                    row++;
                }

                playingField[col, row - 1] = '*';
            }

            return playingField;
        }

        private static void PrintRankings(List<Player> players)
        {
            Console.WriteLine(Environment.NewLine + "Points:");
            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2}", i + 1, players[i].Name, players[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty rank chart!" + Environment.NewLine);
            }
        }

        private static void AddPlayerToRankings(int pointsCounter, List<Player> players)
        {
            string nickname = Console.ReadLine();
            Player currentPlayer = new Player(nickname, pointsCounter);

            if (players.Count < 5)
            {
                players.Add(currentPlayer);
            }
            else
            {
                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].Points < currentPlayer.Points)
                    {
                        players.Insert(i, currentPlayer);
                        players.RemoveAt(players.Count - 1);
                        break;
                    }
                }
            }
        }

        private static void ProceedWithTheNextTurn(
            char[,] bombs,
            int row, 
            int col,
            char[,] board, 
            ref int pointsCounter,
            int max, 
            ref bool hasWon,
            ref bool isDead)
        {
            if (bombs[row, col] != '*')
            {
                if (bombs[row, col] == '-')
                {
                    PutTheNumberOfBombsNearTheFieldOnTopOfIt(board, bombs, row, col);
                    pointsCounter++;
                }

                if (max == pointsCounter)
                {
                    hasWon = true;
                }
                else
                {
                    PrintBoard(board);
                }
            }
            else
            {
                isDead = true;
            }
        }

        private static void StartTheGameOver(
            ref char[,] gameBoard,
            ref char[,] bombs,
            ref int pointsCounter,
            ref bool hasWon,
            ref bool gameHasBegun, 
            ref bool isDead)
        {
            gameBoard = CreateGameBoard();
            bombs = GenerateBombs();
            pointsCounter = 0;
            hasWon = false;
            gameHasBegun = false;
            isDead = false;
        }

        private static void PutTheNumberOfBombsNearTheFieldOnTopOfIt(char[,] field, char[,] bombs, int row, int col)
        {
            char kolkoBombi = GetTheNumberOfBombsNearThisField(bombs, row, col);
            bombs[row, col] = kolkoBombi;
            field[row, col] = kolkoBombi;
        }

        private static void PrintBoard(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine(Environment.NewLine + "    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write("{0} ", board[i, j]);
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------" + Environment.NewLine);
        }

        private static char GetTheNumberOfBombsNearThisField(char[,] board, int row, int col)
        {
            int bombCounter = 0;
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            if (row - 1 >= 0)
            {
                if (board[row - 1, col] == '*')
                {
                    bombCounter++;
                }
            }

            if (row + 1 < rows)
            {
                if (board[row + 1, col] == '*')
                {
                    bombCounter++;
                }
            }

            if (col - 1 >= 0)
            {
                if (board[row, col - 1] == '*')
                {
                    bombCounter++;
                }
            }

            if (col + 1 < cols)
            {
                if (board[row, col + 1] == '*')
                {
                    bombCounter++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (board[row - 1, col - 1] == '*')
                {
                    bombCounter++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (board[row - 1, col + 1] == '*')
                {
                    bombCounter++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (board[row + 1, col - 1] == '*')
                {
                    bombCounter++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (board[row + 1, col + 1] == '*')
                {
                    bombCounter++;
                }
            }

            return char.Parse(bombCounter.ToString());
        }
    }
}