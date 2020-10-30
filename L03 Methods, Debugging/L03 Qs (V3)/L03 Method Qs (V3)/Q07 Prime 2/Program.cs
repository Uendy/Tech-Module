using System;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        // Instructions: Write a method that calculates all prime numbers in given range and returns them as list of integers:
        // Template: static List<int> FindPrimesInRange(startNum, endNum)
        // Write a method to print a list of integers.Write a program that enters two integer numbers(each at a separate line) and prints all primes in their range, separated by a comma.

        // Example:
        // Input: (Start and End Number)              Output
        //  0 10                                    2, 3, 5, 7
        //  5 11                                     5, 7, 11

        // Reading input:
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());

        // List of output:
        var primes = new List<int>();
        if (start < 2) // checking 0 and 1 is pointless
        {
            start = 2;
        }

        // Cycle through range:
        for (int i = start; i <= end; i++)
        {
            bool isPrime = PrimeChecker(i);
            if (isPrime)
            {
                primes.Add(i);
            }
        }

        // Printing output:
        Console.WriteLine(string.Join(", ", primes));
    }

    /// Checks if the number is prime and returns a bool
    private static bool PrimeChecker(int num)
    {
        bool isPrime = true;
        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0)
            {
                return false;
            }
        }

        return isPrime;
    }
}