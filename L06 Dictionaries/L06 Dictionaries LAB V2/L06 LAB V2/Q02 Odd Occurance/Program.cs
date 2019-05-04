using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main(string[] args)
    {
        //Write a program that extracts from a given sequence of words all elements that present in it odd number of times.

        //•	Words are given in a single line, space separated.
        //•	Print the result elements in lowercase, in their order of appearance.

        var itemsAndOccurances = new Dictionary<string, int>();

        var input = Console.ReadLine().ToLower().Split(' ').ToArray();
        foreach (var item in input)
        {
            bool newItem = !itemsAndOccurances.ContainsKey(item);
            if (newItem)
            {
                itemsAndOccurances[item] = 1;
            }
            else
            {
                itemsAndOccurances[item]++;
            }
        }

        //remove any keys with even numbered values
        itemsAndOccurances = itemsAndOccurances.Where(x => x.Value % 2 != 0).ToDictionary(x => x.Key, y => y.Value);

        string outPut = string.Join(", ", itemsAndOccurances.Keys);
        Console.WriteLine(outPut);
    }
}