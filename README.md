# Conway's Game Of Life
The Game of Life, also known simply as Life, is a cellular automaton devised by the British mathematician John Horton Conway in 1970. 

The "game" is a zero-player game, meaning that its evolution is determined by its initial state, requiring no further input.

A seed generation is created on a grid with a pattern of living cells. 

The next generation is created by applying a set of rules to the cells of the previous generation. 

A sequence of generations will play out on the grid.
## Rules
- Any live cell with fewer than two live neighbours dies as if caused by underpopulation.
- Any live cell with more than three live neighbours dies, as if by overcrowding.
- Any live cell with two or three live neighbours lives on to the next generation.
- Any dead cell with exactly three live neighbours becomes a live cell. 
- Any cell on the fringe of the grid will wrap around to the other side.

## Ways To Play The Game 

There are two ways to start the game:
- **Run the Game With Predetermined Pattern:** To run the game with a predetermined seed, you need to be at the solution level and run the command "dotnet run <valid File name / or valid file path>". This skips the normal file selection process. After selecting the world size, the game will run.

- **Run the Game Without a Predetermine Pattern:** At the solution level, run the command "dotnet run". After the game loads, you will enter the pattern selection process. From here, you can either select a pre-loaded pattern or select the custom world option to create your pattern.

## Ways the Game Ends

There are 2 ways for the game to end:
-**By Pressing 'p':** By pressing the 'p' key at any time, the game will stop.
-**When there is no more movement** When all cells have died, or the world has stagnated, then the game will stop.

## Saving a New Pattern
-**Saving A Pattern During the Game:** After pressing 'p' to stop the game, you will be prompted if you want to save the current frame. You can save the world frame by pressing 's'. After pressing 's', you will be prompted to enter a name for the new pattern you want to create.
