﻿using System;
using System.Collections.Generic;
using System.Linq;
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
            

            bool isDivisibleBySeven = CheckDivisibility(i); // Its sum of digits is divisible by 7, e.g. 77, 313, 464, 5225, 37173.
            if (isDivisibleBySeven == false)
            {
                continue;
            }

            bool hasEvenDigit = CheckForEvenDigit(i); // Holds at least one even digit, e.g. 232, 707, 6886, 87578.
            if (hasEvenDigit == false)
            {
                continue;
            }

            bool isSymmetric = CheckSymmetry(i); // Is symmetric(palindrome), e.g. 5, 77, 282, 14341, 9553559.

            bool isMasterNum = isSymmetric && isDivisibleBySeven && hasEvenDigit; // If it passes all checks add it to list of master nums
            if (isMasterNum)
            {
                masterNums.Add(i);
            }
        }
        // Printing output:
        foreach (var item in masterNums)
        {
            Console.WriteLine(item);
        }
    }

    public static bool CheckSymmetry(int num)
    {
        var numAsArray = num.ToString().ToCharArray().ToList();
        for (int startIndex = 0; startIndex < numAsArray.Count() - 1; startIndex++)
        {
            int endIndex = numAsArray.Count() - (1 + startIndex); // cycles from back to front
            bool endCycle = startIndex > endIndex; // if the front index has passed the back we have gone too far, it hasnt returned false until now => is Symmetric
            if (endCycle)
            {
                return true;
            }

            if (numAsArray[startIndex] != numAsArray[endIndex]) // has found a place where it is not symmetric => not Symmetric
            {
                return false;
            }
        }

        return true;
    }

    // Check if sum divisible by seven
    public static bool CheckDivisibility(int i)
    {
        int sum = 0;

        while (i != 0) // add every last digit, then divids i to remove it and move to next last digit
        {
            sum += i % 10;
            i = i / 10;
        }

        if (sum % 7 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool CheckForEvenDigit(int i) // check all digits in i for an even digit
    {
        while (i != 0)
        {
            int lastDigit = i % 10;
            if (lastDigit % 2 == 0)
            {
                return true;
            }

            i = i / 10;
        }

        return false;
    }
}