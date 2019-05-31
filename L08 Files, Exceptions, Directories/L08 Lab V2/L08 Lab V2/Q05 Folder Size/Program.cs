using System;
using System.IO;
public class Program
{
    public static void Main()
    {
        //You are given a folder named “TestFolder”. Get the size of all files in the folder, which are NOT directories. 
        //The result should be written to another text file in Megabytes.

        var currentFile = Directory.GetFiles("TestFolder");

        double sum = 0.0;

        foreach (var file in currentFile)
        {
            var fileInfo = new FileInfo(file);
            sum += fileInfo.Length;
        }

        Console.WriteLine(sum / 1024.0 / 1024.0);
    }
}