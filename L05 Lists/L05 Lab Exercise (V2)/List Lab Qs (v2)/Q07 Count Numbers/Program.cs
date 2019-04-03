using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        //Read a list of integers in range [0…1000] and print them in ascending order along with their number of occurrences.

        var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        var dictOfOccurance = new Dictionary<int, int>();
        var listOfKeys = new List<int>();

        foreach (var num in array)
        {
            bool newKey = !dictOfOccurance.ContainsKey(num);
            if (newKey == true)
            {
                dictOfOccurance[num] = 1;
                listOfKeys.Add(num);
            }
            else
            {
                dictOfOccurance[num]++;
            }
        }

        listOfKeys.Sort();
        foreach (var key in listOfKeys)
        {
            Console.WriteLine($"{key} -> {dictOfOccurance[key]}");
        }
    }
}