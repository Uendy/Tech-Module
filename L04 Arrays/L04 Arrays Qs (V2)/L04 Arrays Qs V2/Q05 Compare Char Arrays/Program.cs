using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Compare two char arrays lexicographically (letter by letter).
        //Print the them in alphabetical order, each on separate line.

        var firstArray = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
        var secondArray = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

        var firstString = string.Join("", firstArray);
        var secondString = string.Join("", secondArray);

        int result = string.Compare(firstString, secondString, true);
        if (result <= 0)
        {
            Console.WriteLine(firstString);
            Console.WriteLine(secondString);
        }
        else
        {
            Console.WriteLine(secondString);
            Console.WriteLine(firstString);
        }
    }
}