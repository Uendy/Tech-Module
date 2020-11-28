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


        // Or what if I order them and then check which order is closest to list?
        var ordered = list.OrderBy(x => x).ToList();

        // See which the longest seq of ordered fits actual sequence
        
        for (int index = 0; index < list.Count(); index++)
        {
            var currentSeq = new List<int>();
            int num = list[index];

            currentSeq = FindSequence(list, ordered, num); // find currentSeq
            longestSeq = CompareSeq(currentSeq, longestSeq); // CompareSequences and return longer
        }
        

        Console.WriteLine(string.Join(" ", longestSeq));
    }
    //// Find longest matching sequence
    public static List<int> FindSequence(List<int> list, List<int> ordered, int num)
    {
        int listIndex = list.IndexOf(num);
        int orderedIndex = ordered.IndexOf(num);

        // find bigger that match in both lists


        // find smaller that match in both lists

        var currentList = new List<int>();
        return currentList;
    }
    public static List<int> CompareSeq(List<int> currentSeq, List<int> longestSeq)
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