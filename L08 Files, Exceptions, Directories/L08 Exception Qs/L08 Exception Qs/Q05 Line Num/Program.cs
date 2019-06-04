using System.Linq;
using System.IO;
public class Program
{
    public static void Main()
    {
        //Write a program that reads a text file (inputLineNumbers.txt from the Resources - Exercises) 
        //inserts line numbers in front of each of its lines.
        //The result should be written to another text file – output.txt. 

        var inputName = "inputText.txt";

        var inputFile = File.ReadAllLines(inputName);

        for (int index = 0; index < inputFile.Count(); index++)
        {
            inputFile[index] = $"{index + 1}. {inputFile[index]}";
        }

        File.WriteAllLines("output.txt", inputFile);
    }
}