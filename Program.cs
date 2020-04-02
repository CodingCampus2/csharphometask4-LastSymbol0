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
                int height = task.Board.GetLength(0);
                int width = task.Board.GetLength(1);
                char[,] resboard = new char[height, width];

                List<char> boardList = task.Board.OfType<char>().ToList();

                var calculatedBoard = boardList.Select(
                    (ch, i) => {
                        int x = i % width;
                        int y = i / width;

                        return new
                        {
                            x, y, alive = (ch == '1'),
                            aliveNeighborsCount = boardList.Where(
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

                return resboard;
            };

            Task4.CheckSolver(TaskSolver);
        }
    }
}
