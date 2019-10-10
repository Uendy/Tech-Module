using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program that prints the bit at position 1 of a number.
        //Examples
        //Input     Output
        //   2         1
        //   51        1
        //   13        0
        //   24        0

        var input = Convert.ToString(int.Parse(Console.ReadLine()), 2);
        var firstbit = input.Reverse().Skip(1).First(); // reverse it, skip the last (now first index) and take the bit at position number 1
        Console.WriteLine(firstbit);
    }
}