using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        //Write a method to print a list of integers.
        //Write a program that enters two integer numbers (each at a separate line) and prints all primes
        //in their range, separated by a comma.

        int startSeq = int.Parse(Console.ReadLine());
        int endSeq = int.Parse(Console.ReadLine());

        var listOfPrimes = new List<int>();

        CheckPrimesInSeq(startSeq, endSeq, listOfPrimes);

        string outPut = string.Join(", ", listOfPrimes);

        Console.WriteLine(outPut);
    }

    public static List<int> CheckPrimesInSeq(int startSeq, int endSeq, List<int> listOfPrimes)
    {
        for (int indexInSeq = startSeq; indexInSeq <= endSeq; indexInSeq++)
        {
            if (indexInSeq < 2)
            {
                continue;
            }

            bool isPrime = true;

            for (int primeCheck = 2; primeCheck <= Math.Sqrt(indexInSeq); primeCheck++)
            {
                if (indexInSeq % primeCheck == 0)
                {
                    isPrime = false;
                }
            }

            if (isPrime == true)
            {
                listOfPrimes.Add(indexInSeq);
            }
        }

        return listOfPrimes;
    }
}