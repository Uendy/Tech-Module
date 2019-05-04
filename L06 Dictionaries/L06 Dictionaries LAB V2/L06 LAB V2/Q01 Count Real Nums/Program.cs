using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Read a list of real numbers and print them in ascending order along with their number of occurrences.

        var numbersAndOccurances = new SortedDictionary<double, int>();

        var input = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

        foreach (var number in input)
        {
            bool newNumber = !numbersAndOccurances.ContainsKey(number);
            if (newNumber)
            {
                numbersAndOccurances[number] = 1;
            }
            else
            {
                numbersAndOccurances[number]++;
            }
        }

        numbersAndOccurances.OrderByDescending(x => x.Key);

        foreach (var num in numbersAndOccurances.Keys)
        {
            Console.WriteLine($"{num} -> {numbersAndOccurances[num]} times");
        }
    }
}