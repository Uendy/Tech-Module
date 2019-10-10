using System;
using System.Text.RegularExpressions;
public class Program
{
    public static void Main()
    {
        int input = int.Parse(Console.ReadLine());
        string searchedBit = Console.ReadLine();

        string binary = Convert.ToString(input, 2); //convert to binary

        string pattern = $@"{searchedBit}";
        var regex = new Regex(pattern);
        var matches = regex.Matches(binary).Count;
        Console.WriteLine(matches);
    }
}