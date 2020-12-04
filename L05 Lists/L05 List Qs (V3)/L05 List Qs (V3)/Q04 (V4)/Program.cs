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

        // Going to try to use the method given in the exercises, but will do it my way using a dictionary <int index, list<int>sequence> to keep the sequences

        // Reading input and initializing dictionary
        var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        var dict = new Dictionary<int, List<int>>(); // key = <int> index, value = <List<int>> sequence

        // Add the first item, in case only one and so you can skip it in the cycling
        dict[0] = new List<int> { list[0] };

        for (int index = 1; index < list.Count(); index++)
        {
            int current = list[index];

            // Tried to unsuccesfuly sort it with LINQ, so I will do this
            //var sorted = dict.Where(x => x.Key < index).OrderByDescending(x => x.Value.Count).First().ToList();

            // Get the longest sequence that has a smaller index than index (key) and the longest list (value) 
            var sequence = FindLongestSeq(dict, index, current);

            // Update dictionary
            dict[index] = new List<int>(sequence);
            dict[index].Add(current);
        }

        // find and print longest value
        var output = dict.OrderByDescending(x => x.Value.Count()).First().Value;
        Console.WriteLine(string.Join(" ", output));
    }
    public static List<int> FindLongestSeq(Dictionary<int, List<int>> dict, int index, int current)
    {
        var sequence = new List<int>();
        foreach (var kvp in dict)
        {
            bool smallerThanIndex = kvp.Key < index; // check numbers before itself in list
            if (smallerThanIndex)
            {
                bool incramenting = current > kvp.Value.Last(); // check to see if current is bigger than the biggest value in kvp
                if (incramenting)
                {
                    bool longerSeq = kvp.Value.Count() > sequence.Count(); // compares Seq to see if it is longer
                    if (longerSeq)
                    {
                        sequence = kvp.Value.ToList();
                    }
                }
            }
        }

        return sequence;
    }
}