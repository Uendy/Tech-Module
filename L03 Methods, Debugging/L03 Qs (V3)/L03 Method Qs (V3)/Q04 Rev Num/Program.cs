using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        // Instructions: Write a method that prints the digits of a given decimal number in a reversed order.
        // Example:
        // Input	Output
        //  256      652
        //  1.12	 21.1

        // Reading input:
        string input = Console.ReadLine();
        double reversedNum = reverseNum(input);

        Console.WriteLine(reversedNum);
    }

    /// Reverses the num and returns it as a double
    private static double reverseNum(string input)
    {
        var stringAsArray = input.ToCharArray();
        var stringReversed = string.Concat(stringAsArray.Reverse());
        double output = double.Parse(stringReversed);

        return output;
    }
}