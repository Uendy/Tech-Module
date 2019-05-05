using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Read a list of real numbers and print largest 3 of them. 
        //If less than 3 numbers exit, print all of them.

        var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        nums = nums.OrderByDescending(x => x).ToList();

        if (nums.Count() >= 3)
        {
            nums = nums.Take(3).ToList();
        }

        string outPut = string.Join(" ", nums);
        Console.WriteLine(outPut);
    }
}