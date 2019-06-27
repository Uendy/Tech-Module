using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
public class Program
{
    public static void Main()
    {
        //Write a program that takes a base-10 number (0 to 1050) and converts it to a base-N number, where 2 <= N <= 10.
        //The input consists of 1 line containing two numbers separated by a single space.
        //The first number is the base N to which you have to convert.The second one is the base 10 number to be converted. 
        //Do not use any built in converting functionality, try to write your own algorythm.

        var arrayOfNumbers = Console.ReadLine().Split(' ').ToArray();

        var baseNumber = int.Parse(arrayOfNumbers[0]);
        var decimalNumber = BigInteger.Parse(arrayOfNumbers[1]);

        var outputNumber = string.Empty;

        var stackOfRemainders = new Stack<string>();

        while (decimalNumber > 0)
        {
            var remainder = decimalNumber % baseNumber;

            stackOfRemainders.Push(remainder.ToString());

            decimalNumber /= baseNumber;

        }

        while (stackOfRemainders.Count > 0)
        {
            outputNumber += stackOfRemainders.Pop();
        }

        Console.WriteLine(outputNumber);
    }
}