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

        // Preparing output Array
        var sumArr = new int[array.Count() / 2];

        // first half of array
        int middle = length / 4;
        for (int i = 0; i < middle; i++)
        {
            sumArr[i] += array[middle - 1 - i];
            sumArr[i] += array[middle + i];
        }

        // Printing string 
        Console.WriteLine(string.Join(" ", sumArr));

    }
}