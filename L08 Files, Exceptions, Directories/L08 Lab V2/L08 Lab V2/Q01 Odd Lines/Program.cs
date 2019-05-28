using System.Collections.Generic;
using System.Linq;
using System.IO;
public class Program
{
    public static void Main()
    {
        //Write a program that reads a text file and writes its every odd line in another file. Line numbers starts from 0. 

        var file = "InputText.txt";

        var lines = File.ReadAllLines(file);

        var oddLines = new List<string>();

        for (int i = 1; i < lines.Count(); i+=2) // skip every 2nd
        {
            oddLines.Add(lines[i]);
        }

        File.WriteAllLines("result.txt", oddLines);
    }
}