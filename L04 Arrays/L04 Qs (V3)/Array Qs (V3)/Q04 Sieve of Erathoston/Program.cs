using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        #region
        // Instructions: 
        // Write a program to find all prime numbers in range [1…n]. Implement the algorithm called “Sieve of Eratosthenes”: https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes. Steps in the “Sieve of Eratosthenes” algorithm:
        // 1.Assign primes[0…n] = true
        // 2.Assign primes[0] = primes[1] = false
        // 3.Find the smallest p, which holds primes[p] = true
        // •	Print p(it is prime)
        // •	Assign primes[2 * p] = primes[3 * p] = primes[4 * p] = … = false
        // 4.Repeat for the next smallest p < n.

        // Examples
        // Input   Output
        //   6     2 3 5

        #endregion

        // Reading input:
        int lastNum = int.Parse(Console.ReadLine());
        var potentialPrimes = Enumerable.Range(2, lastNum - 1).ToList(); // making a list holding all numbers between 2 and N

        // Begin cycling and sieving:
        for (int i = 2; i <= lastNum || i < 7; i++)
        {
            if (i == 4 || i == 6) // no need to check them as they are multiples of 2 (and of 3 for 6)
            {
                continue;
            }

            for (int j = 2; i <= lastNum/ j; j++)
            {
                bool isContainedInList = potentialPrimes.Contains(i * j);
                if (isContainedInList)
                {
                    potentialPrimes.Remove(i * j);
                }
            }
        }

        // Printing output:
        Console.WriteLine(string.Join(" ", potentialPrimes));
    }
}