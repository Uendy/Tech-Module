using System;
using System.IO;
public class Program
{
    public static void Main()
    {
        //Write a program that reads a text file (input.txt from the Resources - Exercises)  
        //changes the casing of all letters to upper. 
        //Write the output to another file (output.txt). 

        string file = "inputText.txt";

        if (File.Exists(file))
        {
            var textInFile = File.ReadAllText(file).ToUpper();

            File.WriteAllText("outputText.txt", textInFile);
        }
        else
        {
            Console.WriteLine($"File {file} does not exist");
            Environment.Exit(0);
        }
    }
}