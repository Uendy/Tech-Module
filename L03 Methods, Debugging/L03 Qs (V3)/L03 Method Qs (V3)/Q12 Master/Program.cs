using System;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        // Instructions:
        // A master number is an integer that holds the following properties:
        // •	Is symmetric(palindrome), e.g. 5, 77, 282, 14341, 9553559.
        // •	Its sum of digits is divisible by 7, e.g. 77, 313, 464, 5225, 37173.
        // •	Holds at least one even digit, e.g. 232, 707, 6886, 87578.
        // Write a program to print all master numbers in the range[1…n].

        // Example:
        // Input	Output
        //  600      232
        //           383
        //           464
        //           545

        // Reading input:
        int finalNum = int.Parse(Console.ReadLine());

        // List of master numbers:
        var masterNums = new List<int>();

        // Cycle through 1...finalNum and check if its master num
        for (int i = 1; i <= finalNum; i++)
        {
            bool isSymmetric = CheckSymmetry(i); // Is symmetric(palindrome), e.g. 5, 77, 282, 14341, 9553559.
            if (isSymmetric == false)
            {
                continue;
            }

            bool isDivisibleBySeven = CheckDivisibility(i); // Its sum of digits is divisible by 7, e.g. 77, 313, 464, 5225, 37173.
            if (isDivisible == false)
            {
                continue;
            }

            bool hasEvenDigit = CheckForEvenDigit(i); // Holds at least one even digit, e.g. 232, 707, 6886, 87578.

            bool isMasterNum = isSymmetric && isDivisibleBySeven && hasEvenDigit; // If it passes all checks add it to list of master nums
            if (isMasterNum)
            {
                masterNums.Add(i);
            }

            // Printing output:
            foreach (var item in masterNums)
            {
                Console.WriteLine(item);
            }
        }
    }
}