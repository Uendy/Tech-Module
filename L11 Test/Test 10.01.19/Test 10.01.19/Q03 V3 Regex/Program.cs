using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
public class Program
{
    public static void Main()
    {
        int decoder = int.Parse(Console.ReadLine());

        var kids = new List<string>();

        string pattern = @"@([A-Za-z]+)([^-@!:>]+)?\!G\!";  // group 1 == the name

        string input = Console.ReadLine();
        while (input != "end")
        {
            string decodedString = DecodeString(input, decoder);

            bool isMatch = Regex.IsMatch(decodedString, pattern);
            if (isMatch)
            {
                Match match = Regex.Match(decodedString, pattern);

                string name = match.Groups[1].Value;

                kids.Add(name);
            }

            input = Console.ReadLine();
        }

        foreach (var kid in kids)
        {
            Console.WriteLine(kid);
        }

    }

    //return decoded string: decode by subtracting the key from the value of each character.
    public static string DecodeString(string input, int decoder)
    {
        var inputAsArray = input.ToCharArray();
        var sb = new StringBuilder();
        foreach (var character in inputAsArray)
        {
            char newChar = (char)(character - decoder);
            sb.Append(newChar);
        }

        string outPut = sb.ToString();
        return outPut;
    }
}