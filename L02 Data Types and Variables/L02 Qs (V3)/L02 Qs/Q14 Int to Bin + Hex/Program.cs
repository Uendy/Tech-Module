using System;
public class Program
{
    public static void Main()
    {
        // Instructions:Create a program to convert a decimal number to hexadecimal and binary number and print it.

        // Example:
        // Input:   Output:
        //  10         A
        //           1010

        // Reading input:
        int input = int.Parse(Console.ReadLine());

        // Converting:
        var hex = Convert.ToString(input, 16).ToUpper();
        var bin = Convert.ToString(input, 2).ToUpper();

        // Printing:
        Console.WriteLine(hex);
        Console.WriteLine(bin);

    }
}