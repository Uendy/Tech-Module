using System;
using System.Linq;
using System.IO;
public class Program
{
    public static void Main()
    {
        //Write a program that reads a text file (input.txt from the Resources - Exercises)
        //prints on the console the sum of the ASCII symbols of each of its lines.
        //Use BufferedReader in combination with FileReader.

        var file = "input.txt";

        var linesInFile = File.ReadAllLines(file);

        foreach (var line in linesInFile)
        {
            int sum = line.Sum(b => b);
            Console.WriteLine(sum);
        }
    }
}