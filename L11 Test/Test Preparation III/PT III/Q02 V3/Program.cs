﻿using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    { 
        var array = Console.ReadLine().Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        string input = Console.ReadLine();
        while (input != "end")
        {
            var inputTokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = inputTokens[0];

            switch (command)
            {
                case "reverse":
                    ReverseSubArray(array, inputTokens);
                    break;

                case "sort":
                    SortSubArray(array, inputTokens);
                    break;

                case "rollLeft":
                    CommandRollLeft(array, inputTokens);
                    break;

                case "rollRight":
                    CommandRollRight(array, inputTokens);
                    break;
            }

            input = Console.ReadLine();
        }

        string outPut = string.Join(", ", array);
        Console.WriteLine($"[{outPut}]");
    }

    public static void CommandRollRight(List<string> array, List<string> inputTokens)
    {
        int shiftBy = int.Parse(inputTokens[1]);

        shiftBy %= array.Count();

        if (shiftBy < 0)
        {
            Console.WriteLine("Invalid input parameters.");
            return;
        }

        for (int i = 0; i < shiftBy; i++)
        {
            string element = array[array.Count - 1];
            array.RemoveAt(array.Count - 1);
            array.Insert(0, element);
        }
    }

    public static void CommandRollLeft(List<string> array, List<string> inputTokens)
    {
        int shiftBy = int.Parse(inputTokens[1]);

        shiftBy %= array.Count();

        if (shiftBy < 0)
        {
            Console.WriteLine("Invalid input parameters.");
            return;
        }

        for (int i = 0; i < shiftBy; i++)
        {
            string element = array[0];
            array.RemoveAt(0);
            array.Add(element);
        }
    }

    public static void SortSubArray(List<string> array, List<string> inputTokens)
    {
        int startIndex = int.Parse(inputTokens[2]);
        int count = int.Parse(inputTokens[4]);

        if (IsValid(array, startIndex, count)) // I had it as count - 1 and it was failing tests and I didnt do start + count <= array.Count();
        {
            var newSubArray = array.Skip(startIndex).Take(count).OrderBy(x => x).ToList();

            array.RemoveRange(startIndex, count);
            array.InsertRange(startIndex, newSubArray);
        }
    }

    public static void ReverseSubArray(List<string> array, List<string> inputTokens)
    {
        int startIndex = int.Parse(inputTokens[2]);
        int count = int.Parse(inputTokens[4]);

        if (IsValid(array, startIndex, count)) 
        {
            var newSubArray = array.Skip(startIndex).Take(count).Reverse().ToList();

            array.RemoveRange(startIndex, count);
            array.InsertRange(startIndex, newSubArray);
        }
    }

    public static bool IsValid(List<string> array, int startIndex, int count)
    {
        if (startIndex >= 0 && startIndex < array.Count() && count >= 0 && (startIndex + count) <= array.Count())
        {
            return true;
        }
        Console.WriteLine("Invalid input parameters.");
        return false;
    }
}
