using System;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program, which prints all unique pairs in an array of integers,
        //whose sum is equal to a given number. 

        var array = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        int magicNum = int.Parse(Console.ReadLine());

        for (int firstIndex = 0; firstIndex < array.Length - 1; firstIndex++)
        {
            for (int secondIndex = firstIndex + 1; secondIndex < array.Length; secondIndex++)
            {
                if (array[firstIndex] + array[secondIndex] == magicNum)
                {
                    Console.WriteLine($"{array[firstIndex]} {array[secondIndex]}");
                }
            }
        }
    }
}