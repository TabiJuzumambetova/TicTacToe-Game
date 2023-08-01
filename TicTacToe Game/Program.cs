using System;

namespace TicTacToe
{
    class Program
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char player = 'X';

        static void Main(string[] args)
        {
            bool gameOver = false;
            int move;
            while (!gameOver)
            {
                DrawBoard();
                move = GetPlayerMove();
                if (IsMoveValid(move))
                {
                    board[move - 1] = player;
                    if (IsWinningMove())
                    {
                        DrawBoard();
                        Console.WriteLine("Игрок " + player + " победил!");
                        gameOver = true;
                    }
                    else if (IsBoardFull())
                    {
                        DrawBoard();
                        Console.WriteLine("Ничья!");
                        gameOver = true;
                    }
                    else
                    {
                        player = (player == 'X') ? 'O' : 'X';
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ход. Попробуйте еще раз.");
                }
            }
        }

        static void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine(" " + board[0] + " | " + board[1] + " | " + board[2]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" " + board[3] + " | " + board[4] + " | " + board[5]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" " + board[6] + " | " + board[7] + " | " + board[8]);
        }

        static int GetPlayerMove()
        {
            Console.Write("Ход игрока " + player + ". Введите число (1-9): ");
            int move;
            while (!int.TryParse(Console.ReadLine(), out move) || move < 1 || move > 9)
            {
                Console.Write("Некорректный ввод. Введите число от 1 до 9: ");
            }
            return move;
        }

        static bool IsMoveValid(int move)
        {
            return board[move - 1] != 'X' && board[move - 1] != 'O';
        }

        static bool IsWinningMove()
        {
            return
                (board[0] == player && board[1] == player && board[2] == player) ||
                (board[3] == player && board[4] == player && board[5] == player) ||
                (board[6] == player && board[7] == player && board[8] == player) ||
                (board[0] == player && board[3] == player && board[6] == player) ||
                (board[1] == player && board[4] == player && board[7] == player) ||
                (board[2] == player && board[5] == player && board[8] == player) ||
                (board[0] == player && board[4] == player && board[8] == player) ||
                (board[2] == player && board[4] == player && board[6] == player);
        }

        static bool IsBoardFull()
        {
            foreach (char cell in board)
            {
                if (cell != 'X' && cell != 'O')
                    return false;
            }
            return true;
        }
    }
}

