using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
public class Program
{
    public static void Main()
    {
        //Write a program that extracts all sentences that contain a particular word from a string (case-sensitive).
        //•	Assume that the sentences are separated from each other by the character "." or "!" or "?".
        //•	The words are separated by a non - letter character.
        //•	Note that a substring is different than a word. The sentence “I am a fan of Motorhead” does not contain the word “to”. 
        //It contains the substring “to”, which is not what we need.
        //•	Print the result text without the separators between the sentences("." or "!" or "?").

        string pattern = Console.ReadLine();
        string result = $" {pattern} ";

        string input = Console.ReadLine();
        var inputTokens = input.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        var regex = new Regex(result);
        foreach (var line in inputTokens)
        {
            bool containsPattern = regex.IsMatch(line);
            if (containsPattern)
            {
                Console.WriteLine(line.Trim());
            }
        }
    }
}