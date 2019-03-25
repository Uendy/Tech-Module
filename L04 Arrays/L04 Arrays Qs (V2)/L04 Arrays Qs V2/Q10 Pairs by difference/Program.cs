using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program that count the number of pairs in given array which difference is equal to given number.
        // Input
        //•	The first line holds the sequence of numbers.
        //•	The second line holds the difference.

        var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var difference = int.Parse(Console.ReadLine());

        int numberOfPairs = 0;

        for (int index = 0; index < array.Length - 1; index++)
        {
            var currentNum = array[index];
            for (int i = index + 1; i < array.Length; i++)
            {
                var secondNum = array[i];
                bool isPair = Math.Abs(secondNum - currentNum) == difference;
                if (isPair == true)
                {
                    numberOfPairs++;
                }
            }
        }

        Console.WriteLine(numberOfPairs);
    }
}