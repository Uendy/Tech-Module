using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        #region
        // Instructions: Write a program that finds the longest increasing subsequence in an array of integers. The longest increasing subsequence is a portion of the array (subsequence) that is strongly increasing and has the longest possible length. If several such subsequences exist, find the left most of them.
        // Example:
        //    Input          Output
        // 3 2 3 4 2 2 4    2 3 4
        // 4 5 1 2 3 4 5    1 2 3 4 5
        // 3 4 5 6          3 4 5 6
        // 0 1 1 2 2 3 3    0 1
        #endregion

        // Reading input:
        var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        // Setting up needed lists:
        var outputList = new List<int>();
        var currentList = new List<int>();

        // Cycling and checking:
        for (int index = 0; index < input.Length-1; index++)
        {
            int currentNum = input[index];
            int nextNum = input[index + 1];

            bool isBigger = nextNum > currentNum;
            if (isBigger)
            {
                currentList.Add(currentNum);
            }
            else
            {
                outputList = CompareList(currentList, outputList);
                currentList.Clear();
            }
        }

        outputList = CompareList(currentList, outputList); // final check with last values

        // Format output and print:
        Console.WriteLine(string.Join(" ", outputList));
    }
    public static List<int> CompareList(List<int> currentList, List<int> outputList)
    {
        if (currentList.Count() > outputList.Count()) // check if new highscore and reset
        {
            outputList.Clear();
            outputList = currentList;
        }

        return outputList;
    }
}