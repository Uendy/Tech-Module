using System;
using System.Text.RegularExpressions;
public class Program
{
    public static void Main()
    {
        //check questions here: https://judge.softuni.bg/Contests/Practice/Index/442#0

        //Write a regular expression to match a valid full name.
        //A valid full name consists of two words, each word starts with a capital letter and contains only lowercase letters afterwards; 
        //each word should be at least two letters long; the two words should be separated by a single space. 

        string text = Console.ReadLine();

        string pattern = @"\b[A-Z][a-z]{2,}\s[A-Z][a-z]{2,}";

        var regex = new Regex(pattern);

        var matches = regex.Matches(text);

        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}