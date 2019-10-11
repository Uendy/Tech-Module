using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program that prints the bit at position p of a number.

        //Examples
        //Input   Output
        // 2145 
        //   5      1

        //  512
        //   0      0

        //  111
        //   8      0

        //  255
        //   7      1

        int num = int.Parse(Console.ReadLine());
        int position = int.Parse(Console.ReadLine());

        num = num >> position;
        Console.WriteLine(num & 1);
    }
}