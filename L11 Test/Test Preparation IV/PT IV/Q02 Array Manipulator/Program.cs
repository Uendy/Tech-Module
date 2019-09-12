using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        //Trifon has finally become a junior developer and has received his first task. It’s about manipulating an array of integers.
        //He is not quite happy about it, since he hates manipulating arrays.
        //They are going to pay him a lot of money, though, and he is willing to give somebody half of it if to help him do his job. 
        //You, on the other hand, love arrays(and money) so you decide to try your luck.

        //The array may be manipulated by one of the following commands:

        //•	exchange { index} – splits the array after the given index, and exchanges the places of the two resulting sub - arrays.
        //E.g. [1, 2, 3, 4, 5]->exchange 2->result: [4, 5, 1, 2, 3]
        //o If the index is outside the boundaries of the array, print “Invalid index”

        //•	max even/odd– returns the INDEX of the max even/odd element -> [1, 4, 8, 2, 3] -> max odd -> print 4
        //•	min even/odd – returns the INDEX of the min even/odd element -> [1, 4, 8, 2, 3] -> min even > print 3
        //o If there are two or more equal min/max elements, return the index of the rightmost one
        //o If a min/max even/odd element cannot be found, print “No matches”

        //•	first {count} even/odd– returns the first {count} elements -> [1, 8, 2, 3] -> first 2 even -> print[8, 2]
        //•	last {count} even/odd – returns the last {count} elements -> [1, 8, 2, 3] -> last 2 odd -> print[1, 3]
        //o If the count is greater than the array length, print “Invalid count”
        //o If there are not enough elements to satisfy the count, print as many as you can.If there are zero even/odd elements, print an empty array “[]”

        //•	end – stop taking input and print the final state of the array
        #endregion

        //ToDo FirstMethod

        var array = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        string commandLine = Console.ReadLine().ToLower();
        while (commandLine != "end")
        {
            var commandTokens = commandLine.Split(' ').ToList();

            string command = commandTokens[0];
            switch (command)
            {
                case "exchange":
                array = ExchangeMethod(array, commandTokens);
                        break;

                case "max":
                    FindMax(array, commandTokens);
                    break;

                case "min":
                    FindMin(array, commandTokens);
                    break;

                case "first":
                    FindFirst(array, commandTokens);
                    break;

                case "last":
                    FindLast(array, commandTokens);
                    break;
            }

            commandLine = Console.ReadLine().ToLower();
        }

        string outPut = string.Join(" ", array);
        Console.WriteLine(outPut);
    }

    public static void FindLast(List<int> array, List<string> commandTokens)
    {
        int count = int.Parse(commandTokens[1]);
        string symmetry = commandTokens[2];

        if (symmetry == "even")
        {
            var evenList = array.Where(x => x % 2 == 0).ToList();

            FindLastEvenOrOdd(array, evenList, count);
        }
        else // odd
        {
            var oddList = array.Where(x => x % 2 != 0).ToList();

            FindLastEvenOrOdd(array, oddList, count);
        }
    }

    public static void FindLastEvenOrOdd(List<int> array, List<int> currentList, int count)
    {
        bool aboveIndex = array.Count() < count; //If the count is greater than the array length, print “Invalid count”
        if (aboveIndex)
        {
            Console.WriteLine("Invalid count");
            return;
        }

        bool zero = currentList.Count() == 0;
        if (zero)
        {
            Console.WriteLine("[]");
            return;
        }

        bool notEnough = currentList.Count() < count; //If there are not enough elements to satisfy the count, print as many as you can.
        if (notEnough)
        {
            string wholeList = string.Join(" ", currentList);
            Console.WriteLine(wholeList);
            return;
        }

        int remaining = currentList.Count() - count;
        var last = currentList.Skip(remaining).Take(count).ToList();
        var output = string.Join(" ", last);
        Console.WriteLine(output);
    }

    public static void FindFirst(List<int> array, List<string> commandTokens)
    {
        int count = int.Parse(commandTokens[1]);
        string symmetry = commandTokens[2];

        if (symmetry == "even")
        {
            var evenList = array.Where(x => x % 2 == 0).ToList();

            FindFirstEvenOrOdd(array, evenList, count);
        }
        else // odd
        {
            var oddList = array.Where(x => x % 2 != 0).ToList();

            FindFirstEvenOrOdd(array, oddList, count);
        }
    }

    public static void FindFirstEvenOrOdd(List<int> array, List<int> currentList, int count)
    {
        bool aboveIndex = array.Count() < count; //If the count is greater than the array length, print “Invalid count”
        if (aboveIndex)
        {
            Console.WriteLine("Invalid count");
            return;
        }

        bool zero = currentList.Count() == 0;
        if (zero)
        {
            Console.WriteLine("[]");
            return;
        }

        bool notEnough = currentList.Count() < count; //If there are not enough elements to satisfy the count, print as many as you can.
        if (notEnough)
        {
            string wholeList = string.Join(" ", currentList);
            Console.WriteLine(wholeList);
            return;
        }

        var first = currentList.Take(count).ToList();
        var output = string.Join(" ", first);
        Console.WriteLine(output);
    }

    public static void FindMin(List<int> array, List<string> commandTokens)
    {
        string symmetry = commandTokens[1];

        if (symmetry == "even")
        {
            var evenList = array.Where(x => x % 2 == 0).ToList();

            MinEvenOddMethod(evenList, array);
        }
        else //odd
        {
            var oddList = array.Where(x => x % 2 != 0).ToList();

            MinEvenOddMethod(oddList, array);
        }

    }

    public static void MinEvenOddMethod(List<int> currentList, List<int> array)
    {
        bool emptyList = currentList.Count() == 0;
        if (emptyList)
        {
            Console.WriteLine("No matches");
            return;
        }

        var min = currentList.Min();

        var indexOfMin = array.IndexOf(min);
        Console.WriteLine(indexOfMin);
    }

    public static void FindMax(List<int> array, List<string> commandTokens)
    {
        string symmetry = commandTokens[1];
        if (symmetry == "even")
        {
            var evenList = array.Where(x => x % 2 == 0).ToList();

            MaxEvenOddMethod(evenList, array);
        }
        else //odd
        {
            var oddList = array.Where(x => x % 2 != 0).ToList();

            MaxEvenOddMethod(oddList, array);
        }
    }

    public static void MaxEvenOddMethod(List<int> currentList, List<int> array)
    {
        bool emptyList = currentList.Count() == 0;
        if (emptyList)
        {
            Console.WriteLine("No matches");
            return;
        }

        var max = currentList.Max();

        var indexOfMax = array.IndexOf(max);
        Console.WriteLine(indexOfMax);
    }

    public static List<int> ExchangeMethod(List<int> array, List<string> commandTokens)
    {
        int index = int.Parse(commandTokens[1]);

        bool inside = index >= 0 && index < array.Count();
        if (!inside)
        {
            Console.WriteLine("Invalid index");
            return array;
        }

        var newEnd = array.GetRange(0, index);
        array.RemoveRange(0, index);
        array = array.Concat(newEnd).ToList();

        return array;
    }
}