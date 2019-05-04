using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program to read n integers and print their sum, min, max, first, last and average values.
        int numberOfInputs = int.Parse(Console.ReadLine());

        var listOfNums = new List<int>();
        for (int i = 0; i < numberOfInputs; i++)
        {
            int currentNum = int.Parse(Console.ReadLine());
            listOfNums.Add(currentNum);
        }

        int sum = listOfNums.Sum();
        Console.WriteLine(sum);

        int min = listOfNums.Min();
        Console.WriteLine(min);

        int max = listOfNums.Max();
        Console.WriteLine(max);

        double average = listOfNums.Average();
        Console.WriteLine(average);
    }
}