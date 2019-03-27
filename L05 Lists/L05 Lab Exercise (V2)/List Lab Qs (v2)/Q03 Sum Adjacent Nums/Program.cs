using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program to sum all adjacent equal numbers in a list of decimal numbers, starting from left to right.
        //	After two numbers are summed, the obtained result could be equal to some of its neighbors and should be summed as well (see the examples below).
        //	Always sum the leftmost two equal neighbors(if several couples of equal neighbors are available).

        var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        bool keepGoing = true;
        while (keepGoing == true)
        {
            for (int index = 0; index < list.Count() - 1; index++)
            {
                int currentNum = list[index];
                int nextNum = list[index + 1];

                bool adjacent = currentNum == nextNum;
                if (adjacent == true)
                {
                    int indexOfCurrentNum = list.IndexOf(currentNum);
                    int indexOfNextNum = list.IndexOf(nextNum);

                    list.RemoveAt(indexOfCurrentNum);
                    list[indexOfNextNum] += currentNum;
                    //list.RemoveAt(indexOfNextNum);
                    break;
                }

                bool noMoreAdjacent = list.Count() - 2 == index;
                if (noMoreAdjacent == true)
                {
                    keepGoing = false;
                }
            }
        }

        string outPut = string.Join(" ", list);
        Console.WriteLine(outPut);
    }
}