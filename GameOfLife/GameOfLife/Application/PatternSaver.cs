using System.IO;
using GameOfLife.Constants;

namespace GameOfLife.Application
{
    public static class PatternSaver
    {
        public static void SavePatternToFile(string[] pattern, string patternName)
        {
            File.WriteAllLinesAsync(RootPathConstant.RootPath + "/" + patternName + ".txt", pattern);
        }
    }
}