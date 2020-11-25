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

        // Cycle and check each incrament with another cycle.
        for (int index = 0; index < list.Count(); index++)
        {
            int currentNum = list[index];
            var currentSeq = new List<int> { currentNum };
            for (int j = index + 1; j < list.Count()-1; j++)
            {
                int nextNum = list[j];

                bool bigger = nextNum > currentSeq.Last();
                if (bigger)
                {
                    currentSeq.Add(nextNum);
                }
            }

            // adding last num
            if (index == list.Count() - 1 && list[index] > currentSeq.Last())
            {
                currentSeq.Add(currentNum);
            }

            // Check if current seq is longer
            bool newHighSeq = currentSeq.Count() > longestSeq.Count(); // see if I am adding list[list.Count - 1]
            if (newHighSeq)
            {
                // check if due to ref type of list they are both cleared
                longestSeq = currentSeq.ToList();
                currentSeq.Clear(); 
            }
        }

        // Printing output
        Console.WriteLine(string.Join(" ", longestSeq));
    }
}