using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        // Instructions: Read a list of integers and find the longest increasing subsequence (LIS). If several such exist, print the leftmost
        // Example:
        //          input                                   output:
        //            1                                        1
        //      7 3 5 8 -1 0 6 7                            3 5 6 7
        //     1 2 5 3 5 2 4 1	                            1 2 3 5
        //  0 10 20 30 30 40 1 50 2 3 4 5 6              0 1 2 3 4 5 6
        //  11 12 13 3 14 4 15 5 6 7 8 7 16 9 8          3 4 5 6 7 8 16
        //  3 14 5 12 15 7 8 9 11 10 1                   3 5 7 8 9 11
        #endregion

        // Reading input:
        var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        // Preparing output:
        var longestSeq = new List<int>();

        for (int index = 0; index < list.Count(); index++)
        {
            int currentNum = list[index];

            var currentSeq = new List<int> { currentNum };
            var before = CycleBefore(currentNum, index, list);
            var after = CycleAfter(currentNum, index, list);

            // Combining before, current and after into a single sequence
            currentSeq.InsertRange(0, before);
            currentSeq.Concat(after).ToList();

            longestSeq = compareSeq(currentSeq, longestSeq);
        }

        // Printing output
        Console.WriteLine(string.Join(" ", longestSeq));
    }
    public static List<int> CycleBefore(int currentNum, int index, List<int> list)
    {
        var output = new List<int>();
        for (int i = index - 1; i >= 0; i--)
        {
            int num = list[i];

            bool smaller = num < currentNum;
            if (smaller)
            {
                output.Add(num);
                currentNum = num;
            }
        }

        // add smallest num if its different to list[index] (= new num, that wasn't added in cycle)
        //if (currentNum != list[index])
        //{
        //    output.Add(currentNum);
        //}

        return output;
    }
    public static List<int> CycleAfter(int currentNum, int index, List<int> list)
    {
        var output = new List<int>();
        for (int j = index + 1; j < list.Count(); j++)
        {
            int num = list[j];

            bool bigger = num > currentNum;
            if (bigger)
            {
                output.Add(num);
                currentNum = num;
            }
        }

        // Add new biggest num that wasn't added to seq as it didn't pass a bigger num check
        //if (currentNum != list[index])
        //{
        //    output.Add(currentNum);
        //}

        return output;
    }
    public  static List<int> compareSeq(List<int> currentSeq, List<int>longestSeq)
    {
        if (currentSeq.Count() > longestSeq.Count())
        {
            return currentSeq;
        }
        else
        {
            return longestSeq;
        }
    }
}