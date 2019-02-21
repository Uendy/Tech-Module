using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        //write a program that prints part of the ASCII table of characters at the console.
        //On the first line of input you will receive the char index you should start with
        //and on the second line - the index of the last character you should print.

        int firstCharAsInt = int.Parse(Console.ReadLine());
        int secondCharAsInt = int.Parse(Console.ReadLine());

        var listOfChars = new List<char>();

        for (int index = firstCharAsInt; index <= secondCharAsInt; index++)
        {
            listOfChars.Add((char)index);
        }

        var output = string.Join(" ", listOfChars);

        Console.WriteLine(output);

    }
}
