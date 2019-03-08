using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program, which prints common elements in two arrays.
        //You have to compare the elements of the second array to the elements of the first.

        var firstArrString = Console.ReadLine();
        var firstArray = firstArrString.Split(' ');

        var secondArrString = Console.ReadLine();
        var secondArray = secondArrString.Split(' ');

        string commonElements = string.Empty;

        foreach (var currentString in secondArray)
        {
            bool commonElement = firstArray.Contains(currentString);
            if (commonElement == true)
            {
                commonElements = string.Concat(commonElements, currentString + ' ');
            }
        }

        Console.WriteLine(commonElements);
    }
}
