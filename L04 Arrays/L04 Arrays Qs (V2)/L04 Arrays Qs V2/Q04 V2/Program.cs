using System;
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
        var initialPrimes = new int[] { 2, 3, 5, 7 };

        var array = new bool[maxNum + 1]; // all are false
        array[0] = true;
        array[1] = true;

        foreach (var prime in initialPrimes)
        {
            var currentPrime = prime;
            while (currentPrime <= maxNum)
            {
                bool initialPrime = currentPrime == prime;
                bool alreadyNotPrime = array[currentPrime] == true;
                if (!initialPrime && !alreadyNotPrime)
                {
                    array[currentPrime] = true;
                }

                currentPrime += prime;
            }
        }

        string outPut = string.Empty;
        for (int index = 0; index <= maxNum; index++)
        {
            if (array[index] == false)
            {
                outPut += index + " ";
            }
        }
        Console.WriteLine(outPut.TrimEnd());
    }
}