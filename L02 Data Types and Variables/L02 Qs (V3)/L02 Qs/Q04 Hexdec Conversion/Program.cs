using System;
public class Program
{
    public static void Main()
    {
        // Requirment: Write a program that reads a number in hexadecimal format (0x##) convert it to decimal format and prints it.

        // Example: 
        // Input	Output
        //  0xFE    254
        //  0x37    55
        //  0x10    16

        // Reading input:
        string input = Console.ReadLine();

        // Converting:
        int decimalNum = Convert.ToInt32(input, 16);

        // Printing output:
        Console.WriteLine(decimalNum);
    }
}