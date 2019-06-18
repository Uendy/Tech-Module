using System;
public class Program
{
    public static void Main()
    {
        //Write a program to find how many times a given string appears in a given text as substring. 
        //The text is given at the first input line. 
        //The search string is given at the second input line. 
        //The output is an integer number. 
        //Please ignore the character casing. 
        //Overlapping between occurrences is allowed. 

        string text = Console.ReadLine();
        string substring = Console.ReadLine();
        int occurances = 0;

        int currentIndex = 0;

        while (currentIndex <= text.Length - 1)
        {
            currentIndex = text.IndexOf(substring, currentIndex);
            if (currentIndex < 0)
            {
                Console.WriteLine(occurances);
                Environment.Exit(0);
            }
            else
            {
                occurances++;
                currentIndex++;
            }
        }
        Console.WriteLine(occurances);

    }
}