using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main()
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

        // Reading input
        var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        // Prepare outout list
        var longestSeq = new List<int>();

        for (int index = 0; index < list.Count(); index++)
        {
            int currentNum = list[index];
            var maxCurrentSeq = new List<int> { currentNum };
            var currentSeq = new List<int> { currentNum };

            for (int j = index + 1; j < list.Count(); j++)
            {
                int num = list[index];

                bool bigger = num > currentNum;
                if (bigger)
                {
                    maxCurrentSeq.Add(num);
                    currentSeq.Add(num);
                }

                // check if end and return to index of newest added in list and cycle;
                bool last = j == list.Count() - 1;
                if (last)
                {
                    int indexOfLast = list.IndexOf(maxCurrentSeq.Last());
                    currentSeq.Remove(currentSeq.Last());
                    j = indexOfLast + 1;
                }

                // find out where and when to compare currentSeq and maxCurrentSeq;
            }

            // comapre maxCurrentSeq with longestSeq
        }

        // Printing ouput:
        Console.WriteLine(string.Join(" ", longestSeq));
    }
}