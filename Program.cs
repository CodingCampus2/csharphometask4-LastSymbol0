using System;
using System.Collections.Generic;
using System.Linq;
using CodingCampusCSharpHomework;

namespace HomeworkTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<Task4, char[,]>TaskSolver = task =>
            {
                char[,] board = (char[,])task.Board.Clone();

                int height = board.GetLength(0);
                int width = board.GetLength(1);

                char[,] resboard = new char[height, width];

                //List<char> boardLS = board.OfType<char>().ToList();
                List<char> boardL = board.OfType<char>().ToList();


                var calculatedBoard = boardL.Select(
                    (ch, i) => {
                        int x = i % width;
                        int y = i / width;

                        //int aliveNeighborsCount = boardL.Where(
                        //    (ch_n, i_n) =>
                        //    {
                        //        int xx = i_n % width;
                        //        int yy = i_n / width;

                        //        return (xx >= x - 1 && xx <= x + 1)
                        //            && (yy >= y - 1 && yy <= y + 1)
                        //            && !(xx == x && yy == y);
                        //    }).Aggregate(0, (count, ch_) => ch_ == '1' ? count + 1 : count);
                        //Console.WriteLine($"[{y}][{x}]: {ch}, a_n: {aliveNeighborsCount}");

                        return new
                        {
                            x, y, alive = (ch == '1'),
                            aliveNeighborsCount = boardL.Where(
                            (ch_n, i_n) =>
                            {
                                int xx = i_n % width;
                                int yy = i_n / width;

                                return (xx >= x - 1 && xx <= x + 1)
                                    && (yy >= y - 1 && yy <= y + 1)
                                    && !(xx == x && yy == y);
                            }).Aggregate(0, (count, ch_) => ch_ == '1' ? count + 1 : count)
                        };
                    });

                foreach (var val in calculatedBoard)
                {
                    ref char currentCell = ref resboard[val.y, val.x];

                    if (val.alive)
                    {
                        if (val.aliveNeighborsCount < 2 || val.aliveNeighborsCount > 3)
                            currentCell = '0';
                        else
                            currentCell = '1';
                    }
                    else
                    {
                        if (val.aliveNeighborsCount == 3)
                            currentCell = '1';
                        else
                            currentCell = '0';
                    }
                }

                //for (int i = 0; i < board.GetLength(0); i++)
                //{
                //    for (int j = 0; j < board.GetLength(1); j++)
                //    {
                //        int aliveNeighborsCount = 0;

                //        for (int ii = i - 1; ii <= i + 1; ii++)
                //            for (int jj = j - 1; jj <= j + 1; jj++) //for each neighbor
                //                if (ii >= 0 && ii < board.GetLength(0)
                //                    && jj >= 0 && jj < board.GetLength(1) // if in bounds
                //                    && !(ii == i && jj == j)) // if not center
                //                    if (task.Board[ii, jj] == '1')
                //                        ++aliveNeighborsCount;

                //        if (task.Board[i, j] == '1')
                //        {
                //            if (aliveNeighborsCount < 2 || aliveNeighborsCount > 3)
                //                board[i, j] = '0';
                //            else
                //                board[i, j] = '1';
                //        }
                //        else if (aliveNeighborsCount == 3)
                //        {
                //            board[i, j] = '1';
                //        }
                //    }
                //}

                return resboard;
            };

            Task4.CheckSolver(TaskSolver);
        }
    }
}
