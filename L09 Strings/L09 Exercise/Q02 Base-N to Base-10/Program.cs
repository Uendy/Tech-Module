using System;
using System.Linq;
using System.Numerics;

public class Program
{
    public static void Main()
    {
        // helped tremendously : https://mathbits.com/MathBits/CompSci/Introduction/tobase10.htm

        var inputAsArray = Console.ReadLine().Split(' ').ToArray();

        int baseCount = int.Parse(inputAsArray[0]);
        var baseNumber = BigInteger.Parse(inputAsArray[1]);
        var baseNumberDigitLength = baseNumber.ToString().Count();

        BigInteger decimalNumber = 0;

        var DigitAsReversedCharArray = baseNumber.ToString().ToCharArray().Reverse();
        var DigitAsRealCharArray = string.Concat(DigitAsReversedCharArray).ToCharArray();

        for (long i = 0; i < baseNumberDigitLength; i++)
        {
            var currentDigitAsChar = DigitAsRealCharArray[i];
            var currentDigit = currentDigitAsChar - '0';
            var baseRaised = (BigInteger)Math.Pow(baseCount, i);
            var currentDigitTimesBase = currentDigit * baseRaised;

            decimalNumber += currentDigitTimesBase; 
        }

        Console.WriteLine(decimalNumber);
    }
}
