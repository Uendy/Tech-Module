using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

public class Program
{
    public static void Main(string[] args)
    {
        var arrayOfNumbers = Console.ReadLine().Split(' ').ToArray();

        var baseNumber = int.Parse(arrayOfNumbers[0]);
        var decimalNumber = BigInteger.Parse(arrayOfNumbers[1]);

        var outputNumber = string.Empty;

        var stackOfRemainders = new Stack<string>();

        while (decimalNumber > 0)
        {
            var remainder = decimalNumber % baseNumber;

            stackOfRemainders.Push(remainder.ToString());

           // outputNumber += decimalNumber / baseNumber;

            decimalNumber /= baseNumber;

        }

        while (stackOfRemainders.Count > 0)
        {
            outputNumber += stackOfRemainders.Pop();
        }

        Console.WriteLine(outputNumber);
    }
}
