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

        // Reading input
        var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        // Prepare outout list
        var longestSeq = new List<int> { list[0] };

        for (int index = 0; index < list.Count(); index++)
        {
            int num = list[index];

            var currentSeq = new List<int> { list[num] };    // 5 10 6 10 1
            int cycles = 0;

            for (int j = index + 1; j < list.Count(); j++)
            {
                int next = list[j];

                bool bigger = next > num;
                if (bigger)
                {
                    cycles = 0;
                    currentSeq.Add(next);
                    num = next;
                }
                else
                {
                    cycles++;
                }

                bool finalIndex = j == list.Count() - 1;
                if (finalIndex)
                {
                    bool newHighSeq = currentSeq.Count() > longestSeq.Count(); // reset if new longestSeq
                    if (newHighSeq)
                    {
                        longestSeq = currentSeq.ToList();
                    }

                    // break cycle if needed
                    if (currentSeq.Last() == list.Last() || currentSeq.Count() == 0) 
                    {
                        break;
                    }

                    // Remove highest value until now
                    currentSeq.Remove(currentSeq.Last());

                    //reset j to continue from where the highest value was added
                    j -= cycles;
                    cycles = 0;
                }
            }
        }

        // Print output
        Console.WriteLine(string.Join(" ", longestSeq));
    }
}