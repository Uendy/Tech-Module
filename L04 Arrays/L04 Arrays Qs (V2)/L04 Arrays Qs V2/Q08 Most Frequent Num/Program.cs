using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        //Write a program that finds the most frequent number in a given sequence of numbers. 
        //•	Numbers will be in the range[0…65535].
        //•	In case of multiple numbers with the same maximal frequency, print the leftmost of them.

        var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        var dictOfNums = new Dictionary<int, int>();
        var listOfKeys = new List<int>();

        foreach (var num in array) // to sort them into dictionary
        {
            bool newNum = !dictOfNums.ContainsKey(num);
            if (newNum == true)
            {
                dictOfNums[num] = 1;
                listOfKeys.Add(num);
            }
            else
            {
                dictOfNums[num]++;
            }
        }

        int bestKey = 0;
        int max = 0;

        foreach (var keyNum in listOfKeys) // finds the bestKey + if two values are even will choose leftmost one
        {
            var currentValue = dictOfNums[keyNum];
            if (currentValue > max)
            {
                bestKey = keyNum;
                max = keyNum;
            }
        }

        Console.WriteLine(bestKey);
    }
}