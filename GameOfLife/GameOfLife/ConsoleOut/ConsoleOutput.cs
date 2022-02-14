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
    }
}