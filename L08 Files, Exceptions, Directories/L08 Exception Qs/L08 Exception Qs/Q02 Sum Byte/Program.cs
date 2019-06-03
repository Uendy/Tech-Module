using System;
using System.IO;
public class Program
{
    public static void Main()
    {
        //Write a program that reads a text file (input.txt from the Resources - Exercises) 
        //prints on the console the sum of the ASCII symbols of all characters inside of the file.
        //Use BufferedReader in combination with FileReader.

        string inputName = "inputText.txt";

        var inputLines = new string[0];

        if (File.Exists(inputName))
        {
             inputLines = File.ReadAllLines(inputName);
        }
        else
        {
            Console.WriteLine($"File {inputName} does not exist");
            Environment.Exit(0);
        }

        long sum = 0;

        foreach (var line in inputLines)
        {
            foreach (var charecter in line.ToCharArray())
            {
                sum += charecter;
            }
        }

        Console.WriteLine(sum);
    }
}