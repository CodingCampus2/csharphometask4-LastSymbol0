# Task 4

## Prerequisites:
Read .NET Book Zero until Chapter 10.

## Description:
You are given a board [task.Board] in which each cell has an initial state: live '1' or dead '0'. Each cell interacts with its eight neighbors (horizontally, vertically and diagonally) using the following four rules:

1. Any live cell with fewer than two live neighbors dies, as if caused by under-population.
2. Any live cell with two or three live neighbors lives on to the next generation.
3. Any live cell with more than three live neighbors dies, as if by over-population.
4. Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.

Write a program to compute the next state (after one update) of the board given its current state.

## Goal:
Create 2d char array that shows next state (after one update) of the board given its current state.

## Example input: 
[task.Board] = 
000  
111  
000  

## Example output:
010  
010  
010  

## Task clarifications:
---

## Bonus task:  
1. Replace the live and dead state of the cell with the chars of your choice.  
2. Take the starting data state from the task and launch an infinite cycle of Game of Life.  
3. Record the gif or take a screenshot of what is happening.  
Tips: 
Use `Console.SetCursorPosition(0, 0);` and `Console.CursorVisible = false;` to redraw the image in console.

## Credits:
Original idea of the task was taken from CodinGames - [link](https://www.codingame.com/ide/puzzle/game-of-life)
