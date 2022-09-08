using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        
        public static int SIZE = 5;
        public static int BOMB = 13;


        static void Main(string[] args)
        {
            Thread.Sleep(100);
            char[,] mine_board = new char[SIZE, SIZE];

            List<int> tMovesX = new List<int>();
            List<int> tMovesY = new List<int>();

            List<int> aMovesX = new List<int>();
            List<int> aMovesY = new List<int>();

            SetBombs(ref mine_board, out int startX, out int startY);
            //SetBombs(ref mine_board, BOMB, out int startX, out int startY);
            PrintBoard(mine_board);

            movement.move(ref mine_board, startX, startY, ref tMovesX, ref tMovesY, ref aMovesX, ref aMovesY);
            movement.toString(ref mine_board, ref tMovesX, ref tMovesY, ref aMovesX, ref aMovesY);

            Console.ReadLine();
        }

        public static void PrintBoard(char[,] char_board)
        {
            for (int k = 0; k < SIZE; k++)
            {
                if (k == 0)
                    Console.Write($"    {k}");
                else if (k != 9)
                    Console.Write($"  {k}");
                else if (k == 8)
                    Console.Write($" {k} ");
                else
                    Console.Write($"  {k}");
            }
            Console.WriteLine();

            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    if (j == 0 && i != 9)
                        Console.Write($" {i} ");

                    if (char_board[i, j] == 'B')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write($"|B|");
                    }
                    else if (char_board[i, j] == 'S')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write($"|S|");
                    }
                    else 
                    {
                        Console.ResetColor();
                        Console.Write($"| |");
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        //public static void SetBombs(ref char[,] board_char, int number, out int startX, out int startY)
        //{
        //    Random rand = new Random();
        //    int x, y;

        //    // Set Safe Route
        //    x = 0;
        //    y = rand.Next(0, SIZE); 
        //    //Console.WriteLine($"{x},{y}");
        //    board_char[x, y] = 'S';
        //    startX = x;
        //    startY = y;
        //    for (int i = 0; i < SIZE-1; i++)
        //    {
        //        if(y == 0)
        //        {
        //            x = x + 1;
        //            y = rand.Next(0, (y + 2));
        //        }
        //        else if(y == (SIZE-1))
        //        {
        //            x = x + 1;
        //            y = rand.Next(y-1, y+1);
        //        }
        //        else
        //        {
        //            x = x + 1;
        //            y = rand.Next(y - 1, y + 2);
        //        }
        //        //Console.WriteLine($"{x},{y}");
        //        board_char[x, y] = 'S';
        //    }
            
        //    //board_char[0, 1] = 'S';
        //    //board_char[1, 2] = 'S';
        //    //board_char[2, 3] = 'S';
        //    //board_char[3, 3] = 'S';
        //    //board_char[4, 2] = 'S';

        //    // Set Bombs
        //    while (number > 0)
        //    {
        //        do
        //        {
        //            x = rand.Next(0, SIZE);
        //            y = rand.Next(0, SIZE);
        //            //Console.WriteLine($"{x},{y}");
        //        } while (board_char[x, y] == 'B' || board_char[x, y] == 'S');
        //        board_char[x, y] = 'B';
        //        number--;
        //    }
        //    for (int i = 0; i < SIZE; i++)
        //    {
        //        for (int j = 0; j < SIZE; j++)
        //        {
        //            if (board_char[i, j] != 'S' && board_char[i, j] != 'B')
        //            {
        //                board_char[i, j] = ' ';
        //            }
        //        }
        //    }
        //}

        public static void SetBombs(ref char[,] board_char, out int startX, out int startY)
        {
            startX = 0;
            startY = 2;

            board_char[0, 0] = 'B';
            board_char[0, 1] = ' ';
            board_char[0, 2] = 'S';
            board_char[0, 3] = 'B';
            board_char[0, 4] = 'B';

            board_char[1, 0] = ' ';
            board_char[1, 1] = 'B';
            board_char[1, 2] = 'S';
            board_char[1, 3] = 'B';
            board_char[1, 4] = ' ';

            board_char[2, 0] = 'B';
            board_char[2, 1] = 'S';
            board_char[2, 2] = 'B';
            board_char[2, 3] = ' ';
            board_char[2, 4] = ' ';

            board_char[3, 0] = 'B';
            board_char[3, 1] = 'B';
            board_char[3, 2] = 'S';
            board_char[3, 3] = 'B';
            board_char[3, 4] = ' ';

            board_char[4, 0] = 'B';
            board_char[4, 1] = 'B';
            board_char[4, 2] = 'S';
            board_char[4, 3] = 'B';
            board_char[4, 4] = 'B';
        }

    }
}
