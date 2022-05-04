using System;
using System.Collections.Generic;
using GameOfLife.ConsoleOut;
using GameOfLife.Domain;

namespace GameOfLife.Application
{
    public class CustomWorldBuilder
    {
        public int Height { get; set; }
        public int Length { get; set; }

        public string[,] CustomPattern { get; set; }
        public int CursorYValue { get; set; }
        public int CursorXValue { get; set; }

        public CustomWorldBuilder(int height, int length)
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
        
        //DisplayBlankWorld
        public void DisplayWorldBuilder(IOutput output)
        {
            for(var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Length; j++)
                {
                    output.DisplayGameCell(CustomPattern[i, j]);
                }
                output.DisplayGameCell("\n");
            }
        }
        
        //MoveCursor
        public void MoveCursor(char UserInput)
        {
            if (UserInput == 'w')
            {
                if (CursorYValue == 0)
                    CursorYValue = Height;
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
                    CursorXValue = Length;
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
        public char SetAliveOrDead(char input)
        {
            return input == 'p' ? '0' : '-';
        }
        
        //MakeThePattern

       
    }
}