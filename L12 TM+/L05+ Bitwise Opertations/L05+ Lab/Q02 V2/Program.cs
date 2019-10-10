using System;
public class Program
{
    public static void Main()
    {
        var input = int.Parse(Console.ReadLine());
        var shifted = input >> 1;
        Console.WriteLine(shifted & 1);

    }
}