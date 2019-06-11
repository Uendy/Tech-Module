using System;
using System.Linq;
using System.IO;

public class Program
{
    public static void Main()
    {
        //Write a program that traverses a folder and calculates its size in bytes. 
        //Use Folder Exercises Resources in Resources.

        //Kenov ways:
        var totalSize = Directory.GetFiles("FindMySize").Select(f => new FileInfo(f)).Sum(f => f.Length);
        Console.WriteLine(totalSize);

        //My Way:
        string dirName = "FindMySize";

        var files = Directory.GetFiles(dirName);

        long size = 0;

        foreach (var file in files)
        {
            var currentFileInfo = new FileInfo(file);
            size += currentFileInfo.Length;
        }

        Console.WriteLine($"{size}B");
        Console.WriteLine($"{size / 1024.0}KB");
        Console.WriteLine($"{size / 1024.0 / 1024.0}MB");
    }
}