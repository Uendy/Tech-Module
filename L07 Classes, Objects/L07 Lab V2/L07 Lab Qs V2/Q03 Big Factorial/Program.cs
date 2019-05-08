using System;
using System.Numerics;

public class Program
{
    public static void Main()
    {
        //Calculate and print n! (n factorial) for very big integer n (e.g. 1000).

        var num = int.Parse(Console.ReadLine());

        var bigFac = new BigInteger();

        bigFac = num;
        for (int index = num - 1; index > 0; index--)
        {
            bigFac *= index;
        }

        Console.WriteLine(bigFac);
    }
}