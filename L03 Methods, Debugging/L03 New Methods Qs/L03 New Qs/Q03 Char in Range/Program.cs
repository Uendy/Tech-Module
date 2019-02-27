using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        //Write a method that receives two characters.
        //Prints on a single line all the characters in between them according to ASCII.

        char firstChar = char.Parse(Console.ReadLine());
        char secondChar = char.Parse(Console.ReadLine());

        int start = (Math.Min((int)firstChar, (int)secondChar)); // incase they give the larger value char first
        int end = (Math.Max((int)firstChar, (int)secondChar));

        FindCharsInRange(start, end);
    }

    public static void FindCharsInRange(int start, int end) /// Returns a string of chars in the given range
    {
        var listOfChars = new List<char>();

        for (int index = start + 1; index < end; index++)
        {
            listOfChars.Add((char)index);
        }

        string outPut = string.Join(" ", listOfChars);

        Console.WriteLine(outPut);
    }
}