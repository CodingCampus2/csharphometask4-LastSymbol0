using System;
using System.Collections.Generic;
using System.Linq;
using CodingCampusCSharpHomework;
using System.Threading;

namespace HomeworkTemplate
{
    class Program
    {
        class CellDescription
        {
            public int x, y, aliveNeighborsCount;
            public bool alive;
        }
        static void Main(string[] args)
        {

            var properties = new
            {
                isInfinity = true,
                isVisible = true,
                char_sign = new { alive = '+', dead = ' ' }
            };

            bool IsAliveInNextGen(bool isAlive, int aliveNeighborsCount) => isAlive ? !(aliveNeighborsCount < 2 || aliveNeighborsCount > 3) : aliveNeighborsCount == 3;
            
            bool IsNeighbor((int x, int y) center, (int x, int y) current) => 
                   (current.x >= center.x - 1 && current.x <= center.x + 1)
                && (current.y >= center.y - 1 && current.y <= center.y + 1)
                && !(center == current);

            void Draw(List<CellDescription> board)
            {
                foreach (var val in board)
                {
                    Console.SetCursorPosition(val.x, val.y);
                    Console.BackgroundColor = val.alive ? ConsoleColor.DarkBlue : ConsoleColor.Black;
                    Console.ForegroundColor = val.alive ? ConsoleColor.DarkBlue : ConsoleColor.Black;
                    Console.Write(val.alive ? properties.char_sign.alive : properties.char_sign.dead);
                    //Console.Write(val.aliveNeighborsCount);
                }
            }

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

                        return new CellDescription
                        {
                            x = x, y = y, alive = (ch == '1'),
                            aliveNeighborsCount = boardList.Where(
                            (ch_n, i_n) =>
                            {
                                int xx = i_n % width;
                                int yy = i_n / width;

                                return IsNeighbor((x, y), (xx, yy));
                            }).Count(ch_ => ch_ == '1')
                        };
                    });

                foreach (var val in calculatedBoard)
                {
                    ref char currentCell = ref resboard[val.y, val.x];

                    currentCell = IsAliveInNextGen(val.alive, val.aliveNeighborsCount) ? '1' : '0';
                }


                //extra part
                {
                    if (properties.isVisible)
                        Console.CursorVisible = false;

                    List<CellDescription> board = calculatedBoard.ToList();

                    while (properties.isInfinity)
                    {
                        if (properties.isVisible)
                            Draw(board);
                        //Console.ReadKey();

                        board.ForEach(val => val.alive = IsAliveInNextGen(val.alive, val.aliveNeighborsCount));

                        board.ForEach(val =>
                        {
                            var neighbors = board.Where((val_n) => IsNeighbor((val.x, val.y), (val_n.x, val_n.y)));

                            val.aliveNeighborsCount = neighbors.Count(val_ => val_.alive);
                        });
                    }
                }

                return resboard;
            };

            Task4.CheckSolver(TaskSolver);
        }
    }
}
