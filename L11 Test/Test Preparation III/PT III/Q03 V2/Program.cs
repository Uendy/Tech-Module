using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main()
    {
        //getting all the substrings between the numbers
        var seperators = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        string input = Console.ReadLine().ToUpper();
        var stringSegments = input.Split(seperators, StringSplitOptions.RemoveEmptyEntries).ToArray();

        //find out how to extract the digits, but more specifially the numbers in sequence and youll have 2 arrays where the indexs line up for the dict
        var numbers = new List<int>();

        for (int index = 0; index < stringSegments.Count() - 1; index++)
        {
            string firstString = stringSegments[index];
            string secondString = stringSegments[index + 1];

            string numInBetween = Between(input, firstString, secondString);

            int currentNum = int.Parse(numInBetween);
            numbers.Add(currentNum);
        }

        // always have to check the last number as it is not sandwiched between 2 string and wont be counter
        var inputReversed = new string(input.Reverse().Take(2).Reverse().ToArray()); // last 2 digits to see if its a number or digit
        bool numberNotDigit = int.TryParse(inputReversed, out int number);
        if (numberNotDigit)
        {
            numbers.Add(number);
        }
        else // only a digit
        {
            var lastChar = inputReversed[1].ToString();
            var lastDigit = int.Parse(lastChar);
            numbers.Add(lastDigit);
        }

        //copying into a StringBuilder
        var sb = new StringBuilder();
        for (int index = 0; index < numbers.Count(); index++)
        {
            var currentSubString = stringSegments[index];
            var timesCopied = numbers[index];

            for (int i = 0; i < timesCopied; i++)
            {
                sb.Append(currentSubString);
            }
        }

        //Finding the distinct chars and printing
        string outPut = sb.ToString();
        int uniqueChars = outPut.Distinct().Count();

        Console.WriteLine($"Unique symbols used: {uniqueChars}");
        Console.WriteLine(outPut);
    }
    public static string Between(string str, string firstString, string lastString)
    {
        int pos1 = str.IndexOf(firstString) + firstString.Length;
        int pos2 = str.Substring(pos1).IndexOf(lastString);
        return str.Substring(pos1, pos2);
    }
}