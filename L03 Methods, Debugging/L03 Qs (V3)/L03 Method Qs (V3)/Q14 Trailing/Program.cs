using System;
using System.Numerics;
using System.Linq;

public class Program
{
    public static void Main()
    {
        #region
        // Instructions: Create a program that counts the trailing zeroes of the factorial of a given number.

        // Example: 
        // Input    Output                                                                                              Comment
        //  100       24     100! = 93326215443944152681699238856266700490715968264381621468592963895217599993229915608941463976156518286253697920827223758251185210916864000000000000000000000000-> 24 trailing zeroes
        #endregion

        // Copying code from Q13 Factorial
        
        // Reading input:
        int input = int.Parse(Console.ReadLine());

        // Cycle to input and factorial multiplication method:
        var sum = new BigInteger(1); // Using BigInt as the numbers can quickly exceed long

        for (BigInteger i = 2; i <= input; i++)
        {
            sum = Factorial(sum, i);
        }

        // Finding zeroes:
        int zeroes = FindTrailingZeroes(sum);

        // Printing output:
        Console.WriteLine(zeroes);
    }
    public static BigInteger Factorial(BigInteger sum, BigInteger i)
    {
        sum = BigInteger.Multiply(sum, i); // Can't just use basic (*) multiplication
        return sum;
    }
    public static int FindTrailingZeroes(BigInteger sum)
    {
        // Format it to a reversed list<char>
        string stringFormat = sum.ToString();
        var charArray = stringFormat.ToCharArray().ToList();
        charArray.Reverse();
        
        // cycle through as many zeroes as there are while the incrament is the amount of zeores
        int trailingZeroes = 0; 
        while (charArray[trailingZeroes] == '0' )
        {
            trailingZeroes++;
        }

        return trailingZeroes;
    }
}