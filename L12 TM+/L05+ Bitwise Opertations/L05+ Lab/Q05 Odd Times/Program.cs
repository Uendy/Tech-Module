using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Given an array of positive integers in a single line joined by space(' '). 
        //All numbers occur even number of times except one number which occurs odd number of times. Find the number.
        // Examples
        //     Input           Output
        // 1 2 3 2 3 1 3         3
        // 5 7 2 7 5 2 5         5

        var numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int number = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            number ^= numbers[i];
        }

        Console.WriteLine(number);
    }
}