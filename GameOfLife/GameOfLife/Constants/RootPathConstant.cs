using System;
using System.IO;

namespace GameOfLife.Constants
{
    public  class RootPathConstant
    {
        public string RootPath { get;}

        public RootPathConstant(string filePathFromRepo)
        {
            RootPath= GetRootPath(filePathFromRepo);
        }
        

        public virtual string GetRootPath(string pathFromRootToSelectedFile)
        {
            var customRootPath = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName;
            var test = customRootPath.Split(new string[] {"/GameOfLife/GameOfLife/GameOfLife"},
                StringSplitOptions.None);
            var subRootPath = customRootPath[..37];
            return $"{test[0]}{pathFromRootToSelectedFile}";
        }
    }
}