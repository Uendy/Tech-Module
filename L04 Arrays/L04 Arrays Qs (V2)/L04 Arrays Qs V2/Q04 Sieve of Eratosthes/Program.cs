using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program to find all prime numbers in range [1…n]. Implement the algorithm called “Sieve of Eratosthenes”: https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes. Steps in the “Sieve of Eratosthenes” algorithm:
        // 1.Assign primes[0…n] = true
        // 2.Assign primes[0] = primes[1] = false
        // 3.Find the smallest p, which holds primes[p] = true
        // •	Print p(it is prime)
        // •	Assign primes[2 * p] = primes[3 * p] = primes[4 * p] = … = false
        // 4.Repeat for the next smallest p < n.

        int maxNum = int.Parse(Console.ReadLine());
        var initialPrimes = new List<int> { 2, 3, 5, 7 };

        if (maxNum <= 7)
        {
            foreach (var prime in initialPrimes)
            {
                if (maxNum >= prime)
                {
                    Console.Write(prime + " ");
                }
            }
            Environment.Exit(0);
        }

        var list = new List<int>();
        for (int i = 10; i <= maxNum; i++) 
        {
            list.Add(i);
        }

        foreach (var prime in initialPrimes) // the actual program to weed out any non-primes
        {
            var currentPrime = prime;
            while (currentPrime <= maxNum)
            {
                if (list.Contains(currentPrime))
                {
                    list.Remove(currentPrime);
                }
                currentPrime += prime;
            }
        }

        initialPrimes = initialPrimes.Concat(list).ToList();
        var outPut = string.Join(" ", initialPrimes);
        Console.WriteLine(outPut);
    }
}