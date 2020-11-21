using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        #region
        // Instructions: Write a program that count the number of pairs in given array which difference is equal to given number.
        //          •	The first line holds the sequence of numbers.
        //          •	The second line holds the difference.

        // Example:
        //  Input        Output                                    Explanation
        // 1 5 3 4 2      3               Pairs of elements with difference 2-> { 1, 3}, { 5, 3}, { 4, 2}
        //    2   
        // Example 2:
        //   Input            Output                                Explanation
        // 5 3 8 10 12 1        0                           No pairs with difference 1
        //      1    
        #endregion

        // Reading input:
        var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int difference = int.Parse(Console.ReadLine());

        // Counting pairs
        int pairs = 0;

        // Cycle the first num
        for (int initialIndex = 0; initialIndex < array.Length; initialIndex++)
        {
            int initialNum = array[initialIndex];
            // Second cylce: check with all nums 
            for (int secondaryIndex = initialIndex + 1; secondaryIndex < array.Length; secondaryIndex++)
            {
                int secondNum = array[secondaryIndex];
                if (Math.Abs(initialNum - secondNum) == difference)
                {
                    pairs++;
                }
            }
        }

        // Printing output:
        Console.WriteLine(pairs);
    }
}