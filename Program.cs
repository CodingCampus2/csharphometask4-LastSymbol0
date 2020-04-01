using System;
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

                return board;
            };

            Task4.CheckSolver(TaskSolver);
        }
    }
}
