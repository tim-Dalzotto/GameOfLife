using System;
using System.IO;

namespace GameOfLife.Constants
{
    public class RootPathConstant
    {
        public static readonly string RootPath = GetRootPath("/GameOfLife/GameOfLife/GameOfLife/PatternFileDirectory/");
        

        public static string GetRootPath(string PathFromRootToSelectedFile)
        {
            var customRootPath = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName;
            var subRootPath = customRootPath[..37];
            return $"{subRootPath}{PathFromRootToSelectedFile}";
        }
    }
}