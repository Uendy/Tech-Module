using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        //Create a program to check if given symbol is digit, vowel or any other symbol.

        char input = char.Parse(Console.ReadLine());
        int inputAsInt = Convert.ToInt32(input);
        int[] arrayOfVowelAsInts = new[] { 97, 101, 105, 111, 117 }; // only lower case vowels

        if (inputAsInt >= 48 && inputAsInt <= 57)
        {
            Console.WriteLine("digit");
        }
        else if (arrayOfVowelAsInts.Contains(inputAsInt))
        {
            Console.WriteLine("vowel");
        }
        else
        {
            Console.WriteLine("other");
        }
    }
}
