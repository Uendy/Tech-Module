using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        // Instructions: Write a program that determines if there exists an element in the array such that the sum of the elements on its left is equal to the sum of the elements on its right. If there are no elements to the left / right, their sum is considered to be 0. Print the index that satisfies the required condition or “no” if there is no such index.

        // Example:
        //  Input        Output                Explanation
        // 1 2 3 3	        2	    At a[2] -> left sum = 3, right sum = 3
        //                                a[0] + a[1] = a[3]
        #endregion

        // Reading input:
        var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        // Cycle through and check left and right sum
        for (int index = 0; index < input.Length; index++)
        {
            int currentNum = input[index];

            int leftSum = CalcLeftSide(input, index);
            int rightSum = CalcRightSide(input, index);

            bool areEqual = leftSum == rightSum; // heck if sides match and print
            if (areEqual)
            {
                Console.WriteLine(index);
                Environment.Exit(0);
            }
        }

        // If none are equal print output "no"
        Console.WriteLine("no");
    }
    public static int CalcLeftSide(int[] input, int index)
    {
        int sum = 0;

        for (int i = 0; i < index; i++)
        {
            sum += input[i];
        }

        return sum;
    }
    public static int CalcRightSide(int[] input, int index)
    {
        int sum = 0;

        for (int i = index + 1; i < input.Length; i++)
        {
            sum += input[i];
        }

        return sum;
    }
}