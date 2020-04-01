using System;
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
                // Your solution goes here
                // You can get all needed inputs from task.[Property]
                // Good luck!
                char[,] board = task.Board;

                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        int aliveNeighborsCount = 0;

                        for (int ii = i - 1; ii <= i + 1; ii++)
                            for (int jj = j - 1; jj <= j + 1; jj++)
                                if (ii >= 0 && ii < board.GetLength(0)
                                    && jj >= 0 && jj < board.GetLength(1)
                                    && board[ii, jj] == '1')
                                {
                                    Console.WriteLine($"[{ii}][{jj}] Found aliveNeighbor");
                                    ++aliveNeighborsCount;
                                }
                        Console.WriteLine($"For [{i}][{j}] found {aliveNeighborsCount} aliveNeighborsCount");
                        if (board[i, j] == '1')
                        {
                            --aliveNeighborsCount;
                            if (aliveNeighborsCount < 2 || aliveNeighborsCount > 3)
                                board[i, j] = '0';
                            else
                                board[i, j] = '1';
                        }
                        else if (aliveNeighborsCount == 3)
                        {
                            board[i, j] = '1';
                        }
                    }
                }

                Console.WriteLine("Real input:");
                for (int i = 0; i < task.Board.GetLength(0); i++)
                {
                    for (int j = 0; j < task.Board.GetLength(1); j++)
                    {
                        Console.Write(task.Board[i, j]);
                    }
                    Console.WriteLine();
                }
                return board;
            };

            Task4.CheckSolver(TaskSolver);
        }
    }
}
