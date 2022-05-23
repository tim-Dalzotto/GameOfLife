using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using GameOfLife.ConsoleOut;
using GameOfLife.Domain;

namespace GameOfLife.Application
{
    public class CustomPatternBuilder
    {
        public int Height { get; set; }
        public int Length { get; set; }

        public string[,] CustomPattern { get; set; }
        public string[] ConvertedCustomPattern { get; set; }
        public int CursorYValue { get; set; }
        public int CursorXValue { get; set; }

        public CustomPatternBuilder(int height, int length)
        {
            Height = height;
            Length = length;

            CustomPattern = new string[height,length];

            for(var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Length; j++)
                {
                    CustomPattern[i, j] = "-";
                }
            }
        }
        
       
        public void DisplayWorldBuilder(IOutput output)
        {
            Console.Clear();
            for(var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Length; j++)
                {
                    if (CursorYValue == i && CursorXValue == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(CustomPattern[i, j]);
                        Console.ResetColor();
                        Console.Write(" ");

                    }
                    else
                        output.DisplayGameCell(CustomPattern[i, j] +" ");
                }
                output.DisplayGameCell("\n");
            }
        }
        
        public void MoveCursor(char UserInput)
        {
            if (UserInput == 'w')
            {
                if (CursorYValue == 0)
                    CursorYValue = Height -1;
                else
                    CursorYValue--;
            }
            if (UserInput == 's')
            {
                if (CursorYValue == Height)
                    CursorYValue = 0;
                else
                    CursorYValue++;
            }
            
            if (UserInput == 'a')
            {
                if (CursorXValue == 0)
                    CursorXValue = Length -1;
                else
                    CursorXValue--;
            }
            if (UserInput == 'd')
            {
                if (CursorXValue == Length)
                    CursorXValue = 0;
                else
                    CursorXValue++;
            }
            
        }
        public void SetAliveOrDead(string input)
        {
            var setState = input == "p" ? "0" : "-";
            CustomPattern[CursorYValue,CursorXValue] = setState;
        }
        
        //MakeThePattern


        [SuppressMessage("ReSharper", "HeapView.BoxingAllocation")]
        public void MakePattern(IUserInput input, IOutput output)
        {
            var keepBuilding = true;
            while (keepBuilding)
            {
                DisplayWorldBuilder(output);
                output.DisplayOptionsForPatternBuilder();
                var userInput = input.GetUserInput().ToLower();
                if (!Validator.ValidCharForCustomWorldBuilder(userInput))
                {
                    output.DisplayMessage("Please enter a valid input");
                    continue;
                }
                if(userInput.All(c => "wasd".Contains(c)))
                    MoveCursor(Char.Parse(userInput));
                if(userInput.All(c => "op".Contains(c)))
                    SetAliveOrDead(userInput);
                if (userInput == "q")
                {
                    keepBuilding = false;
                    ConvertMultiDimensionalArrayToStringArray(CustomPattern);
                }
            }
        }
        
        public void ConvertMultiDimensionalArrayToStringArray(string[,] multidimensionalArray)
        {
            var convertedList = new List<string>();
            for(var i = 0; i < multidimensionalArray.GetLength(0); i++)
            {
                string tempString = null;
                for (var j = 0; j < multidimensionalArray.GetLength(1); j++)
                {
                    tempString += multidimensionalArray[i, j];
                }
                convertedList.Add(tempString);
            }
            ConvertedCustomPattern = convertedList.ToArray();
        }
    }
}