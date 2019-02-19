using System;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        string name = "Alex";
        int age = 20;
        var result = string.Concat(name, " ", age);
        Console.WriteLine(result);


        var text = Console.ReadLine();
        var pattern = Console.ReadLine();

        while (true)
        {
            if (pattern == string.Empty)
            {
                EndingRemarks(text);
            }

            int numberOfSubstring = Regex.Matches(text, pattern).Count; //how many times it's contained'
            bool stillContains = numberOfSubstring >= 2; // gotta check if the pattern is contained atleast twice
            if (stillContains == true)
            {
                var firstIndexOfOccurance = text.IndexOf(pattern);
                text = text.Remove(firstIndexOfOccurance, pattern.Length);

                var lastIndexOfOccurance = text.LastIndexOf(pattern);
                text = text.Remove(lastIndexOfOccurance, pattern.Length);

                var indexInPatternToRemove = pattern.Length / 2;
                pattern = pattern.Remove(indexInPatternToRemove, 1);

                Console.WriteLine("Shaked it.");
            }
            else
            {
                EndingRemarks(text);
            }
        }

    }

    static void EndingRemarks(string text)
    {
        Console.WriteLine("No shake.");
        Console.WriteLine(text);
        Environment.Exit(0);
    }
}