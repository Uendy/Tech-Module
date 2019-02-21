using System;

public class Program
{
    public static void Main()
    {
        //Create a program to convert a decimal number to hexadecimal and binary number and print it.

        int input = int.Parse(Console.ReadLine());

        string inputAsHex = Convert.ToString(input, 16);
        string inputAsBinary = Convert.ToString(input, 2);

        Console.WriteLine(inputAsHex.ToUpper());
        Console.WriteLine(inputAsBinary);
    }
}
