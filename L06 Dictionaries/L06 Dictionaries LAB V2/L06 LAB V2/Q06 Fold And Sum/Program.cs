using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Read an array of 4*k integers, fold it like shown below, and print the sum of the upper and lower rows (2*k integers)

        var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int k = arr.Length / 4;

        var rowLeft = arr.Take(k).Reverse();
        var rowRight = arr.Reverse().Take(k);

        var topRow = rowLeft.Concat(rowRight).ToArray();
        var botRow = arr.Skip(k).Take(2 * k).ToArray();

        var sumArr = topRow.Select((x, index) => x + botRow[index]);
        Console.WriteLine(string.Join(" ", sumArr));
    }
}