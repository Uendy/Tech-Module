using System;
using System.Numerics;
public class Program
{
    public static void Main()
    {
        // Instructions: Write a program that calculates and prints the n! for any n in the range [1…1000].

        // Example:
        // Input	                                                                            Output
        // 100   93326215443944152681699238856266700490715968264381621468592963895217599993229915608941463976156518286253697920827223758251185210916864000000000000000000000000

        // Reading input:
        int input = int.Parse(Console.ReadLine());

        // Cycle to input and factorial multiplication method:
        var sum = new BigInteger(1); // Using BigInt as the numbers can quickly exceed long

        for (BigInteger i = 2; i <= input; i++)
        {
            sum = Factorial(sum, i);
        }

        // Printing output:
        Console.WriteLine(sum);
    }

    public static BigInteger Factorial(BigInteger sum, BigInteger i) 
    {
        sum = BigInteger.Multiply(sum, i); // Can't just use basic (*) multiplication
        return sum;
    }
}