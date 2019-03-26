using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Read a list of integers, remove all negative numbers from it and print the remaining elements in reversed order.
        //In case of no elements left in the list, print “empty”.

        var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        var finalList = new List<int>();

        foreach (var num in list)
        {
            bool notNegative = num >= 0;
            if (notNegative == true)
            {
                finalList.Add(num);
            }
        }

        bool emptyList = finalList.Count() == 0;
        if (emptyList == true)
        {
            Console.WriteLine("empty");
        }
        else
        {
            finalList.Reverse();
            string outPut = string.Join(" ", finalList);
            Console.WriteLine(outPut);
        }
    }
}