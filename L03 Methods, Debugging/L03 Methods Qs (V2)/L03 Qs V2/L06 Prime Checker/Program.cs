using System;

public class Program
{
    public static void Main()
    {
        //Write a Boolean method IsPrime(n) that check whether a given integer number n is prime.

        long input = long.Parse(Console.ReadLine());

        if (input <= 1)
        {
            Console.WriteLine("False");
        }
        else
        {
            Console.WriteLine(CheckIfPrime(input));
        }
    }

    public static bool CheckIfPrime(long input)
    {
        bool isPrime = true;

        for (int primeCheckNum = 2; primeCheckNum <= Math.Sqrt(input); primeCheckNum++)
        {
            if (input % primeCheckNum == 0)
            {
                return isPrime = false;
            }
        }

        return isPrime;
    }
}
