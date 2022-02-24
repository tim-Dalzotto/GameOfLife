using System;
using System.Linq;
using GameOfLife.Domain;

namespace GameOfLife.ConsoleOut
{
    public class ConsoleOutput : IOutput

    {
    public void DisplayWorld(World world)
    {
        Console.Clear();
        for (var i = 0; i < world.WorldPopulation.GetLength(0); i++)
        {
            for (var j = 0; j < world.WorldPopulation.GetLength(1); j++)
            {
                Console.Write(world.WorldPopulation[i, j].IsAlive == true ? 'O' : '-');
                Console.Write(" ");
            }

            Console.WriteLine();
        }
    }

    public void DisplayPatternSelection()
    {
        Console.WriteLine("Please select a pattern to load");
        Console.WriteLine("1.Glider");
        Console.WriteLine("2.Box");
        Console.WriteLine("3.Duck");
    }

    public void DisplayGameBoardSizeSelectionMessage(int minRowSize, int minColumnSize)
    {
        Console.WriteLine(
            $"Select the size of the game board you would like to use, min requirements for selected pattern is {minRowSize.ToString()}X{minColumnSize.ToString()}");
    }

    public void DisplayChoiceForRowsMessage()
    {
        Console.WriteLine("How many rows would you like?");
    }

    public void DisplayChoiceForColumnsMessage()
    {
        Console.WriteLine("How many columns would you like?");
    }

    }
}