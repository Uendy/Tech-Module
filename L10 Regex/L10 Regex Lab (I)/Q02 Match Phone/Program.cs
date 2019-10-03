using System;
using System.Text.RegularExpressions;
public class Program
{
    public static void Main()
    {
        //Write a regular expression to match a valid phone number from Sofia. 
        //A valid number will start with "+359" followed by the area code (2) and then the number itself, consisting of 7 digits (separated in two group of 3 and 4 digits respectively). 
        //The different parts of the number are separated by either a space or a hyphen ('-').

        //matches ex: +359 2 222 2222, +359-2-213-3245
        //invalid ex: 359-2-222-2222, +359/2/222/2222, +359-2 222 2222

        string text = Console.ReadLine();
        string pattern = @"\+359( |-)2\1\d{3}\1\d{4}";

        var regex = new Regex(pattern);

        var matches = regex.Matches(text);
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}