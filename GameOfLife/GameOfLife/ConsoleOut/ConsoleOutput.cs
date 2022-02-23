using System;
using System.Linq;
using GameOfLife.Domain;

namespace GameOfLife.ConsoleOut
{
    public class ConsoleOutput
    {
        public static void DisplayWorld(World world)
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

        public static void DisplayPatternSelection()
        {
            Console.WriteLine("Please select a pattern to load");
            Console.WriteLine("1.Glider");
            Console.WriteLine("2.Box");
            Console.WriteLine("3.Duck");
        }

        public static void DisplayGameBoardSizeSelection(Tuple<int,int> patternWorldRestrictions)
        {
            var (patternXCoOrds, patternYCoOrds) = patternWorldRestrictions;
            Console.WriteLine($"Select the size of the game board you would like to use, min requirements for selected pattern is {patternXCoOrds.ToString()}X{patternYCoOrds.ToString()}");
        }

        public static void DisplayChoiceForRows()
        { 
            Console.WriteLine("How many rows would you like?");
        }
        public static void DisplayChoiceForColumns()
        { 
            Console.WriteLine("How many columns would you like?");
        }
        
    }
}