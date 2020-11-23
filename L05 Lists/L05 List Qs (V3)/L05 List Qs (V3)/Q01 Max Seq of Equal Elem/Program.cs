using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        // Instructions: Read a list of integers and find the longest sequence of equal elements. If several exist, print the leftmost.
        // Example: 
        //    Input            Output
        //7 7 4 4 5 5 3 3    	7 7
        #endregion

        // Reading input:
        var input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        // Initialize output list:
        var maxSeq = new List<int>();

        // Cycle and check:
        for (int index = 0; index < input.Count(); index++)
        {
            var currentSeq = new List<int>();

            int currentNum = input[index];

            // Cycle and add all continuous same numbers:
            for (int j = index+1; j < input.Count(); j++)
            {
                int nextNum = input[j];

                currentSeq.Add(currentNum);

                if (currentNum != nextNum) // break this cycle
                {
                    break;
                }
            }

            // Check if the seq is greater than the current maxSeq
            bool newHighScore = currentSeq.Count() > maxSeq.Count();
            if (newHighScore)
            {
                maxSeq = new List<int>(currentSeq.ToList());
                currentSeq.Clear();
            }
        }

        // Printing output:
        Console.WriteLine(string.Join(" ", maxSeq));
    }
}