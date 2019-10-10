using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        var input = int.Parse(Convert.ToString(int.Parse(Console.ReadLine()),2));
        var shifted = input >> 1;
        Console.WriteLine(shifted & 1);

    }
}