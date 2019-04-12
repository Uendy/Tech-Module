using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program to append several arrays of numbers.
        //	Arrays are separated by ‘|’.
        //	Values are separated by spaces(‘ ’, one or several).
        //	Order the arrays from the last to the first, and their values from left to right.

        var initialList = Console.ReadLine().Split('|').ToList();

        var finalList = new List<int>();
        foreach (var list in initialList)
        {
            var currentList = list.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            finalList.InsertRange(0, currentList);
        }

        string outPut = string.Join(" ", finalList);
        Console.WriteLine(outPut);
    }
}