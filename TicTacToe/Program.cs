using System;

namespace TicTacToe
{
    class Program
    {
        public static void Main()
        {
            //draw board
            int[] board = {0,0,0,
                           0,0,0,
                           0,0,0};

            //game restart?

            OutputBoard(board);
            int player = 1;

            while (true)
            {
                Console.Write("Enter Move: ");

                //var input = Console.Read();
                int move = Convert.ToInt32(Console.ReadLine());
                
                while (!ValidMove(board, move))
                {
                    Console.Write("Move Invalid. Enter Move: ");
                    move = Convert.ToInt32(Console.ReadLine());
                }
                
                board[move] = player;
                Console.Clear();
                OutputBoard(board);

                if (DidPlayerWin(board, player)) break;

                if(IsBoardFull(board)) break;

                player = player == 1 ? 2 : 1;
            }

            if (IsBoardFull(board))
            {
                Console.WriteLine("TIE!");
                return;
            }

            if (DidPlayerWin(board, 1)) Console.WriteLine("Player 1 Won!");
            else Console.WriteLine("Player 2 Won!");
        }

        private static void OutputBoard(int[] board)
        {
            string[] outputBoard = new string[9];

            for (int i = 0; i < 9; i++)
            {
                if (board[i] == 0) outputBoard[i] = " ";
                if (board[i] == 1) outputBoard[i] = "X";
                if (board[i] == 2) outputBoard[i] = "O";
            }

            for (int i = 0; i < 8; i+=3)
            {
                Console.Write(outputBoard[i] + "|" + outputBoard[i+1] + "|" + outputBoard[i+2] + "    " + i.ToString() + "|" + (i+1).ToString() + "|" + (i+2).ToString()   + "\r\n" );
                if (i <=3) Console.Write("- - -    - - -\r\n");
            }
        }

        private static bool ValidMove(int[] board, int move)
        {
            if (move > 8) return false;

            if (board[move] == 0) return true;
            
            return false;
        }

        public static bool DidPlayerWin(int[] ticTacToeBoard, int playerNum)
        {
            for (int i = 0; i < 8; i += 3)
            {
                if (ticTacToeBoard[i] == playerNum && ticTacToeBoard[i + 1] == playerNum && ticTacToeBoard[i + 2] == playerNum) return true;
            }

            for (int i = 0; i < 3; i++)
            {
                if (ticTacToeBoard[i] == playerNum && ticTacToeBoard[i + 3] == playerNum && ticTacToeBoard[i + 6] == playerNum) return true;
            }

            if (ticTacToeBoard[0] == playerNum && ticTacToeBoard[4] == playerNum && ticTacToeBoard[8] == playerNum) return true;
            if (ticTacToeBoard[2] == playerNum && ticTacToeBoard[4] == playerNum && ticTacToeBoard[6] == playerNum) return true;

            return false;
        }

        public static bool IsBoardFull(int[] ticTacToeBoard)
        {
            for (int i = 0; i < 9; i++)
            {
                if (ticTacToeBoard[i] == 0) return false;
            }
            return true;
        }
    }
}

