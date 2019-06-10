using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class Program
{
    public static void Main()
    {
        //Write a program that traverses a folder and calculates its size in bytes. 
        //Use Folder Exercises Resources in Resources.

        var totalSize = Directory.GetFiles("FindMySize").Select(f => new FileInfo(f)).Sum(f => f.Length);
        Console.WriteLine(totalSize);

        //I couldnt read them as I was looking for files where I had directories

        if (Directory.Exists("dir"))
        {
            var files = Directory.GetFiles("dir");
        }
        //var rootDir = "dir";

        ////var dirInfo = new DirectoryInfo(rootDir);

        //var filesInDir = Directory.GetFiles(rootDir);

        //long sumOfSize = 0;
        //foreach (var file in filesInDir)
        //{
        //    sumOfSize += file.Length;
        //}


        //Console.WriteLine(sumOfSize);
    }
}