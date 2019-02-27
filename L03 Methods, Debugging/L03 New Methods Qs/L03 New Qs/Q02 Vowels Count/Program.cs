using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        //Write a method that receives a single string and prints the count of the vowels.
        //Use appropriate name for the method.

        string inputText = Console.ReadLine();

        Console.WriteLine(VowelFinder(inputText));
    }

    public static int VowelFinder(string inputText)
    {
        int numberOfVowels = 0;
        var listOfVowels = new List<char>(new char[] { 'a', 'e', 'i', 'u', 'o', 'A', 'E', 'I', 'U', 'O' });

        var inputAsCharArray = inputText.ToCharArray();

        foreach (var letter in inputAsCharArray)
        {
            if (listOfVowels.Contains(letter))
            {
                numberOfVowels++;
            }
        }

        return numberOfVowels;
    }
}
