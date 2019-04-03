using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Read a list of integers and extract all square numbers from it and print them in descending order. 
        //A square number is an integer which is the square of any integer.
        //For example, 1, 4, 9, 16 are square numbers.

        var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        var listOfSquareNums = new List<int>();

        foreach (var num in array)
        {
            double numSquared = Math.Sqrt(num);
            int numRoundedSquared = (int)Math.Sqrt(num);

            if (numRoundedSquared == numSquared)
            {
                listOfSquareNums.Add(num);
            }
        }

        listOfSquareNums = listOfSquareNums.OrderByDescending(x => x).ToList();
        string outPut = string.Join(" ", listOfSquareNums);
        Console.WriteLine(outPut);
    }
}