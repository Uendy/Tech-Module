using System;
public class Program
{
    public static void Main()
    {
        // Instructions: Given an input integer, you must determine which primitive data types are capable of properly storing that input.

        // Input: 
        // •	You receive N – integer which can be arbitrarily large or small

        // Output:
        // You must determine if the given primitives are capable of storing it.If yes, then print:
        // { N} can fit in:
        // *dataType

        // If there is more than one appropriate data type, print each one on its own line and order them by size
        // (sbyte < byte < short < ushort < int < uint < long).

        // If the number cannot be stored in one of the four aforementioned primitives, print the line: 
        // { N}  can't fit in any type

        // Example: 
        //   Input	                 Output
        // 1500000000          1500000000 can fit in:
        //                          *int
        //                          * uint
        //                          * long

        // Example 2: 
        //          Input                                                     Output
        // 213333333333333333333333333333333333    213333333333333333333333333333333333 can't fit in any type

        // Reading input:
        string input = Console.ReadLine();

        try
        {
            ulong inputParsed = ulong.Parse(input);
        }
        catch (Exception)
        {
            Console.WriteLine($"{input} can't fit in any type");
            throw;
        }
    }
}