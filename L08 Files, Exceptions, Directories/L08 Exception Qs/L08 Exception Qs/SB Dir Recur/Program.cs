using System;
using System.IO;

namespace SB_Dir_Recur
{
    public class Program
    {
        public static void Main()
        {
            // this will be a method to open and cycle through every directory in a given directory 
            // while printing out the names of all files before moving onto the next file.

            string parentDirName = "FindMySecrets";

            var currentDirInfo = new DirectoryInfo(parentDirName);

            TraverseDirectory(currentDirInfo);
        }

        public static void TraverseDirectory(DirectoryInfo currentDirInfo, string dirPrefix = "") // runs through a dir, every new dir has a prefix (+), deeper dirs get more +'s, files have a -- prefix
        {
            foreach (var dir in currentDirInfo.GetDirectories())
            {
                Console.WriteLine($"{dirPrefix} {dir.Name}");
                TraverseDirectory(dir, dirPrefix += "+");
            }

            foreach (var file in currentDirInfo.GetFiles())
            {
                Console.WriteLine($"--{file.Name}");
            }
        }
    }
}
