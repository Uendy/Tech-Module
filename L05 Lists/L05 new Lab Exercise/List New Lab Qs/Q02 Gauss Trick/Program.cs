using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program that sums all of the numbers in a list in the following order: 
        //first + last, first + 1 + last - 1, first + 2 + last - 2, … first + n, last - n.

        var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        var outPutList = new List<int>();

        for (int index = 0; index < list.Count() / 2; index++)
        {
            int indexOnRight = list.Count() - 1 - index;

            outPutList.Add(list[index] + list[indexOnRight]);
        }

        if (list.Count() % 2 != 0) // odd
        {
            outPutList.Add(list[list.Count() / 2]);
        }

        string outPut = string.Join(" ", outPutList);
        Console.WriteLine(outPut);
    }
}