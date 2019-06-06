using System;
using System.Linq;
using System.IO;
public class Program
{
    public static void Main()
    {
        //Write a program that reads the contents of two text files (inputOne.txt, inputTwo.txt from Resources Exercises) 
        //merges them together into a third one.

        var firstFile = "inputFileOne.txt";
        var secondFile = "inputFileTwo.txt";

        var firstFileContents = File.ReadAllLines(firstFile);
        var secondFileContents = File.ReadAllLines(secondFile);

        int maxInt = Math.Max(firstFileContents.Count(), secondFileContents.Count());

        string outputFileName = "outputFile.txt";
        File.WriteAllText(outputFileName, string.Empty);

        for (int index = 0; index < maxInt; index++)
        {
            try
            {
                File.AppendAllText(outputFileName, firstFileContents[index] + Environment.NewLine);
                File.AppendAllText(outputFileName, secondFileContents[index] + Environment.NewLine);
            }
            catch (Exception)
            {

                throw new Exception ("outside of array");
            }
        }
    }
}