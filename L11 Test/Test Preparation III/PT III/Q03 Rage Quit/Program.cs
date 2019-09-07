using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main()
    {
        //Every gamer knows what rage - quitting means.It’s basically when you’re just not good enough and you blame everybody else for losing a game.
        //You press the CAPS LOCK key on the keyboard and flood the chat with gibberish to show your frustration.

        //Chochko is a gamer, and a bad one at that.
        //He asks for your help; he wants to be the most annoying kid in his team, so when he rage - quits he wants something truly spectacular.
        //He’ll give you a series of strings followed by non - negative numbers, e.g. "a3"; you need to print on the console each string repeated N times; 
        //convert the letters to uppercase beforehand. In the example, you need to write back "AAA".

        //On the output, print first a statistic of the number of unique symbols used(the casing of letters is irrelevant, meaning that 'a' and 'A' are the same);
        //the format shoud be "Unique symbols used {0}".Then, print the rage message itself.

        //The strings and numbers will not be separated by anything. The input will always start with a string and for each string there will be a corresponding number.
        //The entire input will be given on a single line; Chochko is too lazy to make your job easier.

        string input = Console.ReadLine().ToUpper();
        var asCharArray = input.ToCharArray().ToList();

        var uniqueChars = new List<char>();
        var stringSegments = new Dictionary<string, int>();

        int lastIndexOfDigit = 0;

        for (int index = 0; index < asCharArray.Count(); index++)
        {
            var currentChar = asCharArray[index];
            bool isDigit = char.IsDigit(currentChar);
            if (isDigit)
            {
                //the substring that will be printed
                int count = index - lastIndexOfDigit;
                var currentRange = asCharArray.GetRange(lastIndexOfDigit, count).ToArray();
                var currentString = new string(currentRange);

                //how manyTimes to print  
                bool lastIndex = index == asCharArray.Count() - 1; //dealing with the problem if it is over 9
                if (!lastIndex)
                {
                    bool doubleDigitNumber = char.IsDigit(asCharArray[index + 1]);
                    if (doubleDigitNumber)
                    {
                        var currentNumberAsArray = asCharArray.GetRange(index, 2).ToArray();
                        var currentNumberAsString = new string(currentNumberAsArray);
                        var currentNumber = int.Parse(currentNumberAsString);

                        lastIndexOfDigit = index + 2; 
                        stringSegments[currentString] = currentNumber;

                        index += 1;
                        continue;
                    }
                }
                var currentDigit = currentChar.ToString();
                lastIndexOfDigit = index + 1;
                int printTimes = int.Parse(currentDigit);

                stringSegments[currentString] = printTimes;

                continue;
            }

            bool newChar = !uniqueChars.Contains(currentChar); // new char to be added to unique chars count
            if (newChar)
            {
                uniqueChars.Add(currentChar);
            }
        }

        //printing
        Console.WriteLine($"Unique symbols used: {uniqueChars.Count()}");

        var sb = new StringBuilder();
        foreach (var kvp in stringSegments) //getting each segment (kvp.Key) print N time (kvp.Value)
        {
            for (int i = 0; i < kvp.Value; i++)
            {
                sb.Append(kvp.Key);
            }
        }

        string output = sb.ToString();
        Console.WriteLine(output);
    }
}