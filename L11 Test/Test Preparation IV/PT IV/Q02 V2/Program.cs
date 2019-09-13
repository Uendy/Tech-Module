using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var array = Console.ReadLine().Trim().Split(new[] { ' ' }).Select(int.Parse).ToList();

        string commandInput = Console.ReadLine();
        while (commandInput != "end")
        {
            var commandTokens = commandInput.Split(' ').ToList();

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
                default:
                    break;
            }

            commandInput = Console.ReadLine();
        }

        string outPut = string.Join(", ", array);
        Console.WriteLine($"[{outPut}]");
    }

    public static void FindLast(List<int> array, List<string> commandTokens)
    {
        int count = int.Parse(commandTokens[1]);
        string parity = commandTokens[2];

        bool greaterThanArray = count > array.Count();
        if (greaterThanArray) //If the count is greater than the array length, print “Invalid count”
        {
            Console.WriteLine("Invalid count");
            return;
        }

        var currentList = new List<int>();

        if (parity == "even")
        {
            currentList = array.Where(x => x % 2 == 0).ToList();
        }
        else //odd
        {
            currentList = array.Where(x => x % 2 != 0).ToList();
        }

        string outPut = string.Empty; //If there are zero even/odd elements, print an empty array “[]”

        bool notEnough = count > currentList.Count();
        if (notEnough) //If there are not enough elements to satisfy the count, print as many as you can.
        {
            outPut = string.Join(", ", currentList);
        }
        else // take as many as you can
        {
            int remaining = currentList.Count() - count;
            var last = currentList.Skip(remaining).Take(count).ToList();
            outPut = string.Join(", ", last);
        }

        Console.WriteLine($"[{outPut}]");
    }

    public static void FindFirst(List<int> array, List<string> commandTokens)
    {
        int count = int.Parse(commandTokens[1]);
        string parity = commandTokens[2];

        bool greaterThanArray = count > array.Count();
        if (greaterThanArray) //If the count is greater than the array length, print “Invalid count”
        {
            Console.WriteLine("Invalid count");
            return;
        }

        var currentList = new List<int>();

        if (parity == "even")
        {
            currentList = array.Where(x => x % 2 == 0).ToList();
        }
        else //odd
        {
            currentList = array.Where(x => x % 2 != 0).ToList();
        }

        string outPut = string.Empty; //If there are zero even/odd elements, print an empty array “[]”

        bool notEnough = count > currentList.Count();
        if (notEnough) //If there are not enough elements to satisfy the count, print as many as you can.
        {
            outPut = string.Join(", ", currentList);
        }
        else // take as many as you need
        {
            var printList = currentList.Take(count);
            outPut = string.Join(", ", printList);
        }

        Console.WriteLine($"[{outPut}]");
    }

    public static void FindMin(List<int> array, List<string> commandTokens)
    {
        string parety = commandTokens[1];

        var currentList = new List<int>();

        if (parety == "even")
        {
            currentList = array.Where(x => x % 2 == 0).ToList();
        }
        else // odd
        {
            currentList = array.Where(x => x % 2 != 0).ToList();
        }

        bool emptyList = currentList.Count() == 0;
        if (emptyList)
        {
            Console.WriteLine("No matches");
            return;
        }

        int min = currentList.Min();

        int lastIndexOfMin = 0;
        int indexOfMin = array.IndexOf(min); //If there are two or more equal min/max elements, return the index of the rightmost one
        while (indexOfMin != -1)
        {
            lastIndexOfMin = indexOfMin;
            indexOfMin = array.IndexOf(min, lastIndexOfMin + 1);
        }

        Console.WriteLine(lastIndexOfMin);
    }

    public static void FindMax(List<int> array, List<string> commandTokens)
    {
        string parety = commandTokens[1];

        var currentList = new List<int>();

        if (parety == "even")
        {
            currentList = array.Where(x => x % 2 == 0).ToList();
        }
        else // odd
        {
            currentList = array.Where(x => x % 2 != 0).ToList();
        }

        bool emptyList = currentList.Count() == 0;
        if (emptyList)
        {
            Console.WriteLine("No matches");
            return;
        }

        int max = currentList.Max();

        int lastIndexOfMax = 0;
        int indexOfMax = array.IndexOf(max); //If there are two or more equal min/max elements, return the index of the rightmost one
        while (indexOfMax != -1)
        {
            lastIndexOfMax = indexOfMax;
            indexOfMax = array.IndexOf(max, lastIndexOfMax + 1);
        }

        Console.WriteLine(lastIndexOfMax);
    }

    public static List<int> ExchangeMethod(List<int> array, List<string> commandTokens)
    {
        int index = int.Parse(commandTokens[1]);

        bool isInside = index >= 0 && index < array.Count();
        if (!isInside)
        {
            Console.WriteLine("Invalid index");
            return array;
        }

        var newEnd = array.Take(index + 1);
        var newStart = array.Skip(index + 1);

        var exchanged = newStart.Concat(newEnd).ToList();
        return exchanged;
    }
}