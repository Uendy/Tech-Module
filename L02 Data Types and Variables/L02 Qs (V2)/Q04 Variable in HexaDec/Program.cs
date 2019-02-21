using System;


public class Program
{
    public static void Main()
    {
        //Write a program that reads a number in hexadecimal format (0x##) convert it to decimal format and prints it.

        var inputAsHex = Console.ReadLine();
        var inputAsInt = Convert.ToInt32(inputAsHex.ToString(), 16);

        Console.WriteLine(inputAsInt);

    }
}
