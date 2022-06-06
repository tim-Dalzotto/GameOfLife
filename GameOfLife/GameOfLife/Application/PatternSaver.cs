using System.IO;
using GameOfLife.Constants;

namespace GameOfLife.Application
{
    public class PatternSaver
    {
        private readonly RootPathConstant _rootPathConstant;

        public PatternSaver(RootPathConstant rootPathConstant)
        {
            _rootPathConstant = rootPathConstant;
        }
        public void SavePatternToFile(string[] pattern, string patternName)
        {
            File.WriteAllLinesAsync(_rootPathConstant.RootPath + "/" + patternName + ".txt", pattern);
        }
    }
}