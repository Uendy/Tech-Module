using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        // Instructions: Write a program that reads sequence of numbers and special bomb number with a certain power. Your task is to detonate every occurrence of the special bomb number and according to its power his neighbors from left and right. Detonations are performed from left to right and all detonated numbers disappear. Finally print the sum of the remaining elements in the sequence.
        // Example:
        //     Input             Output                                                             Comment
        // 1 2 2 4 2 2 2 9         12                   Special number is 4 with power 2. After detontaion we left with the sequence [1, 2, 9] with sum 12.
        //     4 2
        #endregion

        // Reading and extracting input
        var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        
        var specialNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        int bomb = specialNumbers[0];
        int power = specialNumbers[1];

        // bomb each occuarnace
        int indexOfBomb = list.IndexOf(bomb);
        while (indexOfBomb != -1)
        {
            var sequence = 0;

            // before
            var before = indexOfBomb - power;
            if (before < 0)
            {
                before = 0;
            }

            // after
            var after = indexOfBomb + power;
            if (after >= list.Count())
            {
                after = list.Count() - 1;
            }

            // combine after, bomb and before into seq
            sequence = (after - before) + 1;
            list.RemoveRange(before, sequence);

            indexOfBomb = list.IndexOf(bomb);
        }

        // Sum remainder and print
        var sum = list.Sum();
        Console.WriteLine(sum);
    }
}