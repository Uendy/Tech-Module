using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        //Write a program to append several lists of numbers.
        //	Lists are separated by ‘|’.
        //	Values are separated by spaces(‘ ’, one or several)
        //	Order the lists from the last to the first, and their values from left to right.

        var input = Console.ReadLine();
        var list = new List<int>();

        var array = input.Split('|')
            .ToArray();
        foreach (var setOfNums in array)
        {
            var currentSet = setOfNums.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            list.InsertRange(0, currentSet);
        }

        string outPut = string.Join(" ", list);
        Console.WriteLine(outPut);
    }
}