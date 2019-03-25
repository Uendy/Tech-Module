using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program that determines if there exists an element in the array such that the sum
        //of the elements on its left is equal to the sum of the elements on its right. 
        //If there are no elements to the left / right, their sum is considered to be 0. 
        //Print the index that satisfies the required condition or “no” if there is no such index.

        var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        bool equalSums = false;
        for (int index = 0; index < array.Length; index++)
        {
            int leftSum = 0;
            int rightSum = 0;

            bool firstIndex = index == 0;
            bool lastIndex = index == array.Length - 1;
            if (!firstIndex == true)
            {
                for (int i = index - 1; i >= 0; i--) // leftIndex cycle
                {
                    leftSum += array[i];
                }
            }
            if (!lastIndex == true)
            {
                for (int j = index + 1; j < array.Length; j++) // rightIndex cycle
                {
                    rightSum += array[j];
                }
            }

            bool sums = leftSum == rightSum;
            if (sums == true)
            {
                equalSums = true;
                Console.WriteLine(index);
                Environment.Exit(0);
            }
        }

        if (equalSums == false)
        {
            Console.WriteLine("no");
        }
    }
}