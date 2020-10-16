using System;
public class Program
{
    public static void Main()
    {
        // Instructions: You are given a program that checks if numbers in a given range [2...N] are prime. For each number is printed "{number} is prime -> {True or False}". The code however, is not very well written. Your job is to modify it in a way that is easy to read and understand.

        // Example: Input:     Output:
        //            5	       2 -> True
        //                     3->True
        //                     4->False
        //                     5->True

        // Reading input:
        int input = int.Parse(Console.ReadLine());

        // Cycling:
        for (int i = 2; i <= input; i++)
        {
            bool isPrime = true;
            for (int a = 2; a <= Math.Sqrt(i); a++)
            {
                if (i % a == 0)
                {
                    isPrime = false;
                    break;
                }

            }

            if (isPrime)
            {
                Console.WriteLine($"{i} -> True");
            }
            else
            {
                Console.WriteLine($"{i} -> False");
            }
        }
    }
}