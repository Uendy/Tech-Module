using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        // Instructions: Write a program that finds the most frequent number in a given sequence of numbers. 
        //•	Numbers will be in the range[0…65535].
        //•	In case of multiple numbers with the same maximal frequency, print the leftmost of them.

        // Example:
        //         input                output
        // 2 2 2 2 1 2 2 2	              2
        // 7 7 7 0 2 2 2 0 10 10 10       7
        #endregion

        // Reading input:
        var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        var dictionary = new Dictionary<int, int>();

        // Cycling and filling dictionary
        for (int index = 0; index < input.Length; index++)
        {
            int currentNum = input[index];

            bool newNum = !dictionary.ContainsKey(currentNum);
            if (newNum) // add a new kvp to dictionary
            {
                dictionary[currentNum] = 1;
            }
            else // incrament current kvp
            {
                dictionary[currentNum]++;
            }
        }

        // finding most frequent num
        var output = dictionary.OrderByDescending(x => x.Value).First().Key;
        Console.WriteLine(output);
    }
}