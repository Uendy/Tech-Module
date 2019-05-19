using System;
using System.Collections.Generic;
using System.IO;
public class Program
{
    public static void Main()
    {
        //Write a program that reads a text file and writes its every odd line in another file. Line numbers starts from 0. 

        var fileInput = "input.txt";

        var lines = File.ReadAllLines(fileInput);

        var arrayOfOutput = new List<string>();

        for (int indexOfLine = 1; indexOfLine < fileInput.Length; indexOfLine += 2)
        {
            arrayOfOutput.Add(lines[indexOfLine]);
        }

        if (!File.Exists("fileOutput.txt"))
        {
            File.Create("fileOutput.txt");
        }
        var fileOutput = "fileOutput.txt";

        File.WriteAllLines(fileOutput, arrayOfOutput);

        var output = File.ReadAllLines(fileOutput);

        foreach (var line in output)
        {
            Console.WriteLine(line);
        }
    }
}