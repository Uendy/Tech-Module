using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        // Instructions: Read an array of 4*k integers, fold it like shown below, and print the sum of the upper and lower two rows (each holding 2 * k integers):
        // Example: 
        //   Input	        Output	            Comments
        //  5 2 3 6          7 9                 5  6 +
        //                                       2  3 =
        //                                       7  9
        #endregion

        // Reading input:
        var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        // Getting needed variables
        int length = array.Count();
        int halfLength = length / 2; // to split the array into equal subarrays
        int startPoint = length / 4; // to then work inside -> out 

        // first half of array, fold and sum
        var firstHalf = array.Take(halfLength).ToArray();
        var firstSumFold = FoldHalf(firstHalf, startPoint);

        // second half of array, fold and sum
        var secondHalf = array.Skip(halfLength).Take(halfLength).ToArray();
        var secondSumFold = FoldHalf(secondHalf, startPoint);

        // Concat both sum array and Printing string 
        Console.WriteLine(string.Join(" ", firstSumFold.Concat(secondSumFold)));
    }

    // Folds and sums the half (inside -> outside)
    public static int[] FoldHalf(int[] half, int startPoint)
    {
        var sum = new int[startPoint];   
        for (int i = 0; i < startPoint; i++)
        {
            sum[i] += half[startPoint - 1 - i];
            sum[i] += half[startPoint + i];
        }

        return sum;
    }
}