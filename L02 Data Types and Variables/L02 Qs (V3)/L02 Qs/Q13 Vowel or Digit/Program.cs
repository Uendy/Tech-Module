using System;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        // Instructions: Create a program to check if given symbol is digit, vowel or any other symbol.

        // Example:
        // Intro:       Outro:
        //  a           vowel
        //  9           digit
        //  g           other

        // Setting up vowel and digit collections:
        List<char> vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
        List<char> digits = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

        // Reading input char:
        char input = char.Parse(Console.ReadLine().ToLower());

        // Checking if it belongs to any collection and print:
        if (vowels.Contains(input) || digits.Contains(input))
        {
            if (vowels.Contains(input))
            {
                Console.WriteLine("vowel");
            }
            else
            {
                Console.WriteLine("digit");
            }
        }
        else
        {
            Console.WriteLine("other");
        }
        
    }
}