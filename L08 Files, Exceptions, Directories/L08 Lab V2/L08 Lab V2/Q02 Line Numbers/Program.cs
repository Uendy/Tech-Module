using System.Linq;
using System.IO;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        //Write a program that reads a text file and inserts line numbers in front of each of its lines.
        //The result should be written to another text file. 

        var file = "inputText.txt";

        var lines = File.ReadAllLines(file);

        var numberedLines = new List<string>();

        for (int index = 0; index < lines.Count(); index++)
        {
            numberedLines.Add($"{index + 1}. {lines[index]}");
        }

        File.WriteAllLines("resultFile.txt", numberedLines);
    }
}