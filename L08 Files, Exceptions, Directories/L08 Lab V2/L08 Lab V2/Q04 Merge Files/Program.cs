using System.Collections.Generic;
using System.IO;
public class Program
{
    public static void Main()
    {
        //Write a program that reads the contents of two text files and merges them together into a third one.

        var firstFile = "inputText1.txt";
        var secondFile = "inputText2.txt";

        var firstFileContents = File.ReadAllLines(firstFile);
        var secondFileContents = File.ReadAllLines(secondFile);

        var output = new List<string>();

        for (int index = 0; index < firstFileContents.Length; index++)
        {
            output.Add(firstFileContents[index]);
            output.Add(secondFileContents[index]);
        }

        File.WriteAllLines("outputText.txt", output);
    }
}