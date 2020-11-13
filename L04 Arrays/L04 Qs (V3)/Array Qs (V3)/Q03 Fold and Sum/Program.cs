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
        int length = array.Count();
        int halfLength = length / 2; // to split the array into equal subarrays
        int startPoint = length / 4; // to then work inside -> out 

        // Preparing output Array
        var sumArr = new int[array.Count() / 2];

        // first half of array, fold and sum
        var firstHalf = array.Take(halfLength).ToArray();
        sumArr = FoldHalf(firstHalf, startPoint, sumArr);

        // second half of array, fold and sum
        var secondHalf = array.Skip(halfLength).Take(halfLength).ToArray();
        sumArr = FoldHalf(secondHalf, startPoint, sumArr); // need to make the sumArr[i] different from the sumArr[i] of the first half

        // Printing string 
        Console.WriteLine(string.Join(" ", sumArr));
    }

    // Folds and sums the half (inside -> outside)
    public static int[] FoldHalf(int[] half, int startPoint, int[] sumArr)
    {
        for (int i = 0; i < startPoint; i++)
        {
            sumArr[i] += half[startPoint - 1 - i];
            sumArr[i] += half[startPoint + i];
        }

        return sumArr;
    }
}