using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Read a list of decimal numbers and sort them in increasing order.
        //Print the output as shown in the examples below.

        var array = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

        array = array.OrderBy(x => x).ToArray();

        string outPut = string.Join(" <= ", array);
        Console.WriteLine(outPut);
    }
}