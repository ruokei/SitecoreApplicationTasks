using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class movement
    {
        static int SIZE = Program.SIZE;
        static int BOMB = Program.BOMB;

        public static void move(ref char[,] board_char, int startX, int startY, ref List<int> tMovesX, ref List<int> tMovesY, ref List<int> aMovesX, ref List<int> aMovesY)
        {
            int tCurrentX = 0, tCurrentY = 0;
            int aCurrentX = -1, aCurrentY = -1;
            int counter = 0;

            tCurrentX = startX;
            tCurrentY = startY;
            //Console.WriteLine($"{tCurrentX},{tCurrentY}");

            tMovesX.Add(tCurrentX);
            tMovesY.Add(tCurrentY);
            aMovesX.Add(aCurrentX);
            aMovesY.Add(aCurrentY);

            while (aCurrentX != (SIZE - 1))
            {
                if(counter > SIZE + BOMB)
                {
                    tCurrentX = startX;
                    tCurrentY = startY;
                    tMovesX.Clear();
                    tMovesY.Clear();
                    aMovesX.Clear();
                    aMovesY.Clear();
                    tMovesX.Add(tCurrentX);
                    tMovesY.Add(tCurrentY);
                    aMovesX.Add(-1);
                    aMovesY.Add(-1);
                    //Console.WriteLine("x___x");
                    counter = 0;
                }
                aMove(ref board_char, tCurrentX, tCurrentY, ref aMovesX, ref aMovesY, out int anextX, out int anextY);
                aCurrentX = anextX;
                aCurrentY = anextY;

                if (tCurrentX != (SIZE - 1))
                {
                    tMove(ref board_char, tCurrentX, tCurrentY, ref tMovesX, ref tMovesY, out int tnextX, out int tnextY);
                    tCurrentX = tnextX;
                    tCurrentY = tnextY;
                }
                counter++;
            }
        }

        public static void tMove(ref char[,] board_char, int currentX, int currentY, ref List<int> tMovesX, ref List<int> tMovesY, out int nextX, out int nextY)
        {
            int moveX = currentX;
            int moveY = currentY;
            Random rand = new Random();
            do
            {
                if (MoveForward(ref board_char, moveX, moveY))
                {
                    moveX = currentX + 1;
                }
                else if (MoveSide(ref board_char, moveX, moveY))
                {

                }
                else
                {
                    moveX = currentX - 1;
                }
                if (currentY == 0)
                {
                    moveY = rand.Next(0, (currentY + 2));
                }
                else if (currentY == (SIZE - 1))
                {
                    moveY = rand.Next(currentY - 1, currentY + 1);
                }
                else
                {
                    moveY = rand.Next(currentY - 1, currentY + 2);
                }
            } while (board_char[moveX, moveY] == 'B');

            // Console.WriteLine($"{moveX},{moveY}");

            tMovesX.Add(moveX);
            tMovesY.Add(moveY);

            nextX = moveX;
            nextY = moveY;
        }

        public static void aMove(ref char[,] board_char, int newX, int newY, ref List<int> aMovesX, ref List<int> aMovesY, out int nextX, out int nextY)
        {
            aMovesX.Add(newX);
            aMovesY.Add(newY);

            nextX = newX;
            nextY = newY;
        }

        public static bool MoveForward(ref char[,] board_char, int x, int y)
        {
            int flag = 0;
            if (x < SIZE - 1 && y < SIZE - 1 && board_char[x + 1, y + 1] == 'B') // South East neighbor
            {
                flag++;
            }

            if (x < SIZE - 1 && y > 0 && board_char[x + 1, y - 1] == 'B') // South West neighbor
            {
                flag++;
            }
            if (x < SIZE - 1 && board_char[x + 1, y] == 'B') // South
            {
                flag++;
            }

            if (y == 0 || y == (SIZE - 1))
            {
                if (flag > 1)
                    return false;
                else
                    return true;
            }
            else
            {
                if (flag > 2)
                    return false;
                else
                    return true;
            }
        }

        public static bool MoveSide(ref char[,] board_char, int x, int y)
        {
            int flag = 0;
            if (y < SIZE - 1 && board_char[x, y + 1] == 'B') // East neighbor
            {
                flag++;
            }

            if (y > 0 && board_char[x, y - 1] == 'B') // West neighbor
            {
                flag++;
            }

            if (y == 0 || y == (SIZE - 1))
            {
                if (flag > 0)
                    return false;
                else
                    return true;
            }
            else
            {
                if (flag > 1)
                    return false;
                else
                    return true;
            }
        }

        //public static bool MoveBack(ref char[,] board_char, int x, int y)
        //{
        //    int flag = 0;
        //    if (board_char[x - 1, y] == 'B') // North neighbor
        //    {
        //        flag++;
        //    }
        //    if (board_char[x - 1, y + 1] == 'B') // East North neighbor
        //    {
        //        flag++;
        //    }

        //    if (board_char[x - 1, y - 1] == 'B') // West North neighbor
        //    {
        //        flag++;
        //    }

        //    if (y == 0 || y == (SIZE - 1))
        //    {
        //        if (flag > 1)
        //            return false;
        //        else
        //            return true;
        //    }
        //    else
        //    {
        //        if (flag > 2)
        //            return false;
        //        else
        //            return true;
        //    }
        //}

        public static void toString(ref char[,] board_char, ref List<int> tMovesX, ref List<int> tMovesY, ref List<int> aMovesX, ref List<int> aMovesY)
        {
            Console.WriteLine("Totoshka took the following steps:");
            for (var i = 0; i < tMovesX.Count; i++)
            {
                if (board_char[tMovesX[i], tMovesY[i]] != 'B')
                {
                    Console.Write(String.Format("Step {0}: ", i + 1));
                    Console.WriteLine($"{tMovesX[i]},{tMovesY[i]}");
                }
            }

            Console.WriteLine("Ally took the following steps:");
            for (var i = 0; i < aMovesX.Count; i++)
            {
                if (aMovesX[i] == -1 && aMovesY[i] == -1)
                {
                    Console.Write("Step 1:");
                    Console.WriteLine("Stayed put");
                }
                else if (board_char[aMovesX[i], aMovesY[i]] != 'B')
                {
                    Console.Write(String.Format("Step {0}: ", i + 1));
                    Console.WriteLine($"{aMovesX[i]},{aMovesY[i]}");
                }
            }
        }

    }
}

