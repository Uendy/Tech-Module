using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        //Write a program that extracts from a given text all palindromes, e.g. ABBA, lamal, exe 
        //prints them on the console on a single line, separated by comma and space. 
        //Use spaces, commas, dots, question marks and exclamation marks as word delimiters.
        //Print only unique palindromes, sorted lexicographically.

        string inputText = Console.ReadLine();
        var listOfStrings = inputText.Split(new[] { ',', '.', ' ', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();

        var listOfPalindromes = new List<string>();
        foreach (var word in listOfStrings)
        {
            int size = word.Length;
            int halfSize = size / 2;

            var wordAsCharArray = word.ToCharArray();

            var firstHalfAsArray = wordAsCharArray.Take(halfSize).ToArray();
            var firstHalf = string.Concat(firstHalfAsArray);
            var secondHalfAsArray = wordAsCharArray.Reverse().Take(halfSize).ToArray();
            var secondHalf = string.Concat(secondHalfAsArray);

            if (firstHalf.Equals(secondHalf))
            {
                listOfPalindromes.Add(word);
            }
        }

        string outPut = string.Join(", ", listOfPalindromes.OrderBy(x => x));
        Console.WriteLine(outPut);
    }
}