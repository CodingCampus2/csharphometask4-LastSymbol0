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
                char[,] board = (char[,])task.Board.Clone();

                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        int aliveNeighborsCount = 0;

                        for (int ii = i - 1; ii <= i + 1; ii++)
                            for (int jj = j - 1; jj <= j + 1; jj++) //for each neighbor
                                if (ii >= 0 && ii < board.GetLength(0)
                                    && jj >= 0 && jj < board.GetLength(1) // if in bounds
                                    && !(ii == i && jj == j)) // if not center
                                    if (task.Board[ii, jj] == '1')
                                        ++aliveNeighborsCount;

                        if (task.Board[i, j] == '1')
                        {
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

                return board;
            };

            Task4.CheckSolver(TaskSolver);
        }
    }
}
