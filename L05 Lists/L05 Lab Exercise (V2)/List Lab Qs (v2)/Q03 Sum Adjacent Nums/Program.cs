using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program to sum all adjacent equal numbers in a list of decimal numbers, starting from left to right.
        //	After two numbers are summed, the obtained result could be equal to some of its neighbors and should be summed as well (see the examples below).
        //	Always sum the leftmost two equal neighbors(if several couples of equal neighbors are available).

        var list = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
        if (list.Count() == 1)
        {
            Console.WriteLine(list[0]);
            Environment.Exit(0);
        }
        var list;
        bool keepCycling = true;
        while (keepCycling == true)
        {
            keepCycling = false;

            for (int index = 0; index < list.Count - 1; index++)
            {
                bool checkEqualNumber = list[index] == list[index + 1];
                if (checkEqualNumber == true)
                {
                    list[index + 1] = list[index] + list[index + 1];
                    list.RemoveAt(index);
                    keepCycling = true;
                }
            }
        }

        string outPut = string.Join(" ", list);
        Console.WriteLine(outPut);
    }
}